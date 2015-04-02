using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Web;
using System.Windows.Forms;
using GodLesZ.Tools.WebScraper.Forms;
using GodLesZ.Tools.WebScraper.Properties;
using SHDocVw;
using Timer = System.Timers.Timer;
using WebBrowser = System.Windows.Forms.WebBrowser;

namespace GodLesZ.Tools.WebScraper.Library {
    internal class WebMiner {
        private RegistrationManager regManager = new RegistrationManager();
        private ArrayList xpathList = new ArrayList();
        private int currentPage = 1;
        public string categoryTagColName = "CategoryColumn";
        private string urlHost = "";
        private string urlGoogle = "http://www.google.com";
        private string lastMinedUrl = "";
        private string userAgentString = "Mozilla/5.0 (Windows; U; MSIE 9.0; WIndows NT 9.0; en-US))";
        private ProxyManager proxyManager = new ProxyManager();
        private ManualResetEvent resumeEvent = new ManualResetEvent(false);
        private ManualResetEvent pauseEvent = new ManualResetEvent(false);
        private MineParams mineParams;
        private UrlData startURL;
        private ArrayList fieldList;
        private UrlData targetUrl;
        private bool targetDataAvailable;
        private UrlData lastPageURL;
        private bool lastPageURLAvailable;
        private bool allowNavigate;
        private bool pageLoaded;
        private bool pageLoadError;
        private HtmlElement activeElement;
        private Thread mineThread;
        private string imgDirectoryPath;
        private string fileDirectoryPath;
        private bool autoScroll;
        private int recordsMined;
        private int autoSavePoint;
        private int autoSaveLastRowSaved;
        private int duplicateCheckPoint;
        private int totalPagesMined;
        private int currentCategory;
        public bool enableCategoryTagging;
        private bool resumeAbortedMining;
        private DataGridView dataGridView;
        private DataTable dataTable;
        private ToolStripTextBox statusStrip;
        public EventHandler OnMineEnd;
        private bool paused;
        private Timer pauseInjectionTimer;

        public bool ResumeAbortedMining {
            set {
                resumeAbortedMining = value;
            }
        }

        public bool IsPaused {
            get {
                return paused;
            }
        }

        public int PagesMined {
            get {
                return totalPagesMined;
            }
        }

        public int CurrentPage {
            get {
                return currentPage;
            }
        }

        public int CurrentCategory {
            get {
                return currentCategory;
            }
        }

        public DataTable MineData {
            get {
                return dataTable;
            }
        }

        public string FileCaptureDirectory {
            set {
                fileDirectoryPath = value;
            }
        }

        public string ImageCaptureDirectory {
            set {
                imgDirectoryPath = value;
            }
        }

        public bool AutoScroll {
            set {
                autoScroll = value;
            }
        }

        public string LastURL {
            get {
                return lastMinedUrl;
            }
        }

        public WebMiner(MineParams mParams, DataGridView dataView, ToolStripTextBox toolStripText) {
            mineParams = mParams;
            startURL = mineParams.StartURL;
            fieldList = mParams.FieldList;
            dataGridView = dataView;
            dataTable = new DataTable();
            dataView.DataSource = dataTable;
            statusStrip = toolStripText;
        }

        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetCheckConnection(string lpszUrl, int dwFlags, int dwReserved);

        public void ScrollDataView() {
            if (dataTable.Rows.Count <= 0)
                return;
            dataGridView.FirstDisplayedScrollingRowIndex = dataTable.Rows.Count - 1;
        }

        private void HandleAutoScroll() {
            if (!autoScroll)
                return;
            dataGridView.Invoke(new ScrollDataViewCallBack(ScrollDataView), null);
        }

        public void UpdateStatus(string strStatus) {
            statusStrip.Text = strStatus;
        }

        private void SetStatus(string strStatus) {
            strStatus = "[" + MineData.Rows.Count.ToString() + " " + StringResource.RecordsMined + " from " + totalPagesMined.ToString() + (totalPagesMined <= 1 ? " Page" : " Pages") + "]  " + strStatus;
            statusStrip.Owner.Invoke(new UpdateStatusCallBack(UpdateStatus), (object)strStatus);
        }

        public void DataTableAddColumn(string columnName) {
            dataTable.Columns.Add(columnName, typeof(string));
        }

        public void DataTableAddRow(DataRow dataRow) {
            dataTable.Rows.Add(dataRow);
        }

        public void DataTableRemoveRow(int row) {
            dataTable.Rows.RemoveAt(row);
        }

        public void DataTableAssignCell(int row, string column, string value) {
            dataTable.Rows[row][column] = value;
        }

        private bool DuplicateRowExists(DataRow newRow) {
            var flag1 = false;
            var itemArray1 = newRow.ItemArray;
            foreach (DataRow dataRow in (InternalDataCollectionBase)dataTable.Rows) {
                var itemArray2 = dataRow.ItemArray;
                var flag2 = true;
                if (dataRow.Equals(newRow)) {
                    flag2 = false;
                } else {
                    for (var index = 0; index < itemArray2.Length; ++index) {
                        if (!itemArray2[index].ToString().Equals(itemArray1[index].ToString())) {
                            flag2 = false;
                            break;
                        }
                    }
                }
                if (flag2) {
                    flag1 = true;
                    break;
                }
            }
            return flag1;
        }

        private string GetAbsoluteHost(string host) {
            var str = host;
            if (str != null && str.LastIndexOf('.') != -1) {
                while (str.IndexOf('.') != str.LastIndexOf('.'))
                    str = str.Substring(str.IndexOf('.') + 1);
            }
            return str;
        }

        private void ie_NavigateError(object pDisp, ref object URL, ref object Frame, ref object StatusCode, ref bool Cancel) {
            if (Frame != null)
                return;
            try {
                if (URL != null) {
                    if (GetAbsoluteHost(new Uri((string)URL).Host) != urlHost)
                        return;
                }
            } catch (Exception ex) {
                return;
            }
            Cancel = true;
            pageLoadError = true;
        }

        private void ie_BeforeNavigate2(object pDisp, ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel) {
            if (!targetDataAvailable && (URL as string).ToLower().StartsWith("http")) {
                targetUrl.url = (string)URL;
                targetUrl.headers = (string)Headers;
                targetUrl.postData = (byte[])PostData;
                targetDataAvailable = true;
            }
            if (allowNavigate || !targetDataAvailable)
                return;
            Cancel = true;
        }

        private void browser_NewWindow(object sender, CancelEventArgs e) {
            var webBrowser = sender as WebBrowser;
            e.Cancel = true;
            if (!(activeElement != null))
                return;
            webBrowser.Navigate(activeElement.GetAttribute("href"), null, null, null);
        }

        private void newBrowser_NewWindow(object sender, CancelEventArgs e) {
            e.Cancel = true;
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            var webBrowser = sender as WebBrowser;
            if (webBrowser == null || !(e.Url.AbsolutePath == webBrowser.Url.AbsolutePath) || webBrowser.ReadyState != WebBrowserReadyState.Complete)
                return;
            pageLoaded = true;
        }

        private void PrepareDataTable() {
            foreach (DataField datafield in fieldList) {
                if (datafield.type == EDataType.Text || datafield.type == EDataType.Text_Near_Heading || (datafield.type == EDataType.HTML || datafield.type == EDataType.Url) || (datafield.type == EDataType.Image || datafield.type == EDataType.Image_RegEx || (datafield.type == EDataType.Image_URL || datafield.type == EDataType.File)))
                    dataGridView.Invoke(new DataTableAddColumCallBack(DataTableAddColumn), (object)datafield.name);
            }
            try {
                if (!enableCategoryTagging || (mineParams.CategoryList == null || mineParams.CategoryList.Count <= 1) && (mineParams.KeywordList == null || mineParams.KeywordList.Count <= 1))
                    return;
                dataGridView.Invoke(new DataTableAddColumCallBack(DataTableAddColumn), (object)categoryTagColName);
            } catch (Exception ex) {
            }
        }

        private void StartPauseInjectionTimer() {
            pauseInjectionTimer = new Timer();
            pauseInjectionTimer.Elapsed += pauseInjectionTimer_Elapsed;
            pauseInjectionTimer.Interval = (uint)((int)Settings.Default.MinerPauseInterval * 60 * 1000);
            pauseInjectionTimer.Start();
        }

        private void pauseInjectionTimer_Elapsed(object sender, ElapsedEventArgs e) {
            pauseInjectionTimer.Stop();
            if (!pauseEvent.WaitOne(0)) {
                Pause();
                pauseEvent.WaitOne();
                SetStatus(StringResource.MineInjectPaused);
                Thread.Sleep((int)Settings.Default.MinerPauseTime * 60 * 1000);
                Resume();
            }
            pauseInjectionTimer.Start();
        }

        private void StopPauseInjectionTimer() {
            pauseInjectionTimer.Stop();
        }

        public void StartWebMine() {
            mineThread = new Thread(WebMine);
            mineThread.SetApartmentState(ApartmentState.STA);
            if (Settings.Default.MinerInjectPauses)
                StartPauseInjectionTimer();
            mineThread.Start();
        }

        public void StopWebMine() {
            mineThread.Abort();
            proxyManager.stop();
            if (!Settings.Default.MinerInjectPauses)
                return;
            StopPauseInjectionTimer();
        }

        public void Pause() {
            lock (pauseEvent)
                paused = true;
        }

        public void Resume() {
            lock (pauseEvent) {
                if (!paused)
                    return;
                paused = false;
                if (!pauseEvent.WaitOne(0))
                    return;
                resumeEvent.Set();
            }
        }

        private bool HandleDuplicateRemoval() {
            var flag = false;
            if (Settings.Default.MinerRemoveDuplicates && dataTable.Rows.Count != 0) {
                SetStatus(StringResource.MineRemovingDuplicates);
                if (dataTable.Rows.Count - 1 > duplicateCheckPoint) {
                    for (var index = dataTable.Rows.Count - 1; index > duplicateCheckPoint; --index) {
                        if (DuplicateRowExists(dataTable.Rows[index]))
                            dataGridView.Invoke(new DataTableRemoveRowCallBack(DataTableRemoveRow), (object)index);
                    }
                    if (duplicateCheckPoint == dataTable.Rows.Count - 1)
                        flag = true;
                    duplicateCheckPoint = dataTable.Rows.Count - 1;
                }
                SetStatus(StringResource.MineFormStart);
            }
            return flag;
        }

        private void HandleAutoSave(bool forceSave = false) {
            if (!Settings.Default.MinerAutoSave || !forceSave && dataTable.Rows.Count <= autoSavePoint)
                return;
            autoSavePoint = dataTable.Rows.Count + Settings.Default.MinerAutoSaveRowCount;
            SetStatus(StringResource.MineAutoSavingData);
            var exportForm = new ExportForm();
            exportForm.MineData = dataTable;
            var count = dataTable.Rows.Count;
            var str = Settings.Default.MinerAutoSaveFileName;
            if (string.Empty == Path.GetExtension(str))
                str = str + mineParams.ConfigName;
            else if (mineParams.ConfigName != string.Empty)
                str = str.Insert(str.LastIndexOf("."), "-" + mineParams.ConfigName);
            exportForm.ExportData(str, EExportFormat.UnKnown, autoSaveLastRowSaved != 0, autoSaveLastRowSaved, count);
            autoSaveLastRowSaved = count;
            SetStatus(StringResource.MineFormStart);
        }

        private void HandleAutoScrollPagination(WebBrowser browser) {
            var flag1 = false;
            var flag2 = false;
            try {
                foreach (DataField datafield in fieldList) {
                    if (datafield.type == EDataType.Auto_Scroll)
                        flag1 = true;
                    if (datafield.type == EDataType.Link_NextPage || datafield.type == EDataType.Link_LoadMoreContent)
                        flag2 = true;
                }
                if (!flag1 || flag2)
                    return;
                browser.Height = 800;
                browser.Width = 600;
                allowNavigate = true;
                for (var index = 0; index < mineParams.PageMaxCount - 1; ++index) {
                    SetStatus("Loading Page " + (index + 2).ToString() + " of " + mineParams.PageMaxCount.ToString());
                    HandlePauseResume();
                    browser.Navigate("javascript:window.scroll(0,document.body.scrollHeight);");
                    WaitForAjaxLoad();
                    ++totalPagesMined;
                }
                allowNavigate = false;
                SetStatus(StringResource.MineFormStart);
            } catch (Exception ex) {
                allowNavigate = false;
            }
        }

        private void HandleLoadMoreContentOption(WebBrowser browser) {
            var flag = false;
            var datafield1 = new DataField();
            foreach (DataField datafield2 in fieldList) {
                if (datafield2.type == EDataType.Link_LoadMoreContent) {
                    flag = true;
                    datafield1 = datafield2;
                    break;
                }
            }
            if (!flag)
                return;
            for (var index = 0; index < mineParams.PageMaxCount - 1; ++index) {
                SetStatus("Loading Page " + (index + 2).ToString() + " of " + mineParams.PageMaxCount.ToString());
                HandlePauseResume();
                var nextPageElement = HtmlParser.GetNextPageElement(browser.Document, datafield1.name, index + 2);
                if (!(nextPageElement == null)) {
                    allowNavigate = true;
                    nextPageElement.InvokeMember("click");
                    WaitForPageLoad();
                    browser.Stop();
                    allowNavigate = false;
                    ++totalPagesMined;
                } else
                    break;
            }
            SetStatus(StringResource.MineFormStart);
        }

        private void HandlePauseResume() {
            if (!paused)
                return;
            SetStatus(StringResource.MinePaused);
            lock (pauseEvent)
                pauseEvent.Set();
            resumeEvent.WaitOne();
            lock (pauseEvent) {
                resumeEvent.Reset();
                pauseEvent.Reset();
            }
            SetStatus(StringResource.MineFormStart);
        }

        public void WebMine() {
            var str1 = "";
            var str2 = "";
            var str3 = "";
            Encoding encoding = new UTF8Encoding();
            var asciiEncoding = new ASCIIEncoding();
            var unicodeEncoding = new UnicodeEncoding();
            if (!resumeAbortedMining) {
                recordsMined = 0;
                autoSavePoint = Settings.Default.MinerAutoSaveRowCount;
                autoSaveLastRowSaved = 0;
                totalPagesMined = 0;
                currentCategory = 0;
                duplicateCheckPoint = 0;
                PrepareDataTable();
            }
            try {
                var s = "";
                var str4 = "";
                do {
                    do {
                        WebMineThread();
                        HandleAutoScroll();
                        if (!regManager.Registered) {
                            if (currentCategory >= 1)
                                goto label_24;
                        }
                        if (mineParams.CategoryList != null && mineParams.CategoryList.Count > 1) {
                            startURL = mineParams.StartURL;
                            if (currentCategory == 0) {
                                var urldata = (UrlData)mineParams.CategoryList[0];
                                var length = startURL.url.ToLower().IndexOf(urldata.url.ToLower());
                                if (length != 0)
                                    str2 = startURL.url.Substring(0, length);
                                if (length + urldata.url.Length < startURL.url.Length)
                                    str1 = startURL.url.Substring(length + urldata.url.Length);
                            }
                            ++currentCategory;
                            if (currentCategory < mineParams.CategoryList.Count) {
                                var urldata = (UrlData)mineParams.CategoryList[currentCategory];
                                startURL.url = str2 + urldata.url + str1;
                            } else
                                goto label_24;
                        } else if (mineParams.KeywordList != null) {
                            if (mineParams.KeywordList.Count > 1) {
                                s = "";
                                if (str3 == "")
                                    str3 = mineParams.KeywordList[0].ToString();
                                ++currentCategory;
                                if (currentCategory < mineParams.KeywordList.Count) {
                                    str4 = mineParams.KeywordList[currentCategory].ToString();
                                    startURL = mineParams.StartURL;
                                    if (!startURL.url.Contains(str3)) {
                                        str3 = HttpUtility.UrlEncode(str3);
                                        str4 = HttpUtility.UrlEncode(str4);
                                    }
                                    startURL.url = startURL.url.Replace(str3, str4);
                                    if (startURL.postData != null) {
                                        s = encoding.GetString(startURL.postData).Replace(str3, str4);
                                        startURL.postData = encoding.GetBytes(s);
                                    }
                                } else
                                    goto label_24;
                            } else
                                goto label_24;
                        } else
                            goto label_24;
                    }
                    while (-1 != startURL.url.IndexOf(str4));
                }
                while (-1 != s.IndexOf(str4));
            } catch (Exception ex) {
            }
        label_24:
            proxyManager.stop();
            OnMineEnd(this, null);
        }

        public void WebMineThread() {
            SetStatus(StringResource.MineFormStart);
            var browser = new WebBrowser();
            browser.ScriptErrorsSuppressed = true;
            var internetExplorer = browser.ActiveXInstance as InternetExplorer;
            internetExplorer.BeforeNavigate2 += ie_BeforeNavigate2;
            internetExplorer.NavigateError += ie_NavigateError;
            browser.DocumentCompleted += browser_DocumentCompleted;
            browser.NewWindow += browser_NewWindow;
            while (true) {
                allowNavigate = true;
                targetDataAvailable = false;
                pageLoaded = false;
                pageLoadError = false;
                if (Settings.Default.ProxyEnabled) {
                    proxyManager.stop();
                    browser.Navigate("about:blank");
                    (browser.ActiveXInstance as IOleObject).SetClientSite(proxyManager);
                    proxyManager.Start();
                    browser.Navigate("about:blank");
                    Application.DoEvents();
                }
                browser.Navigate(startURL.url, null, startURL.postData, startURL.headers);
                WaitForPageLoad();
                browser.Stop();
                allowNavigate = false;
                if (pageLoadError && !InternetConnected())
                    WaitForInternet();
                else
                    break;
            }
            if (browser.Url != null)
                urlHost = GetAbsoluteHost(browser.Url.Host);
            currentPage = 1;
            if (resumeAbortedMining) {
                NavigateToLastMinedPage(browser);
                currentPage = totalPagesMined + 1;
            }
            HandleLoadMoreContentOption(browser);
            HandleAutoScrollPagination(browser);
            bool flag;
            do {
                flag = false;
                HandlePauseResume();
                if (!HandleDuplicateRemoval()) {
                    HandleAutoSave(false);
                    SetStatus(string.Concat(new object[]
                    {
                        StringResource.MineProgress,
                        currentPage.ToString(),
                        " - ",
                        browser.Url
                    }));
                    lastMinedUrl = browser.Url.ToString();
                    recordsMined = dataTable.Rows.Count;
                    ++totalPagesMined;
                    for (var index = 0; index < fieldList.Count; ++index) {
                        var datafield = (DataField)fieldList[index];
                        switch (datafield.type) {
                            case EDataType.Text:
                            case EDataType.Url:
                            case EDataType.Image:
                            case EDataType.Image_RegEx:
                            case EDataType.Image_URL:
                            case EDataType.HTML:
                            case EDataType.File:
                            case EDataType.Text_Near_Heading:
                                GetData(browser, index, null);
                                goto default;
                            case EDataType.Link_Follow:
                            case EDataType.Link_RegEx:
                                VisitURLandGetData(browser, index);
                                while (index < fieldList.Count && ((DataField)fieldList[index]).type != EDataType.Link_Back)
                                    ++index;
                                goto default;
                            case EDataType.Link_NextPage:
                                HandleAutoScroll();
                                if (currentPage != mineParams.PageMaxCount) {
                                    SetStatus(StringResource.MineLoadingPage + (currentPage + 1).ToString());
                                    flag = NavigateToNextPage(browser, index, currentPage + 1);
                                    if (!flag && !InternetConnected()) {
                                        WaitForInternet();
                                        allowNavigate = true;
                                        pageLoaded = false;
                                        browser.GoBack();
                                        WaitForPageLoad();
                                        browser.Stop();
                                        allowNavigate = false;
                                        --index;
                                        break;
                                    } else
                                        goto default;
                                } else
                                    goto default;
                            case EDataType.Click:
                                var firstElement = GetFirstElement(browser.Document, datafield.xpath, index);
                                allowNavigate = true;
                                HtmlParser.PerformClicks(firstElement, datafield.pattern);
                                WaitForAjaxLoad();
                                allowNavigate = false;
                                goto default;
                            default:
                                if (datafield.type == EDataType.Link_NextPage)
                                    goto label_24;
                                else
                                    break;
                        }
                    }
                label_24: ;
                } else
                    break;
            }
            while ((currentPage++ < mineParams.PageMaxCount || mineParams.PageMaxCount == -1) && flag);
            HandleDuplicateRemoval();
            HandleAutoSave(true);
            browser.Dispose();
        }

        private void WaitForInternet() {
            SetStatus(StringResource.MineNetworkLost);
            while (true) {
                Application.DoEvents();
                if (!InternetConnected())
                    Thread.Sleep(2000);
                else
                    break;
            }
            SetStatus(StringResource.MineNetworkBackLive);
        }

        private void MarkUnassignedCells() {
            for (var index = 0; index < dataTable.Rows.Count; ++index) {
                foreach (DataColumn dataColumn in dataTable.Columns) {
                    if (dataTable.Rows[index][dataColumn.ColumnName].ToString() == "")
                        dataGridView.Invoke(new DataTableAssignCellCallBack(DataTableAssignCell), (object)index, (object)dataColumn.ColumnName, (object)" ");
                }
            }
        }

        private bool GetData(WebBrowser browser, int i, string pgLinkXpath) {
            var flag = true;
            var datafield = (DataField)fieldList[i];
            var element = GetFirstElement(browser.Document, datafield.xpath, i);
            if (datafield.pattern)
                HtmlParser.ResetState();
            while (!(element == null) || datafield.type == EDataType.Text_Near_Heading) {
                if (datafield.name == dataTable.Columns[0].ColumnName) {
                    var dataRow = dataTable.NewRow();
                    for (var index = 0; index < dataTable.Columns.Count; ++index)
                        dataRow[index] = "";
                    try {
                        if (enableCategoryTagging) {
                            if (mineParams.CategoryList != null && mineParams.CategoryList.Count > 1) {
                                dataRow[categoryTagColName] = ((UrlData)mineParams.CategoryList[currentCategory]).name;
                                if (dataRow[categoryTagColName].ToString() == "URL" || dataRow[categoryTagColName].ToString() == "")
                                    dataRow[categoryTagColName] = startURL.url;
                            }
                            if (mineParams.KeywordList != null) {
                                if (mineParams.KeywordList.Count > 1)
                                    dataRow[categoryTagColName] = mineParams.KeywordList[currentCategory].ToString();
                            }
                        }
                    } catch (Exception ex) {
                    }
                    dataGridView.Invoke(new DataTableAddRowCallBack(DataTableAddRow), (object)dataRow);
                    xpathList.Add(HtmlParser.GetXPath(element));
                }
                var index1 = recordsMined;
                while (index1 < dataTable.Rows.Count && !(dataTable.Rows[index1][datafield.name].ToString() == ""))
                    ++index1;
                if (index1 != dataTable.Rows.Count) {
                    var xpath2 = pgLinkXpath == null ? HtmlParser.GetXPath(element) : pgLinkXpath;
                    if (datafield.name != dataTable.Columns[0].ColumnName && index1 + 1 < xpathList.Count && HtmlParser.Compare((string)xpathList[index1 + 1], xpath2) <= 0) {
                        dataGridView.Invoke(new DataTableAssignCellCallBack(DataTableAssignCell), (object)index1, (object)datafield.name, (object)" ");
                    } else {
                        if (datafield.type == EDataType.Text) {
                            var str = HtmlParser.GetElementText(element, true);
                            if (datafield.regex != null && datafield.regex.Trim() != "")
                                str = HtmlParser.RefineElementText(HtmlParser.GetElementText(element, false), datafield.regex);
                            dataGridView.Invoke(new DataTableAssignCellCallBack(DataTableAssignCell), (object)index1, (object)datafield.name, (object)str);
                        } else if (datafield.type == EDataType.Text_Near_Heading) {
                            var text = !datafield.pattern ? HtmlParser.GetTextNearHeadingBruteForce(browser.Document, datafield.heading) : HtmlParser.GetTextNearHeading(element, datafield.heading);
                            if (datafield.regex != null && datafield.regex.Trim() != "")
                                text = HtmlParser.RefineElementText(text, datafield.regex);
                            dataGridView.Invoke(new DataTableAssignCellCallBack(DataTableAssignCell), (object)index1, (object)datafield.name, (object)text);
                        } else if (datafield.type == EDataType.Url)
                            dataGridView.Invoke(new DataTableAssignCellCallBack(DataTableAssignCell), (object)index1, (object)datafield.name, (object)HtmlParser.GetElementUrl(element));
                        else if (datafield.type == EDataType.HTML) {
                            var text = HtmlParser.GetElementHtml(element);
                            if (datafield.regex != null && datafield.regex.Trim() != "")
                                text = HtmlParser.RefineElementText(text, datafield.regex);
                            dataGridView.Invoke(new DataTableAssignCellCallBack(DataTableAssignCell), (object)index1, (object)datafield.name, (object)text);
                        } else if (datafield.type == EDataType.Image || datafield.type == EDataType.Image_URL) {
                            var elementImageUrl = HtmlParser.GetElementImageUrl(element);
                            if (elementImageUrl != null) {
                                var str = elementImageUrl;
                                if (datafield.type == EDataType.Image)
                                    str = DownloadImage(elementImageUrl);
                                dataGridView.Invoke(new DataTableAssignCellCallBack(DataTableAssignCell), (object)index1, (object)datafield.name, (object)str);
                            }
                        } else if (datafield.type == EDataType.Image_RegEx) {
                            var str1 = HtmlParser.GetElementHtml(element);
                            if (datafield.regex != null && datafield.regex.Trim() != "")
                                str1 = HtmlParser.RefineElementText(str1, datafield.regex);
                            if (str1 != null) {
                                var str2 = DownloadImage(HtmlParser.GetAbsoluteUrl(browser.Url, str1));
                                dataGridView.Invoke(new DataTableAssignCellCallBack(DataTableAssignCell), (object)index1, (object)datafield.name, (object)str2);
                            }
                        } else if (datafield.type == EDataType.File) {
                            var str = SaveAsFile(HtmlParser.GetElementText(element, false), datafield.name);
                            dataGridView.Invoke(new DataTableAssignCellCallBack(DataTableAssignCell), (object)index1, (object)datafield.name, (object)str);
                        }
                        if (datafield.pattern)
                            element = HtmlParser.GetNextElement(element);
                        else
                            goto label_52;
                    }
                    if (!(element != null))
                        goto label_52;
                } else
                    goto label_52;
            }
            flag = false;
        label_52:
            return flag;
        }

        private string SaveAsFile(string fileContent, string fileName) {
            var str1 = fileDirectoryPath;
            try {
                if (str1 != null) {
                    var str2 = str1 + "\\" + fileName;
                    string path;
                    if (File.Exists(str2 + ".txt")) {
                        var num = 1;
                        while (File.Exists(str2 + "-" + num.ToString() + ".txt"))
                            ++num;
                        path = str2 + "-" + num.ToString() + ".txt";
                        fileName = fileName + "-" + num.ToString() + ".txt";
                    } else {
                        path = str2 + ".txt";
                        fileName = fileName + ".txt";
                    }
                    File.WriteAllText(path, fileContent);
                } else
                    fileName = fileContent;
            } catch (Exception ex) {
                fileName = "Save to file failed !";
            }
            return fileName;
        }

        private string DownloadImage(string imageUrl) {
            var str1 = imgDirectoryPath;
            var str2 = imageUrl;
            try {
                if (imageUrl != null) {
                    var str3 = Regex.Replace(imageUrl.Substring(imageUrl.LastIndexOf("/") + 1), string.Format("([{0}]*\\.+$)|([{0}]+)", Regex.Escape(new string(Path.GetInvalidFileNameChars()))), "_");
                    if (str3.Length > 50)
                        str3 = str3.Substring(str3.Length - 50);
                    if (str1 != null) {
                        if (!str1.Trim().Equals(string.Empty))
                            str1 = str1 + "\\";
                        var str4 = str1 + str3;
                        if (!HtmlParser.IsFileImage(str4)) {
                            var imageExtension = HtmlParser.GetImageExtension(imageUrl);
                            str4 = str4 + imageExtension;
                            str3 = str3 + imageExtension;
                        }
                        if (File.Exists(str4)) {
                            var num = 1;
                            while (File.Exists(str4.Insert(str4.LastIndexOf('.'), "-" + num.ToString())))
                                ++num;
                            str4 = str4.Insert(str4.LastIndexOf('.'), "-" + num.ToString());
                            str3 = str3.Insert(str3.LastIndexOf('.'), "-" + num.ToString());
                        }
                        var webClient = new WebClient();
                        webClient.Headers.Add("user-agent", userAgentString);
                        webClient.DownloadFile(imageUrl, str4);
                        str2 = str3;
                    }
                }
            } catch (Exception ex) {
            }
            return str2;
        }

        private void ParsePage(WebBrowser browser, int i, string pgLinkXpath) {
            for (var index = i; index < fieldList.Count; ++index) {
                var datafield = (DataField)fieldList[index];
                if (datafield.type == EDataType.Link_Back)
                    break;
                if (datafield.type == EDataType.Text || datafield.type == EDataType.File || (datafield.type == EDataType.Text_Near_Heading || datafield.type == EDataType.Url) || (datafield.type == EDataType.HTML || datafield.type == EDataType.Image || (datafield.type == EDataType.Image_URL || datafield.type == EDataType.Image_RegEx)))
                    GetData(browser, index, pgLinkXpath);
                if (datafield.type == EDataType.Click) {
                    allowNavigate = true;
                    HtmlParser.PerformClicks(HtmlParser.GetElement(browser.Document, datafield.xpath), false);
                    WaitForAjaxLoad();
                    allowNavigate = false;
                }
                if (datafield.type == EDataType.Link_RegEx) {
                    var str = HtmlParser.GetElementHtml(GetFirstElement(browser.Document, datafield.xpath, index));
                    if (datafield.regex != null && datafield.regex.Trim() != "")
                        str = HtmlParser.RefineElementText(str, datafield.regex);
                    if (str != null && !(str == "")) {
                        var absoluteUrl = HtmlParser.GetAbsoluteUrl(browser.Url, str);
                        Uri result;
                        if (Uri.TryCreate(absoluteUrl, UriKind.Absolute, out result)) {
                            pageLoaded = false;
                            pageLoadError = false;
                            browser.Navigate(absoluteUrl, null, null, null);
                            WaitForPageLoad();
                            browser.Stop();
                        }
                    }
                }
            }
        }

        private void WaitForAjaxLoad() {
            var now = DateTime.Now;
            while ((DateTime.Now - now).Seconds < Settings.Default.AjaxLoadTimeout)
                Application.DoEvents();
        }

        private void WaitForPageLoad() {
            var now = DateTime.Now;
            while (!pageLoaded && (DateTime.Now - now).Seconds < Settings.Default.PageLoadTimeout)
                Application.DoEvents();
            WaitForAjaxLoad();
        }

        private void WaitForTargetData() {
            var now = DateTime.Now;
            while (!targetDataAvailable && (DateTime.Now - now).Seconds < Settings.Default.PageLoadTimeout)
                Application.DoEvents();
        }

        private bool NavigateToNextPage(WebBrowser browser, int i, int pageIndex) {
            var flag1 = false;
            var str = ((DataField)fieldList[i]).name;
            var flag2 = str != null && str.StartsWith("<");
            var element1 = HtmlParser.GetNextPageElement(browser.Document, str, pageIndex);
            if (null == element1 || !HtmlParser.IsElementClickable(element1)) {
                int result;
                if (!int.TryParse(str, out result)) {
                    var element2 = HtmlParser.GetElement(browser.Document, ((DataField)fieldList[i]).xpath);
                    if (element2 != null) {
                        if (!flag2 && element2.InnerText != str) {
                            element1 = null;
                            flag1 = false;
                        } else
                            element1 = element2;
                    }
                } else if (element1 != null) {
                    foreach (HtmlElement element2 in element1.Children) {
                        if (HtmlParser.IsElementClickable(element2)) {
                            element1 = element2;
                            break;
                        }
                    }
                }
            }
            MarkUnassignedCells();
            if (element1 != null) {
                targetDataAvailable = false;
                lastPageURLAvailable = false;
                allowNavigate = true;
                pageLoaded = false;
                pageLoadError = false;
                element1.InvokeMember("click");
                if (targetDataAvailable) {
                    lastPageURLAvailable = true;
                    lastPageURL = targetUrl;
                }
                WaitForPageLoad();
                if (!pageLoaded)
                    WaitForPageLoad();
                browser.Stop();
                allowNavigate = false;
                if (!pageLoadError) {
                    flag1 = true;
                } else {
                    flag1 = false;
                    if (targetDataAvailable) {
                        targetDataAvailable = false;
                        allowNavigate = true;
                        pageLoaded = false;
                        pageLoadError = false;
                        browser.Navigate(targetUrl.url, null, targetUrl.postData, targetUrl.headers);
                        WaitForPageLoad();
                        browser.Stop();
                        allowNavigate = false;
                        flag1 = !pageLoadError;
                    }
                }
            }
            return flag1;
        }

        private void VisitURLandGetData(WebBrowser browser, int i) {
            var datafield = (DataField)fieldList[i];
            var element = GetFirstElement(browser.Document, datafield.xpath, i);
            WebBrowser browser1 = null;
            HtmlParser.ResetState();
            while (!(element == null)) {
                var uriString = HtmlParser.GetElementUrl(element);
                targetDataAvailable = false;
                if (datafield.type == EDataType.Link_Follow) {
                    activeElement = element;
                    element.InvokeMember("click");
                    WaitForTargetData();
                    if (!targetDataAvailable && !InternetConnected()) {
                        WaitForInternet();
                        goto label_21;
                    } else {
                        Uri result;
                        if (targetDataAvailable && (!Uri.TryCreate(targetUrl.url, UriKind.Absolute, out result) || !(result.Scheme == Uri.UriSchemeHttp) && !(result.Scheme == Uri.UriSchemeHttps)))
                            targetDataAvailable = false;
                    }
                } else if (datafield.type == EDataType.Link_RegEx) {
                    var str = HtmlParser.GetElementHtml(element);
                    if (datafield.regex != null && datafield.regex.Trim() != "")
                        str = HtmlParser.RefineElementText(str, datafield.regex);
                    if (str != null && !(str == "")) {
                        uriString = HtmlParser.GetAbsoluteUrl(browser.Url, str);
                        Uri result;
                        if (!Uri.TryCreate(uriString, UriKind.Absolute, out result))
                            break;
                    } else
                        break;
                }
                if (!targetDataAvailable) {
                    targetUrl.url = uriString;
                    targetUrl.postData = null;
                    targetUrl.headers = null;
                }
                targetDataAvailable = false;
                if (browser1 == null) {
                    browser1 = new WebBrowser();
                    browser1.ScriptErrorsSuppressed = true;
                    browser1.DocumentCompleted += browser_DocumentCompleted;
                    ((InternetExplorer)browser1.ActiveXInstance).NavigateError += ie_NavigateError;
                    if (Settings.Default.ProxyEnabled) {
                        proxyManager.stop();
                        browser1.Navigate("about:blank");
                        (browser1.ActiveXInstance as IOleObject).SetClientSite(proxyManager);
                        proxyManager.Start();
                        browser1.Navigate("about:blank");
                        Application.DoEvents();
                    }
                }
                pageLoaded = false;
                pageLoadError = false;
                browser1.Navigate(targetUrl.url, null, targetUrl.postData, targetUrl.headers);
                WaitForPageLoad();
                browser1.Stop();
                if (pageLoadError && !InternetConnected()) {
                    WaitForInternet();
                } else {
                    HandlePauseResume();
                    ParsePage(browser1, i + 1, HtmlParser.GetXPath(element));
                    if (((DataField)fieldList[i]).pattern)
                        element = HtmlParser.GetNextElement(element);
                    else
                        break;
                }
            label_21:
                if (!(element != null))
                    break;
            }
            if (browser1 == null)
                return;
            browser1.Dispose();
        }

        private bool InternetConnected() {
            return InternetCheckConnection(urlGoogle, 1, 0);
        }

        private HtmlElement GetFirstElement(HtmlDocument htmlDoc, string xpath, int index) {
            HtmlElement htmlElement;
            try {
                htmlElement = HtmlParser.GetElement(htmlDoc, xpath);
                if (!(htmlElement != null)) {
                    if (index != 0) {
                        if (((DataField)fieldList[index]).pattern) {
                            for (var index1 = recordsMined + 1; index1 < xpathList.Count; ++index1) {
                                var xpath1 = HtmlParser.AdjustXPath((string)xpathList[index1], xpath);
                                if (xpath1 != null) {
                                    htmlElement = HtmlParser.GetElement(htmlDoc, xpath1);
                                    if (null != htmlElement)
                                        break;
                                } else
                                    break;
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                htmlElement = null;
            }
            return htmlElement;
        }

        private void NavigateToLastMinedPage(WebBrowser browser) {
            if (lastPageURLAvailable) {
                SetStatus(StringResource.LoadingLastMinedPage);
                targetDataAvailable = false;
                allowNavigate = true;
                pageLoaded = false;
                pageLoadError = false;
                browser.Navigate(lastPageURL.url, null, lastPageURL.postData, lastPageURL.headers);
                WaitForPageLoad();
                browser.Stop();
                allowNavigate = false;
            } else
                NavigateToPageIndex(browser, totalPagesMined + 1);
        }

        private void NavigateToPageIndex(WebBrowser browser, int pageNumber) {
            var i = -1;
            for (var index = 0; index < fieldList.Count; ++index) {
                if (((DataField)fieldList[index]).type == EDataType.Link_NextPage) {
                    i = index;
                    break;
                }
            }
            if (i == -1)
                return;
            for (var pageIndex = 2; pageIndex <= pageNumber; ++pageIndex) {
                SetStatus(StringResource.MineLoadingPage + pageIndex.ToString());
                NavigateToNextPage(browser, i, pageIndex);
            }
        }

        public delegate void ScrollDataViewCallBack();

        public delegate void UpdateStatusCallBack(string strStatus);

        public delegate void DataTableAddColumCallBack(string columnName);

        public delegate void DataTableAddRowCallBack(DataRow dataRow);

        public delegate void DataTableRemoveRowCallBack(int row);

        public delegate void DataTableAssignCellCallBack(int row, string column, string value);
    }
}

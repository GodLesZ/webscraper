using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using GodLesZ.Tools.WebScraper.Forms;
using GodLesZ.Tools.WebScraper.Library;
using GodLesZ.Tools.WebScraper.Properties;
using SHDocVw;
using WeifenLuo.WinFormsUI.Docking;

namespace GodLesZ.Tools.WebScraper.Components {
    public partial class BrowserContainer : DockContent {
        private ArrayList _categoryList = new ArrayList();
        private ArrayList _keywordList = new ArrayList();
        private bool _cancelNavigation;
        private bool _ignoreNavigation;
        private bool _configMode;
        private bool _isPageLoaded;
        private UrlData _startUrl;
        private bool _startUrlAvaiable;
        private string _baseUrl;
        private HtmlElement _categoryStartElement;

        public bool ReadyToMine {
            get {
                return MineParameters != null && MineParameters.FieldList != null && MineParameters.FieldList.Count != 0;
            }
        }

        public MineParams MineParameters { get; set; }

        public MainForm ControllerForm { private get; set; }

        public string[] KeywordList {
            set {
                _keywordList.Clear();
                if (value == null)
                    return;
                _keywordList.AddRange(value);
            }
        }

        public bool DisablePatterns { private get; set; }

        public bool IsInputElementSelected {
            get {
                if (_webBrowserCtrl.Document == null) {
                    return false;
                }
                if (_webBrowserCtrl.Document.ActiveElement == null) {
                    return false;
                }
                return _webBrowserCtrl.Document.ActiveElement.TagName == "INPUT";
            }
        }

        public BrowserContainer() {
            InitializeComponent();
            _toolStripStatusLabel.Text = StringResource.BrowserStateReady;
            _webBrowserCtrl.ScriptErrorsSuppressed = true;
            _webBrowserCtrl.IsWebBrowserContextMenuEnabled = false;

            ((InternetExplorer)_webBrowserCtrl.ActiveXInstance).BeforeNavigate2 += ie_BeforeNavigate2;
            if (Settings.Default.VisitedUrlList != null)
                _textBoxUrl.AutoCompleteCustomSource = Settings.Default.VisitedUrlList;
            else
                Settings.Default.VisitedUrlList = new AutoCompleteStringCollection();
        }

        public void Clear() {
            LoadStartPage();
        }

        private void WaitForAjaxLoad() {
            var now = DateTime.Now;
            while ((DateTime.Now - now).Seconds < Settings.Default.AjaxLoadTimeout) {
                Application.DoEvents();
                if (_toolStripStatusLabel.Text == "") {
                    _toolStripStatusLabel.Text = StringResource.LoadingPreview;
                    _toolStripProgressBar.Visible = true;
                }
            }
        }

        private void WaitForPageLoad() {
            var now = DateTime.Now;
            while (!_isPageLoaded && (DateTime.Now - now).Seconds < Settings.Default.PageLoadTimeout) {
                Application.DoEvents();
                if (_toolStripStatusLabel.Text == "") {
                    _toolStripStatusLabel.Text = StringResource.LoadingPreview;
                    _toolStripProgressBar.Visible = true;
                }
            }
            WaitForAjaxLoad();
        }

        public bool EditConfiguration() {
            var flag1 = true;
            var flag2 = false;
            try {
                _isPageLoaded = false;
                _webBrowserCtrl.Navigate(MineParameters.StartURL.url, null, MineParameters.StartURL.postData, MineParameters.StartURL.headers);
                ((Control)_webBrowserCtrl).Enabled = false;
                WaitForPageLoad();
                _webBrowserCtrl.Stop();
                ClearPreview();
                foreach (var field in MineParameters.FieldList) {
                    var datafield = (DataField)field;
                    switch (datafield.type) {
                        case EDataType.Text:
                        case EDataType.Url:
                        case EDataType.Image:
                        case EDataType.Image_RegEx:
                        case EDataType.HTML:
                        case EDataType.File:
                        case EDataType.Text_Near_Heading:
                            var element = flag2 ? null : HtmlParser.GetElement(_webBrowserCtrl.Document, datafield.xpath);
                            if (element != null) {
                                UpdatePreview(datafield.type, element, datafield.name, datafield.regex, datafield.pattern, datafield.heading);
                                break;
                            }
                            ControllerForm.FormPreview.AddColumn(datafield.name);
                            ControllerForm.FormPreview.AddSingleItem("--");
                            break;
                        case EDataType.Link_Follow:
                            flag2 = true;
                            break;
                        case EDataType.Link_Back:
                            flag2 = false;
                            break;
                        case EDataType.Click:
                            _ignoreNavigation = true;
                            HtmlParser.PerformClicks(HtmlParser.GetElement(_webBrowserCtrl.Document, datafield.xpath), datafield.pattern);
                            _ignoreNavigation = false;
                            break;
                    }
                }
                _configMode = true;
                ControllerForm.FormPreview.ConfigMode = true;
                InstallHandlers();
                _textBoxUrl.Enabled = false;
                _baseUrl = _webBrowserCtrl.Url.ToString();
            } catch (Exception) {
                MessageBox.Show(StringResource.ErrorLoadingConf, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag1 = false;
                _toolStripStatusLabel.Text = "";
                _toolStripProgressBar.Visible = false;
            } finally {
                ((Control)_webBrowserCtrl).Enabled = true;
            }
            return flag1;
        }

        private void BrowserContainer_Load(object sender, EventArgs e) {
            Application.Idle += Application_Idle;
        }

        private void Application_Idle(object sender, EventArgs e) {
            Application.Idle -= Application_Idle;
            LoadStartPage();
        }

        private void LoadStartPage() {
            _webBrowserCtrl.Navigate(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\InitPage\\index.html");
            while (_webBrowserCtrl.ReadyState != WebBrowserReadyState.Complete)
                Application.DoEvents();
            _textBoxUrl.Text = "";
            _isPageLoaded = false;
        }

        public void SetInputFieldValue(string value) {
            try {
                if (_webBrowserCtrl.Document != null && _webBrowserCtrl.Document.ActiveElement != null && _webBrowserCtrl.Document.ActiveElement.TagName == "INPUT") {
                    _webBrowserCtrl.Document.ActiveElement.SetAttribute("value", value);
                }
            } catch (Exception) {
            }
        }

        public void EnableSelectCategoryMode(bool enable) {
            var document = _webBrowserCtrl.Document;
            if (enable) {
                if (!_isPageLoaded)
                    buttonStop_Click(this, null);
                ClearPreview();
                _categoryList.Clear();
                _categoryStartElement = null;
                ControllerForm.FormPreview.AddColumn(StringResource.CategoryColumnName);
                if (document != null) {
                    document.Click += htmlDocSelectCategory_Click;
                }
            } else if (document != null) {
                document.Click -= htmlDocSelectCategory_Click;
            }
        }

        private void htmlDocSelectCategory_Click(object sender, HtmlElementEventArgs e) {
            var count = _categoryList.Count;
            var flag1 = count == 0;
            var flag2 = false;
            if (!(_webBrowserCtrl.Document == null)) {
                if (Settings.Default.CategoryDoNotParse)
                    flag1 = false;
                var element = _webBrowserCtrl.Document.GetElementFromPoint(e.ClientMousePosition);
                if (element == null) {
                    flag2 = true;
                } else {
                    if (element.TagName != "A") {
                        if (element.Parent == null || element.Parent.TagName != "A") {
                            flag2 = true;
                            goto label_26;
                        }

                        element = element.Parent;
                    }
                    _toolStripStatusLabel.Text = StringResource.Wait;
                    _toolStripProgressBar.Visible = true;
                    _toolStripProgressBar.Style = ProgressBarStyle.Continuous;
                    _toolStripProgressBar.Minimum = 0;
                    _toolStripProgressBar.Maximum = 100;
                    _toolStripProgressBar.Step = 1;
                    HtmlParser.ResetState();
                    while (element != null) {
                        if (_toolStripProgressBar.Value == 100)
                            _toolStripProgressBar.Value = 0;
                        var urldata = new UrlData();
                        urldata.name = HtmlParser.GetElementText(element);
                        if (element.TagName == "A")
                            urldata.url = HtmlParser.GetElementUrl(element);
                        else if (element.Parent != null && element.Parent.TagName == "A")
                            urldata.url = HtmlParser.GetElementUrl(element.Parent);
                        else
                            break;
                        _categoryList.Add(urldata);
                        var htmlElement = element;
                        var str = htmlElement.Style + " BACKGROUND:yellow";
                        htmlElement.Style = str;
                        ControllerForm.FormPreview.AddItem(count++, urldata.name);
                        if (_categoryStartElement == null)
                            _categoryStartElement = element;
                        if (flag1) {
                            element = HtmlParser.GetNextElement(element);
                            _toolStripProgressBar.PerformStep();
                        } else
                            break;
                    }
                    _toolStripProgressBar.Value = 100;
                    _toolStripStatusLabel.Text = "";
                    _toolStripProgressBar.Visible = false;
                    _toolStripProgressBar.Style = ProgressBarStyle.Marquee;
                    if (flag1) {
                        if (DialogResult.Yes == MessageBox.Show(StringResource.SelMoreCategoriesMessage, StringResource.PgmName, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                            e.ReturnValue = false;
                        else
                            flag2 = true;
                    } else
                        e.ReturnValue = false;
                }
            }
        label_26:
            if (!flag2)
                return;
            EnableSelectCategoryMode(false);
            if (_categoryStartElement == null)
                return;
            
            MessageBox.Show(StringResource.SelectSectionsConfMessage, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            _categoryStartElement.InvokeMember("click");
        }

        public bool EnableConfigMode(bool enable) {
            DisablePatterns = false;
            if (_webBrowserCtrl.ReadyState == WebBrowserReadyState.Complete) {
                _isPageLoaded = true;
                _toolStripStatusLabel.Text = "";
                _toolStripProgressBar.Visible = false;
            }
            ControllerForm.FormPreview.ConfigMode = enable;
            if (!enable) {
                _configMode = false;
                RemoveHandlers();
                _textBoxUrl.Enabled = true;
                MineParameters.Optimize();
                _categoryList = new ArrayList();
                _keywordList = new ArrayList();
            } else {
                if (!_isPageLoaded)
                    buttonStop_Click(this, null);
                _configMode = true;
                InstallHandlers();
                if (!_startUrlAvaiable) {
                    _startUrl.url = _webBrowserCtrl.Url.ToString();
                    _startUrl.postData = null;
                    _startUrl.headers = null;
                }
                MineParameters = new MineParams();
                MineParameters.StartURL = _startUrl;
                if (_categoryList.Count > 1) {
                    try {
                        var urldata1 = (UrlData)_categoryList[0];
                        if (-1 != _startUrl.url.ToLower().IndexOf(urldata1.url.ToLower(), StringComparison.Ordinal))
                            MineParameters.CategoryList = _categoryList;
                        else if (-1 != _startUrl.url.ToLower().IndexOf(Uri.UnescapeDataString(urldata1.url).ToLower(), StringComparison.Ordinal)) {
                            var arrayList = new ArrayList();
                            foreach (object category in _categoryList) {
                                var urldata = (UrlData)category;
                                urldata.url = Uri.UnescapeDataString(urldata.url);
                                arrayList.Add(urldata);
                            }
                            MineParameters.CategoryList = arrayList;
                        }
                    } catch (Exception) {
                        MineParameters.CategoryList = null;
                    }
                }
                if (_keywordList.Count > 1)
                    MineParameters.KeywordList = _keywordList;
                ClearPreview();
                _textBoxUrl.Enabled = false;
                _baseUrl = _webBrowserCtrl.Url.ToString();
            }
            
            return true;
        }

        private static bool IsCapturableElement(HtmlElement element) {
            return element.Children.Count == 0;
        }

        private static void HighLightElement(HtmlElement element) {
            if (!(element != null))
                return;
            if (element.Style == null) {
                element.Style = "BACKGROUND: yellow";
                return;
            }

            if (String.Compare(element.Style, "BACKGROUND: yellow", StringComparison.Ordinal) == 0) {
                return;
            }
            
            element.Style = element.Style + " BACKGROUND: yellow";
        }

        private void RemoveHighLight(HtmlElement element) {
            if (!(element != null) || element.Style == null || element.Style.Length < "BACKGROUND: yellow".Length)
                return;
            element.Style = element.Style.Remove(element.Style.Length - "BACKGROUND: yellow".Length, "BACKGROUND: yellow".Length);
        }

        private void InstallHandlers() {
            var document = _webBrowserCtrl.Document;
            if (!(document != null))
                return;
            var all = document.All;
            document.MouseUp += htmlDoc_Click;
            foreach (HtmlElement element in all) {
                if (IsCapturableElement(element)) {
                    element.MouseOver += element_MouseOver;
                    element.MouseLeave += element_MouseLeave;
                }
            }
            _cancelNavigation = true;
        }

        private void RemoveHandlers() {
            var document = _webBrowserCtrl.Document;
            if (!(document != null))
                return;
            var all = document.All;
            document.MouseUp -= htmlDoc_Click;
            foreach (HtmlElement element in all) {
                if (IsCapturableElement(element)) {
                    element.MouseOver -= element_MouseOver;
                    element.MouseLeave -= element_MouseLeave;
                }
            }
            _cancelNavigation = false;
        }

        private void webBrowserCtrl_NewWindow(object sender, CancelEventArgs e) {
            e.Cancel = true;
            if (_webBrowserCtrl.Document == null || _webBrowserCtrl.Document.ActiveElement == null) {
                return;
            }

            var urlString = _webBrowserCtrl.Document.ActiveElement.GetAttribute("href");
            if (urlString.StartsWith("/")) {
                urlString = "http://" + _webBrowserCtrl.Url.Host + urlString;
            }
            if (!urlString.StartsWith("http")) {
                return;
            }
            _webBrowserCtrl.Navigate(urlString);
        }

        private void ie_BeforeNavigate2(object pDisp, ref object url, ref object flags, ref object targetFrameName, ref object postData, ref object headers, ref bool cancel) {
            var str = url as string;
            if (str != null && (_startUrlAvaiable || targetFrameName != null || (postData == null || !str.ToLower().StartsWith("http"))))
                return;
            _startUrl.url = (string)url;
            _startUrl.headers = (string)headers;
            _startUrl.postData = (byte[])postData;
            _startUrlAvaiable = true;
        }

        private void webBrowserCtrl_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            if (_webBrowserCtrl.ReadyState == WebBrowserReadyState.Complete) {
                _toolStripStatusLabel.Text = "";
                _toolStripProgressBar.Visible = false;
                _textBoxUrl.Text = _webBrowserCtrl.Url.ToString();
                if (_configMode && !_isPageLoaded)
                    InstallHandlers();
                _isPageLoaded = true;
            }
            if (_webBrowserCtrl.ReadyState != WebBrowserReadyState.Interactive)
                return;
            if (_webBrowserCtrl.Document != null) {
                _webBrowserCtrl.Document.Click += htmlDocNonConfig_Click;
                if (!_configMode)
                    return;
                _webBrowserCtrl.Document.Click += htmlDocConfig_Click;
            }
            _cancelNavigation = true;
        }

        private void webBrowserCtrl_Navigating(object sender, WebBrowserNavigatingEventArgs e) {
            if (_ignoreNavigation)
                return;
            if (_cancelNavigation) {
                e.Cancel = true;
            } else {
                _toolStripStatusLabel.Text = StringResource.BrowserStateLoading;
                _toolStripProgressBar.Visible = true;
                RemoveHandlers();
                if (_webBrowserCtrl.Document != null) {
                    _webBrowserCtrl.Document.Click -= htmlDocNonConfig_Click;
                    _webBrowserCtrl.Document.Click -= htmlDocConfig_Click;
                }
                _isPageLoaded = false;
            }
        }

        private void htmlDocConfig_Click(object sender, HtmlElementEventArgs e) {
            if (_configMode && !_isPageLoaded)
                buttonStop_Click(sender, null);
            if (_webBrowserCtrl.Document != null) {
                _webBrowserCtrl.Document.Click -= htmlDocConfig_Click;
            }
        }

        private void htmlDocNonConfig_Click(object sender, HtmlElementEventArgs e) {
            if (_configMode)
                return;
            _startUrlAvaiable = false;
        }

        private void htmlDoc_Click(object sender, HtmlElementEventArgs e) {
            if (!(_webBrowserCtrl.Document != null))
                return;
            var element = _webBrowserCtrl.Document.GetElementFromPoint(e.ClientMousePosition);
            if (!(element != null))
                return;
            if (!HtmlParser.IsElementClickable(element)) {
                if (HtmlParser.IsElementClickable(_webBrowserCtrl.Document.ActiveElement))
                    element = _webBrowserCtrl.Document.ActiveElement;
                else if (string.IsNullOrEmpty(element.InnerText))
                    element = _webBrowserCtrl.Document.ActiveElement;
            }
            element_Click(element);
        }

        private void element_Click(object sender) {
            var captureForm = new CaptureForm();
            var element1 = sender as HtmlElement;
            try {
                var flag1 = HtmlParser.IsElementClickable(element1);
                var flag2 = HtmlParser.IsElementLink(element1);
                var flag3 = HtmlParser.IsElementEmailAddr(element1);
                var flag4 = HtmlParser.IsElementImage(element1);
                string heading = null;
                if (element1 != null) {
                    var innerText = element1.InnerText;
                    var outerHtml = element1.OuterHtml;
                    if (!flag1 && !flag4 && string.IsNullOrEmpty(element1.InnerText))
                        return;
                    captureForm.Document = _webBrowserCtrl.Document;
                    captureForm.CapElement = element1;
                    captureForm.IsClickable = flag1;
                    captureForm.IsLink = flag2;
                    captureForm.IsEmail = flag3;
                    captureForm.IsImage = flag4;
                    captureForm.StartPosition = FormStartPosition.CenterParent;
                    if (_webBrowserCtrl.Url.ToString() == _baseUrl) {
                        captureForm.IsPattern = !DisablePatterns;
                    } else {
                        captureForm.IsPattern = false;
                        captureForm.IsClickable = false;
                    }
                    if (captureForm.ShowDialog(this) != DialogResult.OK)
                        return;
                    var element2 = captureForm.CapElement;
                    var type = captureForm.Type;
                    if (type == EDataType.Link_NextPage || type == EDataType.Link_LoadMoreContent)
                        captureForm.FieldName = innerText == null || innerText.Trim() == "" ? outerHtml : innerText;
                    if (type == EDataType.Text_Near_Heading) {
                        heading = element2.InnerText;
                        if (element2.Parent != null) {
                            element2 = element2.Parent.Parent;
                        }
                    }
                    var xpath = captureForm.IsPattern ? GetFirstXPath(HtmlParser.GetXPath(element2)) : HtmlParser.GetXPath(element2);
                    var flag5 = MineParameters.AddDataField(type, captureForm.FieldName, xpath, captureForm.IsPattern, heading, captureForm.RegEx);
                    if (!flag5) {
                        MessageBox.Show(string.Format(StringResource.MsgDuplicateFieldName, captureForm.FieldName), StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    if (flag5 && type == EDataType.Click) {
                        _ignoreNavigation = true;
                        HtmlParser.PerformClicks(element2, captureForm.IsPattern);
                        _ignoreNavigation = false;
                    }
                    if (flag5 && (type == EDataType.Text || type == EDataType.Text_Near_Heading || (type == EDataType.Url || type == EDataType.Image) || (type == EDataType.Image_URL || type == EDataType.HTML || (type == EDataType.File || type == EDataType.Image_RegEx))))
                        UpdatePreview(type, element2, captureForm.FieldName, captureForm.RegEx, captureForm.IsPattern, heading);
                    if (flag5 && flag1 && type == EDataType.Link_Follow) {
                        _cancelNavigation = false;
                        element2.InvokeMember("click");
                    }
                    if (!flag5 || type != EDataType.Link_RegEx)
                        return;
                }
                _cancelNavigation = false;
                _webBrowserCtrl.Navigate(HtmlParser.GetAbsoluteUrl(_webBrowserCtrl.Url, captureForm.URLLinkRegEx));
            } catch (Exception ex) {
                MessageBox.Show("Failed to add field:\n\n" + ex.Message, "Parameter Exception", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private string GetFirstXPath(string xpath) {
            var str1 = xpath;
            if (ControllerForm.FormPreview.ColCount != 0) {
                var itemData = ControllerForm.FormPreview.GetItemData(1);
                var xpath1 = itemData.ToString();
                if (xpath1 != string.Empty && HtmlParser.Compare(xpath1, xpath) <= 0) {
                    itemData = ControllerForm.FormPreview.GetItemData(0);
                    var refXPath = itemData.ToString();
                    if (refXPath != string.Empty) {
                        var str2 = HtmlParser.AdjustXPath(refXPath, xpath);
                        if (str2 != null)
                            str1 = str2;
                    }
                }
            }

            return str1;
        }

        private void element_MouseLeave(object sender, HtmlElementEventArgs e) {
            RemoveHighLight(sender as HtmlElement);
        }

        private void element_MouseOver(object sender, HtmlElementEventArgs e) {
            HighLightElement(sender as HtmlElement);
        }

        private void buttonGo_Click(object sender, EventArgs e) {
            if (_textBoxUrl.Text == "")
                return;
            if (!_textBoxUrl.Text.StartsWith("http") && !_textBoxUrl.Text.StartsWith("file:///"))
                _textBoxUrl.Text = "http://" + _textBoxUrl.Text;
            Uri result;
            if (Uri.TryCreate(_textBoxUrl.Text, UriKind.Absolute, out result)) {
                _startUrlAvaiable = false;
                _webBrowserCtrl.Navigate(_textBoxUrl.Text);
                Settings.Default.VisitedUrlList.Add(_textBoxUrl.Text);
            } else {
                MessageBox.Show(StringResource.InvalidUrl, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e) {
            if (_webBrowserCtrl.ReadyState != WebBrowserReadyState.Complete) {
                if (_webBrowserCtrl.Url != null)
                    _textBoxUrl.Text = _webBrowserCtrl.Url.ToString();
                if (_configMode)
                    InstallHandlers();
            }
            _toolStripStatusLabel.Text = "";
            _toolStripProgressBar.Visible = false;
            _isPageLoaded = true;
            _webBrowserCtrl.Stop();
        }

        private void textBoxURL_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.Return)
                return;
            buttonGo_Click(null, null);
        }

        private void buttonBack_Click(object sender, EventArgs e) {
            if (_configMode) {
                MineParameters.AddDataField(EDataType.Link_Back, null, null, false, null);
                _cancelNavigation = false;
            } else
                _startUrlAvaiable = false;
            _webBrowserCtrl.GoBack();
        }

        private void buttonForward_Click(object sender, EventArgs e) {
            if (_configMode)
                return;
            _startUrlAvaiable = false;
            _webBrowserCtrl.GoForward();
        }

        private void buttonRefresh_Click(object sender, EventArgs e) {
            if (_configMode)
                return;
            _startUrlAvaiable = false;
            _webBrowserCtrl.Refresh();
        }

        private void UpdatePreview(EDataType type, HtmlElement element, string fieldName, string regex, bool isPattern, string heading) {
            var element1 = element;
            string str = null;
            var flag1 = ControllerForm.FormPreview.ColCount > 0;
            var row = 0;
            var flag2 = false;
            ControllerForm.FormPreview.AddColumn(fieldName);
            _toolStripStatusLabel.Text = StringResource.Wait;
            _toolStripProgressBar.Visible = true;
            _toolStripProgressBar.Style = ProgressBarStyle.Continuous;
            _toolStripProgressBar.Minimum = 0;
            _toolStripProgressBar.Maximum = 500;
            _toolStripProgressBar.Step = 1;
            HtmlParser.ResetState();
            do {
                _toolStripProgressBar.PerformStep();
                if (_toolStripProgressBar.Value == 500)
                    _toolStripProgressBar.Value = 0;
                var xpath = HtmlParser.GetXPath(element1);
                if (type == EDataType.Text || type == EDataType.File) {
                    str = HtmlParser.GetElementText(element1);
                    if (regex != null && regex.Trim() != "")
                        str = HtmlParser.RefineElementText(HtmlParser.GetElementText(element1, false), regex);
                } else if (type == EDataType.Text_Near_Heading) {
                    str = _webBrowserCtrl.Url.ToString() != _baseUrl ? HtmlParser.GetTextNearHeadingBruteForce(_webBrowserCtrl.Document, heading) : HtmlParser.GetTextNearHeading(element1, heading);
                    if (regex != null && regex.Trim() != "")
                        str = HtmlParser.RefineElementText(str, regex);
                } else if (type == EDataType.Url)
                    str = HtmlParser.GetElementUrl(element1);
                else if (type == EDataType.Image || type == EDataType.Image_URL)
                    str = HtmlParser.GetElementImageUrl(element1);
                else if (type == EDataType.Image_RegEx || type == EDataType.HTML) {
                    str = HtmlParser.GetElementHtml(element1);
                    if (regex != null && regex.Trim() != "")
                        str = HtmlParser.RefineElementText(str, regex);
                }
                if (flag1 && isPattern) {
                    if (row < ControllerForm.FormPreview.RowCount) {
                        var xpath1 = (string)ControllerForm.FormPreview.GetItemData(row + 1);
                        if (xpath1 == null)
                            ControllerForm.FormPreview.AddItem(row++, str);
                        else if (HtmlParser.Compare(xpath1, xpath) > 0) {
                            ControllerForm.FormPreview.AddItem(row++, str);
                        } else {
                            ControllerForm.FormPreview.AddItem(row++, "");
                            goto label_29;
                        }
                    } else
                        break;
                } else if (flag1)
                    ControllerForm.FormPreview.AddSingleItem(str);
                else
                    ControllerForm.FormPreview.AddItem(row++, str, xpath);
                element1 = HtmlParser.GetNextElement(element1);
                if (!flag1 && ControllerForm.FormPreview.RowCount > 40 && !flag2) {
                    if (DialogResult.Yes == MessageBox.Show(StringResource.ProceedPreviewGeneration, StringResource.PgmName, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        flag2 = true;
                    else
                        break;
                }
            label_29: ;
            }
            while (element1 != null && isPattern);
            if (flag1 && isPattern) {
                for (; row < ControllerForm.FormPreview.RowCount; ++row)
                    ControllerForm.FormPreview.AddItem(row, "");
            }
            _toolStripStatusLabel.Text = "";
            _toolStripProgressBar.Visible = false;
            _toolStripProgressBar.Style = ProgressBarStyle.Marquee;
        }

        private void ClearPreview() {
            ControllerForm.FormPreview.Clear();
            ControllerForm.FormPreview.MineParameters = MineParameters;
        }

    }
}

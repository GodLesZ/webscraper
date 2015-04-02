using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using GodLesZ.Tools.WebScraper.Components;
using GodLesZ.Tools.WebScraper.Library;
using GodLesZ.Tools.WebScraper.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class MainForm : Form {
        private readonly int UPDATE_CHECK_INTERVAL = 15;
        private readonly string URL_BUY = "http://www.GodLesZ.Tools.WebScraper.com/buy.html";
        private readonly string URL_DOWNLOAD = "http://www.GodLesZ.Tools.WebScraper.com/download.html";
        private readonly string URL_UPGRADE = "http://www.GodLesZ.Tools.WebScraper.com/upgrade.html";
        private readonly string URL_TOUR = "http://www.GodLesZ.Tools.WebScraper.com/tour.html";
        private readonly string URL_SUPPORT = "http://www.GodLesZ.Tools.WebScraper.com/support.html";
        private readonly string URL_WEBSCRAPER_XML = "http://www.GodLesZ.Tools.WebScraper.com/GodLesZ.Tools.WebScraper.xml";
        private readonly BrowserContainer _formBrowserCont = new BrowserContainer();
        private readonly CultureInfo _englishCulture = new CultureInfo("en-US");
        private readonly RegistrationManager _regManager = new RegistrationManager();
        private DockPanel _dockPanel;
        
        public PreviewForm FormPreview = new PreviewForm();
        

        public MainForm() {
            InitializeComponent();

            Thread.CurrentThread.CurrentUICulture = _englishCulture;
            _dockPanel.Dock = DockStyle.Fill;
            _dockPanel.BringToFront();
            _formBrowserCont.ShowHint = DockState.Document;
            _formBrowserCont.TabText = StringResource.BrowserTab;
            _formBrowserCont.ControllerForm = this;
            _formBrowserCont.Show(_dockPanel);
            FormPreview.Show(_dockPanel, DockState.DockBottom);
        }

        [DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            var aboutForm = new AboutForm();
            aboutForm.StartPosition = FormStartPosition.CenterParent;
            aboutForm.ShowDialog();
        }

        private void menuStripButtonInputKeywords_Click(object sender, EventArgs e) {
            if (_formBrowserCont.IsInputElementSelected) {
                if (!_regManager.Registered) {
                    MessageBox.Show(StringResource.EvalLimitMsg, StringResource.PgmNameEval, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                var keywordForm = new KeywordForm();
                if (DialogResult.OK != keywordForm.ShowDialog())
                    return;
                var keywords = keywordForm.Keywords;
                if (keywords == null || keywords.Length == 0)
                    return;
                _formBrowserCont.KeywordList = keywords;
                _formBrowserCont.SetInputFieldValue(keywords[0]);
            } else {
                MessageBox.Show(StringResource.SelectInputField, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void menuStripButtonSelectSections_Click(object sender, EventArgs e) {
            if (!_regManager.Registered) {
                MessageBox.Show(StringResource.CatEvalLimitMsg, StringResource.PgmNameEval, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (DialogResult.OK != (!Settings.Default.CategoryDoNotParse ? MessageBox.Show(StringResource.SelectSectionsMessage, StringResource.PgmName, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) : MessageBox.Show(StringResource.SelectSectionsMessage2, StringResource.PgmName, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk)))
                return;
            _formBrowserCont.EnableSelectCategoryMode(true);
        }

        private void toolStripButtonStartConfig_Click(object sender, EventArgs e) {
            if (!_formBrowserCont.EnableConfigMode(true))
                return;
            toolStripButtonStartConfig.Enabled = false;
            toolStripButtonStopConfig.Enabled = true;
            menuStripButtonStartConfig.Enabled = false;
            menuStripButtonStopConfig.Enabled = true;
            menuStripButtonSelectSections.Enabled = false;
            menuStripButtonInputKeywords.Enabled = false;
            editConfigToolStripMenuItem.Enabled = false;
            settingsToolStripMenuItem.Enabled = false;
            clearToolStripMenuItem.Enabled = false;
            autoScrollToLoadMoreDataToolStripMenuItem.Checked = false;
            disablePatternDetectionToolStripMenuItem.Checked = false;
            toolStripButtonMine.Enabled = false;
            menuStripButtonStartMine.Enabled = false;
            toolStripButtonOpen.Enabled = false;menuStripButtonOpen.Enabled = false;
            toolStripButtonSave.Enabled = false;
            menuStripButtonSave.Enabled = false;
            editOptionsToolStripMenuItem.Enabled = true;
            if (_formBrowserCont.MineParameters.KeywordList == null || _formBrowserCont.MineParameters.KeywordList.Count == 0)
                editKeywordsToolStripMenuItem.Enabled = false;
            Text = StringResource.PgmName;
        }

        private void toolStripButtonStopConfig_Click(object sender, EventArgs e) {
            if (!_formBrowserCont.EnableConfigMode(false))
                return;
            toolStripButtonStartConfig.Enabled = true;
            toolStripButtonStopConfig.Enabled = false;
            menuStripButtonStartConfig.Enabled = true;
            menuStripButtonStopConfig.Enabled = false;
            editOptionsToolStripMenuItem.Enabled = false;
            editKeywordsToolStripMenuItem.Enabled = true;
            menuStripButtonSelectSections.Enabled = true;
            menuStripButtonInputKeywords.Enabled = true;
            editConfigToolStripMenuItem.Enabled = true;
            settingsToolStripMenuItem.Enabled = true;
            clearToolStripMenuItem.Enabled = true;
            disablePatternDetectionToolStripMenuItem.Checked = false;
            if (_formBrowserCont.ReadyToMine) {
                toolStripButtonMine.Enabled = true;
                menuStripButtonStartMine.Enabled = true;
                toolStripButtonSave.Enabled = true;
                menuStripButtonSave.Enabled = true;
                editConfigToolStripMenuItem.Enabled = true;
            }
            toolStripButtonOpen.Enabled = true;
            menuStripButtonOpen.Enabled = true;
        }

        private void DisplayMineForm(bool autoStart) {
            if (!_formBrowserCont.ReadyToMine)
                return;
            var mineForm = new MineForm();
            mineForm.StartPosition = FormStartPosition.CenterParent;
            mineForm.MineParameters = _formBrowserCont.MineParameters;
            mineForm.AutoStartMine = autoStart;
            var num = (int)mineForm.ShowDialog();
        }

        private void toolStripButtonMine_Click(object sender, EventArgs e) {
            DisplayMineForm(false);
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e) {
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.Filter = "XML file (*.xml)|*.xml| All files (*.*)|*.*";
            saveFileDialog.AddExtension = true;
            saveFileDialog.RestoreDirectory = true;
            try {
                var mineParameters = _formBrowserCont.MineParameters;
                if (mineParameters == null || saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                XmlWriter xmlWriter = new XmlTextWriter(saveFileDialog.FileName, null);
                new XmlSerializer(typeof(MineParams)).Serialize(xmlWriter, mineParameters);
                xmlWriter.Close();
                Text = StringResource.PgmName + "-" + saveFileDialog.FileName;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void OpenConfigurationFile(string configFileName) {
            XmlReader xmlReader = new XmlTextReader(new FileStream(configFileName, FileMode.Open));
            _formBrowserCont.MineParameters = (MineParams)new XmlSerializer(typeof(MineParams)).Deserialize(xmlReader);
            xmlReader.Close();
            Text = StringResource.PgmName + "-" + openFileDialog.FileName;
            _formBrowserCont.MineParameters.ConfigName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
            if (_formBrowserCont.ReadyToMine) {
                toolStripButtonMine.Enabled = true;
                menuStripButtonStartMine.Enabled = true;
            }
            autoScrollToLoadMoreDataToolStripMenuItem.Checked = _formBrowserCont.MineParameters.AutoScrollEnabled;
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e) {
            openFileDialog.DefaultExt = "xml";
            openFileDialog.Filter = "XML file (*.xml)|*.xml| All files (*.*)|*.*";
            openFileDialog.AddExtension = true;
            openFileDialog.RestoreDirectory = true;
            try {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                OpenConfigurationFile(openFileDialog.FileName);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void MainForm_Load(object sender, EventArgs e) {
            Location = Settings.Default.WindowLocation;
            Size = Settings.Default.WindowSize;
            if (Settings.Default.WindowStartPostion == 1) {
                CenterToScreen();
                Settings.Default.WindowStartPostion = 0;
            }
            WindowState = (FormWindowState)Settings.Default.WindowState;
            Application.Idle += Application_Idle;
        }

        private void HandleCommandLineArgs() {
            var commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Length == 2 && (commandLineArgs[1].Equals("/?") || commandLineArgs[1].Equals("/h") || commandLineArgs[1].ToLower().EndsWith("help"))) {
                AttachConsole(-1);
                Console.WriteLine("\n\nWebScraper Usage:\n\n-- Export to File --\n\n" + "webscraper <configuration xml file> <number of pages to mine> <export file>\n\n" + "Example:- webscraper config.xml 10 data.csv\n\n" + "To mine all pages, use -1 for <number of pages to mine>\n\n" + "-- Export to database --\n\n" + "webharvy <configuration xml file> <number of pages to mine> db <dbserver> <type:mysql/mssql> <db-name> <table-name> <windows-auth:true/false> <username> <password>\n\n" + "Examples:-\nwebharvy config.xml 10 db dbserver.net mysql WebHarvyDB MyTable false testuser mypwd\n" + "webharvy config.xml 10 db dbserver.net mssql WebHarvyDB MyTable true\n");
                FreeConsole();
                Close();
            } else if (_regManager.Registered || _regManager.GetEvaluationDaysRemaining() > 0) {
                OpenConfigurationFile(commandLineArgs[1]);
                WindowState = FormWindowState.Minimized;
                DisplayMineForm(true);
            } else
                Close();
        }

        private void Application_Idle(object sender, EventArgs e) {
            Application.Idle -= Application_Idle;
            try {
                if (Environment.GetCommandLineArgs().Length > 1)
                    HandleCommandLineArgs();
                else if (!_regManager.Registered || _regManager.TimeLimited) {
                    var nagForm = new NagForm();
                    nagForm.StartPosition = FormStartPosition.CenterParent;
                    if (nagForm.ShowDialog() == DialogResult.OK)
                        return;
                    Close();
                } else
                    StartUpdateCheckThread();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Close();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (WindowState == FormWindowState.Minimized)
                return;
            Settings.Default.WindowLocation = Location;
            Settings.Default.WindowState = (int)WindowState;
            Settings.Default.WindowSize = WindowState != FormWindowState.Normal ? RestoreBounds.Size : Size;
            Settings.Default.Save();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            var settingsForm = new SettingsForm();
            settingsForm.StartPosition = FormStartPosition.CenterParent;
            settingsForm.ShowDialog();
        }

        private bool CheckForNewerVersion(ref DateTime releaseDate) {
            var flag = false;
            var version1 = "";
            var year = 0;
            var month = 0;
            var day = 0;
            releaseDate = DateTime.Now;
            var xmlTextReader = new XmlTextReader(URL_WEBSCRAPER_XML);
            while (xmlTextReader.Read()) {
                if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "Program_Version")
                    version1 = xmlTextReader.ReadElementString().Trim();
                if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "Program_Release_Month")
                    month = int.Parse(xmlTextReader.ReadElementString());
                if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "Program_Release_Day")
                    day = int.Parse(xmlTextReader.ReadElementString());
                if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "Program_Release_Year") {
                    year = int.Parse(xmlTextReader.ReadElementString());
                    break;
                }
            }
            if (version1 != "") {
                var version2 = new Version(version1);
                releaseDate = new DateTime(year, month, day);
                if (Assembly.GetExecutingAssembly().GetName().Version.CompareTo(version2) < 0)
                    flag = true;
            }
            return flag;
        }

        public void CheckForUpdate(bool fromUi) {
            var now = DateTime.Now;
            try {
                var timeSpan1 = DateTime.Now - Settings.Default.lastUpdateCheck;
                if (!fromUi && timeSpan1.Days < UPDATE_CHECK_INTERVAL)
                    return;
                if (fromUi)
                    Cursor.Current = Cursors.WaitCursor;
                var flag = CheckForNewerVersion(ref now);
                var timeSpan2 = new TimeSpan(0L);
                if (_regManager.Registered)
                    timeSpan2 = now - _regManager.PurchaseDate;
                Settings.Default.lastUpdateCheck = DateTime.Now;
                if (fromUi)
                    Cursor.Current = Cursors.Default;
                if (flag) {
                    if (!_regManager.Registered || timeSpan2.Days <= 365) {
                        if (DialogResult.Yes != MessageBox.Show(StringResource.NewUpdateAvailable, StringResource.PgmName, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                            return;
                        Process.Start(URL_DOWNLOAD);
                    } else if (_regManager.Registered && timeSpan2.Days < _regManager.UPGRADE_WINDOW) {
                        if (DialogResult.Yes != MessageBox.Show(StringResource.NewUpdateUpgrade, StringResource.PgmName, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                            return;
                        Process.Start(URL_UPGRADE);
                    } else {
                        if (!_regManager.Registered || timeSpan2.Days <= _regManager.UPGRADE_WINDOW || DialogResult.Yes != MessageBox.Show(StringResource.NewUpdatePurchase, StringResource.PgmName, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                            return;
                        Process.Start(URL_BUY);
                    }
                } else if (fromUi) {
                    MessageBox.Show(StringResource.NoNewUpdates, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                } else {
                    if (!_regManager.Registered)
                        return;
                    var days = (DateTime.Now - _regManager.PurchaseDate).Days;
                    if (!_regManager.Registered || days <= 365 || (days >= _regManager.UPGRADE_WINDOW || DialogResult.Yes != MessageBox.Show(StringResource.UpgradePrompt, StringResource.PgmName, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)))
                        return;
                    Process.Start(URL_UPGRADE);
                }
            } catch (Exception ex) {
                if (!fromUi)
                    return;
                MessageBox.Show(StringResource.ErrorUpdateChk, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            } finally {
                if (fromUi)
                    Cursor.Current = Cursors.Default;
            }
        }

        private void CheckForUpdateThread() {
            CheckForUpdate(false);
        }

        private void StartUpdateCheckThread() {
            new Thread(CheckForUpdateThread).Start();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e) {
            CheckForUpdate(true);
        }

        private void editConfigToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!_formBrowserCont.ReadyToMine) {
                MessageBox.Show(StringResource.NoConfigOpened, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            } else {
                toolStripButtonStartConfig.Enabled = false;
                toolStripButtonStopConfig.Enabled = false;
                menuStripButtonStartConfig.Enabled = false;
                menuStripButtonStopConfig.Enabled = false;
                menuStripButtonSelectSections.Enabled = false;
                menuStripButtonInputKeywords.Enabled = false;
                editConfigToolStripMenuItem.Enabled = false;
                clearToolStripMenuItem.Enabled = false;
                toolStripButtonMine.Enabled = false;
                menuStripButtonStartMine.Enabled = false;
                toolStripButtonOpen.Enabled = false;
                menuStripButtonOpen.Enabled = false;
                toolStripButtonSave.Enabled = false;
                menuStripButtonSave.Enabled = false;
                if (_formBrowserCont.EditConfiguration()) {
                    menuStripButtonStopConfig.Enabled = true;
                    toolStripButtonStopConfig.Enabled = true;
                    editOptionsToolStripMenuItem.Enabled = true;
                    if (_formBrowserCont.MineParameters.KeywordList != null && _formBrowserCont.MineParameters.KeywordList.Count != 0)
                        return;
                    editKeywordsToolStripMenuItem.Enabled = false;
                } else {
                    toolStripButtonStartConfig.Enabled = true;
                    toolStripButtonStopConfig.Enabled = false;
                    menuStripButtonStartConfig.Enabled = true;
                    menuStripButtonStopConfig.Enabled = false;
                    menuStripButtonSelectSections.Enabled = true;
                    menuStripButtonInputKeywords.Enabled = true;
                    editConfigToolStripMenuItem.Enabled = true;
                    toolStripButtonMine.Enabled = true;
                    menuStripButtonStartMine.Enabled = true;
                    toolStripButtonOpen.Enabled = true;
                    menuStripButtonOpen.Enabled = true;
                    toolStripButtonSave.Enabled = true;
                    menuStripButtonSave.Enabled = true;
                }
            }
        }

        private void schedulerToolStripMenuItem_Click(object sender, EventArgs e) {
            var schedulerForm = new SchedulerForm();
            schedulerForm.StartPosition = FormStartPosition.CenterParent;
            var num = (int)schedulerForm.ShowDialog();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e) {
            Text = StringResource.PgmName;
            FormPreview.Clear();
            _formBrowserCont.Clear();
            _formBrowserCont.MineParameters = null;
        }

        private void addURLsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (_formBrowserCont.MineParameters == null) {
                MessageBox.Show(StringResource.NoConfigOpened, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            } else {
                if (!_regManager.Registered) {
                    MessageBox.Show(StringResource.UrlEvalLimitMsg, StringResource.PgmNameEval, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                var addUrlForm = new AddUrlForm();
                addUrlForm.URLList = _formBrowserCont.MineParameters.CategoryList;
                addUrlForm.StartPosition = FormStartPosition.CenterParent;
                if (DialogResult.OK != addUrlForm.ShowDialog())
                    return;
                ArrayList arrayList = null;
                var urlList = addUrlForm.URLList;
                if (urlList != null && urlList.Count != 0) {
                    arrayList = new ArrayList();
                    arrayList.Add(_formBrowserCont.MineParameters.StartURL);
                    arrayList.AddRange(urlList);
                }
                _formBrowserCont.MineParameters.CategoryList = arrayList;
            }
        }

        private void editStartURLPostDataToolStripMenuItem_Click(object sender, EventArgs e) {
            var editStartUrlForm = new EditStartUrlForm();
            editStartUrlForm.StartPosition = FormStartPosition.CenterParent;
            editStartUrlForm.StartURL = _formBrowserCont.MineParameters.StartURL;
            if (editStartUrlForm.ShowDialog() != DialogResult.OK)
                return;
            _formBrowserCont.MineParameters.StartURL = editStartUrlForm.StartURL;
        }

        private void autoScrollToLoadMoreDataToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!autoScrollToLoadMoreDataToolStripMenuItem.Checked)
                _formBrowserCont.MineParameters.RemoveAutoScroll();
            else
                _formBrowserCont.MineParameters.AddAutoScroll();
        }

        private void editKeywordsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!_regManager.Registered) {
                MessageBox.Show(StringResource.EvalLimitMsg, StringResource.PgmNameEval, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            var keywordForm = new KeywordForm();
            keywordForm.Keywords = (string[])_formBrowserCont.MineParameters.KeywordList.ToArray(typeof(string));
            if (DialogResult.OK != keywordForm.ShowDialog())
                return;
            _formBrowserCont.MineParameters.KeywordList.Clear();
            _formBrowserCont.MineParameters.KeywordList.AddRange(keywordForm.Keywords);
        }

        private void disablePatternDetectionToolStripMenuItem_Click(object sender, EventArgs e) {
            _formBrowserCont.DisablePatterns = disablePatternDetectionToolStripMenuItem.Checked;
        }

    }
}

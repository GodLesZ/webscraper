using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GodLesZ.Tools.WebScraper.Library;
using GodLesZ.Tools.WebScraper.Properties;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class MineForm : Form {
        private const int EvalMaxPages = 2;

        private readonly RegistrationManager _regManager = new RegistrationManager();
        private string _imageCaptureDir;
        private string _fileCaptureDir;
        private WebMiner _miner;

        public bool AutoStartMine {
            get;
            set;
        }

        public MineParams MineParameters {
            get;
            set;
        }


        public MineForm() {
            InitializeComponent();
        }

        private void MineForm_Load(object sender, EventArgs e) {
            progressBarMine.MarqueeAnimationSpeed = 0;
            progressBarMine.Value = 0;
            buttonStop.Enabled = false;
            buttonExport.Enabled = false;
            buttonPauseResume.Enabled = false;
            toolStripStatus.Text = StringResource.MineFormReady;
            toolStripStatus.AutoSize = true;
            toolStripStatus.TextAlign = ContentAlignment.MiddleLeft;
            checkBoxAutoScroll.Checked = Settings.Default.MineAutoScroll;
            dataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            if (MineParameters.SinglePage) {
                groupBoxMinePager.Enabled = false;
                textBoxNumPages.Text = 1.ToString();
            } else {
                if (_regManager.Registered)
                    checkBoxMineTillEnd.Checked = Settings.Default.MineAllPages;
                textBoxNumPages.Text = EvalMaxPages.ToString();
                if (!MineParameters.SupportsMineTillEnd) {
                    checkBoxMineTillEnd.Enabled = false;
                    checkBoxMineTillEnd.Checked = false;
                }
                checkBoxMineTillEnd_CheckedChanged(null, null);
            }
            StartPosition = FormStartPosition.CenterParent;
            var mineWindowLocation = Settings.Default.MineWindowLocation;
            if (Settings.Default.MineWindowLocation.X != 0 && Settings.Default.MineWindowLocation.Y != 0)
                Location = Settings.Default.MineWindowLocation;
            var mineWindowSize = Settings.Default.MineWindowSize;
            Size = Settings.Default.MineWindowSize;
            if (Settings.Default.MineWindowMaximized)
                WindowState = FormWindowState.Maximized;
            HandleCmdLineArgsOnMineStart();
        }

        private void HandleCmdLineArgsOnMineStart() {
            if (!AutoStartMine)
                return;
            var commandLineArgs = Environment.GetCommandLineArgs();
            int result;
            if (commandLineArgs.Length > 2 && int.TryParse(commandLineArgs[2], out result)) {
                if (result >= 0) {
                    textBoxNumPages.Text = commandLineArgs[2];
                    checkBoxMineTillEnd.Checked = false;
                    if (result > 2 && !_regManager.Registered)
                        textBoxNumPages.Text = 2.ToString();
                } else if (result == -1 && _regManager.Registered)
                    checkBoxMineTillEnd.Checked = true;
            }
            if (commandLineArgs.Length > 1) {
                try {
                    var directoryName = Path.GetDirectoryName(commandLineArgs[1]);
                    _imageCaptureDir = directoryName;
                    _fileCaptureDir = directoryName;
                } catch (Exception ex) {
                }
            }
            buttonStart_Click(null, null);
            WindowState = FormWindowState.Minimized;
        }

        private void HandleFilesInMineParams() {
            var flag1 = false;
            var flag2 = false;
            foreach (DataField datafield in MineParameters.FieldList) {
                if ((datafield.type == EDataType.Image || datafield.type == EDataType.Image_RegEx) && (_imageCaptureDir == null && !flag1)) {
                    var folderBrowserDialog = new FolderBrowserDialog();
                    folderBrowserDialog.Description = StringResource.ImageDirBrowse;
                    if (DialogResult.OK == folderBrowserDialog.ShowDialog())
                        _imageCaptureDir = folderBrowserDialog.SelectedPath;
                    else
                        flag1 = true;
                }
                if (datafield.type == EDataType.File && _fileCaptureDir == null && !flag2) {
                    var folderBrowserDialog = new FolderBrowserDialog();
                    folderBrowserDialog.Description = StringResource.FileDirBrowse;
                    if (DialogResult.OK == folderBrowserDialog.ShowDialog())
                        _fileCaptureDir = folderBrowserDialog.SelectedPath;
                    else
                        flag2 = true;
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e) {
            var flag = false;
            try {
                if (checkBoxMineTillEnd.Checked) {
                    MineParameters.PageMaxCount = -1;
                } else {
                    MineParameters.PageMaxCount = int.Parse(textBoxNumPages.Text);
                    if (MineParameters.PageMaxCount == 0) {
                        MineParameters.PageMaxCount = 1;
                        textBoxNumPages.Text = MineParameters.PageMaxCount.ToString();
                    }
                }
            } catch (Exception ex) {
                var num = (int)MessageBox.Show(ex.Message, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (!_regManager.Registered && MineParameters.PageMaxCount > EvalMaxPages) {
                var num = (int)MessageBox.Show(StringResource.EvalPageLimit, StringResource.PgmNameEval, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                MineParameters.PageMaxCount = EvalMaxPages;
                textBoxNumPages.Text = EvalMaxPages.ToString();
            }
            if (_miner != null && _miner.MineData != null && (_miner.MineData.Rows.Count != 0 && MineParameters.SupportsMineTillEnd) && (MineParameters.PageMaxCount == -1 || _miner.CurrentPage < MineParameters.PageMaxCount || MineParameters.CategoryList != null && MineParameters.CategoryList.Count > 1 && _miner.CurrentCategory != MineParameters.CategoryList.Count) && DialogResult.Yes == MessageBox.Show(StringResource.ResumeAbortedMining, StringResource.PgmName, MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                flag = true;
            if (!flag) {
                dataGridView.DataSource = null;
                _miner = new WebMiner(MineParameters, dataGridView, toolStripStatus);
            }
            _miner.AutoScroll = checkBoxAutoScroll.Checked;
            _miner.ResumeAbortedMining = flag;
            _miner.enableCategoryTagging = Settings.Default.EnableCategoryTagging;
            _miner.categoryTagColName = Settings.Default.CategoryTagColName;
            HandleFilesInMineParams();
            _miner.ImageCaptureDirectory = _imageCaptureDir;
            _miner.FileCaptureDirectory = _fileCaptureDir;
            progressBarMine.Style = ProgressBarStyle.Marquee;
            progressBarMine.Value = 0;
            progressBarMine.MarqueeAnimationSpeed = 50;
            progressBarMine.Visible = true;
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            buttonPauseResume.Enabled = true;
            buttonExport.Enabled = false;
            checkBoxAutoScroll.Enabled = false;
            toolStripStatus.Text = StringResource.MineFormStart;
            _miner.OnMineEnd += buttonStop_Click;
            _miner.StartWebMine();
        }

        private void buttonStop_Click(object sender, EventArgs e) {
            if (progressBarMine.InvokeRequired) {
                Invoke(new EventHandler(buttonStop_Click), (object)this, null);
            } else {
                if (sender != _miner)
                    _miner.StopWebMine();
                progressBarMine.Style = ProgressBarStyle.Blocks;
                progressBarMine.MarqueeAnimationSpeed = 0;
                progressBarMine.Value = 0;
                progressBarMine.Visible = false;
                buttonStart.Enabled = true;
                buttonStop.Enabled = false;
                buttonPauseResume.Enabled = false;
                buttonExport.Enabled = true;
                checkBoxAutoScroll.Enabled = true;
                buttonPauseResume.Text = " &Pause";
                buttonPauseResume.Image = Resources.pause;
                toolStripStatus.Text = "[" + _miner.MineData.Rows.Count + " " + StringResource.RecordsMined + " from " + _miner.PagesMined.ToString() + (_miner.PagesMined <= 1 ? " Page" : " Pages") + "]  " + StringResource.MineFormStop + " - Last Mined URL : " + _miner.LastURL;
                HandleCmdLineArgsOnMineEnd();
            }
        }

        private void HandleCmdLineArgsOnMineEnd() {
            if (!AutoStartMine)
                return;
            var commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Length <= 3)
                return;
            if (commandLineArgs[3].ToLower().Equals("db") && commandLineArgs.Length > 8) {
                var exportDbForm = new ExportDbForm();
                exportDbForm.AutoExport = true;
                exportDbForm.MineData = _miner.MineData;
                exportDbForm.StartPosition = FormStartPosition.CenterParent;
                exportDbForm.WindowState = FormWindowState.Minimized;
                exportDbForm.SetDBParams(commandLineArgs[4], commandLineArgs[5], commandLineArgs[6], commandLineArgs[7]);
                exportDbForm.SetLoginParams(false, "", "");
                if (commandLineArgs[8].ToLower() == "false") {
                    if (commandLineArgs.Length > 10)
                        exportDbForm.SetLoginParams(false, commandLineArgs[9], commandLineArgs[10]);
                } else
                    exportDbForm.SetLoginParams(true, "", "");
                if (DialogResult.OK != exportDbForm.ShowDialog())
                    return;
                Application.Exit();
            } else {
                if (commandLineArgs.Length != 4)
                    return;
                var exportForm = new ExportForm();
                exportForm.MineData = _miner.MineData;
                var append = true;
                if (!File.Exists(commandLineArgs[3]))
                    append = false;
                if (!exportForm.ExportData(commandLineArgs[3], EExportFormat.UnKnown, append, 0, -1))
                    return;
                Application.Exit();
            }
        }

        private void checkBoxMineTillEnd_CheckedChanged(object sender, EventArgs e) {
            textBoxNumPages.Enabled = !checkBoxMineTillEnd.Checked;
            labelNumPages.Enabled = !checkBoxMineTillEnd.Checked;
        }

        private void buttonExport_Click(object sender, EventArgs e) {
            buttonExport.ContextMenuStrip.Show(Cursor.Position);
        }

        private void textBoxNumPages_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = !char.IsDigit(e.KeyChar);
            if (!char.IsControl(e.KeyChar))
                return;
            e.Handled = false;
        }

        private void checkBoxMineTillEnd_Click(object sender, EventArgs e) {
            if (_regManager.Registered)
                return;
            checkBoxMineTillEnd.Checked = false;
            MessageBox.Show(StringResource.EvalLimitation, StringResource.PgmNameEval, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void MineForm_FormClosing(object sender, FormClosingEventArgs e) {
            Settings.Default.MineAutoScroll = checkBoxAutoScroll.Checked;
            if (groupBoxMinePager.Enabled)
                Settings.Default.MineAllPages = checkBoxMineTillEnd.Checked;
            if (buttonStop.Enabled)
                buttonStop_Click(null, null);
            if (WindowState != FormWindowState.Normal) {
                Settings.Default.MineWindowLocation = RestoreBounds.Location;
                Settings.Default.MineWindowSize = RestoreBounds.Size;
                Settings.Default.MineWindowMaximized = WindowState == FormWindowState.Maximized;
            } else {
                Settings.Default.MineWindowLocation = Location;
                Settings.Default.MineWindowSize = Size;
                Settings.Default.MineWindowMaximized = false;
            }
            Settings.Default.Save();
        }

        private void toolStripMenuItemFile_Click(object sender, EventArgs e) {
            var exportForm = new ExportForm();
            exportForm.StartPosition = FormStartPosition.CenterParent;
            exportForm.MineData = _miner.MineData;
            var num = (int)exportForm.ShowDialog();
        }

        private void toolStripMenuItemDatabase_Click(object sender, EventArgs e) {
            var exportDbForm = new ExportDbForm(false);
            exportDbForm.StartPosition = FormStartPosition.CenterParent;
            exportDbForm.MineData = _miner.MineData;
            exportDbForm.ShowDialog();
        }

        private void buttonPauseResume_Click(object sender, EventArgs e) {
            if (buttonPauseResume.Text == " &Pause") {
                if (!_miner.IsPaused) {
                    _miner.Pause();
                    toolStripStatus.Text = StringResource.MinePausing;
                }
                buttonPauseResume.Text = " &Resume";
                buttonPauseResume.Image = Resources.resume;
                buttonExport.Enabled = true;
                progressBarMine.MarqueeAnimationSpeed = 0;
            } else {
                if (_miner.IsPaused)
                    _miner.Resume();
                buttonPauseResume.Text = " &Pause";
                buttonPauseResume.Image = Resources.pause;
                buttonExport.Enabled = false;
                toolStripStatus.Text = StringResource.MineFormStart;
                progressBarMine.MarqueeAnimationSpeed = 50;
            }
        }

        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) {
            using (var solidBrush = new SolidBrush(dataGridView.RowHeadersDefaultCellStyle.ForeColor)) {
                var num = e.RowIndex + 1;
                var sizeF = e.Graphics.MeasureString(num.ToString(), Font);
                e.Graphics.DrawString(num.ToString(), e.InheritedRowStyle.Font, solidBrush, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + (float)((e.RowBounds.Height - (double)sizeF.Height) / 2.0));
            }
        }

    }
}

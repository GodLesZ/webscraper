using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using GodLesZ.Tools.WebScraper.Library;
using GodLesZ.Tools.WebScraper.Properties;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class SettingsForm : Form {
        private readonly TestProxyForm _testProxyForm = new TestProxyForm();

        public SettingsForm() {
            InitializeComponent();
            listBoxProxy.Columns.Add("Proxy Server");
            listBoxProxy.Columns[0].Width = 500;
        }

        public static ProxyData GetProxyData(string proxyDataString) {
            var proxyData = new ProxyData();
            var strArray = proxyDataString.Split(' ');
            if (strArray.Length > 0)
                proxyData.Address = strArray[0];
            if (strArray.Length > 1)
                proxyData.Username = strArray[1];
            if (strArray.Length > 2)
                proxyData.Password = strArray[2];
            return proxyData;
        }

        private void SettingsForm_Load(object sender, EventArgs e) {
            LoadProxyPage();
            UpdateProxyPage();
            LoadMinerPage();
            LoadCategoryKWPage();
            toolTip.SetToolTip(buttonAdd, "Add proxy to list");
            toolTip.SetToolTip(buttonDown, "Move Down");
            toolTip.SetToolTip(buttonUp, "Move Up");
            toolTip.SetToolTip(buttonImport, "Import proxy list from file");
            toolTip.SetToolTip(buttonRemove, "Remove proxy from list");
            toolTip.SetToolTip(buttonTest, "Test and remove unresponsive proxies");
        }

        private void LoadCategoryKWPage() {
            checkBoxTagCategoryKW.Checked = Settings.Default.EnableCategoryTagging;
            textBoxTagColName.Text = Settings.Default.CategoryTagColName;
            textBoxTagColName.Enabled = checkBoxTagCategoryKW.Checked;
            checkBoxDoNotParseCategories.Checked = Settings.Default.CategoryDoNotParse;
        }

        private void checkBoxTagCategoryKW_CheckedChanged(object sender, EventArgs e) {
            textBoxTagColName.Enabled = checkBoxTagCategoryKW.Checked;
        }

        private bool SaveCategoryKWPage() {
            var flag = true;
            if (checkBoxTagCategoryKW.Checked && textBoxTagColName.Text.Trim() == string.Empty) {
                var num = (int)MessageBox.Show(StringResource.TagColNameError, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            } else {
                Settings.Default.EnableCategoryTagging = checkBoxTagCategoryKW.Checked;
                if (checkBoxTagCategoryKW.Checked)
                    Settings.Default.CategoryTagColName = textBoxTagColName.Text.Trim();
                Settings.Default.CategoryDoNotParse = checkBoxDoNotParseCategories.Checked;
            }
            return flag;
        }

        private void LoadMinerPage() {
            checkBoxRemoveDuplicates.Checked = Settings.Default.MinerRemoveDuplicates;
            textBoxTimeout.Text = Settings.Default.PageLoadTimeout.ToString();
            textBoxAJAXWaitTime.Text = Settings.Default.AjaxLoadTimeout.ToString();
            checkBoxPauseMiner.Checked = Settings.Default.MinerInjectPauses;
            textBoxPauseInterval.Text = Settings.Default.MinerPauseInterval.ToString();
            textBoxPauseTime.Text = Settings.Default.MinerPauseTime.ToString();
            checkBoxAutoSave.Checked = Settings.Default.MinerAutoSave;
            textBoxAutoSaveFileName.Text = Settings.Default.MinerAutoSaveFileName;
            textBoxAutoSaveNumRecords.Text = Settings.Default.MinerAutoSaveRowCount.ToString();
            UpdateMinerPage();
        }

        private void UpdateMinerPage() {
            textBoxPauseInterval.Enabled = checkBoxPauseMiner.Checked;
            textBoxPauseTime.Enabled = checkBoxPauseMiner.Checked;
            textBoxAutoSaveFileName.Enabled = checkBoxAutoSave.Checked;
            textBoxAutoSaveNumRecords.Enabled = checkBoxAutoSave.Checked;
            buttonOpenAutoSaveFile.Enabled = checkBoxAutoSave.Checked;
        }

        private void LoadProxyPage() {
            try {
                checkBoxEnableProxy.Checked = Settings.Default.ProxyEnabled;
                if (Settings.Default.ProxyDataList != null) {
                    foreach (string proxyDataString in Settings.Default.ProxyDataList) {
                        listBoxProxy.Items.Add(GetProxyData(proxyDataString).Address);
                        listBoxProxy.Items[listBoxProxy.Items.Count - 1].Tag = proxyDataString;
                    }
                }
                checkBoxRotateProxy.Checked = Settings.Default.ProxyRotate;
                textBoxInterval.Text = Settings.Default.ProxyRotateInterval.ToString();
            } catch (Exception ex) {
            }
        }

        private bool SaveMinerPage() {
            var flag = true;
            try {
                Settings.Default.MinerRemoveDuplicates = checkBoxRemoveDuplicates.Checked;
                uint result1;
                if (!uint.TryParse(textBoxAJAXWaitTime.Text, out result1)) {
                    var num = (int)MessageBox.Show(StringResource.InvalidAjaxLoadTimeout, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    flag = false;
                } else {
                    Settings.Default.AjaxLoadTimeout = result1;
                    uint result2;
                    if (!uint.TryParse(textBoxTimeout.Text, out result2)) {
                        var num = (int)MessageBox.Show(StringResource.InvalidPageLoadTimeout, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        flag = false;
                    } else {
                        Settings.Default.PageLoadTimeout = result2;
                        if (checkBoxPauseMiner.Checked) {
                            uint result3;
                            uint result4;
                            if (!uint.TryParse(textBoxPauseInterval.Text, out result3) || !uint.TryParse(textBoxPauseTime.Text, out result4) || ((int)result3 == 0 || (int)result4 == 0)) {
                                var num = (int)MessageBox.Show(StringResource.InvalidMinerPauseParams, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                flag = false;
                                goto label_22;
                            } else {
                                Settings.Default.MinerInjectPauses = checkBoxPauseMiner.Checked;
                                Settings.Default.MinerPauseInterval = result3;
                                Settings.Default.MinerPauseTime = result4;
                            }
                        } else
                            Settings.Default.MinerInjectPauses = checkBoxPauseMiner.Checked;
                        if (checkBoxAutoSave.Checked) {
                            int result3;
                            if (!int.TryParse(textBoxAutoSaveNumRecords.Text, out result3) || result3 <= 0) {
                                var num = (int)MessageBox.Show(StringResource.AutoSaveInvalidRowCount, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                flag = false;
                            } else if (textBoxAutoSaveFileName.Text.Trim() == "") {
                                var num = (int)MessageBox.Show(StringResource.AutoSaveInvalidFileName, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                flag = false;
                            } else {
                                if (textBoxAutoSaveFileName.Text.IndexOf('\\') == -1)
                                    textBoxAutoSaveFileName.Text = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\" + textBoxAutoSaveFileName.Text;
                                if ("" == Path.GetExtension(textBoxAutoSaveFileName.Text)) {
                                    var textBox = textBoxAutoSaveFileName;
                                    var str = textBox.Text + ".csv";
                                    textBox.Text = str;
                                }
                                Settings.Default.MinerAutoSave = checkBoxAutoSave.Checked;
                                Settings.Default.MinerAutoSaveRowCount = result3;
                                Settings.Default.MinerAutoSaveFileName = textBoxAutoSaveFileName.Text;
                            }
                        } else
                            Settings.Default.MinerAutoSave = checkBoxAutoSave.Checked;
                    }
                }
            } catch (Exception ex) {
                flag = false;
                var num = (int)MessageBox.Show(ex.Message, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        label_22:
            return flag;
        }

        private bool SaveProxyPage() {
            var flag = true;
            if (!checkBoxEnableProxy.Checked)
                Settings.Default.ProxyEnabled = checkBoxEnableProxy.Checked;
            else if (listBoxProxy.Items.Count == 0) {
                var num = (int)MessageBox.Show(StringResource.ProxyIncorrectAddress, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = false;
            } else {
                if (Settings.Default.ProxyDataList == null)
                    Settings.Default.ProxyDataList = new ArrayList();
                Settings.Default.ProxyRotate = checkBoxRotateProxy.Checked;
                try {
                    Settings.Default.ProxyRotateInterval = byte.Parse(textBoxInterval.Text);
                } catch (Exception ex) {
                    if (checkBoxRotateProxy.Checked) {
                        var num = (int)MessageBox.Show(StringResource.ProxyIncorrectInterval, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        flag = false;
                    }
                }
                if (Settings.Default.ProxyRotateInterval == 0) {
                    var num = (int)MessageBox.Show(StringResource.ProxyIncorrectInterval, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Settings.Default.ProxyRotateInterval = 1;
                    flag = false;
                }
                Settings.Default.ProxyDataList.Clear();
                foreach (ListViewItem listViewItem in listBoxProxy.Items)
                    Settings.Default.ProxyDataList.Add(listViewItem.Tag);
                Settings.Default.ProxyEnabled = checkBoxEnableProxy.Checked;
            }
            return flag;
        }

        private void UpdateProxyPage() {
            if (checkBoxEnableProxy.Checked) {
                foreach (Control control in (ArrangedElementCollection)tabControl.TabPages[1].Controls) {
                    if (control != checkBoxEnableProxy)
                        control.Enabled = true;
                }
                textBoxInterval.Enabled = checkBoxRotateProxy.Checked;
                textBoxUserName.Enabled = checkBoxRequiredAuth.Checked;
                textBoxPassword.Enabled = checkBoxRequiredAuth.Checked;
            } else {
                foreach (Control control in (ArrangedElementCollection)tabControl.TabPages[1].Controls) {
                    if (control != checkBoxEnableProxy)
                        control.Enabled = false;
                }
            }
        }

        private void checkBoxEnableProxy_CheckedChanged(object sender, EventArgs e) {
            UpdateProxyPage();
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            if (SaveProxyPage() && SaveMinerPage() && SaveCategoryKWPage()) {
                Settings.Default.Save();
                Close();
            } else
                DialogResult = DialogResult.None;
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void radioProxySingle_CheckedChanged(object sender, EventArgs e) {
            UpdateProxyPage();
        }

        private void radioProxyList_CheckedChanged(object sender, EventArgs e) {
            UpdateProxyPage();
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            try {
                if (textBoxAddProxy.Text.Trim() == "") {
                    var num1 = (int)MessageBox.Show(StringResource.ProxyIncorrectAddress, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                } else if (textBoxPortAdd.Text.Trim() == "") {
                    var num2 = (int)MessageBox.Show(StringResource.ProxyIncorrectPort, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                } else if (checkBoxRequiredAuth.Checked && (textBoxUserName.Text.Trim() == "" || textBoxPassword.Text.Trim() == "")) {
                    var num3 = (int)MessageBox.Show(StringResource.ProxyIncorrectAuth, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                } else {
                    var text = textBoxAddProxy.Text + ":" + textBoxPortAdd.Text;
                    if (!text.ToLower().StartsWith("http"))
                        text = "http://" + text;
                    listBoxProxy.Items.Add(text);
                    var str = text;
                    if (checkBoxRequiredAuth.Checked)
                        str = str + " " + textBoxUserName.Text + " " + textBoxPassword.Text;
                    listBoxProxy.Items[listBoxProxy.Items.Count - 1].Tag = str;
                    textBoxAddProxy.Text = "";
                    textBoxPortAdd.Text = "";
                }
            } catch (Exception ex) {
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e) {
            foreach (ListViewItem listViewItem in listBoxProxy.SelectedItems)
                listBoxProxy.Items.Remove(listViewItem);
        }

        private void buttonUp_Click(object sender, EventArgs e) {
            if (listBoxProxy.SelectedItems.Count <= 0 || listBoxProxy.Items.Count <= 1)
                return;
            var listViewItem = listBoxProxy.SelectedItems[0];
            var num = listBoxProxy.Items.IndexOf(listViewItem);
            if (num == 0)
                return;
            listBoxProxy.Items.Remove(listViewItem);
            listBoxProxy.Items.Insert(num - 1, listViewItem);
            listBoxProxy.Items[num - 1].Selected = true;
        }

        private void buttonDown_Click(object sender, EventArgs e) {
            if (listBoxProxy.SelectedItems.Count <= 0 || listBoxProxy.Items.Count <= 1)
                return;
            var listViewItem = listBoxProxy.SelectedItems[0];
            var num = listBoxProxy.Items.IndexOf(listViewItem);
            if (num == listBoxProxy.Items.Count - 1)
                return;
            listBoxProxy.Items.Remove(listViewItem);
            listBoxProxy.Items.Insert(num + 1, listViewItem);
            listBoxProxy.Items[num + 1].Selected = true;
        }

        private void textBoxDigit_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = !char.IsDigit(e.KeyChar);
            if (!char.IsControl(e.KeyChar))
                return;
            e.Handled = false;
        }

        private void checkBoxPauseMiner_CheckedChanged(object sender, EventArgs e) {
            UpdateMinerPage();
        }

        private void buttonAutoSaveFile_Click(object sender, EventArgs e) {
            var saveFileDialog = new SaveFileDialog();
            try {
                saveFileDialog.OverwritePrompt = false;
                saveFileDialog.DefaultExt = "csv";
                saveFileDialog.Filter = "CSV file (*.csv)|*.csv|XML file (*.xml)|*.xml|TSV file (*.tsv)|*.tsv|All files (*.*)|*.*";
                if (textBoxAutoSaveFileName.Text != "") {
                    var directoryName = Path.GetDirectoryName(textBoxAutoSaveFileName.Text);
                    if (directoryName != "")
                        saveFileDialog.InitialDirectory = directoryName;
                }
                if (DialogResult.OK != saveFileDialog.ShowDialog())
                    return;
                textBoxAutoSaveFileName.Text = saveFileDialog.FileName;
            } catch (Exception ex) {
            }
        }

        private void checkBoxAutoSave_CheckedChanged(object sender, EventArgs e) {
            UpdateMinerPage();
        }

        private void textBoxAutoSaveNumRecords_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = !char.IsDigit(e.KeyChar);
            if (!char.IsControl(e.KeyChar))
                return;
            e.Handled = false;
        }

        private void checkBoxRequiredAuth_CheckedChanged(object sender, EventArgs e) {
            textBoxUserName.Enabled = checkBoxRequiredAuth.Checked;
            textBoxPassword.Enabled = checkBoxRequiredAuth.Checked;
        }

        private void checkBoxRotateProxy_CheckedChanged(object sender, EventArgs e) {
            textBoxInterval.Enabled = checkBoxRotateProxy.Checked;
        }

        private void buttonImport_Click(object sender, EventArgs e) {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "TXT file (*.txt)|*.txt|CSV file (*.csv)|*.csv| All files (*.*)|*.*";
            openFileDialog.AddExtension = true;
            openFileDialog.RestoreDirectory = true;
            try {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                var str = File.ReadAllText(openFileDialog.FileName).Replace("\r", "");
                var chArray = new char[3]
        {
          ',',
          ';',
          '\n'
        };
                foreach (var proxyDataString in str.Split(chArray)) {
                    if (proxyDataString != "") {
                        listBoxProxy.Items.Add(GetProxyData(proxyDataString).Address);
                        listBoxProxy.Items[listBoxProxy.Items.Count - 1].Tag = proxyDataString;
                    }
                }
            } catch (Exception ex) {
                var num = (int)MessageBox.Show(ex.Message, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void buttonTest_Click(object sender, EventArgs e) {
            var thread = new Thread(TestProxies);
            thread.Start();
            _testProxyForm.StartPosition = FormStartPosition.CenterParent;
            var num = (int)_testProxyForm.ShowDialog();
            thread.Abort();
        }

        private string GetProxyInfoString(int i) {
            string str;
            if (listBoxProxy.InvokeRequired)
                str = (string)Invoke(new GetProxyInfoStringCallback(GetProxyInfoString), (object)i);
            else
                str = (string)listBoxProxy.Items[i].Tag;
            return str;
        }

        private void CloseTestProxyForm() {
            if (_testProxyForm.InvokeRequired)
                Invoke(new CloseTestProxyFormCallback(CloseTestProxyForm), null);
            else
                _testProxyForm.Close();
        }

        private void RemoveProxyAt(int i) {
            if (listBoxProxy.InvokeRequired)
                Invoke(new RemoveProxyAtCallback(RemoveProxyAt), (object)i);
            else
                listBoxProxy.Items.RemoveAt(i);
        }

        private void TestProxies() {
            var num = 1;
            var count = listBoxProxy.Items.Count;
            for (var i = count - 1; i >= 0; --i) {
                _testProxyForm.SetStatus("(" + num.ToString() + " of " + count.ToString() + ")");
                ++num;
                if (!ProxyManager.CheckProxy(GetProxyData(GetProxyInfoString(i))))
                    RemoveProxyAt(i);
            }
            CloseTestProxyForm();
        }

        private void buttonAdvanced_Click(object sender, EventArgs e) {
            var minerOptionsForm = new AdvancedMinerOptionsForm();
            minerOptionsForm.StartPosition = FormStartPosition.CenterParent;
            var num = (int)minerOptionsForm.ShowDialog();
        }


        private enum TabType {
            Miner,
            Proxy,
        }

        private delegate string GetProxyInfoStringCallback(int i);

        private delegate void CloseTestProxyFormCallback();

        private delegate void RemoveProxyAtCallback(int i);
    }
}

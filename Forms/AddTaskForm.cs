using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using GodLesZ.Tools.WebScraper.Properties;
using Microsoft.Win32.TaskScheduler;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class AddTaskForm : Form {
        private string _dbCommandLine = "";
        private bool _editMode;
        private ExportDbForm _selDbForm;

        public string TaskName {
            get {
                return textBoxTaskName.Text;
            }
            set {
                textBoxTaskName.Text = value;
                _editMode = true;
            }
        }


        public AddTaskForm() {
            InitializeComponent();
        }

        private void InitForm() {
            comboBoxRepeatFrequency.SelectedIndex = 1;
            if (textBoxTaskName.Text == "")
                return;

            Text = "Edit Task";
            buttonOK.Text = "&Apply";
            textBoxTaskName.Enabled = false;
            if (GetTask())
                return;
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void AddTaskForm_Load(object sender, EventArgs e) {
            radioButtonExportFile_CheckedChanged(null, null);
            InitForm();
        }

        private string[] ParseArguments(string commandLine) {
            var chArray = commandLine.ToCharArray();
            var flag = false;
            for (var index = 0; index < chArray.Length; ++index) {
                if (chArray[index] == 34)
                    flag = !flag;
                if (!flag && chArray[index] == 32)
                    chArray[index] = '\n';
            }
            var strArray = new string(chArray).Split(new[]
                {
                '\n'
                }, StringSplitOptions.RemoveEmptyEntries);
            for (var index = 0; index < strArray.Length; ++index)
                strArray[index] = strArray[index].Replace('"', ' ').Trim();
            return strArray;
        }

        private bool GetTask() {
            var flag = true;
            try {
                using (var taskService = new TaskService()) {
                    var task = taskService.GetTask(textBoxTaskName.Text);
                    if (task != null) {
                        var definition = task.Definition;
                        var execAction = (ExecAction)definition.Actions[0];
                        var strArray = ParseArguments(execAction.Arguments);
                        var str = strArray[1].Trim();
                        textBoxConfFileName.Text = strArray[0];
                        if (strArray[2].ToLower() == "db") {
                            radioButtonExportDB.Checked = true;
                            var num = execAction.Arguments.ToLower().IndexOf(" db ");
                            _dbCommandLine = execAction.Arguments.Substring(num + " db ".Length);
                        } else
                            textBoxExportFileName.Text = strArray[2];
                        if (str == "-1")
                            checkBoxMineAllPages.Checked = true;
                        else
                            textBoxNumPages.Text = str;
                        switch (definition.Triggers[0].TriggerType) {
                            case TaskTriggerType.Daily:
                                if (definition.Triggers[0].Repetition.Interval == TimeSpan.FromHours(1.0)) {
                                    comboBoxRepeatFrequency.SelectedIndex = 0;
                                    break;
                                } else {
                                    comboBoxRepeatFrequency.SelectedIndex = 1;
                                    break;
                                }
                            case TaskTriggerType.Weekly:
                                comboBoxRepeatFrequency.SelectedIndex = 2;
                                break;
                            case TaskTriggerType.Monthly:
                                comboBoxRepeatFrequency.SelectedIndex = 3;
                                break;
                        }
                        dateTimePickerStartDate.Value = definition.Triggers[0].StartBoundary;
                    } else
                        flag = false;
                }
            } catch (Exception) {
                flag = false;
            }
            return flag;
        }

        private void checkBoxMineAllPages_CheckedChanged(object sender, EventArgs e) {
            textBoxNumPages.Enabled = !checkBoxMineAllPages.Checked;
        }

        private void textBoxNumPages_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = !char.IsDigit(e.KeyChar);
            if (!char.IsControl(e.KeyChar))
                return;
            e.Handled = false;
        }

        private void buttonBrowseConfigFile_Click(object sender, EventArgs e) {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "xml";
            openFileDialog.Filter = "XML file (*.xml)|*.xml| All files (*.*)|*.*";
            openFileDialog.AddExtension = true;
            openFileDialog.RestoreDirectory = true;
            try {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                textBoxConfFileName.Text = openFileDialog.FileName;
            } catch (Exception ex) {
                var num = (int)MessageBox.Show(ex.Message, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void buttonSaveToFile_Click(object sender, EventArgs e) {
            var saveFileDialog = new SaveFileDialog();
            try {
                saveFileDialog.OverwritePrompt = false;
                saveFileDialog.DefaultExt = "csv";
                saveFileDialog.Filter = "CSV file (*.csv)|*.csv|XML file (*.xml)|*.xml|JSON file (*.json)|*.json|TSV file (*.tsv)|*.tsv|All files (*.*)|*.*";
                if (textBoxExportFileName.Text != "") {
                    var directoryName = Path.GetDirectoryName(textBoxExportFileName.Text);
                    if (directoryName != "")
                        saveFileDialog.InitialDirectory = directoryName;
                }
                if (DialogResult.OK != saveFileDialog.ShowDialog())
                    return;
                textBoxExportFileName.Text = saveFileDialog.FileName;
            } catch (Exception ex) {
                var num = (int)MessageBox.Show(ex.Message, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private bool ValidateParams() {
            var flag = true;
            try {
                if (textBoxTaskName.Text.Trim() == "")
                    flag = false;
                else if (textBoxConfFileName.Text.Trim() == "" || !File.Exists(textBoxConfFileName.Text)) {
                    flag = false;
                } else {
                    textBoxConfFileName.Text = Path.GetFullPath(textBoxConfFileName.Text);
                    if (!checkBoxMineAllPages.Checked && textBoxNumPages.Text.Trim() == "")
                        flag = false;
                    else if (radioButtonExportFile.Checked && textBoxExportFileName.Text.Trim() == "")
                        flag = false;
                    else if (radioButtonExportDB.Checked && _dbCommandLine == "")
                        flag = false;
                    else
                        textBoxExportFileName.Text = Path.GetFullPath(textBoxExportFileName.Text);
                }
            } catch (Exception ex) {
            }
            return flag;
        }

        private bool ScheduleTask() {
            var flag = true;
            try {
                using (var taskService = new TaskService()) {
                    TaskDefinition definition;
                    if (!_editMode) {
                        definition = taskService.NewTask();
                    } else {
                        definition = taskService.GetTask(textBoxTaskName.Text).Definition;
                        definition.Triggers.Clear();
                        definition.Actions.Clear();
                    }
                    definition.RegistrationInfo.Author = "WebScraper";
                    definition.RegistrationInfo.Description = "Scheduled Mining";
                    definition.Principal.LogonType = TaskLogonType.InteractiveToken;
                    switch (comboBoxRepeatFrequency.SelectedIndex) {
                        case 0:
                            var dailyTrigger1 = new DailyTrigger((short)1);
                            dailyTrigger1.Repetition.Duration = TimeSpan.FromHours(23.0);
                            dailyTrigger1.Repetition.Interval = TimeSpan.FromHours(1.0);
                            dailyTrigger1.StartBoundary = dateTimePickerStartDate.Value;
                            definition.Triggers.Add(dailyTrigger1);
                            break;
                        case 1:
                            var triggers1 = definition.Triggers;
                            var dailyTrigger2 = new DailyTrigger((short)1);
                            dailyTrigger2.StartBoundary = dateTimePickerStartDate.Value;
                            var dailyTrigger3 = dailyTrigger2;
                            var dailyTrigger4 = (DailyTrigger)triggers1.Add(dailyTrigger3);
                            break;
                        case 2:
                            var triggers2 = definition.Triggers;
                            var weeklyTrigger1 = new WeeklyTrigger(DaysOfTheWeek.Sunday, (short)1);
                            weeklyTrigger1.StartBoundary = dateTimePickerStartDate.Value;
                            weeklyTrigger1.DaysOfWeek = (DaysOfTheWeek)(1 << (int)(dateTimePickerStartDate.Value.DayOfWeek & (DayOfWeek)31));
                            var weeklyTrigger2 = weeklyTrigger1;
                            var weeklyTrigger3 = (WeeklyTrigger)triggers2.Add(weeklyTrigger2);
                            break;
                        case 3:
                            var triggers3 = definition.Triggers;
                            var monthlyTrigger1 = new MonthlyTrigger(1, MonthsOfTheYear.AllMonths);
                            monthlyTrigger1.StartBoundary = dateTimePickerStartDate.Value;
                            monthlyTrigger1.DaysOfMonth = new int[1]
              {
                dateTimePickerStartDate.Value.Day
              };
                            var monthlyTrigger2 = monthlyTrigger1;
                            var monthlyTrigger3 = (MonthlyTrigger)triggers3.Add(monthlyTrigger2);
                            break;
                    }
                    string arguments;
                    if (radioButtonExportFile.Checked)
                        arguments = "\"" + textBoxConfFileName.Text + "\" " + (checkBoxMineAllPages.Checked ? "-1" : textBoxNumPages.Text) + " \"" + textBoxExportFileName.Text + "\"";
                    else
                        arguments = "\"" + textBoxConfFileName.Text + "\" " + (checkBoxMineAllPages.Checked ? "-1" : textBoxNumPages.Text) + " db " + _dbCommandLine;
                    definition.Actions.Add(new ExecAction(Application.ExecutablePath, arguments, (string)null));
                    taskService.RootFolder.RegisterTaskDefinition(textBoxTaskName.Text, definition);
                }
            } catch (Exception ex) {
                flag = false;
            }
            return flag;
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            if (!ValidateParams()) {
                var num = (int)MessageBox.Show(StringResource.InputError, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                DialogResult = DialogResult.None;
            } else {
                if (!ScheduleTask()) {
                    var num = (int)MessageBox.Show(StringResource.ScheduleFailed, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                Close();
            }
        }

        private void radioButtonExportFile_CheckedChanged(object sender, EventArgs e) {
            buttonSelDB.Visible = !radioButtonExportFile.Checked;
            labelExportFile.Visible = radioButtonExportFile.Checked;
            textBoxExportFileName.Visible = radioButtonExportFile.Checked;
            buttonSaveToFile.Visible = radioButtonExportFile.Checked;
        }

        private void buttonSelDB_Click(object sender, EventArgs e) {
            if (_selDbForm == null) {
                _selDbForm = new ExportDbForm(true);
                _selDbForm.SetSelMode();
                _selDbForm.StartPosition = FormStartPosition.CenterParent;
            }
            if (_editMode) {
                using (var taskService = new TaskService()) {
                    var task = taskService.GetTask(textBoxTaskName.Text);
                    if (task != null) {
                        var strArray = ParseArguments(((ExecAction)task.Definition.Actions[0]).Arguments);
                        if (strArray.Length > 2) {
                            if (strArray[2].ToLower().Equals("db")) {
                                if (strArray.Length > 7) {
                                    _selDbForm.SetDBParams(strArray[3], strArray[4], strArray[5], strArray[6]);
                                    _selDbForm.SetLoginParams(false, "", "");
                                    if (strArray[7].ToLower() == "false") {
                                        if (strArray.Length > 9)
                                            _selDbForm.SetLoginParams(false, strArray[8], strArray[9]);
                                    } else
                                        _selDbForm.SetLoginParams(true, "", "");
                                }
                            }
                        }
                    }
                }
            }
            if (_selDbForm.ShowDialog() != DialogResult.OK)
                return;
            _dbCommandLine = _selDbForm.DbCommandLine;
        }

    }
}

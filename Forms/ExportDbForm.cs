using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using GodLesZ.Tools.WebScraper.Library;
using GodLesZ.Tools.WebScraper.Properties;
using MySql.Data.MySqlClient;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class ExportDbForm : Form {
        private readonly SqlConnection _msSqlConn = new SqlConnection();
        private readonly SqlCommand _msSqlCmd = new SqlCommand();
        private readonly MySqlConnection _mySqlConn = new MySqlConnection();
        private readonly MySqlCommand _mySqlCmd = new MySqlCommand();
        private IDbConnection _sqlConn;
        private IDbCommand _sqlCmd;
        private DataTable _dataTable;

        private EServerType SelectedServerType {
            get { return (EServerType)comboBoxServerType.SelectedIndex; }
        }

        public bool AutoExport {
            get;
            set;
        }

        public string DbCommandLine {
            get {
                var str = textBoxServerAddress.Text + " " + (comboBoxServerType.SelectedIndex == 0 ? "mssql" : "mysql") + " " + textBoxDBName.Text + " " + textBoxTableName.Text + " " + checkBoxWinAuth.Checked.ToString().ToLower();
                if (!checkBoxWinAuth.Checked)
                    str = str + " " + textBoxUserName.Text + " " + textBoxPassword.Text;
                return str;
            }
        }

        public DataTable MineData {
            set { _dataTable = value; }
        }


        public ExportDbForm(bool selectionMode = false) {
            InitializeComponent();
            comboBoxServerType.SelectedIndex = 0;
            if (!selectionMode) {
                if (Settings.Default.DBServerName != "")
                    textBoxServerAddress.Text = Settings.Default.DBServerName;
                if (Settings.Default.DBName != "")
                    textBoxDBName.Text = Settings.Default.DBName;
                if (Settings.Default.DBUserName != "")
                    textBoxUserName.Text = Settings.Default.DBUserName;
                if (Settings.Default.DBPwd != "")
                    textBoxPassword.Text = Settings.Default.DBPwd;
                if (Settings.Default.DBTableName != "")
                    textBoxTableName.Text = Settings.Default.DBTableName;
                comboBoxServerType.SelectedIndex = Settings.Default.DBType;
                checkBoxWinAuth.Checked = Settings.Default.DBWindowsAuth;
            }
            checkBoxWinAuth_CheckStateChanged(null, null);
        }

        private void DisplayMessage(string mainMsg, Exception ex) {
            MessageBox.Show(StringResource.ResourceManager.GetString(mainMsg) + "\n\n" + ex.Message, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        public void SetSelMode() {
            buttonExport.Text = " &Save";
            Text = "Select Database";
        }

        private void ExportDBForm_Shown(object sender, EventArgs e) {
            if (!AutoExport)
                return;
            buttonExport.PerformClick();
        }

        public void SetDBParams(string dbServerAddress, string dbType, string dbName, string dbTableName) {
            textBoxServerAddress.Text = dbServerAddress;
            textBoxDBName.Text = dbName;
            textBoxTableName.Text = dbTableName;
            if (dbType.ToLower() == "mysql")
                comboBoxServerType.SelectedIndex = 1;
            else
                comboBoxServerType.SelectedIndex = 0;
        }

        public void SetLoginParams(bool winAuth, string username = "", string pwd = "") {
            checkBoxWinAuth.Checked = winAuth;
            if (winAuth)
                return;
            textBoxUserName.Text = username;
            textBoxPassword.Text = pwd;
        }

        private string GetConnectionString(bool bConnectToDB) {
            var str = "";
            switch (SelectedServerType) {
                case EServerType.MSSQL:
                    if (checkBoxWinAuth.Checked) {
                        str = "server=" + textBoxServerAddress.Text + ";Initial Catalog=" + (bConnectToDB ? textBoxDBName.Text : "") + ";Integrated Security=true;";
                        break;
                    } else {
                        str = "server=" + textBoxServerAddress.Text + ";Initial Catalog=" + (bConnectToDB ? textBoxDBName.Text : "") + ";User ID=" + textBoxUserName.Text + ";Password=" + textBoxPassword.Text + ";";
                        break;
                    }
                case EServerType.MySQL:
                    str = "Server=" + textBoxServerAddress.Text + ";Database=" + textBoxDBName.Text + ";Uid=" + textBoxUserName.Text + ";Pwd=" + textBoxPassword.Text + ";";
                    break;
            }
            return str;
        }

        private bool ConnectToDatabase() {
            var flag = true;
            _sqlConn.ConnectionString = GetConnectionString(true);
            try {
                _sqlConn.Open();
            } catch (Exception ex) {
                DisplayMessage("strDBConnFailed", ex);
                flag = false;
            }
            if (flag) {
                _sqlCmd.CommandType = CommandType.Text;
                _sqlCmd.Connection = _sqlConn;
            }
            return flag;
        }

        private void CloseConnection() {
            _sqlConn.Close();
        }

        private bool DoesDBExist() {
            var dbConnection = SelectedServerType == EServerType.MSSQL ? new SqlConnection() : (IDbConnection)new MySqlConnection();
            dbConnection.ConnectionString = GetConnectionString(false);
            _sqlCmd.CommandType = CommandType.Text;
            _sqlCmd.CommandText = SelectedServerType != EServerType.MSSQL ? "SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '" + textBoxDBName.Text + "'" : "SELECT database_id FROM sys.databases WHERE Name = '" + textBoxDBName.Text + "'";
            try {
                _sqlCmd.Connection = dbConnection;
                dbConnection.Open();
                var num = (int)_sqlCmd.ExecuteScalar();
                dbConnection.Close();
                return num > 0;
            } catch (Exception ex) {
                return false;
            }
        }

        private bool CreateDatabase() {
            var flag = true;
            var dbConnection = SelectedServerType == EServerType.MSSQL ? new SqlConnection() : (IDbConnection)new MySqlConnection();
            dbConnection.ConnectionString = GetConnectionString(false);
            _sqlCmd.CommandType = CommandType.Text;
            _sqlCmd.CommandText = "CREATE DATABASE " + textBoxDBName.Text;
            if (SelectedServerType == EServerType.MySQL)
                _sqlCmd.CommandText = "CREATE DATABASE IF NOT EXISTS " + textBoxDBName.Text;
            _sqlCmd.Connection = dbConnection;
            try {
                dbConnection.Open();
                _sqlCmd.ExecuteNonQuery();
            } catch (Exception ex) {
                DisplayMessage("strDBCreateFailed", ex);
                flag = false;
            } finally {
                dbConnection.Close();
            }
            return flag;
        }

        private bool DoesTableExist() {
            var flag = true;
            try {
                _sqlCmd.CommandText = "SELECT COUNT(*) FROM " + textBoxTableName.Text;
                _sqlCmd.ExecuteNonQuery();
            } catch (Exception ex) {
                flag = false;
            }
            return flag;
        }

        private bool CreateTable() {
            var flag = true;
            try {
                _sqlCmd.CommandText = "CREATE TABLE " + textBoxTableName.Text + " (";
                for (var index = 0; index < _dataTable.Columns.Count; ++index) {
                    var dbCommand1 = _sqlCmd;
                    var str1 = dbCommand1.CommandText + _dataTable.Columns[index].ColumnName.Replace(" ", "") + " TEXT";
                    dbCommand1.CommandText = str1;
                    if (index != _dataTable.Columns.Count - 1) {
                        var dbCommand2 = _sqlCmd;
                        var str2 = dbCommand2.CommandText + ",";
                        dbCommand2.CommandText = str2;
                    }
                }
                var dbCommand = _sqlCmd;
                var str = dbCommand.CommandText + ")";
                dbCommand.CommandText = str;
                _sqlCmd.ExecuteNonQuery();
            } catch (Exception ex) {
                DisplayMessage("strTableCreateFailed", ex);
                flag = false;
            }
            return flag;
        }

        private bool ExportData() {
            var flag = true;
            try {
                var str1 = "INSERT INTO " + textBoxTableName.Text + " (";
                for (var index = 0; index < _dataTable.Columns.Count; ++index) {
                    var str2 = _dataTable.Columns[index].ColumnName.Replace(" ", "");
                    str1 = SelectedServerType != EServerType.MSSQL ? str1 + str2 : str1 + "[" + str2 + "]";
                    if (index != _dataTable.Columns.Count - 1)
                        str1 = str1 + ",";
                }
                var str3 = str1 + ") VALUES(";
                progressBar.Visible = true;
                progressBar.Minimum = 0;
                progressBar.Maximum = _dataTable.Rows.Count;
                progressBar.Step = 1;
                progressBar.Value = 0;
                for (var index1 = 0; index1 < _dataTable.Rows.Count; ++index1) {
                    var str2 = str3;
                    for (var index2 = 0; index2 < _dataTable.Columns.Count; ++index2) {
                        var str4 = _dataTable.Rows[index1][index2].ToString().Replace(Environment.NewLine, string.Empty);
                        if (SelectedServerType == EServerType.MSSQL)
                            str4 = str4.Replace("'", "''");
                        else if (SelectedServerType == EServerType.MySQL)
                            str4 = str4.Replace("'", "\\'").Replace("\"", "\\\"").Replace(",", "\\,");
                        str2 = str2 + "'" + str4 + "'";
                        if (index2 != _dataTable.Columns.Count - 1)
                            str2 = str2 + ",";
                    }
                    _sqlCmd.CommandText = str2 + ")";
                    _sqlCmd.ExecuteNonQuery();
                    progressBar.PerformStep();
                }
            } catch (Exception ex) {
                DisplayMessage("strExportDBFailed", ex);
                flag = false;
            }
            progressBar.Visible = false;
            return flag;
        }

        private void Export_Click(object sender, EventArgs e) {
            try {
                DialogResult = DialogResult.Abort;
                buttonExport.Enabled = false;
                if (textBoxServerAddress.Text == "" || textBoxTableName.Text == "" || textBoxDBName.Text == "") {
                    var num1 = (int)MessageBox.Show(StringResource.ExportDbFieldWarning, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                } else if (!checkBoxWinAuth.Checked && (textBoxUserName.Text == "" || textBoxPassword.Text == "")) {
                    var num2 = (int)MessageBox.Show(StringResource.ExportDbLoginWarning, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                } else if (buttonExport.Text.Trim() == "&Save") {
                    DialogResult = DialogResult.OK;
                    buttonExport.Enabled = true;
                    return;
                } else {
                    switch (SelectedServerType) {
                        case EServerType.MSSQL:
                            _sqlConn = _msSqlConn;
                            _sqlCmd = _msSqlCmd;
                            break;
                        case EServerType.MySQL:
                            _sqlConn = _mySqlConn;
                            _sqlCmd = _mySqlCmd;
                            break;
                    }
                    Cursor.Current = Cursors.WaitCursor;
                    if ((DoesDBExist() || CreateDatabase()) && ConnectToDatabase() && ((DoesTableExist() || CreateTable()) && ExportData())) {
                        if (!AutoExport) {
                            var num3 = (int)MessageBox.Show(StringResource.ExportDbSuccess, StringResource.PgmName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        DialogResult = DialogResult.OK;
                    }
                }
                CloseConnection();
                buttonExport.Enabled = true;
                if (!AutoExport) {
                    if (textBoxServerAddress.Text != "")
                        Settings.Default.DBServerName = textBoxServerAddress.Text;
                    if (textBoxDBName.Text != "")
                        Settings.Default.DBName = textBoxDBName.Text;
                    if (textBoxUserName.Text != "")
                        Settings.Default.DBUserName = textBoxUserName.Text;
                    if (textBoxTableName.Text != "")
                        Settings.Default.DBTableName = textBoxTableName.Text;
                    if (textBoxPassword.Text != "")
                        Settings.Default.DBPwd = textBoxPassword.Text;
                    Settings.Default.DBType = comboBoxServerType.SelectedIndex;
                    Settings.Default.DBWindowsAuth = checkBoxWinAuth.Checked;
                }
                if (!AutoExport)
                    return;
                Close();
            } catch (Exception ex) {
                Cursor.Current = Cursors.Default;
                buttonExport.Enabled = true;
            }
        }

        private void checkBoxWinAuth_CheckStateChanged(object sender, EventArgs e) {
            textBoxUserName.Enabled = !checkBoxWinAuth.Checked;
            textBoxPassword.Enabled = !checkBoxWinAuth.Checked;
        }

        private void comboBoxServerType_SelectedIndexChanged(object sender, EventArgs e) {
            if (SelectedServerType == EServerType.MySQL) {
                checkBoxWinAuth.Checked = false;
                checkBoxWinAuth.Enabled = false;
            } else
                checkBoxWinAuth.Enabled = true;
        }


    }
}

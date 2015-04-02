using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class ExportDbForm  {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.buttonExport = new System.Windows.Forms.Button();
            this.textBoxServerAddress = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.checkBoxWinAuth = new System.Windows.Forms.CheckBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelUName = new System.Windows.Forms.Label();
            this.labelPwd = new System.Windows.Forms.Label();
            this.labelDBName = new System.Windows.Forms.Label();
            this.textBoxDBName = new System.Windows.Forms.TextBox();
            this.labelTableName = new System.Windows.Forms.Label();
            this.textBoxTableName = new System.Windows.Forms.TextBox();
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.comboBoxServerType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExport
            // 
            this.buttonExport.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.ico_export;
            this.buttonExport.Location = new System.Drawing.Point(182, 310);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(108, 31);
            this.buttonExport.TabIndex = 4;
            this.buttonExport.Text = "   &Export";
            this.buttonExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.Export_Click);
            // 
            // textBoxServerAddress
            // 
            this.textBoxServerAddress.Location = new System.Drawing.Point(12, 27);
            this.textBoxServerAddress.Name = "textBoxServerAddress";
            this.textBoxServerAddress.Size = new System.Drawing.Size(169, 20);
            this.textBoxServerAddress.TabIndex = 0;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(10, 9);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(136, 13);
            this.labelAddress.TabIndex = 0;
            this.labelAddress.Text = "SQL Server Name/Address";
            // 
            // checkBoxWinAuth
            // 
            this.checkBoxWinAuth.AutoSize = true;
            this.checkBoxWinAuth.Location = new System.Drawing.Point(16, 29);
            this.checkBoxWinAuth.Name = "checkBoxWinAuth";
            this.checkBoxWinAuth.Size = new System.Drawing.Size(163, 17);
            this.checkBoxWinAuth.TabIndex = 0;
            this.checkBoxWinAuth.Text = "Use Windows Authentication";
            this.checkBoxWinAuth.UseVisualStyleBackColor = true;
            this.checkBoxWinAuth.CheckStateChanged += new System.EventHandler(this.checkBoxWinAuth_CheckStateChanged);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Enabled = false;
            this.textBoxUserName.Location = new System.Drawing.Point(101, 52);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(154, 20);
            this.textBoxUserName.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Enabled = false;
            this.textBoxPassword.Location = new System.Drawing.Point(101, 78);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(154, 20);
            this.textBoxPassword.TabIndex = 2;
            // 
            // labelUName
            // 
            this.labelUName.AutoSize = true;
            this.labelUName.Location = new System.Drawing.Point(35, 55);
            this.labelUName.Name = "labelUName";
            this.labelUName.Size = new System.Drawing.Size(60, 13);
            this.labelUName.TabIndex = 6;
            this.labelUName.Text = "User Name";
            // 
            // labelPwd
            // 
            this.labelPwd.AutoSize = true;
            this.labelPwd.Location = new System.Drawing.Point(35, 81);
            this.labelPwd.Name = "labelPwd";
            this.labelPwd.Size = new System.Drawing.Size(53, 13);
            this.labelPwd.TabIndex = 7;
            this.labelPwd.Text = "Password";
            // 
            // labelDBName
            // 
            this.labelDBName.AutoSize = true;
            this.labelDBName.Location = new System.Drawing.Point(12, 208);
            this.labelDBName.Name = "labelDBName";
            this.labelDBName.Size = new System.Drawing.Size(84, 13);
            this.labelDBName.TabIndex = 2;
            this.labelDBName.Text = "Database Name";
            // 
            // textBoxDBName
            // 
            this.textBoxDBName.Location = new System.Drawing.Point(12, 224);
            this.textBoxDBName.Name = "textBoxDBName";
            this.textBoxDBName.Size = new System.Drawing.Size(278, 20);
            this.textBoxDBName.TabIndex = 1;
            // 
            // labelTableName
            // 
            this.labelTableName.AutoSize = true;
            this.labelTableName.Location = new System.Drawing.Point(12, 261);
            this.labelTableName.Name = "labelTableName";
            this.labelTableName.Size = new System.Drawing.Size(65, 13);
            this.labelTableName.TabIndex = 3;
            this.labelTableName.Text = "Table Name";
            // 
            // textBoxTableName
            // 
            this.textBoxTableName.Location = new System.Drawing.Point(12, 277);
            this.textBoxTableName.Name = "textBoxTableName";
            this.textBoxTableName.Size = new System.Drawing.Size(278, 20);
            this.textBoxTableName.TabIndex = 2;
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.Controls.Add(this.labelPwd);
            this.groupBoxLogin.Controls.Add(this.labelUName);
            this.groupBoxLogin.Controls.Add(this.textBoxPassword);
            this.groupBoxLogin.Controls.Add(this.textBoxUserName);
            this.groupBoxLogin.Controls.Add(this.checkBoxWinAuth);
            this.groupBoxLogin.Location = new System.Drawing.Point(12, 64);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(278, 126);
            this.groupBoxLogin.TabIndex = 1;
            this.groupBoxLogin.TabStop = false;
            this.groupBoxLogin.Text = "Login";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 351);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(278, 12);
            this.progressBar.TabIndex = 5;
            this.progressBar.Visible = false;
            // 
            // comboBoxServerType
            // 
            this.comboBoxServerType.FormattingEnabled = true;
            this.comboBoxServerType.Items.AddRange(new object[] {
            "MS SQL Server",
            "MySQL"});
            this.comboBoxServerType.Location = new System.Drawing.Point(190, 26);
            this.comboBoxServerType.Name = "comboBoxServerType";
            this.comboBoxServerType.Size = new System.Drawing.Size(100, 21);
            this.comboBoxServerType.TabIndex = 6;
            this.comboBoxServerType.SelectedIndexChanged += new System.EventHandler(this.comboBoxServerType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Type";
            // 
            // ExportDBForm
            // 
            this.ClientSize = new System.Drawing.Size(302, 369);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxServerType);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBoxLogin);
            this.Controls.Add(this.textBoxTableName);
            this.Controls.Add(this.labelTableName);
            this.Controls.Add(this.textBoxDBName);
            this.Controls.Add(this.labelDBName);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.textBoxServerAddress);
            this.Controls.Add(this.buttonExport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportDBForm";
            this.ShowIcon = false;
            this.Text = "Export to SQL Database";
            this.Shown += new System.EventHandler(this.ExportDBForm_Shown);
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        private Button buttonExport;
        private TextBox textBoxServerAddress;
        private Label labelAddress;
        private CheckBox checkBoxWinAuth;
        private TextBox textBoxUserName;
        private TextBox textBoxPassword;
        private Label labelUName;
        private Label labelPwd;
        private Label labelDBName;
        private TextBox textBoxDBName;
        private Label labelTableName;
        private TextBox textBoxTableName;
        private GroupBox groupBoxLogin;
        private ProgressBar progressBar;
        private ComboBox comboBoxServerType;
        private Label label1;        
        #endregion
    }
}

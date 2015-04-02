using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class AddTaskForm  {
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTaskName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxConfFileName = new System.Windows.Forms.TextBox();
            this.buttonBrowseConfigFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxMineAllPages = new System.Windows.Forms.CheckBox();
            this.textBoxNumPages = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelExportFile = new System.Windows.Forms.Label();
            this.textBoxExportFileName = new System.Windows.Forms.TextBox();
            this.buttonSaveToFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxRepeatFrequency = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.radioButtonExportFile = new System.Windows.Forms.RadioButton();
            this.radioButtonExportDB = new System.Windows.Forms.RadioButton();
            this.buttonSelDB = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Task Name";
            // 
            // textBoxTaskName
            // 
            this.textBoxTaskName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTaskName.Location = new System.Drawing.Point(104, 23);
            this.textBoxTaskName.Name = "textBoxTaskName";
            this.textBoxTaskName.Size = new System.Drawing.Size(224, 20);
            this.textBoxTaskName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Configuration File";
            // 
            // textBoxConfFileName
            // 
            this.textBoxConfFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConfFileName.Location = new System.Drawing.Point(104, 61);
            this.textBoxConfFileName.Name = "textBoxConfFileName";
            this.textBoxConfFileName.Size = new System.Drawing.Size(224, 20);
            this.textBoxConfFileName.TabIndex = 3;
            // 
            // buttonBrowseConfigFile
            // 
            this.buttonBrowseConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseConfigFile.Location = new System.Drawing.Point(334, 61);
            this.buttonBrowseConfigFile.Name = "buttonBrowseConfigFile";
            this.buttonBrowseConfigFile.Size = new System.Drawing.Size(26, 20);
            this.buttonBrowseConfigFile.TabIndex = 4;
            this.buttonBrowseConfigFile.Text = ". .";
            this.buttonBrowseConfigFile.UseVisualStyleBackColor = true;
            this.buttonBrowseConfigFile.Click += new System.EventHandler(this.buttonBrowseConfigFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pages to Mine";
            // 
            // checkBoxMineAllPages
            // 
            this.checkBoxMineAllPages.AutoSize = true;
            this.checkBoxMineAllPages.Location = new System.Drawing.Point(104, 100);
            this.checkBoxMineAllPages.Name = "checkBoxMineAllPages";
            this.checkBoxMineAllPages.Size = new System.Drawing.Size(96, 17);
            this.checkBoxMineAllPages.TabIndex = 6;
            this.checkBoxMineAllPages.Text = "Mine All Pages";
            this.checkBoxMineAllPages.UseVisualStyleBackColor = true;
            this.checkBoxMineAllPages.CheckedChanged += new System.EventHandler(this.checkBoxMineAllPages_CheckedChanged);
            // 
            // textBoxNumPages
            // 
            this.textBoxNumPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNumPages.Location = new System.Drawing.Point(245, 98);
            this.textBoxNumPages.Name = "textBoxNumPages";
            this.textBoxNumPages.Size = new System.Drawing.Size(33, 20);
            this.textBoxNumPages.TabIndex = 7;
            this.textBoxNumPages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumPages_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Pages";
            // 
            // labelExportFile
            // 
            this.labelExportFile.AutoSize = true;
            this.labelExportFile.Location = new System.Drawing.Point(110, 23);
            this.labelExportFile.Name = "labelExportFile";
            this.labelExportFile.Size = new System.Drawing.Size(23, 13);
            this.labelExportFile.TabIndex = 9;
            this.labelExportFile.Text = "File";
            // 
            // textBoxExportFileName
            // 
            this.textBoxExportFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExportFileName.Location = new System.Drawing.Point(139, 20);
            this.textBoxExportFileName.Name = "textBoxExportFileName";
            this.textBoxExportFileName.Size = new System.Drawing.Size(116, 20);
            this.textBoxExportFileName.TabIndex = 10;
            // 
            // buttonSaveToFile
            // 
            this.buttonSaveToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveToFile.Location = new System.Drawing.Point(261, 19);
            this.buttonSaveToFile.Name = "buttonSaveToFile";
            this.buttonSaveToFile.Size = new System.Drawing.Size(26, 21);
            this.buttonSaveToFile.TabIndex = 11;
            this.buttonSaveToFile.Text = ". .";
            this.buttonSaveToFile.UseVisualStyleBackColor = true;
            this.buttonSaveToFile.Click += new System.EventHandler(this.buttonSaveToFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Start Date / Time";
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerStartDate.CustomFormat = "dddd, MMM dd yyyy, hh:mm tt";
            this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(103, 132);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(256, 20);
            this.dateTimePickerStartDate.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Repeat";
            // 
            // comboBoxRepeatFrequency
            // 
            this.comboBoxRepeatFrequency.FormattingEnabled = true;
            this.comboBoxRepeatFrequency.Items.AddRange(new object[] {
            "Hourly",
            "Daily",
            "Weekly",
            "Monthly"});
            this.comboBoxRepeatFrequency.Location = new System.Drawing.Point(103, 167);
            this.comboBoxRepeatFrequency.Name = "comboBoxRepeatFrequency";
            this.comboBoxRepeatFrequency.Size = new System.Drawing.Size(73, 21);
            this.comboBoxRepeatFrequency.TabIndex = 15;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.delete;
            this.buttonCancel.Location = new System.Drawing.Point(211, 295);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(101, 38);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = " &Cancel";
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.alarm;
            this.buttonOK.Location = new System.Drawing.Point(67, 295);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(101, 38);
            this.buttonOK.TabIndex = 16;
            this.buttonOK.Text = " &Schedule";
            this.buttonOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // radioButtonExportFile
            // 
            this.radioButtonExportFile.AutoSize = true;
            this.radioButtonExportFile.Checked = true;
            this.radioButtonExportFile.Location = new System.Drawing.Point(34, 22);
            this.radioButtonExportFile.Name = "radioButtonExportFile";
            this.radioButtonExportFile.Size = new System.Drawing.Size(41, 17);
            this.radioButtonExportFile.TabIndex = 20;
            this.radioButtonExportFile.TabStop = true;
            this.radioButtonExportFile.Text = "File";
            this.radioButtonExportFile.UseVisualStyleBackColor = true;
            this.radioButtonExportFile.CheckedChanged += new System.EventHandler(this.radioButtonExportFile_CheckedChanged);
            // 
            // radioButtonExportDB
            // 
            this.radioButtonExportDB.AutoSize = true;
            this.radioButtonExportDB.Location = new System.Drawing.Point(34, 50);
            this.radioButtonExportDB.Name = "radioButtonExportDB";
            this.radioButtonExportDB.Size = new System.Drawing.Size(71, 17);
            this.radioButtonExportDB.TabIndex = 21;
            this.radioButtonExportDB.Text = "Database";
            this.radioButtonExportDB.UseVisualStyleBackColor = true;
            // 
            // buttonSelDB
            // 
            this.buttonSelDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelDB.Location = new System.Drawing.Point(139, 44);
            this.buttonSelDB.Name = "buttonSelDB";
            this.buttonSelDB.Size = new System.Drawing.Size(116, 28);
            this.buttonSelDB.TabIndex = 22;
            this.buttonSelDB.Text = "Select Database";
            this.buttonSelDB.UseVisualStyleBackColor = true;
            this.buttonSelDB.Click += new System.EventHandler(this.buttonSelDB_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButtonExportFile);
            this.groupBox1.Controls.Add(this.buttonSelDB);
            this.groupBox1.Controls.Add(this.radioButtonExportDB);
            this.groupBox1.Controls.Add(this.textBoxExportFileName);
            this.groupBox1.Controls.Add(this.labelExportFile);
            this.groupBox1.Controls.Add(this.buttonSaveToFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 81);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export To";
            // 
            // AddTaskForm
            // 
            this.ClientSize = new System.Drawing.Size(375, 347);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxRepeatFrequency);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNumPages);
            this.Controls.Add(this.checkBoxMineAllPages);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonBrowseConfigFile);
            this.Controls.Add(this.textBoxConfFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTaskName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTaskForm";
            this.ShowIcon = false;
            this.Text = "Schedule New Task";
            this.Load += new System.EventHandler(this.AddTaskForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }        
        
        private Label label1;
        private TextBox textBoxTaskName;
        private Label label2;
        private TextBox textBoxConfFileName;
        private Button buttonBrowseConfigFile;
        private Label label3;
        private CheckBox checkBoxMineAllPages;
        private TextBox textBoxNumPages;
        private Label label4;
        private Label labelExportFile;
        private TextBox textBoxExportFileName;
        private Button buttonSaveToFile;
        private Label label6;
        private DateTimePicker dateTimePickerStartDate;
        private Label label7;
        private ComboBox comboBoxRepeatFrequency;
        private Button buttonOK;
        private Button buttonCancel;
        private RadioButton radioButtonExportFile;
        private RadioButton radioButtonExportDB;
        private Button buttonSelDB;
        private GroupBox groupBox1;

        #endregion
    }
}

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class SettingsForm  {
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
            this.components = new System.ComponentModel.Container();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabMiner = new System.Windows.Forms.TabPage();
            this.buttonAdvanced = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxRemoveDuplicates = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonOpenAutoSaveFile = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxAutoSaveFileName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxAutoSaveNumRecords = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxAutoSave = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPauseInterval = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPauseTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxPauseMiner = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxAJAXWaitTime = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTimeout = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabProxy = new System.Windows.Forms.TabPage();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.listBoxProxy = new System.Windows.Forms.ListView();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxRotateProxy = new System.Windows.Forms.CheckBox();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.checkBoxRequiredAuth = new System.Windows.Forms.CheckBox();
            this.labelAddressAdd = new System.Windows.Forms.Label();
            this.textBoxPortAdd = new System.Windows.Forms.TextBox();
            this.labelPortAdd = new System.Windows.Forms.Label();
            this.textBoxAddProxy = new System.Windows.Forms.TextBox();
            this.labelInterval2 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelInterval1 = new System.Windows.Forms.Label();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.checkBoxEnableProxy = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCategoryKW = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBoxDoNotParseCategories = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBoxTagCategoryKW = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBoxTagColName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabMiner.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabProxy.SuspendLayout();
            this.groupBoxList.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabCategoryKW.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(201, 444);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(90, 31);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "&Apply";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(297, 444);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 31);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // tabMiner
            // 
            this.tabMiner.Controls.Add(this.buttonAdvanced);
            this.tabMiner.Controls.Add(this.groupBox4);
            this.tabMiner.Controls.Add(this.groupBox3);
            this.tabMiner.Controls.Add(this.groupBox2);
            this.tabMiner.Controls.Add(this.groupBox1);
            this.tabMiner.Location = new System.Drawing.Point(4, 22);
            this.tabMiner.Margin = new System.Windows.Forms.Padding(2);
            this.tabMiner.Name = "tabMiner";
            this.tabMiner.Padding = new System.Windows.Forms.Padding(2);
            this.tabMiner.Size = new System.Drawing.Size(372, 395);
            this.tabMiner.TabIndex = 1;
            this.tabMiner.Text = "Miner";
            this.tabMiner.UseVisualStyleBackColor = true;
            // 
            // buttonAdvanced
            // 
            this.buttonAdvanced.Location = new System.Drawing.Point(109, 359);
            this.buttonAdvanced.Name = "buttonAdvanced";
            this.buttonAdvanced.Size = new System.Drawing.Size(149, 29);
            this.buttonAdvanced.TabIndex = 9;
            this.buttonAdvanced.Text = "Advanced Miner &Options";
            this.buttonAdvanced.UseVisualStyleBackColor = true;
            this.buttonAdvanced.Click += new System.EventHandler(this.buttonAdvanced_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxRemoveDuplicates);
            this.groupBox4.Location = new System.Drawing.Point(5, 1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(361, 46);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            // 
            // checkBoxRemoveDuplicates
            // 
            this.checkBoxRemoveDuplicates.AutoSize = true;
            this.checkBoxRemoveDuplicates.Location = new System.Drawing.Point(7, 18);
            this.checkBoxRemoveDuplicates.Name = "checkBoxRemoveDuplicates";
            this.checkBoxRemoveDuplicates.Size = new System.Drawing.Size(270, 17);
            this.checkBoxRemoveDuplicates.TabIndex = 0;
            this.checkBoxRemoveDuplicates.Text = "Automatically remove duplicate records while mining";
            this.checkBoxRemoveDuplicates.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonOpenAutoSaveFile);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBoxAutoSaveFileName);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.textBoxAutoSaveNumRecords);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.checkBoxAutoSave);
            this.groupBox3.Location = new System.Drawing.Point(5, 256);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(362, 94);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // buttonOpenAutoSaveFile
            // 
            this.buttonOpenAutoSaveFile.Location = new System.Drawing.Point(275, 59);
            this.buttonOpenAutoSaveFile.Name = "buttonOpenAutoSaveFile";
            this.buttonOpenAutoSaveFile.Size = new System.Drawing.Size(26, 23);
            this.buttonOpenAutoSaveFile.TabIndex = 6;
            this.buttonOpenAutoSaveFile.Text = ". .";
            this.buttonOpenAutoSaveFile.UseVisualStyleBackColor = true;
            this.buttonOpenAutoSaveFile.Click += new System.EventHandler(this.buttonAutoSaveFile_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Save as";
            // 
            // textBoxAutoSaveFileName
            // 
            this.textBoxAutoSaveFileName.Location = new System.Drawing.Point(64, 61);
            this.textBoxAutoSaveFileName.Name = "textBoxAutoSaveFileName";
            this.textBoxAutoSaveFileName.Size = new System.Drawing.Size(205, 20);
            this.textBoxAutoSaveFileName.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(272, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "records";
            // 
            // textBoxAutoSaveNumRecords
            // 
            this.textBoxAutoSaveNumRecords.Location = new System.Drawing.Point(220, 27);
            this.textBoxAutoSaveNumRecords.Name = "textBoxAutoSaveNumRecords";
            this.textBoxAutoSaveNumRecords.Size = new System.Drawing.Size(46, 20);
            this.textBoxAutoSaveNumRecords.TabIndex = 2;
            this.textBoxAutoSaveNumRecords.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAutoSaveNumRecords_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(209, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Auto save data after capturing each set of ";
            // 
            // checkBoxAutoSave
            // 
            this.checkBoxAutoSave.AutoSize = true;
            this.checkBoxAutoSave.BackColor = System.Drawing.SystemColors.Window;
            this.checkBoxAutoSave.Location = new System.Drawing.Point(12, 0);
            this.checkBoxAutoSave.Name = "checkBoxAutoSave";
            this.checkBoxAutoSave.Size = new System.Drawing.Size(134, 17);
            this.checkBoxAutoSave.TabIndex = 0;
            this.checkBoxAutoSave.Text = "Auto Save Mined Data";
            this.checkBoxAutoSave.UseVisualStyleBackColor = false;
            this.checkBoxAutoSave.CheckedChanged += new System.EventHandler(this.checkBoxAutoSave_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxPauseInterval);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxPauseTime);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.checkBoxPauseMiner);
            this.groupBox2.Location = new System.Drawing.Point(5, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 103);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(11, 67);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(340, 35);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Injecting pauses helps to avoid making continous data requests to websites. This " +
    "prevents the miner from being blocked by websites.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "minutes interval";
            // 
            // textBoxPauseInterval
            // 
            this.textBoxPauseInterval.Location = new System.Drawing.Point(235, 33);
            this.textBoxPauseInterval.Name = "textBoxPauseInterval";
            this.textBoxPauseInterval.Size = new System.Drawing.Size(31, 20);
            this.textBoxPauseInterval.TabIndex = 4;
            this.textBoxPauseInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDigit_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "minutes after each";
            // 
            // textBoxPauseTime
            // 
            this.textBoxPauseTime.Location = new System.Drawing.Point(104, 33);
            this.textBoxPauseTime.Name = "textBoxPauseTime";
            this.textBoxPauseTime.Size = new System.Drawing.Size(31, 20);
            this.textBoxPauseTime.TabIndex = 2;
            this.textBoxPauseTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDigit_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Pause the Miner for ";
            // 
            // checkBoxPauseMiner
            // 
            this.checkBoxPauseMiner.AutoSize = true;
            this.checkBoxPauseMiner.BackColor = System.Drawing.SystemColors.Window;
            this.checkBoxPauseMiner.Location = new System.Drawing.Point(12, 0);
            this.checkBoxPauseMiner.Name = "checkBoxPauseMiner";
            this.checkBoxPauseMiner.Size = new System.Drawing.Size(154, 17);
            this.checkBoxPauseMiner.TabIndex = 0;
            this.checkBoxPauseMiner.Text = "Inject pauses during mining";
            this.checkBoxPauseMiner.UseVisualStyleBackColor = false;
            this.checkBoxPauseMiner.CheckedChanged += new System.EventHandler(this.checkBoxPauseMiner_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.textBoxAJAXWaitTime);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxTimeout);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(5, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 87);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(204, 57);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(141, 13);
            this.label17.TabIndex = 7;
            this.label17.Text = "(Time to wait for AJAX Load)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(204, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(140, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "(Time to wait for Page Load)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(153, 57);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "seconds";
            // 
            // textBoxAJAXWaitTime
            // 
            this.textBoxAJAXWaitTime.Location = new System.Drawing.Point(123, 54);
            this.textBoxAJAXWaitTime.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAJAXWaitTime.Name = "textBoxAJAXWaitTime";
            this.textBoxAJAXWaitTime.Size = new System.Drawing.Size(26, 20);
            this.textBoxAJAXWaitTime.TabIndex = 4;
            this.textBoxAJAXWaitTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDigit_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 57);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "AJAX Load Wait Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "seconds";
            // 
            // textBoxTimeout
            // 
            this.textBoxTimeout.Location = new System.Drawing.Point(123, 17);
            this.textBoxTimeout.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTimeout.Name = "textBoxTimeout";
            this.textBoxTimeout.Size = new System.Drawing.Size(26, 20);
            this.textBoxTimeout.TabIndex = 1;
            this.textBoxTimeout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDigit_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Page Load Timeout";
            // 
            // tabProxy
            // 
            this.tabProxy.Controls.Add(this.buttonTest);
            this.tabProxy.Controls.Add(this.buttonImport);
            this.tabProxy.Controls.Add(this.listBoxProxy);
            this.tabProxy.Controls.Add(this.label12);
            this.tabProxy.Controls.Add(this.label1);
            this.tabProxy.Controls.Add(this.checkBoxRotateProxy);
            this.tabProxy.Controls.Add(this.buttonUp);
            this.tabProxy.Controls.Add(this.buttonDown);
            this.tabProxy.Controls.Add(this.groupBoxList);
            this.tabProxy.Controls.Add(this.labelInterval2);
            this.tabProxy.Controls.Add(this.buttonAdd);
            this.tabProxy.Controls.Add(this.labelInterval1);
            this.tabProxy.Controls.Add(this.textBoxInterval);
            this.tabProxy.Controls.Add(this.buttonRemove);
            this.tabProxy.Controls.Add(this.checkBoxEnableProxy);
            this.tabProxy.Location = new System.Drawing.Point(4, 22);
            this.tabProxy.Name = "tabProxy";
            this.tabProxy.Padding = new System.Windows.Forms.Padding(3);
            this.tabProxy.Size = new System.Drawing.Size(372, 395);
            this.tabProxy.TabIndex = 0;
            this.tabProxy.Text = "Proxy Settings";
            this.tabProxy.UseVisualStyleBackColor = true;
            // 
            // buttonTest
            // 
            this.buttonTest.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.icon_stethoscope_small;
            this.buttonTest.Location = new System.Drawing.Point(338, 232);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(28, 26);
            this.buttonTest.TabIndex = 26;
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.importproxy;
            this.buttonImport.Location = new System.Drawing.Point(338, 202);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(28, 26);
            this.buttonImport.TabIndex = 25;
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // listBoxProxy
            // 
            this.listBoxProxy.FullRowSelect = true;
            this.listBoxProxy.GridLines = true;
            this.listBoxProxy.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listBoxProxy.Location = new System.Drawing.Point(31, 202);
            this.listBoxProxy.Name = "listBoxProxy";
            this.listBoxProxy.Size = new System.Drawing.Size(299, 145);
            this.listBoxProxy.TabIndex = 24;
            this.listBoxProxy.UseCompatibleStateImageBehavior = false;
            this.listBoxProxy.View = System.Windows.Forms.View.Details;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Add proxy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Proxy List";
            // 
            // checkBoxRotateProxy
            // 
            this.checkBoxRotateProxy.AutoSize = true;
            this.checkBoxRotateProxy.Location = new System.Drawing.Point(31, 362);
            this.checkBoxRotateProxy.Name = "checkBoxRotateProxy";
            this.checkBoxRotateProxy.Size = new System.Drawing.Size(94, 17);
            this.checkBoxRotateProxy.TabIndex = 21;
            this.checkBoxRotateProxy.Text = "Rotate proxies";
            this.checkBoxRotateProxy.UseVisualStyleBackColor = true;
            this.checkBoxRotateProxy.CheckedChanged += new System.EventHandler(this.checkBoxRotateProxy_CheckedChanged);
            // 
            // buttonUp
            // 
            this.buttonUp.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.up;
            this.buttonUp.Location = new System.Drawing.Point(338, 293);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(28, 26);
            this.buttonUp.TabIndex = 20;
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.down;
            this.buttonDown.Location = new System.Drawing.Point(338, 321);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(28, 26);
            this.buttonDown.TabIndex = 19;
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // groupBoxList
            // 
            this.groupBoxList.Controls.Add(this.label11);
            this.groupBoxList.Controls.Add(this.textBoxPassword);
            this.groupBoxList.Controls.Add(this.label10);
            this.groupBoxList.Controls.Add(this.textBoxUserName);
            this.groupBoxList.Controls.Add(this.checkBoxRequiredAuth);
            this.groupBoxList.Controls.Add(this.labelAddressAdd);
            this.groupBoxList.Controls.Add(this.textBoxPortAdd);
            this.groupBoxList.Controls.Add(this.labelPortAdd);
            this.groupBoxList.Controls.Add(this.textBoxAddProxy);
            this.groupBoxList.Location = new System.Drawing.Point(31, 61);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(300, 114);
            this.groupBoxList.TabIndex = 18;
            this.groupBoxList.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(153, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Enabled = false;
            this.textBoxPassword.Location = new System.Drawing.Point(208, 79);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(81, 20);
            this.textBoxPassword.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Username";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Enabled = false;
            this.textBoxUserName.Location = new System.Drawing.Point(65, 79);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(79, 20);
            this.textBoxUserName.TabIndex = 18;
            // 
            // checkBoxRequiredAuth
            // 
            this.checkBoxRequiredAuth.AutoSize = true;
            this.checkBoxRequiredAuth.Location = new System.Drawing.Point(11, 52);
            this.checkBoxRequiredAuth.Name = "checkBoxRequiredAuth";
            this.checkBoxRequiredAuth.Size = new System.Drawing.Size(139, 17);
            this.checkBoxRequiredAuth.TabIndex = 17;
            this.checkBoxRequiredAuth.Text = "Requires Authentication";
            this.checkBoxRequiredAuth.UseVisualStyleBackColor = true;
            this.checkBoxRequiredAuth.CheckedChanged += new System.EventHandler(this.checkBoxRequiredAuth_CheckedChanged);
            // 
            // labelAddressAdd
            // 
            this.labelAddressAdd.AutoSize = true;
            this.labelAddressAdd.Location = new System.Drawing.Point(8, 21);
            this.labelAddressAdd.Name = "labelAddressAdd";
            this.labelAddressAdd.Size = new System.Drawing.Size(45, 13);
            this.labelAddressAdd.TabIndex = 16;
            this.labelAddressAdd.Text = "Address";
            // 
            // textBoxPortAdd
            // 
            this.textBoxPortAdd.Location = new System.Drawing.Point(236, 19);
            this.textBoxPortAdd.Name = "textBoxPortAdd";
            this.textBoxPortAdd.Size = new System.Drawing.Size(53, 20);
            this.textBoxPortAdd.TabIndex = 15;
            this.textBoxPortAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDigit_KeyPress);
            // 
            // labelPortAdd
            // 
            this.labelPortAdd.AutoSize = true;
            this.labelPortAdd.Location = new System.Drawing.Point(201, 21);
            this.labelPortAdd.Name = "labelPortAdd";
            this.labelPortAdd.Size = new System.Drawing.Size(26, 13);
            this.labelPortAdd.TabIndex = 14;
            this.labelPortAdd.Text = "Port";
            // 
            // textBoxAddProxy
            // 
            this.textBoxAddProxy.Location = new System.Drawing.Point(64, 19);
            this.textBoxAddProxy.Name = "textBoxAddProxy";
            this.textBoxAddProxy.Size = new System.Drawing.Size(124, 20);
            this.textBoxAddProxy.TabIndex = 4;
            // 
            // labelInterval2
            // 
            this.labelInterval2.AutoSize = true;
            this.labelInterval2.Location = new System.Drawing.Point(194, 364);
            this.labelInterval2.Name = "labelInterval2";
            this.labelInterval2.Size = new System.Drawing.Size(43, 13);
            this.labelInterval2.TabIndex = 10;
            this.labelInterval2.Text = "minutes";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.plus;
            this.buttonAdd.Location = new System.Drawing.Point(338, 98);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(28, 47);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelInterval1
            // 
            this.labelInterval1.AutoSize = true;
            this.labelInterval1.Location = new System.Drawing.Point(123, 363);
            this.labelInterval1.Name = "labelInterval1";
            this.labelInterval1.Size = new System.Drawing.Size(33, 13);
            this.labelInterval1.TabIndex = 9;
            this.labelInterval1.Text = "every";
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Enabled = false;
            this.textBoxInterval.Location = new System.Drawing.Point(158, 361);
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(31, 20);
            this.textBoxInterval.TabIndex = 8;
            this.textBoxInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDigit_KeyPress);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.minus;
            this.buttonRemove.Location = new System.Drawing.Point(338, 262);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(28, 26);
            this.buttonRemove.TabIndex = 7;
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // checkBoxEnableProxy
            // 
            this.checkBoxEnableProxy.AutoSize = true;
            this.checkBoxEnableProxy.Location = new System.Drawing.Point(15, 17);
            this.checkBoxEnableProxy.Name = "checkBoxEnableProxy";
            this.checkBoxEnableProxy.Size = new System.Drawing.Size(236, 17);
            this.checkBoxEnableProxy.TabIndex = 0;
            this.checkBoxEnableProxy.Text = "&Enable network connection via Proxy Server";
            this.checkBoxEnableProxy.UseVisualStyleBackColor = true;
            this.checkBoxEnableProxy.CheckedChanged += new System.EventHandler(this.checkBoxEnableProxy_CheckedChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMiner);
            this.tabControl.Controls.Add(this.tabProxy);
            this.tabControl.Controls.Add(this.tabCategoryKW);
            this.tabControl.Location = new System.Drawing.Point(7, 9);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(380, 421);
            this.tabControl.TabIndex = 0;
            // 
            // tabCategoryKW
            // 
            this.tabCategoryKW.Controls.Add(this.groupBox6);
            this.tabCategoryKW.Controls.Add(this.groupBox5);
            this.tabCategoryKW.Location = new System.Drawing.Point(4, 22);
            this.tabCategoryKW.Name = "tabCategoryKW";
            this.tabCategoryKW.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategoryKW.Size = new System.Drawing.Size(372, 395);
            this.tabCategoryKW.TabIndex = 2;
            this.tabCategoryKW.Text = "Category/Keyword";
            this.tabCategoryKW.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBox2);
            this.groupBox6.Controls.Add(this.checkBoxDoNotParseCategories);
            this.groupBox6.Location = new System.Drawing.Point(7, 167);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(353, 88);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Category Scraping (Scrape a list of similar links)";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(17, 58);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(331, 23);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "Enabling this option allows you to select category links one by one";
            // 
            // checkBoxDoNotParseCategories
            // 
            this.checkBoxDoNotParseCategories.AutoSize = true;
            this.checkBoxDoNotParseCategories.Location = new System.Drawing.Point(17, 28);
            this.checkBoxDoNotParseCategories.Name = "checkBoxDoNotParseCategories";
            this.checkBoxDoNotParseCategories.Size = new System.Drawing.Size(243, 17);
            this.checkBoxDoNotParseCategories.TabIndex = 0;
            this.checkBoxDoNotParseCategories.Text = "Disable automatically identifying category links";
            this.checkBoxDoNotParseCategories.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBoxTagCategoryKW);
            this.groupBox5.Controls.Add(this.textBox3);
            this.groupBox5.Controls.Add(this.textBoxTagColName);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Location = new System.Drawing.Point(6, 26);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(354, 122);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            // 
            // checkBoxTagCategoryKW
            // 
            this.checkBoxTagCategoryKW.AutoSize = true;
            this.checkBoxTagCategoryKW.BackColor = System.Drawing.SystemColors.Window;
            this.checkBoxTagCategoryKW.Location = new System.Drawing.Point(6, 0);
            this.checkBoxTagCategoryKW.Name = "checkBoxTagCategoryKW";
            this.checkBoxTagCategoryKW.Size = new System.Drawing.Size(164, 17);
            this.checkBoxTagCategoryKW.TabIndex = 8;
            this.checkBoxTagCategoryKW.Text = "Tag with Category / Keyword";
            this.checkBoxTagCategoryKW.UseVisualStyleBackColor = false;
            this.checkBoxTagCategoryKW.CheckedChanged += new System.EventHandler(this.checkBoxTagCategoryKW_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Window;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(18, 32);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(331, 37);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "Add an extra column displaying the Category / Keyword related to the records whil" +
    "e mining, for Category & Keyword based scraping.";
            // 
            // textBoxTagColName
            // 
            this.textBoxTagColName.Location = new System.Drawing.Point(18, 87);
            this.textBoxTagColName.Name = "textBoxTagColName";
            this.textBoxTagColName.Size = new System.Drawing.Size(172, 20);
            this.textBoxTagColName.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Column Name";
            // 
            // SettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(399, 486);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WebScraper Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tabMiner.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabProxy.ResumeLayout(false);
            this.tabProxy.PerformLayout();
            this.groupBoxList.ResumeLayout(false);
            this.groupBoxList.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabCategoryKW.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }
        
        private Button buttonOK;
        private Button buttonCancel;
        private TabPage tabMiner;
        private GroupBox groupBox2;
        private TextBox textBox1;
        private Label label6;
        private TextBox textBoxPauseInterval;
        private Label label5;
        private TextBox textBoxPauseTime;
        private Label label4;
        private CheckBox checkBoxPauseMiner;
        private GroupBox groupBox1;
        private Label label3;
        private TextBox textBoxTimeout;
        private Label label2;
        private TabPage tabProxy;
        private Button buttonUp;
        private Button buttonDown;
        private GroupBox groupBoxList;
        private Label labelAddressAdd;
        private TextBox textBoxPortAdd;
        private Label labelPortAdd;
        private TextBox textBoxAddProxy;
        private Label labelInterval2;
        private Button buttonAdd;
        private Label labelInterval1;
        private TextBox textBoxInterval;
        private Button buttonRemove;
        private CheckBox checkBoxEnableProxy;
        private TabControl tabControl;
        private GroupBox groupBox3;
        private Button buttonOpenAutoSaveFile;
        private Label label9;
        private TextBox textBoxAutoSaveFileName;
        private Label label8;
        private TextBox textBoxAutoSaveNumRecords;
        private Label label7;
        private CheckBox checkBoxAutoSave;
        private CheckBox checkBoxRequiredAuth;
        private Label label11;
        private TextBox textBoxPassword;
        private Label label10;
        private TextBox textBoxUserName;
        private CheckBox checkBoxRotateProxy;
        private Label label1;
        private Label label12;
        private ListView listBoxProxy;
        private Button buttonImport;
        private ToolTip toolTip;
        private Button buttonTest;
        private TabPage tabCategoryKW;
        private TextBox textBox3;
        private Label label13;
        private TextBox textBoxTagColName;
        private GroupBox groupBox5;
        private CheckBox checkBoxTagCategoryKW;
        private Label label14;
        private TextBox textBoxAJAXWaitTime;
        private Label label15;
        private Label label17;
        private Label label16;
        private GroupBox groupBox6;
        private CheckBox checkBoxDoNotParseCategories;
        private TextBox textBox2;
        private GroupBox groupBox4;
        private CheckBox checkBoxRemoveDuplicates;
        private Button buttonAdvanced;        
        #endregion
    }
}

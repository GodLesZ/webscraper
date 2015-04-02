using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class AdvancedMinerOptionsForm  {
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
            this.comboBoxMinChildCount = new System.Windows.Forms.ComboBox();
            this.comboBoxMinLevelsUp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Minimum number of items required in a list";
            // 
            // comboBoxMinChildCount
            // 
            this.comboBoxMinChildCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMinChildCount.FormattingEnabled = true;
            this.comboBoxMinChildCount.Items.AddRange(new object[] {
            "10",
            "5",
            "3",
            "2"});
            this.comboBoxMinChildCount.Location = new System.Drawing.Point(15, 74);
            this.comboBoxMinChildCount.Name = "comboBoxMinChildCount";
            this.comboBoxMinChildCount.Size = new System.Drawing.Size(37, 21);
            this.comboBoxMinChildCount.TabIndex = 1;
            // 
            // comboBoxMinLevelsUp
            // 
            this.comboBoxMinLevelsUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMinLevelsUp.FormattingEnabled = true;
            this.comboBoxMinLevelsUp.Items.AddRange(new object[] {
            "2",
            "1"});
            this.comboBoxMinLevelsUp.Location = new System.Drawing.Point(15, 133);
            this.comboBoxMinLevelsUp.Name = "comboBoxMinLevelsUp";
            this.comboBoxMinLevelsUp.Size = new System.Drawing.Size(37, 21);
            this.comboBoxMinLevelsUp.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(315, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of levels higher in HTML DOM to search for the next item";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(252, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "&OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(326, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Warning! Change these settings only if you know what you\'re doing!";
            // 
            // AdvancedMinerOptionsForm
            // 
            this.ClientSize = new System.Drawing.Size(351, 212);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxMinLevelsUp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxMinChildCount);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvancedMinerOptionsForm";
            this.ShowIcon = false;
            this.Text = "Advanced Options";
            this.Load += new System.EventHandler(this.AdvancedMinerOptionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        private Label label1;
        private ComboBox comboBoxMinChildCount;
        private ComboBox comboBoxMinLevelsUp;
        private Label label2;
        private Button button1;
        private Label label3;
        #endregion
    }
}

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class NagForm  {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NagForm));
            this.labelEval = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelEvalLimit = new System.Windows.Forms.Label();
            this.buttonContinueEval = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.linkPurchase = new System.Windows.Forms.LinkLabel();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelEval
            // 
            this.labelEval.AutoSize = true;
            this.labelEval.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelEval.Location = new System.Drawing.Point(97, 9);
            this.labelEval.Name = "labelEval";
            this.labelEval.Size = new System.Drawing.Size(216, 13);
            this.labelEval.TabIndex = 0;
            this.labelEval.Text = "This is an evaluation version of WebScraper";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(7, 32);
            this.progressBar.Maximum = 15;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(387, 23);
            this.progressBar.TabIndex = 1;
            // 
            // labelEvalLimit
            // 
            this.labelEvalLimit.AutoSize = true;
            this.labelEvalLimit.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelEvalLimit.Location = new System.Drawing.Point(93, 67);
            this.labelEvalLimit.Name = "labelEvalLimit";
            this.labelEvalLimit.Size = new System.Drawing.Size(159, 13);
            this.labelEvalLimit.TabIndex = 2;
            this.labelEvalLimit.Text = "15 days remaining for evaluation";
            // 
            // buttonContinueEval
            // 
            this.buttonContinueEval.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonContinueEval.Location = new System.Drawing.Point(6, 15);
            this.buttonContinueEval.Name = "buttonContinueEval";
            this.buttonContinueEval.Size = new System.Drawing.Size(118, 34);
            this.buttonContinueEval.TabIndex = 0;
            this.buttonContinueEval.Text = "&Continue Evaluation";
            this.buttonContinueEval.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(272, 15);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(118, 34);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "C&lose WebScraper";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // linkPurchase
            // 
            this.linkPurchase.AutoSize = true;
            this.linkPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkPurchase.Location = new System.Drawing.Point(258, 64);
            this.linkPurchase.Name = "linkPurchase";
            this.linkPurchase.Size = new System.Drawing.Size(67, 16);
            this.linkPurchase.TabIndex = 6;
            this.linkPurchase.TabStop = true;
            this.linkPurchase.Text = "Buy Now !";
            this.linkPurchase.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPurchase_LinkClicked);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.buttonClose);
            this.groupBox.Controls.Add(this.buttonContinueEval);
            this.groupBox.Controls.Add(this.buttonRegister);
            this.groupBox.Location = new System.Drawing.Point(6, 83);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(394, 62);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.unlock;
            this.buttonRegister.Location = new System.Drawing.Point(129, 15);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(139, 34);
            this.buttonRegister.TabIndex = 1;
            this.buttonRegister.Text = "  &Unlock";
            this.buttonRegister.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRegister.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "Select WebScraper License File";
            // 
            // NagForm
            // 
            this.ClientSize = new System.Drawing.Size(408, 146);
            this.Controls.Add(this.linkPurchase);
            this.Controls.Add(this.labelEvalLimit);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelEval);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NagForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "WebScraper Evaluation";
            this.Load += new System.EventHandler(this.NagForm_Load);
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        private Label labelEval;
        private ProgressBar progressBar;
        private Label labelEvalLimit;
        private Button buttonContinueEval;
        private Button buttonRegister;
        private Button buttonClose;
        private LinkLabel linkPurchase;
        private GroupBox groupBox;
        private OpenFileDialog openFileDialog;        
        #endregion
    }
}

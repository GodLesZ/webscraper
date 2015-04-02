using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GodLesZ.Tools.WebScraper.Components {
    public partial class BrowserContainer  {
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
            this._textBoxUrl = new System.Windows.Forms.TextBox();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this._labelUrl = new System.Windows.Forms.Label();
            this._webBrowserCtrl = new System.Windows.Forms.WebBrowser();
            this._buttonRefresh = new System.Windows.Forms.Button();
            this._buttonForward = new System.Windows.Forms.Button();
            this._buttonBack = new System.Windows.Forms.Button();
            this._buttonStop = new System.Windows.Forms.Button();
            this._buttonGo = new System.Windows.Forms.Button();
            this._statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _textBoxUrl
            // 
            this._textBoxUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxUrl.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this._textBoxUrl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this._textBoxUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._textBoxUrl.Location = new System.Drawing.Point(120, 3);
            this._textBoxUrl.Name = "_textBoxUrl";
            this._textBoxUrl.Size = new System.Drawing.Size(340, 22);
            this._textBoxUrl.TabIndex = 4;
            this._textBoxUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxURL_KeyDown);
            // 
            // _statusStrip
            // 
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripStatusLabel,
            this._toolStripProgressBar});
            this._statusStrip.Location = new System.Drawing.Point(0, 261);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(539, 22);
            this._statusStrip.TabIndex = 8;
            // 
            // _toolStripStatusLabel
            // 
            this._toolStripStatusLabel.Name = "_toolStripStatusLabel";
            this._toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // _toolStripProgressBar
            // 
            this._toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._toolStripProgressBar.Name = "_toolStripProgressBar";
            this._toolStripProgressBar.Size = new System.Drawing.Size(150, 16);
            this._toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this._toolStripProgressBar.Visible = false;
            // 
            // _labelUrl
            // 
            this._labelUrl.AutoSize = true;
            this._labelUrl.Location = new System.Drawing.Point(98, 7);
            this._labelUrl.Name = "_labelUrl";
            this._labelUrl.Size = new System.Drawing.Size(20, 13);
            this._labelUrl.TabIndex = 3;
            this._labelUrl.Text = "&Url";
            // 
            // _webBrowserCtrl
            // 
            this._webBrowserCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._webBrowserCtrl.Location = new System.Drawing.Point(0, 32);
            this._webBrowserCtrl.MinimumSize = new System.Drawing.Size(20, 20);
            this._webBrowserCtrl.Name = "_webBrowserCtrl";
            this._webBrowserCtrl.Size = new System.Drawing.Size(539, 227);
            this._webBrowserCtrl.TabIndex = 7;
            this._webBrowserCtrl.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserCtrl_DocumentCompleted);
            this._webBrowserCtrl.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowserCtrl_Navigating);
            this._webBrowserCtrl.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowserCtrl_NewWindow);
            // 
            // _buttonRefresh
            // 
            this._buttonRefresh.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.refresh;
            this._buttonRefresh.Location = new System.Drawing.Point(65, 3);
            this._buttonRefresh.Name = "_buttonRefresh";
            this._buttonRefresh.Size = new System.Drawing.Size(29, 23);
            this._buttonRefresh.TabIndex = 2;
            this._buttonRefresh.UseVisualStyleBackColor = true;
            this._buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // _buttonForward
            // 
            this._buttonForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._buttonForward.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.icon_forward_arrow_16;
            this._buttonForward.Location = new System.Drawing.Point(34, 3);
            this._buttonForward.Name = "_buttonForward";
            this._buttonForward.Size = new System.Drawing.Size(29, 23);
            this._buttonForward.TabIndex = 1;
            this._buttonForward.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._buttonForward.UseVisualStyleBackColor = true;
            this._buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
            // 
            // _buttonBack
            // 
            this._buttonBack.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.icon_back_arrow_16;
            this._buttonBack.Location = new System.Drawing.Point(3, 3);
            this._buttonBack.Name = "_buttonBack";
            this._buttonBack.Size = new System.Drawing.Size(29, 23);
            this._buttonBack.TabIndex = 0;
            this._buttonBack.UseVisualStyleBackColor = true;
            this._buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // _buttonStop
            // 
            this._buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonStop.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.delete;
            this._buttonStop.Location = new System.Drawing.Point(497, 3);
            this._buttonStop.Name = "_buttonStop";
            this._buttonStop.Size = new System.Drawing.Size(29, 23);
            this._buttonStop.TabIndex = 6;
            this._buttonStop.UseVisualStyleBackColor = true;
            this._buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // _buttonGo
            // 
            this._buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonGo.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.play;
            this._buttonGo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._buttonGo.Location = new System.Drawing.Point(466, 3);
            this._buttonGo.Name = "_buttonGo";
            this._buttonGo.Size = new System.Drawing.Size(29, 23);
            this._buttonGo.TabIndex = 5;
            this._buttonGo.UseVisualStyleBackColor = true;
            this._buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // BrowserContainer
            // 
            this.ClientSize = new System.Drawing.Size(539, 283);
            this.Controls.Add(this._labelUrl);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._buttonRefresh);
            this.Controls.Add(this._buttonForward);
            this.Controls.Add(this._buttonBack);
            this.Controls.Add(this._buttonStop);
            this.Controls.Add(this._buttonGo);
            this.Controls.Add(this._textBoxUrl);
            this.Controls.Add(this._webBrowserCtrl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BrowserContainer";
            this.Text = "BrowserContainer";
            this.Load += new System.EventHandler(this.BrowserContainer_Load);
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private WebBrowser _webBrowserCtrl;
        private TextBox _textBoxUrl;
        private Button _buttonGo;
        private Button _buttonStop;
        private Button _buttonBack;
        private Button _buttonForward;
        private Button _buttonRefresh;
        private StatusStrip _statusStrip;
        private ToolStripStatusLabel _toolStripStatusLabel;
        private Label _labelUrl;
        private ToolStripProgressBar _toolStripProgressBar;

        #endregion
    }
}

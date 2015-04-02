using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class CaptureForm  {
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
            this.textBoxCaptureText = new System.Windows.Forms.TextBox();
            this.toolTipControl = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStripOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.captureFollowingTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureHTMLOfItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureTextAsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyRegularExpressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureParentElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsshowMoreResultsLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripImgOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureImageURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCaptureImage = new System.Windows.Forms.Button();
            this.buttonMoreOptions = new System.Windows.Forms.Button();
            this.buttonCaptureLink = new System.Windows.Forms.Button();
            this.buttonCaptureItemText = new System.Windows.Forms.Button();
            this.buttonFollowLink = new System.Windows.Forms.Button();
            this.buttonSetNextPageLink = new System.Windows.Forms.Button();
            this.contextMenuStripOptions.SuspendLayout();
            this.contextMenuStripImgOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCaptureText
            // 
            this.textBoxCaptureText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCaptureText.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxCaptureText.Location = new System.Drawing.Point(12, 12);
            this.textBoxCaptureText.Multiline = true;
            this.textBoxCaptureText.Name = "textBoxCaptureText";
            this.textBoxCaptureText.ReadOnly = true;
            this.textBoxCaptureText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCaptureText.Size = new System.Drawing.Size(348, 144);
            this.textBoxCaptureText.TabIndex = 3;
            // 
            // toolTipControl
            // 
            this.toolTipControl.AutoPopDelay = 5000;
            this.toolTipControl.InitialDelay = 100;
            this.toolTipControl.ReshowDelay = 100;
            // 
            // contextMenuStripOptions
            // 
            this.contextMenuStripOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureFollowingTextToolStripMenuItem,
            this.captureHTMLOfItemToolStripMenuItem,
            this.captureTextAsFileToolStripMenuItem,
            this.clickToolStripMenuItem,
            this.applyRegularExpressionToolStripMenuItem,
            this.captureParentElementToolStripMenuItem,
            this.setAsshowMoreResultsLinkToolStripMenuItem});
            this.contextMenuStripOptions.Name = "contextMenuStripOptions";
            this.contextMenuStripOptions.Size = new System.Drawing.Size(249, 158);
            // 
            // captureFollowingTextToolStripMenuItem
            // 
            this.captureFollowingTextToolStripMenuItem.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.text_letter_t;
            this.captureFollowingTextToolStripMenuItem.Name = "captureFollowingTextToolStripMenuItem";
            this.captureFollowingTextToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.captureFollowingTextToolStripMenuItem.Text = "Capture following &Text";
            this.captureFollowingTextToolStripMenuItem.Click += new System.EventHandler(this.captureFollowingTextToolStripMenuItem_Click);
            // 
            // captureHTMLOfItemToolStripMenuItem
            // 
            this.captureHTMLOfItemToolStripMenuItem.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.html;
            this.captureHTMLOfItemToolStripMenuItem.Name = "captureHTMLOfItemToolStripMenuItem";
            this.captureHTMLOfItemToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.captureHTMLOfItemToolStripMenuItem.Text = "Capture &HTML";
            this.captureHTMLOfItemToolStripMenuItem.Click += new System.EventHandler(this.captureHTMLOfItemToolStripMenuItem_Click);
            // 
            // captureTextAsFileToolStripMenuItem
            // 
            this.captureTextAsFileToolStripMenuItem.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.administrative_docs;
            this.captureTextAsFileToolStripMenuItem.Name = "captureTextAsFileToolStripMenuItem";
            this.captureTextAsFileToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.captureTextAsFileToolStripMenuItem.Text = "Capture Text as &File";
            this.captureTextAsFileToolStripMenuItem.Click += new System.EventHandler(this.captureTextAsFileToolStripMenuItem_Click);
            // 
            // clickToolStripMenuItem
            // 
            this.clickToolStripMenuItem.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.click;
            this.clickToolStripMenuItem.Name = "clickToolStripMenuItem";
            this.clickToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.clickToolStripMenuItem.Text = "Click";
            this.clickToolStripMenuItem.Click += new System.EventHandler(this.clickToolStripMenuItem_Click);
            // 
            // applyRegularExpressionToolStripMenuItem
            // 
            this.applyRegularExpressionToolStripMenuItem.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.regex;
            this.applyRegularExpressionToolStripMenuItem.Name = "applyRegularExpressionToolStripMenuItem";
            this.applyRegularExpressionToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.applyRegularExpressionToolStripMenuItem.Text = "Apply Regular Expression";
            this.applyRegularExpressionToolStripMenuItem.Click += new System.EventHandler(this.applyRegularExpressionToolStripMenuItem_Click);
            // 
            // captureParentElementToolStripMenuItem
            // 
            this.captureParentElementToolStripMenuItem.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.captureparent;
            this.captureParentElementToolStripMenuItem.Name = "captureParentElementToolStripMenuItem";
            this.captureParentElementToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.captureParentElementToolStripMenuItem.Text = "Capture More Content";
            this.captureParentElementToolStripMenuItem.Click += new System.EventHandler(this.captureParentElementToolStripMenuItem_Click);
            // 
            // setAsshowMoreResultsLinkToolStripMenuItem
            // 
            this.setAsshowMoreResultsLinkToolStripMenuItem.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.loadmore;
            this.setAsshowMoreResultsLinkToolStripMenuItem.Name = "setAsshowMoreResultsLinkToolStripMenuItem";
            this.setAsshowMoreResultsLinkToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.setAsshowMoreResultsLinkToolStripMenuItem.Text = "Set as \'show/load more data\' link";
            this.setAsshowMoreResultsLinkToolStripMenuItem.Click += new System.EventHandler(this.setAsShowMoreResultsLinkToolStripMenuItem_Click);
            // 
            // contextMenuStripImgOptions
            // 
            this.contextMenuStripImgOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadImageToolStripMenuItem,
            this.captureImageURLToolStripMenuItem});
            this.contextMenuStripImgOptions.Name = "contextMenuStripImgOptions";
            this.contextMenuStripImgOptions.ShowItemToolTips = false;
            this.contextMenuStripImgOptions.Size = new System.Drawing.Size(177, 48);
            // 
            // downloadImageToolStripMenuItem
            // 
            this.downloadImageToolStripMenuItem.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.download;
            this.downloadImageToolStripMenuItem.Name = "downloadImageToolStripMenuItem";
            this.downloadImageToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.downloadImageToolStripMenuItem.Text = "&Download Image";
            this.downloadImageToolStripMenuItem.Click += new System.EventHandler(this.downloadImageToolStripMenuItem_Click);
            // 
            // captureImageURLToolStripMenuItem
            // 
            this.captureImageURLToolStripMenuItem.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.link;
            this.captureImageURLToolStripMenuItem.Name = "captureImageURLToolStripMenuItem";
            this.captureImageURLToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.captureImageURLToolStripMenuItem.Text = "&Capture Image URL";
            this.captureImageURLToolStripMenuItem.Click += new System.EventHandler(this.captureImageURLToolStripMenuItem_Click);
            // 
            // buttonCaptureImage
            // 
            this.buttonCaptureImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCaptureImage.ContextMenuStrip = this.contextMenuStripImgOptions;
            this.buttonCaptureImage.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.image;
            this.buttonCaptureImage.Location = new System.Drawing.Point(12, 252);
            this.buttonCaptureImage.Name = "buttonCaptureImage";
            this.buttonCaptureImage.Size = new System.Drawing.Size(171, 40);
            this.buttonCaptureImage.TabIndex = 5;
            this.buttonCaptureImage.Text = " Capture &Image";
            this.buttonCaptureImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCaptureImage.UseVisualStyleBackColor = true;
            this.buttonCaptureImage.Click += new System.EventHandler(this.buttonCaptureImage_Click);
            // 
            // buttonMoreOptions
            // 
            this.buttonMoreOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMoreOptions.ContextMenuStrip = this.contextMenuStripOptions;
            this.buttonMoreOptions.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.options;
            this.buttonMoreOptions.Location = new System.Drawing.Point(189, 252);
            this.buttonMoreOptions.Name = "buttonMoreOptions";
            this.buttonMoreOptions.Size = new System.Drawing.Size(171, 40);
            this.buttonMoreOptions.TabIndex = 9;
            this.buttonMoreOptions.Text = " More Options";
            this.buttonMoreOptions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonMoreOptions.UseVisualStyleBackColor = true;
            this.buttonMoreOptions.Click += new System.EventHandler(this.buttonMoreOptions_Click);
            // 
            // buttonCaptureLink
            // 
            this.buttonCaptureLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCaptureLink.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.link;
            this.buttonCaptureLink.Location = new System.Drawing.Point(12, 206);
            this.buttonCaptureLink.Name = "buttonCaptureLink";
            this.buttonCaptureLink.Size = new System.Drawing.Size(171, 40);
            this.buttonCaptureLink.TabIndex = 4;
            this.buttonCaptureLink.Text = " Capture target &URL";
            this.buttonCaptureLink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCaptureLink.UseVisualStyleBackColor = true;
            this.buttonCaptureLink.Click += new System.EventHandler(this.buttonCaptureLink_Click);
            // 
            // buttonCaptureItemText
            // 
            this.buttonCaptureItemText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCaptureItemText.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.text_letter_t;
            this.buttonCaptureItemText.Location = new System.Drawing.Point(12, 162);
            this.buttonCaptureItemText.Name = "buttonCaptureItemText";
            this.buttonCaptureItemText.Size = new System.Drawing.Size(171, 40);
            this.buttonCaptureItemText.TabIndex = 0;
            this.buttonCaptureItemText.Text = " &Capture Text";
            this.buttonCaptureItemText.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCaptureItemText.UseVisualStyleBackColor = true;
            this.buttonCaptureItemText.Click += new System.EventHandler(this.buttonCaptureItemText_Click);
            // 
            // buttonFollowLink
            // 
            this.buttonFollowLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFollowLink.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.go_jump;
            this.buttonFollowLink.Location = new System.Drawing.Point(189, 162);
            this.buttonFollowLink.Name = "buttonFollowLink";
            this.buttonFollowLink.Size = new System.Drawing.Size(171, 40);
            this.buttonFollowLink.TabIndex = 1;
            this.buttonFollowLink.Text = " &Follow this link";
            this.buttonFollowLink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonFollowLink.UseVisualStyleBackColor = true;
            this.buttonFollowLink.Click += new System.EventHandler(this.buttonFollowLink_Click);
            // 
            // buttonSetNextPageLink
            // 
            this.buttonSetNextPageLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetNextPageLink.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.administrative_docs;
            this.buttonSetNextPageLink.Location = new System.Drawing.Point(189, 208);
            this.buttonSetNextPageLink.Name = "buttonSetNextPageLink";
            this.buttonSetNextPageLink.Size = new System.Drawing.Size(171, 40);
            this.buttonSetNextPageLink.TabIndex = 2;
            this.buttonSetNextPageLink.Text = " Set as &Next Page link";
            this.buttonSetNextPageLink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSetNextPageLink.UseVisualStyleBackColor = true;
            this.buttonSetNextPageLink.Click += new System.EventHandler(this.buttonSetNextPageLink_Click);
            // 
            // CaptureForm
            // 
            this.ClientSize = new System.Drawing.Size(372, 307);
            this.Controls.Add(this.buttonCaptureImage);
            this.Controls.Add(this.buttonMoreOptions);
            this.Controls.Add(this.buttonCaptureLink);
            this.Controls.Add(this.buttonCaptureItemText);
            this.Controls.Add(this.buttonFollowLink);
            this.Controls.Add(this.textBoxCaptureText);
            this.Controls.Add(this.buttonSetNextPageLink);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaptureForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Capture";
            this.Shown += new System.EventHandler(this.CaptureForm_Shown);
            this.contextMenuStripOptions.ResumeLayout(false);
            this.contextMenuStripImgOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button buttonSetNextPageLink;
        private TextBox textBoxCaptureText;
        private Button buttonFollowLink;
        private Button buttonCaptureItemText;
        private Button buttonCaptureLink;
        private Button buttonCaptureImage;
        private ToolTip toolTipControl;
        private Button buttonMoreOptions;
        private ContextMenuStrip contextMenuStripOptions;
        private ToolStripMenuItem captureFollowingTextToolStripMenuItem;
        private ToolStripMenuItem captureHTMLOfItemToolStripMenuItem;
        private ToolStripMenuItem captureTextAsFileToolStripMenuItem;
        private ToolStripMenuItem clickToolStripMenuItem;
        private ToolStripMenuItem applyRegularExpressionToolStripMenuItem;
        private ToolStripMenuItem captureParentElementToolStripMenuItem;
        private ToolStripMenuItem setAsshowMoreResultsLinkToolStripMenuItem;
        private ContextMenuStrip contextMenuStripImgOptions;
        private ToolStripMenuItem downloadImageToolStripMenuItem;
        private ToolStripMenuItem captureImageURLToolStripMenuItem;

        #endregion
    }
}

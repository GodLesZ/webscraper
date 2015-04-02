using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class TestProxyForm  {
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
    private void InitializeComponent()
    {
      labelInfo = new Label();
      buttonCancel = new Button();
      labelProgress = new Label();
      SuspendLayout();
      labelInfo.AutoSize = true;
      labelInfo.Location = new Point(25, 25);
      labelInfo.Name = "labelInfo";
      labelInfo.Size = new Size(183, 13);
      labelInfo.TabIndex = 0;
      labelInfo.Text = "Please wait while proxies are tested ..";
      buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      buttonCancel.Location = new Point(97, 62);
      buttonCancel.Name = "buttonCancel";
      buttonCancel.Size = new Size(90, 31);
      buttonCancel.TabIndex = 1;
      buttonCancel.Text = "&Cancel";
      buttonCancel.UseVisualStyleBackColor = true;
      labelProgress.AutoSize = true;
      labelProgress.Location = new Point(214, 25);
      labelProgress.Name = "labelProgress";
      labelProgress.Size = new Size(46, 13);
      labelProgress.TabIndex = 2;
      labelProgress.Text = "(1 of 10)";
      ClientSize = new Size(284, 99);
      Controls.Add(labelProgress);
      Controls.Add(buttonCancel);
      Controls.Add(labelInfo);
      FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "TestProxyForm";
      ShowIcon = false;
      Text = "Testing Proxy Servers";
      ResumeLayout(false);
      PerformLayout();
    }
    private Label labelInfo;
    private Button buttonCancel;
    private Label labelProgress;

        #endregion
    }
}

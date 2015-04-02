using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class RegExForm  {
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
      textBoxRegEx = new TextBox();
      label1 = new Label();
      buttonApply = new Button();
      SuspendLayout();
      textBoxRegEx.Location = new Point(50, 19);
      textBoxRegEx.Name = "textBoxRegEx";
      textBoxRegEx.Size = new Size(301, 20);
      textBoxRegEx.TabIndex = 0;
      label1.AutoSize = true;
      label1.Location = new Point(5, 22);
      label1.Name = "label1";
      label1.Size = new Size(39, 13);
      label1.TabIndex = 1;
      label1.Text = "RegEx";
      buttonApply.DialogResult = System.Windows.Forms.DialogResult.OK;
      buttonApply.Location = new Point(268, 45);
      buttonApply.Name = "buttonApply";
      buttonApply.Size = new Size(83, 29);
      buttonApply.TabIndex = 2;
      buttonApply.Text = "Apply";
      buttonApply.UseVisualStyleBackColor = true;
      ClientSize = new Size(360, 84);
      Controls.Add(buttonApply);
      Controls.Add(label1);
      Controls.Add(textBoxRegEx);
      FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "RegExForm";
      ShowIcon = false;
      SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      Text = "Apply Regular Expression";
      ResumeLayout(false);
      PerformLayout();
    }
            
        private TextBox textBoxRegEx;
        private Label label1;
        private Button buttonApply;        
        #endregion
    }
}

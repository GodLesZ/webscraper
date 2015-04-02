using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class PreviewForm  {
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
            components = new Container();
            listPreview = new ListView();
            contextMenuStrip = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            listPreview.BackColor = SystemColors.Info;
            listPreview.ContextMenuStrip = contextMenuStrip;
            listPreview.Dock = DockStyle.Fill;
            listPreview.FullRowSelect = true;
            listPreview.GridLines = true;
            listPreview.Location = new Point(0, 0);
            listPreview.Name = "listPreview";
            listPreview.Size = new Size(700, 384);
            listPreview.TabIndex = 0;
            listPreview.UseCompatibleStateImageBehavior = false;
            listPreview.View = View.Details;
            listPreview.ColumnWidthChanging += new ColumnWidthChangingEventHandler(listPreview_ColumnWidthChanging);
            contextMenuStrip.Items.AddRange(new ToolStripItem[2]
      {
        deleteToolStripMenuItem,
        toolStripMenuItem1
      });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(147, 48);
            contextMenuStrip.Opening += new CancelEventHandler(contextMenuStrip_Opening);
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(146, 22);
            deleteToolStripMenuItem.Text = "Delete";
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(146, 22);
            toolStripMenuItem1.Text = "Copy Preview";
            ClientSize = new Size(700, 384);
            CloseButton = false;
            CloseButtonVisible = false;
            Controls.Add(listPreview);
            Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "PreviewForm";
            Text = "Captured Data Preview";
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }
        
        private ListView listPreview;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;        
        #endregion
    }
}

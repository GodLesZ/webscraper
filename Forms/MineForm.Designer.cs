using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GodLesZ.Tools.WebScraper.Components;

namespace GodLesZ.Tools.WebScraper.Forms {
    public partial class MineForm  {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MineForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.progressBarMine = new System.Windows.Forms.ProgressBar();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus = new GodLesZ.Tools.WebScraper.Components.ToolStripSpringTextBox();
            this.checkBoxMineTillEnd = new System.Windows.Forms.CheckBox();
            this.labelNumPages = new System.Windows.Forms.Label();
            this.groupBoxMinePager = new System.Windows.Forms.GroupBox();
            this.textBoxNumPages = new System.Windows.Forms.TextBox();
            this.exportMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonPauseResume = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.checkBoxAutoScroll = new System.Windows.Forms.CheckBox();
            this.buttonExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.groupBoxMinePager.SuspendLayout();
            this.exportMenuStrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 11);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(779, 247);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView_RowPostPaint);
            // 
            // progressBarMine
            // 
            this.progressBarMine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarMine.Location = new System.Drawing.Point(12, 294);
            this.progressBarMine.Name = "progressBarMine";
            this.progressBarMine.Size = new System.Drawing.Size(179, 23);
            this.progressBarMine.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarMine.TabIndex = 5;
            this.progressBarMine.Visible = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 342);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(803, 23);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.ReadOnly = true;
            this.toolStripStatus.Size = new System.Drawing.Size(755, 23);
            // 
            // checkBoxMineTillEnd
            // 
            this.checkBoxMineTillEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxMineTillEnd.AutoSize = true;
            this.checkBoxMineTillEnd.Location = new System.Drawing.Point(6, -1);
            this.checkBoxMineTillEnd.Name = "checkBoxMineTillEnd";
            this.checkBoxMineTillEnd.Size = new System.Drawing.Size(94, 17);
            this.checkBoxMineTillEnd.TabIndex = 0;
            this.checkBoxMineTillEnd.Text = "Mine all pages";
            this.checkBoxMineTillEnd.UseVisualStyleBackColor = true;
            this.checkBoxMineTillEnd.CheckedChanged += new System.EventHandler(this.checkBoxMineTillEnd_CheckedChanged);
            this.checkBoxMineTillEnd.Click += new System.EventHandler(this.checkBoxMineTillEnd_Click);
            // 
            // labelNumPages
            // 
            this.labelNumPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNumPages.AutoSize = true;
            this.labelNumPages.Location = new System.Drawing.Point(13, 25);
            this.labelNumPages.Name = "labelNumPages";
            this.labelNumPages.Size = new System.Drawing.Size(128, 13);
            this.labelNumPages.TabIndex = 1;
            this.labelNumPages.Text = "Number of pages to mine ";
            // 
            // groupBoxMinePager
            // 
            this.groupBoxMinePager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMinePager.Controls.Add(this.textBoxNumPages);
            this.groupBoxMinePager.Controls.Add(this.labelNumPages);
            this.groupBoxMinePager.Controls.Add(this.checkBoxMineTillEnd);
            this.groupBoxMinePager.Location = new System.Drawing.Point(214, 272);
            this.groupBoxMinePager.Name = "groupBoxMinePager";
            this.groupBoxMinePager.Size = new System.Drawing.Size(190, 58);
            this.groupBoxMinePager.TabIndex = 4;
            this.groupBoxMinePager.TabStop = false;
            // 
            // textBoxNumPages
            // 
            this.textBoxNumPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNumPages.Location = new System.Drawing.Point(147, 22);
            this.textBoxNumPages.Name = "textBoxNumPages";
            this.textBoxNumPages.Size = new System.Drawing.Size(29, 20);
            this.textBoxNumPages.TabIndex = 2;
            this.textBoxNumPages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumPages_KeyPress);
            // 
            // exportMenuStrip
            // 
            this.exportMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemDatabase});
            this.exportMenuStrip.Name = "exportMenuStrip";
            this.exportMenuStrip.Size = new System.Drawing.Size(173, 48);
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItemFile.Text = "Export as File";
            this.toolStripMenuItemFile.ToolTipText = "XML / CSV / JSON / TSV";
            this.toolStripMenuItemFile.Click += new System.EventHandler(this.toolStripMenuItemFile_Click);
            // 
            // toolStripMenuItemDatabase
            // 
            this.toolStripMenuItemDatabase.Name = "toolStripMenuItemDatabase";
            this.toolStripMenuItemDatabase.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItemDatabase.Text = "Export to Database";
            this.toolStripMenuItemDatabase.Click += new System.EventHandler(this.toolStripMenuItemDatabase_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.buttonPauseResume);
            this.groupBox2.Controls.Add(this.buttonStop);
            this.groupBox2.Controls.Add(this.buttonStart);
            this.groupBox2.Location = new System.Drawing.Point(410, 272);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 58);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // buttonPauseResume
            // 
            this.buttonPauseResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPauseResume.Image = ((System.Drawing.Image)(resources.GetObject("buttonPauseResume.Image")));
            this.buttonPauseResume.Location = new System.Drawing.Point(100, 13);
            this.buttonPauseResume.Name = "buttonPauseResume";
            this.buttonPauseResume.Size = new System.Drawing.Size(81, 33);
            this.buttonPauseResume.TabIndex = 3;
            this.buttonPauseResume.Text = " &Pause";
            this.buttonPauseResume.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPauseResume.UseVisualStyleBackColor = true;
            this.buttonPauseResume.Click += new System.EventHandler(this.buttonPauseResume_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.stop;
            this.buttonStop.Location = new System.Drawing.Point(187, 13);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(81, 33);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = " S&top";
            this.buttonStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.play;
            this.buttonStart.Location = new System.Drawing.Point(13, 14);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(81, 33);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "&Start";
            this.buttonStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // checkBoxAutoScroll
            // 
            this.checkBoxAutoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAutoScroll.AutoSize = true;
            this.checkBoxAutoScroll.Location = new System.Drawing.Point(12, 260);
            this.checkBoxAutoScroll.Name = "checkBoxAutoScroll";
            this.checkBoxAutoScroll.Size = new System.Drawing.Size(134, 17);
            this.checkBoxAutoScroll.TabIndex = 6;
            this.checkBoxAutoScroll.Text = "Auto scroll above table";
            this.checkBoxAutoScroll.UseVisualStyleBackColor = true;
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.ContextMenuStrip = this.exportMenuStrip;
            this.buttonExport.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.ico_export;
            this.buttonExport.Location = new System.Drawing.Point(696, 285);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(95, 33);
            this.buttonExport.TabIndex = 3;
            this.buttonExport.Text = "&Export";
            this.buttonExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // MineForm
            // 
            this.ClientSize = new System.Drawing.Size(803, 365);
            this.Controls.Add(this.checkBoxAutoScroll);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.groupBoxMinePager);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.progressBarMine);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.groupBox2);
            this.Name = "MineForm";
            this.ShowIcon = false;
            this.Text = "WebScraper Miner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MineForm_FormClosing);
            this.Load += new System.EventHandler(this.MineForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBoxMinePager.ResumeLayout(false);
            this.groupBoxMinePager.PerformLayout();
            this.exportMenuStrip.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private DataGridView dataGridView;
        private Button buttonStart;
        private Button buttonStop;
        private ProgressBar progressBarMine;
        private StatusStrip statusStrip;
        private CheckBox checkBoxMineTillEnd;
        private Label labelNumPages;
        private GroupBox groupBoxMinePager;
        private Button buttonExport;
        private GroupBox groupBox2;
        private TextBox textBoxNumPages;
        private ToolStripSpringTextBox toolStripStatus;
        private ContextMenuStrip exportMenuStrip;
        private ToolStripMenuItem toolStripMenuItemFile;
        private ToolStripMenuItem toolStripMenuItemDatabase;
        private CheckBox checkBoxAutoScroll;
        private Button buttonPauseResume;        
        #endregion
    }
}

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace GodLesZ.Tools.WebScraper.Forms {
    partial class MainForm {
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
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonStartConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStopConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonMine = new System.Windows.Forms.ToolStripButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripButtonOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuStripButtonSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addURLsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editKeywordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editStartURLPostDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.autoScrollToLoadMoreDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.disablePatternDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripButtonStartConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripButtonStopConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStripButtonSelectSections = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripButtonInputKeywords = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStripButtonStartMine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.schedulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dockPanel
            // 
            this._dockPanel.ActiveAutoHideContent = null;
            this._dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dockPanel.DockBackColor = System.Drawing.SystemColors.AppWorkspace;
            this._dockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingSdi;
            this._dockPanel.Location = new System.Drawing.Point(0, 0);
            this._dockPanel.Name = "_dockPanel";
            this._dockPanel.Size = new System.Drawing.Size(640, 352);
            dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.SystemColors.Control;
            tabGradient1.StartColor = System.Drawing.SystemColors.Control;
            tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin1.TabGradient = tabGradient1;
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.SystemColors.Control;
            tabGradient5.StartColor = System.Drawing.SystemColors.Control;
            tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.Color.Transparent;
            tabGradient7.StartColor = System.Drawing.Color.Transparent;
            tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this._dockPanel.Skin = dockPanelSkin1;
            this._dockPanel.TabIndex = 1;
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripButtonSave,
            this.toolStripSeparator7,
            this.toolStripButtonStartConfig,
            this.toolStripButtonStopConfig,
            this.toolStripSeparator6,
            this.toolStripButtonMine});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(640, 31);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.folder;
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(64, 28);
            this.toolStripButtonOpen.Text = "Open";
            this.toolStripButtonOpen.ToolTipText = "Open configuration";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.disk_blue;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(59, 28);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.ToolTipText = "Save configuration";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButtonStartConfig
            // 
            this.toolStripButtonStartConfig.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.gear_run;
            this.toolStripButtonStartConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStartConfig.Name = "toolStripButtonStartConfig";
            this.toolStripButtonStartConfig.Size = new System.Drawing.Size(98, 28);
            this.toolStripButtonStartConfig.Text = "Start Config";
            this.toolStripButtonStartConfig.ToolTipText = "Start configuration. Click this after you have navigated to the page which contai" +
    "ns the data to be scraped.";
            this.toolStripButtonStartConfig.Click += new System.EventHandler(this.toolStripButtonStartConfig_Click);
            // 
            // toolStripButtonStopConfig
            // 
            this.toolStripButtonStopConfig.Enabled = false;
            this.toolStripButtonStopConfig.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.gear_stop;
            this.toolStripButtonStopConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStopConfig.Name = "toolStripButtonStopConfig";
            this.toolStripButtonStopConfig.Size = new System.Drawing.Size(98, 28);
            this.toolStripButtonStopConfig.Text = "Stop Config";
            this.toolStripButtonStopConfig.ToolTipText = "Stop Configuration";
            this.toolStripButtonStopConfig.Click += new System.EventHandler(this.toolStripButtonStopConfig_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButtonMine
            // 
            this.toolStripButtonMine.Enabled = false;
            this.toolStripButtonMine.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.document_ok;
            this.toolStripButtonMine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMine.Name = "toolStripButtonMine";
            this.toolStripButtonMine.Size = new System.Drawing.Size(89, 28);
            this.toolStripButtonMine.Text = "Start Mine";
            this.toolStripButtonMine.ToolTipText = "Start Mining Data";
            this.toolStripButtonMine.Click += new System.EventHandler(this.toolStripButtonMine_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(640, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripButtonOpen,
            this.toolStripSeparator,
            this.menuStripButtonSave,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // menuStripButtonOpen
            // 
            this.menuStripButtonOpen.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.folder;
            this.menuStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuStripButtonOpen.Name = "menuStripButtonOpen";
            this.menuStripButtonOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuStripButtonOpen.Size = new System.Drawing.Size(146, 22);
            this.menuStripButtonOpen.Text = "&Open";
            this.menuStripButtonOpen.ToolTipText = "Open configuration";
            this.menuStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // menuStripButtonSave
            // 
            this.menuStripButtonSave.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.disk_blue;
            this.menuStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuStripButtonSave.Name = "menuStripButtonSave";
            this.menuStripButtonSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuStripButtonSave.Size = new System.Drawing.Size(146, 22);
            this.menuStripButtonSave.Text = "&Save";
            this.menuStripButtonSave.ToolTipText = "Save configuration";
            this.menuStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editConfigToolStripMenuItem,
            this.editOptionsToolStripMenuItem,
            this.toolStripSeparator9,
            this.clearToolStripMenuItem,
            this.toolStripSeparator2,
            this.settingsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // editConfigToolStripMenuItem
            // 
            this.editConfigToolStripMenuItem.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.pencil;
            this.editConfigToolStripMenuItem.Name = "editConfigToolStripMenuItem";
            this.editConfigToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.editConfigToolStripMenuItem.Text = "&Edit Configuration";
            this.editConfigToolStripMenuItem.Click += new System.EventHandler(this.editConfigToolStripMenuItem_Click);
            // 
            // editOptionsToolStripMenuItem
            // 
            this.editOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addURLsToolStripMenuItem,
            this.editKeywordsToolStripMenuItem,
            this.editStartURLPostDataToolStripMenuItem,
            this.toolStripSeparator10,
            this.autoScrollToLoadMoreDataToolStripMenuItem,
            this.toolStripSeparator11,
            this.disablePatternDetectionToolStripMenuItem});
            this.editOptionsToolStripMenuItem.Enabled = false;
            this.editOptionsToolStripMenuItem.Name = "editOptionsToolStripMenuItem";
            this.editOptionsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.editOptionsToolStripMenuItem.Text = "Edit Options";
            // 
            // addURLsToolStripMenuItem
            // 
            this.addURLsToolStripMenuItem.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.add2;
            this.addURLsToolStripMenuItem.Name = "addURLsToolStripMenuItem";
            this.addURLsToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.addURLsToolStripMenuItem.Text = "&Add/Remove URLs from Configuration";
            this.addURLsToolStripMenuItem.Click += new System.EventHandler(this.addURLsToolStripMenuItem_Click);
            // 
            // editKeywordsToolStripMenuItem
            // 
            this.editKeywordsToolStripMenuItem.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.key1_preferences;
            this.editKeywordsToolStripMenuItem.Name = "editKeywordsToolStripMenuItem";
            this.editKeywordsToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.editKeywordsToolStripMenuItem.Text = "Edit &Keywords";
            this.editKeywordsToolStripMenuItem.Click += new System.EventHandler(this.editKeywordsToolStripMenuItem_Click);
            // 
            // editStartURLPostDataToolStripMenuItem
            // 
            this.editStartURLPostDataToolStripMenuItem.Name = "editStartURLPostDataToolStripMenuItem";
            this.editStartURLPostDataToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.editStartURLPostDataToolStripMenuItem.Text = "Edit &Start URL / PostData";
            this.editStartURLPostDataToolStripMenuItem.Click += new System.EventHandler(this.editStartURLPostDataToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(276, 6);
            // 
            // autoScrollToLoadMoreDataToolStripMenuItem
            // 
            this.autoScrollToLoadMoreDataToolStripMenuItem.CheckOnClick = true;
            this.autoScrollToLoadMoreDataToolStripMenuItem.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.arrow_down_green;
            this.autoScrollToLoadMoreDataToolStripMenuItem.Name = "autoScrollToLoadMoreDataToolStripMenuItem";
            this.autoScrollToLoadMoreDataToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.autoScrollToLoadMoreDataToolStripMenuItem.Text = "Scroll &down to load next page";
            this.autoScrollToLoadMoreDataToolStripMenuItem.Click += new System.EventHandler(this.autoScrollToLoadMoreDataToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(276, 6);
            // 
            // disablePatternDetectionToolStripMenuItem
            // 
            this.disablePatternDetectionToolStripMenuItem.CheckOnClick = true;
            this.disablePatternDetectionToolStripMenuItem.Name = "disablePatternDetectionToolStripMenuItem";
            this.disablePatternDetectionToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.disablePatternDetectionToolStripMenuItem.Text = "Disable start-page pattern detection";
            this.disablePatternDetectionToolStripMenuItem.Click += new System.EventHandler(this.disablePatternDetectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(168, 6);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.delete2;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.clearToolStripMenuItem.Text = "&Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(168, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.gear;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.settingsToolStripMenuItem.Text = "&Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripButtonStartConfig,
            this.menuStripButtonStopConfig,
            this.toolStripSeparator1,
            this.menuStripButtonSelectSections,
            this.menuStripButtonInputKeywords,
            this.toolStripSeparator8,
            this.menuStripButtonStartMine,
            this.toolStripSeparator3,
            this.schedulerToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Mine";
            // 
            // menuStripButtonStartConfig
            // 
            this.menuStripButtonStartConfig.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.gear_run;
            this.menuStripButtonStartConfig.Name = "menuStripButtonStartConfig";
            this.menuStripButtonStartConfig.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.menuStripButtonStartConfig.Size = new System.Drawing.Size(255, 22);
            this.menuStripButtonStartConfig.Text = "&Start Config";
            this.menuStripButtonStartConfig.Click += new System.EventHandler(this.toolStripButtonStartConfig_Click);
            // 
            // menuStripButtonStopConfig
            // 
            this.menuStripButtonStopConfig.Enabled = false;
            this.menuStripButtonStopConfig.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.gear_stop;
            this.menuStripButtonStopConfig.Name = "menuStripButtonStopConfig";
            this.menuStripButtonStopConfig.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.menuStripButtonStopConfig.Size = new System.Drawing.Size(255, 22);
            this.menuStripButtonStopConfig.Text = "S&top Config";
            this.menuStripButtonStopConfig.Click += new System.EventHandler(this.toolStripButtonStopConfig_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(252, 6);
            // 
            // menuStripButtonSelectSections
            // 
            this.menuStripButtonSelectSections.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.gears_run;
            this.menuStripButtonSelectSections.Name = "menuStripButtonSelectSections";
            this.menuStripButtonSelectSections.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.menuStripButtonSelectSections.Size = new System.Drawing.Size(255, 22);
            this.menuStripButtonSelectSections.Text = "Scrape a &list of similar links";
            this.menuStripButtonSelectSections.Click += new System.EventHandler(this.menuStripButtonSelectSections_Click);
            // 
            // menuStripButtonInputKeywords
            // 
            this.menuStripButtonInputKeywords.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.key1_add;
            this.menuStripButtonInputKeywords.Name = "menuStripButtonInputKeywords";
            this.menuStripButtonInputKeywords.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.menuStripButtonInputKeywords.Size = new System.Drawing.Size(255, 22);
            this.menuStripButtonInputKeywords.Text = "Input a list of &keywords";
            this.menuStripButtonInputKeywords.Click += new System.EventHandler(this.menuStripButtonInputKeywords_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(252, 6);
            // 
            // menuStripButtonStartMine
            // 
            this.menuStripButtonStartMine.Enabled = false;
            this.menuStripButtonStartMine.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.document_ok;
            this.menuStripButtonStartMine.Name = "menuStripButtonStartMine";
            this.menuStripButtonStartMine.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.menuStripButtonStartMine.Size = new System.Drawing.Size(255, 22);
            this.menuStripButtonStartMine.Text = "Start &Mine";
            this.menuStripButtonStartMine.Click += new System.EventHandler(this.toolStripButtonMine_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(252, 6);
            // 
            // schedulerToolStripMenuItem
            // 
            this.schedulerToolStripMenuItem.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.clock;
            this.schedulerToolStripMenuItem.Name = "schedulerToolStripMenuItem";
            this.schedulerToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.schedulerToolStripMenuItem.Text = "S&cheduler";
            this.schedulerToolStripMenuItem.Click += new System.EventHandler(this.schedulerToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdatesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.refresh1;
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::GodLesZ.Tools.WebScraper.Properties.Resources.about;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(640, 352);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this._dockPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebScraper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ToolStrip toolStrip;
        private ToolStripButton toolStripButtonStopConfig;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem menuStripButtonOpen;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem menuStripButtonSave;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem menuStripButtonStartConfig;
        private ToolStripMenuItem menuStripButtonStopConfig;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripButton toolStripButtonStartConfig;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton toolStripButtonMine;
        private ToolStripButton toolStripButtonOpen;
        private ToolStripButton toolStripButtonSave;
        private ToolStripSeparator toolStripSeparator7;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem menuStripButtonStartMine;
        private ToolStripMenuItem menuStripButtonSelectSections;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem menuStripButtonInputKeywords;
        private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem editConfigToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem schedulerToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem editOptionsToolStripMenuItem;
        private ToolStripMenuItem addURLsToolStripMenuItem;
        private ToolStripMenuItem editStartURLPostDataToolStripMenuItem;
        private ToolStripMenuItem autoScrollToLoadMoreDataToolStripMenuItem;
        private ToolStripMenuItem editKeywordsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem disablePatternDetectionToolStripMenuItem;
        #endregion
    }
}
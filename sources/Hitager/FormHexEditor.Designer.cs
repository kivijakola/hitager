

namespace Hitager
{
    partial class FormHexEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHexEditor));
            this.menuStrip = new Hitager.Core.MenuStripEx();
            this.fileToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.openToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.recentFilesToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.editToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.cutToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.copyToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.pasteToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.copyHexStringToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.pasteHexToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.findToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.findNextToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.goToToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.viewToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.encodingToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.bitsToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.toolsToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.optionsToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.helpToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.aboutToolStripMenuItem = new Hitager.Core.ToolStripMenuItemEx();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new Hitager.Core.ToolStripEx();
            this.openToolStripButton = new Hitager.Core.ToolStripButtonEx();
            this.saveToolStripButton = new Hitager.Core.ToolStripButtonEx();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new Hitager.Core.ToolStripButtonEx();
            this.copyToolStripSplitButton = new Hitager.Core.ToolStripSplitButtonEx();
            this.copyToolStripMenuItem1 = new Hitager.Core.ToolStripMenuItemEx();
            this.copyHexToolStripMenuItem1 = new Hitager.Core.ToolStripMenuItemEx();
            this.pasteToolStripSplitButton = new Hitager.Core.ToolStripSplitButtonEx();
            this.pasteToolStripMenuItem1 = new Hitager.Core.ToolStripMenuItemEx();
            this.pasteHexToolStripMenuItem1 = new Hitager.Core.ToolStripMenuItemEx();
            this.encodingToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.portList = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileSizeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.bitToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.phaseNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.gainNum = new System.Windows.Forms.NumericUpDown();
            this.statusArduino = new System.Windows.Forms.Label();
            this.copyBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.statusReader = new System.Windows.Forms.Label();
            this.statusReceiver = new System.Windows.Forms.Label();
            this.statusTransponder = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.hitag2Tab = new System.Windows.Forms.TabPage();
            this.hitag2 = new Hitager.Hitag2();
            this.hitagAesTab = new System.Windows.Forms.TabPage();
            this.hexPanel = new System.Windows.Forms.Panel();
            this.hexBox = new Be.Windows.Forms.HexBox();
            this.hitagAes = new Hitager.HitagAes();
            this.hitag2EE = new System.Windows.Forms.TabPage();
            this.hitag2EEapp = new Hitager.Hitag2EE();
            this.tabHitagExtended = new System.Windows.Forms.TabPage();
            this.hitagExtended = new Hitager.HitagExtended();
            this.tabHitag3 = new System.Windows.Forms.TabPage();
            this.hitag3 = new Hitager.Hitag3();
            this.tabHitagPro = new System.Windows.Forms.TabPage();
            this.hitagPro = new Hitager.HitagPro();
            this.tabPageBmw = new System.Windows.Forms.TabPage();
            this.bmwHt2 = new Hitager.BmwHt2();
            this.tabVvdiSuperChip = new System.Windows.Forms.TabPage();
            this.superChip = new Hitager.SuperChip();
            this.tabPageDebugger = new System.Windows.Forms.TabPage();
            this.serialDebugger1 = new Hitager.SerialDebugger(this);
            this.portOutput = new System.Windows.Forms.TextBox();
            this.bitControl1 = new Hitager.BitControl();
            this.RecentFileHandler = new Hitager.RecentFileHandler(this.components);
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.bodyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phaseNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gainNum)).BeginInit();
            this.tabControl.SuspendLayout();
            this.hitag2Tab.SuspendLayout();
            this.hitagAesTab.SuspendLayout();
            this.hexPanel.SuspendLayout();
            this.hitag2EE.SuspendLayout();
            this.tabHitagExtended.SuspendLayout();
            this.tabHitag3.SuspendLayout();
            this.tabHitagPro.SuspendLayout();
            this.tabPageBmw.SuspendLayout();
            this.tabVvdiSuperChip.SuspendLayout();
            this.tabPageDebugger.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.donateToolStripMenuItem,
            this.toolStripMenuItem1});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator2,
            this.recentFilesToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::Hitager.ScalingImages.FolderOpen_16;
            this.openToolStripMenuItem.Image16 = global::Hitager.ScalingImages.FolderOpen_16;
            this.openToolStripMenuItem.Image24 = global::Hitager.ScalingImages.FolderOpen_24;
            this.openToolStripMenuItem.Image32 = global::Hitager.ScalingImages.FolderOpen_32;
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.open_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            resources.ApplyResources(this.toolStripSeparator, "toolStripSeparator");
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::Hitager.ScalingImages.save16;
            this.saveToolStripMenuItem.Image16 = global::Hitager.ScalingImages.save16;
            this.saveToolStripMenuItem.Image24 = global::Hitager.ScalingImages.Save24;
            this.saveToolStripMenuItem.Image32 = global::Hitager.ScalingImages.Save32;
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.save_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // recentFilesToolStripMenuItem
            // 
            resources.ApplyResources(this.recentFilesToolStripMenuItem, "recentFilesToolStripMenuItem");
            this.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
            this.recentFilesToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.recentFiles_DropDownItemClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator3,
            this.copyHexStringToolStripMenuItem,
            this.pasteHexToolStripMenuItem,
            this.toolStripSeparator4,
            this.findToolStripMenuItem,
            this.findNextToolStripMenuItem,
            this.goToToolStripMenuItem,
            this.toolStripSeparator5,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::Hitager.ScalingImages.Cut16;
            this.cutToolStripMenuItem.Image16 = global::Hitager.ScalingImages.Copy16;
            this.cutToolStripMenuItem.Image24 = global::Hitager.ScalingImages.Copy24;
            this.cutToolStripMenuItem.Image32 = global::Hitager.ScalingImages.Copy32;
            resources.ApplyResources(this.cutToolStripMenuItem, "cutToolStripMenuItem");
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cut_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::Hitager.ScalingImages.Copy16;
            this.copyToolStripMenuItem.Image16 = global::Hitager.ScalingImages.Copy16;
            this.copyToolStripMenuItem.Image24 = global::Hitager.ScalingImages.Copy24;
            this.copyToolStripMenuItem.Image32 = global::Hitager.ScalingImages.Copy32;
            resources.ApplyResources(this.copyToolStripMenuItem, "copyToolStripMenuItem");
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copy_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::Hitager.ScalingImages.Paste16;
            this.pasteToolStripMenuItem.Image16 = global::Hitager.ScalingImages.Paste16;
            this.pasteToolStripMenuItem.Image24 = global::Hitager.ScalingImages.Paste24;
            this.pasteToolStripMenuItem.Image32 = global::Hitager.ScalingImages.Paste32;
            resources.ApplyResources(this.pasteToolStripMenuItem, "pasteToolStripMenuItem");
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.paste_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // copyHexStringToolStripMenuItem
            // 
            this.copyHexStringToolStripMenuItem.Name = "copyHexStringToolStripMenuItem";
            resources.ApplyResources(this.copyHexStringToolStripMenuItem, "copyHexStringToolStripMenuItem");
            this.copyHexStringToolStripMenuItem.Click += new System.EventHandler(this.copyHex_Click);
            // 
            // pasteHexToolStripMenuItem
            // 
            this.pasteHexToolStripMenuItem.Name = "pasteHexToolStripMenuItem";
            resources.ApplyResources(this.pasteHexToolStripMenuItem, "pasteHexToolStripMenuItem");
            this.pasteHexToolStripMenuItem.Click += new System.EventHandler(this.pasteHex_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Image = global::Hitager.ScalingImages.Find16;
            this.findToolStripMenuItem.Image16 = global::Hitager.ScalingImages.Find16;
            this.findToolStripMenuItem.Image24 = global::Hitager.ScalingImages.Find24;
            this.findToolStripMenuItem.Image32 = global::Hitager.ScalingImages.Find32;
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            resources.ApplyResources(this.findToolStripMenuItem, "findToolStripMenuItem");
            this.findToolStripMenuItem.Click += new System.EventHandler(this.find_Click);
            // 
            // findNextToolStripMenuItem
            // 
            this.findNextToolStripMenuItem.Image = global::Hitager.ScalingImages.FindNext16;
            this.findNextToolStripMenuItem.Image16 = global::Hitager.ScalingImages.FindNext16;
            this.findNextToolStripMenuItem.Image24 = global::Hitager.ScalingImages.FindNext24;
            this.findNextToolStripMenuItem.Image32 = global::Hitager.ScalingImages.FindNext32;
            this.findNextToolStripMenuItem.Name = "findNextToolStripMenuItem";
            resources.ApplyResources(this.findNextToolStripMenuItem, "findNextToolStripMenuItem");
            this.findNextToolStripMenuItem.Click += new System.EventHandler(this.findNext_Click);
            // 
            // goToToolStripMenuItem
            // 
            this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
            resources.ApplyResources(this.goToToolStripMenuItem, "goToToolStripMenuItem");
            this.goToToolStripMenuItem.Click += new System.EventHandler(this.goTo_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            resources.ApplyResources(this.selectAllToolStripMenuItem, "selectAllToolStripMenuItem");
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encodingToolStripMenuItem,
            this.bitsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
            // 
            // encodingToolStripMenuItem
            // 
            this.encodingToolStripMenuItem.Name = "encodingToolStripMenuItem";
            resources.ApplyResources(this.encodingToolStripMenuItem, "encodingToolStripMenuItem");
            // 
            // bitsToolStripMenuItem
            // 
            this.bitsToolStripMenuItem.CheckOnClick = true;
            this.bitsToolStripMenuItem.Name = "bitsToolStripMenuItem";
            resources.ApplyResources(this.bitsToolStripMenuItem, "bitsToolStripMenuItem");
            this.bitsToolStripMenuItem.CheckedChanged += new System.EventHandler(this.bitsToolStripMenuItem_CheckedChanged);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.options_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.about_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.donateToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            resources.ApplyResources(this.donateToolStripMenuItem, "donateToolStripMenuItem");
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // toolStrip
            // 
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator6,
            this.cutToolStripButton,
            this.copyToolStripSplitButton,
            this.pasteToolStripSplitButton,
            this.encodingToolStripComboBox,
            this.toolStripSeparator7,
            this.toolStripLabel1,
            this.portList});
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = global::Hitager.images.openHS;
            this.openToolStripButton.Image16 = global::Hitager.ScalingImages.FolderOpen_16;
            this.openToolStripButton.Image24 = global::Hitager.ScalingImages.FolderOpen_24;
            this.openToolStripButton.Image32 = global::Hitager.ScalingImages.FolderOpen_32;
            resources.ApplyResources(this.openToolStripButton, "openToolStripButton");
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Click += new System.EventHandler(this.open_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = global::Hitager.images.saveHS;
            this.saveToolStripButton.Image16 = global::Hitager.ScalingImages.save16;
            this.saveToolStripButton.Image24 = global::Hitager.ScalingImages.Save24;
            this.saveToolStripButton.Image32 = global::Hitager.ScalingImages.Save32;
            resources.ApplyResources(this.saveToolStripButton, "saveToolStripButton");
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Click += new System.EventHandler(this.save_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = global::Hitager.images.CutHS;
            this.cutToolStripButton.Image16 = global::Hitager.ScalingImages.Cut16;
            this.cutToolStripButton.Image24 = global::Hitager.ScalingImages.Copy24;
            this.cutToolStripButton.Image32 = global::Hitager.ScalingImages.Copy32;
            resources.ApplyResources(this.cutToolStripButton, "cutToolStripButton");
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Click += new System.EventHandler(this.cut_Click);
            // 
            // copyToolStripSplitButton
            // 
            this.copyToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem1,
            this.copyHexToolStripMenuItem1});
            this.copyToolStripSplitButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.copyToolStripSplitButton.Image = global::Hitager.ScalingImages.Copy16;
            this.copyToolStripSplitButton.Image16 = global::Hitager.ScalingImages.Copy16;
            this.copyToolStripSplitButton.Image24 = global::Hitager.ScalingImages.Copy24;
            this.copyToolStripSplitButton.Image32 = global::Hitager.ScalingImages.Copy32;
            resources.ApplyResources(this.copyToolStripSplitButton, "copyToolStripSplitButton");
            this.copyToolStripSplitButton.Name = "copyToolStripSplitButton";
            this.copyToolStripSplitButton.ButtonClick += new System.EventHandler(this.copy_Click);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Image = global::Hitager.images.CopyHS;
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            resources.ApplyResources(this.copyToolStripMenuItem1, "copyToolStripMenuItem1");
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copy_Click);
            // 
            // copyHexToolStripMenuItem1
            // 
            this.copyHexToolStripMenuItem1.Image = global::Hitager.images.CopyHS;
            this.copyHexToolStripMenuItem1.Name = "copyHexToolStripMenuItem1";
            resources.ApplyResources(this.copyHexToolStripMenuItem1, "copyHexToolStripMenuItem1");
            this.copyHexToolStripMenuItem1.Click += new System.EventHandler(this.copyHex_Click);
            // 
            // pasteToolStripSplitButton
            // 
            this.pasteToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteToolStripMenuItem1,
            this.pasteHexToolStripMenuItem1});
            this.pasteToolStripSplitButton.Image = global::Hitager.ScalingImages.Paste16;
            this.pasteToolStripSplitButton.Image16 = global::Hitager.ScalingImages.Paste16;
            this.pasteToolStripSplitButton.Image24 = global::Hitager.ScalingImages.Paste24;
            this.pasteToolStripSplitButton.Image32 = global::Hitager.ScalingImages.Paste32;
            resources.ApplyResources(this.pasteToolStripSplitButton, "pasteToolStripSplitButton");
            this.pasteToolStripSplitButton.Name = "pasteToolStripSplitButton";
            this.pasteToolStripSplitButton.ButtonClick += new System.EventHandler(this.paste_Click);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            resources.ApplyResources(this.pasteToolStripMenuItem1, "pasteToolStripMenuItem1");
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.paste_Click);
            // 
            // pasteHexToolStripMenuItem1
            // 
            this.pasteHexToolStripMenuItem1.Name = "pasteHexToolStripMenuItem1";
            resources.ApplyResources(this.pasteHexToolStripMenuItem1, "pasteHexToolStripMenuItem1");
            this.pasteHexToolStripMenuItem1.Click += new System.EventHandler(this.pasteHex_Click);
            // 
            // encodingToolStripComboBox
            // 
            this.encodingToolStripComboBox.BackColor = System.Drawing.SystemColors.Control;
            this.encodingToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encodingToolStripComboBox.DropDownWidth = 180;
            resources.ApplyResources(this.encodingToolStripComboBox, "encodingToolStripComboBox");
            this.encodingToolStripComboBox.Name = "encodingToolStripComboBox";
            this.encodingToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.toolStripEncoding_SelectedIndexChanged);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            // 
            // portList
            // 
            this.portList.BackColor = System.Drawing.SystemColors.Control;
            this.portList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portList.DropDownWidth = 180;
            resources.ApplyResources(this.portList, "portList");
            this.portList.Name = "portList";
            this.portList.SelectedIndexChanged += new System.EventHandler(this.portList_SelectedIndexChanged);
            this.portList.Click += new System.EventHandler(this.portList_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.fileSizeToolStripStatusLabel,
            this.bitToolStripStatusLabel});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip.SizingGrip = false;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            resources.ApplyResources(this.toolStripStatusLabel, "toolStripStatusLabel");
            // 
            // fileSizeToolStripStatusLabel
            // 
            this.fileSizeToolStripStatusLabel.Name = "fileSizeToolStripStatusLabel";
            this.fileSizeToolStripStatusLabel.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            resources.ApplyResources(this.fileSizeToolStripStatusLabel, "fileSizeToolStripStatusLabel");
            // 
            // bitToolStripStatusLabel
            // 
            this.bitToolStripStatusLabel.Name = "bitToolStripStatusLabel";
            resources.ApplyResources(this.bitToolStripStatusLabel, "bitToolStripStatusLabel");
            // 
            // bodyPanel
            // 
            resources.ApplyResources(this.bodyPanel, "bodyPanel");
            this.bodyPanel.Controls.Add(this.label2);
            this.bodyPanel.Controls.Add(this.phaseNum);
            this.bodyPanel.Controls.Add(this.label1);
            this.bodyPanel.Controls.Add(this.gainNum);
            this.bodyPanel.Controls.Add(this.statusArduino);
            this.bodyPanel.Controls.Add(this.copyBtn);
            this.bodyPanel.Controls.Add(this.clearBtn);
            this.bodyPanel.Controls.Add(this.statusReader);
            this.bodyPanel.Controls.Add(this.statusReceiver);
            this.bodyPanel.Controls.Add(this.statusTransponder);
            this.bodyPanel.Controls.Add(this.tabControl);
            this.bodyPanel.Controls.Add(this.portOutput);
            this.bodyPanel.Controls.Add(this.bitControl1);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.bodyPanel_Paint);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // phaseNum
            // 
            resources.ApplyResources(this.phaseNum, "phaseNum");
            this.phaseNum.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.phaseNum.Name = "phaseNum";
            this.phaseNum.ValueChanged += new System.EventHandler(this.phaseNum_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // gainNum
            // 
            resources.ApplyResources(this.gainNum, "gainNum");
            this.gainNum.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.gainNum.Name = "gainNum";
            this.gainNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.gainNum.ValueChanged += new System.EventHandler(this.gainNum_ValueChanged);
            // 
            // statusArduino
            // 
            resources.ApplyResources(this.statusArduino, "statusArduino");
            this.statusArduino.BackColor = System.Drawing.Color.Red;
            this.statusArduino.Name = "statusArduino";
            // 
            // copyBtn
            // 
            resources.ApplyResources(this.copyBtn, "copyBtn");
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // clearBtn
            // 
            resources.ApplyResources(this.clearBtn, "clearBtn");
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // statusReader
            // 
            resources.ApplyResources(this.statusReader, "statusReader");
            this.statusReader.BackColor = System.Drawing.Color.Red;
            this.statusReader.Name = "statusReader";
            // 
            // statusReceiver
            // 
            resources.ApplyResources(this.statusReceiver, "statusReceiver");
            this.statusReceiver.BackColor = System.Drawing.Color.Red;
            this.statusReceiver.Name = "statusReceiver";
            // 
            // statusTransponder
            // 
            resources.ApplyResources(this.statusTransponder, "statusTransponder");
            this.statusTransponder.BackColor = System.Drawing.Color.Red;
            this.statusTransponder.Name = "statusTransponder";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.hitag2Tab);
            this.tabControl.Controls.Add(this.hitagAesTab);
            this.tabControl.Controls.Add(this.hitag2EE);
            this.tabControl.Controls.Add(this.tabHitagExtended);
            this.tabControl.Controls.Add(this.tabHitag3);
            this.tabControl.Controls.Add(this.tabHitagPro);
            this.tabControl.Controls.Add(this.tabPageBmw);
            this.tabControl.Controls.Add(this.tabVvdiSuperChip);
            this.tabControl.Controls.Add(this.tabPageDebugger);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // hitag2Tab
            // 
            this.hitag2Tab.Controls.Add(this.hitag2);
            resources.ApplyResources(this.hitag2Tab, "hitag2Tab");
            this.hitag2Tab.Name = "hitag2Tab";
            this.hitag2Tab.UseVisualStyleBackColor = true;
            // 
            // hitag2
            // 
            resources.ApplyResources(this.hitag2, "hitag2");
            this.hitag2.Name = "hitag2";
            this.hitag2.HexUpdated += new System.EventHandler(this.Controlapp_HexUpdated);
            this.hitag2.debugUpdated += new System.EventHandler(this.debugUpdatedEventHandler);
            // 
            // hitagAesTab
            // 
            this.hitagAesTab.Controls.Add(this.hexPanel);
            this.hitagAesTab.Controls.Add(this.hitagAes);
            resources.ApplyResources(this.hitagAesTab, "hitagAesTab");
            this.hitagAesTab.Name = "hitagAesTab";
            this.hitagAesTab.UseVisualStyleBackColor = true;
            // 
            // hexPanel
            // 
            this.hexPanel.Controls.Add(this.hexBox);
            resources.ApplyResources(this.hexPanel, "hexPanel");
            this.hexPanel.Name = "hexPanel";
            // 
            // hexBox
            // 
            this.hexBox.AllowDrop = true;
            this.hexBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            // 
            // 
            // 
            this.hexBox.BuiltInContextMenu.CopyMenuItemImage = global::Hitager.images.CopyHS;
            this.hexBox.BuiltInContextMenu.CopyMenuItemText = resources.GetString("hexBox.BuiltInContextMenu.CopyMenuItemText");
            this.hexBox.BuiltInContextMenu.CutMenuItemImage = global::Hitager.images.CutHS;
            this.hexBox.BuiltInContextMenu.CutMenuItemText = resources.GetString("hexBox.BuiltInContextMenu.CutMenuItemText");
            this.hexBox.BuiltInContextMenu.PasteMenuItemImage = global::Hitager.images.PasteHS;
            this.hexBox.BuiltInContextMenu.PasteMenuItemText = resources.GetString("hexBox.BuiltInContextMenu.PasteMenuItemText");
            this.hexBox.BuiltInContextMenu.SelectAllMenuItemText = resources.GetString("hexBox.BuiltInContextMenu.SelectAllMenuItemText");
            this.hexBox.ColumnInfoVisible = true;
            resources.ApplyResources(this.hexBox, "hexBox");
            this.hexBox.HexCasing = Be.Windows.Forms.HexCasing.Lower;
            this.hexBox.LineInfoVisible = true;
            this.hexBox.Name = "hexBox";
            this.hexBox.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox.StringViewVisible = true;
            this.hexBox.UseFixedBytesPerLine = true;
            this.hexBox.VScrollBarVisible = true;
            this.hexBox.SelectionStartChanged += new System.EventHandler(this.hexBox_SelectionStartChanged);
            this.hexBox.SelectionLengthChanged += new System.EventHandler(this.hexBox_SelectionLengthChanged);
            this.hexBox.CurrentLineChanged += new System.EventHandler(this.Position_Changed);
            this.hexBox.CurrentPositionInLineChanged += new System.EventHandler(this.Position_Changed);
            this.hexBox.Copied += new System.EventHandler(this.hexBox_Copied);
            this.hexBox.CopiedHex += new System.EventHandler(this.hexBox_CopiedHex);
            this.hexBox.RequiredWidthChanged += new System.EventHandler(this.hexBox_RequiredWidthChanged);
            this.hexBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.hexBox_DragDrop);
            this.hexBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.hexBox_DragEnter);
            // 
            // hitagAes
            // 
            resources.ApplyResources(this.hitagAes, "hitagAes");
            this.hitagAes.Name = "hitagAes";
            this.hitagAes.HexUpdated += new System.EventHandler(this.Controlapp_HexUpdated);
            this.hitagAes.debugUpdated += new System.EventHandler(this.debugUpdatedEventHandler);
            this.hitagAes.Load += new System.EventHandler(this.hitagAes_Load);
            // 
            // hitag2EE
            // 
            this.hitag2EE.Controls.Add(this.hitag2EEapp);
            resources.ApplyResources(this.hitag2EE, "hitag2EE");
            this.hitag2EE.Name = "hitag2EE";
            this.hitag2EE.UseVisualStyleBackColor = true;
            // 
            // hitag2EEapp
            // 
            resources.ApplyResources(this.hitag2EEapp, "hitag2EEapp");
            this.hitag2EEapp.Name = "hitag2EEapp";
            this.hitag2EEapp.HexUpdated += new System.EventHandler(this.Controlapp_HexUpdated);
            this.hitag2EEapp.debugUpdated += new System.EventHandler(this.debugUpdatedEventHandler);
            // 
            // tabHitagExtended
            // 
            this.tabHitagExtended.Controls.Add(this.hitagExtended);
            resources.ApplyResources(this.tabHitagExtended, "tabHitagExtended");
            this.tabHitagExtended.Name = "tabHitagExtended";
            this.tabHitagExtended.UseVisualStyleBackColor = true;
            // 
            // hitagExtended
            // 
            resources.ApplyResources(this.hitagExtended, "hitagExtended");
            this.hitagExtended.Name = "hitagExtended";
            this.hitagExtended.HexUpdated += new System.EventHandler(this.Controlapp_HexUpdated);
            this.hitagExtended.debugUpdated += new System.EventHandler(this.debugUpdatedEventHandler);
            // 
            // tabHitag3
            // 
            this.tabHitag3.Controls.Add(this.hitag3);
            resources.ApplyResources(this.tabHitag3, "tabHitag3");
            this.tabHitag3.Name = "tabHitag3";
            this.tabHitag3.UseVisualStyleBackColor = true;
            // 
            // hitag3
            // 
            resources.ApplyResources(this.hitag3, "hitag3");
            this.hitag3.Name = "hitag3";
            this.hitag3.HexUpdated += new System.EventHandler(this.Controlapp_HexUpdated);
            this.hitag3.debugUpdated += new System.EventHandler(this.debugUpdatedEventHandler);
            // 
            // tabHitagPro
            // 
            this.tabHitagPro.Controls.Add(this.hitagPro);
            resources.ApplyResources(this.tabHitagPro, "tabHitagPro");
            this.tabHitagPro.Name = "tabHitagPro";
            this.tabHitagPro.UseVisualStyleBackColor = true;
            // 
            // hitagPro
            // 
            resources.ApplyResources(this.hitagPro, "hitagPro");
            this.hitagPro.Name = "hitagPro";
            this.hitagPro.HexUpdated += new System.EventHandler(this.Controlapp_HexUpdated);
            this.hitagPro.debugUpdated += new System.EventHandler(this.debugUpdatedEventHandler);
            // 
            // tabPageBmw
            // 
            this.tabPageBmw.Controls.Add(this.bmwHt2);
            resources.ApplyResources(this.tabPageBmw, "tabPageBmw");
            this.tabPageBmw.Name = "tabPageBmw";
            this.tabPageBmw.UseVisualStyleBackColor = true;
            // 
            // bmwHt2
            // 
            resources.ApplyResources(this.bmwHt2, "bmwHt2");
            this.bmwHt2.Name = "bmwHt2";
            this.bmwHt2.HexUpdated += new System.EventHandler(this.Controlapp_HexUpdated);
            this.bmwHt2.debugUpdated += new System.EventHandler(this.debugUpdatedEventHandler);
            this.bmwHt2.Load += new System.EventHandler(this.bmwHt2_Load);
            // 
            // tabVvdiSuperChip
            // 
            this.tabVvdiSuperChip.Controls.Add(this.superChip);
            resources.ApplyResources(this.tabVvdiSuperChip, "tabVvdiSuperChip");
            this.tabVvdiSuperChip.Name = "tabVvdiSuperChip";
            this.tabVvdiSuperChip.UseVisualStyleBackColor = true;
            // 
            // superChip
            // 
            resources.ApplyResources(this.superChip, "superChip");
            this.superChip.Name = "superChip";
            this.superChip.HexUpdated += new System.EventHandler(this.Controlapp_HexUpdated);
            this.superChip.debugUpdated += new System.EventHandler(this.debugUpdatedEventHandler);
            // 
            // tabPageDebugger
            // 
            this.tabPageDebugger.Controls.Add(this.serialDebugger1);
            resources.ApplyResources(this.tabPageDebugger, "tabPageDebugger");
            this.tabPageDebugger.Name = "tabPageDebugger";
            this.tabPageDebugger.UseVisualStyleBackColor = true;
            // 
            // serialDebugger1
            // 
            resources.ApplyResources(this.serialDebugger1, "serialDebugger1");
            this.serialDebugger1.Name = "serialDebugger1";
            this.serialDebugger1.debugUpdated += new System.EventHandler(this.debugUpdatedEventHandler);
            this.serialDebugger1.Load += new System.EventHandler(this.serialDebugger1_Load);
            // 
            // portOutput
            // 
            resources.ApplyResources(this.portOutput, "portOutput");
            this.portOutput.Name = "portOutput";
            // 
            // bitControl1
            // 
            resources.ApplyResources(this.bitControl1, "bitControl1");
            this.bitControl1.Name = "bitControl1";
            this.bitControl1.BitChanged += new System.EventHandler(this.bitControl1_BitChanged);
            // 
            // RecentFileHandler
            // 
            this.RecentFileHandler.RecentFileToolStripItem = this.recentFilesToolStripMenuItem;
            // 
            // FormHexEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.bodyPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormHexEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormHexEditor_FormClosing);
            this.Load += new System.EventHandler(this.FormHexEditor_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.bodyPanel.ResumeLayout(false);
            this.bodyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phaseNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gainNum)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.hitag2Tab.ResumeLayout(false);
            this.hitagAesTab.ResumeLayout(false);
            this.hexPanel.ResumeLayout(false);
            this.hitag2EE.ResumeLayout(false);
            this.tabHitagExtended.ResumeLayout(false);
            this.tabHitag3.ResumeLayout(false);
            this.tabHitagPro.ResumeLayout(false);
            this.tabPageBmw.ResumeLayout(false);
            this.tabVvdiSuperChip.ResumeLayout(false);
            this.tabPageDebugger.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Core.MenuStripEx menuStrip;
        private Core.ToolStripMenuItemEx fileToolStripMenuItem;
        private Core.ToolStripMenuItemEx openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private Core.ToolStripMenuItemEx saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private Core.ToolStripMenuItemEx exitToolStripMenuItem;
        private Core.ToolStripMenuItemEx editToolStripMenuItem;
        private Core.ToolStripMenuItemEx cutToolStripMenuItem;
        private Core.ToolStripMenuItemEx copyToolStripMenuItem;
        private Core.ToolStripMenuItemEx pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private Core.ToolStripMenuItemEx findToolStripMenuItem;
        private Core.ToolStripMenuItemEx toolsToolStripMenuItem;
        private Core.ToolStripMenuItemEx optionsToolStripMenuItem;
        private Core.ToolStripMenuItemEx helpToolStripMenuItem;
        private Core.ToolStripMenuItemEx aboutToolStripMenuItem;
        private Core.ToolStripEx toolStrip;
        private Core.ToolStripButtonEx openToolStripButton;
        private Core.ToolStripButtonEx saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private Core.ToolStripButtonEx cutToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private Core.ToolStripMenuItemEx findNextToolStripMenuItem;
        private Core.ToolStripMenuItemEx goToToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private Core.ToolStripMenuItemEx recentFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel fileSizeToolStripStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private Core.ToolStripMenuItemEx copyHexStringToolStripMenuItem;
        private Core.ToolStripMenuItemEx pasteHexToolStripMenuItem;
        private Core.ToolStripSplitButtonEx copyToolStripSplitButton;
        private Core.ToolStripMenuItemEx copyToolStripMenuItem1;
        private Core.ToolStripMenuItemEx copyHexToolStripMenuItem1;
        private Core.ToolStripSplitButtonEx pasteToolStripSplitButton;
        private Core.ToolStripMenuItemEx pasteToolStripMenuItem1;
        private Core.ToolStripMenuItemEx pasteHexToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private Core.ToolStripMenuItemEx selectAllToolStripMenuItem;
        public RecentFileHandler RecentFileHandler;
		private System.Windows.Forms.ToolStripStatusLabel bitToolStripStatusLabel;
		private System.Windows.Forms.ToolStripComboBox encodingToolStripComboBox;
		private Core.ToolStripMenuItemEx viewToolStripMenuItem;
		private Core.ToolStripMenuItemEx encodingToolStripMenuItem;
		private Core.ToolStripMenuItemEx bitsToolStripMenuItem;
		private BitControl bitControl1;
		private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.TextBox portOutput;
        private System.Windows.Forms.ToolStripComboBox portList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage hitagAesTab;
        private System.Windows.Forms.TabPage hitag2Tab;
        private Hitag2 hitag2;
        private Be.Windows.Forms.HexBox hexBox;
        private HitagAes hitagAes;
        private System.Windows.Forms.TabPage hitag2EE;
        private Hitag2EE hitag2EEapp;
        private System.Windows.Forms.TabPage tabPageDebugger;
        private SerialDebugger serialDebugger1;
        private System.Windows.Forms.TabPage tabHitagExtended;
        private System.Windows.Forms.TabPage tabHitagPro;
        private System.Windows.Forms.TabPage tabHitag3;
        private HitagExtended hitagExtended;
        private HitagPro hitagPro;
        private Hitag3 hitag3;
        private System.Windows.Forms.Panel hexPanel;
        private System.Windows.Forms.Label statusTransponder;
        private System.Windows.Forms.Label statusReader;
        private System.Windows.Forms.Label statusReceiver;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Label statusArduino;
        private System.Windows.Forms.NumericUpDown gainNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown phaseNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageBmw;
        private BmwHt2 bmwHt2;
        private System.Windows.Forms.TabPage tabVvdiSuperChip;
        private SuperChip superChip;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}
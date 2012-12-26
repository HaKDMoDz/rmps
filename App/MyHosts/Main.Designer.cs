namespace Me.Amon.Hosts
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.SbEcho = new System.Windows.Forms.StatusStrip();
            this.CbMenu = new System.Windows.Forms.MenuStrip();
            this.MuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSaveas = new System.Windows.Forms.ToolStripMenuItem();
            this.MiFile0 = new System.Windows.Forms.ToolStripSeparator();
            this.MiReload = new System.Windows.Forms.ToolStripMenuItem();
            this.MiOpenas = new System.Windows.Forms.ToolStripMenuItem();
            this.MiFile1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.MiResume = new System.Windows.Forms.ToolStripMenuItem();
            this.MiFile2 = new System.Windows.Forms.ToolStripSeparator();
            this.MiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MiCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.MiRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.MiEdit0 = new System.Windows.Forms.ToolStripSeparator();
            this.MiCreateGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MuData = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSaveasSln = new System.Windows.Forms.ToolStripMenuItem();
            this.MiManageSln = new System.Windows.Forms.ToolStripMenuItem();
            this.MiData0 = new System.Windows.Forms.ToolStripSeparator();
            this.MuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.MiHelp0 = new System.Windows.Forms.ToolStripSeparator();
            this.MiSite = new System.Windows.Forms.ToolStripMenuItem();
            this.TbTool = new System.Windows.Forms.ToolStrip();
            this.TbSaveas = new System.Windows.Forms.ToolStripButton();
            this.TbSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.TbUpdate = new System.Windows.Forms.ToolStripButton();
            this.TbCreate = new System.Windows.Forms.ToolStripButton();
            this.TbRemove = new System.Windows.Forms.ToolStripButton();
            this.TbSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.TbReload = new System.Windows.Forms.ToolStripButton();
            this.TbOpenas = new System.Windows.Forms.ToolStripButton();
            this.TbSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.TbComment = new System.Windows.Forms.ToolStripButton();
            this.TbAbout = new System.Windows.Forms.ToolStripButton();
            this.LvItem = new System.Windows.Forms.ListView();
            this.ChIp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Chdomain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChComment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CmGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CiCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.CiRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.NiTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.TmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.SiSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.TuSln = new System.Windows.Forms.ToolStripMenuItem();
            this.TiSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.TiHide = new System.Windows.Forms.ToolStripMenuItem();
            this.TiSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.TiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MiCreateSln = new System.Windows.Forms.ToolStripMenuItem();
            this.CbMenu.SuspendLayout();
            this.TbTool.SuspendLayout();
            this.CmMenu.SuspendLayout();
            this.TmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SbEcho
            // 
            this.SbEcho.Location = new System.Drawing.Point(0, 390);
            this.SbEcho.Name = "SbEcho";
            this.SbEcho.Size = new System.Drawing.Size(584, 22);
            this.SbEcho.TabIndex = 0;
            this.SbEcho.Text = "状态栏";
            // 
            // CbMenu
            // 
            this.CbMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MuFile,
            this.MuEdit,
            this.MuData,
            this.MuHelp});
            this.CbMenu.Location = new System.Drawing.Point(0, 0);
            this.CbMenu.Name = "CbMenu";
            this.CbMenu.Size = new System.Drawing.Size(584, 24);
            this.CbMenu.TabIndex = 1;
            this.CbMenu.Text = "选单栏";
            // 
            // MuFile
            // 
            this.MuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiSaveas,
            this.MiFile0,
            this.MiReload,
            this.MiOpenas,
            this.MiFile1,
            this.MiBackup,
            this.MiResume,
            this.MiFile2,
            this.MiExit});
            this.MuFile.Name = "MuFile";
            this.MuFile.Size = new System.Drawing.Size(57, 20);
            this.MuFile.Text = "文件(&F)";
            // 
            // MiSaveas
            // 
            this.MiSaveas.Name = "MiSaveas";
            this.MiSaveas.ShortcutKeyDisplayString = "Ctrl + S";
            this.MiSaveas.Size = new System.Drawing.Size(164, 22);
            this.MiSaveas.Text = "保存(&S)";
            this.MiSaveas.Click += new System.EventHandler(this.MiSaveasClick);
            // 
            // MiFile0
            // 
            this.MiFile0.Name = "MiFile0";
            this.MiFile0.Size = new System.Drawing.Size(161, 6);
            // 
            // MiReload
            // 
            this.MiReload.Name = "MiReload";
            this.MiReload.ShortcutKeyDisplayString = "F5";
            this.MiReload.Size = new System.Drawing.Size(164, 22);
            this.MiReload.Text = "重新加载(&R)";
            this.MiReload.Click += new System.EventHandler(this.MiReloadClick);
            // 
            // MiOpenas
            // 
            this.MiOpenas.Name = "MiOpenas";
            this.MiOpenas.ShortcutKeyDisplayString = "F12";
            this.MiOpenas.Size = new System.Drawing.Size(164, 22);
            this.MiOpenas.Text = "手动编辑(&E)";
            this.MiOpenas.Click += new System.EventHandler(this.MiOpenasClick);
            // 
            // MiFile1
            // 
            this.MiFile1.Name = "MiFile1";
            this.MiFile1.Size = new System.Drawing.Size(161, 6);
            // 
            // MiBackup
            // 
            this.MiBackup.Name = "MiBackup";
            this.MiBackup.Size = new System.Drawing.Size(164, 22);
            this.MiBackup.Text = "备份(&B)";
            this.MiBackup.Click += new System.EventHandler(this.MiBackupClick);
            // 
            // MiResume
            // 
            this.MiResume.Name = "MiResume";
            this.MiResume.Size = new System.Drawing.Size(164, 22);
            this.MiResume.Text = "恢复(&P)";
            this.MiResume.Click += new System.EventHandler(this.MiPickupClick);
            // 
            // MiFile2
            // 
            this.MiFile2.Name = "MiFile2";
            this.MiFile2.Size = new System.Drawing.Size(161, 6);
            // 
            // MiExit
            // 
            this.MiExit.Name = "MiExit";
            this.MiExit.Size = new System.Drawing.Size(164, 22);
            this.MiExit.Text = "退出(&X)";
            this.MiExit.Click += new System.EventHandler(this.MiExitClick);
            // 
            // MuEdit
            // 
            this.MuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiCreate,
            this.MiUpdate,
            this.MiRemove,
            this.MiEdit0,
            this.MiCreateGroup});
            this.MuEdit.Name = "MuEdit";
            this.MuEdit.Size = new System.Drawing.Size(58, 20);
            this.MuEdit.Text = "编辑(&E)";
            // 
            // MiCreate
            // 
            this.MiCreate.Name = "MiCreate";
            this.MiCreate.ShortcutKeyDisplayString = "Ctrl + N";
            this.MiCreate.Size = new System.Drawing.Size(170, 22);
            this.MiCreate.Text = "新增(&N)";
            this.MiCreate.Click += new System.EventHandler(this.MiCreateClick);
            // 
            // MiUpdate
            // 
            this.MiUpdate.Name = "MiUpdate";
            this.MiUpdate.ShortcutKeyDisplayString = "Ctrl + E";
            this.MiUpdate.Size = new System.Drawing.Size(170, 22);
            this.MiUpdate.Text = "编辑(&E)";
            this.MiUpdate.Click += new System.EventHandler(this.MiUpdateClick);
            // 
            // MiRemove
            // 
            this.MiRemove.Name = "MiRemove";
            this.MiRemove.ShortcutKeyDisplayString = "Ctrl + D";
            this.MiRemove.Size = new System.Drawing.Size(170, 22);
            this.MiRemove.Text = "删除(&D)";
            this.MiRemove.Click += new System.EventHandler(this.MiRemoveClick);
            // 
            // MiEdit0
            // 
            this.MiEdit0.Name = "MiEdit0";
            this.MiEdit0.Size = new System.Drawing.Size(167, 6);
            // 
            // MiCreateGroup
            // 
            this.MiCreateGroup.Name = "MiCreateGroup";
            this.MiCreateGroup.Size = new System.Drawing.Size(170, 22);
            this.MiCreateGroup.Text = "创建分组(&G)";
            this.MiCreateGroup.Click += new System.EventHandler(this.MiCreateGroupClick);
            // 
            // MuData
            // 
            this.MuData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiSaveasSln,
            this.MiCreateSln,
            this.MiManageSln,
            this.MiData0});
            this.MuData.Name = "MuData";
            this.MuData.Size = new System.Drawing.Size(58, 20);
            this.MuData.Text = "方案(&S)";
            // 
            // MiSaveasSln
            // 
            this.MiSaveasSln.Name = "MiSaveasSln";
            this.MiSaveasSln.Size = new System.Drawing.Size(164, 22);
            this.MiSaveasSln.Text = "另存为新方案(&S)";
            this.MiSaveasSln.Click += new System.EventHandler(this.MiSaveasSlnClick);
            // 
            // MiManageSln
            // 
            this.MiManageSln.Name = "MiManageSln";
            this.MiManageSln.Size = new System.Drawing.Size(164, 22);
            this.MiManageSln.Text = "管理方案(&M)";
            this.MiManageSln.Click += new System.EventHandler(this.MiManageSlnClick);
            // 
            // MiData0
            // 
            this.MiData0.Name = "MiData0";
            this.MiData0.Size = new System.Drawing.Size(161, 6);
            // 
            // MuHelp
            // 
            this.MuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiAbout,
            this.MiHelp0,
            this.MiSite});
            this.MuHelp.Name = "MuHelp";
            this.MuHelp.Size = new System.Drawing.Size(60, 20);
            this.MuHelp.Text = "帮助(&H)";
            // 
            // MiAbout
            // 
            this.MiAbout.Name = "MiAbout";
            this.MiAbout.ShortcutKeyDisplayString = "F1";
            this.MiAbout.Size = new System.Drawing.Size(139, 22);
            this.MiAbout.Text = "关于(&A)";
            this.MiAbout.Click += new System.EventHandler(this.MiAboutClick);
            // 
            // MiHelp0
            // 
            this.MiHelp0.Name = "MiHelp0";
            this.MiHelp0.Size = new System.Drawing.Size(136, 6);
            // 
            // MiSite
            // 
            this.MiSite.Name = "MiSite";
            this.MiSite.Size = new System.Drawing.Size(139, 22);
            this.MiSite.Text = "作者博客(&H)";
            this.MiSite.Click += new System.EventHandler(this.MiSite_Click);
            // 
            // TbTool
            // 
            this.TbTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TbSaveas,
            this.TbSep0,
            this.TbUpdate,
            this.TbCreate,
            this.TbRemove,
            this.TbSep1,
            this.TbReload,
            this.TbOpenas,
            this.TbSep2,
            this.TbComment,
            this.TbAbout});
            this.TbTool.Location = new System.Drawing.Point(0, 24);
            this.TbTool.Name = "TbTool";
            this.TbTool.Size = new System.Drawing.Size(584, 25);
            this.TbTool.TabIndex = 2;
            this.TbTool.Text = "工具栏";
            // 
            // TbSaveas
            // 
            this.TbSaveas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbSaveas.Image = global::Me.Amon.Hosts.Properties.Resources.Saveas;
            this.TbSaveas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbSaveas.Name = "TbSaveas";
            this.TbSaveas.Size = new System.Drawing.Size(23, 22);
            this.TbSaveas.Text = "保存";
            this.TbSaveas.Click += new System.EventHandler(this.TbSaveasClick);
            // 
            // TbSep0
            // 
            this.TbSep0.Name = "TbSep0";
            this.TbSep0.Size = new System.Drawing.Size(6, 25);
            // 
            // TbUpdate
            // 
            this.TbUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbUpdate.Image = global::Me.Amon.Hosts.Properties.Resources.Update;
            this.TbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbUpdate.Name = "TbUpdate";
            this.TbUpdate.Size = new System.Drawing.Size(23, 22);
            this.TbUpdate.Text = "编辑";
            this.TbUpdate.Click += new System.EventHandler(this.TbUpdateClick);
            // 
            // TbCreate
            // 
            this.TbCreate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbCreate.Image = global::Me.Amon.Hosts.Properties.Resources.Append;
            this.TbCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbCreate.Name = "TbCreate";
            this.TbCreate.Size = new System.Drawing.Size(23, 22);
            this.TbCreate.Text = "添加";
            this.TbCreate.Click += new System.EventHandler(this.TbCreateClick);
            // 
            // TbRemove
            // 
            this.TbRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbRemove.Image = global::Me.Amon.Hosts.Properties.Resources.Delete;
            this.TbRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbRemove.Name = "TbRemove";
            this.TbRemove.Size = new System.Drawing.Size(23, 22);
            this.TbRemove.Text = "删除";
            this.TbRemove.Click += new System.EventHandler(this.TbRemoveClick);
            // 
            // TbSep1
            // 
            this.TbSep1.Name = "TbSep1";
            this.TbSep1.Size = new System.Drawing.Size(6, 25);
            // 
            // TbReload
            // 
            this.TbReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbReload.Image = global::Me.Amon.Hosts.Properties.Resources.Reload;
            this.TbReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbReload.Name = "TbReload";
            this.TbReload.Size = new System.Drawing.Size(23, 22);
            this.TbReload.Text = "重新加载";
            this.TbReload.Click += new System.EventHandler(this.TbReloadClick);
            // 
            // TbOpenas
            // 
            this.TbOpenas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbOpenas.Image = global::Me.Amon.Hosts.Properties.Resources.Openas;
            this.TbOpenas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbOpenas.Name = "TbOpenas";
            this.TbOpenas.Size = new System.Drawing.Size(23, 22);
            this.TbOpenas.Text = "手动编辑";
            this.TbOpenas.Click += new System.EventHandler(this.TbOpenasClick);
            // 
            // TbSep2
            // 
            this.TbSep2.Name = "TbSep2";
            this.TbSep2.Size = new System.Drawing.Size(6, 25);
            // 
            // TbComment
            // 
            this.TbComment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbComment.Image = global::Me.Amon.Hosts.Properties.Resources.Comment;
            this.TbComment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbComment.Name = "TbComment";
            this.TbComment.Size = new System.Drawing.Size(23, 22);
            this.TbComment.Text = "查看备注";
            this.TbComment.Click += new System.EventHandler(this.TbCommentClick);
            // 
            // TbAbout
            // 
            this.TbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TbAbout.Image = global::Me.Amon.Hosts.Properties.Resources.About;
            this.TbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TbAbout.Name = "TbAbout";
            this.TbAbout.Size = new System.Drawing.Size(23, 22);
            this.TbAbout.Text = "关于软件";
            this.TbAbout.Click += new System.EventHandler(this.TbAboutClick);
            // 
            // LvItem
            // 
            this.LvItem.CheckBoxes = true;
            this.LvItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ChIp,
            this.Chdomain,
            this.ChComment});
            this.LvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvItem.FullRowSelect = true;
            this.LvItem.HideSelection = false;
            this.LvItem.Location = new System.Drawing.Point(0, 49);
            this.LvItem.MultiSelect = false;
            this.LvItem.Name = "LvItem";
            this.LvItem.ShowItemToolTips = true;
            this.LvItem.Size = new System.Drawing.Size(584, 341);
            this.LvItem.TabIndex = 3;
            this.LvItem.UseCompatibleStateImageBehavior = false;
            this.LvItem.View = System.Windows.Forms.View.Details;
            this.LvItem.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.LvItemItemChecked);
            this.LvItem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LvItem_MouseClick);
            // 
            // ChIp
            // 
            this.ChIp.Text = "网址";
            this.ChIp.Width = 120;
            // 
            // Chdomain
            // 
            this.Chdomain.Text = "域名";
            this.Chdomain.Width = 180;
            // 
            // ChComment
            // 
            this.ChComment.Text = "备注";
            this.ChComment.Width = 240;
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CiUpdate,
            this.toolStripSeparator1,
            this.CmGroups,
            this.toolStripSeparator2,
            this.CiCreate,
            this.CiRemove});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(117, 104);
            this.CmMenu.Text = "右键选单";
            // 
            // CiUpdate
            // 
            this.CiUpdate.Name = "CiUpdate";
            this.CiUpdate.Size = new System.Drawing.Size(116, 22);
            this.CiUpdate.Text = "编辑(&E)";
            this.CiUpdate.Click += new System.EventHandler(this.CiUpdateClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // CmGroups
            // 
            this.CmGroups.Name = "CmGroups";
            this.CmGroups.Size = new System.Drawing.Size(116, 22);
            this.CmGroups.Text = "分组(&G)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(113, 6);
            // 
            // CiCreate
            // 
            this.CiCreate.Name = "CiCreate";
            this.CiCreate.Size = new System.Drawing.Size(116, 22);
            this.CiCreate.Text = "添加(&N)";
            this.CiCreate.Click += new System.EventHandler(this.CiCreateClick);
            // 
            // CiRemove
            // 
            this.CiRemove.Name = "CiRemove";
            this.CiRemove.Size = new System.Drawing.Size(116, 22);
            this.CiRemove.Text = "删除(&D)";
            this.CiRemove.Click += new System.EventHandler(this.CiRemoveClick);
            // 
            // NiTray
            // 
            this.NiTray.BalloonTipTitle = "提示";
            this.NiTray.ContextMenuStrip = this.TmMenu;
            this.NiTray.Text = "MyHosts";
            this.NiTray.Visible = true;
            this.NiTray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NiTray_MouseDoubleClick);
            // 
            // TmMenu
            // 
            this.TmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TiOpen,
            this.SiSep0,
            this.TuSln,
            this.TiSep1,
            this.TiHide,
            this.TiSep3,
            this.TiExit});
            this.TmMenu.Name = "TmMenu";
            this.TmMenu.Size = new System.Drawing.Size(164, 110);
            this.TmMenu.Text = "托盘菜单";
            // 
            // TiOpen
            // 
            this.TiOpen.Name = "TiOpen";
            this.TiOpen.Size = new System.Drawing.Size(163, 22);
            this.TiOpen.Text = "显示主界面(&O)";
            this.TiOpen.Click += new System.EventHandler(this.TiOpenClick);
            // 
            // SiSep0
            // 
            this.SiSep0.Name = "SiSep0";
            this.SiSep0.Size = new System.Drawing.Size(160, 6);
            // 
            // TuSln
            // 
            this.TuSln.Name = "TuSln";
            this.TuSln.Size = new System.Drawing.Size(163, 22);
            this.TuSln.Text = "方案(&S)";
            // 
            // TiSep1
            // 
            this.TiSep1.Name = "TiSep1";
            this.TiSep1.Size = new System.Drawing.Size(160, 6);
            // 
            // TiHide
            // 
            this.TiHide.Name = "TiHide";
            this.TiHide.Size = new System.Drawing.Size(163, 22);
            this.TiHide.Text = "最小化时隐藏(&H)";
            this.TiHide.Click += new System.EventHandler(this.TiHide_Click);
            // 
            // TiSep3
            // 
            this.TiSep3.Name = "TiSep3";
            this.TiSep3.Size = new System.Drawing.Size(160, 6);
            // 
            // TiExit
            // 
            this.TiExit.Name = "TiExit";
            this.TiExit.Size = new System.Drawing.Size(163, 22);
            this.TiExit.Text = "退出(&X)";
            this.TiExit.Click += new System.EventHandler(this.TiExitClick);
            // 
            // MiCreateSln
            // 
            this.MiCreateSln.Name = "MiCreateSln";
            this.MiCreateSln.Size = new System.Drawing.Size(164, 22);
            this.MiCreateSln.Text = "新建空白方案(&N)";
            this.MiCreateSln.Click += new System.EventHandler(this.MiCreateSln_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.LvItem);
            this.Controls.Add(this.TbTool);
            this.Controls.Add(this.SbEcho);
            this.Controls.Add(this.CbMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.CbMenu;
            this.Name = "Main";
            this.Text = "MyHosts";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.CbMenu.ResumeLayout(false);
            this.CbMenu.PerformLayout();
            this.TbTool.ResumeLayout(false);
            this.TbTool.PerformLayout();
            this.CmMenu.ResumeLayout(false);
            this.TmMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip SbEcho;
        private System.Windows.Forms.MenuStrip CbMenu;
        private System.Windows.Forms.ToolStrip TbTool;
        private System.Windows.Forms.ListView LvItem;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.NotifyIcon NiTray;
        private System.Windows.Forms.ContextMenuStrip TmMenu;
        private System.Windows.Forms.ColumnHeader ChIp;
        private System.Windows.Forms.ColumnHeader Chdomain;
        private System.Windows.Forms.ColumnHeader ChComment;
        private System.Windows.Forms.ToolStripMenuItem CiUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CmGroups;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem CiCreate;
        private System.Windows.Forms.ToolStripMenuItem CiRemove;
        private System.Windows.Forms.ToolStripButton TbSaveas;
        private System.Windows.Forms.ToolStripSeparator TbSep0;
        private System.Windows.Forms.ToolStripButton TbUpdate;
        private System.Windows.Forms.ToolStripButton TbCreate;
        private System.Windows.Forms.ToolStripButton TbRemove;
        private System.Windows.Forms.ToolStripSeparator TbSep1;
        private System.Windows.Forms.ToolStripButton TbReload;
        private System.Windows.Forms.ToolStripButton TbOpenas;
        private System.Windows.Forms.ToolStripSeparator TbSep2;
        private System.Windows.Forms.ToolStripButton TbComment;
        private System.Windows.Forms.ToolStripButton TbAbout;
        private System.Windows.Forms.ToolStripMenuItem MuFile;
        private System.Windows.Forms.ToolStripMenuItem MuEdit;
        private System.Windows.Forms.ToolStripMenuItem MuData;
        private System.Windows.Forms.ToolStripMenuItem MuHelp;
        private System.Windows.Forms.ToolStripMenuItem MiSaveas;
        private System.Windows.Forms.ToolStripSeparator MiFile0;
        private System.Windows.Forms.ToolStripMenuItem MiReload;
        private System.Windows.Forms.ToolStripMenuItem MiOpenas;
        private System.Windows.Forms.ToolStripSeparator MiFile1;
        private System.Windows.Forms.ToolStripMenuItem MiBackup;
        private System.Windows.Forms.ToolStripMenuItem MiResume;
        private System.Windows.Forms.ToolStripSeparator MiFile2;
        private System.Windows.Forms.ToolStripMenuItem MiExit;
        private System.Windows.Forms.ToolStripMenuItem MiCreate;
        private System.Windows.Forms.ToolStripMenuItem MiUpdate;
        private System.Windows.Forms.ToolStripMenuItem MiRemove;
        private System.Windows.Forms.ToolStripSeparator MiEdit0;
        private System.Windows.Forms.ToolStripMenuItem MiCreateGroup;
        private System.Windows.Forms.ToolStripMenuItem MiSaveasSln;
        private System.Windows.Forms.ToolStripMenuItem MiManageSln;
        private System.Windows.Forms.ToolStripSeparator MiData0;
        private System.Windows.Forms.ToolStripMenuItem MiAbout;
        private System.Windows.Forms.ToolStripMenuItem TiOpen;
        private System.Windows.Forms.ToolStripSeparator SiSep0;
        private System.Windows.Forms.ToolStripMenuItem TuSln;
        private System.Windows.Forms.ToolStripSeparator TiSep1;
        private System.Windows.Forms.ToolStripMenuItem TiExit;
        private System.Windows.Forms.ToolStripSeparator MiHelp0;
        private System.Windows.Forms.ToolStripMenuItem MiSite;
        private System.Windows.Forms.ToolStripMenuItem TiHide;
        private System.Windows.Forms.ToolStripSeparator TiSep3;
        private System.Windows.Forms.ToolStripMenuItem MiCreateSln;
    }
}


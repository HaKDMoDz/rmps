namespace Me.Amon.Pwd
{
    partial class APwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APwd));
            this.MsMenu = new System.Windows.Forms.MenuStrip();
            this.MiAmon = new System.Windows.Forms.ToolStripMenuItem();
            this.MiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MiData = new System.Windows.Forms.ToolStripMenuItem();
            this.MiUser = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSkin = new System.Windows.Forms.ToolStripMenuItem();
            this.MiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.CsCat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CsKey = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TcTool = new System.Windows.Forms.ToolStripContainer();
            this.HSplit = new System.Windows.Forms.SplitContainer();
            this.VSplit = new System.Windows.Forms.SplitContainer();
            this.TvCatView = new System.Windows.Forms.TreeView();
            this.LbKeyList = new System.Windows.Forms.ListBox();
            this.TsTool = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.SsInfo = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MsMenu.SuspendLayout();
            this.TcTool.ContentPanel.SuspendLayout();
            this.TcTool.TopToolStripPanel.SuspendLayout();
            this.TcTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HSplit)).BeginInit();
            this.HSplit.Panel1.SuspendLayout();
            this.HSplit.Panel2.SuspendLayout();
            this.HSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VSplit)).BeginInit();
            this.VSplit.Panel1.SuspendLayout();
            this.VSplit.Panel2.SuspendLayout();
            this.VSplit.SuspendLayout();
            this.TsTool.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MsMenu
            // 
            this.MsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiAmon,
            this.MiFile,
            this.MiEdit,
            this.MiData,
            this.MiUser,
            this.MiSkin,
            this.MiHelp});
            this.MsMenu.Location = new System.Drawing.Point(0, 0);
            this.MsMenu.Name = "MsMenu";
            this.MsMenu.Size = new System.Drawing.Size(624, 25);
            this.MsMenu.TabIndex = 0;
            this.MsMenu.Text = "menuStrip1";
            // 
            // MiAmon
            // 
            this.MiAmon.Name = "MiAmon";
            this.MiAmon.Size = new System.Drawing.Size(60, 21);
            this.MiAmon.Text = "系统(&A)";
            // 
            // MiFile
            // 
            this.MiFile.Name = "MiFile";
            this.MiFile.Size = new System.Drawing.Size(58, 21);
            this.MiFile.Text = "文件(&F)";
            // 
            // MiEdit
            // 
            this.MiEdit.Name = "MiEdit";
            this.MiEdit.Size = new System.Drawing.Size(59, 21);
            this.MiEdit.Text = "编辑(&E)";
            // 
            // MiData
            // 
            this.MiData.Name = "MiData";
            this.MiData.Size = new System.Drawing.Size(61, 21);
            this.MiData.Text = "数据(&D)";
            // 
            // MiUser
            // 
            this.MiUser.Name = "MiUser";
            this.MiUser.Size = new System.Drawing.Size(61, 21);
            this.MiUser.Text = "用户(&U)";
            // 
            // MiSkin
            // 
            this.MiSkin.Name = "MiSkin";
            this.MiSkin.Size = new System.Drawing.Size(59, 21);
            this.MiSkin.Text = "皮肤(&S)";
            // 
            // MiHelp
            // 
            this.MiHelp.Name = "MiHelp";
            this.MiHelp.Size = new System.Drawing.Size(61, 21);
            this.MiHelp.Text = "帮助(&H)";
            // 
            // CsCat
            // 
            this.CsCat.Name = "CsCat";
            this.CsCat.Size = new System.Drawing.Size(61, 4);
            // 
            // CsKey
            // 
            this.CsKey.Name = "CsCat";
            this.CsKey.Size = new System.Drawing.Size(61, 4);
            // 
            // TcTool
            // 
            // 
            // TcTool.ContentPanel
            // 
            this.TcTool.ContentPanel.Controls.Add(this.HSplit);
            this.TcTool.ContentPanel.Size = new System.Drawing.Size(624, 395);
            this.TcTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TcTool.Location = new System.Drawing.Point(0, 0);
            this.TcTool.Name = "TcTool";
            this.TcTool.Size = new System.Drawing.Size(624, 420);
            this.TcTool.TabIndex = 3;
            this.TcTool.Text = "toolStripContainer1";
            // 
            // TcTool.TopToolStripPanel
            // 
            this.TcTool.TopToolStripPanel.Controls.Add(this.TsTool);
            // 
            // HSplit
            // 
            this.HSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HSplit.Location = new System.Drawing.Point(12, 3);
            this.HSplit.Name = "HSplit";
            // 
            // HSplit.Panel1
            // 
            this.HSplit.Panel1.Controls.Add(this.VSplit);
            // 
            // HSplit.Panel2
            // 
            this.HSplit.Panel2.Controls.Add(this.panel1);
            this.HSplit.Size = new System.Drawing.Size(600, 389);
            this.HSplit.SplitterDistance = 200;
            this.HSplit.TabIndex = 0;
            // 
            // VSplit
            // 
            this.VSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VSplit.Location = new System.Drawing.Point(0, 0);
            this.VSplit.Name = "VSplit";
            this.VSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // VSplit.Panel1
            // 
            this.VSplit.Panel1.Controls.Add(this.TvCatView);
            // 
            // VSplit.Panel2
            // 
            this.VSplit.Panel2.Controls.Add(this.LbKeyList);
            this.VSplit.Size = new System.Drawing.Size(200, 389);
            this.VSplit.SplitterDistance = 197;
            this.VSplit.TabIndex = 0;
            // 
            // TvCatView
            // 
            this.TvCatView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvCatView.Location = new System.Drawing.Point(0, 0);
            this.TvCatView.Name = "TvCatView";
            this.TvCatView.Size = new System.Drawing.Size(200, 197);
            this.TvCatView.TabIndex = 0;
            this.TvCatView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvCatView_AfterSelect);
            // 
            // LbKeyList
            // 
            this.LbKeyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbKeyList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LbKeyList.FormattingEnabled = true;
            this.LbKeyList.ItemHeight = 12;
            this.LbKeyList.Location = new System.Drawing.Point(0, 0);
            this.LbKeyList.Name = "LbKeyList";
            this.LbKeyList.Size = new System.Drawing.Size(200, 188);
            this.LbKeyList.TabIndex = 0;
            this.LbKeyList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LbKeyList_DrawItem);
            // 
            // TsTool
            // 
            this.TsTool.Dock = System.Windows.Forms.DockStyle.None;
            this.TsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6});
            this.TsTool.Location = new System.Drawing.Point(3, 0);
            this.TsTool.Name = "TsTool";
            this.TsTool.Size = new System.Drawing.Size(156, 25);
            this.TsTool.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "toolStripButton6";
            // 
            // SsInfo
            // 
            this.SsInfo.Location = new System.Drawing.Point(0, 420);
            this.SsInfo.Name = "SsInfo";
            this.SsInfo.Size = new System.Drawing.Size(624, 22);
            this.SsInfo.TabIndex = 4;
            this.SsInfo.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 389);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 289);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(396, 100);
            this.panel2.TabIndex = 0;
            // 
            // APwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.MsMenu);
            this.Controls.Add(this.TcTool);
            this.Controls.Add(this.SsInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MsMenu;
            this.Name = "APwd";
            this.Text = "阿木密码箱";
            this.MsMenu.ResumeLayout(false);
            this.MsMenu.PerformLayout();
            this.TcTool.ContentPanel.ResumeLayout(false);
            this.TcTool.TopToolStripPanel.ResumeLayout(false);
            this.TcTool.TopToolStripPanel.PerformLayout();
            this.TcTool.ResumeLayout(false);
            this.TcTool.PerformLayout();
            this.HSplit.Panel1.ResumeLayout(false);
            this.HSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HSplit)).EndInit();
            this.HSplit.ResumeLayout(false);
            this.VSplit.Panel1.ResumeLayout(false);
            this.VSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VSplit)).EndInit();
            this.VSplit.ResumeLayout(false);
            this.TsTool.ResumeLayout(false);
            this.TsTool.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MsMenu;
        private System.Windows.Forms.ToolStripMenuItem MiAmon;
        private System.Windows.Forms.ToolStripMenuItem MiFile;
        private System.Windows.Forms.ToolStripMenuItem MiEdit;
        private System.Windows.Forms.ToolStripMenuItem MiData;
        private System.Windows.Forms.ToolStripMenuItem MiUser;
        private System.Windows.Forms.ToolStripMenuItem MiSkin;
        private System.Windows.Forms.ContextMenuStrip CsCat;
        private System.Windows.Forms.ContextMenuStrip CsKey;
        private System.Windows.Forms.ToolStripContainer TcTool;
        private System.Windows.Forms.ToolStrip TsTool;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripMenuItem MiHelp;
        private System.Windows.Forms.SplitContainer HSplit;
        private System.Windows.Forms.SplitContainer VSplit;
        private System.Windows.Forms.TreeView TvCatView;
        private System.Windows.Forms.ListBox LbKeyList;
        private System.Windows.Forms.StatusStrip SsInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
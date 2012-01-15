namespace Me.Amon.Pwd
{
    partial class Demo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Demo));
            this.TmMenu = new System.Windows.Forms.MenuStrip();
            this.TmuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.TmuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.TmuView = new System.Windows.Forms.ToolStripMenuItem();
            this.TmuData = new System.Windows.Forms.ToolStripMenuItem();
            this.TmuUser = new System.Windows.Forms.ToolStripMenuItem();
            this.TmuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.TcTool = new System.Windows.Forms.ToolStripContainer();
            this.SsInfo = new System.Windows.Forms.StatusStrip();
            this.TssInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.TsTool = new System.Windows.Forms.ToolStrip();
            this.TsbAppend = new System.Windows.Forms.ToolStripButton();
            this.HSplit = new System.Windows.Forms.SplitContainer();
            this.VSplit = new System.Windows.Forms.SplitContainer();
            this.TvCatTree = new System.Windows.Forms.TreeView();
            this.IlCatTree = new System.Windows.Forms.ImageList(this.components);
            this.LbKeyList = new System.Windows.Forms.ListBox();
            this.TpGrid = new System.Windows.Forms.TableLayoutPanel();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.TmMenu.SuspendLayout();
            this.TcTool.ContentPanel.SuspendLayout();
            this.TcTool.TopToolStripPanel.SuspendLayout();
            this.TcTool.SuspendLayout();
            this.SsInfo.SuspendLayout();
            this.TsTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HSplit)).BeginInit();
            this.HSplit.Panel1.SuspendLayout();
            this.HSplit.Panel2.SuspendLayout();
            this.HSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VSplit)).BeginInit();
            this.VSplit.Panel1.SuspendLayout();
            this.VSplit.Panel2.SuspendLayout();
            this.VSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // TmMenu
            // 
            this.TmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TmuFile,
            this.TmuEdit,
            this.TmuView,
            this.TmuData,
            this.TmuUser,
            this.TmuHelp});
            this.TmMenu.Location = new System.Drawing.Point(0, 0);
            this.TmMenu.Name = "TmMenu";
            this.TmMenu.Size = new System.Drawing.Size(584, 25);
            this.TmMenu.TabIndex = 0;
            this.TmMenu.Text = "menuStrip1";
            // 
            // TmuFile
            // 
            this.TmuFile.Name = "TmuFile";
            this.TmuFile.Size = new System.Drawing.Size(58, 21);
            this.TmuFile.Text = "文件(&F)";
            // 
            // TmuEdit
            // 
            this.TmuEdit.Name = "TmuEdit";
            this.TmuEdit.Size = new System.Drawing.Size(59, 21);
            this.TmuEdit.Text = "编辑(&E)";
            // 
            // TmuView
            // 
            this.TmuView.Name = "TmuView";
            this.TmuView.Size = new System.Drawing.Size(60, 21);
            this.TmuView.Text = "视图(&V)";
            // 
            // TmuData
            // 
            this.TmuData.Name = "TmuData";
            this.TmuData.Size = new System.Drawing.Size(61, 21);
            this.TmuData.Text = "数据(&D)";
            // 
            // TmuUser
            // 
            this.TmuUser.Name = "TmuUser";
            this.TmuUser.Size = new System.Drawing.Size(56, 21);
            this.TmuUser.Text = "用户(&I)";
            // 
            // TmuHelp
            // 
            this.TmuHelp.Name = "TmuHelp";
            this.TmuHelp.Size = new System.Drawing.Size(61, 21);
            this.TmuHelp.Text = "帮助(&H)";
            // 
            // TcTool
            // 
            // 
            // TcTool.ContentPanel
            // 
            this.TcTool.ContentPanel.Controls.Add(this.HSplit);
            this.TcTool.ContentPanel.Size = new System.Drawing.Size(584, 362);
            this.TcTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TcTool.Location = new System.Drawing.Point(0, 25);
            this.TcTool.Name = "TcTool";
            this.TcTool.Size = new System.Drawing.Size(584, 387);
            this.TcTool.TabIndex = 1;
            this.TcTool.Text = "toolStripContainer1";
            // 
            // TcTool.TopToolStripPanel
            // 
            this.TcTool.TopToolStripPanel.Controls.Add(this.TsTool);
            // 
            // SsInfo
            // 
            this.SsInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TssInfo});
            this.SsInfo.Location = new System.Drawing.Point(0, 390);
            this.SsInfo.Name = "SsInfo";
            this.SsInfo.Size = new System.Drawing.Size(584, 22);
            this.SsInfo.TabIndex = 2;
            this.SsInfo.Text = "statusStrip1";
            // 
            // TssInfo
            // 
            this.TssInfo.Name = "TssInfo";
            this.TssInfo.Size = new System.Drawing.Size(50, 17);
            this.TssInfo.Text = "TssInfo";
            // 
            // TsTool
            // 
            this.TsTool.Dock = System.Windows.Forms.DockStyle.None;
            this.TsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsbAppend});
            this.TsTool.Location = new System.Drawing.Point(3, 0);
            this.TsTool.Name = "TsTool";
            this.TsTool.Size = new System.Drawing.Size(35, 25);
            this.TsTool.TabIndex = 0;
            this.TsTool.EndDrag += new System.EventHandler(this.TsTool_EndDrag);
            // 
            // TsbAppend
            // 
            this.TsbAppend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbAppend.Image = ((System.Drawing.Image)(resources.GetObject("TsbAppend.Image")));
            this.TsbAppend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbAppend.Name = "TsbAppend";
            this.TsbAppend.Size = new System.Drawing.Size(23, 22);
            this.TsbAppend.Text = "toolStripButton1";
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
            this.HSplit.Panel2.Controls.Add(this.TpGrid);
            this.HSplit.Size = new System.Drawing.Size(560, 334);
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
            this.VSplit.Panel1.Controls.Add(this.TvCatTree);
            // 
            // VSplit.Panel2
            // 
            this.VSplit.Panel2.Controls.Add(this.LbKeyList);
            this.VSplit.Size = new System.Drawing.Size(200, 334);
            this.VSplit.SplitterDistance = 160;
            this.VSplit.TabIndex = 0;
            // 
            // TvCatTree
            // 
            this.TvCatTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvCatTree.ImageIndex = 0;
            this.TvCatTree.ImageList = this.IlCatTree;
            this.TvCatTree.Location = new System.Drawing.Point(0, 0);
            this.TvCatTree.Name = "TvCatTree";
            this.TvCatTree.SelectedImageIndex = 0;
            this.TvCatTree.Size = new System.Drawing.Size(200, 160);
            this.TvCatTree.TabIndex = 0;
            this.TvCatTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvCatTree_AfterSelect);
            // 
            // IlCatTree
            // 
            this.IlCatTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.IlCatTree.ImageSize = new System.Drawing.Size(16, 16);
            this.IlCatTree.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // LbKeyList
            // 
            this.LbKeyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbKeyList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LbKeyList.FormattingEnabled = true;
            this.LbKeyList.Location = new System.Drawing.Point(0, 0);
            this.LbKeyList.Name = "LbKeyList";
            this.LbKeyList.Size = new System.Drawing.Size(200, 170);
            this.LbKeyList.TabIndex = 0;
            this.LbKeyList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LbKeyList_DrawItem);
            this.LbKeyList.SelectedIndexChanged += new System.EventHandler(this.LbKeyList_SelectedIndexChanged);
            // 
            // TpGrid
            // 
            this.TpGrid.ColumnCount = 1;
            this.TpGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TpGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TpGrid.Location = new System.Drawing.Point(0, 0);
            this.TpGrid.Name = "TpGrid";
            this.TpGrid.RowCount = 2;
            this.TpGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.TpGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TpGrid.Size = new System.Drawing.Size(356, 334);
            this.TpGrid.TabIndex = 0;
            // 
            // Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.SsInfo);
            this.Controls.Add(this.TcTool);
            this.Controls.Add(this.TmMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.TmMenu;
            this.Name = "Demo";
            this.Text = "Demo";
            this.TmMenu.ResumeLayout(false);
            this.TmMenu.PerformLayout();
            this.TcTool.ContentPanel.ResumeLayout(false);
            this.TcTool.TopToolStripPanel.ResumeLayout(false);
            this.TcTool.TopToolStripPanel.PerformLayout();
            this.TcTool.ResumeLayout(false);
            this.TcTool.PerformLayout();
            this.SsInfo.ResumeLayout(false);
            this.SsInfo.PerformLayout();
            this.TsTool.ResumeLayout(false);
            this.TsTool.PerformLayout();
            this.HSplit.Panel1.ResumeLayout(false);
            this.HSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HSplit)).EndInit();
            this.HSplit.ResumeLayout(false);
            this.VSplit.Panel1.ResumeLayout(false);
            this.VSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VSplit)).EndInit();
            this.VSplit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip TmMenu;
        private System.Windows.Forms.ToolStripMenuItem TmuFile;
        private System.Windows.Forms.ToolStripMenuItem TmuEdit;
        private System.Windows.Forms.ToolStripMenuItem TmuView;
        private System.Windows.Forms.ToolStripMenuItem TmuData;
        private System.Windows.Forms.ToolStripMenuItem TmuUser;
        private System.Windows.Forms.ToolStripMenuItem TmuHelp;
        private System.Windows.Forms.ToolStripContainer TcTool;
        private System.Windows.Forms.StatusStrip SsInfo;
        private System.Windows.Forms.ToolStripStatusLabel TssInfo;
        private System.Windows.Forms.ToolStrip TsTool;
        private System.Windows.Forms.ToolStripButton TsbAppend;
        private System.Windows.Forms.SplitContainer HSplit;
        private System.Windows.Forms.SplitContainer VSplit;
        private System.Windows.Forms.TreeView TvCatTree;
        private System.Windows.Forms.ImageList IlCatTree;
        private System.Windows.Forms.ListBox LbKeyList;
        private System.Windows.Forms.TableLayoutPanel TpGrid;
        private System.Windows.Forms.ToolTip TpTips;
    }
}
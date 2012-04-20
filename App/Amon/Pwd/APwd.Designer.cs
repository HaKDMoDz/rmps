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
            this.TmMenu = new System.Windows.Forms.MenuStrip();
            this.SsEcho = new System.Windows.Forms.StatusStrip();
            this.TcTool = new System.Windows.Forms.ToolStripContainer();
            this.HSplit = new System.Windows.Forms.SplitContainer();
            this.VSplit = new System.Windows.Forms.SplitContainer();
            this.TvCatTree = new System.Windows.Forms.TreeView();
            this.IlCatTree = new System.Windows.Forms.ImageList(this.components);
            this.LbKeyList = new System.Windows.Forms.ListBox();
            this.TbTool = new System.Windows.Forms.ToolStrip();
            this.PlBody = new System.Windows.Forms.Panel();
            this.CmCat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CmKey = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.UcTime = new System.Windows.Forms.Timer(this.components);
            this.TssEcho = new System.Windows.Forms.ToolStripStatusLabel();
            this.TssTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.SsEcho.SuspendLayout();
            this.TcTool.ContentPanel.SuspendLayout();
            this.TcTool.TopToolStripPanel.SuspendLayout();
            this.TcTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HSplit)).BeginInit();
            this.HSplit.Panel1.SuspendLayout();
            this.HSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VSplit)).BeginInit();
            this.VSplit.Panel1.SuspendLayout();
            this.VSplit.Panel2.SuspendLayout();
            this.VSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // TmMenu
            // 
            this.TmMenu.Location = new System.Drawing.Point(0, 0);
            this.TmMenu.Name = "TmMenu";
            this.TmMenu.Size = new System.Drawing.Size(584, 24);
            this.TmMenu.TabIndex = 0;
            this.TmMenu.Text = "menuStrip1";
            // 
            // SsEcho
            // 
            this.SsEcho.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TssEcho,
            this.TssTime});
            this.SsEcho.Location = new System.Drawing.Point(0, 390);
            this.SsEcho.Name = "SsEcho";
            this.SsEcho.Size = new System.Drawing.Size(584, 22);
            this.SsEcho.TabIndex = 1;
            this.SsEcho.Text = "statusStrip1";
            // 
            // TcTool
            // 
            // 
            // TcTool.ContentPanel
            // 
            this.TcTool.ContentPanel.Controls.Add(this.HSplit);
            this.TcTool.ContentPanel.Size = new System.Drawing.Size(584, 341);
            this.TcTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TcTool.Location = new System.Drawing.Point(0, 24);
            this.TcTool.Name = "TcTool";
            this.TcTool.Size = new System.Drawing.Size(584, 366);
            this.TcTool.TabIndex = 2;
            this.TcTool.Text = "toolStripContainer1";
            // 
            // TcTool.TopToolStripPanel
            // 
            this.TcTool.TopToolStripPanel.Controls.Add(this.TbTool);
            // 
            // HSplit
            // 
            this.HSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HSplit.Location = new System.Drawing.Point(10, 10);
            this.HSplit.Name = "HSplit";
            // 
            // HSplit.Panel1
            // 
            this.HSplit.Panel1.Controls.Add(this.VSplit);
            this.HSplit.Size = new System.Drawing.Size(564, 321);
            this.HSplit.SplitterDistance = 188;
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
            this.VSplit.Size = new System.Drawing.Size(188, 321);
            this.VSplit.SplitterDistance = 151;
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
            this.TvCatTree.Size = new System.Drawing.Size(188, 151);
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
            this.LbKeyList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.LbKeyList.FormattingEnabled = true;
            this.LbKeyList.Location = new System.Drawing.Point(0, 0);
            this.LbKeyList.Name = "LbKeyList";
            this.LbKeyList.Size = new System.Drawing.Size(188, 166);
            this.LbKeyList.TabIndex = 0;
            this.LbKeyList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LbKeyList_DrawItem);
            this.LbKeyList.SelectedIndexChanged += new System.EventHandler(this.LbKeyList_SelectedIndexChanged);
            // 
            // TbTool
            // 
            this.TbTool.Dock = System.Windows.Forms.DockStyle.None;
            this.TbTool.Location = new System.Drawing.Point(3, 0);
            this.TbTool.Name = "TbTool";
            this.TbTool.Size = new System.Drawing.Size(111, 25);
            this.TbTool.TabIndex = 0;
            this.TbTool.EndDrag += new System.EventHandler(this.TbTool_EndDrag);
            // 
            // PlBody
            // 
            this.PlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlBody.Location = new System.Drawing.Point(0, 29);
            this.PlBody.Name = "PlBody";
            this.PlBody.Size = new System.Drawing.Size(372, 292);
            this.PlBody.TabIndex = 1;
            // 
            // CmCat
            // 
            this.CmCat.Name = "contextMenuStrip1";
            this.CmCat.Size = new System.Drawing.Size(61, 4);
            // 
            // CmKey
            // 
            this.CmKey.Name = "CmKey";
            this.CmKey.Size = new System.Drawing.Size(61, 4);
            // 
            // TssEcho
            // 
            this.TssEcho.Name = "TssEcho";
            this.TssEcho.Size = new System.Drawing.Size(482, 17);
            this.TssEcho.Spring = true;
            this.TssEcho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TssTime
            // 
            this.TssTime.Name = "TssTime";
            this.TssTime.Size = new System.Drawing.Size(56, 17);
            this.TssTime.Text = "当前时间";
            // 
            // APwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.TcTool);
            this.Controls.Add(this.SsEcho);
            this.Controls.Add(this.TmMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.TmMenu;
            this.Name = "APwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "阿木密码箱";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.APwd_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.APwd_KeyDown);
            this.SsEcho.ResumeLayout(false);
            this.SsEcho.PerformLayout();
            this.TcTool.ContentPanel.ResumeLayout(false);
            this.TcTool.TopToolStripPanel.ResumeLayout(false);
            this.TcTool.TopToolStripPanel.PerformLayout();
            this.TcTool.ResumeLayout(false);
            this.TcTool.PerformLayout();
            this.HSplit.Panel1.ResumeLayout(false);
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
        private System.Windows.Forms.StatusStrip SsEcho;
        private System.Windows.Forms.ToolStripContainer TcTool;
        private System.Windows.Forms.SplitContainer HSplit;
        private System.Windows.Forms.SplitContainer VSplit;
        private System.Windows.Forms.Panel PlBody;
        private Bean.FindBar FbFind;
        private System.Windows.Forms.ToolStrip TbTool;
        private System.Windows.Forms.TreeView TvCatTree;
        private System.Windows.Forms.ListBox LbKeyList;
        private System.Windows.Forms.ImageList IlCatTree;
        private System.Windows.Forms.ContextMenuStrip CmCat;
        private System.Windows.Forms.ContextMenuStrip CmKey;
        private System.Windows.Forms.ToolTip TpTips;
        private System.Windows.Forms.Timer UcTime;
        private System.Windows.Forms.ToolStripStatusLabel TssEcho;
        private System.Windows.Forms.ToolStripStatusLabel TssTime;

    }
}
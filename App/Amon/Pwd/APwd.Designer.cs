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
            this.MbMenu = new System.Windows.Forms.MenuStrip();
            this.SsEcho = new System.Windows.Forms.StatusStrip();
            this.TssEcho = new System.Windows.Forms.ToolStripStatusLabel();
            this.TssTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.PlMain = new System.Windows.Forms.Panel();
            this.TcTool = new System.Windows.Forms.ToolStripContainer();
            this.CmCat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.IlCatTree = new System.Windows.Forms.ImageList(this.components);
            this.TbTool = new System.Windows.Forms.ToolStrip();
            this.CmKey = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.UcTimer = new System.Windows.Forms.Timer(this.components);
            this.BgWorker = new System.ComponentModel.BackgroundWorker();
            this.SsEcho.SuspendLayout();
            this.PlMain.SuspendLayout();
            this.TcTool.TopToolStripPanel.SuspendLayout();
            this.TcTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // MbMenu
            // 
            this.MbMenu.Location = new System.Drawing.Point(0, 0);
            this.MbMenu.Name = "MbMenu";
            this.MbMenu.Size = new System.Drawing.Size(584, 24);
            this.MbMenu.TabIndex = 0;
            this.MbMenu.Text = "menuStrip1";
            // 
            // SsEcho
            // 
            this.SsEcho.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TssEcho,
            this.TssTime});
            this.SsEcho.Location = new System.Drawing.Point(0, 420);
            this.SsEcho.Name = "SsEcho";
            this.SsEcho.Size = new System.Drawing.Size(584, 22);
            this.SsEcho.TabIndex = 1;
            this.SsEcho.Text = "statusStrip1";
            // 
            // TssEcho
            // 
            this.TssEcho.DoubleClickEnabled = true;
            this.TssEcho.Name = "TssEcho";
            this.TssEcho.Size = new System.Drawing.Size(513, 17);
            this.TssEcho.Spring = true;
            this.TssEcho.Text = "系统处理中，请稍后……";
            this.TssEcho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TssEcho.DoubleClick += new System.EventHandler(this.TssEcho_DoubleClick);
            // 
            // TssTime
            // 
            this.TssTime.Name = "TssTime";
            this.TssTime.Size = new System.Drawing.Size(56, 17);
            this.TssTime.Text = "当前时间";
            // 
            // PlMain
            // 
            this.PlMain.Controls.Add(this.TcTool);
            this.PlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlMain.Location = new System.Drawing.Point(0, 24);
            this.PlMain.Name = "PlMain";
            this.PlMain.Size = new System.Drawing.Size(584, 396);
            this.PlMain.TabIndex = 2;
            // 
            // TcTool
            // 
            // 
            // TcTool.ContentPanel
            // 
            this.TcTool.ContentPanel.Size = new System.Drawing.Size(584, 371);
            this.TcTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TcTool.Location = new System.Drawing.Point(0, 0);
            this.TcTool.Name = "TcTool";
            this.TcTool.Size = new System.Drawing.Size(584, 396);
            this.TcTool.TabIndex = 0;
            this.TcTool.Text = "toolStripContainer1";
            // 
            // TcTool.TopToolStripPanel
            // 
            this.TcTool.TopToolStripPanel.Controls.Add(this.TbTool);
            // 
            // CmCat
            // 
            this.CmCat.Name = "contextMenuStrip1";
            this.CmCat.Size = new System.Drawing.Size(61, 4);
            // 
            // IlCatTree
            // 
            this.IlCatTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.IlCatTree.ImageSize = new System.Drawing.Size(16, 16);
            this.IlCatTree.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // TbTool
            // 
            this.TbTool.Dock = System.Windows.Forms.DockStyle.None;
            this.TbTool.Location = new System.Drawing.Point(3, 0);
            this.TbTool.Name = "TbTool";
            this.TbTool.Size = new System.Drawing.Size(111, 25);
            this.TbTool.TabIndex = 0;
            // 
            // CmKey
            // 
            this.CmKey.Name = "CmKey";
            this.CmKey.Size = new System.Drawing.Size(61, 4);
            // 
            // UcTimer
            // 
            this.UcTimer.Tick += new System.EventHandler(this.UcTime_Tick);
            // 
            // BgWorker
            // 
            this.BgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgWorker_DoWork);
            // 
            // APwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 442);
            this.Controls.Add(this.PlMain);
            this.Controls.Add(this.SsEcho);
            this.Controls.Add(this.MbMenu);
            this.MainMenuStrip = this.MbMenu;
            this.Name = "APwd";
            this.Text = "阿木密码箱";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.APwd_FormClosing);
            this.Load += new System.EventHandler(this.APwd_Load);
            this.Resize += new System.EventHandler(this.APwd_Resize);
            this.SsEcho.ResumeLayout(false);
            this.SsEcho.PerformLayout();
            this.PlMain.ResumeLayout(false);
            this.TcTool.TopToolStripPanel.ResumeLayout(false);
            this.TcTool.TopToolStripPanel.PerformLayout();
            this.TcTool.ResumeLayout(false);
            this.TcTool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MbMenu;
        private System.Windows.Forms.StatusStrip SsEcho;
        private System.Windows.Forms.Panel PlMain;
        private System.Windows.Forms.ToolStripContainer TcTool;
        private System.Windows.Forms.ToolStrip TbTool;
        private System.Windows.Forms.ImageList IlCatTree;
        private System.Windows.Forms.ContextMenuStrip CmCat;
        private System.Windows.Forms.ContextMenuStrip CmKey;
        private System.Windows.Forms.ToolTip TpTips;
        private System.Windows.Forms.Timer UcTimer;
        private System.Windows.Forms.ToolStripStatusLabel TssEcho;
        private System.Windows.Forms.ToolStripStatusLabel TssTime;
        private System.ComponentModel.BackgroundWorker BgWorker;

    }
}
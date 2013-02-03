namespace Me.Amon.Pwd
{
    partial class WPwd
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
            this.SbEcho = new System.Windows.Forms.StatusStrip();
            this.TlEcho = new System.Windows.Forms.ToolStripStatusLabel();
            this.TlSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.TlTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.TlSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.TlLayout0 = new System.Windows.Forms.ToolStripButton();
            this.TlLayout1 = new System.Windows.Forms.ToolStripButton();
            this.TlLayout2 = new System.Windows.Forms.ToolStripButton();
            this.MbMenu = new System.Windows.Forms.MenuStrip();
            this.TcMain = new System.Windows.Forms.ToolStripContainer();
            this.ScMain = new System.Windows.Forms.SplitContainer();
            this.ScGuid = new System.Windows.Forms.SplitContainer();
            this.ScData = new System.Windows.Forms.SplitContainer();
            this.UcFind = new Me.Amon.Pwd.V.FindBar();
            this.TbTool = new System.Windows.Forms.ToolStrip();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.BgWorker = new System.ComponentModel.BackgroundWorker();
            this.UcTimer = new System.Windows.Forms.Timer(this.components);
            this.SbEcho.SuspendLayout();
            this.TcMain.ContentPanel.SuspendLayout();
            this.TcMain.TopToolStripPanel.SuspendLayout();
            this.TcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).BeginInit();
            this.ScMain.Panel1.SuspendLayout();
            this.ScMain.Panel2.SuspendLayout();
            this.ScMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScGuid)).BeginInit();
            this.ScGuid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScData)).BeginInit();
            this.ScData.SuspendLayout();
            this.SuspendLayout();
            // 
            // SbEcho
            // 
            this.SbEcho.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TlEcho,
            this.TlSep0,
            this.TlTime,
            this.TlSep1,
            this.TlLayout0,
            this.TlLayout1,
            this.TlLayout2});
            this.SbEcho.Location = new System.Drawing.Point(0, 419);
            this.SbEcho.Name = "SbEcho";
            this.SbEcho.Size = new System.Drawing.Size(584, 23);
            this.SbEcho.TabIndex = 0;
            this.SbEcho.Text = "状态栏";
            // 
            // TlEcho
            // 
            this.TlEcho.Name = "TlEcho";
            this.TlEcho.Size = new System.Drawing.Size(433, 18);
            this.TlEcho.Spring = true;
            this.TlEcho.Text = "系统处理中，请稍候……";
            this.TlEcho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TlEcho.Click += new System.EventHandler(this.TlEcho_DoubleClick);
            // 
            // TlSep0
            // 
            this.TlSep0.Name = "TlSep0";
            this.TlSep0.Size = new System.Drawing.Size(6, 23);
            // 
            // TlTime
            // 
            this.TlTime.Name = "TlTime";
            this.TlTime.Size = new System.Drawing.Size(55, 18);
            this.TlTime.Text = "当前时间";
            this.TlTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TlTime.ToolTipText = "当前时间";
            // 
            // TlSep1
            // 
            this.TlSep1.Name = "TlSep1";
            this.TlSep1.Size = new System.Drawing.Size(6, 23);
            // 
            // TlLayout0
            // 
            this.TlLayout0.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TlLayout0.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TlLayout0.Name = "TlLayout0";
            this.TlLayout0.Size = new System.Drawing.Size(23, 21);
            this.TlLayout0.Text = "默认视图";
            this.TlLayout0.Click += new System.EventHandler(this.TlLayout0_Click);
            // 
            // TlLayout1
            // 
            this.TlLayout1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TlLayout1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TlLayout1.Name = "TlLayout1";
            this.TlLayout1.Size = new System.Drawing.Size(23, 21);
            this.TlLayout1.Text = "紧凑视图";
            this.TlLayout1.Click += new System.EventHandler(this.TlLayout1_Click);
            // 
            // TlLayout2
            // 
            this.TlLayout2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TlLayout2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TlLayout2.Name = "TlLayout2";
            this.TlLayout2.Size = new System.Drawing.Size(23, 21);
            this.TlLayout2.Text = "三列视图";
            this.TlLayout2.Click += new System.EventHandler(this.TlLayout2_Click);
            // 
            // MbMenu
            // 
            this.MbMenu.Location = new System.Drawing.Point(0, 0);
            this.MbMenu.Name = "MbMenu";
            this.MbMenu.Size = new System.Drawing.Size(584, 24);
            this.MbMenu.TabIndex = 1;
            this.MbMenu.Text = "菜单栏";
            // 
            // TcMain
            // 
            // 
            // TcMain.ContentPanel
            // 
            this.TcMain.ContentPanel.Controls.Add(this.ScMain);
            this.TcMain.ContentPanel.Size = new System.Drawing.Size(584, 370);
            this.TcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TcMain.Location = new System.Drawing.Point(0, 24);
            this.TcMain.Name = "TcMain";
            this.TcMain.Size = new System.Drawing.Size(584, 395);
            this.TcMain.TabIndex = 2;
            this.TcMain.Text = "toolStripContainer1";
            // 
            // TcMain.TopToolStripPanel
            // 
            this.TcMain.TopToolStripPanel.Controls.Add(this.TbTool);
            // 
            // ScMain
            // 
            this.ScMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ScMain.Location = new System.Drawing.Point(3, 3);
            this.ScMain.Name = "ScMain";
            // 
            // ScMain.Panel1
            // 
            this.ScMain.Panel1.Controls.Add(this.ScGuid);
            this.ScMain.Panel1MinSize = 120;
            // 
            // ScMain.Panel2
            // 
            this.ScMain.Panel2.Controls.Add(this.ScData);
            this.ScMain.Panel2.Controls.Add(this.UcFind);
            this.ScMain.Size = new System.Drawing.Size(578, 364);
            this.ScMain.SplitterDistance = 200;
            this.ScMain.TabIndex = 0;
            // 
            // ScGuid
            // 
            this.ScGuid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScGuid.Location = new System.Drawing.Point(0, 0);
            this.ScGuid.Name = "ScGuid";
            this.ScGuid.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ScGuid.Size = new System.Drawing.Size(200, 364);
            this.ScGuid.SplitterDistance = 179;
            this.ScGuid.TabIndex = 0;
            // 
            // ScData
            // 
            this.ScData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScData.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ScData.Location = new System.Drawing.Point(0, 29);
            this.ScData.Name = "ScData";
            this.ScData.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.ScData.Size = new System.Drawing.Size(374, 335);
            this.ScData.SplitterDistance = 80;
            this.ScData.TabIndex = 1;
            // 
            // UcFind
            // 
            this.UcFind.Dock = System.Windows.Forms.DockStyle.Top;
            this.UcFind.KeyList = null;
            this.UcFind.Location = new System.Drawing.Point(0, 0);
            this.UcFind.Name = "UcFind";
            this.UcFind.Size = new System.Drawing.Size(374, 29);
            this.UcFind.TabIndex = 0;
            // 
            // TbTool
            // 
            this.TbTool.Dock = System.Windows.Forms.DockStyle.None;
            this.TbTool.Location = new System.Drawing.Point(3, 0);
            this.TbTool.Name = "TbTool";
            this.TbTool.Size = new System.Drawing.Size(111, 25);
            this.TbTool.TabIndex = 0;
            this.TbTool.Text = "工具栏";
            // 
            // BgWorker
            // 
            this.BgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgWorker_DoWork);
            // 
            // UcTimer
            // 
            this.UcTimer.Interval = 200;
            this.UcTimer.Tick += new System.EventHandler(this.UcTimer_Tick);
            // 
            // WPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 442);
            this.Controls.Add(this.TcMain);
            this.Controls.Add(this.SbEcho);
            this.Controls.Add(this.MbMenu);
            this.MainMenuStrip = this.MbMenu;
            this.Name = "WPwd";
            this.Text = "阿木密码箱";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WPwd_FormClosing);
            this.Load += new System.EventHandler(this.WPwd_Load);
            this.Resize += new System.EventHandler(this.WPwd_Resize);
            this.SbEcho.ResumeLayout(false);
            this.SbEcho.PerformLayout();
            this.TcMain.ContentPanel.ResumeLayout(false);
            this.TcMain.TopToolStripPanel.ResumeLayout(false);
            this.TcMain.TopToolStripPanel.PerformLayout();
            this.TcMain.ResumeLayout(false);
            this.TcMain.PerformLayout();
            this.ScMain.Panel1.ResumeLayout(false);
            this.ScMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).EndInit();
            this.ScMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScGuid)).EndInit();
            this.ScGuid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScData)).EndInit();
            this.ScData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip SbEcho;
        private System.Windows.Forms.MenuStrip MbMenu;
        private System.Windows.Forms.ToolStripContainer TcMain;
        private System.Windows.Forms.ToolStrip TbTool;
        private System.Windows.Forms.SplitContainer ScMain;
        private System.Windows.Forms.SplitContainer ScGuid;
        private Me.Amon.Pwd.V.FindBar UcFind;
        private System.Windows.Forms.SplitContainer ScData;
        private System.Windows.Forms.ToolTip TpTips;
        private System.ComponentModel.BackgroundWorker BgWorker;
        private System.Windows.Forms.ToolStripStatusLabel TlEcho;
        private System.Windows.Forms.ToolStripStatusLabel TlTime;
        private System.Windows.Forms.ToolStripSeparator TlSep0;
        private System.Windows.Forms.ToolStripSeparator TlSep1;
        private System.Windows.Forms.ToolStripButton TlLayout0;
        private System.Windows.Forms.ToolStripButton TlLayout1;
        private System.Windows.Forms.ToolStripButton TlLayout2;
        private System.Windows.Forms.Timer UcTimer;
    }
}
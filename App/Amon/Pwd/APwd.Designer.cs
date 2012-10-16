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
            this.SbEcho = new System.Windows.Forms.StatusStrip();
            this.TlEcho = new System.Windows.Forms.ToolStripStatusLabel();
            this.TlTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.TcTool = new System.Windows.Forms.ToolStripContainer();
            this.PlMain = new System.Windows.Forms.Panel();
            this.TbTool = new System.Windows.Forms.ToolStrip();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.BgWorker = new System.ComponentModel.BackgroundWorker();
            this.SbEcho.SuspendLayout();
            this.TcTool.ContentPanel.SuspendLayout();
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
            this.MbMenu.Text = "菜单栏";
            // 
            // SbEcho
            // 
            this.SbEcho.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TlEcho,
            this.TlTime});
            this.SbEcho.Location = new System.Drawing.Point(0, 420);
            this.SbEcho.Name = "SbEcho";
            this.SbEcho.Size = new System.Drawing.Size(584, 22);
            this.SbEcho.TabIndex = 1;
            this.SbEcho.Text = "状态栏";
            // 
            // TlEcho
            // 
            this.TlEcho.Name = "TlEcho";
            this.TlEcho.Size = new System.Drawing.Size(513, 17);
            this.TlEcho.Spring = true;
            this.TlEcho.Text = "系统处理中，请稍后……";
            this.TlEcho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TlTime
            // 
            this.TlTime.Name = "TlTime";
            this.TlTime.Size = new System.Drawing.Size(56, 17);
            this.TlTime.Text = "当前时间";
            this.TlTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TcTool
            // 
            // 
            // TcTool.ContentPanel
            // 
            this.TcTool.ContentPanel.Controls.Add(this.PlMain);
            this.TcTool.ContentPanel.Size = new System.Drawing.Size(584, 371);
            this.TcTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TcTool.Location = new System.Drawing.Point(0, 24);
            this.TcTool.Name = "TcTool";
            this.TcTool.Size = new System.Drawing.Size(584, 396);
            this.TcTool.TabIndex = 2;
            this.TcTool.Text = "主窗体";
            // 
            // TcTool.TopToolStripPanel
            // 
            this.TcTool.TopToolStripPanel.Controls.Add(this.TbTool);
            // 
            // PlMain
            // 
            this.PlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PlMain.Location = new System.Drawing.Point(12, 3);
            this.PlMain.Name = "PlMain";
            this.PlMain.Size = new System.Drawing.Size(560, 365);
            this.PlMain.TabIndex = 0;
            // 
            // TbTool
            // 
            this.TbTool.Dock = System.Windows.Forms.DockStyle.None;
            this.TbTool.Location = new System.Drawing.Point(3, 0);
            this.TbTool.Name = "TbTool";
            this.TbTool.Size = new System.Drawing.Size(111, 25);
            this.TbTool.TabIndex = 0;
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
            this.Controls.Add(this.TcTool);
            this.Controls.Add(this.SbEcho);
            this.Controls.Add(this.MbMenu);
            this.MainMenuStrip = this.MbMenu;
            this.Name = "APwd";
            this.Text = "阿木密码箱";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.APwd_FormClosing);
            this.Load += new System.EventHandler(this.APwd_Load);
            this.Resize += new System.EventHandler(this.APwd_Resize);
            this.SbEcho.ResumeLayout(false);
            this.SbEcho.PerformLayout();
            this.TcTool.ContentPanel.ResumeLayout(false);
            this.TcTool.TopToolStripPanel.ResumeLayout(false);
            this.TcTool.TopToolStripPanel.PerformLayout();
            this.TcTool.ResumeLayout(false);
            this.TcTool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MbMenu;
        private System.Windows.Forms.StatusStrip SbEcho;
        private System.Windows.Forms.ToolStripStatusLabel TlEcho;
        private System.Windows.Forms.ToolStripStatusLabel TlTime;
        private System.Windows.Forms.ToolStripContainer TcTool;
        private System.Windows.Forms.ToolStrip TbTool;
        private System.Windows.Forms.ToolTip TpTips;
        private System.ComponentModel.BackgroundWorker BgWorker;
        private System.Windows.Forms.Panel PlMain;

    }
}
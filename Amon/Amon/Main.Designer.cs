namespace Me.Amon
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
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.BgWorker = new System.Windows.Forms.Timer(this.components);
            this.NiTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.CtMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MtGuid = new System.Windows.Forms.ToolStripMenuItem();
            this.MtSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.MtAPwd = new System.Windows.Forms.ToolStripMenuItem();
            this.MtASec = new System.Windows.Forms.ToolStripMenuItem();
            this.MtSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MtExit = new System.Windows.Forms.ToolStripMenuItem();
            this.CgMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MgTray = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.MgAPwd = new System.Windows.Forms.ToolStripMenuItem();
            this.MgASec = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MgTopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.MgExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            this.CtMenu.SuspendLayout();
            this.CgMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PbLogo
            // 
            this.PbLogo.Location = new System.Drawing.Point(0, 0);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(25, 25);
            this.PbLogo.TabIndex = 2;
            this.PbLogo.TabStop = false;
            // 
            // BgWorker
            // 
            this.BgWorker.Tick += new System.EventHandler(this.BgWorker_Tick);
            // 
            // NiTray
            // 
            this.NiTray.BalloonTipTitle = "阿木提示";
            this.NiTray.ContextMenuStrip = this.CtMenu;
            this.NiTray.Icon = ((System.Drawing.Icon)(resources.GetObject("NiTray.Icon")));
            this.NiTray.Text = "阿木导航";
            this.NiTray.Visible = true;
            this.NiTray.DoubleClick += new System.EventHandler(this.NiTray_DoubleClick);
            // 
            // CtMenu
            // 
            this.CtMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MtGuid,
            this.MtSep0,
            this.MtAPwd,
            this.MtASec,
            this.MtSep1,
            this.MtExit});
            this.CtMenu.Name = "CtMenu";
            this.CtMenu.Size = new System.Drawing.Size(166, 126);
            // 
            // MtGuid
            // 
            this.MtGuid.Checked = true;
            this.MtGuid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MtGuid.Name = "MtGuid";
            this.MtGuid.Size = new System.Drawing.Size(165, 22);
            this.MtGuid.Text = "显示导航窗口(&G)";
            this.MtGuid.Click += new System.EventHandler(this.MtGuid_Click);
            // 
            // MtSep0
            // 
            this.MtSep0.Name = "MtSep0";
            this.MtSep0.Size = new System.Drawing.Size(162, 6);
            // 
            // MtAPwd
            // 
            this.MtAPwd.Name = "MtAPwd";
            this.MtAPwd.Size = new System.Drawing.Size(165, 22);
            this.MtAPwd.Text = "密码箱(&P)";
            this.MtAPwd.Click += new System.EventHandler(this.MtAPwd_Click);
            // 
            // MtASec
            // 
            this.MtASec.Name = "MtASec";
            this.MtASec.Size = new System.Drawing.Size(165, 22);
            this.MtASec.Text = "加密器(&S)";
            this.MtASec.Click += new System.EventHandler(this.MtASec_Click);
            // 
            // MtSep1
            // 
            this.MtSep1.Name = "MtSep1";
            this.MtSep1.Size = new System.Drawing.Size(162, 6);
            // 
            // MtExit
            // 
            this.MtExit.Name = "MtExit";
            this.MtExit.Size = new System.Drawing.Size(165, 22);
            this.MtExit.Text = "退出(&X)";
            this.MtExit.Click += new System.EventHandler(this.MtExit_Click);
            // 
            // CgMenu
            // 
            this.CgMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MgTray,
            this.MgSep0,
            this.MgAPwd,
            this.MgASec,
            this.MgSep1,
            this.MgTopMost,
            this.MgSep2,
            this.MgExit});
            this.CgMenu.Name = "CmMenu";
            this.CgMenu.Size = new System.Drawing.Size(164, 132);
            // 
            // MgTray
            // 
            this.MgTray.Checked = true;
            this.MgTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MgTray.Name = "MgTray";
            this.MgTray.Size = new System.Drawing.Size(163, 22);
            this.MgTray.Text = "显示托盘图标(&T)";
            this.MgTray.Click += new System.EventHandler(this.MgTray_Click);
            // 
            // MgSep0
            // 
            this.MgSep0.Name = "MgSep0";
            this.MgSep0.Size = new System.Drawing.Size(160, 6);
            // 
            // MgAPwd
            // 
            this.MgAPwd.Name = "MgAPwd";
            this.MgAPwd.Size = new System.Drawing.Size(163, 22);
            this.MgAPwd.Text = "密码箱(&P)";
            this.MgAPwd.Click += new System.EventHandler(this.MgAPwd_Click);
            // 
            // MgASec
            // 
            this.MgASec.Name = "MgASec";
            this.MgASec.Size = new System.Drawing.Size(163, 22);
            this.MgASec.Text = "加密器(&S)";
            this.MgASec.Click += new System.EventHandler(this.MgASec_Click);
            // 
            // MgSep1
            // 
            this.MgSep1.Name = "MgSep1";
            this.MgSep1.Size = new System.Drawing.Size(160, 6);
            // 
            // MgTopMost
            // 
            this.MgTopMost.Checked = true;
            this.MgTopMost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MgTopMost.Name = "MgTopMost";
            this.MgTopMost.Size = new System.Drawing.Size(163, 22);
            this.MgTopMost.Text = "窗口置项(&T)";
            this.MgTopMost.Click += new System.EventHandler(this.MgTopMost_Click);
            // 
            // MgSep2
            // 
            this.MgSep2.Name = "MgSep2";
            this.MgSep2.Size = new System.Drawing.Size(160, 6);
            // 
            // MgExit
            // 
            this.MgExit.Name = "MgExit";
            this.MgExit.Size = new System.Drawing.Size(163, 22);
            this.MgExit.Text = "退出(&X)";
            this.MgExit.Click += new System.EventHandler(this.MgExit_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(25, 25);
            this.ContextMenuStrip = this.CgMenu;
            this.Controls.Add(this.PbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "登录";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            this.CtMenu.ResumeLayout(false);
            this.CgMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.Timer BgWorker;
        private System.Windows.Forms.NotifyIcon NiTray;
        private System.Windows.Forms.ContextMenuStrip CgMenu;
        private System.Windows.Forms.ToolStripMenuItem MgTopMost;
        private System.Windows.Forms.ToolStripMenuItem MgTray;
        private System.Windows.Forms.ToolStripMenuItem MgExit;
        private System.Windows.Forms.ContextMenuStrip CtMenu;
        private System.Windows.Forms.ToolStripSeparator MgSep0;
        private System.Windows.Forms.ToolStripSeparator MgSep1;
        private System.Windows.Forms.ToolStripMenuItem MgAPwd;
        private System.Windows.Forms.ToolStripMenuItem MgASec;
        private System.Windows.Forms.ToolStripSeparator MgSep2;
        private System.Windows.Forms.ToolStripMenuItem MtGuid;
        private System.Windows.Forms.ToolStripSeparator MtSep0;
        private System.Windows.Forms.ToolStripMenuItem MtAPwd;
        private System.Windows.Forms.ToolStripMenuItem MtASec;
        private System.Windows.Forms.ToolStripSeparator MtSep1;
        private System.Windows.Forms.ToolStripMenuItem MtExit;


    }
}


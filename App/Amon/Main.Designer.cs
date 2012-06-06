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
            this.NiTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.CgMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MgTopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.MgTray = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.MgAPwd = new System.Windows.Forms.ToolStripMenuItem();
            this.MgASec = new System.Windows.Forms.ToolStripMenuItem();
            this.MgABar = new System.Windows.Forms.ToolStripMenuItem();
            this.MgARen = new System.Windows.Forms.ToolStripMenuItem();
            this.MgAIco = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MgSignUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSignIn = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSignOf = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSignFp = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.MgInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.MgExit = new System.Windows.Forms.ToolStripMenuItem();
            this.UcApp = new System.Windows.Forms.PictureBox();
            this.LvApp = new System.Windows.Forms.ListView();
            this.IlApp = new System.Windows.Forms.ImageList(this.components);
            this.IsApp = new System.Windows.Forms.ImageList(this.components);
            this.CgMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UcApp)).BeginInit();
            this.SuspendLayout();
            // 
            // NiTray
            // 
            this.NiTray.BalloonTipTitle = "阿木提示";
            this.NiTray.Icon = ((System.Drawing.Icon)(resources.GetObject("NiTray.Icon")));
            this.NiTray.Text = "阿木导航";
            this.NiTray.Visible = true;
            this.NiTray.DoubleClick += new System.EventHandler(this.NiTray_DoubleClick);
            // 
            // CgMenu
            // 
            this.CgMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MgTopMost,
            this.MgTray,
            this.MgSep0,
            this.MgAPwd,
            this.MgASec,
            this.MgABar,
            this.MgARen,
            this.MgAIco,
            this.MgSep1,
            this.MgSignUp,
            this.MgSignIn,
            this.MgSignOf,
            this.MgSignFp,
            this.MgSep2,
            this.MgInfo,
            this.MgExit});
            this.CgMenu.Name = "CmMenu";
            this.CgMenu.Size = new System.Drawing.Size(164, 330);
            // 
            // MgTopMost
            // 
            this.MgTopMost.Checked = true;
            this.MgTopMost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MgTopMost.Name = "MgTopMost";
            this.MgTopMost.Size = new System.Drawing.Size(163, 22);
            this.MgTopMost.Text = "窗口置项(&W)";
            this.MgTopMost.Click += new System.EventHandler(this.MgTopMost_Click);
            // 
            // MgTray
            // 
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
            // MgABar
            // 
            this.MgABar.Name = "MgABar";
            this.MgABar.Size = new System.Drawing.Size(163, 22);
            this.MgABar.Text = "二维码(&B)";
            this.MgABar.Click += new System.EventHandler(this.MgABar_Click);
            // 
            // MgARen
            // 
            this.MgARen.Name = "MgARen";
            this.MgARen.Size = new System.Drawing.Size(163, 22);
            this.MgARen.Text = "文件重命名(&R)";
            this.MgARen.Click += new System.EventHandler(this.MgARen_Click);
            // 
            // MgAIco
            // 
            this.MgAIco.Name = "MgAIco";
            this.MgAIco.Size = new System.Drawing.Size(163, 22);
            this.MgAIco.Text = "图标编辑器(&I)";
            this.MgAIco.Click += new System.EventHandler(this.MgAIco_Click);
            // 
            // MgSep1
            // 
            this.MgSep1.Name = "MgSep1";
            this.MgSep1.Size = new System.Drawing.Size(160, 6);
            // 
            // MgSignUp
            // 
            this.MgSignUp.Name = "MgSignUp";
            this.MgSignUp.Size = new System.Drawing.Size(163, 22);
            this.MgSignUp.Text = "注册(&U)";
            this.MgSignUp.Click += new System.EventHandler(this.MgSignUp_Click);
            // 
            // MgSignIn
            // 
            this.MgSignIn.Name = "MgSignIn";
            this.MgSignIn.Size = new System.Drawing.Size(163, 22);
            this.MgSignIn.Text = "登录(&L)";
            this.MgSignIn.Click += new System.EventHandler(this.MgSignIn_Click);
            // 
            // MgSignOf
            // 
            this.MgSignOf.Name = "MgSignOf";
            this.MgSignOf.Size = new System.Drawing.Size(163, 22);
            this.MgSignOf.Text = "注销(&O)";
            this.MgSignOf.Visible = false;
            this.MgSignOf.Click += new System.EventHandler(this.MgSignOf_Click);
            // 
            // MgSignFp
            // 
            this.MgSignFp.Name = "MgSignFp";
            this.MgSignFp.Size = new System.Drawing.Size(163, 22);
            this.MgSignFp.Text = "找回口令(&F)";
            this.MgSignFp.Visible = false;
            this.MgSignFp.Click += new System.EventHandler(this.MgSignFp_Click);
            // 
            // MgSep2
            // 
            this.MgSep2.Name = "MgSep2";
            this.MgSep2.Size = new System.Drawing.Size(160, 6);
            // 
            // MgInfo
            // 
            this.MgInfo.Name = "MgInfo";
            this.MgInfo.Size = new System.Drawing.Size(163, 22);
            this.MgInfo.Text = "关于(&A)";
            this.MgInfo.Click += new System.EventHandler(this.MgInfo_Click);
            // 
            // MgExit
            // 
            this.MgExit.Name = "MgExit";
            this.MgExit.Size = new System.Drawing.Size(163, 22);
            this.MgExit.Text = "退出(&X)";
            this.MgExit.Click += new System.EventHandler(this.MgExit_Click);
            // 
            // UcApp
            // 
            this.UcApp.Location = new System.Drawing.Point(0, 0);
            this.UcApp.Name = "UcApp";
            this.UcApp.Size = new System.Drawing.Size(25, 25);
            this.UcApp.TabIndex = 1;
            this.UcApp.TabStop = false;
            this.UcApp.DoubleClick += new System.EventHandler(this.PbLogo_DoubleClick);
            this.UcApp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbLogo_MouseDown);
            this.UcApp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbLogo_MouseMove);
            this.UcApp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbLogo_MouseUp);
            // 
            // LvApp
            // 
            this.LvApp.LargeImageList = this.IlApp;
            this.LvApp.Location = new System.Drawing.Point(31, 22);
            this.LvApp.Name = "LvApp";
            this.LvApp.Size = new System.Drawing.Size(120, 120);
            this.LvApp.SmallImageList = this.IsApp;
            this.LvApp.TabIndex = 2;
            this.LvApp.UseCompatibleStateImageBehavior = false;
            this.LvApp.SelectedIndexChanged += new System.EventHandler(this.LvApp_SelectedIndexChanged);
            this.LvApp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvApp_MouseDoubleClick);
            // 
            // IlApp
            // 
            this.IlApp.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.IlApp.ImageSize = new System.Drawing.Size(32, 32);
            this.IlApp.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // IsApp
            // 
            this.IsApp.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.IsApp.ImageSize = new System.Drawing.Size(16, 16);
            this.IsApp.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(163, 154);
            this.ContextMenuStrip = this.CgMenu;
            this.Controls.Add(this.UcApp);
            this.Controls.Add(this.LvApp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "登录";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.CgMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UcApp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NiTray;
        private System.Windows.Forms.ContextMenuStrip CgMenu;
        private System.Windows.Forms.ToolStripMenuItem MgTopMost;
        private System.Windows.Forms.ToolStripMenuItem MgTray;
        private System.Windows.Forms.ToolStripMenuItem MgExit;
        private System.Windows.Forms.ToolStripSeparator MgSep0;
        private System.Windows.Forms.ToolStripSeparator MgSep1;
        private System.Windows.Forms.ToolStripMenuItem MgAPwd;
        private System.Windows.Forms.ToolStripMenuItem MgASec;
        private System.Windows.Forms.ToolStripSeparator MgSep2;
        private System.Windows.Forms.ToolStripMenuItem MgSignUp;
        private System.Windows.Forms.ToolStripMenuItem MgSignIn;
        private System.Windows.Forms.ToolStripMenuItem MgSignOf;
        private System.Windows.Forms.ToolStripMenuItem MgSignFp;
        private System.Windows.Forms.ToolStripMenuItem MgInfo;
        private System.Windows.Forms.ToolStripMenuItem MgABar;
        private System.Windows.Forms.ToolStripMenuItem MgARen;
        private System.Windows.Forms.PictureBox UcApp;
        private System.Windows.Forms.ListView LvApp;
        private System.Windows.Forms.ImageList IlApp;
        private System.Windows.Forms.ImageList IsApp;
        private System.Windows.Forms.ToolStripMenuItem MgAIco;


    }
}


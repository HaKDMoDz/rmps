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
            this.MtABar = new System.Windows.Forms.ToolStripMenuItem();
            this.MtSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MtSignUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MtSignOl = new System.Windows.Forms.ToolStripMenuItem();
            this.MtSignUl = new System.Windows.Forms.ToolStripMenuItem();
            this.MtSignPc = new System.Windows.Forms.ToolStripMenuItem();
            this.MtSignIn = new System.Windows.Forms.ToolStripMenuItem();
            this.MtSignOf = new System.Windows.Forms.ToolStripMenuItem();
            this.MtSignFp = new System.Windows.Forms.ToolStripMenuItem();
            this.MtSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.MtInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.MtExit = new System.Windows.Forms.ToolStripMenuItem();
            this.CgMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MgTopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.MgTray = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.MgAPwd = new System.Windows.Forms.ToolStripMenuItem();
            this.MgASec = new System.Windows.Forms.ToolStripMenuItem();
            this.MgABar = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MgSignUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSignOl = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSignUl = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSignPc = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSignIn = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSignOf = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSignFp = new System.Windows.Forms.ToolStripMenuItem();
            this.MgSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.MgInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.MgExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MgARen = new System.Windows.Forms.ToolStripMenuItem();
            this.MtARen = new System.Windows.Forms.ToolStripMenuItem();
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
            this.PbLogo.DoubleClick += new System.EventHandler(this.PbLogo_DoubleClick);
            this.PbLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.PbLogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.PbLogo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
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
            this.MtABar,
            this.MtARen,
            this.MtSep1,
            this.MtSignUp,
            this.MtSignIn,
            this.MtSignOf,
            this.MtSignFp,
            this.MtSep2,
            this.MtInfo,
            this.MtExit});
            this.CtMenu.Name = "CtMenu";
            this.CtMenu.Size = new System.Drawing.Size(166, 264);
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
            // MtABar
            // 
            this.MtABar.Name = "MtABar";
            this.MtABar.Size = new System.Drawing.Size(165, 22);
            this.MtABar.Text = "二维码(&B)";
            this.MtABar.Click += new System.EventHandler(this.MtABar_Click);
            // 
            // MtSep1
            // 
            this.MtSep1.Name = "MtSep1";
            this.MtSep1.Size = new System.Drawing.Size(162, 6);
            // 
            // MtSignUp
            // 
            this.MtSignUp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MtSignOl,
            this.MtSignUl,
            this.MtSignPc});
            this.MtSignUp.Name = "MtSignUp";
            this.MtSignUp.Size = new System.Drawing.Size(165, 22);
            this.MtSignUp.Text = "注册(&U)";
            // 
            // MtSignOl
            // 
            this.MtSignOl.Name = "MtSignOl";
            this.MtSignOl.Size = new System.Drawing.Size(142, 22);
            this.MtSignOl.Text = "联机注册(&R)";
            this.MtSignOl.Click += new System.EventHandler(this.MtSignOl_Click);
            // 
            // MtSignUl
            // 
            this.MtSignUl.Name = "MtSignUl";
            this.MtSignUl.Size = new System.Drawing.Size(142, 22);
            this.MtSignUl.Text = "脱机注册(&O)";
            this.MtSignUl.Click += new System.EventHandler(this.MtSignUl_Click);
            // 
            // MtSignPc
            // 
            this.MtSignPc.Name = "MtSignPc";
            this.MtSignPc.Size = new System.Drawing.Size(142, 22);
            this.MtSignPc.Text = "单机注册(&P)";
            this.MtSignPc.Click += new System.EventHandler(this.MtSignPc_Click);
            // 
            // MtSignIn
            // 
            this.MtSignIn.Name = "MtSignIn";
            this.MtSignIn.Size = new System.Drawing.Size(165, 22);
            this.MtSignIn.Text = "登录(&I)";
            this.MtSignIn.Click += new System.EventHandler(this.MtSignIn_Click);
            // 
            // MtSignOf
            // 
            this.MtSignOf.Name = "MtSignOf";
            this.MtSignOf.Size = new System.Drawing.Size(165, 22);
            this.MtSignOf.Text = "注销(&O)";
            this.MtSignOf.Visible = false;
            this.MtSignOf.Click += new System.EventHandler(this.MtSignOf_Click);
            // 
            // MtSignFp
            // 
            this.MtSignFp.Name = "MtSignFp";
            this.MtSignFp.Size = new System.Drawing.Size(165, 22);
            this.MtSignFp.Text = "找回口令(&F)";
            this.MtSignFp.Visible = false;
            this.MtSignFp.Click += new System.EventHandler(this.MtSignFp_Click);
            // 
            // MtSep2
            // 
            this.MtSep2.Name = "MtSep2";
            this.MtSep2.Size = new System.Drawing.Size(162, 6);
            // 
            // MtInfo
            // 
            this.MtInfo.Name = "MtInfo";
            this.MtInfo.Size = new System.Drawing.Size(165, 22);
            this.MtInfo.Text = "关于(&A)";
            this.MtInfo.Click += new System.EventHandler(this.MtInfo_Click);
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
            this.MgTopMost,
            this.MgTray,
            this.MgSep0,
            this.MgAPwd,
            this.MgASec,
            this.MgABar,
            this.MgARen,
            this.MgSep1,
            this.MgSignUp,
            this.MgSignIn,
            this.MgSignOf,
            this.MgSignFp,
            this.MgSep2,
            this.MgInfo,
            this.MgExit});
            this.CgMenu.Name = "CmMenu";
            this.CgMenu.Size = new System.Drawing.Size(164, 308);
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
            // MgABar
            // 
            this.MgABar.Name = "MgABar";
            this.MgABar.Size = new System.Drawing.Size(163, 22);
            this.MgABar.Text = "二维码(&B)";
            this.MgABar.Click += new System.EventHandler(this.MgABar_Click);
            // 
            // MgSep1
            // 
            this.MgSep1.Name = "MgSep1";
            this.MgSep1.Size = new System.Drawing.Size(160, 6);
            // 
            // MgSignUp
            // 
            this.MgSignUp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MgSignOl,
            this.MgSignUl,
            this.MgSignPc});
            this.MgSignUp.Name = "MgSignUp";
            this.MgSignUp.Size = new System.Drawing.Size(163, 22);
            this.MgSignUp.Text = "注册(&U)";
            // 
            // MgSignOl
            // 
            this.MgSignOl.Name = "MgSignOl";
            this.MgSignOl.Size = new System.Drawing.Size(142, 22);
            this.MgSignOl.Text = "联机注册(&R)";
            this.MgSignOl.Click += new System.EventHandler(this.MgSignOl_Click);
            // 
            // MgSignUl
            // 
            this.MgSignUl.Name = "MgSignUl";
            this.MgSignUl.Size = new System.Drawing.Size(142, 22);
            this.MgSignUl.Text = "脱机注册(&O)";
            this.MgSignUl.Click += new System.EventHandler(this.MgSignUl_Click);
            // 
            // MgSignPc
            // 
            this.MgSignPc.Name = "MgSignPc";
            this.MgSignPc.Size = new System.Drawing.Size(142, 22);
            this.MgSignPc.Text = "单机注册(&P)";
            this.MgSignPc.Click += new System.EventHandler(this.MgSignPc_Click);
            // 
            // MgSignIn
            // 
            this.MgSignIn.Name = "MgSignIn";
            this.MgSignIn.Size = new System.Drawing.Size(163, 22);
            this.MgSignIn.Text = "登录(&I)";
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
            // MgARen
            // 
            this.MgARen.Name = "MgARen";
            this.MgARen.Size = new System.Drawing.Size(163, 22);
            this.MgARen.Text = "文件更名";
            this.MgARen.Click += new System.EventHandler(this.MgARen_Click);
            // 
            // MtARen
            // 
            this.MtARen.Name = "MtARen";
            this.MtARen.Size = new System.Drawing.Size(165, 22);
            this.MtARen.Text = "文件更名";
            this.MtARen.Click += new System.EventHandler(this.MtARen_Click);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
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
        private System.Windows.Forms.ToolStripMenuItem MgSignUp;
        private System.Windows.Forms.ToolStripMenuItem MgSignIn;
        private System.Windows.Forms.ToolStripMenuItem MgSignOf;
        private System.Windows.Forms.ToolStripMenuItem MtSignUp;
        private System.Windows.Forms.ToolStripMenuItem MtSignIn;
        private System.Windows.Forms.ToolStripMenuItem MtSignOf;
        private System.Windows.Forms.ToolStripSeparator MtSep2;
        private System.Windows.Forms.ToolStripMenuItem MtSignFp;
        private System.Windows.Forms.ToolStripMenuItem MgSignFp;
        private System.Windows.Forms.ToolStripMenuItem MgSignOl;
        private System.Windows.Forms.ToolStripMenuItem MgSignUl;
        private System.Windows.Forms.ToolStripMenuItem MgSignPc;
        private System.Windows.Forms.ToolStripMenuItem MtSignOl;
        private System.Windows.Forms.ToolStripMenuItem MtSignUl;
        private System.Windows.Forms.ToolStripMenuItem MtSignPc;
        private System.Windows.Forms.ToolStripMenuItem MgInfo;
        private System.Windows.Forms.ToolStripMenuItem MtInfo;
        private System.Windows.Forms.ToolStripMenuItem MgABar;
        private System.Windows.Forms.ToolStripMenuItem MtABar;
        private System.Windows.Forms.ToolStripMenuItem MgARen;
        private System.Windows.Forms.ToolStripMenuItem MtARen;


    }
}


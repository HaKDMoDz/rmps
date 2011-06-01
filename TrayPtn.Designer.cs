namespace com.magickms
{
    partial class TrayPtn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrayPtn));
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MuUser = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.MiUser = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.MiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.NiTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.MiTalk = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSend = new System.Windows.Forms.ToolStripMenuItem();
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.CmMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiInfo,
            this.MiSep1,
            this.MuUser,
            this.MiSep2,
            this.MiSend,
            this.MiTalk,
            this.MiUser,
            this.MiSep3,
            this.MiExit});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(153, 176);
            // 
            // MiInfo
            // 
            this.MiInfo.Name = "MiInfo";
            this.MiInfo.Size = new System.Drawing.Size(152, 22);
            this.MiInfo.Text = "关于(&A)";
            this.MiInfo.Click += new System.EventHandler(this.MiInfo_Click);
            // 
            // MiSep1
            // 
            this.MiSep1.Name = "MiSep1";
            this.MiSep1.Size = new System.Drawing.Size(149, 6);
            // 
            // MuUser
            // 
            this.MuUser.Name = "MuUser";
            this.MuUser.Size = new System.Drawing.Size(152, 22);
            this.MuUser.Text = "方案(&S)";
            // 
            // MiSep2
            // 
            this.MiSep2.Name = "MiSep2";
            this.MiSep2.Size = new System.Drawing.Size(149, 6);
            // 
            // MiUser
            // 
            this.MiUser.Name = "MiUser";
            this.MiUser.Size = new System.Drawing.Size(152, 22);
            this.MiUser.Text = "选项(&O)";
            this.MiUser.Click += new System.EventHandler(this.MiUser_Click);
            // 
            // MiSep3
            // 
            this.MiSep3.Name = "MiSep3";
            this.MiSep3.Size = new System.Drawing.Size(149, 6);
            // 
            // MiExit
            // 
            this.MiExit.Name = "MiExit";
            this.MiExit.Size = new System.Drawing.Size(152, 22);
            this.MiExit.Text = "退出(&X)";
            this.MiExit.Click += new System.EventHandler(this.MiExit_Click);
            // 
            // NiTray
            // 
            this.NiTray.ContextMenuStrip = this.CmMenu;
            this.NiTray.Icon = ((System.Drawing.Icon)(resources.GetObject("NiTray.Icon")));
            this.NiTray.Text = "哈哈";
            this.NiTray.Visible = true;
            this.NiTray.DoubleClick += new System.EventHandler(this.NiTray_DoubleClick);
            // 
            // MiTalk
            // 
            this.MiTalk.Name = "MiTalk";
            this.MiTalk.Size = new System.Drawing.Size(152, 22);
            this.MiTalk.Text = "训练(&T)";
            this.MiTalk.Click += new System.EventHandler(this.MiTalk_Click);
            // 
            // MiSend
            // 
            this.MiSend.Name = "MiSend";
            this.MiSend.Size = new System.Drawing.Size(152, 22);
            this.MiSend.Text = "发送(&P)";
            this.MiSend.Click += new System.EventHandler(this.MiSend_Click);
            // 
            // PbLogo
            // 
            this.PbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PbLogo.Image = global::com.magickms.Properties.Resources.logo24;
            this.PbLogo.Location = new System.Drawing.Point(0, 0);
            this.PbLogo.Margin = new System.Windows.Forms.Padding(0);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(150, 32);
            this.PbLogo.TabIndex = 1;
            this.PbLogo.TabStop = false;
            this.PbLogo.DoubleClick += new System.EventHandler(this.PbLogo_DoubleClick);
            this.PbLogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TrayPtn_MouseMove);
            this.PbLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrayPtn_MouseDown);
            this.PbLogo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrayPtn_MouseUp);
            // 
            // TrayPtn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(150, 32);
            this.ContextMenuStrip = this.CmMenu;
            this.ControlBox = false;
            this.Controls.Add(this.PbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrayPtn";
            this.ShowInTaskbar = false;
            this.Text = "TrayPtn";
            this.TopMost = true;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TrayPtn_Paint);
            this.Resize += new System.EventHandler(this.TrayPtn_Resize);
            this.CmMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiExit;
        private System.Windows.Forms.NotifyIcon NiTray;
        private System.Windows.Forms.ToolStripMenuItem MiInfo;
        private System.Windows.Forms.ToolStripSeparator MiSep1;
        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.ToolStripMenuItem MiUser;
        private System.Windows.Forms.ToolTip TpTips;
        private System.Windows.Forms.ToolStripMenuItem MuUser;
        private System.Windows.Forms.ToolStripSeparator MiSep2;
        private System.Windows.Forms.ToolStripSeparator MiSep3;
        private System.Windows.Forms.ToolStripMenuItem MiTalk;
        private System.Windows.Forms.ToolStripMenuItem MiSend;
    }
}
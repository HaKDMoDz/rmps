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
            this.BtPwd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BgWorker = new System.Windows.Forms.Timer(this.components);
            this.NiTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiTopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.MiGuid = new System.Windows.Forms.ToolStripMenuItem();
            this.MiExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtPwd
            // 
            this.BtPwd.Location = new System.Drawing.Point(38, 9);
            this.BtPwd.Name = "BtPwd";
            this.BtPwd.Size = new System.Drawing.Size(75, 23);
            this.BtPwd.TabIndex = 0;
            this.BtPwd.Text = "&Putton";
            this.BtPwd.UseVisualStyleBackColor = true;
            this.BtPwd.Click += new System.EventHandler(this.BtPwd_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(119, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "&Qutton";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // BgWorker
            // 
            this.BgWorker.Tick += new System.EventHandler(this.BgWorker_Tick);
            // 
            // NiTray
            // 
            this.NiTray.BalloonTipTitle = "阿木提示";
            this.NiTray.ContextMenuStrip = this.CmMenu;
            this.NiTray.Icon = ((System.Drawing.Icon)(resources.GetObject("NiTray.Icon")));
            this.NiTray.Text = "阿木导航";
            this.NiTray.Visible = true;
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiTopMost,
            this.MiGuid,
            this.MiExit});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(149, 70);
            // 
            // MiTopMost
            // 
            this.MiTopMost.Name = "MiTopMost";
            this.MiTopMost.Size = new System.Drawing.Size(148, 22);
            this.MiTopMost.Text = "关于";
            this.MiTopMost.Click += new System.EventHandler(this.MiTopMost_Click);
            // 
            // MiGuid
            // 
            this.MiGuid.Name = "MiGuid";
            this.MiGuid.Size = new System.Drawing.Size(148, 22);
            this.MiGuid.Text = "隐藏导航窗口";
            this.MiGuid.Click += new System.EventHandler(this.MiTrayIco_Click);
            // 
            // MiExit
            // 
            this.MiExit.Name = "MiExit";
            this.MiExit.Size = new System.Drawing.Size(148, 22);
            this.MiExit.Text = "退出";
            this.MiExit.Click += new System.EventHandler(this.MiExit_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 36);
            this.ContextMenuStrip = this.CmMenu;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtPwd);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtPwd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer BgWorker;
        private System.Windows.Forms.NotifyIcon NiTray;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiTopMost;
        private System.Windows.Forms.ToolStripMenuItem MiGuid;
        private System.Windows.Forms.ToolStripMenuItem MiExit;


    }
}


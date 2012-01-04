namespace Msec
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
            this.LbOpt = new System.Windows.Forms.Label();
            this.CbOpt = new System.Windows.Forms.ComboBox();
            this.CbKey = new System.Windows.Forms.ComboBox();
            this.LbInfo = new System.Windows.Forms.Label();
            this.BtDo = new System.Windows.Forms.Button();
            this.MsUser = new System.Windows.Forms.MenuStrip();
            this.MiUser = new System.Windows.Forms.ToolStripMenuItem();
            this.MiInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MsUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbOpt
            // 
            this.LbOpt.AutoSize = true;
            this.LbOpt.Location = new System.Drawing.Point(12, 15);
            this.LbOpt.Name = "LbOpt";
            this.LbOpt.Size = new System.Drawing.Size(47, 12);
            this.LbOpt.TabIndex = 0;
            this.LbOpt.Text = "操作(&T)";
            // 
            // CbOpt
            // 
            this.CbOpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbOpt.FormattingEnabled = true;
            this.CbOpt.Location = new System.Drawing.Point(65, 12);
            this.CbOpt.Name = "CbOpt";
            this.CbOpt.Size = new System.Drawing.Size(91, 20);
            this.CbOpt.TabIndex = 1;
            this.CbOpt.SelectedIndexChanged += new System.EventHandler(this.CbOpt_SelectedIndexChanged);
            // 
            // CbKey
            // 
            this.CbKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbKey.FormattingEnabled = true;
            this.CbKey.Location = new System.Drawing.Point(162, 12);
            this.CbKey.Name = "CbKey";
            this.CbKey.Size = new System.Drawing.Size(81, 20);
            this.CbKey.TabIndex = 2;
            this.CbKey.SelectedIndexChanged += new System.EventHandler(this.CbKey_SelectedIndexChanged);
            // 
            // LbInfo
            // 
            this.LbInfo.AutoSize = true;
            this.LbInfo.Location = new System.Drawing.Point(12, 275);
            this.LbInfo.Name = "LbInfo";
            this.LbInfo.Size = new System.Drawing.Size(0, 12);
            this.LbInfo.TabIndex = 7;
            // 
            // BtDo
            // 
            this.BtDo.Location = new System.Drawing.Point(423, 270);
            this.BtDo.Name = "BtDo";
            this.BtDo.Size = new System.Drawing.Size(75, 23);
            this.BtDo.TabIndex = 8;
            this.BtDo.Text = "执行(&R)";
            this.BtDo.UseVisualStyleBackColor = true;
            this.BtDo.Click += new System.EventHandler(this.BtDo_Click);
            // 
            // MsUser
            // 
            this.MsUser.BackColor = System.Drawing.Color.Transparent;
            this.MsUser.Dock = System.Windows.Forms.DockStyle.None;
            this.MsUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiUser});
            this.MsUser.Location = new System.Drawing.Point(433, 9);
            this.MsUser.Name = "MsUser";
            this.MsUser.Size = new System.Drawing.Size(158, 25);
            this.MsUser.TabIndex = 9;
            this.MsUser.Text = "menuStrip1";
            // 
            // MiUser
            // 
            this.MiUser.BackColor = System.Drawing.SystemColors.Control;
            this.MiUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiInfo,
            this.toolStripSeparator1,
            this.MiSave,
            this.toolStripSeparator2,
            this.MiExit});
            this.MiUser.Name = "MiUser";
            this.MiUser.Size = new System.Drawing.Size(58, 21);
            this.MiUser.Text = "偏好(&F)";
            // 
            // MiInfo
            // 
            this.MiInfo.Name = "MiInfo";
            this.MiInfo.Size = new System.Drawing.Size(152, 22);
            this.MiInfo.Text = "关于(&I)";
            this.MiInfo.Click += new System.EventHandler(this.MiInfo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // MiExit
            // 
            this.MiExit.Name = "MiExit";
            this.MiExit.Size = new System.Drawing.Size(152, 22);
            this.MiExit.Text = "退出(&X)";
            this.MiExit.Click += new System.EventHandler(this.MiExit_Click);
            // 
            // MiSave
            // 
            this.MiSave.Name = "MiSave";
            this.MiSave.Size = new System.Drawing.Size(152, 22);
            this.MiSave.Text = "保存(&S)";
            this.MiSave.Click += new System.EventHandler(this.MiSave_Click);
            // 
            // Worker
            // 
            this.Worker.WorkerSupportsCancellation = true;
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DoWork);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DoWorkerCompleted);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 305);
            this.Controls.Add(this.BtDo);
            this.Controls.Add(this.LbInfo);
            this.Controls.Add(this.CbKey);
            this.Controls.Add(this.CbOpt);
            this.Controls.Add(this.LbOpt);
            this.Controls.Add(this.MsUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "阿木加密器";
            this.MsUser.ResumeLayout(false);
            this.MsUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbOpt;
        private System.Windows.Forms.ComboBox CbOpt;
        private System.Windows.Forms.ComboBox CbKey;
        private System.Windows.Forms.Button BtDo;
        private System.Windows.Forms.Label LbInfo;
        private System.Windows.Forms.MenuStrip MsUser;
        private System.Windows.Forms.ToolStripMenuItem MiUser;
        private System.Windows.Forms.ToolStripMenuItem MiInfo;
        private System.Windows.Forms.ToolStripMenuItem MiExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.ComponentModel.BackgroundWorker Worker;
        private System.Windows.Forms.ToolTip TpTips;
        private System.Windows.Forms.ToolStripMenuItem MiSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}


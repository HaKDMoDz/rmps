namespace Me.Amon.User
{
    partial class SignIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignIn));
            this.LbName = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.TbPass = new System.Windows.Forms.TextBox();
            this.LbPass = new System.Windows.Forms.Label();
            this.BtNo = new System.Windows.Forms.Button();
            this.BtOk = new System.Windows.Forms.Button();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiOnSignUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MiOfSignUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MiLcSignUp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiUpgrade = new System.Windows.Forms.ToolStripMenuItem();
            this.PbMenu = new System.Windows.Forms.PictureBox();
            this.PbGuid = new System.Windows.Forms.PictureBox();
            this.CmMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbGuid)).BeginInit();
            this.SuspendLayout();
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(49, 63);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(47, 12);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "用户(&U)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(102, 60);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(100, 21);
            this.TbName.TabIndex = 1;
            // 
            // TbPass
            // 
            this.TbPass.Location = new System.Drawing.Point(102, 87);
            this.TbPass.Name = "TbPass";
            this.TbPass.PasswordChar = '*';
            this.TbPass.Size = new System.Drawing.Size(100, 21);
            this.TbPass.TabIndex = 3;
            // 
            // LbPass
            // 
            this.LbPass.AutoSize = true;
            this.LbPass.Location = new System.Drawing.Point(49, 90);
            this.LbPass.Name = "LbPass";
            this.LbPass.Size = new System.Drawing.Size(47, 12);
            this.LbPass.TabIndex = 2;
            this.LbPass.Text = "口令(&K)";
            // 
            // BtNo
            // 
            this.BtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtNo.Location = new System.Drawing.Point(163, 122);
            this.BtNo.Name = "BtNo";
            this.BtNo.Size = new System.Drawing.Size(75, 23);
            this.BtNo.TabIndex = 5;
            this.BtNo.Text = "取消(&C)";
            this.BtNo.UseVisualStyleBackColor = true;
            this.BtNo.Click += new System.EventHandler(this.BtNo_Click);
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(82, 122);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 4;
            this.BtOk.Text = "登录(&S)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiOnSignUp,
            this.MiOfSignUp,
            this.MiLcSignUp,
            this.toolStripSeparator1,
            this.MiUpgrade});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(153, 120);
            // 
            // MiOnSignUp
            // 
            this.MiOnSignUp.Name = "MiOnSignUp";
            this.MiOnSignUp.Size = new System.Drawing.Size(152, 22);
            this.MiOnSignUp.Text = "联机注册(&O)";
            this.MiOnSignUp.Click += new System.EventHandler(this.MiOnSignUp_Click);
            // 
            // MiOfSignUp
            // 
            this.MiOfSignUp.Enabled = false;
            this.MiOfSignUp.Name = "MiOfSignUp";
            this.MiOfSignUp.Size = new System.Drawing.Size(152, 22);
            this.MiOfSignUp.Text = "脱机注册(&F)";
            this.MiOfSignUp.Click += new System.EventHandler(this.MiOfSignUp_Click);
            // 
            // MiLcSignUp
            // 
            this.MiLcSignUp.Name = "MiLcSignUp";
            this.MiLcSignUp.Size = new System.Drawing.Size(152, 22);
            this.MiLcSignUp.Text = "本地注册(&P)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // MiUpgrade
            // 
            this.MiUpgrade.Name = "MiUpgrade";
            this.MiUpgrade.Size = new System.Drawing.Size(152, 22);
            this.MiUpgrade.Text = "升级(&U)";
            this.MiUpgrade.Click += new System.EventHandler(this.MiUpgrade_Click);
            // 
            // PbMenu
            // 
            this.PbMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbMenu.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbMenu.Location = new System.Drawing.Point(12, 126);
            this.PbMenu.Name = "PbMenu";
            this.PbMenu.Size = new System.Drawing.Size(16, 16);
            this.PbMenu.TabIndex = 6;
            this.PbMenu.TabStop = false;
            this.PbMenu.Click += new System.EventHandler(this.PbMenu_Click);
            // 
            // PbGuid
            // 
            this.PbGuid.Image = global::Me.Amon.Properties.Resources.Guid;
            this.PbGuid.Location = new System.Drawing.Point(0, 0);
            this.PbGuid.Name = "PbGuid";
            this.PbGuid.Size = new System.Drawing.Size(250, 40);
            this.PbGuid.TabIndex = 2;
            this.PbGuid.TabStop = false;
            // 
            // SignIn
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtNo;
            this.ClientSize = new System.Drawing.Size(250, 157);
            this.Controls.Add(this.PbMenu);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.TbPass);
            this.Controls.Add(this.LbPass);
            this.Controls.Add(this.PbGuid);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.CmMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbGuid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.PictureBox PbGuid;
        private System.Windows.Forms.TextBox TbPass;
        private System.Windows.Forms.Label LbPass;
        private System.Windows.Forms.Button BtNo;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.PictureBox PbMenu;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiOnSignUp;
        private System.Windows.Forms.ToolStripMenuItem MiOfSignUp;
        private System.Windows.Forms.ToolStripMenuItem MiLcSignUp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MiUpgrade;
    }
}
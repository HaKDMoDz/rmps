namespace Me.Amon.User.Sign
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LbName = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LbPass = new System.Windows.Forms.Label();
            this.TbPass = new System.Windows.Forms.TextBox();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiOnSignUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MiOfSignUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MiPcSignUp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MiUpgrade = new System.Windows.Forms.ToolStripMenuItem();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(3, 6);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(47, 12);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "用户(&U)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(56, 3);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(100, 21);
            this.TbName.TabIndex = 1;
            // 
            // LbPass
            // 
            this.LbPass.AutoSize = true;
            this.LbPass.Location = new System.Drawing.Point(3, 33);
            this.LbPass.Name = "LbPass";
            this.LbPass.Size = new System.Drawing.Size(47, 12);
            this.LbPass.TabIndex = 2;
            this.LbPass.Text = "口令(&K)";
            // 
            // TbPass
            // 
            this.TbPass.Location = new System.Drawing.Point(56, 30);
            this.TbPass.Name = "TbPass";
            this.TbPass.PasswordChar = '*';
            this.TbPass.Size = new System.Drawing.Size(100, 21);
            this.TbPass.TabIndex = 3;
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiOpen,
            this.toolStripSeparator1,
            this.MiOnSignUp,
            this.MiOfSignUp,
            this.MiPcSignUp,
            this.toolStripSeparator2,
            this.MiUpgrade});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(153, 148);
            // 
            // MiOpen
            // 
            this.MiOpen.Name = "MiOpen";
            this.MiOpen.Size = new System.Drawing.Size(152, 22);
            this.MiOpen.Text = "打开(&O)";
            this.MiOpen.Click += new System.EventHandler(this.MiOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // MiOnSignUp
            // 
            this.MiOnSignUp.Name = "MiOnSignUp";
            this.MiOnSignUp.Size = new System.Drawing.Size(152, 22);
            this.MiOnSignUp.Text = "联机注册(&R)";
            this.MiOnSignUp.Click += new System.EventHandler(this.MiOnSignUp_Click);
            // 
            // MiOfSignUp
            // 
            this.MiOfSignUp.Name = "MiOfSignUp";
            this.MiOfSignUp.Size = new System.Drawing.Size(152, 22);
            this.MiOfSignUp.Text = "脱机注册(&N)";
            this.MiOfSignUp.Click += new System.EventHandler(this.MiOfSignUp_Click);
            // 
            // MiPcSignUp
            // 
            this.MiPcSignUp.Name = "MiPcSignUp";
            this.MiPcSignUp.Size = new System.Drawing.Size(152, 22);
            this.MiPcSignUp.Text = "单机注册(&P)";
            this.MiPcSignUp.Click += new System.EventHandler(this.MiPcSignUp_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // MiUpgrade
            // 
            this.MiUpgrade.Enabled = false;
            this.MiUpgrade.Name = "MiUpgrade";
            this.MiUpgrade.Size = new System.Drawing.Size(152, 22);
            this.MiUpgrade.Text = "升级(&U)";
            this.MiUpgrade.Click += new System.EventHandler(this.MiUpgrade_Click);
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbPass);
            this.Controls.Add(this.LbPass);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.Name = "SignIn";
            this.Size = new System.Drawing.Size(226, 54);
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbPass;
        private System.Windows.Forms.TextBox TbPass;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MiOnSignUp;
        private System.Windows.Forms.ToolStripMenuItem MiOfSignUp;
        private System.Windows.Forms.ToolStripMenuItem MiPcSignUp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MiUpgrade;
    }
}

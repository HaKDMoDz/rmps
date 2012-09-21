namespace Me.Amon.Auth.Uc
{
    partial class AuthPc
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
            this.LbOldPass = new System.Windows.Forms.Label();
            this.TbOldPass = new System.Windows.Forms.TextBox();
            this.LbNewPass1 = new System.Windows.Forms.Label();
            this.TbNewPass1 = new System.Windows.Forms.TextBox();
            this.LbNewPass2 = new System.Windows.Forms.Label();
            this.TbNewPass2 = new System.Windows.Forms.TextBox();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiAuthOl = new System.Windows.Forms.ToolStripMenuItem();
            this.MiAuthUl = new System.Windows.Forms.ToolStripMenuItem();
            this.MiAuthPc = new System.Windows.Forms.ToolStripMenuItem();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbOldPass
            // 
            this.LbOldPass.AutoSize = true;
            this.LbOldPass.Location = new System.Drawing.Point(24, 6);
            this.LbOldPass.Name = "LbOldPass";
            this.LbOldPass.Size = new System.Drawing.Size(71, 12);
            this.LbOldPass.TabIndex = 0;
            this.LbOldPass.Text = "旧 口 令(&O)";
            // 
            // TbOldPass
            // 
            this.TbOldPass.Location = new System.Drawing.Point(101, 3);
            this.TbOldPass.Name = "TbOldPass";
            this.TbOldPass.Size = new System.Drawing.Size(100, 21);
            this.TbOldPass.TabIndex = 1;
            this.TbOldPass.UseSystemPasswordChar = true;
            // 
            // LbNewPass1
            // 
            this.LbNewPass1.AutoSize = true;
            this.LbNewPass1.Location = new System.Drawing.Point(24, 33);
            this.LbNewPass1.Name = "LbNewPass1";
            this.LbNewPass1.Size = new System.Drawing.Size(71, 12);
            this.LbNewPass1.TabIndex = 2;
            this.LbNewPass1.Text = "新 口 令(&N)";
            // 
            // TbNewPass1
            // 
            this.TbNewPass1.Location = new System.Drawing.Point(101, 30);
            this.TbNewPass1.Name = "TbNewPass1";
            this.TbNewPass1.Size = new System.Drawing.Size(100, 21);
            this.TbNewPass1.TabIndex = 3;
            this.TbNewPass1.UseSystemPasswordChar = true;
            // 
            // LbNewPass2
            // 
            this.LbNewPass2.AutoSize = true;
            this.LbNewPass2.Location = new System.Drawing.Point(24, 60);
            this.LbNewPass2.Name = "LbNewPass2";
            this.LbNewPass2.Size = new System.Drawing.Size(71, 12);
            this.LbNewPass2.TabIndex = 4;
            this.LbNewPass2.Text = "口令确认(&V)";
            // 
            // TbNewPass2
            // 
            this.TbNewPass2.Location = new System.Drawing.Point(101, 57);
            this.TbNewPass2.Name = "TbNewPass2";
            this.TbNewPass2.Size = new System.Drawing.Size(100, 21);
            this.TbNewPass2.TabIndex = 5;
            this.TbNewPass2.UseSystemPasswordChar = true;
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiAuthOl,
            this.MiAuthUl,
            this.MiAuthPc});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(153, 92);
            // 
            // MiAuthOl
            // 
            this.MiAuthOl.Name = "MiAuthOl";
            this.MiAuthOl.Size = new System.Drawing.Size(152, 22);
            this.MiAuthOl.Text = "联机修改(&O)";
            this.MiAuthOl.Click += new System.EventHandler(this.MiAuthOl_Click);
            // 
            // MiAuthUl
            // 
            this.MiAuthUl.Name = "MiAuthUl";
            this.MiAuthUl.Size = new System.Drawing.Size(152, 22);
            this.MiAuthUl.Text = "脱机修改(&U)";
            this.MiAuthUl.Click += new System.EventHandler(this.MiAuthUl_Click);
            // 
            // MiAuthPc
            // 
            this.MiAuthPc.Checked = true;
            this.MiAuthPc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MiAuthPc.Name = "MiAuthPc";
            this.MiAuthPc.Size = new System.Drawing.Size(152, 22);
            this.MiAuthPc.Text = "单机修改(&P)";
            // 
            // AuthPc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbNewPass2);
            this.Controls.Add(this.LbNewPass2);
            this.Controls.Add(this.TbNewPass1);
            this.Controls.Add(this.LbNewPass1);
            this.Controls.Add(this.TbOldPass);
            this.Controls.Add(this.LbOldPass);
            this.Name = "AuthPc";
            this.Size = new System.Drawing.Size(226, 81);
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbOldPass;
        private System.Windows.Forms.TextBox TbOldPass;
        private System.Windows.Forms.Label LbNewPass1;
        private System.Windows.Forms.TextBox TbNewPass1;
        private System.Windows.Forms.Label LbNewPass2;
        private System.Windows.Forms.TextBox TbNewPass2;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiAuthOl;
        private System.Windows.Forms.ToolStripMenuItem MiAuthUl;
        private System.Windows.Forms.ToolStripMenuItem MiAuthPc;
    }
}

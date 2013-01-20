namespace Me.Amon.Auth.Uc
{
    partial class AuthLk
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
            this.TbNewPass2 = new System.Windows.Forms.TextBox();
            this.LbNewPass2 = new System.Windows.Forms.Label();
            this.TbNewPass1 = new System.Windows.Forms.TextBox();
            this.LbNewPass1 = new System.Windows.Forms.Label();
            this.TbOldPass = new System.Windows.Forms.TextBox();
            this.LbOldPass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TbNewPass2
            // 
            this.TbNewPass2.Location = new System.Drawing.Point(102, 57);
            this.TbNewPass2.Name = "TbNewPass2";
            this.TbNewPass2.Size = new System.Drawing.Size(100, 21);
            this.TbNewPass2.TabIndex = 11;
            this.TbNewPass2.UseSystemPasswordChar = true;
            // 
            // LbNewPass2
            // 
            this.LbNewPass2.AutoSize = true;
            this.LbNewPass2.Location = new System.Drawing.Point(25, 60);
            this.LbNewPass2.Name = "LbNewPass2";
            this.LbNewPass2.Size = new System.Drawing.Size(71, 12);
            this.LbNewPass2.TabIndex = 10;
            this.LbNewPass2.Text = "口令确认(&V)";
            // 
            // TbNewPass1
            // 
            this.TbNewPass1.Location = new System.Drawing.Point(102, 30);
            this.TbNewPass1.Name = "TbNewPass1";
            this.TbNewPass1.Size = new System.Drawing.Size(100, 21);
            this.TbNewPass1.TabIndex = 9;
            this.TbNewPass1.UseSystemPasswordChar = true;
            // 
            // LbNewPass1
            // 
            this.LbNewPass1.AutoSize = true;
            this.LbNewPass1.Location = new System.Drawing.Point(25, 33);
            this.LbNewPass1.Name = "LbNewPass1";
            this.LbNewPass1.Size = new System.Drawing.Size(71, 12);
            this.LbNewPass1.TabIndex = 8;
            this.LbNewPass1.Text = "新 口 令(&N)";
            // 
            // TbOldPass
            // 
            this.TbOldPass.Location = new System.Drawing.Point(102, 3);
            this.TbOldPass.Name = "TbOldPass";
            this.TbOldPass.Size = new System.Drawing.Size(100, 21);
            this.TbOldPass.TabIndex = 7;
            this.TbOldPass.UseSystemPasswordChar = true;
            // 
            // LbOldPass
            // 
            this.LbOldPass.AutoSize = true;
            this.LbOldPass.Location = new System.Drawing.Point(25, 6);
            this.LbOldPass.Name = "LbOldPass";
            this.LbOldPass.Size = new System.Drawing.Size(71, 12);
            this.LbOldPass.TabIndex = 6;
            this.LbOldPass.Text = "旧 口 令(&O)";
            // 
            // AuthLk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbNewPass2);
            this.Controls.Add(this.LbNewPass2);
            this.Controls.Add(this.TbNewPass1);
            this.Controls.Add(this.LbNewPass1);
            this.Controls.Add(this.TbOldPass);
            this.Controls.Add(this.LbOldPass);
            this.Name = "AuthLk";
            this.Size = new System.Drawing.Size(226, 81);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbNewPass2;
        private System.Windows.Forms.Label LbNewPass2;
        private System.Windows.Forms.TextBox TbNewPass1;
        private System.Windows.Forms.Label LbNewPass1;
        private System.Windows.Forms.TextBox TbOldPass;
        private System.Windows.Forms.Label LbOldPass;
    }
}

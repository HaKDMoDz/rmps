namespace Me.Amon.V.Sign
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
            this.LbName = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LbPass = new System.Windows.Forms.Label();
            this.TbPass = new System.Windows.Forms.TextBox();
            this.PbSignFk = new System.Windows.Forms.PictureBox();
            this.PbSignUp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbSignFk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbSignUp)).BeginInit();
            this.SuspendLayout();
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(25, 6);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(47, 12);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "用户(&U)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(78, 3);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(100, 21);
            this.TbName.TabIndex = 1;
            // 
            // LbPass
            // 
            this.LbPass.AutoSize = true;
            this.LbPass.Location = new System.Drawing.Point(25, 33);
            this.LbPass.Name = "LbPass";
            this.LbPass.Size = new System.Drawing.Size(47, 12);
            this.LbPass.TabIndex = 2;
            this.LbPass.Text = "口令(&K)";
            // 
            // TbPass
            // 
            this.TbPass.Location = new System.Drawing.Point(78, 30);
            this.TbPass.Name = "TbPass";
            this.TbPass.Size = new System.Drawing.Size(100, 21);
            this.TbPass.TabIndex = 3;
            this.TbPass.UseSystemPasswordChar = true;
            // 
            // PbSignFk
            // 
            this.PbSignFk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbSignFk.Image = global::Me.Amon.Properties.Resources.SignFp;
            this.PbSignFk.Location = new System.Drawing.Point(184, 32);
            this.PbSignFk.Name = "PbSignFk";
            this.PbSignFk.Size = new System.Drawing.Size(16, 16);
            this.PbSignFk.TabIndex = 5;
            this.PbSignFk.TabStop = false;
            this.PbSignFk.Click += new System.EventHandler(this.PbSignFk_Click);
            // 
            // PbSignUp
            // 
            this.PbSignUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbSignUp.Image = global::Me.Amon.Properties.Resources.SignIn;
            this.PbSignUp.Location = new System.Drawing.Point(184, 5);
            this.PbSignUp.Name = "PbSignUp";
            this.PbSignUp.Size = new System.Drawing.Size(16, 16);
            this.PbSignUp.TabIndex = 4;
            this.PbSignUp.TabStop = false;
            this.PbSignUp.Click += new System.EventHandler(this.PbSignUp_Click);
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbSignFk);
            this.Controls.Add(this.PbSignUp);
            this.Controls.Add(this.TbPass);
            this.Controls.Add(this.LbPass);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.Name = "SignIn";
            this.Size = new System.Drawing.Size(226, 54);
            ((System.ComponentModel.ISupportInitialize)(this.PbSignFk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbSignUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbPass;
        private System.Windows.Forms.TextBox TbPass;
        private System.Windows.Forms.PictureBox PbSignUp;
        private System.Windows.Forms.PictureBox PbSignFk;
    }
}

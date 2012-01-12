namespace Me.Amon.User
{
    partial class SignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LbName = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LbPass1 = new System.Windows.Forms.Label();
            this.TbPass1 = new System.Windows.Forms.TextBox();
            this.LbPass2 = new System.Windows.Forms.Label();
            this.TbPass2 = new System.Windows.Forms.TextBox();
            this.BtNo = new System.Windows.Forms.Button();
            this.BtOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(254, 48);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(41, 67);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(71, 12);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "登录用户(&U)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(118, 64);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(100, 21);
            this.TbName.TabIndex = 1;
            // 
            // LbPass1
            // 
            this.LbPass1.AutoSize = true;
            this.LbPass1.Location = new System.Drawing.Point(41, 94);
            this.LbPass1.Name = "LbPass1";
            this.LbPass1.Size = new System.Drawing.Size(71, 12);
            this.LbPass1.TabIndex = 2;
            this.LbPass1.Text = "登录口令(&K)";
            // 
            // TbPass1
            // 
            this.TbPass1.Location = new System.Drawing.Point(118, 91);
            this.TbPass1.Name = "TbPass1";
            this.TbPass1.PasswordChar = '*';
            this.TbPass1.Size = new System.Drawing.Size(100, 21);
            this.TbPass1.TabIndex = 3;
            // 
            // LbPass2
            // 
            this.LbPass2.AutoSize = true;
            this.LbPass2.Location = new System.Drawing.Point(41, 121);
            this.LbPass2.Name = "LbPass2";
            this.LbPass2.Size = new System.Drawing.Size(71, 12);
            this.LbPass2.TabIndex = 4;
            this.LbPass2.Text = "口令确认(&V)";
            // 
            // TbPass2
            // 
            this.TbPass2.Location = new System.Drawing.Point(118, 118);
            this.TbPass2.Name = "TbPass2";
            this.TbPass2.Size = new System.Drawing.Size(100, 21);
            this.TbPass2.TabIndex = 5;
            // 
            // BtNo
            // 
            this.BtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtNo.Location = new System.Drawing.Point(167, 154);
            this.BtNo.Name = "BtNo";
            this.BtNo.Size = new System.Drawing.Size(75, 23);
            this.BtNo.TabIndex = 7;
            this.BtNo.Text = "取消(&C)";
            this.BtNo.UseVisualStyleBackColor = true;
            this.BtNo.Click += new System.EventHandler(this.BtNo_Click);
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(86, 154);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 6;
            this.BtOk.Text = "注册(&S)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // SignUp
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtNo;
            this.ClientSize = new System.Drawing.Size(254, 189);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.TbPass2);
            this.Controls.Add(this.LbPass2);
            this.Controls.Add(this.TbPass1);
            this.Controls.Add(this.LbPass1);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SignUp";
            this.Text = "SignUp";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbPass1;
        private System.Windows.Forms.TextBox TbPass1;
        private System.Windows.Forms.Label LbPass2;
        private System.Windows.Forms.TextBox TbPass2;
        private System.Windows.Forms.Button BtNo;
        private System.Windows.Forms.Button BtOk;
    }
}
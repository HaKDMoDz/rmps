namespace Me.Amon.User
{
    partial class SignRc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignRc));
            this.LbName = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LbPass = new System.Windows.Forms.Label();
            this.TbPass = new System.Windows.Forms.TextBox();
            this.BtOk = new System.Windows.Forms.Button();
            this.BtNo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(50, 57);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(47, 12);
            this.LbName.TabIndex = 1;
            this.LbName.Text = "用户(&N)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(103, 54);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(100, 21);
            this.TbName.TabIndex = 2;
            // 
            // LbPass
            // 
            this.LbPass.AutoSize = true;
            this.LbPass.Location = new System.Drawing.Point(50, 84);
            this.LbPass.Name = "LbPass";
            this.LbPass.Size = new System.Drawing.Size(47, 12);
            this.LbPass.TabIndex = 3;
            this.LbPass.Text = "口令(&K)";
            // 
            // TbPass
            // 
            this.TbPass.Location = new System.Drawing.Point(103, 81);
            this.TbPass.Name = "TbPass";
            this.TbPass.Size = new System.Drawing.Size(100, 21);
            this.TbPass.TabIndex = 4;
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(82, 117);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 5;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            // 
            // BtNo
            // 
            this.BtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtNo.Location = new System.Drawing.Point(163, 117);
            this.BtNo.Name = "BtNo";
            this.BtNo.Size = new System.Drawing.Size(75, 23);
            this.BtNo.TabIndex = 6;
            this.BtNo.Text = "取消(&C)";
            this.BtNo.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Me.Amon.Properties.Resources.Guid;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 40);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SignRc
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtNo;
            this.ClientSize = new System.Drawing.Size(250, 152);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.TbPass);
            this.Controls.Add(this.LbPass);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignRc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SignRc";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbPass;
        private System.Windows.Forms.TextBox TbPass;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtNo;
    }
}
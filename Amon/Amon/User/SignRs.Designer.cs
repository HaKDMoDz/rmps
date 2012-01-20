namespace Me.Amon.User
{
    partial class SignRs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignRs));
            this.BtOk = new System.Windows.Forms.Button();
            this.BtNo = new System.Windows.Forms.Button();
            this.TbPass = new System.Windows.Forms.TextBox();
            this.LbPass = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LbName = new System.Windows.Forms.Label();
            this.PbGuid = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbGuid)).BeginInit();
            this.SuspendLayout();
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(82, 122);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 10;
            this.BtOk.Text = "登录(&S)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // BtNo
            // 
            this.BtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtNo.Location = new System.Drawing.Point(163, 122);
            this.BtNo.Name = "BtNo";
            this.BtNo.Size = new System.Drawing.Size(75, 23);
            this.BtNo.TabIndex = 11;
            this.BtNo.Text = "取消(&C)";
            this.BtNo.UseVisualStyleBackColor = true;
            this.BtNo.Click += new System.EventHandler(this.BtNo_Click);
            // 
            // TbPass
            // 
            this.TbPass.Location = new System.Drawing.Point(87, 87);
            this.TbPass.Name = "TbPass";
            this.TbPass.PasswordChar = '*';
            this.TbPass.Size = new System.Drawing.Size(100, 21);
            this.TbPass.TabIndex = 9;
            // 
            // LbPass
            // 
            this.LbPass.AutoSize = true;
            this.LbPass.Location = new System.Drawing.Point(34, 90);
            this.LbPass.Name = "LbPass";
            this.LbPass.Size = new System.Drawing.Size(47, 12);
            this.LbPass.TabIndex = 8;
            this.LbPass.Text = "口令(&K)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(87, 60);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(100, 21);
            this.TbName.TabIndex = 7;
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(34, 63);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(47, 12);
            this.LbName.TabIndex = 6;
            this.LbName.Text = "用户(&U)";
            // 
            // PbGuid
            // 
            this.PbGuid.Image = global::Me.Amon.Properties.Resources.Guid;
            this.PbGuid.Location = new System.Drawing.Point(0, 0);
            this.PbGuid.Name = "PbGuid";
            this.PbGuid.Size = new System.Drawing.Size(250, 40);
            this.PbGuid.TabIndex = 0;
            this.PbGuid.TabStop = false;
            // 
            // SignRs
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtNo;
            this.ClientSize = new System.Drawing.Size(250, 157);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.TbPass);
            this.Controls.Add(this.LbPass);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.Controls.Add(this.PbGuid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignRs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SignRs";
            ((System.ComponentModel.ISupportInitialize)(this.PbGuid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbGuid;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtNo;
        private System.Windows.Forms.TextBox TbPass;
        private System.Windows.Forms.Label LbPass;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbName;
    }
}
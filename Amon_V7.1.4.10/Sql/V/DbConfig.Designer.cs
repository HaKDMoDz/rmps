namespace Me.Amon.Sql.V
{
    partial class DbConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbConfig));
            this.LlDriver = new System.Windows.Forms.Label();
            this.CbDriver = new System.Windows.Forms.ComboBox();
            this.LlUri = new System.Windows.Forms.Label();
            this.TbUri = new System.Windows.Forms.TextBox();
            this.LbUser = new System.Windows.Forms.Label();
            this.TbUser = new System.Windows.Forms.TextBox();
            this.LlPass = new System.Windows.Forms.Label();
            this.TbPass = new System.Windows.Forms.TextBox();
            this.BnOk = new System.Windows.Forms.Button();
            this.BnNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LlDriver
            // 
            this.LlDriver.AutoSize = true;
            this.LlDriver.Location = new System.Drawing.Point(28, 25);
            this.LlDriver.Name = "LlDriver";
            this.LlDriver.Size = new System.Drawing.Size(83, 12);
            this.LlDriver.TabIndex = 0;
            this.LlDriver.Text = "数据库引擎(&E)";
            // 
            // CbDriver
            // 
            this.CbDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbDriver.FormattingEnabled = true;
            this.CbDriver.Location = new System.Drawing.Point(117, 22);
            this.CbDriver.Name = "CbDriver";
            this.CbDriver.Size = new System.Drawing.Size(121, 20);
            this.CbDriver.TabIndex = 1;
            // 
            // LlUri
            // 
            this.LlUri.AutoSize = true;
            this.LlUri.Location = new System.Drawing.Point(28, 51);
            this.LlUri.Name = "LlUri";
            this.LlUri.Size = new System.Drawing.Size(83, 12);
            this.LlUri.TabIndex = 2;
            this.LlUri.Text = "数据源路径(&U)";
            // 
            // TbUri
            // 
            this.TbUri.Location = new System.Drawing.Point(117, 48);
            this.TbUri.Name = "TbUri";
            this.TbUri.Size = new System.Drawing.Size(121, 21);
            this.TbUri.TabIndex = 3;
            // 
            // LbUser
            // 
            this.LbUser.AutoSize = true;
            this.LbUser.Location = new System.Drawing.Point(28, 78);
            this.LbUser.Name = "LbUser";
            this.LbUser.Size = new System.Drawing.Size(71, 12);
            this.LbUser.TabIndex = 4;
            this.LbUser.Text = "登录用户(&U)";
            // 
            // TbUser
            // 
            this.TbUser.Location = new System.Drawing.Point(117, 75);
            this.TbUser.Name = "TbUser";
            this.TbUser.Size = new System.Drawing.Size(121, 21);
            this.TbUser.TabIndex = 5;
            // 
            // LlPass
            // 
            this.LlPass.AutoSize = true;
            this.LlPass.Location = new System.Drawing.Point(28, 105);
            this.LlPass.Name = "LlPass";
            this.LlPass.Size = new System.Drawing.Size(71, 12);
            this.LlPass.TabIndex = 6;
            this.LlPass.Text = "登录口令(&P)";
            // 
            // TbPass
            // 
            this.TbPass.Location = new System.Drawing.Point(117, 102);
            this.TbPass.Name = "TbPass";
            this.TbPass.Size = new System.Drawing.Size(121, 21);
            this.TbPass.TabIndex = 7;
            this.TbPass.UseSystemPasswordChar = true;
            // 
            // BnOk
            // 
            this.BnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnOk.Location = new System.Drawing.Point(99, 139);
            this.BnOk.Name = "BnOk";
            this.BnOk.Size = new System.Drawing.Size(75, 23);
            this.BnOk.TabIndex = 8;
            this.BnOk.Text = "确定(&O)";
            this.BnOk.UseVisualStyleBackColor = true;
            this.BnOk.Click += new System.EventHandler(this.BnOk_Click);
            // 
            // BnNo
            // 
            this.BnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BnNo.Location = new System.Drawing.Point(180, 139);
            this.BnNo.Name = "BnNo";
            this.BnNo.Size = new System.Drawing.Size(75, 23);
            this.BnNo.TabIndex = 9;
            this.BnNo.Text = "取消(&C)";
            this.BnNo.UseVisualStyleBackColor = true;
            this.BnNo.Click += new System.EventHandler(this.BnNo_Click);
            // 
            // DbConfig
            // 
            this.AcceptButton = this.BnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BnNo;
            this.ClientSize = new System.Drawing.Size(267, 174);
            this.Controls.Add(this.BnNo);
            this.Controls.Add(this.BnOk);
            this.Controls.Add(this.TbPass);
            this.Controls.Add(this.LlPass);
            this.Controls.Add(this.TbUser);
            this.Controls.Add(this.LbUser);
            this.Controls.Add(this.TbUri);
            this.Controls.Add(this.LlUri);
            this.Controls.Add(this.CbDriver);
            this.Controls.Add(this.LlDriver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DbConfig";
            this.Text = "DbConfig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LlDriver;
        private System.Windows.Forms.ComboBox CbDriver;
        private System.Windows.Forms.Label LlUri;
        private System.Windows.Forms.TextBox TbUri;
        private System.Windows.Forms.Label LbUser;
        private System.Windows.Forms.TextBox TbUser;
        private System.Windows.Forms.Label LlPass;
        private System.Windows.Forms.TextBox TbPass;
        private System.Windows.Forms.Button BnOk;
        private System.Windows.Forms.Button BnNo;
    }
}
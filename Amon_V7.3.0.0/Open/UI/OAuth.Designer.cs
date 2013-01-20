namespace Me.Amon.Open.UI
{
    partial class OAuth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OAuth));
            this.PbOAuth = new System.Windows.Forms.PictureBox();
            this.LlOAuth = new System.Windows.Forms.Label();
            this.PlBrowser = new System.Windows.Forms.Panel();
            this.WbBrowser = new System.Windows.Forms.WebBrowser();
            this.LlToken = new System.Windows.Forms.Label();
            this.TbToken = new System.Windows.Forms.TextBox();
            this.BtOk = new System.Windows.Forms.Button();
            this.BtNo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PbOAuth)).BeginInit();
            this.PlBrowser.SuspendLayout();
            this.SuspendLayout();
            // 
            // PbOAuth
            // 
            this.PbOAuth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbOAuth.Image = ((System.Drawing.Image)(resources.GetObject("PbOAuth.Image")));
            this.PbOAuth.Location = new System.Drawing.Point(12, 12);
            this.PbOAuth.Name = "PbOAuth";
            this.PbOAuth.Size = new System.Drawing.Size(66, 66);
            this.PbOAuth.TabIndex = 0;
            this.PbOAuth.TabStop = false;
            // 
            // LlOAuth
            // 
            this.LlOAuth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LlOAuth.Location = new System.Drawing.Point(82, 12);
            this.LlOAuth.Name = "LlOAuth";
            this.LlOAuth.Size = new System.Drawing.Size(690, 66);
            this.LlOAuth.TabIndex = 1;
            this.LlOAuth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PlBrowser
            // 
            this.PlBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlBrowser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlBrowser.Controls.Add(this.WbBrowser);
            this.PlBrowser.Location = new System.Drawing.Point(12, 84);
            this.PlBrowser.Name = "PlBrowser";
            this.PlBrowser.Size = new System.Drawing.Size(760, 436);
            this.PlBrowser.TabIndex = 2;
            // 
            // WbBrowser
            // 
            this.WbBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WbBrowser.Location = new System.Drawing.Point(0, 0);
            this.WbBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.WbBrowser.Name = "WbBrowser";
            this.WbBrowser.Size = new System.Drawing.Size(758, 434);
            this.WbBrowser.TabIndex = 0;
            // 
            // LlToken
            // 
            this.LlToken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LlToken.AutoSize = true;
            this.LlToken.Location = new System.Drawing.Point(12, 531);
            this.LlToken.Name = "LlToken";
            this.LlToken.Size = new System.Drawing.Size(59, 12);
            this.LlToken.TabIndex = 3;
            this.LlToken.Text = "授权码(&T)";
            // 
            // TbToken
            // 
            this.TbToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbToken.Location = new System.Drawing.Point(77, 527);
            this.TbToken.Name = "TbToken";
            this.TbToken.Size = new System.Drawing.Size(533, 21);
            this.TbToken.TabIndex = 4;
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(616, 526);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 5;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // BtNo
            // 
            this.BtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtNo.Location = new System.Drawing.Point(697, 526);
            this.BtNo.Name = "BtNo";
            this.BtNo.Size = new System.Drawing.Size(75, 23);
            this.BtNo.TabIndex = 6;
            this.BtNo.Text = "取消(&C)";
            this.BtNo.UseVisualStyleBackColor = true;
            this.BtNo.Click += new System.EventHandler(this.BtNo_Click);
            // 
            // OAuth
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtNo;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.TbToken);
            this.Controls.Add(this.LlToken);
            this.Controls.Add(this.PlBrowser);
            this.Controls.Add(this.LlOAuth);
            this.Controls.Add(this.PbOAuth);
            this.Name = "OAuth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "应用授权";
            this.Load += new System.EventHandler(this.Auth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbOAuth)).EndInit();
            this.PlBrowser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbOAuth;
        private System.Windows.Forms.Label LlOAuth;
        private System.Windows.Forms.Panel PlBrowser;
        private System.Windows.Forms.WebBrowser WbBrowser;
        private System.Windows.Forms.Label LlToken;
        private System.Windows.Forms.TextBox TbToken;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtNo;
    }
}
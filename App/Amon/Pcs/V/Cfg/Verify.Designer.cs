﻿namespace Me.Amon.Pcs.V.Cfg
{
    partial class Verify
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
            this.PlBrowser = new System.Windows.Forms.Panel();
            this.WbBrowser = new System.Windows.Forms.WebBrowser();
            this.LlToken = new System.Windows.Forms.Label();
            this.TbToken = new System.Windows.Forms.TextBox();
            this.PlBrowser.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlBrowser
            // 
            this.PlBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PlBrowser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlBrowser.Controls.Add(this.WbBrowser);
            this.PlBrowser.Location = new System.Drawing.Point(3, 3);
            this.PlBrowser.Name = "PlBrowser";
            this.PlBrowser.Size = new System.Drawing.Size(413, 220);
            this.PlBrowser.TabIndex = 0;
            // 
            // WbBrowser
            // 
            this.WbBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WbBrowser.Location = new System.Drawing.Point(0, 0);
            this.WbBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.WbBrowser.Name = "WbBrowser";
            this.WbBrowser.Size = new System.Drawing.Size(411, 218);
            this.WbBrowser.TabIndex = 0;
            // 
            // LlToken
            // 
            this.LlToken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LlToken.AutoSize = true;
            this.LlToken.Location = new System.Drawing.Point(3, 232);
            this.LlToken.Name = "LlToken";
            this.LlToken.Size = new System.Drawing.Size(53, 12);
            this.LlToken.TabIndex = 1;
            this.LlToken.Text = "授权码：";
            // 
            // TbToken
            // 
            this.TbToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TbToken.Location = new System.Drawing.Point(62, 229);
            this.TbToken.Name = "TbToken";
            this.TbToken.Size = new System.Drawing.Size(354, 21);
            this.TbToken.TabIndex = 2;
            // 
            // Verify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbToken);
            this.Controls.Add(this.LlToken);
            this.Controls.Add(this.PlBrowser);
            this.Name = "Verify";
            this.Size = new System.Drawing.Size(419, 253);
            this.PlBrowser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PlBrowser;
        private System.Windows.Forms.WebBrowser WbBrowser;
        private System.Windows.Forms.Label LlToken;
        private System.Windows.Forms.TextBox TbToken;
    }
}

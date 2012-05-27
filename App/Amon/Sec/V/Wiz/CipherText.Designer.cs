namespace Me.Amon.Sec.V.Wiz
{
    partial class CipherText
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
            this.LbSrc = new System.Windows.Forms.Label();
            this.TbSrc = new System.Windows.Forms.TextBox();
            this.LbDst = new System.Windows.Forms.Label();
            this.TbDst = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LbSrc
            // 
            this.LbSrc.AutoSize = true;
            this.LbSrc.Location = new System.Drawing.Point(0, 3);
            this.LbSrc.Name = "LbSrc";
            this.LbSrc.Size = new System.Drawing.Size(47, 12);
            this.LbSrc.TabIndex = 0;
            this.LbSrc.Text = "明文(&S)";
            // 
            // TbSrc
            // 
            this.TbSrc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbSrc.Location = new System.Drawing.Point(0, 18);
            this.TbSrc.Multiline = true;
            this.TbSrc.Name = "TbSrc";
            this.TbSrc.Size = new System.Drawing.Size(240, 73);
            this.TbSrc.TabIndex = 1;
            // 
            // LbDst
            // 
            this.LbDst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LbDst.AutoSize = true;
            this.LbDst.Location = new System.Drawing.Point(0, 94);
            this.LbDst.Name = "LbDst";
            this.LbDst.Size = new System.Drawing.Size(47, 12);
            this.LbDst.TabIndex = 2;
            this.LbDst.Text = "密文(&D)";
            // 
            // TbDst
            // 
            this.TbDst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbDst.Location = new System.Drawing.Point(0, 109);
            this.TbDst.Multiline = true;
            this.TbDst.Name = "TbDst";
            this.TbDst.ReadOnly = true;
            this.TbDst.Size = new System.Drawing.Size(240, 73);
            this.TbDst.TabIndex = 3;
            // 
            // CipherText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbDst);
            this.Controls.Add(this.LbDst);
            this.Controls.Add(this.TbSrc);
            this.Controls.Add(this.LbSrc);
            this.Name = "CipherText";
            this.Size = new System.Drawing.Size(240, 183);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbSrc;
        private System.Windows.Forms.TextBox TbSrc;
        private System.Windows.Forms.Label LbDst;
        private System.Windows.Forms.TextBox TbDst;
    }
}

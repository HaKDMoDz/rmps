namespace Me.Amon.Sec.Wiz
{
    partial class DigestText
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
            this.TbDst = new System.Windows.Forms.TextBox();
            this.LbDst = new System.Windows.Forms.Label();
            this.TbSrc = new System.Windows.Forms.TextBox();
            this.LbSrc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TbDst
            // 
            this.TbDst.Location = new System.Drawing.Point(0, 108);
            this.TbDst.Multiline = true;
            this.TbDst.Name = "TbDst";
            this.TbDst.ReadOnly = true;
            this.TbDst.Size = new System.Drawing.Size(240, 73);
            this.TbDst.TabIndex = 3;
            // 
            // LbDst
            // 
            this.LbDst.AutoSize = true;
            this.LbDst.Location = new System.Drawing.Point(0, 93);
            this.LbDst.Name = "LbDst";
            this.LbDst.Size = new System.Drawing.Size(47, 12);
            this.LbDst.TabIndex = 2;
            this.LbDst.Text = "密文(&D)";
            // 
            // TbSrc
            // 
            this.TbSrc.Location = new System.Drawing.Point(0, 17);
            this.TbSrc.Multiline = true;
            this.TbSrc.Name = "TbSrc";
            this.TbSrc.Size = new System.Drawing.Size(240, 73);
            this.TbSrc.TabIndex = 1;
            // 
            // LbSrc
            // 
            this.LbSrc.AutoSize = true;
            this.LbSrc.Location = new System.Drawing.Point(0, 2);
            this.LbSrc.Name = "LbSrc";
            this.LbSrc.Size = new System.Drawing.Size(47, 12);
            this.LbSrc.TabIndex = 0;
            this.LbSrc.Text = "明文(&S)";
            // 
            // DigestText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbDst);
            this.Controls.Add(this.LbDst);
            this.Controls.Add(this.TbSrc);
            this.Controls.Add(this.LbSrc);
            this.Name = "DigestText";
            this.Size = new System.Drawing.Size(240, 183);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbDst;
        private System.Windows.Forms.Label LbDst;
        private System.Windows.Forms.TextBox TbSrc;
        private System.Windows.Forms.Label LbSrc;
    }
}

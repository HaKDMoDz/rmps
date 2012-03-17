namespace Me.Amon.Sec.Wiz
{
    partial class CipherFile
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
            this.BtSrc = new System.Windows.Forms.Button();
            this.LbDst = new System.Windows.Forms.Label();
            this.TbDst = new System.Windows.Forms.TextBox();
            this.BtDst = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbSrc
            // 
            this.LbSrc.AutoSize = true;
            this.LbSrc.Location = new System.Drawing.Point(3, 6);
            this.LbSrc.Name = "LbSrc";
            this.LbSrc.Size = new System.Drawing.Size(71, 12);
            this.LbSrc.TabIndex = 0;
            this.LbSrc.Text = "输入文件(&I)";
            // 
            // TbSrc
            // 
            this.TbSrc.Location = new System.Drawing.Point(3, 21);
            this.TbSrc.Name = "TbSrc";
            this.TbSrc.Size = new System.Drawing.Size(100, 21);
            this.TbSrc.TabIndex = 1;
            // 
            // BtSrc
            // 
            this.BtSrc.Location = new System.Drawing.Point(109, 19);
            this.BtSrc.Name = "BtSrc";
            this.BtSrc.Size = new System.Drawing.Size(75, 23);
            this.BtSrc.TabIndex = 2;
            this.BtSrc.Text = "button1";
            this.BtSrc.UseVisualStyleBackColor = true;
            // 
            // LbDst
            // 
            this.LbDst.AutoSize = true;
            this.LbDst.Location = new System.Drawing.Point(3, 45);
            this.LbDst.Name = "LbDst";
            this.LbDst.Size = new System.Drawing.Size(71, 12);
            this.LbDst.TabIndex = 3;
            this.LbDst.Text = "输出文件(&S)";
            // 
            // TbDst
            // 
            this.TbDst.Location = new System.Drawing.Point(3, 60);
            this.TbDst.Name = "TbDst";
            this.TbDst.Size = new System.Drawing.Size(100, 21);
            this.TbDst.TabIndex = 4;
            // 
            // BtDst
            // 
            this.BtDst.Location = new System.Drawing.Point(109, 58);
            this.BtDst.Name = "BtDst";
            this.BtDst.Size = new System.Drawing.Size(75, 23);
            this.BtDst.TabIndex = 5;
            this.BtDst.Text = "button2";
            this.BtDst.UseVisualStyleBackColor = true;
            // 
            // CipherFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtDst);
            this.Controls.Add(this.TbDst);
            this.Controls.Add(this.LbDst);
            this.Controls.Add(this.BtSrc);
            this.Controls.Add(this.TbSrc);
            this.Controls.Add(this.LbSrc);
            this.Name = "CipherFile";
            this.Size = new System.Drawing.Size(218, 207);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbSrc;
        private System.Windows.Forms.TextBox TbSrc;
        private System.Windows.Forms.Button BtSrc;
        private System.Windows.Forms.Label LbDst;
        private System.Windows.Forms.TextBox TbDst;
        private System.Windows.Forms.Button BtDst;
    }
}

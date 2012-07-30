namespace Me.Amon.Sec.V.Wiz
{
    partial class AText
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
            this.ScText = new System.Windows.Forms.SplitContainer();
            this.TbSrc = new System.Windows.Forms.TextBox();
            this.TbDst = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ScText)).BeginInit();
            this.ScText.Panel1.SuspendLayout();
            this.ScText.Panel2.SuspendLayout();
            this.ScText.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScText
            // 
            this.ScText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScText.Location = new System.Drawing.Point(3, 3);
            this.ScText.Name = "ScText";
            this.ScText.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ScText.Panel1
            // 
            this.ScText.Panel1.Controls.Add(this.TbSrc);
            // 
            // ScText.Panel2
            // 
            this.ScText.Panel2.Controls.Add(this.TbDst);
            this.ScText.Size = new System.Drawing.Size(144, 144);
            this.ScText.SplitterDistance = 89;
            this.ScText.TabIndex = 0;
            // 
            // TbSrc
            // 
            this.TbSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbSrc.Location = new System.Drawing.Point(0, 0);
            this.TbSrc.Multiline = true;
            this.TbSrc.Name = "TbSrc";
            this.TbSrc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbSrc.Size = new System.Drawing.Size(144, 89);
            this.TbSrc.TabIndex = 0;
            // 
            // TbDst
            // 
            this.TbDst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbDst.Location = new System.Drawing.Point(0, 0);
            this.TbDst.Multiline = true;
            this.TbDst.Name = "TbDst";
            this.TbDst.ReadOnly = true;
            this.TbDst.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbDst.Size = new System.Drawing.Size(144, 51);
            this.TbDst.TabIndex = 0;
            // 
            // AText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ScText);
            this.Name = "AText";
            this.ScText.Panel1.ResumeLayout(false);
            this.ScText.Panel1.PerformLayout();
            this.ScText.Panel2.ResumeLayout(false);
            this.ScText.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScText)).EndInit();
            this.ScText.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.SplitContainer ScText;
        public System.Windows.Forms.TextBox TbSrc;
        public System.Windows.Forms.TextBox TbDst;
    }
}

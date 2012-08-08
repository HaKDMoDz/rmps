namespace Me.Amon.Img.V.Pro
{
    partial class BeanPos
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
            this.TlLabel = new System.Windows.Forms.Label();
            this.TrLabel = new System.Windows.Forms.Label();
            this.BlLabel = new System.Windows.Forms.Label();
            this.BrLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TlLabel
            // 
            this.TlLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TlLabel.Location = new System.Drawing.Point(0, 0);
            this.TlLabel.Name = "TlLabel";
            this.TlLabel.Size = new System.Drawing.Size(16, 16);
            this.TlLabel.TabIndex = 0;
            this.TlLabel.Click += new System.EventHandler(this.TlLabel_Click);
            // 
            // TrLabel
            // 
            this.TrLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TrLabel.Location = new System.Drawing.Point(114, 0);
            this.TrLabel.Name = "TrLabel";
            this.TrLabel.Size = new System.Drawing.Size(16, 16);
            this.TrLabel.TabIndex = 1;
            this.TrLabel.Click += new System.EventHandler(this.TrLabel_Click);
            // 
            // BlLabel
            // 
            this.BlLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BlLabel.Location = new System.Drawing.Point(0, 59);
            this.BlLabel.Name = "BlLabel";
            this.BlLabel.Size = new System.Drawing.Size(16, 16);
            this.BlLabel.TabIndex = 2;
            this.BlLabel.Click += new System.EventHandler(this.BlLabel_Click);
            // 
            // BrLabel
            // 
            this.BrLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BrLabel.Location = new System.Drawing.Point(114, 59);
            this.BrLabel.Name = "BrLabel";
            this.BrLabel.Size = new System.Drawing.Size(16, 16);
            this.BrLabel.TabIndex = 3;
            this.BrLabel.Click += new System.EventHandler(this.BrLabel_Click);
            // 
            // BeanPos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BrLabel);
            this.Controls.Add(this.BlLabel);
            this.Controls.Add(this.TrLabel);
            this.Controls.Add(this.TlLabel);
            this.Name = "BeanPos";
            this.Size = new System.Drawing.Size(130, 75);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TlLabel;
        private System.Windows.Forms.Label TrLabel;
        private System.Windows.Forms.Label BlLabel;
        private System.Windows.Forms.Label BrLabel;
    }
}

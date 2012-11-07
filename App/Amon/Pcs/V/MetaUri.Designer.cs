namespace Me.Amon.Pcs.V
{
    partial class MetaUri
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
            this.LlUri = new System.Windows.Forms.Label();
            this.TbUri = new System.Windows.Forms.TextBox();
            this.BnUri = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LlUri
            // 
            this.LlUri.Location = new System.Drawing.Point(3, 7);
            this.LlUri.Name = "LlUri";
            this.LlUri.Size = new System.Drawing.Size(64, 18);
            this.LlUri.TabIndex = 0;
            this.LlUri.Text = "首页：";
            this.LlUri.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TbUri
            // 
            this.TbUri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TbUri.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TbUri.Location = new System.Drawing.Point(73, 3);
            this.TbUri.Name = "TbUri";
            this.TbUri.Size = new System.Drawing.Size(309, 26);
            this.TbUri.TabIndex = 1;
            this.TbUri.Text = "pcs://首页";
            // 
            // BnUri
            // 
            this.BnUri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BnUri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BnUri.Location = new System.Drawing.Point(388, 6);
            this.BnUri.Name = "BnUri";
            this.BnUri.Size = new System.Drawing.Size(20, 20);
            this.BnUri.TabIndex = 2;
            this.BnUri.UseVisualStyleBackColor = true;
            // 
            // MetaUri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BnUri);
            this.Controls.Add(this.TbUri);
            this.Controls.Add(this.LlUri);
            this.Name = "MetaUri";
            this.Size = new System.Drawing.Size(411, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LlUri;
        private System.Windows.Forms.TextBox TbUri;
        private System.Windows.Forms.Button BnUri;
    }
}

namespace Me.Amon.Uc
{
    partial class Tips
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
            this.LlTips = new System.Windows.Forms.Label();
            this.PbHide = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbHide)).BeginInit();
            this.SuspendLayout();
            // 
            // LlTips
            // 
            this.LlTips.AutoSize = true;
            this.LlTips.Location = new System.Drawing.Point(26, 55);
            this.LlTips.Name = "LlTips";
            this.LlTips.Size = new System.Drawing.Size(41, 12);
            this.LlTips.TabIndex = 0;
            this.LlTips.Text = "label1";
            // 
            // PbHide
            // 
            this.PbHide.Location = new System.Drawing.Point(193, 35);
            this.PbHide.Name = "PbHide";
            this.PbHide.Size = new System.Drawing.Size(16, 16);
            this.PbHide.TabIndex = 1;
            this.PbHide.TabStop = false;
            this.PbHide.Click += new System.EventHandler(this.PbHide_Click);
            // 
            // Tips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.PbHide);
            this.Controls.Add(this.LlTips);
            this.Name = "Tips";
            this.Size = new System.Drawing.Size(270, 150);
            ((System.ComponentModel.ISupportInitialize)(this.PbHide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LlTips;
        private System.Windows.Forms.PictureBox PbHide;
    }
}

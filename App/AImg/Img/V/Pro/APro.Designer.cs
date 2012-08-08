namespace Me.Amon.Img.V.Pro
{
    partial class APro
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
            this.ScPanel = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.ScPanel)).BeginInit();
            this.ScPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScPanel
            // 
            this.ScPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ScPanel.Location = new System.Drawing.Point(0, 0);
            this.ScPanel.Name = "ScPanel";
            this.ScPanel.Panel1MinSize = 200;
            this.ScPanel.Size = new System.Drawing.Size(480, 320);
            this.ScPanel.SplitterDistance = 200;
            this.ScPanel.TabIndex = 0;
            // 
            // APro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ScPanel);
            this.Name = "APro";
            this.Size = new System.Drawing.Size(480, 320);
            ((System.ComponentModel.ISupportInitialize)(this.ScPanel)).EndInit();
            this.ScPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer ScPanel;
    }
}

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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucOpt1 = new Me.Amon.Img.V.Pro.UcOpt();
            this.ucImg1 = new Me.Amon.Img.V.Pro.UcImg();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucOpt1);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucImg1);
            this.splitContainer1.Size = new System.Drawing.Size(480, 320);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 0;
            // 
            // ucOpt1
            // 
            this.ucOpt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucOpt1.Location = new System.Drawing.Point(0, 0);
            this.ucOpt1.Name = "ucOpt1";
            this.ucOpt1.Size = new System.Drawing.Size(200, 320);
            this.ucOpt1.TabIndex = 0;
            // 
            // ucImg1
            // 
            this.ucImg1.AllowDrop = true;
            this.ucImg1.AutoScroll = true;
            this.ucImg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucImg1.Location = new System.Drawing.Point(0, 0);
            this.ucImg1.Name = "ucImg1";
            this.ucImg1.Size = new System.Drawing.Size(276, 320);
            this.ucImg1.TabIndex = 0;
            // 
            // APro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "APro";
            this.Size = new System.Drawing.Size(480, 320);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private UcOpt ucOpt1;
        private UcImg ucImg1;
    }
}

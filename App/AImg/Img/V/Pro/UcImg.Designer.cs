namespace Me.Amon.Img.V.Pro
{
    partial class UcImg
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
            this.PbImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbImg)).BeginInit();
            this.SuspendLayout();
            // 
            // PbImg
            // 
            this.PbImg.Location = new System.Drawing.Point(26, 49);
            this.PbImg.Name = "PbImg";
            this.PbImg.Size = new System.Drawing.Size(100, 50);
            this.PbImg.TabIndex = 0;
            this.PbImg.TabStop = false;
            this.PbImg.Click += new System.EventHandler(this.PbImg_Click);
            // 
            // UcImg
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.PbImg);
            this.Name = "UcImg";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.UcImg_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.UcImg_DragEnter);
            this.Resize += new System.EventHandler(this.UcImg_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.PbImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PbImg;
    }
}

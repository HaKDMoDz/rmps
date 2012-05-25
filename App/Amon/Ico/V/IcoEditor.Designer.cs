namespace Me.Amon.Ico
{
    partial class IcoEditor
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
            this.LbImg = new System.Windows.Forms.ListBox();
            this.PbImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbImg)).BeginInit();
            this.SuspendLayout();
            // 
            // LbImg
            // 
            this.LbImg.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LbImg.FormattingEnabled = true;
            this.LbImg.IntegralHeight = false;
            this.LbImg.Location = new System.Drawing.Point(0, 0);
            this.LbImg.Name = "LbImg";
            this.LbImg.Size = new System.Drawing.Size(120, 260);
            this.LbImg.TabIndex = 0;
            this.LbImg.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LbImg_DrawItem);
            this.LbImg.SelectedIndexChanged += new System.EventHandler(this.LbImg_SelectedIndexChanged);
            // 
            // PbImg
            // 
            this.PbImg.Location = new System.Drawing.Point(126, 0);
            this.PbImg.Name = "PbImg";
            this.PbImg.Size = new System.Drawing.Size(256, 260);
            this.PbImg.TabIndex = 1;
            this.PbImg.TabStop = false;
            // 
            // IcoEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbImg);
            this.Controls.Add(this.LbImg);
            this.Name = "IcoEditor";
            this.Size = new System.Drawing.Size(486, 260);
            ((System.ComponentModel.ISupportInitialize)(this.PbImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LbImg;
        private System.Windows.Forms.PictureBox PbImg;

    }
}

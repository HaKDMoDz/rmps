namespace Me.Amon.Img.V.Pro
{
    partial class OptWater
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
            this.LlFile = new System.Windows.Forms.Label();
            this.TbFile = new System.Windows.Forms.TextBox();
            this.PbFile = new System.Windows.Forms.PictureBox();
            this.LlLoc = new System.Windows.Forms.Label();
            this.UcLoc = new System.Windows.Forms.Panel();
            this.LlAlpha = new System.Windows.Forms.Label();
            this.SpAlpha = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.PbFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpAlpha)).BeginInit();
            this.SuspendLayout();
            // 
            // LlFile
            // 
            this.LlFile.AutoSize = true;
            this.LlFile.Location = new System.Drawing.Point(3, 6);
            this.LlFile.Name = "LlFile";
            this.LlFile.Size = new System.Drawing.Size(71, 12);
            this.LlFile.TabIndex = 0;
            this.LlFile.Text = "水印图像(&I)";
            // 
            // TbFile
            // 
            this.TbFile.Location = new System.Drawing.Point(80, 3);
            this.TbFile.Name = "TbFile";
            this.TbFile.Size = new System.Drawing.Size(100, 21);
            this.TbFile.TabIndex = 1;
            // 
            // PbFile
            // 
            this.PbFile.Location = new System.Drawing.Point(186, 6);
            this.PbFile.Name = "PbFile";
            this.PbFile.Size = new System.Drawing.Size(16, 16);
            this.PbFile.TabIndex = 2;
            this.PbFile.TabStop = false;
            // 
            // LlLoc
            // 
            this.LlLoc.AutoSize = true;
            this.LlLoc.Location = new System.Drawing.Point(3, 34);
            this.LlLoc.Name = "LlLoc";
            this.LlLoc.Size = new System.Drawing.Size(71, 12);
            this.LlLoc.TabIndex = 3;
            this.LlLoc.Text = "水印位置(&P)";
            // 
            // UcLoc
            // 
            this.UcLoc.Location = new System.Drawing.Point(31, 49);
            this.UcLoc.Name = "UcLoc";
            this.UcLoc.Size = new System.Drawing.Size(149, 61);
            this.UcLoc.TabIndex = 4;
            // 
            // LlAlpha
            // 
            this.LlAlpha.AutoSize = true;
            this.LlAlpha.Location = new System.Drawing.Point(3, 121);
            this.LlAlpha.Name = "LlAlpha";
            this.LlAlpha.Size = new System.Drawing.Size(59, 12);
            this.LlAlpha.TabIndex = 5;
            this.LlAlpha.Text = "透明度(&T)";
            // 
            // SpAlpha
            // 
            this.SpAlpha.Location = new System.Drawing.Point(80, 116);
            this.SpAlpha.Name = "SpAlpha";
            this.SpAlpha.Size = new System.Drawing.Size(56, 21);
            this.SpAlpha.TabIndex = 6;
            this.SpAlpha.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // OptWater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SpAlpha);
            this.Controls.Add(this.LlAlpha);
            this.Controls.Add(this.UcLoc);
            this.Controls.Add(this.LlLoc);
            this.Controls.Add(this.PbFile);
            this.Controls.Add(this.TbFile);
            this.Controls.Add(this.LlFile);
            this.Name = "OptWater";
            this.Size = new System.Drawing.Size(205, 315);
            ((System.ComponentModel.ISupportInitialize)(this.PbFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpAlpha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LlFile;
        private System.Windows.Forms.TextBox TbFile;
        private System.Windows.Forms.PictureBox PbFile;
        private System.Windows.Forms.Label LlLoc;
        private System.Windows.Forms.Panel UcLoc;
        private System.Windows.Forms.Label LlAlpha;
        private System.Windows.Forms.NumericUpDown SpAlpha;
    }
}

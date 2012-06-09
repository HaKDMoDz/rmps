namespace Me.Amon.Sec.V.Wiz
{
    partial class DigestFile
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
            this.GvFile = new System.Windows.Forms.DataGridView();
            this.TbHash = new System.Windows.Forms.TextBox();
            this.LlHash = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GvFile)).BeginInit();
            this.SuspendLayout();
            // 
            // GvFile
            // 
            this.GvFile.AllowDrop = true;
            this.GvFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GvFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvFile.Location = new System.Drawing.Point(3, 3);
            this.GvFile.Name = "GvFile";
            this.GvFile.RowTemplate.Height = 23;
            this.GvFile.Size = new System.Drawing.Size(234, 150);
            this.GvFile.TabIndex = 0;
            // 
            // TbHash
            // 
            this.TbHash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbHash.Location = new System.Drawing.Point(56, 159);
            this.TbHash.Name = "TbHash";
            this.TbHash.ReadOnly = true;
            this.TbHash.Size = new System.Drawing.Size(181, 21);
            this.TbHash.TabIndex = 1;
            // 
            // LlHash
            // 
            this.LlHash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LlHash.AutoSize = true;
            this.LlHash.Location = new System.Drawing.Point(3, 162);
            this.LlHash.Name = "LlHash";
            this.LlHash.Size = new System.Drawing.Size(47, 12);
            this.LlHash.TabIndex = 2;
            this.LlHash.Text = "摘要(&K)";
            // 
            // DigestFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbHash);
            this.Controls.Add(this.LlHash);
            this.Controls.Add(this.GvFile);
            this.Name = "DigestFile";
            this.Size = new System.Drawing.Size(240, 183);
            ((System.ComponentModel.ISupportInitialize)(this.GvFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GvFile;
        private System.Windows.Forms.TextBox TbHash;
        private System.Windows.Forms.Label LlHash;


    }
}

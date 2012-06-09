namespace Me.Amon.Sec.V.Wiz
{
    partial class CipherFile
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
            this.LlPass = new System.Windows.Forms.Label();
            this.TbPass = new System.Windows.Forms.TextBox();
            this.SrcFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DstFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GvFile)).BeginInit();
            this.SuspendLayout();
            // 
            // GvFile
            // 
            this.GvFile.AllowDrop = true;
            this.GvFile.AllowUserToAddRows = false;
            this.GvFile.AllowUserToDeleteRows = false;
            this.GvFile.AllowUserToResizeRows = false;
            this.GvFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GvFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrcFile,
            this.DstFile});
            this.GvFile.Location = new System.Drawing.Point(3, 3);
            this.GvFile.MultiSelect = false;
            this.GvFile.Name = "GvFile";
            this.GvFile.ReadOnly = true;
            this.GvFile.RowHeadersVisible = false;
            this.GvFile.RowTemplate.Height = 23;
            this.GvFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GvFile.Size = new System.Drawing.Size(234, 150);
            this.GvFile.TabIndex = 0;
            this.GvFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.GvFile_DragDrop);
            this.GvFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.GvFile_DragEnter);
            // 
            // LlPass
            // 
            this.LlPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LlPass.AutoSize = true;
            this.LlPass.Location = new System.Drawing.Point(3, 162);
            this.LlPass.Name = "LlPass";
            this.LlPass.Size = new System.Drawing.Size(47, 12);
            this.LlPass.TabIndex = 1;
            this.LlPass.Text = "口令(&K)";
            // 
            // TbPass
            // 
            this.TbPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbPass.Location = new System.Drawing.Point(56, 159);
            this.TbPass.Name = "TbPass";
            this.TbPass.Size = new System.Drawing.Size(181, 21);
            this.TbPass.TabIndex = 2;
            // 
            // SrcFile
            // 
            this.SrcFile.HeaderText = "文件";
            this.SrcFile.Name = "SrcFile";
            this.SrcFile.ReadOnly = true;
            // 
            // DstFile
            // 
            this.DstFile.HeaderText = "文件";
            this.DstFile.Name = "DstFile";
            this.DstFile.ReadOnly = true;
            // 
            // CipherFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbPass);
            this.Controls.Add(this.LlPass);
            this.Controls.Add(this.GvFile);
            this.Name = "CipherFile";
            this.Size = new System.Drawing.Size(240, 183);
            ((System.ComponentModel.ISupportInitialize)(this.GvFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GvFile;
        private System.Windows.Forms.Label LlPass;
        private System.Windows.Forms.TextBox TbPass;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrcFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn DstFile;
    }
}

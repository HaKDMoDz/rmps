namespace Me.Amon.Sec.V.Wiz
{
    partial class AFile
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
            this.LlData = new System.Windows.Forms.Label();
            this.TbData = new System.Windows.Forms.TextBox();
            this.PbData = new System.Windows.Forms.PictureBox();
            this.ClSrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClDst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GvFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbData)).BeginInit();
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
            this.GvFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GvFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClSrc,
            this.ClDst});
            this.GvFile.Location = new System.Drawing.Point(3, 3);
            this.GvFile.Name = "GvFile";
            this.GvFile.ReadOnly = true;
            this.GvFile.RowHeadersVisible = false;
            this.GvFile.RowTemplate.Height = 23;
            this.GvFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GvFile.Size = new System.Drawing.Size(144, 117);
            this.GvFile.TabIndex = 0;
            this.GvFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.GvFile_DragDrop);
            this.GvFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.GvFile_DragEnter);
            // 
            // LlData
            // 
            this.LlData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LlData.AutoSize = true;
            this.LlData.Location = new System.Drawing.Point(3, 129);
            this.LlData.Name = "LlData";
            this.LlData.Size = new System.Drawing.Size(47, 12);
            this.LlData.TabIndex = 1;
            this.LlData.Text = "中文(&C)";
            // 
            // TbData
            // 
            this.TbData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbData.Location = new System.Drawing.Point(56, 126);
            this.TbData.Name = "TbData";
            this.TbData.Size = new System.Drawing.Size(69, 21);
            this.TbData.TabIndex = 2;
            // 
            // PbData
            // 
            this.PbData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PbData.Location = new System.Drawing.Point(131, 129);
            this.PbData.Name = "PbData";
            this.PbData.Size = new System.Drawing.Size(16, 16);
            this.PbData.TabIndex = 3;
            this.PbData.TabStop = false;
            // 
            // ClSrc
            // 
            this.ClSrc.HeaderText = "Column1";
            this.ClSrc.Name = "ClSrc";
            this.ClSrc.ReadOnly = true;
            // 
            // ClDst
            // 
            this.ClDst.HeaderText = "Column1";
            this.ClDst.Name = "ClDst";
            this.ClDst.ReadOnly = true;
            // 
            // AFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbData);
            this.Controls.Add(this.TbData);
            this.Controls.Add(this.LlData);
            this.Controls.Add(this.GvFile);
            this.Name = "AFile";
            ((System.ComponentModel.ISupportInitialize)(this.GvFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView GvFile;
        public System.Windows.Forms.Label LlData;
        public System.Windows.Forms.TextBox TbData;
        public System.Windows.Forms.PictureBox PbData;
        public System.Windows.Forms.DataGridViewTextBoxColumn ClSrc;
        public System.Windows.Forms.DataGridViewTextBoxColumn ClDst;
    }
}

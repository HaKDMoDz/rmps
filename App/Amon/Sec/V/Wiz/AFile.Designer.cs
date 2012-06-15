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
            this.components = new System.ComponentModel.Container();
            this.GvFile = new System.Windows.Forms.DataGridView();
            this.ClSrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClDst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiAppendFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MiRemoveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.LlData = new System.Windows.Forms.Label();
            this.TbData = new System.Windows.Forms.TextBox();
            this.PbData = new System.Windows.Forms.PictureBox();
            this.MiSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.MiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.MiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MiClearAllFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.GvFile)).BeginInit();
            this.CmMenu.SuspendLayout();
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
            this.GvFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GvFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClSrc,
            this.ClDst});
            this.GvFile.ContextMenuStrip = this.CmMenu;
            this.GvFile.Location = new System.Drawing.Point(3, 3);
            this.GvFile.MultiSelect = false;
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
            // ClSrc
            // 
            this.ClSrc.DataPropertyName = "V";
            this.ClSrc.HeaderText = "Column1";
            this.ClSrc.Name = "ClSrc";
            this.ClSrc.ReadOnly = true;
            // 
            // ClDst
            // 
            this.ClDst.DataPropertyName = "D";
            this.ClDst.HeaderText = "Column1";
            this.ClDst.Name = "ClDst";
            this.ClDst.ReadOnly = true;
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiAppendFile,
            this.MiSep0,
            this.MiRemoveFile,
            this.MiClearAllFile,
            this.toolStripSeparator1,
            this.MiCopy,
            this.MiOpen});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(153, 148);
            // 
            // MiAppendFile
            // 
            this.MiAppendFile.Name = "MiAppendFile";
            this.MiAppendFile.Size = new System.Drawing.Size(152, 22);
            this.MiAppendFile.Text = "添加文件";
            this.MiAppendFile.Click += new System.EventHandler(this.MiAppendFile_Click);
            // 
            // MiRemoveFile
            // 
            this.MiRemoveFile.Name = "MiRemoveFile";
            this.MiRemoveFile.Size = new System.Drawing.Size(152, 22);
            this.MiRemoveFile.Text = "移除选择";
            this.MiRemoveFile.Click += new System.EventHandler(this.MiRemoveFile_Click);
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
            // MiSep0
            // 
            this.MiSep0.Name = "MiSep0";
            this.MiSep0.Size = new System.Drawing.Size(149, 6);
            // 
            // MiCopy
            // 
            this.MiCopy.Name = "MiCopy";
            this.MiCopy.Size = new System.Drawing.Size(152, 22);
            this.MiCopy.Text = "复制结果";
            this.MiCopy.Click += new System.EventHandler(this.MiCopy_Click);
            // 
            // MiOpen
            // 
            this.MiOpen.Name = "MiOpen";
            this.MiOpen.Size = new System.Drawing.Size(152, 22);
            this.MiOpen.Text = "打开目录";
            this.MiOpen.Click += new System.EventHandler(this.MiOpen_Click);
            // 
            // MiClearAllFile
            // 
            this.MiClearAllFile.Name = "MiClearAllFile";
            this.MiClearAllFile.Size = new System.Drawing.Size(152, 22);
            this.MiClearAllFile.Text = "清除所有";
            this.MiClearAllFile.Click += new System.EventHandler(this.MiClearAllFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
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
            this.CmMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView GvFile;
        public System.Windows.Forms.Label LlData;
        public System.Windows.Forms.TextBox TbData;
        public System.Windows.Forms.PictureBox PbData;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiAppendFile;
        private System.Windows.Forms.ToolStripMenuItem MiRemoveFile;
        public System.Windows.Forms.DataGridViewTextBoxColumn ClSrc;
        public System.Windows.Forms.DataGridViewTextBoxColumn ClDst;
        private System.Windows.Forms.ToolStripSeparator MiSep0;
        private System.Windows.Forms.ToolStripMenuItem MiCopy;
        private System.Windows.Forms.ToolStripMenuItem MiOpen;
        private System.Windows.Forms.ToolStripMenuItem MiClearAllFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

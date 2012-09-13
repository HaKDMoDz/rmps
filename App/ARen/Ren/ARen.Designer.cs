namespace Me.Amon.Ren
{
    partial class ARen
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TcRule = new System.Windows.Forms.TabControl();
            this.TpMemo = new System.Windows.Forms.TabPage();
            this.GvInfo = new System.Windows.Forms.DataGridView();
            this.ColCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LlInfo = new System.Windows.Forms.Label();
            this.TpRule = new System.Windows.Forms.TabPage();
            this.LbRule = new System.Windows.Forms.ListBox();
            this.TpAttr = new System.Windows.Forms.TabPage();
            this.CkArchive = new System.Windows.Forms.CheckBox();
            this.CkHidden = new System.Windows.Forms.CheckBox();
            this.CkReadOnly = new System.Windows.Forms.CheckBox();
            this.GvFile = new System.Windows.Forms.DataGridView();
            this.ColSrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LlRule = new System.Windows.Forms.Label();
            this.TbRule = new System.Windows.Forms.TextBox();
            this.PbRule = new System.Windows.Forms.PictureBox();
            this.PbMenu = new System.Windows.Forms.PictureBox();
            this.LlEcho = new System.Windows.Forms.Label();
            this.BtReview = new System.Windows.Forms.Button();
            this.BtRename = new System.Windows.Forms.Button();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.PmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PmRule = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PmFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.FbOpen = new System.Windows.Forms.FolderBrowserDialog();
            this.FdOpen = new System.Windows.Forms.OpenFileDialog();
            this.BgWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.TcRule.SuspendLayout();
            this.TpMemo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvInfo)).BeginInit();
            this.TpRule.SuspendLayout();
            this.TpAttr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TcRule);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GvFile);
            this.splitContainer1.Panel2MinSize = 160;
            this.splitContainer1.Size = new System.Drawing.Size(520, 238);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 0;
            // 
            // TcRule
            // 
            this.TcRule.Controls.Add(this.TpMemo);
            this.TcRule.Controls.Add(this.TpRule);
            this.TcRule.Controls.Add(this.TpAttr);
            this.TcRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TcRule.Location = new System.Drawing.Point(0, 0);
            this.TcRule.Name = "TcRule";
            this.TcRule.SelectedIndex = 0;
            this.TcRule.Size = new System.Drawing.Size(240, 238);
            this.TcRule.TabIndex = 0;
            // 
            // TpMemo
            // 
            this.TpMemo.Controls.Add(this.GvInfo);
            this.TpMemo.Controls.Add(this.LlInfo);
            this.TpMemo.Location = new System.Drawing.Point(4, 22);
            this.TpMemo.Name = "TpMemo";
            this.TpMemo.Padding = new System.Windows.Forms.Padding(3);
            this.TpMemo.Size = new System.Drawing.Size(232, 212);
            this.TpMemo.TabIndex = 0;
            this.TpMemo.Text = "规则说明";
            this.TpMemo.UseVisualStyleBackColor = true;
            // 
            // GvInfo
            // 
            this.GvInfo.AllowUserToAddRows = false;
            this.GvInfo.AllowUserToDeleteRows = false;
            this.GvInfo.AllowUserToResizeRows = false;
            this.GvInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GvInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GvInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvInfo.ColumnHeadersVisible = false;
            this.GvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCode,
            this.ColMemo});
            this.GvInfo.Location = new System.Drawing.Point(6, 40);
            this.GvInfo.MultiSelect = false;
            this.GvInfo.Name = "GvInfo";
            this.GvInfo.ReadOnly = true;
            this.GvInfo.RowHeadersVisible = false;
            this.GvInfo.RowTemplate.Height = 23;
            this.GvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GvInfo.Size = new System.Drawing.Size(220, 166);
            this.GvInfo.TabIndex = 1;
            // 
            // ColCode
            // 
            this.ColCode.DataPropertyName = "KeyCode";
            this.ColCode.HeaderText = "字符";
            this.ColCode.Name = "ColCode";
            this.ColCode.ReadOnly = true;
            // 
            // ColMemo
            // 
            this.ColMemo.DataPropertyName = "KeyInfo";
            this.ColMemo.HeaderText = "说明";
            this.ColMemo.Name = "ColMemo";
            this.ColMemo.ReadOnly = true;
            // 
            // LlInfo
            // 
            this.LlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LlInfo.Location = new System.Drawing.Point(6, 6);
            this.LlInfo.Name = "LlInfo";
            this.LlInfo.Size = new System.Drawing.Size(220, 31);
            this.LlInfo.TabIndex = 0;
            this.LlInfo.Text = "label1";
            // 
            // TpRule
            // 
            this.TpRule.Controls.Add(this.LbRule);
            this.TpRule.Location = new System.Drawing.Point(4, 22);
            this.TpRule.Name = "TpRule";
            this.TpRule.Padding = new System.Windows.Forms.Padding(3);
            this.TpRule.Size = new System.Drawing.Size(232, 212);
            this.TpRule.TabIndex = 1;
            this.TpRule.Text = "规则列表";
            this.TpRule.UseVisualStyleBackColor = true;
            // 
            // LbRule
            // 
            this.LbRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbRule.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LbRule.FormattingEnabled = true;
            this.LbRule.ItemHeight = 20;
            this.LbRule.Location = new System.Drawing.Point(3, 3);
            this.LbRule.Name = "LbRule";
            this.LbRule.Size = new System.Drawing.Size(226, 206);
            this.LbRule.TabIndex = 0;
            this.LbRule.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LbRule_DrawItem);
            this.LbRule.SelectedIndexChanged += new System.EventHandler(this.LbRule_SelectedIndexChanged);
            this.LbRule.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LbRule_MouseUp);
            // 
            // TpAttr
            // 
            this.TpAttr.Controls.Add(this.CkArchive);
            this.TpAttr.Controls.Add(this.CkHidden);
            this.TpAttr.Controls.Add(this.CkReadOnly);
            this.TpAttr.Location = new System.Drawing.Point(4, 22);
            this.TpAttr.Name = "TpAttr";
            this.TpAttr.Size = new System.Drawing.Size(232, 212);
            this.TpAttr.TabIndex = 2;
            this.TpAttr.Text = "文件属性";
            this.TpAttr.UseVisualStyleBackColor = true;
            // 
            // CkArchive
            // 
            this.CkArchive.AutoSize = true;
            this.CkArchive.Location = new System.Drawing.Point(3, 47);
            this.CkArchive.Name = "CkArchive";
            this.CkArchive.Size = new System.Drawing.Size(66, 16);
            this.CkArchive.TabIndex = 2;
            this.CkArchive.Text = "归档(&A)";
            this.CkArchive.UseVisualStyleBackColor = true;
            // 
            // CkHidden
            // 
            this.CkHidden.AutoSize = true;
            this.CkHidden.Location = new System.Drawing.Point(3, 25);
            this.CkHidden.Name = "CkHidden";
            this.CkHidden.Size = new System.Drawing.Size(66, 16);
            this.CkHidden.TabIndex = 1;
            this.CkHidden.Text = "隐藏(&H)";
            this.CkHidden.UseVisualStyleBackColor = true;
            // 
            // CkReadOnly
            // 
            this.CkReadOnly.AutoSize = true;
            this.CkReadOnly.Location = new System.Drawing.Point(3, 3);
            this.CkReadOnly.Name = "CkReadOnly";
            this.CkReadOnly.Size = new System.Drawing.Size(66, 16);
            this.CkReadOnly.TabIndex = 0;
            this.CkReadOnly.Text = "只读(&R)";
            this.CkReadOnly.UseVisualStyleBackColor = true;
            // 
            // GvFile
            // 
            this.GvFile.AllowDrop = true;
            this.GvFile.AllowUserToAddRows = false;
            this.GvFile.AllowUserToDeleteRows = false;
            this.GvFile.AllowUserToResizeRows = false;
            this.GvFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GvFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSrc,
            this.ColDst});
            this.GvFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GvFile.Location = new System.Drawing.Point(0, 0);
            this.GvFile.MultiSelect = false;
            this.GvFile.Name = "GvFile";
            this.GvFile.ReadOnly = true;
            this.GvFile.RowHeadersVisible = false;
            this.GvFile.RowTemplate.Height = 23;
            this.GvFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GvFile.Size = new System.Drawing.Size(276, 238);
            this.GvFile.TabIndex = 0;
            this.GvFile.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GvFile_CellMouseUp);
            this.GvFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.GvFile_DragDrop);
            this.GvFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.GvFile_DragEnter);
            // 
            // ColSrc
            // 
            this.ColSrc.HeaderText = "源文件名";
            this.ColSrc.Name = "ColSrc";
            this.ColSrc.ReadOnly = true;
            // 
            // ColDst
            // 
            this.ColDst.HeaderText = "新文件名";
            this.ColDst.Name = "ColDst";
            this.ColDst.ReadOnly = true;
            // 
            // LlRule
            // 
            this.LlRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LlRule.AutoSize = true;
            this.LlRule.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LlRule.Location = new System.Drawing.Point(12, 263);
            this.LlRule.Name = "LlRule";
            this.LlRule.Size = new System.Drawing.Size(78, 12);
            this.LlRule.TabIndex = 1;
            this.LlRule.Text = "命名规则(&F)";
            // 
            // TbRule
            // 
            this.TbRule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbRule.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbRule.Location = new System.Drawing.Point(96, 256);
            this.TbRule.Name = "TbRule";
            this.TbRule.Size = new System.Drawing.Size(406, 25);
            this.TbRule.TabIndex = 2;
            // 
            // PbRule
            // 
            this.PbRule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PbRule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbRule.Image = global::Me.Amon.Properties.Resources.Save;
            this.PbRule.Location = new System.Drawing.Point(508, 256);
            this.PbRule.Name = "PbRule";
            this.PbRule.Size = new System.Drawing.Size(24, 24);
            this.PbRule.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PbRule.TabIndex = 3;
            this.PbRule.TabStop = false;
            this.TpTips.SetToolTip(this.PbRule, "另存为模板");
            this.PbRule.Click += new System.EventHandler(this.PbRule_Click);
            // 
            // PbMenu
            // 
            this.PbMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PbMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbMenu.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbMenu.Location = new System.Drawing.Point(12, 290);
            this.PbMenu.Name = "PbMenu";
            this.PbMenu.Size = new System.Drawing.Size(16, 16);
            this.PbMenu.TabIndex = 4;
            this.PbMenu.TabStop = false;
            this.PbMenu.Click += new System.EventHandler(this.PbMenu_Click);
            // 
            // LlEcho
            // 
            this.LlEcho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LlEcho.AutoSize = true;
            this.LlEcho.Location = new System.Drawing.Point(34, 292);
            this.LlEcho.Name = "LlEcho";
            this.LlEcho.Size = new System.Drawing.Size(161, 12);
            this.LlEcho.TabIndex = 5;
            this.LlEcho.Text = "请选择或输入您的命名规则！";
            // 
            // BtReview
            // 
            this.BtReview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtReview.Location = new System.Drawing.Point(376, 287);
            this.BtReview.Name = "BtReview";
            this.BtReview.Size = new System.Drawing.Size(75, 23);
            this.BtReview.TabIndex = 6;
            this.BtReview.Text = "预览(&P)";
            this.BtReview.UseVisualStyleBackColor = true;
            this.BtReview.Click += new System.EventHandler(this.BtReview_Click);
            // 
            // BtRename
            // 
            this.BtRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtRename.Location = new System.Drawing.Point(457, 287);
            this.BtRename.Name = "BtRename";
            this.BtRename.Size = new System.Drawing.Size(75, 23);
            this.BtRename.TabIndex = 7;
            this.BtRename.Text = "执行(&X)";
            this.BtRename.UseVisualStyleBackColor = true;
            this.BtRename.Click += new System.EventHandler(this.BtRename_Click);
            // 
            // PmMenu
            // 
            this.PmMenu.Name = "PmMenu";
            this.PmMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // PmRule
            // 
            this.PmRule.Name = "PmRule";
            this.PmRule.Size = new System.Drawing.Size(61, 4);
            // 
            // PmFile
            // 
            this.PmFile.Name = "PmFile";
            this.PmFile.Size = new System.Drawing.Size(61, 4);
            // 
            // FdOpen
            // 
            this.FdOpen.FileName = "openFileDialog1";
            // 
            // ARen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 322);
            this.Controls.Add(this.BtRename);
            this.Controls.Add(this.BtReview);
            this.Controls.Add(this.LlEcho);
            this.Controls.Add(this.PbMenu);
            this.Controls.Add(this.PbRule);
            this.Controls.Add(this.TbRule);
            this.Controls.Add(this.LlRule);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ARen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "阿木更名器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ARen_FormClosing);
            this.Load += new System.EventHandler(this.ARen_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.TcRule.ResumeLayout(false);
            this.TpMemo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GvInfo)).EndInit();
            this.TpRule.ResumeLayout(false);
            this.TpAttr.ResumeLayout(false);
            this.TpAttr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label LlRule;
        private System.Windows.Forms.TextBox TbRule;
        private System.Windows.Forms.PictureBox PbRule;
        private System.Windows.Forms.PictureBox PbMenu;
        private System.Windows.Forms.Label LlEcho;
        private System.Windows.Forms.Button BtReview;
        private System.Windows.Forms.Button BtRename;
        private System.Windows.Forms.TabControl TcRule;
        private System.Windows.Forms.TabPage TpMemo;
        private System.Windows.Forms.TabPage TpRule;
        private System.Windows.Forms.DataGridView GvFile;
        private System.Windows.Forms.TabPage TpAttr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSrc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDst;
        private System.Windows.Forms.Label LlInfo;
        private System.Windows.Forms.DataGridView GvInfo;
        private System.Windows.Forms.ListBox LbRule;
        private System.Windows.Forms.CheckBox CkHidden;
        private System.Windows.Forms.CheckBox CkReadOnly;
        private System.Windows.Forms.ToolTip TpTips;
        private System.Windows.Forms.ContextMenuStrip PmMenu;
        private System.Windows.Forms.ContextMenuStrip PmRule;
        private System.Windows.Forms.ContextMenuStrip PmFile;
        private System.Windows.Forms.FolderBrowserDialog FbOpen;
        private System.Windows.Forms.OpenFileDialog FdOpen;
        private System.ComponentModel.BackgroundWorker BgWorker;
        private System.Windows.Forms.CheckBox CkArchive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMemo;
    }
}


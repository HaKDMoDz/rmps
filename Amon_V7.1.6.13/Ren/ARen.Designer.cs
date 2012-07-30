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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ARen));
            this.TcRule = new System.Windows.Forms.TabControl();
            this.TpRuleInf = new System.Windows.Forms.TabPage();
            this.GvInfo = new System.Windows.Forms.DataGridView();
            this.KeyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeyInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LtInfo = new System.Windows.Forms.Label();
            this.TpRulePre = new System.Windows.Forms.TabPage();
            this.LsRule = new System.Windows.Forms.ListBox();
            this.TpFileAtt = new System.Windows.Forms.TabPage();
            this.CkArchive = new System.Windows.Forms.CheckBox();
            this.CkHidden = new System.Windows.Forms.CheckBox();
            this.CkReadOnly = new System.Windows.Forms.CheckBox();
            this.LbRule = new System.Windows.Forms.Label();
            this.TbRule = new System.Windows.Forms.TextBox();
            this.GvFile = new System.Windows.Forms.DataGridView();
            this.SrcFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DstFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtReview = new System.Windows.Forms.Button();
            this.BtRename = new System.Windows.Forms.Button();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.PbMenu = new System.Windows.Forms.PictureBox();
            this.PbSaveas = new System.Windows.Forms.PictureBox();
            this.LbEcho = new System.Windows.Forms.Label();
            this.FdBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.BgWorker = new System.ComponentModel.BackgroundWorker();
            this.CmFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CmRule = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TcRule.SuspendLayout();
            this.TpRuleInf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvInfo)).BeginInit();
            this.TpRulePre.SuspendLayout();
            this.TpFileAtt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbSaveas)).BeginInit();
            this.SuspendLayout();
            // 
            // TcRule
            // 
            this.TcRule.Controls.Add(this.TpRuleInf);
            this.TcRule.Controls.Add(this.TpRulePre);
            this.TcRule.Controls.Add(this.TpFileAtt);
            this.TcRule.Location = new System.Drawing.Point(12, 12);
            this.TcRule.Name = "TcRule";
            this.TcRule.SelectedIndex = 0;
            this.TcRule.Size = new System.Drawing.Size(225, 212);
            this.TcRule.TabIndex = 0;
            // 
            // TpRuleInf
            // 
            this.TpRuleInf.Controls.Add(this.GvInfo);
            this.TpRuleInf.Controls.Add(this.LtInfo);
            this.TpRuleInf.Location = new System.Drawing.Point(4, 22);
            this.TpRuleInf.Name = "TpRuleInf";
            this.TpRuleInf.Padding = new System.Windows.Forms.Padding(3);
            this.TpRuleInf.Size = new System.Drawing.Size(217, 186);
            this.TpRuleInf.TabIndex = 0;
            this.TpRuleInf.Text = "规则说明";
            this.TpRuleInf.UseVisualStyleBackColor = true;
            // 
            // GvInfo
            // 
            this.GvInfo.AllowUserToAddRows = false;
            this.GvInfo.AllowUserToDeleteRows = false;
            this.GvInfo.AllowUserToResizeRows = false;
            this.GvInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvInfo.ColumnHeadersVisible = false;
            this.GvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyCode,
            this.KeyInfo});
            this.GvInfo.Location = new System.Drawing.Point(6, 40);
            this.GvInfo.MultiSelect = false;
            this.GvInfo.Name = "GvInfo";
            this.GvInfo.ReadOnly = true;
            this.GvInfo.RowHeadersVisible = false;
            this.GvInfo.RowTemplate.Height = 23;
            this.GvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GvInfo.Size = new System.Drawing.Size(205, 140);
            this.GvInfo.TabIndex = 1;
            // 
            // KeyCode
            // 
            this.KeyCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.KeyCode.DataPropertyName = "KeyCode";
            this.KeyCode.HeaderText = "字符";
            this.KeyCode.Name = "KeyCode";
            this.KeyCode.ReadOnly = true;
            this.KeyCode.Width = 5;
            // 
            // KeyInfo
            // 
            this.KeyInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.KeyInfo.DataPropertyName = "KeyInfo";
            this.KeyInfo.HeaderText = "说明";
            this.KeyInfo.Name = "KeyInfo";
            this.KeyInfo.ReadOnly = true;
            // 
            // LtInfo
            // 
            this.LtInfo.Location = new System.Drawing.Point(6, 6);
            this.LtInfo.Name = "LtInfo";
            this.LtInfo.Size = new System.Drawing.Size(205, 31);
            this.LtInfo.TabIndex = 0;
            this.LtInfo.Text = "label2";
            // 
            // TpRulePre
            // 
            this.TpRulePre.Controls.Add(this.LsRule);
            this.TpRulePre.Location = new System.Drawing.Point(4, 22);
            this.TpRulePre.Name = "TpRulePre";
            this.TpRulePre.Padding = new System.Windows.Forms.Padding(3);
            this.TpRulePre.Size = new System.Drawing.Size(217, 186);
            this.TpRulePre.TabIndex = 1;
            this.TpRulePre.Text = "规则列表";
            this.TpRulePre.UseVisualStyleBackColor = true;
            // 
            // LsRule
            // 
            this.LsRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LsRule.FormattingEnabled = true;
            this.LsRule.ItemHeight = 12;
            this.LsRule.Location = new System.Drawing.Point(3, 3);
            this.LsRule.Name = "LsRule";
            this.LsRule.Size = new System.Drawing.Size(211, 180);
            this.LsRule.TabIndex = 0;
            this.LsRule.SelectedIndexChanged += new System.EventHandler(this.LsRule_SelectedIndexChanged);
            this.LsRule.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LsRule_MouseUp);
            // 
            // TpFileAtt
            // 
            this.TpFileAtt.Controls.Add(this.CkArchive);
            this.TpFileAtt.Controls.Add(this.CkHidden);
            this.TpFileAtt.Controls.Add(this.CkReadOnly);
            this.TpFileAtt.Location = new System.Drawing.Point(4, 22);
            this.TpFileAtt.Name = "TpFileAtt";
            this.TpFileAtt.Size = new System.Drawing.Size(217, 186);
            this.TpFileAtt.TabIndex = 2;
            this.TpFileAtt.Text = "文件属性";
            this.TpFileAtt.UseVisualStyleBackColor = true;
            // 
            // CkArchive
            // 
            this.CkArchive.AutoSize = true;
            this.CkArchive.Location = new System.Drawing.Point(3, 47);
            this.CkArchive.Name = "CkArchive";
            this.CkArchive.Size = new System.Drawing.Size(48, 16);
            this.CkArchive.TabIndex = 2;
            this.CkArchive.Text = "归档";
            this.CkArchive.UseVisualStyleBackColor = true;
            // 
            // CkHidden
            // 
            this.CkHidden.AutoSize = true;
            this.CkHidden.Location = new System.Drawing.Point(3, 25);
            this.CkHidden.Name = "CkHidden";
            this.CkHidden.Size = new System.Drawing.Size(48, 16);
            this.CkHidden.TabIndex = 1;
            this.CkHidden.Text = "隐藏";
            this.CkHidden.UseVisualStyleBackColor = true;
            // 
            // CkReadOnly
            // 
            this.CkReadOnly.AutoSize = true;
            this.CkReadOnly.Location = new System.Drawing.Point(3, 3);
            this.CkReadOnly.Name = "CkReadOnly";
            this.CkReadOnly.Size = new System.Drawing.Size(48, 16);
            this.CkReadOnly.TabIndex = 0;
            this.CkReadOnly.Text = "只读";
            this.CkReadOnly.UseVisualStyleBackColor = true;
            // 
            // LbRule
            // 
            this.LbRule.AutoSize = true;
            this.LbRule.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbRule.Location = new System.Drawing.Point(12, 236);
            this.LbRule.Name = "LbRule";
            this.LbRule.Size = new System.Drawing.Size(78, 12);
            this.LbRule.TabIndex = 1;
            this.LbRule.Text = "命名规则(&R)";
            // 
            // TbRule
            // 
            this.TbRule.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.TbRule.Location = new System.Drawing.Point(96, 230);
            this.TbRule.Name = "TbRule";
            this.TbRule.Size = new System.Drawing.Size(376, 25);
            this.TbRule.TabIndex = 2;
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
            this.GvFile.Location = new System.Drawing.Point(243, 12);
            this.GvFile.MultiSelect = false;
            this.GvFile.Name = "GvFile";
            this.GvFile.ReadOnly = true;
            this.GvFile.RowHeadersVisible = false;
            this.GvFile.RowTemplate.Height = 23;
            this.GvFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GvFile.Size = new System.Drawing.Size(259, 212);
            this.GvFile.TabIndex = 4;
            this.GvFile.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GvFile_CellMouseUp);
            this.GvFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.GvFile_DragDrop);
            this.GvFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.GvFile_DragEnter);
            // 
            // SrcFile
            // 
            this.SrcFile.DataPropertyName = "SrcName";
            this.SrcFile.HeaderText = "原文件名";
            this.SrcFile.Name = "SrcFile";
            this.SrcFile.ReadOnly = true;
            // 
            // DstFile
            // 
            this.DstFile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DstFile.DataPropertyName = "DstName";
            this.DstFile.HeaderText = "新文件名";
            this.DstFile.Name = "DstFile";
            this.DstFile.ReadOnly = true;
            // 
            // BtReview
            // 
            this.BtReview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtReview.Location = new System.Drawing.Point(346, 261);
            this.BtReview.Name = "BtReview";
            this.BtReview.Size = new System.Drawing.Size(75, 23);
            this.BtReview.TabIndex = 6;
            this.BtReview.Text = "预览(&P)";
            this.TpTips.SetToolTip(this.BtReview, "预览重命名结果");
            this.BtReview.UseVisualStyleBackColor = true;
            this.BtReview.Click += new System.EventHandler(this.BtReview_Click);
            // 
            // BtRename
            // 
            this.BtRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtRename.Location = new System.Drawing.Point(427, 261);
            this.BtRename.Name = "BtRename";
            this.BtRename.Size = new System.Drawing.Size(75, 23);
            this.BtRename.TabIndex = 7;
            this.BtRename.Text = "执行(&R)";
            this.TpTips.SetToolTip(this.BtRename, "执行文件重命名");
            this.BtRename.UseVisualStyleBackColor = true;
            this.BtRename.Click += new System.EventHandler(this.BtRename_Click);
            // 
            // CmMenu
            // 
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // PbMenu
            // 
            this.PbMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbMenu.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbMenu.Location = new System.Drawing.Point(12, 265);
            this.PbMenu.Name = "PbMenu";
            this.PbMenu.Size = new System.Drawing.Size(16, 16);
            this.PbMenu.TabIndex = 8;
            this.PbMenu.TabStop = false;
            this.TpTips.SetToolTip(this.PbMenu, "系统选单");
            this.PbMenu.Click += new System.EventHandler(this.PbMenu_Click);
            // 
            // PbSaveas
            // 
            this.PbSaveas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbSaveas.Image = ((System.Drawing.Image)(resources.GetObject("PbSaveas.Image")));
            this.PbSaveas.Location = new System.Drawing.Point(478, 230);
            this.PbSaveas.Name = "PbSaveas";
            this.PbSaveas.Size = new System.Drawing.Size(24, 24);
            this.PbSaveas.TabIndex = 3;
            this.PbSaveas.TabStop = false;
            this.TpTips.SetToolTip(this.PbSaveas, "另存为模板");
            this.PbSaveas.Click += new System.EventHandler(this.PbSaveas_Click);
            // 
            // LbEcho
            // 
            this.LbEcho.AutoSize = true;
            this.LbEcho.Location = new System.Drawing.Point(34, 266);
            this.LbEcho.Name = "LbEcho";
            this.LbEcho.Size = new System.Drawing.Size(0, 12);
            this.LbEcho.TabIndex = 9;
            // 
            // FdBrowser
            // 
            this.FdBrowser.Description = "请选择您要进行重命名的目录：";
            // 
            // BgWorker
            // 
            this.BgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgWorker_DoWork);
            this.BgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BgWorker_ProgressChanged);
            this.BgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgWorker_RunWorkerCompleted);
            // 
            // CmFile
            // 
            this.CmFile.Name = "CmFile";
            this.CmFile.Size = new System.Drawing.Size(61, 4);
            // 
            // CmRule
            // 
            this.CmRule.Name = "CmRule";
            this.CmRule.Size = new System.Drawing.Size(61, 4);
            // 
            // ARen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 296);
            this.Controls.Add(this.LbEcho);
            this.Controls.Add(this.PbMenu);
            this.Controls.Add(this.BtRename);
            this.Controls.Add(this.BtReview);
            this.Controls.Add(this.GvFile);
            this.Controls.Add(this.TbRule);
            this.Controls.Add(this.LbRule);
            this.Controls.Add(this.PbSaveas);
            this.Controls.Add(this.TcRule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ARen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "阿木重命名";
            this.Load += new System.EventHandler(this.ARen_Load);
            this.TcRule.ResumeLayout(false);
            this.TpRuleInf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GvInfo)).EndInit();
            this.TpRulePre.ResumeLayout(false);
            this.TpFileAtt.ResumeLayout(false);
            this.TpFileAtt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbSaveas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TcRule;
        private System.Windows.Forms.TabPage TpRuleInf;
        private System.Windows.Forms.TabPage TpRulePre;
        private System.Windows.Forms.Label LbRule;
        private System.Windows.Forms.TextBox TbRule;
        private System.Windows.Forms.PictureBox PbSaveas;
        private System.Windows.Forms.DataGridView GvFile;
        private System.Windows.Forms.Button BtReview;
        private System.Windows.Forms.Button BtRename;
        private System.Windows.Forms.PictureBox PbMenu;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.TabPage TpFileAtt;
        private System.Windows.Forms.Label LtInfo;
        private System.Windows.Forms.ListBox LsRule;
        private System.Windows.Forms.CheckBox CkHidden;
        private System.Windows.Forms.CheckBox CkReadOnly;
        private System.Windows.Forms.ToolTip TpTips;
        private System.Windows.Forms.Label LbEcho;
        private System.Windows.Forms.FolderBrowserDialog FdBrowser;
        private System.Windows.Forms.CheckBox CkArchive;
        private System.Windows.Forms.DataGridView GvInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyInfo;
        private System.ComponentModel.BackgroundWorker BgWorker;
        private System.Windows.Forms.ContextMenuStrip CmFile;
        private System.Windows.Forms.ContextMenuStrip CmRule;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrcFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn DstFile;
    }
}
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
            this.GvName = new System.Windows.Forms.DataGridView();
            this.OldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtReview = new System.Windows.Forms.Button();
            this.BtRename = new System.Windows.Forms.Button();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiSaveas = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.MiExport = new System.Windows.Forms.ToolStripMenuItem();
            this.MiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSortUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSortDown = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.PbMenu = new System.Windows.Forms.PictureBox();
            this.PbSelect = new System.Windows.Forms.PictureBox();
            this.LbEcho = new System.Windows.Forms.Label();
            this.FdBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.TcRule.SuspendLayout();
            this.TpRuleInf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvInfo)).BeginInit();
            this.TpRulePre.SuspendLayout();
            this.TpFileAtt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvName)).BeginInit();
            this.CmMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbSelect)).BeginInit();
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
            // GvName
            // 
            this.GvName.AllowUserToAddRows = false;
            this.GvName.AllowUserToDeleteRows = false;
            this.GvName.AllowUserToResizeRows = false;
            this.GvName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GvName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvName.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OldName,
            this.NewName});
            this.GvName.Location = new System.Drawing.Point(243, 12);
            this.GvName.MultiSelect = false;
            this.GvName.Name = "GvName";
            this.GvName.ReadOnly = true;
            this.GvName.RowHeadersVisible = false;
            this.GvName.RowTemplate.Height = 23;
            this.GvName.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GvName.Size = new System.Drawing.Size(259, 212);
            this.GvName.TabIndex = 4;
            // 
            // OldName
            // 
            this.OldName.DataPropertyName = "OldName";
            this.OldName.HeaderText = "原文件名";
            this.OldName.Name = "OldName";
            this.OldName.ReadOnly = true;
            // 
            // NewName
            // 
            this.NewName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NewName.DataPropertyName = "NewName";
            this.NewName.HeaderText = "新文件名";
            this.NewName.Name = "NewName";
            this.NewName.ReadOnly = true;
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
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiSaveas,
            this.MiSep0,
            this.MiExport,
            this.MiImport,
            this.MiSortUp,
            this.MiSortDown,
            this.MiSep1,
            this.MiDelete});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(153, 170);
            // 
            // MiSaveas
            // 
            this.MiSaveas.Name = "MiSaveas";
            this.MiSaveas.Size = new System.Drawing.Size(152, 22);
            this.MiSaveas.Text = "保存(&S)";
            this.MiSaveas.Click += new System.EventHandler(this.MiSaveas_Click);
            // 
            // MiSep0
            // 
            this.MiSep0.Name = "MiSep0";
            this.MiSep0.Size = new System.Drawing.Size(149, 6);
            // 
            // MiExport
            // 
            this.MiExport.Name = "MiExport";
            this.MiExport.Size = new System.Drawing.Size(152, 22);
            this.MiExport.Text = "导出(&X)";
            this.MiExport.Click += new System.EventHandler(this.MiExport_Click);
            // 
            // MiImport
            // 
            this.MiImport.Name = "MiImport";
            this.MiImport.Size = new System.Drawing.Size(152, 22);
            this.MiImport.Text = "导入(&I)";
            this.MiImport.Click += new System.EventHandler(this.MiImport_Click);
            // 
            // MiSortUp
            // 
            this.MiSortUp.Name = "MiSortUp";
            this.MiSortUp.Size = new System.Drawing.Size(152, 22);
            this.MiSortUp.Text = "上移(&U)";
            this.MiSortUp.Click += new System.EventHandler(this.MiSortUp_Click);
            // 
            // MiSortDown
            // 
            this.MiSortDown.Name = "MiSortDown";
            this.MiSortDown.Size = new System.Drawing.Size(152, 22);
            this.MiSortDown.Text = "下移(&D)";
            this.MiSortDown.Click += new System.EventHandler(this.MiSortDown_Click);
            // 
            // MiSep1
            // 
            this.MiSep1.Name = "MiSep1";
            this.MiSep1.Size = new System.Drawing.Size(149, 6);
            // 
            // MiDelete
            // 
            this.MiDelete.Name = "MiDelete";
            this.MiDelete.Size = new System.Drawing.Size(152, 22);
            this.MiDelete.Text = "删除(&R)";
            this.MiDelete.Click += new System.EventHandler(this.MiDelete_Click);
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
            this.TpTips.SetToolTip(this.PbMenu, "菜单");
            this.PbMenu.Click += new System.EventHandler(this.PbMenu_Click);
            // 
            // PbSelect
            // 
            this.PbSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbSelect.Image = global::Me.Amon.Properties.Resources.Open;
            this.PbSelect.Location = new System.Drawing.Point(478, 230);
            this.PbSelect.Name = "PbSelect";
            this.PbSelect.Size = new System.Drawing.Size(24, 24);
            this.PbSelect.TabIndex = 3;
            this.PbSelect.TabStop = false;
            this.TpTips.SetToolTip(this.PbSelect, "选择目录");
            this.PbSelect.Click += new System.EventHandler(this.PbSelect_Click);
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
            // ARen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 296);
            this.Controls.Add(this.LbEcho);
            this.Controls.Add(this.PbMenu);
            this.Controls.Add(this.BtRename);
            this.Controls.Add(this.BtReview);
            this.Controls.Add(this.GvName);
            this.Controls.Add(this.TbRule);
            this.Controls.Add(this.LbRule);
            this.Controls.Add(this.PbSelect);
            this.Controls.Add(this.TcRule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ARen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "阿木重命名";
            this.TcRule.ResumeLayout(false);
            this.TpRuleInf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GvInfo)).EndInit();
            this.TpRulePre.ResumeLayout(false);
            this.TpFileAtt.ResumeLayout(false);
            this.TpFileAtt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvName)).EndInit();
            this.CmMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TcRule;
        private System.Windows.Forms.TabPage TpRuleInf;
        private System.Windows.Forms.TabPage TpRulePre;
        private System.Windows.Forms.Label LbRule;
        private System.Windows.Forms.TextBox TbRule;
        private System.Windows.Forms.PictureBox PbSelect;
        private System.Windows.Forms.DataGridView GvName;
        private System.Windows.Forms.Button BtReview;
        private System.Windows.Forms.Button BtRename;
        private System.Windows.Forms.PictureBox PbMenu;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.TabPage TpFileAtt;
        private System.Windows.Forms.Label LtInfo;
        private System.Windows.Forms.ListBox LsRule;
        private System.Windows.Forms.CheckBox CkHidden;
        private System.Windows.Forms.CheckBox CkReadOnly;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewName;
        private System.Windows.Forms.ToolTip TpTips;
        private System.Windows.Forms.Label LbEcho;
        private System.Windows.Forms.FolderBrowserDialog FdBrowser;
        private System.Windows.Forms.CheckBox CkArchive;
        private System.Windows.Forms.ToolStripMenuItem MiImport;
        private System.Windows.Forms.ToolStripMenuItem MiExport;
        private System.Windows.Forms.DataGridView GvInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyInfo;
        private System.Windows.Forms.ToolStripMenuItem MiDelete;
        private System.Windows.Forms.ToolStripSeparator MiSep0;
        private System.Windows.Forms.ToolStripMenuItem MiSaveas;
        private System.Windows.Forms.ToolStripSeparator MiSep1;
        private System.Windows.Forms.ToolStripMenuItem MiSortUp;
        private System.Windows.Forms.ToolStripMenuItem MiSortDown;
    }
}
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
            this.label2 = new System.Windows.Forms.Label();
            this.TpRulePre = new System.Windows.Forms.TabPage();
            this.LsRule = new System.Windows.Forms.ListBox();
            this.TpFileAtt = new System.Windows.Forms.TabPage();
            this.CkHidden = new System.Windows.Forms.CheckBox();
            this.CkReadOnly = new System.Windows.Forms.CheckBox();
            this.LbRule = new System.Windows.Forms.Label();
            this.TbRule = new System.Windows.Forms.TextBox();
            this.GvName = new System.Windows.Forms.DataGridView();
            this.OldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtSelect = new System.Windows.Forms.Button();
            this.BtReview = new System.Windows.Forms.Button();
            this.BtRename = new System.Windows.Forms.Button();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.PbMenu = new System.Windows.Forms.PictureBox();
            this.PbSave = new System.Windows.Forms.PictureBox();
            this.LbEcho = new System.Windows.Forms.Label();
            this.FdBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.CkArchive = new System.Windows.Forms.CheckBox();
            this.TcRule.SuspendLayout();
            this.TpRuleInf.SuspendLayout();
            this.TpRulePre.SuspendLayout();
            this.TpFileAtt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbSave)).BeginInit();
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
            this.TcRule.SelectedIndexChanged += new System.EventHandler(this.TcRule_SelectedIndexChanged);
            // 
            // TpRuleInf
            // 
            this.TpRuleInf.Controls.Add(this.label2);
            this.TpRuleInf.Location = new System.Drawing.Point(4, 22);
            this.TpRuleInf.Name = "TpRuleInf";
            this.TpRuleInf.Padding = new System.Windows.Forms.Padding(3);
            this.TpRuleInf.Size = new System.Drawing.Size(217, 186);
            this.TpRuleInf.TabIndex = 0;
            this.TpRuleInf.Text = "规则说明";
            this.TpRuleInf.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 180);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
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
            this.LsRule.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.LsRule.FormattingEnabled = true;
            this.LsRule.ItemHeight = 12;
            this.LsRule.Location = new System.Drawing.Point(3, 3);
            this.LsRule.Name = "LsRule";
            this.LsRule.Size = new System.Drawing.Size(211, 180);
            this.LsRule.TabIndex = 0;
            this.LsRule.SelectedIndexChanged += new System.EventHandler(this.LsRule_SelectedIndexChanged);
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
            this.LbRule.Location = new System.Drawing.Point(12, 233);
            this.LbRule.Name = "LbRule";
            this.LbRule.Size = new System.Drawing.Size(71, 12);
            this.LbRule.TabIndex = 1;
            this.LbRule.Text = "命名规则(&R)";
            // 
            // TbRule
            // 
            this.TbRule.Location = new System.Drawing.Point(91, 230);
            this.TbRule.Name = "TbRule";
            this.TbRule.Size = new System.Drawing.Size(124, 21);
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
            this.GvName.Size = new System.Drawing.Size(259, 239);
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
            // BtSelect
            // 
            this.BtSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtSelect.Location = new System.Drawing.Point(265, 257);
            this.BtSelect.Name = "BtSelect";
            this.BtSelect.Size = new System.Drawing.Size(75, 23);
            this.BtSelect.TabIndex = 5;
            this.BtSelect.Text = "选择(&C)";
            this.TpTips.SetToolTip(this.BtSelect, "选择重命名目录");
            this.BtSelect.UseVisualStyleBackColor = true;
            this.BtSelect.Click += new System.EventHandler(this.BtSelect_Click);
            // 
            // BtReview
            // 
            this.BtReview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtReview.Location = new System.Drawing.Point(346, 257);
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
            this.BtRename.Location = new System.Drawing.Point(427, 257);
            this.BtRename.Name = "BtRename";
            this.BtRename.Size = new System.Drawing.Size(75, 23);
            this.BtRename.TabIndex = 7;
            this.BtRename.Text = "执行(&R)";
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
            this.PbMenu.Location = new System.Drawing.Point(12, 261);
            this.PbMenu.Name = "PbMenu";
            this.PbMenu.Size = new System.Drawing.Size(16, 16);
            this.PbMenu.TabIndex = 8;
            this.PbMenu.TabStop = false;
            this.TpTips.SetToolTip(this.PbMenu, "菜单");
            this.PbMenu.Click += new System.EventHandler(this.PbMenu_Click);
            // 
            // PbSave
            // 
            this.PbSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbSave.Image = global::Me.Amon.Properties.Resources.Save;
            this.PbSave.Location = new System.Drawing.Point(221, 232);
            this.PbSave.Name = "PbSave";
            this.PbSave.Size = new System.Drawing.Size(16, 16);
            this.PbSave.TabIndex = 3;
            this.PbSave.TabStop = false;
            this.TpTips.SetToolTip(this.PbSave, "另存为模板");
            this.PbSave.Click += new System.EventHandler(this.PbSave_Click);
            // 
            // LbEcho
            // 
            this.LbEcho.AutoSize = true;
            this.LbEcho.Location = new System.Drawing.Point(34, 262);
            this.LbEcho.Name = "LbEcho";
            this.LbEcho.Size = new System.Drawing.Size(0, 12);
            this.LbEcho.TabIndex = 9;
            // 
            // FdBrowser
            // 
            this.FdBrowser.Description = "请选择您要进行重命名的目录：";
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
            // ARen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 292);
            this.Controls.Add(this.LbEcho);
            this.Controls.Add(this.PbMenu);
            this.Controls.Add(this.BtRename);
            this.Controls.Add(this.BtReview);
            this.Controls.Add(this.BtSelect);
            this.Controls.Add(this.GvName);
            this.Controls.Add(this.PbSave);
            this.Controls.Add(this.TbRule);
            this.Controls.Add(this.LbRule);
            this.Controls.Add(this.TcRule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ARen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "阿木重命名";
            this.TcRule.ResumeLayout(false);
            this.TpRuleInf.ResumeLayout(false);
            this.TpRulePre.ResumeLayout(false);
            this.TpFileAtt.ResumeLayout(false);
            this.TpFileAtt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TcRule;
        private System.Windows.Forms.TabPage TpRuleInf;
        private System.Windows.Forms.TabPage TpRulePre;
        private System.Windows.Forms.Label LbRule;
        private System.Windows.Forms.TextBox TbRule;
        private System.Windows.Forms.PictureBox PbSave;
        private System.Windows.Forms.DataGridView GvName;
        private System.Windows.Forms.Button BtSelect;
        private System.Windows.Forms.Button BtReview;
        private System.Windows.Forms.Button BtRename;
        private System.Windows.Forms.PictureBox PbMenu;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.TabPage TpFileAtt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox LsRule;
        private System.Windows.Forms.CheckBox CkHidden;
        private System.Windows.Forms.CheckBox CkReadOnly;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewName;
        private System.Windows.Forms.ToolTip TpTips;
        private System.Windows.Forms.Label LbEcho;
        private System.Windows.Forms.FolderBrowserDialog FdBrowser;
        private System.Windows.Forms.CheckBox CkArchive;
    }
}
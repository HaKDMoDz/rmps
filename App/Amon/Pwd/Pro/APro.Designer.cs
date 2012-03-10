namespace Me.Amon.Pwd.Pro
{
    partial class APro
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GvAttList = new System.Windows.Forms.DataGridView();
            this.OrderCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmAtt = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CmuAppendAtt = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiAppendAttText = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiAppendAttPass = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiAppendAttLink = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiAppendAttMail = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiAppendAttDate = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiAppendAttData = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiAppendAttList = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiAppendAttMemo = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiAppendAttFile = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiAppendAttLine = new System.Windows.Forms.ToolStripMenuItem();
            this.CmuUpdateAtt = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiUpdateAttText = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiUpdateAttPass = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiUpdateAttLink = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiUpdateAttMail = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiUpdateAttDate = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiUpdateAttData = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiUpdateAttList = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiUpdateAttMemo = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiUpdateAttFile = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiUpdateAttLine = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiDeleteAtt = new System.Windows.Forms.ToolStripMenuItem();
            this.GbGroup = new System.Windows.Forms.GroupBox();
            this.BtDrop = new System.Windows.Forms.Button();
            this.BtSave = new System.Windows.Forms.Button();
            this.BtCopy = new System.Windows.Forms.Button();
            this.CmiAppendAttCall = new System.Windows.Forms.ToolStripMenuItem();
            this.CmiUpdateAttCall = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.GvAttList)).BeginInit();
            this.CmAtt.SuspendLayout();
            this.GbGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // GvAttList
            // 
            this.GvAttList.AllowUserToAddRows = false;
            this.GvAttList.AllowUserToDeleteRows = false;
            this.GvAttList.AllowUserToResizeColumns = false;
            this.GvAttList.AllowUserToResizeRows = false;
            this.GvAttList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GvAttList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvAttList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderCol,
            this.ValueCol});
            this.GvAttList.ContextMenuStrip = this.CmAtt;
            this.GvAttList.Location = new System.Drawing.Point(0, 0);
            this.GvAttList.MultiSelect = false;
            this.GvAttList.Name = "GvAttList";
            this.GvAttList.ReadOnly = true;
            this.GvAttList.RowHeadersVisible = false;
            this.GvAttList.RowTemplate.Height = 23;
            this.GvAttList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GvAttList.Size = new System.Drawing.Size(350, 145);
            this.GvAttList.TabIndex = 0;
            this.GvAttList.SelectionChanged += new System.EventHandler(this.GvAttList_SelectionChanged);
            // 
            // OrderCol
            // 
            this.OrderCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.OrderCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.OrderCol.HeaderText = "索引";
            this.OrderCol.Name = "OrderCol";
            this.OrderCol.ReadOnly = true;
            this.OrderCol.Width = 54;
            // 
            // ValueCol
            // 
            this.ValueCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValueCol.HeaderText = "属性";
            this.ValueCol.Name = "ValueCol";
            this.ValueCol.ReadOnly = true;
            // 
            // CmAtt
            // 
            this.CmAtt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmuAppendAtt,
            this.CmuUpdateAtt,
            this.CmiDeleteAtt});
            this.CmAtt.Name = "CmAtt";
            this.CmAtt.Size = new System.Drawing.Size(153, 92);
            // 
            // CmuAppendAtt
            // 
            this.CmuAppendAtt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmiAppendAttText,
            this.CmiAppendAttPass,
            this.CmiAppendAttLink,
            this.CmiAppendAttMail,
            this.CmiAppendAttDate,
            this.CmiAppendAttData,
            this.CmiAppendAttCall,
            this.CmiAppendAttList,
            this.CmiAppendAttMemo,
            this.CmiAppendAttFile,
            this.CmiAppendAttLine});
            this.CmuAppendAtt.Name = "CmuAppendAtt";
            this.CmuAppendAtt.Size = new System.Drawing.Size(152, 22);
            this.CmuAppendAtt.Text = "添加属性";
            // 
            // CmiAppendAttText
            // 
            this.CmiAppendAttText.Name = "CmiAppendAttText";
            this.CmiAppendAttText.Size = new System.Drawing.Size(152, 22);
            this.CmiAppendAttText.Text = "文本";
            this.CmiAppendAttText.Click += new System.EventHandler(this.CmiAppendAttText_Click);
            // 
            // CmiAppendAttPass
            // 
            this.CmiAppendAttPass.Name = "CmiAppendAttPass";
            this.CmiAppendAttPass.Size = new System.Drawing.Size(152, 22);
            this.CmiAppendAttPass.Text = "口令";
            this.CmiAppendAttPass.Click += new System.EventHandler(this.CmiAppendAttPass_Click);
            // 
            // CmiAppendAttLink
            // 
            this.CmiAppendAttLink.Name = "CmiAppendAttLink";
            this.CmiAppendAttLink.Size = new System.Drawing.Size(152, 22);
            this.CmiAppendAttLink.Text = "链接";
            this.CmiAppendAttLink.Click += new System.EventHandler(this.CmiAppendAttLink_Click);
            // 
            // CmiAppendAttMail
            // 
            this.CmiAppendAttMail.Name = "CmiAppendAttMail";
            this.CmiAppendAttMail.Size = new System.Drawing.Size(152, 22);
            this.CmiAppendAttMail.Text = "邮件";
            this.CmiAppendAttMail.Click += new System.EventHandler(this.CmiAppendAttMail_Click);
            // 
            // CmiAppendAttDate
            // 
            this.CmiAppendAttDate.Name = "CmiAppendAttDate";
            this.CmiAppendAttDate.Size = new System.Drawing.Size(152, 22);
            this.CmiAppendAttDate.Text = "日期";
            this.CmiAppendAttDate.Click += new System.EventHandler(this.CmiAppendAttDate_Click);
            // 
            // CmiAppendAttData
            // 
            this.CmiAppendAttData.Name = "CmiAppendAttData";
            this.CmiAppendAttData.Size = new System.Drawing.Size(152, 22);
            this.CmiAppendAttData.Text = "数值";
            this.CmiAppendAttData.Click += new System.EventHandler(this.CmiAppendAttData_Click);
            // 
            // CmiAppendAttList
            // 
            this.CmiAppendAttList.Name = "CmiAppendAttList";
            this.CmiAppendAttList.Size = new System.Drawing.Size(152, 22);
            this.CmiAppendAttList.Text = "列表";
            this.CmiAppendAttList.Visible = false;
            this.CmiAppendAttList.Click += new System.EventHandler(this.CmiAppendAttList_Click);
            // 
            // CmiAppendAttMemo
            // 
            this.CmiAppendAttMemo.Name = "CmiAppendAttMemo";
            this.CmiAppendAttMemo.Size = new System.Drawing.Size(152, 22);
            this.CmiAppendAttMemo.Text = "附注";
            this.CmiAppendAttMemo.Click += new System.EventHandler(this.CmiAppendAttMemo_Click);
            // 
            // CmiAppendAttFile
            // 
            this.CmiAppendAttFile.Name = "CmiAppendAttFile";
            this.CmiAppendAttFile.Size = new System.Drawing.Size(152, 22);
            this.CmiAppendAttFile.Text = "附件";
            this.CmiAppendAttFile.Click += new System.EventHandler(this.CmiAppendAttFile_Click);
            // 
            // CmiAppendAttLine
            // 
            this.CmiAppendAttLine.Name = "CmiAppendAttLine";
            this.CmiAppendAttLine.Size = new System.Drawing.Size(152, 22);
            this.CmiAppendAttLine.Text = "分组";
            this.CmiAppendAttLine.Visible = false;
            this.CmiAppendAttLine.Click += new System.EventHandler(this.CmiAppendAttLine_Click);
            // 
            // CmuUpdateAtt
            // 
            this.CmuUpdateAtt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmiUpdateAttText,
            this.CmiUpdateAttPass,
            this.CmiUpdateAttLink,
            this.CmiUpdateAttMail,
            this.CmiUpdateAttDate,
            this.CmiUpdateAttData,
            this.CmiUpdateAttCall,
            this.CmiUpdateAttList,
            this.CmiUpdateAttMemo,
            this.CmiUpdateAttFile,
            this.CmiUpdateAttLine});
            this.CmuUpdateAtt.Name = "CmuUpdateAtt";
            this.CmuUpdateAtt.Size = new System.Drawing.Size(152, 22);
            this.CmuUpdateAtt.Text = "转换属性";
            // 
            // CmiUpdateAttText
            // 
            this.CmiUpdateAttText.Name = "CmiUpdateAttText";
            this.CmiUpdateAttText.Size = new System.Drawing.Size(152, 22);
            this.CmiUpdateAttText.Text = "文本";
            this.CmiUpdateAttText.Click += new System.EventHandler(this.CmiUpdateAttText_Click);
            // 
            // CmiUpdateAttPass
            // 
            this.CmiUpdateAttPass.Name = "CmiUpdateAttPass";
            this.CmiUpdateAttPass.Size = new System.Drawing.Size(152, 22);
            this.CmiUpdateAttPass.Text = "口令";
            this.CmiUpdateAttPass.Click += new System.EventHandler(this.CmiUpdateAttPass_Click);
            // 
            // CmiUpdateAttLink
            // 
            this.CmiUpdateAttLink.Name = "CmiUpdateAttLink";
            this.CmiUpdateAttLink.Size = new System.Drawing.Size(152, 22);
            this.CmiUpdateAttLink.Text = "链接";
            this.CmiUpdateAttLink.Click += new System.EventHandler(this.CmiUpdateAttLink_Click);
            // 
            // CmiUpdateAttMail
            // 
            this.CmiUpdateAttMail.Name = "CmiUpdateAttMail";
            this.CmiUpdateAttMail.Size = new System.Drawing.Size(152, 22);
            this.CmiUpdateAttMail.Text = "邮件";
            this.CmiUpdateAttMail.Click += new System.EventHandler(this.CmiUpdateAttMail_Click);
            // 
            // CmiUpdateAttDate
            // 
            this.CmiUpdateAttDate.Name = "CmiUpdateAttDate";
            this.CmiUpdateAttDate.Size = new System.Drawing.Size(152, 22);
            this.CmiUpdateAttDate.Text = "日期";
            this.CmiUpdateAttDate.Click += new System.EventHandler(this.CmiUpdateAttDate_Click);
            // 
            // CmiUpdateAttData
            // 
            this.CmiUpdateAttData.Name = "CmiUpdateAttData";
            this.CmiUpdateAttData.Size = new System.Drawing.Size(152, 22);
            this.CmiUpdateAttData.Text = "数值";
            this.CmiUpdateAttData.Click += new System.EventHandler(this.CmiUpdateAttData_Click);
            // 
            // CmiUpdateAttList
            // 
            this.CmiUpdateAttList.Name = "CmiUpdateAttList";
            this.CmiUpdateAttList.Size = new System.Drawing.Size(152, 22);
            this.CmiUpdateAttList.Text = "列表";
            this.CmiUpdateAttList.Visible = false;
            this.CmiUpdateAttList.Click += new System.EventHandler(this.CmiUpdateAttList_Click);
            // 
            // CmiUpdateAttMemo
            // 
            this.CmiUpdateAttMemo.Name = "CmiUpdateAttMemo";
            this.CmiUpdateAttMemo.Size = new System.Drawing.Size(152, 22);
            this.CmiUpdateAttMemo.Text = "附注";
            this.CmiUpdateAttMemo.Click += new System.EventHandler(this.CmiUpdateAttMemo_Click);
            // 
            // CmiUpdateAttFile
            // 
            this.CmiUpdateAttFile.Name = "CmiUpdateAttFile";
            this.CmiUpdateAttFile.Size = new System.Drawing.Size(152, 22);
            this.CmiUpdateAttFile.Text = "附件";
            this.CmiUpdateAttFile.Click += new System.EventHandler(this.CmiUpdateAttFile_Click);
            // 
            // CmiUpdateAttLine
            // 
            this.CmiUpdateAttLine.Name = "CmiUpdateAttLine";
            this.CmiUpdateAttLine.Size = new System.Drawing.Size(152, 22);
            this.CmiUpdateAttLine.Text = "分组";
            this.CmiUpdateAttLine.Visible = false;
            this.CmiUpdateAttLine.Click += new System.EventHandler(this.CmiUpdateAttLine_Click);
            // 
            // CmiDeleteAtt
            // 
            this.CmiDeleteAtt.Name = "CmiDeleteAtt";
            this.CmiDeleteAtt.Size = new System.Drawing.Size(152, 22);
            this.CmiDeleteAtt.Text = "删除属性";
            this.CmiDeleteAtt.Click += new System.EventHandler(this.CmiDeleteAtt_Click);
            // 
            // GbGroup
            // 
            this.GbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbGroup.Controls.Add(this.BtDrop);
            this.GbGroup.Controls.Add(this.BtSave);
            this.GbGroup.Controls.Add(this.BtCopy);
            this.GbGroup.Location = new System.Drawing.Point(0, 151);
            this.GbGroup.Name = "GbGroup";
            this.GbGroup.Size = new System.Drawing.Size(350, 110);
            this.GbGroup.TabIndex = 1;
            this.GbGroup.TabStop = false;
            this.GbGroup.Text = "提示";
            // 
            // BtDrop
            // 
            this.BtDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtDrop.Location = new System.Drawing.Point(321, 81);
            this.BtDrop.Name = "BtDrop";
            this.BtDrop.Size = new System.Drawing.Size(23, 23);
            this.BtDrop.TabIndex = 3;
            this.BtDrop.UseVisualStyleBackColor = true;
            this.BtDrop.Click += new System.EventHandler(this.BtDrop_Click);
            // 
            // BtSave
            // 
            this.BtSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtSave.Location = new System.Drawing.Point(321, 52);
            this.BtSave.Name = "BtSave";
            this.BtSave.Size = new System.Drawing.Size(23, 23);
            this.BtSave.TabIndex = 2;
            this.BtSave.UseVisualStyleBackColor = true;
            this.BtSave.Click += new System.EventHandler(this.BtSave_Click);
            // 
            // BtCopy
            // 
            this.BtCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtCopy.Location = new System.Drawing.Point(321, 23);
            this.BtCopy.Name = "BtCopy";
            this.BtCopy.Size = new System.Drawing.Size(23, 23);
            this.BtCopy.TabIndex = 1;
            this.BtCopy.UseVisualStyleBackColor = true;
            this.BtCopy.Click += new System.EventHandler(this.BtCopy_Click);
            // 
            // CmiAppendAttCall
            // 
            this.CmiAppendAttCall.Name = "CmiAppendAttCall";
            this.CmiAppendAttCall.Size = new System.Drawing.Size(152, 22);
            this.CmiAppendAttCall.Text = "电话";
            this.CmiAppendAttCall.Click += new System.EventHandler(this.CmiAppendAttCall_Click);
            // 
            // CmiUpdateAttCall
            // 
            this.CmiUpdateAttCall.Name = "CmiUpdateAttCall";
            this.CmiUpdateAttCall.Size = new System.Drawing.Size(152, 22);
            this.CmiUpdateAttCall.Text = "电话";
            this.CmiUpdateAttCall.Click += new System.EventHandler(this.CmiUpdateAttCall_Click);
            // 
            // APro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GvAttList);
            this.Controls.Add(this.GbGroup);
            this.Name = "APro";
            this.Size = new System.Drawing.Size(350, 261);
            ((System.ComponentModel.ISupportInitialize)(this.GvAttList)).EndInit();
            this.CmAtt.ResumeLayout(false);
            this.GbGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbGroup;
        private System.Windows.Forms.DataGridView GvAttList;
        private System.Windows.Forms.ContextMenuStrip CmAtt;
        private System.Windows.Forms.ToolStripMenuItem CmuAppendAtt;
        private System.Windows.Forms.ToolStripMenuItem CmiAppendAttText;
        private System.Windows.Forms.ToolStripMenuItem CmiAppendAttPass;
        private System.Windows.Forms.ToolStripMenuItem CmiAppendAttLink;
        private System.Windows.Forms.ToolStripMenuItem CmiAppendAttMail;
        private System.Windows.Forms.ToolStripMenuItem CmiAppendAttDate;
        private System.Windows.Forms.ToolStripMenuItem CmiAppendAttData;
        private System.Windows.Forms.ToolStripMenuItem CmiAppendAttList;
        private System.Windows.Forms.ToolStripMenuItem CmiAppendAttMemo;
        private System.Windows.Forms.ToolStripMenuItem CmiAppendAttFile;
        private System.Windows.Forms.ToolStripMenuItem CmiAppendAttLine;
        private System.Windows.Forms.ToolStripMenuItem CmuUpdateAtt;
        private System.Windows.Forms.ToolStripMenuItem CmiUpdateAttText;
        private System.Windows.Forms.ToolStripMenuItem CmiUpdateAttPass;
        private System.Windows.Forms.ToolStripMenuItem CmiUpdateAttLink;
        private System.Windows.Forms.ToolStripMenuItem CmiUpdateAttMail;
        private System.Windows.Forms.ToolStripMenuItem CmiUpdateAttDate;
        private System.Windows.Forms.ToolStripMenuItem CmiUpdateAttData;
        private System.Windows.Forms.ToolStripMenuItem CmiUpdateAttList;
        private System.Windows.Forms.ToolStripMenuItem CmiUpdateAttMemo;
        private System.Windows.Forms.ToolStripMenuItem CmiUpdateAttFile;
        private System.Windows.Forms.ToolStripMenuItem CmiUpdateAttLine;
        private System.Windows.Forms.ToolStripMenuItem CmiDeleteAtt;
        private System.Windows.Forms.Button BtDrop;
        private System.Windows.Forms.Button BtSave;
        private System.Windows.Forms.Button BtCopy;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueCol;
        private System.Windows.Forms.ToolStripMenuItem CmiAppendAttCall;
        private System.Windows.Forms.ToolStripMenuItem CmiUpdateAttCall;
    }
}

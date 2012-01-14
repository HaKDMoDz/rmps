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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GvAttList = new System.Windows.Forms.DataGridView();
            this.OrderCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AeAttEdit = new Me.Amon.Pwd.Pro.AttEdit();
            ((System.ComponentModel.ISupportInitialize)(this.GvAttList)).BeginInit();
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
            this.GvAttList.Location = new System.Drawing.Point(0, 0);
            this.GvAttList.MultiSelect = false;
            this.GvAttList.Name = "GvAttList";
            this.GvAttList.ReadOnly = true;
            this.GvAttList.RowHeadersVisible = false;
            this.GvAttList.RowTemplate.Height = 23;
            this.GvAttList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GvAttList.Size = new System.Drawing.Size(332, 145);
            this.GvAttList.TabIndex = 0;
            this.GvAttList.SelectionChanged += new System.EventHandler(this.GvAttList_SelectionChanged);
            // 
            // OrderCol
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.OrderCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.OrderCol.HeaderText = "索引";
            this.OrderCol.Name = "OrderCol";
            this.OrderCol.ReadOnly = true;
            this.OrderCol.Width = 52;
            // 
            // ValueCol
            // 
            this.ValueCol.HeaderText = "属性";
            this.ValueCol.Name = "ValueCol";
            this.ValueCol.ReadOnly = true;
            // 
            // AeAttEdit
            // 
            this.AeAttEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AeAttEdit.Location = new System.Drawing.Point(0, 151);
            this.AeAttEdit.Name = "AeAttEdit";
            this.AeAttEdit.Size = new System.Drawing.Size(332, 110);
            this.AeAttEdit.TabIndex = 1;
            // 
            // APro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GvAttList);
            this.Controls.Add(this.AeAttEdit);
            this.Name = "APro";
            this.Size = new System.Drawing.Size(332, 261);
            ((System.ComponentModel.ISupportInitialize)(this.GvAttList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AttEdit AeAttEdit;
        private System.Windows.Forms.DataGridView GvAttList;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueCol;
    }
}

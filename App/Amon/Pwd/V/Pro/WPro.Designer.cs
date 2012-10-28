using Me.Amon.Pwd._Cat;
using Me.Amon.Pwd._Key;
namespace Me.Amon.Pwd.V.Pro
{
    partial class WPro
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
            this.GvAttList = new System.Windows.Forms.DataGridView();
            this.OrderCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GbGroup = new System.Windows.Forms.GroupBox();
            this.BtDrop = new System.Windows.Forms.Button();
            this.BtSave = new System.Windows.Forms.Button();
            this.BtFill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GvAttList)).BeginInit();
            this.GbGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // GvAttList
            // 
            this.GvAttList.AllowUserToAddRows = false;
            this.GvAttList.AllowUserToDeleteRows = false;
            this.GvAttList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GvAttList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GvAttList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvAttList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderCol,
            this.ValueCol});
            this.GvAttList.Location = new System.Drawing.Point(3, 3);
            this.GvAttList.MultiSelect = false;
            this.GvAttList.Name = "GvAttList";
            this.GvAttList.ReadOnly = true;
            this.GvAttList.RowHeadersVisible = false;
            this.GvAttList.RowTemplate.Height = 23;
            this.GvAttList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GvAttList.Size = new System.Drawing.Size(376, 160);
            this.GvAttList.TabIndex = 0;
            // 
            // OrderCol
            // 
            this.OrderCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.OrderCol.HeaderText = "排序";
            this.OrderCol.Name = "OrderCol";
            this.OrderCol.ReadOnly = true;
            this.OrderCol.Width = 54;
            // 
            // ValueCol
            // 
            this.ValueCol.HeaderText = "属性";
            this.ValueCol.Name = "ValueCol";
            this.ValueCol.ReadOnly = true;
            // 
            // GbGroup
            // 
            this.GbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GbGroup.Controls.Add(this.BtDrop);
            this.GbGroup.Controls.Add(this.BtSave);
            this.GbGroup.Controls.Add(this.BtFill);
            this.GbGroup.Location = new System.Drawing.Point(3, 169);
            this.GbGroup.Name = "GbGroup";
            this.GbGroup.Size = new System.Drawing.Size(376, 110);
            this.GbGroup.TabIndex = 1;
            this.GbGroup.TabStop = false;
            this.GbGroup.Text = "属性";
            // 
            // BtDrop
            // 
            this.BtDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtDrop.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtDrop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtDrop.Location = new System.Drawing.Point(354, 88);
            this.BtDrop.Name = "BtDrop";
            this.BtDrop.Size = new System.Drawing.Size(16, 16);
            this.BtDrop.TabIndex = 2;
            this.BtDrop.UseVisualStyleBackColor = true;
            // 
            // BtSave
            // 
            this.BtSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtSave.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtSave.Location = new System.Drawing.Point(354, 66);
            this.BtSave.Name = "BtSave";
            this.BtSave.Size = new System.Drawing.Size(16, 16);
            this.BtSave.TabIndex = 1;
            this.BtSave.UseVisualStyleBackColor = true;
            // 
            // BtFill
            // 
            this.BtFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtFill.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtFill.Location = new System.Drawing.Point(354, 44);
            this.BtFill.Name = "BtFill";
            this.BtFill.Size = new System.Drawing.Size(16, 16);
            this.BtFill.TabIndex = 0;
            this.BtFill.UseVisualStyleBackColor = true;
            // 
            // APro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GbGroup);
            this.Controls.Add(this.GvAttList);
            this.Name = "APro";
            this.Size = new System.Drawing.Size(382, 282);
            ((System.ComponentModel.ISupportInitialize)(this.GvAttList)).EndInit();
            this.GbGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GvAttList;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueCol;
        private System.Windows.Forms.GroupBox GbGroup;
        private System.Windows.Forms.Button BtFill;
        private System.Windows.Forms.Button BtSave;
        private System.Windows.Forms.Button BtDrop;
    }
}

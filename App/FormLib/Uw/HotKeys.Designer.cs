namespace Me.Amon.Uw
{
    partial class HotKeys
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
            this.DvKeys = new System.Windows.Forms.DataGridView();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DvKeys)).BeginInit();
            this.SuspendLayout();
            // 
            // DvKeys
            // 
            this.DvKeys.AllowUserToAddRows = false;
            this.DvKeys.AllowUserToDeleteRows = false;
            this.DvKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DvKeys.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DvKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DvKeys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.Memo});
            this.DvKeys.Location = new System.Drawing.Point(12, 12);
            this.DvKeys.MultiSelect = false;
            this.DvKeys.Name = "DvKeys";
            this.DvKeys.ReadOnly = true;
            this.DvKeys.RowHeadersVisible = false;
            this.DvKeys.RowTemplate.Height = 23;
            this.DvKeys.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DvKeys.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DvKeys.Size = new System.Drawing.Size(370, 199);
            this.DvKeys.TabIndex = 0;
            // 
            // Key
            // 
            this.Key.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Key.DataPropertyName = "Key";
            this.Key.HeaderText = "按键";
            this.Key.Name = "Key";
            this.Key.ReadOnly = true;
            this.Key.Width = 54;
            // 
            // Memo
            // 
            this.Memo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Memo.DataPropertyName = "Memo";
            this.Memo.HeaderText = "功能";
            this.Memo.Name = "Memo";
            this.Memo.ReadOnly = true;
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtOk.Location = new System.Drawing.Point(307, 217);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 1;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // HotKeys
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtOk;
            this.ClientSize = new System.Drawing.Size(394, 252);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.DvKeys);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HotKeys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "快捷键";
            ((System.ComponentModel.ISupportInitialize)(this.DvKeys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DvKeys;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memo;
    }
}
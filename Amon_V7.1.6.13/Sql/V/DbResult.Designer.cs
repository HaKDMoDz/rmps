 namespace Me.Amon.Sql.V
{
    partial class DbResult
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
            this.GvList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GvList)).BeginInit();
            this.SuspendLayout();
            // 
            // GvList
            // 
            this.GvList.AllowUserToAddRows = false;
            this.GvList.AllowUserToDeleteRows = false;
            this.GvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GvList.Location = new System.Drawing.Point(0, 0);
            this.GvList.Name = "GvList";
            this.GvList.ReadOnly = true;
            this.GvList.RowTemplate.Height = 23;
            this.GvList.Size = new System.Drawing.Size(454, 231);
            this.GvList.TabIndex = 0;
            // 
            // DbResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GvList);
            this.Name = "DbResult";
            this.Size = new System.Drawing.Size(454, 231);
            ((System.ComponentModel.ISupportInitialize)(this.GvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GvList;
    }
}

namespace Me.Amon.Sql.Editor
{
    partial class SqlEditor
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
            this.TbSql = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TbSql
            // 
            this.TbSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbSql.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TbSql.Location = new System.Drawing.Point(0, 0);
            this.TbSql.Multiline = true;
            this.TbSql.Name = "TbSql";
            this.TbSql.Size = new System.Drawing.Size(150, 150);
            this.TbSql.TabIndex = 0;
            this.TbSql.Text = "select * from abc;";
            // 
            // SqlEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbSql);
            this.Name = "SqlEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbSql;
    }
}

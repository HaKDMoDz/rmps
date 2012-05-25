namespace Me.Amon.Sql.Editor
{
    partial class UdfEditor
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
            this.LblSqlList = new System.Windows.Forms.Label();
            this.CbSqlList = new System.Windows.Forms.ComboBox();
            this.TbSql = new System.Windows.Forms.TextBox();
            this.TpInput = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // LblSqlList
            // 
            this.LblSqlList.AutoSize = true;
            this.LblSqlList.Location = new System.Drawing.Point(3, 6);
            this.LblSqlList.Name = "LblSqlList";
            this.LblSqlList.Size = new System.Drawing.Size(53, 12);
            this.LblSqlList.TabIndex = 0;
            this.LblSqlList.Text = "功能列表";
            // 
            // CbSqlList
            // 
            this.CbSqlList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbSqlList.FormattingEnabled = true;
            this.CbSqlList.Location = new System.Drawing.Point(62, 3);
            this.CbSqlList.Name = "CbSqlList";
            this.CbSqlList.Size = new System.Drawing.Size(121, 20);
            this.CbSqlList.TabIndex = 1;
            // 
            // TbSql
            // 
            this.TbSql.Location = new System.Drawing.Point(31, 84);
            this.TbSql.Name = "TbSql";
            this.TbSql.Size = new System.Drawing.Size(100, 21);
            this.TbSql.TabIndex = 2;
            // 
            // TpInput
            // 
            this.TpInput.ColumnCount = 2;
            this.TpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TpInput.Location = new System.Drawing.Point(254, 70);
            this.TpInput.Name = "TpInput";
            this.TpInput.RowCount = 2;
            this.TpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TpInput.Size = new System.Drawing.Size(200, 100);
            this.TpInput.TabIndex = 3;
            // 
            // UdfEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TpInput);
            this.Controls.Add(this.TbSql);
            this.Controls.Add(this.CbSqlList);
            this.Controls.Add(this.LblSqlList);
            this.Name = "UdfEditor";
            this.Size = new System.Drawing.Size(440, 216);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblSqlList;
        private System.Windows.Forms.ComboBox CbSqlList;
        private System.Windows.Forms.TextBox TbSql;
        private System.Windows.Forms.TableLayoutPanel TpInput;
    }
}

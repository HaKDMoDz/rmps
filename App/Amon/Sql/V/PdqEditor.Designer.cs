namespace Me.Amon.Sql.Editor
{
    partial class PdqEditor
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
            this.SpPanel = new System.Windows.Forms.SplitContainer();
            this.TpInput = new System.Windows.Forms.TableLayoutPanel();
            this.TbSql = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SpPanel)).BeginInit();
            this.SpPanel.Panel1.SuspendLayout();
            this.SpPanel.Panel2.SuspendLayout();
            this.SpPanel.SuspendLayout();
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
            // SpPanel
            // 
            this.SpPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpPanel.Location = new System.Drawing.Point(3, 29);
            this.SpPanel.Name = "SpPanel";
            // 
            // SpPanel.Panel1
            // 
            this.SpPanel.Panel1.Controls.Add(this.TpInput);
            // 
            // SpPanel.Panel2
            // 
            this.SpPanel.Panel2.Controls.Add(this.TbSql);
            this.SpPanel.Size = new System.Drawing.Size(434, 184);
            this.SpPanel.SplitterDistance = 280;
            this.SpPanel.TabIndex = 2;
            // 
            // TpInput
            // 
            this.TpInput.ColumnCount = 2;
            this.TpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TpInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TpInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TpInput.Location = new System.Drawing.Point(0, 0);
            this.TpInput.Name = "TpInput";
            this.TpInput.RowCount = 1;
            this.TpInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TpInput.Size = new System.Drawing.Size(280, 184);
            this.TpInput.TabIndex = 0;
            // 
            // TbSql
            // 
            this.TbSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbSql.Location = new System.Drawing.Point(0, 0);
            this.TbSql.Multiline = true;
            this.TbSql.Name = "TbSql";
            this.TbSql.ReadOnly = true;
            this.TbSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TbSql.Size = new System.Drawing.Size(150, 184);
            this.TbSql.TabIndex = 0;
            // 
            // PdqEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SpPanel);
            this.Controls.Add(this.CbSqlList);
            this.Controls.Add(this.LblSqlList);
            this.Name = "PdqEditor";
            this.Size = new System.Drawing.Size(440, 216);
            this.SpPanel.Panel1.ResumeLayout(false);
            this.SpPanel.Panel2.ResumeLayout(false);
            this.SpPanel.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpPanel)).EndInit();
            this.SpPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblSqlList;
        private System.Windows.Forms.ComboBox CbSqlList;
        private System.Windows.Forms.SplitContainer SpPanel;
        private System.Windows.Forms.TextBox TbSql;
        private System.Windows.Forms.TableLayoutPanel TpInput;
    }
}

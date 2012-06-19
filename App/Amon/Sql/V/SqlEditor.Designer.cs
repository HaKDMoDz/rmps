namespace Me.Amon.Sql.V
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
            this.ScPanel = new System.Windows.Forms.SplitContainer();
            this.TbSql = new System.Windows.Forms.TextBox();
            this.TvObj = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.ScPanel)).BeginInit();
            this.ScPanel.Panel1.SuspendLayout();
            this.ScPanel.Panel2.SuspendLayout();
            this.ScPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScPanel
            // 
            this.ScPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScPanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.ScPanel.Location = new System.Drawing.Point(3, 3);
            this.ScPanel.Name = "ScPanel";
            // 
            // ScPanel.Panel1
            // 
            this.ScPanel.Panel1.Controls.Add(this.TbSql);
            // 
            // ScPanel.Panel2
            // 
            this.ScPanel.Panel2.Controls.Add(this.TvObj);
            this.ScPanel.Size = new System.Drawing.Size(434, 210);
            this.ScPanel.SplitterDistance = 280;
            this.ScPanel.TabIndex = 0;
            // 
            // TbSql
            // 
            this.TbSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbSql.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbSql.Location = new System.Drawing.Point(0, 0);
            this.TbSql.Multiline = true;
            this.TbSql.Name = "TbSql";
            this.TbSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TbSql.Size = new System.Drawing.Size(280, 210);
            this.TbSql.TabIndex = 0;
            // 
            // TvObj
            // 
            this.TvObj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvObj.Location = new System.Drawing.Point(0, 0);
            this.TvObj.Name = "TvObj";
            this.TvObj.Size = new System.Drawing.Size(150, 210);
            this.TvObj.TabIndex = 0;
            this.TvObj.DoubleClick += new System.EventHandler(this.TvObj_DoubleClick);
            // 
            // SqlEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ScPanel);
            this.Name = "SqlEditor";
            this.Size = new System.Drawing.Size(440, 216);
            this.ScPanel.Panel1.ResumeLayout(false);
            this.ScPanel.Panel1.PerformLayout();
            this.ScPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScPanel)).EndInit();
            this.ScPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer ScPanel;
        private System.Windows.Forms.TreeView TvObj;
        private System.Windows.Forms.TextBox TbSql;

    }
}

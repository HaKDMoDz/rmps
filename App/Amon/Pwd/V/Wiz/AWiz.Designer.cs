namespace Me.Amon.Pwd.V.Wiz
{
    partial class AWiz
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
            this.TpGrid = new System.Windows.Forms.TableLayoutPanel();
            this.guid = new System.Windows.Forms.FlowLayoutPanel();
            this.BtNext = new System.Windows.Forms.Button();
            this.BtPrev = new System.Windows.Forms.Button();
            this.TpGrid.SuspendLayout();
            this.guid.SuspendLayout();
            this.SuspendLayout();
            // 
            // TpGrid
            // 
            this.TpGrid.ColumnCount = 1;
            this.TpGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TpGrid.Controls.Add(this.guid, 0, 1);
            this.TpGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TpGrid.Location = new System.Drawing.Point(0, 0);
            this.TpGrid.Name = "TpGrid";
            this.TpGrid.RowCount = 2;
            this.TpGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TpGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.TpGrid.Size = new System.Drawing.Size(332, 261);
            this.TpGrid.TabIndex = 0;
            // 
            // guid
            // 
            this.guid.Controls.Add(this.BtNext);
            this.guid.Controls.Add(this.BtPrev);
            this.guid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guid.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.guid.Location = new System.Drawing.Point(3, 232);
            this.guid.Name = "guid";
            this.guid.Size = new System.Drawing.Size(326, 26);
            this.guid.TabIndex = 1;
            // 
            // BtNext
            // 
            this.BtNext.Location = new System.Drawing.Point(248, 3);
            this.BtNext.Name = "BtNext";
            this.BtNext.Size = new System.Drawing.Size(75, 23);
            this.BtNext.TabIndex = 1;
            this.BtNext.Text = "下一步(&N)";
            this.BtNext.UseVisualStyleBackColor = true;
            this.BtNext.Click += new System.EventHandler(this.BtNext_Click);
            // 
            // BtPrev
            // 
            this.BtPrev.Location = new System.Drawing.Point(167, 3);
            this.BtPrev.Name = "BtPrev";
            this.BtPrev.Size = new System.Drawing.Size(75, 23);
            this.BtPrev.TabIndex = 0;
            this.BtPrev.Text = "上一步(&P)";
            this.BtPrev.UseVisualStyleBackColor = true;
            this.BtPrev.Click += new System.EventHandler(this.BtPrev_Click);
            // 
            // AWiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TpGrid);
            this.Name = "AWiz";
            this.Size = new System.Drawing.Size(332, 261);
            this.TpGrid.ResumeLayout(false);
            this.guid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TpGrid;
        private System.Windows.Forms.FlowLayoutPanel guid;
        private System.Windows.Forms.Button BtNext;
        private System.Windows.Forms.Button BtPrev;
    }
}

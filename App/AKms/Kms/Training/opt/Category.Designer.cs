namespace Me.Amon.Kms.Training.Opt
{
    partial class Category
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
            this.TsToolBar = new System.Windows.Forms.ToolStrip();
            this.LbInfo = new System.Windows.Forms.ToolStripLabel();
            this.CbCategory = new System.Windows.Forms.ToolStripComboBox();
            this.BtDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtNa = new System.Windows.Forms.ToolStripButton();
            this.BtRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TsToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // TsToolBar
            // 
            this.TsToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LbInfo,
            this.CbCategory,
            this.BtRemove,
            this.toolStripSeparator2,
            this.BtDelete,
            this.toolStripSeparator1,
            this.BtNa});
            this.TsToolBar.Location = new System.Drawing.Point(0, 0);
            this.TsToolBar.Name = "TsToolBar";
            this.TsToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.TsToolBar.Size = new System.Drawing.Size(290, 25);
            this.TsToolBar.TabIndex = 0;
            this.TsToolBar.Text = "toolStrip1";
            // 
            // LbInfo
            // 
            this.LbInfo.Name = "LbInfo";
            this.LbInfo.Size = new System.Drawing.Size(44, 22);
            this.LbInfo.Text = "标签：";
            // 
            // CbCategory
            // 
            this.CbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbCategory.Font = new System.Drawing.Font("宋体", 9F);
            this.CbCategory.Name = "CbCategory";
            this.CbCategory.Size = new System.Drawing.Size(121, 25);
            this.CbCategory.ToolTipText = "已有标签";
            // 
            // BtDelete
            // 
            this.BtDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtDelete.Image = global::Me.Amon.Properties.Resources._del;
            this.BtDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtDelete.Name = "BtDelete";
            this.BtDelete.Size = new System.Drawing.Size(23, 22);
            this.BtDelete.Text = "废弃选中标签";
            this.BtDelete.Click += new System.EventHandler(this.BtDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BtNa
            // 
            this.BtNa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtNa.Image = global::Me.Amon.Properties.Resources.na;
            this.BtNa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtNa.Name = "BtNa";
            this.BtNa.Size = new System.Drawing.Size(23, 22);
            this.BtNa.Text = "就这样吧";
            this.BtNa.Click += new System.EventHandler(this.BtNa_Click);
            // 
            // BtRemove
            // 
            this.BtRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtRemove.Image = global::Me.Amon.Properties.Resources._sub;
            this.BtRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtRemove.Name = "BtRemove";
            this.BtRemove.Size = new System.Drawing.Size(23, 22);
            this.BtRemove.Text = "移除选中标签";
            this.BtRemove.Click += new System.EventHandler(this.BtRemove_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TsToolBar);
            this.Name = "Category";
            this.Size = new System.Drawing.Size(290, 25);
            this.TsToolBar.ResumeLayout(false);
            this.TsToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TsToolBar;
        private System.Windows.Forms.ToolStripButton BtNa;
        private System.Windows.Forms.ToolStripComboBox CbCategory;
        private System.Windows.Forms.ToolStripButton BtDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel LbInfo;
        private System.Windows.Forms.ToolStripButton BtRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

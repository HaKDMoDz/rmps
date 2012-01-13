namespace Me.Amon.Uc
{
    partial class IcoEdit
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IcoEdit));
            this.LbDir = new System.Windows.Forms.ListBox();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiAppend = new System.Windows.Forms.ToolStripMenuItem();
            this.MiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.MiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbDir
            // 
            this.LbDir.ContextMenuStrip = this.CmMenu;
            this.LbDir.FormattingEnabled = true;
            this.LbDir.ItemHeight = 12;
            this.LbDir.Location = new System.Drawing.Point(12, 12);
            this.LbDir.Name = "LbDir";
            this.LbDir.Size = new System.Drawing.Size(120, 220);
            this.LbDir.TabIndex = 0;
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiAppend,
            this.MiUpdate,
            this.MiDelete});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(142, 70);
            // 
            // MiAppend
            // 
            this.MiAppend.Name = "MiAppend";
            this.MiAppend.Size = new System.Drawing.Size(141, 22);
            this.MiAppend.Text = "添加分类(&A)";
            this.MiAppend.Click += new System.EventHandler(this.MiAppend_Click);
            // 
            // MiUpdate
            // 
            this.MiUpdate.Name = "MiUpdate";
            this.MiUpdate.Size = new System.Drawing.Size(141, 22);
            this.MiUpdate.Text = "更新分类(&U)";
            this.MiUpdate.Click += new System.EventHandler(this.MiUpdate_Click);
            // 
            // MiDelete
            // 
            this.MiDelete.Name = "MiDelete";
            this.MiDelete.Size = new System.Drawing.Size(141, 22);
            this.MiDelete.Text = "删除分类(&D)";
            this.MiDelete.Click += new System.EventHandler(this.MiDelete_Click);
            // 
            // IcoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 273);
            this.Controls.Add(this.LbDir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IcoEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图标管理";
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LbDir;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiAppend;
        private System.Windows.Forms.ToolStripMenuItem MiUpdate;
        private System.Windows.Forms.ToolStripMenuItem MiDelete;
    }
}
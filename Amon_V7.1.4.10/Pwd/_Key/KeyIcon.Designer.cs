namespace Me.Amon.Pwd._Key
{
    partial class KeyIcon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyIcon));
            this.LsDir = new System.Windows.Forms.ListBox();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiAppend = new System.Windows.Forms.ToolStripMenuItem();
            this.MiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.MiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.IlIco = new System.Windows.Forms.ImageList(this.components);
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LsDir
            // 
            this.LsDir.ContextMenuStrip = this.CmMenu;
            this.LsDir.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LsDir.FormattingEnabled = true;
            this.LsDir.IntegralHeight = false;
            this.LsDir.ItemHeight = 20;
            this.LsDir.Location = new System.Drawing.Point(12, 12);
            this.LsDir.Name = "LsDir";
            this.LsDir.Size = new System.Drawing.Size(120, 220);
            this.LsDir.TabIndex = 0;
            this.LsDir.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LsDir_DrawItem);
            this.LsDir.SelectedIndexChanged += new System.EventHandler(this.LsDir_SelectedIndexChanged);
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
            // IlIco
            // 
            this.IlIco.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.IlIco.ImageSize = new System.Drawing.Size(16, 16);
            this.IlIco.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // KeyIcon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 273);
            this.Controls.Add(this.LsDir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyIcon";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图标管理";
            this.Load += new System.EventHandler(this.KeyIcon_Load);
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LsDir;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiAppend;
        private System.Windows.Forms.ToolStripMenuItem MiUpdate;
        private System.Windows.Forms.ToolStripMenuItem MiDelete;
        private System.Windows.Forms.ImageList IlIco;
    }
}
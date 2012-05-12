namespace Me.Amon.Pwd.Bean
{
    partial class AFile
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
            this.components = new System.ComponentModel.Container();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiPwdViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSysViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiPwdViewer,
            this.MiSysViewer});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // MiPwdViewer
            // 
            this.MiPwdViewer.Name = "MiPwdViewer";
            this.MiPwdViewer.Size = new System.Drawing.Size(152, 22);
            this.MiPwdViewer.Text = "内置查看器";
            this.MiPwdViewer.Click += new System.EventHandler(this.MiPwdViewer_Click);
            // 
            // MiSysViewer
            // 
            this.MiSysViewer.Name = "MiSysViewer";
            this.MiSysViewer.Size = new System.Drawing.Size(152, 22);
            this.MiSysViewer.Text = "系统查看器";
            this.MiSysViewer.Click += new System.EventHandler(this.MiSysViewer_Click);
            // 
            // AFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "AFile";
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem MiPwdViewer;
        private System.Windows.Forms.ToolStripMenuItem MiSysViewer;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
    }
}

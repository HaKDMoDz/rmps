namespace Me.Amon.Pwd.Bean
{
    partial class APass
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
            this.MuCharLen = new System.Windows.Forms.ToolStripMenuItem();
            this.MuCharSet = new System.Windows.Forms.ToolStripMenuItem();
            this.MiRepeatable = new System.Windows.Forms.ToolStripMenuItem();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MuCharLen,
            this.MuCharSet,
            this.MiRepeatable});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(165, 92);
            // 
            // MuCharLen
            // 
            this.MuCharLen.Name = "MuCharLen";
            this.MuCharLen.Size = new System.Drawing.Size(164, 22);
            this.MuCharLen.Text = "口令长度(&L)";
            // 
            // MuCharSet
            // 
            this.MuCharSet.Name = "MuCharSet";
            this.MuCharSet.Size = new System.Drawing.Size(164, 22);
            this.MuCharSet.Text = "字符空间(&C)";
            // 
            // MiRepeatable
            // 
            this.MiRepeatable.Name = "MiRepeatable";
            this.MiRepeatable.Size = new System.Drawing.Size(164, 22);
            this.MiRepeatable.Text = "允许字符重复(&A)";
            this.MiRepeatable.Click += new System.EventHandler(this.MiRepeatable_Click);
            // 
            // APass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "APass";
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem MuCharLen;
        private System.Windows.Forms.ToolStripMenuItem MuCharSet;
        private System.Windows.Forms.ToolStripMenuItem MiRepeatable;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
    }
}

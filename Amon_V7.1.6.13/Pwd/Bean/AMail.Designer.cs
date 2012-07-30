namespace Me.Amon.Pwd.Bean
{
    partial class AMail
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiWork = new System.Windows.Forms.ToolStripMenuItem();
            this.MiHome = new System.Windows.Forms.ToolStripMenuItem();
            this.MiCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.MiPhone = new System.Windows.Forms.ToolStripMenuItem();
            this.MiOther = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiDefault,
            this.toolStripSeparator1,
            this.MiWork,
            this.MiHome,
            this.MiCompany,
            this.MiPhone,
            this.MiOther});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 164);
            // 
            // MiDefault
            // 
            this.MiDefault.Name = "MiDefault";
            this.MiDefault.Size = new System.Drawing.Size(152, 22);
            this.MiDefault.Text = "默认";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // MiWork
            // 
            this.MiWork.Name = "MiWork";
            this.MiWork.Size = new System.Drawing.Size(152, 22);
            this.MiWork.Text = "商务邮件";
            // 
            // MiHome
            // 
            this.MiHome.Name = "MiHome";
            this.MiHome.Size = new System.Drawing.Size(152, 22);
            this.MiHome.Text = "个人邮件";
            // 
            // MiCompany
            // 
            this.MiCompany.Name = "MiCompany";
            this.MiCompany.Size = new System.Drawing.Size(152, 22);
            this.MiCompany.Text = "单位邮件";
            // 
            // MiPhone
            // 
            this.MiPhone.Name = "MiPhone";
            this.MiPhone.Size = new System.Drawing.Size(152, 22);
            this.MiPhone.Text = "手机邮件";
            // 
            // MiOther
            // 
            this.MiOther.Name = "MiOther";
            this.MiOther.Size = new System.Drawing.Size(152, 22);
            this.MiOther.Text = "其它邮件";
            // 
            // AMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "AMail";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MiDefault;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MiWork;
        private System.Windows.Forms.ToolStripMenuItem MiHome;
        private System.Windows.Forms.ToolStripMenuItem MiCompany;
        private System.Windows.Forms.ToolStripMenuItem MiPhone;
        private System.Windows.Forms.ToolStripMenuItem MiOther;
    }
}

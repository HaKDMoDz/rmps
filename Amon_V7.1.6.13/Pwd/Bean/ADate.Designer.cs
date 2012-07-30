namespace Me.Amon.Pwd.Bean
{
    partial class ADate
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
            this.MiDateDef = new System.Windows.Forms.ToolStripMenuItem();
            this.MiDateSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.MuDate = new System.Windows.Forms.ToolStripMenuItem();
            this.MuTime = new System.Windows.Forms.ToolStripMenuItem();
            this.MuDateTime = new System.Windows.Forms.ToolStripMenuItem();
            this.MiDateSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiDateTimeDiy = new System.Windows.Forms.ToolStripMenuItem();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiDateDef,
            this.MiDateSep0,
            this.MuDate,
            this.MuTime,
            this.MuDateTime,
            this.MiDateSep1,
            this.MiDateTimeDiy});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(153, 148);
            // 
            // MiDateDef
            // 
            this.MiDateDef.Name = "MiDateDef";
            this.MiDateDef.Size = new System.Drawing.Size(152, 22);
            this.MiDateDef.Text = "默认格式";
            this.MiDateDef.Click += new System.EventHandler(this.MiDateDef_Click);
            // 
            // MiDateSep0
            // 
            this.MiDateSep0.Name = "MiDateSep0";
            this.MiDateSep0.Size = new System.Drawing.Size(149, 6);
            // 
            // MuDate
            // 
            this.MuDate.Name = "MuDate";
            this.MuDate.Size = new System.Drawing.Size(152, 22);
            this.MuDate.Text = "日期格式";
            // 
            // MuTime
            // 
            this.MuTime.Name = "MuTime";
            this.MuTime.Size = new System.Drawing.Size(152, 22);
            this.MuTime.Text = "时间格式";
            // 
            // MuDateTime
            // 
            this.MuDateTime.Name = "MuDateTime";
            this.MuDateTime.Size = new System.Drawing.Size(152, 22);
            this.MuDateTime.Text = "日期时间格式";
            // 
            // MiDateSep1
            // 
            this.MiDateSep1.Name = "MiDateSep1";
            this.MiDateSep1.Size = new System.Drawing.Size(149, 6);
            // 
            // MiDateTimeDiy
            // 
            this.MiDateTimeDiy.Name = "MiDateTimeDiy";
            this.MiDateTimeDiy.Size = new System.Drawing.Size(152, 22);
            this.MiDateTimeDiy.Text = "其它…(&O)";
            this.MiDateTimeDiy.Click += new System.EventHandler(this.MiDateDiy_Click);
            // 
            // ADate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ADate";
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem MiDateDef;
        private System.Windows.Forms.ToolStripSeparator MiDateSep0;
        private System.Windows.Forms.ToolStripMenuItem MuDate;
        private System.Windows.Forms.ToolStripMenuItem MuTime;
        private System.Windows.Forms.ToolStripMenuItem MuDateTime;
        private System.Windows.Forms.ToolStripSeparator MiDateSep1;
        private System.Windows.Forms.ToolStripMenuItem MiDateTimeDiy;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
    }
}

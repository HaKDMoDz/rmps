namespace Me.Amon.Pwd.Wiz
{
    partial class BeanDate
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
            this.DtData = new System.Windows.Forms.DateTimePicker();
            this.BtNow = new System.Windows.Forms.Button();
            this.BtOpt = new System.Windows.Forms.Button();
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
            // DtData
            // 
            this.DtData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtData.Location = new System.Drawing.Point(0, 0);
            this.DtData.Name = "DtData";
            this.DtData.Size = new System.Drawing.Size(200, 21);
            this.DtData.TabIndex = 0;
            // 
            // BtNow
            // 
            this.BtNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNow.FlatAppearance.BorderSize = 0;
            this.BtNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtNow.Location = new System.Drawing.Point(299, 0);
            this.BtNow.Name = "BtNow";
            this.BtNow.Size = new System.Drawing.Size(21, 21);
            this.BtNow.TabIndex = 1;
            this.BtNow.TabStop = false;
            this.BtNow.UseVisualStyleBackColor = true;
            this.BtNow.Click += new System.EventHandler(this.BtNow_Click);
            // 
            // BtOpt
            // 
            this.BtOpt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOpt.FlatAppearance.BorderSize = 0;
            this.BtOpt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtOpt.Location = new System.Drawing.Point(326, 0);
            this.BtOpt.Name = "BtOpt";
            this.BtOpt.Size = new System.Drawing.Size(21, 21);
            this.BtOpt.TabIndex = 2;
            this.BtOpt.TabStop = false;
            this.BtOpt.UseVisualStyleBackColor = true;
            this.BtOpt.Click += new System.EventHandler(this.BtOpt_Click);
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
            this.CmMenu.Size = new System.Drawing.Size(149, 126);
            // 
            // MiDateDef
            // 
            this.MiDateDef.Name = "MiDateDef";
            this.MiDateDef.Size = new System.Drawing.Size(148, 22);
            this.MiDateDef.Text = "默认格式";
            this.MiDateDef.Click += new System.EventHandler(this.MiDateDef_Click);
            // 
            // MiDateSep0
            // 
            this.MiDateSep0.Name = "MiDateSep0";
            this.MiDateSep0.Size = new System.Drawing.Size(145, 6);
            // 
            // MuDate
            // 
            this.MuDate.Name = "MuDate";
            this.MuDate.Size = new System.Drawing.Size(148, 22);
            this.MuDate.Text = "日期格式";
            // 
            // MuTime
            // 
            this.MuTime.Name = "MuTime";
            this.MuTime.Size = new System.Drawing.Size(148, 22);
            this.MuTime.Text = "时间格式";
            // 
            // MuDateTime
            // 
            this.MuDateTime.Name = "MuDateTime";
            this.MuDateTime.Size = new System.Drawing.Size(148, 22);
            this.MuDateTime.Text = "日期时间格式";
            // 
            // MiDateSep1
            // 
            this.MiDateSep1.Name = "MiDateSep1";
            this.MiDateSep1.Size = new System.Drawing.Size(145, 6);
            // 
            // MiDateTimeDiy
            // 
            this.MiDateTimeDiy.Name = "MiDateTimeDiy";
            this.MiDateTimeDiy.Size = new System.Drawing.Size(148, 22);
            this.MiDateTimeDiy.Text = "其它…(&O)";
            this.MiDateTimeDiy.Click += new System.EventHandler(this.MiDateDiy_Click);
            // 
            // BeanDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtOpt);
            this.Controls.Add(this.BtNow);
            this.Controls.Add(this.DtData);
            this.Name = "BeanDate";
            this.Size = new System.Drawing.Size(350, 24);
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DtData;
        private System.Windows.Forms.Button BtNow;
        private System.Windows.Forms.Button BtOpt;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MuDate;
        private System.Windows.Forms.ToolStripMenuItem MuTime;
        private System.Windows.Forms.ToolStripMenuItem MuDateTime;
        private System.Windows.Forms.ToolStripMenuItem MiDateDef;
        private System.Windows.Forms.ToolStripMenuItem MiDateTimeDiy;
        private System.Windows.Forms.ToolStripSeparator MiDateSep0;
        private System.Windows.Forms.ToolStripSeparator MiDateSep1;
    }
}

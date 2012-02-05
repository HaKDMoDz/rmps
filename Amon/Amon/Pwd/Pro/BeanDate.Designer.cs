namespace Me.Amon.Pwd.Pro
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
            this.BtNow = new System.Windows.Forms.Button();
            this.DtData = new System.Windows.Forms.DateTimePicker();
            this.LbData = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LbName = new System.Windows.Forms.Label();
            this.BtOpt = new System.Windows.Forms.Button();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiDateDef = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MuDate = new System.Windows.Forms.ToolStripMenuItem();
            this.MuTime = new System.Windows.Forms.ToolStripMenuItem();
            this.MuDateTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MiDateTimeDiy = new System.Windows.Forms.ToolStripMenuItem();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtNow
            // 
            this.BtNow.Location = new System.Drawing.Point(56, 57);
            this.BtNow.Name = "BtNow";
            this.BtNow.Size = new System.Drawing.Size(21, 21);
            this.BtNow.TabIndex = 4;
            this.BtNow.UseVisualStyleBackColor = true;
            this.BtNow.Click += new System.EventHandler(this.BtNow_Click);
            // 
            // DtData
            // 
            this.DtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtData.Location = new System.Drawing.Point(56, 30);
            this.DtData.Name = "DtData";
            this.DtData.Size = new System.Drawing.Size(200, 21);
            this.DtData.TabIndex = 3;
            // 
            // LbData
            // 
            this.LbData.AutoSize = true;
            this.LbData.Location = new System.Drawing.Point(3, 33);
            this.LbData.Name = "LbData";
            this.LbData.Size = new System.Drawing.Size(47, 12);
            this.LbData.TabIndex = 2;
            this.LbData.Text = "数据(&D)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(56, 3);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(100, 21);
            this.TbName.TabIndex = 1;
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(3, 6);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(47, 12);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "名称(&N)";
            // 
            // BtOpt
            // 
            this.BtOpt.Location = new System.Drawing.Point(83, 57);
            this.BtOpt.Name = "BtOpt";
            this.BtOpt.Size = new System.Drawing.Size(21, 21);
            this.BtOpt.TabIndex = 5;
            this.BtOpt.UseVisualStyleBackColor = true;
            this.BtOpt.Click += new System.EventHandler(this.BtOpt_Click);
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiDateDef,
            this.toolStripSeparator1,
            this.MuDate,
            this.MuTime,
            this.MuDateTime,
            this.toolStripSeparator2,
            this.MiDateTimeDiy});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(163, 148);
            // 
            // MiDateDef
            // 
            this.MiDateDef.Name = "MiDateDef";
            this.MiDateDef.Size = new System.Drawing.Size(162, 22);
            this.MiDateDef.Text = "默认格式(&D)";
            this.MiDateDef.Click += new System.EventHandler(this.MiDateDef_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // MuDate
            // 
            this.MuDate.Name = "MuDate";
            this.MuDate.Size = new System.Drawing.Size(162, 22);
            this.MuDate.Text = "日期格式(&D)";
            // 
            // MuTime
            // 
            this.MuTime.Name = "MuTime";
            this.MuTime.Size = new System.Drawing.Size(162, 22);
            this.MuTime.Text = "时间格式(&T)";
            // 
            // MuDateTime
            // 
            this.MuDateTime.Name = "MuDateTime";
            this.MuDateTime.Size = new System.Drawing.Size(162, 22);
            this.MuDateTime.Text = "日期时间格式(&F)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // MiDateTimeDiy
            // 
            this.MiDateTimeDiy.Name = "MiDateTimeDiy";
            this.MiDateTimeDiy.Size = new System.Drawing.Size(162, 22);
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
            this.Controls.Add(this.LbData);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.Name = "BeanDate";
            this.Size = new System.Drawing.Size(366, 81);
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtNow;
        private System.Windows.Forms.DateTimePicker DtData;
        private System.Windows.Forms.Label LbData;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.Button BtOpt;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiDateDef;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MuDate;
        private System.Windows.Forms.ToolStripMenuItem MuTime;
        private System.Windows.Forms.ToolStripMenuItem MuDateTime;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MiDateTimeDiy;
    }
}

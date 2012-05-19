namespace Me.Amon.Pwd._Log
{
    partial class LogEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogEdit));
            this.LbLog = new System.Windows.Forms.ListBox();
            this.TbLog = new System.Windows.Forms.TextBox();
            this.BtResume = new System.Windows.Forms.Button();
            this.BtClearCur = new System.Windows.Forms.Button();
            this.BtClearAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbLog
            // 
            this.LbLog.FormattingEnabled = true;
            this.LbLog.ItemHeight = 12;
            this.LbLog.Location = new System.Drawing.Point(12, 12);
            this.LbLog.Name = "LbLog";
            this.LbLog.Size = new System.Drawing.Size(146, 208);
            this.LbLog.TabIndex = 0;
            this.LbLog.SelectedIndexChanged += new System.EventHandler(this.LbLog_SelectedIndexChanged);
            // 
            // TbLog
            // 
            this.TbLog.BackColor = System.Drawing.SystemColors.Window;
            this.TbLog.Location = new System.Drawing.Point(164, 12);
            this.TbLog.Multiline = true;
            this.TbLog.Name = "TbLog";
            this.TbLog.ReadOnly = true;
            this.TbLog.Size = new System.Drawing.Size(288, 208);
            this.TbLog.TabIndex = 1;
            // 
            // BtResume
            // 
            this.BtResume.Location = new System.Drawing.Point(179, 226);
            this.BtResume.Name = "BtResume";
            this.BtResume.Size = new System.Drawing.Size(87, 23);
            this.BtResume.TabIndex = 2;
            this.BtResume.Text = "恢复选择(&R)";
            this.BtResume.UseVisualStyleBackColor = true;
            this.BtResume.Click += new System.EventHandler(this.BtResume_Click);
            // 
            // BtClearCur
            // 
            this.BtClearCur.Location = new System.Drawing.Point(272, 226);
            this.BtClearCur.Name = "BtClearCur";
            this.BtClearCur.Size = new System.Drawing.Size(87, 23);
            this.BtClearCur.TabIndex = 3;
            this.BtClearCur.Text = "清除选择(&S)";
            this.BtClearCur.UseVisualStyleBackColor = true;
            this.BtClearCur.Click += new System.EventHandler(this.BtClearCur_Click);
            // 
            // BtClearAll
            // 
            this.BtClearAll.Location = new System.Drawing.Point(365, 226);
            this.BtClearAll.Name = "BtClearAll";
            this.BtClearAll.Size = new System.Drawing.Size(87, 23);
            this.BtClearAll.TabIndex = 4;
            this.BtClearAll.Text = "清除所有(&A)";
            this.BtClearAll.UseVisualStyleBackColor = true;
            this.BtClearAll.Click += new System.EventHandler(this.BtClearAll_Click);
            // 
            // LogEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 261);
            this.Controls.Add(this.BtClearAll);
            this.Controls.Add(this.BtClearCur);
            this.Controls.Add(this.BtResume);
            this.Controls.Add(this.TbLog);
            this.Controls.Add(this.LbLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "操作日志";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LbLog;
        private System.Windows.Forms.TextBox TbLog;
        private System.Windows.Forms.Button BtResume;
        private System.Windows.Forms.Button BtClearCur;
        private System.Windows.Forms.Button BtClearAll;
    }
}
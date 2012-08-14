namespace Me.Amon.Gtd.V
{
    partial class GtdEditor
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
            this.TcGtd = new System.Windows.Forms.ATabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.UcFixTime = new Me.Amon.Gtd.V.FixTime();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.UcInterval = new Me.Amon.Gtd.V.Interval();
            this.BtOk = new System.Windows.Forms.Button();
            this.BtNo = new System.Windows.Forms.Button();
            this.TcGtd.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TcGtd
            // 
            this.TcGtd.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TcGtd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TcGtd.Controls.Add(this.tabPage1);
            this.TcGtd.Controls.Add(this.tabPage2);
            // 
            // 
            // 
            this.TcGtd.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.TcGtd.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.TcGtd.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.TcGtd.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.TcGtd.DisplayStyleProvider.FocusTrack = true;
            this.TcGtd.DisplayStyleProvider.HotTrack = true;
            this.TcGtd.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TcGtd.DisplayStyleProvider.Opacity = 1F;
            this.TcGtd.DisplayStyleProvider.Overlap = 0;
            this.TcGtd.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
            this.TcGtd.DisplayStyleProvider.Radius = 2;
            this.TcGtd.DisplayStyleProvider.ShowTabCloser = false;
            this.TcGtd.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.TcGtd.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.TcGtd.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.TcGtd.HotTrack = true;
            this.TcGtd.Location = new System.Drawing.Point(12, 12);
            this.TcGtd.Multiline = true;
            this.TcGtd.Name = "TcGtd";
            this.TcGtd.SelectedIndex = 0;
            this.TcGtd.Size = new System.Drawing.Size(400, 250);
            this.TcGtd.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.UcFixTime);
            this.tabPage1.Location = new System.Drawing.Point(23, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(373, 242);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "定时";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // UcFixTime
            // 
            this.UcFixTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UcFixTime.Location = new System.Drawing.Point(3, 3);
            this.UcFixTime.MGtd = null;
            this.UcFixTime.Name = "UcFixTime";
            this.UcFixTime.Size = new System.Drawing.Size(367, 236);
            this.UcFixTime.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.UcInterval);
            this.tabPage2.Location = new System.Drawing.Point(23, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(373, 242);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "间隔";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // UcInterval
            // 
            this.UcInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UcInterval.Location = new System.Drawing.Point(3, 3);
            this.UcInterval.MGtd = null;
            this.UcInterval.Name = "UcInterval";
            this.UcInterval.Size = new System.Drawing.Size(367, 236);
            this.UcInterval.TabIndex = 0;
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(256, 268);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 1;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // BtNo
            // 
            this.BtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNo.Location = new System.Drawing.Point(337, 268);
            this.BtNo.Name = "BtNo";
            this.BtNo.Size = new System.Drawing.Size(75, 23);
            this.BtNo.TabIndex = 2;
            this.BtNo.Text = "取消(&C)";
            this.BtNo.UseVisualStyleBackColor = true;
            this.BtNo.Click += new System.EventHandler(this.BtNo_Click);
            // 
            // GtdEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 303);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.TcGtd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GtdEditor";
            this.Text = "提醒";
            this.Load += new System.EventHandler(this.GtdEditor_Load);
            this.TcGtd.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ATabControl TcGtd;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtNo;
        private FixTime UcFixTime;
        private Interval UcInterval;
    }
}
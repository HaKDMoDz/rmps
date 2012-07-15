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
            this.aTabControl1 = new System.Windows.Forms.ATabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.BtOk = new System.Windows.Forms.Button();
            this.BtNo = new System.Windows.Forms.Button();
            this.fixTime1 = new Me.Amon.Gtd.V.FixTime();
            this.interval1 = new Me.Amon.Gtd.V.Interval();
            this.cyclist1 = new Me.Amon.Gtd.V.Cyclist();
            this.repeat1 = new Me.Amon.Gtd.V.Repeat();
            this.others1 = new Me.Amon.Gtd.V.Others();
            this.aTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // aTabControl1
            // 
            this.aTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.aTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aTabControl1.Controls.Add(this.tabPage1);
            this.aTabControl1.Controls.Add(this.tabPage2);
            this.aTabControl1.Controls.Add(this.tabPage3);
            this.aTabControl1.Controls.Add(this.tabPage4);
            this.aTabControl1.Controls.Add(this.tabPage5);
            // 
            // 
            // 
            this.aTabControl1.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.aTabControl1.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.aTabControl1.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.aTabControl1.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.aTabControl1.DisplayStyleProvider.FocusTrack = true;
            this.aTabControl1.DisplayStyleProvider.HotTrack = true;
            this.aTabControl1.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aTabControl1.DisplayStyleProvider.Opacity = 1F;
            this.aTabControl1.DisplayStyleProvider.Overlap = 0;
            this.aTabControl1.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
            this.aTabControl1.DisplayStyleProvider.Radius = 2;
            this.aTabControl1.DisplayStyleProvider.ShowTabCloser = false;
            this.aTabControl1.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.aTabControl1.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.aTabControl1.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.aTabControl1.HotTrack = true;
            this.aTabControl1.Location = new System.Drawing.Point(12, 12);
            this.aTabControl1.Multiline = true;
            this.aTabControl1.Name = "aTabControl1";
            this.aTabControl1.SelectedIndex = 0;
            this.aTabControl1.Size = new System.Drawing.Size(400, 250);
            this.aTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.fixTime1);
            this.tabPage1.Location = new System.Drawing.Point(23, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(373, 242);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "定时";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.interval1);
            this.tabPage2.Location = new System.Drawing.Point(23, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(373, 242);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "间隔";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cyclist1);
            this.tabPage3.Location = new System.Drawing.Point(23, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(373, 242);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "周期";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.repeat1);
            this.tabPage4.Location = new System.Drawing.Point(23, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(373, 242);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "重复";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.others1);
            this.tabPage5.Location = new System.Drawing.Point(23, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(373, 242);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "特殊";
            this.tabPage5.UseVisualStyleBackColor = true;
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
            // fixTime1
            // 
            this.fixTime1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fixTime1.Location = new System.Drawing.Point(3, 3);
            this.fixTime1.Name = "fixTime1";
            this.fixTime1.Size = new System.Drawing.Size(367, 236);
            this.fixTime1.TabIndex = 0;
            // 
            // interval1
            // 
            this.interval1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interval1.Location = new System.Drawing.Point(3, 3);
            this.interval1.Name = "interval1";
            this.interval1.Size = new System.Drawing.Size(367, 236);
            this.interval1.TabIndex = 0;
            // 
            // cyclist1
            // 
            this.cyclist1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cyclist1.Location = new System.Drawing.Point(0, 0);
            this.cyclist1.Name = "cyclist1";
            this.cyclist1.Size = new System.Drawing.Size(373, 242);
            this.cyclist1.TabIndex = 0;
            // 
            // repeat1
            // 
            this.repeat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.repeat1.Location = new System.Drawing.Point(0, 0);
            this.repeat1.Name = "repeat1";
            this.repeat1.Size = new System.Drawing.Size(373, 242);
            this.repeat1.TabIndex = 0;
            // 
            // others1
            // 
            this.others1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.others1.Location = new System.Drawing.Point(0, 0);
            this.others1.Name = "others1";
            this.others1.Size = new System.Drawing.Size(373, 242);
            this.others1.TabIndex = 0;
            // 
            // GtdEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 303);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.aTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GtdEditor";
            this.Text = "GtdEditor";
            this.Load += new System.EventHandler(this.GtdEditor_Load);
            this.aTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ATabControl aTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtNo;
        private System.Windows.Forms.TabPage tabPage5;
        private FixTime fixTime1;
        private Interval interval1;
        private Cyclist cyclist1;
        private Repeat repeat1;
        private Others others1;
    }
}
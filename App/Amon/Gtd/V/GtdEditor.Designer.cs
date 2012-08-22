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
            this.LbTitle = new System.Windows.Forms.Label();
            this.TbTitle = new System.Windows.Forms.TextBox();
            this.LbType = new System.Windows.Forms.Label();
            this.GpDate = new System.Windows.Forms.GroupBox();
            this.GpStop = new System.Windows.Forms.GroupBox();
            this.UcStop = new Me.Amon.Gtd.V.UcStop();
            this.BtOk = new System.Windows.Forms.Button();
            this.BtNo = new System.Windows.Forms.Button();
            this.RbDates = new System.Windows.Forms.RadioButton();
            this.RbEvent = new System.Windows.Forms.RadioButton();
            this.RbMaths = new System.Windows.Forms.RadioButton();
            this.CkSwitch = new System.Windows.Forms.CheckBox();
            this.GpStop.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Location = new System.Drawing.Point(12, 15);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(47, 12);
            this.LbTitle.TabIndex = 0;
            this.LbTitle.Text = "名称(&N)";
            // 
            // TbTitle
            // 
            this.TbTitle.Location = new System.Drawing.Point(65, 12);
            this.TbTitle.Name = "TbTitle";
            this.TbTitle.Size = new System.Drawing.Size(257, 21);
            this.TbTitle.TabIndex = 1;
            // 
            // LbType
            // 
            this.LbType.AutoSize = true;
            this.LbType.Location = new System.Drawing.Point(12, 41);
            this.LbType.Name = "LbType";
            this.LbType.Size = new System.Drawing.Size(47, 12);
            this.LbType.TabIndex = 2;
            this.LbType.Text = "方案(&S)";
            // 
            // GpDate
            // 
            this.GpDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GpDate.Location = new System.Drawing.Point(12, 65);
            this.GpDate.Name = "GpDate";
            this.GpDate.Size = new System.Drawing.Size(310, 180);
            this.GpDate.TabIndex = 6;
            this.GpDate.TabStop = false;
            this.GpDate.Text = "周期";
            // 
            // GpStop
            // 
            this.GpStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GpStop.Controls.Add(this.UcStop);
            this.GpStop.Location = new System.Drawing.Point(12, 251);
            this.GpStop.Name = "GpStop";
            this.GpStop.Size = new System.Drawing.Size(310, 100);
            this.GpStop.TabIndex = 7;
            this.GpStop.TabStop = false;
            this.GpStop.Text = "结束";
            // 
            // UcStop
            // 
            this.UcStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UcStop.Location = new System.Drawing.Point(3, 17);
            this.UcStop.Name = "UcStop";
            this.UcStop.Size = new System.Drawing.Size(304, 80);
            this.UcStop.TabIndex = 0;
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(166, 357);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 8;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // BtNo
            // 
            this.BtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtNo.Location = new System.Drawing.Point(247, 357);
            this.BtNo.Name = "BtNo";
            this.BtNo.Size = new System.Drawing.Size(75, 23);
            this.BtNo.TabIndex = 9;
            this.BtNo.Text = "取消(&C)";
            this.BtNo.UseVisualStyleBackColor = true;
            this.BtNo.Click += new System.EventHandler(this.BtNo_Click);
            // 
            // RbDates
            // 
            this.RbDates.Location = new System.Drawing.Point(65, 39);
            this.RbDates.Name = "RbDates";
            this.RbDates.Size = new System.Drawing.Size(47, 16);
            this.RbDates.TabIndex = 3;
            this.RbDates.Text = "定时";
            this.RbDates.CheckedChanged += new System.EventHandler(this.RbDates_CheckedChanged);
            // 
            // RbEvent
            // 
            this.RbEvent.Location = new System.Drawing.Point(118, 39);
            this.RbEvent.Name = "RbEvent";
            this.RbEvent.Size = new System.Drawing.Size(47, 16);
            this.RbEvent.TabIndex = 4;
            this.RbEvent.Text = "事件";
            this.RbEvent.CheckedChanged += new System.EventHandler(this.RbEvent_CheckedChanged);
            // 
            // RbMaths
            // 
            this.RbMaths.Enabled = false;
            this.RbMaths.Location = new System.Drawing.Point(171, 39);
            this.RbMaths.Name = "RbMaths";
            this.RbMaths.Size = new System.Drawing.Size(47, 16);
            this.RbMaths.TabIndex = 5;
            this.RbMaths.Text = "公式";
            this.RbMaths.CheckedChanged += new System.EventHandler(this.RbMaths_CheckedChanged);
            // 
            // CkSwitch
            // 
            this.CkSwitch.AutoSize = true;
            this.CkSwitch.Location = new System.Drawing.Point(12, 361);
            this.CkSwitch.Name = "CkSwitch";
            this.CkSwitch.Size = new System.Drawing.Size(84, 16);
            this.CkSwitch.TabIndex = 10;
            this.CkSwitch.Text = "保存为模板";
            this.CkSwitch.UseVisualStyleBackColor = true;
            // 
            // GtdEditor
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtNo;
            this.ClientSize = new System.Drawing.Size(334, 392);
            this.Controls.Add(this.CkSwitch);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.GpStop);
            this.Controls.Add(this.GpDate);
            this.Controls.Add(this.RbMaths);
            this.Controls.Add(this.RbEvent);
            this.Controls.Add(this.RbDates);
            this.Controls.Add(this.LbType);
            this.Controls.Add(this.TbTitle);
            this.Controls.Add(this.LbTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GtdEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提醒";
            this.Load += new System.EventHandler(this.GtdEditor_Load);
            this.GpStop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.TextBox TbTitle;
        private System.Windows.Forms.Label LbType;
        private System.Windows.Forms.GroupBox GpDate;
        private System.Windows.Forms.GroupBox GpStop;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtNo;
        private System.Windows.Forms.RadioButton RbDates;
        private System.Windows.Forms.RadioButton RbEvent;
        private System.Windows.Forms.RadioButton RbMaths;
        private System.Windows.Forms.CheckBox CkSwitch;
        private UcStop UcStop;

    }
}
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
            this.GpHint = new System.Windows.Forms.GroupBox();
            this.NpHint = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.RbMail = new System.Windows.Forms.RadioButton();
            this.RbApps = new System.Windows.Forms.RadioButton();
            this.RbTips = new System.Windows.Forms.RadioButton();
            this.BtOk = new System.Windows.Forms.Button();
            this.BtNo = new System.Windows.Forms.Button();
            this.RbDate = new System.Windows.Forms.RadioButton();
            this.RbEvent = new System.Windows.Forms.RadioButton();
            this.RbMaths = new System.Windows.Forms.RadioButton();
            this.CkControl = new System.Windows.Forms.CheckBox();
            this.GpHint.SuspendLayout();
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
            this.TbTitle.Size = new System.Drawing.Size(171, 21);
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
            this.GpDate.Text = "时间";
            // 
            // GpHint
            // 
            this.GpHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GpHint.Controls.Add(this.NpHint);
            this.GpHint.Controls.Add(this.label1);
            this.GpHint.Controls.Add(this.RbMail);
            this.GpHint.Controls.Add(this.RbApps);
            this.GpHint.Controls.Add(this.RbTips);
            this.GpHint.Location = new System.Drawing.Point(12, 251);
            this.GpHint.Name = "GpHint";
            this.GpHint.Size = new System.Drawing.Size(310, 100);
            this.GpHint.TabIndex = 7;
            this.GpHint.TabStop = false;
            this.GpHint.Text = "提示";
            // 
            // NpHint
            // 
            this.NpHint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NpHint.Location = new System.Drawing.Point(85, 20);
            this.NpHint.Name = "NpHint";
            this.NpHint.Size = new System.Drawing.Size(219, 74);
            this.NpHint.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(77, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 80);
            this.label1.TabIndex = 3;
            // 
            // RbMail
            // 
            this.RbMail.AutoSize = true;
            this.RbMail.Enabled = false;
            this.RbMail.Location = new System.Drawing.Point(6, 64);
            this.RbMail.Name = "RbMail";
            this.RbMail.Size = new System.Drawing.Size(65, 16);
            this.RbMail.TabIndex = 2;
            this.RbMail.TabStop = true;
            this.RbMail.Text = "邮件(&M)";
            this.RbMail.UseVisualStyleBackColor = true;
            this.RbMail.CheckedChanged += new System.EventHandler(this.RbMail_CheckedChanged);
            // 
            // RbApps
            // 
            this.RbApps.AutoSize = true;
            this.RbApps.Location = new System.Drawing.Point(6, 42);
            this.RbApps.Name = "RbApps";
            this.RbApps.Size = new System.Drawing.Size(65, 16);
            this.RbApps.TabIndex = 1;
            this.RbApps.TabStop = true;
            this.RbApps.Text = "应用(&A)";
            this.RbApps.UseVisualStyleBackColor = true;
            this.RbApps.CheckedChanged += new System.EventHandler(this.RbApps_CheckedChanged);
            // 
            // RbTips
            // 
            this.RbTips.AutoSize = true;
            this.RbTips.Location = new System.Drawing.Point(6, 20);
            this.RbTips.Name = "RbTips";
            this.RbTips.Size = new System.Drawing.Size(65, 16);
            this.RbTips.TabIndex = 0;
            this.RbTips.TabStop = true;
            this.RbTips.Text = "消息(&I)";
            this.RbTips.UseVisualStyleBackColor = true;
            this.RbTips.CheckedChanged += new System.EventHandler(this.RbTips_CheckedChanged);
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
            // RbDate
            // 
            this.RbDate.Location = new System.Drawing.Point(65, 39);
            this.RbDate.Name = "RbDate";
            this.RbDate.Size = new System.Drawing.Size(47, 16);
            this.RbDate.TabIndex = 3;
            this.RbDate.Text = "时间";
            this.RbDate.CheckedChanged += new System.EventHandler(this.RbDate_CheckedChanged);
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
            // CkControl
            // 
            this.CkControl.AutoSize = true;
            this.CkControl.Location = new System.Drawing.Point(12, 361);
            this.CkControl.Name = "CkControl";
            this.CkControl.Size = new System.Drawing.Size(78, 16);
            this.CkControl.TabIndex = 10;
            this.CkControl.Text = "checkBox1";
            this.CkControl.UseVisualStyleBackColor = true;
            // 
            // GtdEditor
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtNo;
            this.ClientSize = new System.Drawing.Size(334, 392);
            this.Controls.Add(this.CkControl);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.GpHint);
            this.Controls.Add(this.GpDate);
            this.Controls.Add(this.RbMaths);
            this.Controls.Add(this.RbEvent);
            this.Controls.Add(this.RbDate);
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
            this.GpHint.ResumeLayout(false);
            this.GpHint.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.TextBox TbTitle;
        private System.Windows.Forms.Label LbType;
        private System.Windows.Forms.GroupBox GpDate;
        private System.Windows.Forms.GroupBox GpHint;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtNo;
        private System.Windows.Forms.RadioButton RbMail;
        private System.Windows.Forms.RadioButton RbApps;
        private System.Windows.Forms.RadioButton RbTips;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel NpHint;
        private System.Windows.Forms.RadioButton RbDate;
        private System.Windows.Forms.RadioButton RbEvent;
        private System.Windows.Forms.RadioButton RbMaths;
        private System.Windows.Forms.CheckBox CkControl;

    }
}
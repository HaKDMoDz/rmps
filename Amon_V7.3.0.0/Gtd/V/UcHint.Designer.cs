namespace Me.Amon.Gtd.V
{
    partial class UcHint
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
            this.RbMail = new System.Windows.Forms.RadioButton();
            this.RbApps = new System.Windows.Forms.RadioButton();
            this.RbTips = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.NpHint = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // RbMail
            // 
            this.RbMail.AutoSize = true;
            this.RbMail.Enabled = false;
            this.RbMail.Location = new System.Drawing.Point(3, 47);
            this.RbMail.Name = "RbMail";
            this.RbMail.Size = new System.Drawing.Size(65, 16);
            this.RbMail.TabIndex = 5;
            this.RbMail.TabStop = true;
            this.RbMail.Text = "邮件(&M)";
            this.RbMail.UseVisualStyleBackColor = true;
            this.RbMail.CheckedChanged += new System.EventHandler(this.RbMail_CheckedChanged);
            // 
            // RbApps
            // 
            this.RbApps.AutoSize = true;
            this.RbApps.Location = new System.Drawing.Point(3, 25);
            this.RbApps.Name = "RbApps";
            this.RbApps.Size = new System.Drawing.Size(65, 16);
            this.RbApps.TabIndex = 4;
            this.RbApps.TabStop = true;
            this.RbApps.Text = "应用(&A)";
            this.RbApps.UseVisualStyleBackColor = true;
            this.RbApps.CheckedChanged += new System.EventHandler(this.RbApps_CheckedChanged);
            // 
            // RbTips
            // 
            this.RbTips.AutoSize = true;
            this.RbTips.Location = new System.Drawing.Point(3, 3);
            this.RbTips.Name = "RbTips";
            this.RbTips.Size = new System.Drawing.Size(65, 16);
            this.RbTips.TabIndex = 3;
            this.RbTips.TabStop = true;
            this.RbTips.Text = "消息(&I)";
            this.RbTips.UseVisualStyleBackColor = true;
            this.RbTips.CheckedChanged += new System.EventHandler(this.RbTips_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(74, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 80);
            this.label1.TabIndex = 6;
            // 
            // NpHint
            // 
            this.NpHint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NpHint.Location = new System.Drawing.Point(82, 3);
            this.NpHint.Name = "NpHint";
            this.NpHint.Size = new System.Drawing.Size(219, 74);
            this.NpHint.TabIndex = 7;
            // 
            // UcHint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NpHint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RbMail);
            this.Controls.Add(this.RbApps);
            this.Controls.Add(this.RbTips);
            this.Name = "UcHint";
            this.Size = new System.Drawing.Size(304, 80);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RbMail;
        private System.Windows.Forms.RadioButton RbApps;
        private System.Windows.Forms.RadioButton RbTips;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel NpHint;
    }
}

namespace Me.Amon.Gtd.V
{
    partial class UhMail
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
            this.TbSubject = new System.Windows.Forms.TextBox();
            this.LlSubject = new System.Windows.Forms.Label();
            this.TbAddress = new System.Windows.Forms.TextBox();
            this.LlAddress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TbSubject
            // 
            this.TbSubject.Location = new System.Drawing.Point(38, 30);
            this.TbSubject.Multiline = true;
            this.TbSubject.Name = "TbSubject";
            this.TbSubject.Size = new System.Drawing.Size(178, 41);
            this.TbSubject.TabIndex = 8;
            // 
            // LlSubject
            // 
            this.LlSubject.AutoSize = true;
            this.LlSubject.Location = new System.Drawing.Point(3, 33);
            this.LlSubject.Name = "LlSubject";
            this.LlSubject.Size = new System.Drawing.Size(29, 12);
            this.LlSubject.TabIndex = 7;
            this.LlSubject.Text = "标题";
            // 
            // TbAddress
            // 
            this.TbAddress.Location = new System.Drawing.Point(38, 3);
            this.TbAddress.Name = "TbAddress";
            this.TbAddress.Size = new System.Drawing.Size(151, 21);
            this.TbAddress.TabIndex = 6;
            // 
            // LlAddress
            // 
            this.LlAddress.AutoSize = true;
            this.LlAddress.Location = new System.Drawing.Point(3, 6);
            this.LlAddress.Name = "LlAddress";
            this.LlAddress.Size = new System.Drawing.Size(29, 12);
            this.LlAddress.TabIndex = 5;
            this.LlAddress.Text = "邮件";
            // 
            // UhMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbSubject);
            this.Controls.Add(this.LlSubject);
            this.Controls.Add(this.TbAddress);
            this.Controls.Add(this.LlAddress);
            this.Name = "UhMail";
            this.Size = new System.Drawing.Size(219, 74);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbSubject;
        private System.Windows.Forms.Label LlSubject;
        private System.Windows.Forms.TextBox TbAddress;
        private System.Windows.Forms.Label LlAddress;
    }
}

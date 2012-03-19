namespace Me.Amon.Bar.Opt
{
    partial class Sms
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
            this.LbSub = new System.Windows.Forms.Label();
            this.TbSub = new System.Windows.Forms.TextBox();
            this.LbTxt = new System.Windows.Forms.Label();
            this.TbTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LbSub
            // 
            this.LbSub.AutoSize = true;
            this.LbSub.Location = new System.Drawing.Point(0, 3);
            this.LbSub.Name = "LbSub";
            this.LbSub.Size = new System.Drawing.Size(29, 12);
            this.LbSub.TabIndex = 0;
            this.LbSub.Text = "手机";
            // 
            // TbSub
            // 
            this.TbSub.Location = new System.Drawing.Point(35, 0);
            this.TbSub.Name = "TbSub";
            this.TbSub.Size = new System.Drawing.Size(108, 21);
            this.TbSub.TabIndex = 1;
            // 
            // LbTxt
            // 
            this.LbTxt.AutoSize = true;
            this.LbTxt.Location = new System.Drawing.Point(0, 30);
            this.LbTxt.Name = "LbTxt";
            this.LbTxt.Size = new System.Drawing.Size(29, 12);
            this.LbTxt.TabIndex = 2;
            this.LbTxt.Text = "内容";
            // 
            // TbTxt
            // 
            this.TbTxt.Location = new System.Drawing.Point(35, 27);
            this.TbTxt.MaxLength = 140;
            this.TbTxt.Multiline = true;
            this.TbTxt.Name = "TbTxt";
            this.TbTxt.Size = new System.Drawing.Size(261, 129);
            this.TbTxt.TabIndex = 3;
            // 
            // Sms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbTxt);
            this.Controls.Add(this.LbTxt);
            this.Controls.Add(this.TbSub);
            this.Controls.Add(this.LbSub);
            this.Name = "Sms";
            this.Size = new System.Drawing.Size(296, 156);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbSub;
        private System.Windows.Forms.TextBox TbSub;
        private System.Windows.Forms.Label LbTxt;
        private System.Windows.Forms.TextBox TbTxt;
    }
}

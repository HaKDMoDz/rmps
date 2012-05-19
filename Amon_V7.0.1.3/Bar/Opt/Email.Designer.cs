namespace Me.Amon.Bar.Opt
{
    partial class Email
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
            this.LbAdr = new System.Windows.Forms.Label();
            this.TbAdr = new System.Windows.Forms.TextBox();
            this.LbSub = new System.Windows.Forms.Label();
            this.TbSub = new System.Windows.Forms.TextBox();
            this.LbTxt = new System.Windows.Forms.Label();
            this.TbTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LbAdr
            // 
            this.LbAdr.AutoSize = true;
            this.LbAdr.Location = new System.Drawing.Point(0, 3);
            this.LbAdr.Name = "LbAdr";
            this.LbAdr.Size = new System.Drawing.Size(29, 12);
            this.LbAdr.TabIndex = 0;
            this.LbAdr.Text = "地址";
            // 
            // TbAdr
            // 
            this.TbAdr.Location = new System.Drawing.Point(35, 0);
            this.TbAdr.Name = "TbAdr";
            this.TbAdr.Size = new System.Drawing.Size(261, 21);
            this.TbAdr.TabIndex = 1;
            // 
            // LbSub
            // 
            this.LbSub.AutoSize = true;
            this.LbSub.Location = new System.Drawing.Point(0, 30);
            this.LbSub.Name = "LbSub";
            this.LbSub.Size = new System.Drawing.Size(29, 12);
            this.LbSub.TabIndex = 2;
            this.LbSub.Text = "标题";
            // 
            // TbSub
            // 
            this.TbSub.Location = new System.Drawing.Point(35, 27);
            this.TbSub.Name = "TbSub";
            this.TbSub.Size = new System.Drawing.Size(261, 21);
            this.TbSub.TabIndex = 3;
            // 
            // LbTxt
            // 
            this.LbTxt.AutoSize = true;
            this.LbTxt.Location = new System.Drawing.Point(0, 57);
            this.LbTxt.Name = "LbTxt";
            this.LbTxt.Size = new System.Drawing.Size(29, 12);
            this.LbTxt.TabIndex = 4;
            this.LbTxt.Text = "内容";
            // 
            // TbTxt
            // 
            this.TbTxt.Location = new System.Drawing.Point(35, 54);
            this.TbTxt.MaxLength = 700;
            this.TbTxt.Multiline = true;
            this.TbTxt.Name = "TbTxt";
            this.TbTxt.Size = new System.Drawing.Size(261, 102);
            this.TbTxt.TabIndex = 5;
            // 
            // Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbTxt);
            this.Controls.Add(this.LbTxt);
            this.Controls.Add(this.TbSub);
            this.Controls.Add(this.LbSub);
            this.Controls.Add(this.TbAdr);
            this.Controls.Add(this.LbAdr);
            this.Name = "Email";
            this.Size = new System.Drawing.Size(296, 156);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbAdr;
        private System.Windows.Forms.TextBox TbAdr;
        private System.Windows.Forms.Label LbSub;
        private System.Windows.Forms.TextBox TbSub;
        private System.Windows.Forms.Label LbTxt;
        private System.Windows.Forms.TextBox TbTxt;
    }
}

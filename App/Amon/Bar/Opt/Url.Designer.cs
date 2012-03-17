namespace Me.Amon.Bar.Opt
{
    partial class Url
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
            this.LbUrl = new System.Windows.Forms.Label();
            this.TbUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LbSub
            // 
            this.LbSub.AutoSize = true;
            this.LbSub.Location = new System.Drawing.Point(3, 3);
            this.LbSub.Name = "LbSub";
            this.LbSub.Size = new System.Drawing.Size(29, 12);
            this.LbSub.TabIndex = 0;
            this.LbSub.Text = "名称";
            // 
            // TbSub
            // 
            this.TbSub.Location = new System.Drawing.Point(38, 0);
            this.TbSub.Name = "TbSub";
            this.TbSub.Size = new System.Drawing.Size(150, 21);
            this.TbSub.TabIndex = 1;
            // 
            // LbUrl
            // 
            this.LbUrl.AutoSize = true;
            this.LbUrl.Location = new System.Drawing.Point(3, 30);
            this.LbUrl.Name = "LbUrl";
            this.LbUrl.Size = new System.Drawing.Size(29, 12);
            this.LbUrl.TabIndex = 2;
            this.LbUrl.Text = "链接";
            // 
            // TbUrl
            // 
            this.TbUrl.Location = new System.Drawing.Point(38, 27);
            this.TbUrl.Name = "TbUrl";
            this.TbUrl.Size = new System.Drawing.Size(258, 21);
            this.TbUrl.TabIndex = 3;
            // 
            // Url
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbUrl);
            this.Controls.Add(this.LbUrl);
            this.Controls.Add(this.TbSub);
            this.Controls.Add(this.LbSub);
            this.Name = "Url";
            this.Size = new System.Drawing.Size(296, 148);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbSub;
        private System.Windows.Forms.TextBox TbSub;
        private System.Windows.Forms.Label LbUrl;
        private System.Windows.Forms.TextBox TbUrl;
    }
}

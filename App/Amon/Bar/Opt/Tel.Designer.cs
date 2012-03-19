namespace Me.Amon.Bar.Opt
{
    partial class Tel
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
            this.LbTel = new System.Windows.Forms.Label();
            this.TbTel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LbTel
            // 
            this.LbTel.AutoSize = true;
            this.LbTel.Location = new System.Drawing.Point(0, 3);
            this.LbTel.Name = "LbTel";
            this.LbTel.Size = new System.Drawing.Size(29, 12);
            this.LbTel.TabIndex = 0;
            this.LbTel.Text = "号码";
            // 
            // TbTel
            // 
            this.TbTel.Location = new System.Drawing.Point(35, 0);
            this.TbTel.Name = "TbTel";
            this.TbTel.Size = new System.Drawing.Size(261, 21);
            this.TbTel.TabIndex = 1;
            // 
            // Tel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbTel);
            this.Controls.Add(this.LbTel);
            this.Name = "Tel";
            this.Size = new System.Drawing.Size(296, 156);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbTel;
        private System.Windows.Forms.TextBox TbTel;
    }
}

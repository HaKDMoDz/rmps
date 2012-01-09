namespace Me.Amon.Pwd.Wiz
{
    partial class BeanBody
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
            this.beanText1 = new Me.Amon.Pwd.Wiz.BeanText();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.beanText2 = new Me.Amon.Pwd.Wiz.BeanText();
            this.SuspendLayout();
            // 
            // beanText1
            // 
            this.beanText1.Location = new System.Drawing.Point(69, 3);
            this.beanText1.Name = "beanText1";
            this.beanText1.Size = new System.Drawing.Size(350, 27);
            this.beanText1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // beanText2
            // 
            this.beanText2.Location = new System.Drawing.Point(69, 36);
            this.beanText2.Name = "beanText2";
            this.beanText2.Size = new System.Drawing.Size(350, 27);
            this.beanText2.TabIndex = 2;
            // 
            // BeanBody
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.beanText2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.beanText1);
            this.Name = "BeanBody";
            this.Size = new System.Drawing.Size(350, 250);
            this.ResumeLayout(false);

        }

        #endregion

        private BeanText beanText1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private BeanText beanText2;

    }
}

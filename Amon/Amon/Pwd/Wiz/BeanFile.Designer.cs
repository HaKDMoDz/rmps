namespace Me.Amon.Pwd.Wiz
{
    partial class BeanFile
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtOpen = new System.Windows.Forms.Button();
            this.BtView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 21);
            this.textBox1.TabIndex = 0;
            // 
            // BtOpen
            // 
            this.BtOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtOpen.Location = new System.Drawing.Point(326, 3);
            this.BtOpen.Name = "BtOpen";
            this.BtOpen.Size = new System.Drawing.Size(21, 21);
            this.BtOpen.TabIndex = 2;
            this.BtOpen.Text = "button1";
            this.BtOpen.UseVisualStyleBackColor = true;
            this.BtOpen.Click += new System.EventHandler(this.BtOpen_Click);
            // 
            // BtView
            // 
            this.BtView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtView.Location = new System.Drawing.Point(299, 3);
            this.BtView.Name = "BtView";
            this.BtView.Size = new System.Drawing.Size(21, 21);
            this.BtView.TabIndex = 1;
            this.BtView.Text = "button2";
            this.BtView.UseVisualStyleBackColor = true;
            this.BtView.Click += new System.EventHandler(this.BtView_Click);
            // 
            // BeanFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtView);
            this.Controls.Add(this.BtOpen);
            this.Controls.Add(this.textBox1);
            this.Name = "BeanFile";
            this.Size = new System.Drawing.Size(350, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtOpen;
        private System.Windows.Forms.Button BtView;
    }
}

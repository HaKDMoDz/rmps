namespace Me.Amon.Gtd.V.Uc
{
    partial class UcYear
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
            this.LlEach = new System.Windows.Forms.Label();
            this.SpEach = new System.Windows.Forms.NumericUpDown();
            this.RbEach = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.SpEach)).BeginInit();
            this.SuspendLayout();
            // 
            // LlEach
            // 
            this.LlEach.AutoSize = true;
            this.LlEach.Location = new System.Drawing.Point(117, 7);
            this.LlEach.Name = "LlEach";
            this.LlEach.Size = new System.Drawing.Size(17, 12);
            this.LlEach.TabIndex = 20;
            this.LlEach.Text = "年";
            // 
            // SpEach
            // 
            this.SpEach.Location = new System.Drawing.Point(56, 3);
            this.SpEach.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.SpEach.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpEach.Name = "SpEach";
            this.SpEach.Size = new System.Drawing.Size(55, 21);
            this.SpEach.TabIndex = 19;
            this.SpEach.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RbEach
            // 
            this.RbEach.AutoSize = true;
            this.RbEach.Location = new System.Drawing.Point(3, 5);
            this.RbEach.Name = "RbEach";
            this.RbEach.Size = new System.Drawing.Size(47, 16);
            this.RbEach.TabIndex = 18;
            this.RbEach.TabStop = true;
            this.RbEach.Text = "每隔";
            this.RbEach.UseVisualStyleBackColor = true;
            // 
            // UcYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LlEach);
            this.Controls.Add(this.SpEach);
            this.Controls.Add(this.RbEach);
            this.Name = "UcYear";
            this.Size = new System.Drawing.Size(243, 150);
            ((System.ComponentModel.ISupportInitialize)(this.SpEach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LlEach;
        private System.Windows.Forms.NumericUpDown SpEach;
        private System.Windows.Forms.RadioButton RbEach;
    }
}

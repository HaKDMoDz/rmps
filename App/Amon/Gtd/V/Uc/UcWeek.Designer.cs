namespace Me.Amon.Gtd.V.Uc
{
    partial class UcWeek
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
            this.LlWhen = new System.Windows.Forms.Label();
            this.SpWhen = new System.Windows.Forms.NumericUpDown();
            this.RbWhen = new System.Windows.Forms.RadioButton();
            this.LlEach = new System.Windows.Forms.Label();
            this.SpEach = new System.Windows.Forms.NumericUpDown();
            this.RbEach = new System.Windows.Forms.RadioButton();
            this.CbWhen = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.SpWhen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpEach)).BeginInit();
            this.SuspendLayout();
            // 
            // LlWhen
            // 
            this.LlWhen.AutoSize = true;
            this.LlWhen.Location = new System.Drawing.Point(117, 34);
            this.LlWhen.Name = "LlWhen";
            this.LlWhen.Size = new System.Drawing.Size(29, 12);
            this.LlWhen.TabIndex = 23;
            this.LlWhen.Text = "周的";
            // 
            // SpWhen
            // 
            this.SpWhen.Location = new System.Drawing.Point(56, 30);
            this.SpWhen.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.SpWhen.Name = "SpWhen";
            this.SpWhen.Size = new System.Drawing.Size(55, 21);
            this.SpWhen.TabIndex = 22;
            // 
            // RbWhen
            // 
            this.RbWhen.AutoSize = true;
            this.RbWhen.Location = new System.Drawing.Point(3, 32);
            this.RbWhen.Name = "RbWhen";
            this.RbWhen.Size = new System.Drawing.Size(47, 16);
            this.RbWhen.TabIndex = 21;
            this.RbWhen.TabStop = true;
            this.RbWhen.Text = "每月";
            this.RbWhen.UseVisualStyleBackColor = true;
            this.RbWhen.CheckedChanged += new System.EventHandler(this.RbWhen_CheckedChanged);
            // 
            // LlEach
            // 
            this.LlEach.AutoSize = true;
            this.LlEach.Location = new System.Drawing.Point(117, 7);
            this.LlEach.Name = "LlEach";
            this.LlEach.Size = new System.Drawing.Size(17, 12);
            this.LlEach.TabIndex = 20;
            this.LlEach.Text = "周";
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
            this.RbEach.CheckedChanged += new System.EventHandler(this.RbEach_CheckedChanged);
            // 
            // CbWhen
            // 
            this.CbWhen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbWhen.FormattingEnabled = true;
            this.CbWhen.Location = new System.Drawing.Point(152, 31);
            this.CbWhen.Name = "CbWhen";
            this.CbWhen.Size = new System.Drawing.Size(78, 20);
            this.CbWhen.TabIndex = 24;
            // 
            // UcWeek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CbWhen);
            this.Controls.Add(this.LlWhen);
            this.Controls.Add(this.SpWhen);
            this.Controls.Add(this.RbWhen);
            this.Controls.Add(this.LlEach);
            this.Controls.Add(this.SpEach);
            this.Controls.Add(this.RbEach);
            this.Name = "UcWeek";
            this.Size = new System.Drawing.Size(251, 150);
            ((System.ComponentModel.ISupportInitialize)(this.SpWhen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpEach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LlWhen;
        private System.Windows.Forms.NumericUpDown SpWhen;
        private System.Windows.Forms.RadioButton RbWhen;
        private System.Windows.Forms.Label LlEach;
        private System.Windows.Forms.NumericUpDown SpEach;
        private System.Windows.Forms.RadioButton RbEach;
        private System.Windows.Forms.ComboBox CbWhen;
    }
}

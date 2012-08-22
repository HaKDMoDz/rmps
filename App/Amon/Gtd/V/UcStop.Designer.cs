namespace Me.Amon.Gtd.V
{
    partial class UcStop
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
            this.RbNone = new System.Windows.Forms.RadioButton();
            this.RbLoop = new System.Windows.Forms.RadioButton();
            this.SpLoop = new System.Windows.Forms.NumericUpDown();
            this.LlLoop = new System.Windows.Forms.Label();
            this.RbTime = new System.Windows.Forms.RadioButton();
            this.DtTime = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.SpLoop)).BeginInit();
            this.SuspendLayout();
            // 
            // RbNone
            // 
            this.RbNone.AutoSize = true;
            this.RbNone.Location = new System.Drawing.Point(3, 3);
            this.RbNone.Name = "RbNone";
            this.RbNone.Size = new System.Drawing.Size(71, 16);
            this.RbNone.TabIndex = 0;
            this.RbNone.TabStop = true;
            this.RbNone.Text = "永不结束";
            this.RbNone.UseVisualStyleBackColor = true;
            this.RbNone.CheckedChanged += new System.EventHandler(this.RbNone_CheckedChanged);
            // 
            // RbLoop
            // 
            this.RbLoop.AutoSize = true;
            this.RbLoop.Location = new System.Drawing.Point(3, 28);
            this.RbLoop.Name = "RbLoop";
            this.RbLoop.Size = new System.Drawing.Size(47, 16);
            this.RbLoop.TabIndex = 1;
            this.RbLoop.TabStop = true;
            this.RbLoop.Text = "重复";
            this.RbLoop.UseVisualStyleBackColor = true;
            this.RbLoop.CheckedChanged += new System.EventHandler(this.RbLoop_CheckedChanged);
            // 
            // SpLoop
            // 
            this.SpLoop.Location = new System.Drawing.Point(56, 25);
            this.SpLoop.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.SpLoop.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpLoop.Name = "SpLoop";
            this.SpLoop.Size = new System.Drawing.Size(56, 21);
            this.SpLoop.TabIndex = 2;
            this.SpLoop.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // LlLoop
            // 
            this.LlLoop.AutoSize = true;
            this.LlLoop.Location = new System.Drawing.Point(118, 30);
            this.LlLoop.Name = "LlLoop";
            this.LlLoop.Size = new System.Drawing.Size(53, 12);
            this.LlLoop.TabIndex = 3;
            this.LlLoop.Text = "次后结束";
            // 
            // RbTime
            // 
            this.RbTime.AutoSize = true;
            this.RbTime.Location = new System.Drawing.Point(3, 54);
            this.RbTime.Name = "RbTime";
            this.RbTime.Size = new System.Drawing.Size(71, 16);
            this.RbTime.TabIndex = 4;
            this.RbTime.TabStop = true;
            this.RbTime.Text = "结束时间";
            this.RbTime.UseVisualStyleBackColor = true;
            this.RbTime.CheckedChanged += new System.EventHandler(this.RbTime_CheckedChanged);
            // 
            // DtTime
            // 
            this.DtTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtTime.Location = new System.Drawing.Point(80, 52);
            this.DtTime.Name = "DtTime";
            this.DtTime.Size = new System.Drawing.Size(161, 21);
            this.DtTime.TabIndex = 5;
            // 
            // UcStop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DtTime);
            this.Controls.Add(this.RbTime);
            this.Controls.Add(this.LlLoop);
            this.Controls.Add(this.SpLoop);
            this.Controls.Add(this.RbLoop);
            this.Controls.Add(this.RbNone);
            this.Name = "UcStop";
            this.Size = new System.Drawing.Size(304, 80);
            ((System.ComponentModel.ISupportInitialize)(this.SpLoop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RbNone;
        private System.Windows.Forms.RadioButton RbLoop;
        private System.Windows.Forms.NumericUpDown SpLoop;
        private System.Windows.Forms.Label LlLoop;
        private System.Windows.Forms.RadioButton RbTime;
        private System.Windows.Forms.DateTimePicker DtTime;
    }
}

namespace Me.Amon.Gtd.V
{
    partial class UtDates
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
            this.LlStart = new System.Windows.Forms.Label();
            this.DtStart = new System.Windows.Forms.DateTimePicker();
            this.CbRedoUnit = new System.Windows.Forms.ComboBox();
            this.LbRedoUnit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LlStart
            // 
            this.LlStart.AutoSize = true;
            this.LlStart.Location = new System.Drawing.Point(3, 6);
            this.LlStart.Name = "LlStart";
            this.LlStart.Size = new System.Drawing.Size(71, 12);
            this.LlStart.TabIndex = 0;
            this.LlStart.Text = "提醒时间(&T)";
            // 
            // DtStart
            // 
            this.DtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtStart.Location = new System.Drawing.Point(80, 3);
            this.DtStart.Name = "DtStart";
            this.DtStart.Size = new System.Drawing.Size(161, 21);
            this.DtStart.TabIndex = 1;
            // 
            // CbRedoUnit
            // 
            this.CbRedoUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbRedoUnit.FormattingEnabled = true;
            this.CbRedoUnit.Location = new System.Drawing.Point(80, 30);
            this.CbRedoUnit.Name = "CbRedoUnit";
            this.CbRedoUnit.Size = new System.Drawing.Size(81, 20);
            this.CbRedoUnit.TabIndex = 3;
            this.CbRedoUnit.SelectedIndexChanged += new System.EventHandler(this.CbRedoUnit_SelectedIndexChanged);
            // 
            // LbRedoUnit
            // 
            this.LbRedoUnit.AutoSize = true;
            this.LbRedoUnit.Location = new System.Drawing.Point(3, 33);
            this.LbRedoUnit.Name = "LbRedoUnit";
            this.LbRedoUnit.Size = new System.Drawing.Size(71, 12);
            this.LbRedoUnit.TabIndex = 2;
            this.LbRedoUnit.Text = "提醒周期(&U)";
            // 
            // UtDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CbRedoUnit);
            this.Controls.Add(this.LbRedoUnit);
            this.Controls.Add(this.DtStart);
            this.Controls.Add(this.LlStart);
            this.Name = "UtDates";
            this.Size = new System.Drawing.Size(304, 160);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LlStart;
        private System.Windows.Forms.DateTimePicker DtStart;
        private System.Windows.Forms.ComboBox CbRedoUnit;
        private System.Windows.Forms.Label LbRedoUnit;
    }
}

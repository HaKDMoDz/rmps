namespace Me.Amon.Gtd.V
{
    partial class Interval
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
            this.LlDate = new System.Windows.Forms.Label();
            this.DtDate = new System.Windows.Forms.DateTimePicker();
            this.LlData = new System.Windows.Forms.Label();
            this.SpData = new System.Windows.Forms.NumericUpDown();
            this.CbUnit = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.SpData)).BeginInit();
            this.SuspendLayout();
            // 
            // LlDate
            // 
            this.LlDate.AutoSize = true;
            this.LlDate.Location = new System.Drawing.Point(3, 9);
            this.LlDate.Name = "LlDate";
            this.LlDate.Size = new System.Drawing.Size(71, 12);
            this.LlDate.TabIndex = 0;
            this.LlDate.Text = "起始时间(&T)";
            // 
            // DtDate
            // 
            this.DtDate.Location = new System.Drawing.Point(80, 3);
            this.DtDate.Name = "DtDate";
            this.DtDate.Size = new System.Drawing.Size(121, 21);
            this.DtDate.TabIndex = 1;
            // 
            // LlData
            // 
            this.LlData.AutoSize = true;
            this.LlData.Location = new System.Drawing.Point(3, 35);
            this.LlData.Name = "LlData";
            this.LlData.Size = new System.Drawing.Size(47, 12);
            this.LlData.TabIndex = 2;
            this.LlData.Text = "每隔(&I)";
            // 
            // SpData
            // 
            this.SpData.Location = new System.Drawing.Point(80, 30);
            this.SpData.Name = "SpData";
            this.SpData.Size = new System.Drawing.Size(62, 21);
            this.SpData.TabIndex = 3;
            // 
            // CbUnit
            // 
            this.CbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbUnit.FormattingEnabled = true;
            this.CbUnit.Location = new System.Drawing.Point(148, 31);
            this.CbUnit.Name = "CbUnit";
            this.CbUnit.Size = new System.Drawing.Size(74, 20);
            this.CbUnit.TabIndex = 4;
            // 
            // Interval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CbUnit);
            this.Controls.Add(this.SpData);
            this.Controls.Add(this.LlData);
            this.Controls.Add(this.DtDate);
            this.Controls.Add(this.LlDate);
            this.Name = "Interval";
            this.Size = new System.Drawing.Size(373, 242);
            ((System.ComponentModel.ISupportInitialize)(this.SpData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LlDate;
        private System.Windows.Forms.DateTimePicker DtDate;
        private System.Windows.Forms.Label LlData;
        private System.Windows.Forms.NumericUpDown SpData;
        private System.Windows.Forms.ComboBox CbUnit;

    }
}

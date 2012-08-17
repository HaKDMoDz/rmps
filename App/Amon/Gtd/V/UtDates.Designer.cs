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
            this.LlMajorUnit = new System.Windows.Forms.Label();
            this.CbMajorUnit = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // LlMajorUnit
            // 
            this.LlMajorUnit.AutoSize = true;
            this.LlMajorUnit.Location = new System.Drawing.Point(3, 6);
            this.LlMajorUnit.Name = "LlMajorUnit";
            this.LlMajorUnit.Size = new System.Drawing.Size(47, 12);
            this.LlMajorUnit.TabIndex = 0;
            this.LlMajorUnit.Text = "单位(&U)";
            // 
            // CbMajorUnit
            // 
            this.CbMajorUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbMajorUnit.FormattingEnabled = true;
            this.CbMajorUnit.Location = new System.Drawing.Point(56, 3);
            this.CbMajorUnit.Name = "CbMajorUnit";
            this.CbMajorUnit.Size = new System.Drawing.Size(121, 20);
            this.CbMajorUnit.TabIndex = 1;
            this.CbMajorUnit.SelectedIndexChanged += new System.EventHandler(this.CbMajorUnit_SelectedIndexChanged);
            // 
            // UtDates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CbMajorUnit);
            this.Controls.Add(this.LlMajorUnit);
            this.Name = "UtDates";
            this.Size = new System.Drawing.Size(283, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LlMajorUnit;
        private System.Windows.Forms.ComboBox CbMajorUnit;
    }
}

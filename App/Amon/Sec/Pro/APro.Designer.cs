namespace Me.Amon.Sec.Pro
{
    partial class APro
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
            this.CbKey = new System.Windows.Forms.ComboBox();
            this.CbOpt = new System.Windows.Forms.ComboBox();
            this.LbOpt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CbKey
            // 
            this.CbKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbKey.FormattingEnabled = true;
            this.CbKey.Location = new System.Drawing.Point(153, 3);
            this.CbKey.Name = "CbKey";
            this.CbKey.Size = new System.Drawing.Size(81, 20);
            this.CbKey.TabIndex = 5;
            // 
            // CbOpt
            // 
            this.CbOpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbOpt.FormattingEnabled = true;
            this.CbOpt.Location = new System.Drawing.Point(56, 3);
            this.CbOpt.Name = "CbOpt";
            this.CbOpt.Size = new System.Drawing.Size(91, 20);
            this.CbOpt.TabIndex = 4;
            // 
            // LbOpt
            // 
            this.LbOpt.AutoSize = true;
            this.LbOpt.Location = new System.Drawing.Point(3, 6);
            this.LbOpt.Name = "LbOpt";
            this.LbOpt.Size = new System.Drawing.Size(47, 12);
            this.LbOpt.TabIndex = 3;
            this.LbOpt.Text = "操作(&T)";
            // 
            // APro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CbKey);
            this.Controls.Add(this.CbOpt);
            this.Controls.Add(this.LbOpt);
            this.Name = "APro";
            this.Size = new System.Drawing.Size(516, 333);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CbKey;
        private System.Windows.Forms.ComboBox CbOpt;
        private System.Windows.Forms.Label LbOpt;
    }
}

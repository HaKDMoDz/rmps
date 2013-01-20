namespace Me.Amon.Gtd.V
{
    partial class UtMaths
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
            this.LlMaths = new System.Windows.Forms.Label();
            this.TbMaths = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LlMaths
            // 
            this.LlMaths.AutoSize = true;
            this.LlMaths.Location = new System.Drawing.Point(3, 6);
            this.LlMaths.Name = "LlMaths";
            this.LlMaths.Size = new System.Drawing.Size(29, 12);
            this.LlMaths.TabIndex = 0;
            this.LlMaths.Text = "公式";
            // 
            // TbMaths
            // 
            this.TbMaths.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbMaths.Location = new System.Drawing.Point(38, 3);
            this.TbMaths.Name = "TbMaths";
            this.TbMaths.Size = new System.Drawing.Size(263, 21);
            this.TbMaths.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Multiline = true;
            this.label2.Name = "label2";
            this.label2.ReadOnly = true;
            this.label2.Size = new System.Drawing.Size(298, 130);
            this.label2.TabIndex = 2;
            this.label2.TabStop = false;
            // 
            // UtMaths
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TbMaths);
            this.Controls.Add(this.LlMaths);
            this.Name = "UtMaths";
            this.Size = new System.Drawing.Size(304, 160);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LlMaths;
        private System.Windows.Forms.TextBox TbMaths;
        private System.Windows.Forms.TextBox label2;
    }
}

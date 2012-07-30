namespace Me.Amon.Sec.V.Pro.Uw
{
    partial class Text
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TbText = new System.Windows.Forms.TextBox();
            this.BtOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TbText
            // 
            this.TbText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbText.Location = new System.Drawing.Point(12, 12);
            this.TbText.Multiline = true;
            this.TbText.Name = "TbText";
            this.TbText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbText.Size = new System.Drawing.Size(260, 111);
            this.TbText.TabIndex = 0;
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtOk.Location = new System.Drawing.Point(197, 129);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 1;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // Text
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtOk;
            this.ClientSize = new System.Drawing.Size(284, 164);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.TbText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Text";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "文本";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbText;
        private System.Windows.Forms.Button BtOk;
    }
}
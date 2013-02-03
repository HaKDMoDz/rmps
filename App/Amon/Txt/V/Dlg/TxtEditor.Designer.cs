namespace Me.Amon.Txt.V.Dlg
{
    partial class TxtEditor
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
            this.TbTxt = new System.Windows.Forms.TextBox();
            this.CkWrap = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // TbTxt
            // 
            this.TbTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbTxt.Location = new System.Drawing.Point(12, 12);
            this.TbTxt.Multiline = true;
            this.TbTxt.Name = "TbTxt";
            this.TbTxt.Size = new System.Drawing.Size(360, 216);
            this.TbTxt.TabIndex = 0;
            // 
            // CkWrap
            // 
            this.CkWrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CkWrap.AutoSize = true;
            this.CkWrap.Location = new System.Drawing.Point(12, 234);
            this.CkWrap.Name = "CkWrap";
            this.CkWrap.Size = new System.Drawing.Size(90, 16);
            this.CkWrap.TabIndex = 1;
            this.CkWrap.Text = "自动换行(&W)";
            this.CkWrap.UseVisualStyleBackColor = true;
            this.CkWrap.CheckedChanged += new System.EventHandler(this.CkWrap_CheckedChanged);
            // 
            // TxtEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.CkWrap);
            this.Controls.Add(this.TbTxt);
            this.Name = "TxtEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文本查看器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbTxt;
        private System.Windows.Forms.CheckBox CkWrap;
    }
}
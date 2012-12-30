namespace Me.Amon.Uc
{
    partial class GtdHint
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
            this.PlHint = new System.Windows.Forms.Panel();
            this.PbHide = new System.Windows.Forms.PictureBox();
            this.TbTips = new System.Windows.Forms.TextBox();
            this.PlHint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbHide)).BeginInit();
            this.SuspendLayout();
            // 
            // PlHint
            // 
            this.PlHint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PlHint.BackgroundImage = global::Me.Amon.Properties.Resources.Tips;
            this.PlHint.Controls.Add(this.PbHide);
            this.PlHint.Controls.Add(this.TbTips);
            this.PlHint.Location = new System.Drawing.Point(15, 46);
            this.PlHint.Name = "PlHint";
            this.PlHint.Size = new System.Drawing.Size(270, 208);
            this.PlHint.TabIndex = 0;
            // 
            // PbHide
            // 
            this.PbHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbHide.Image = global::Me.Amon.Properties.Resources.OK;
            this.PbHide.Location = new System.Drawing.Point(180, 170);
            this.PbHide.Name = "PbHide";
            this.PbHide.Size = new System.Drawing.Size(64, 23);
            this.PbHide.TabIndex = 2;
            this.PbHide.TabStop = false;
            this.PbHide.Click += new System.EventHandler(this.PbHide_Click);
            // 
            // TbTips
            // 
            this.TbTips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbTips.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TbTips.Location = new System.Drawing.Point(26, 79);
            this.TbTips.Multiline = true;
            this.TbTips.Name = "TbTips";
            this.TbTips.ReadOnly = true;
            this.TbTips.Size = new System.Drawing.Size(218, 85);
            this.TbTips.TabIndex = 1;
            this.TbTips.TabStop = false;
            // 
            // GtdHint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.PlHint);
            this.Name = "GtdHint";
            this.Size = new System.Drawing.Size(300, 300);
            this.PlHint.ResumeLayout(false);
            this.PlHint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbHide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlHint;
        private System.Windows.Forms.TextBox TbTips;
        private System.Windows.Forms.PictureBox PbHide;
    }
}

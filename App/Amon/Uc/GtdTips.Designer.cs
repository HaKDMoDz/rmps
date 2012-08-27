namespace Me.Amon.Uc
{
    partial class GtdTips
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
            this.TbTips = new System.Windows.Forms.TextBox();
            this.PbHide = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbHide)).BeginInit();
            this.SuspendLayout();
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
            this.TbTips.TabIndex = 0;
            this.TbTips.TabStop = false;
            // 
            // PbHide
            // 
            this.PbHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbHide.Image = global::Me.Amon.Properties.Resources.OK;
            this.PbHide.Location = new System.Drawing.Point(180, 170);
            this.PbHide.Name = "PbHide";
            this.PbHide.Size = new System.Drawing.Size(64, 23);
            this.PbHide.TabIndex = 1;
            this.PbHide.TabStop = false;
            this.PbHide.Click += new System.EventHandler(this.PbHide_Click);
            // 
            // GtdTips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Me.Amon.Properties.Resources.Tips;
            this.Controls.Add(this.TbTips);
            this.Controls.Add(this.PbHide);
            this.Name = "GtdTips";
            this.Size = new System.Drawing.Size(270, 208);
            ((System.ComponentModel.ISupportInitialize)(this.PbHide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbTips;
        private System.Windows.Forms.PictureBox PbHide;
    }
}

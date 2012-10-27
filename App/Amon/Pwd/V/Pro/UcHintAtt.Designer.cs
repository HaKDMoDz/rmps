namespace Me.Amon.Pwd.V.Pro
{
    partial class UcHintAtt
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
            this.LbText = new System.Windows.Forms.Label();
            this.PbHint = new System.Windows.Forms.PictureBox();
            this.LbData = new System.Windows.Forms.Label();
            this.TbData = new System.Windows.Forms.TextBox();
            this.LlHint = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbHint)).BeginInit();
            this.SuspendLayout();
            // 
            // LbText
            // 
            this.LbText.AutoSize = true;
            this.LbText.Location = new System.Drawing.Point(3, 6);
            this.LbText.Name = "LbText";
            this.LbText.Size = new System.Drawing.Size(47, 12);
            this.LbText.TabIndex = 0;
            this.LbText.Text = "计划(&N)";
            // 
            // PbHint
            // 
            this.PbHint.BackColor = System.Drawing.SystemColors.Window;
            this.PbHint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbHint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbHint.Location = new System.Drawing.Point(56, 3);
            this.PbHint.Name = "PbHint";
            this.PbHint.Size = new System.Drawing.Size(18, 18);
            this.PbHint.TabIndex = 1;
            this.PbHint.TabStop = false;
            this.PbHint.Click += new System.EventHandler(this.BtName_Click);
            // 
            // LbData
            // 
            this.LbData.AutoSize = true;
            this.LbData.Location = new System.Drawing.Point(3, 33);
            this.LbData.Name = "LbData";
            this.LbData.Size = new System.Drawing.Size(47, 12);
            this.LbData.TabIndex = 2;
            this.LbData.Text = "说明(&D)";
            // 
            // TbData
            // 
            this.TbData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbData.Location = new System.Drawing.Point(56, 30);
            this.TbData.Multiline = true;
            this.TbData.Name = "TbData";
            this.TbData.Size = new System.Drawing.Size(307, 48);
            this.TbData.TabIndex = 3;
            // 
            // LlHint
            // 
            this.LlHint.AutoSize = true;
            this.LlHint.Location = new System.Drawing.Point(80, 6);
            this.LlHint.Name = "LlHint";
            this.LlHint.Size = new System.Drawing.Size(53, 12);
            this.LlHint.TabIndex = 4;
            this.LlHint.Text = "<无提醒>";
            // 
            // BeanHint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LlHint);
            this.Controls.Add(this.TbData);
            this.Controls.Add(this.LbData);
            this.Controls.Add(this.PbHint);
            this.Controls.Add(this.LbText);
            this.Name = "BeanHint";
            this.Size = new System.Drawing.Size(366, 81);
            ((System.ComponentModel.ISupportInitialize)(this.PbHint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbText;
        private System.Windows.Forms.PictureBox PbHint;
        private System.Windows.Forms.Label LbData;
        private System.Windows.Forms.TextBox TbData;
        private System.Windows.Forms.Label LlHint;
    }
}

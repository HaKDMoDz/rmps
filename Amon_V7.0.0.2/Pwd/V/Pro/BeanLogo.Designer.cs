namespace Me.Amon.Pwd.V.Pro
{
    partial class BeanLogo
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
            this.TbData = new System.Windows.Forms.TextBox();
            this.LbData = new System.Windows.Forms.Label();
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.LbText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // TbData
            // 
            this.TbData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbData.Location = new System.Drawing.Point(56, 30);
            this.TbData.Multiline = true;
            this.TbData.Name = "TbData";
            this.TbData.Size = new System.Drawing.Size(309, 50);
            this.TbData.TabIndex = 3;
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
            // PbLogo
            // 
            this.PbLogo.BackColor = System.Drawing.SystemColors.Window;
            this.PbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbLogo.Location = new System.Drawing.Point(56, 4);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(18, 18);
            this.PbLogo.TabIndex = 1;
            this.PbLogo.TabStop = false;
            this.PbLogo.Click += new System.EventHandler(this.PbName_Click);
            // 
            // LbText
            // 
            this.LbText.AutoSize = true;
            this.LbText.Location = new System.Drawing.Point(3, 7);
            this.LbText.Name = "LbText";
            this.LbText.Size = new System.Drawing.Size(47, 12);
            this.LbText.TabIndex = 0;
            this.LbText.Text = "徽标(&N)";
            // 
            // BeanLogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbData);
            this.Controls.Add(this.LbData);
            this.Controls.Add(this.PbLogo);
            this.Controls.Add(this.LbText);
            this.Name = "BeanLogo";
            this.Size = new System.Drawing.Size(366, 81);
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbData;
        private System.Windows.Forms.Label LbData;
        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.Label LbText;
    }
}

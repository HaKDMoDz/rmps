namespace Me.Amon.Pwd.Pro
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
            this.PbName = new System.Windows.Forms.PictureBox();
            this.LbName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbName)).BeginInit();
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
            // PbName
            // 
            this.PbName.BackColor = System.Drawing.SystemColors.Window;
            this.PbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbName.Location = new System.Drawing.Point(56, 3);
            this.PbName.Name = "PbName";
            this.PbName.Size = new System.Drawing.Size(21, 21);
            this.PbName.TabIndex = 1;
            this.PbName.TabStop = false;
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(3, 7);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(47, 12);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "徽标(&N)";
            // 
            // BeanLogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbData);
            this.Controls.Add(this.LbData);
            this.Controls.Add(this.PbName);
            this.Controls.Add(this.LbName);
            this.Name = "BeanLogo";
            this.Size = new System.Drawing.Size(366, 81);
            ((System.ComponentModel.ISupportInitialize)(this.PbName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbData;
        private System.Windows.Forms.Label LbData;
        private System.Windows.Forms.PictureBox PbName;
        private System.Windows.Forms.Label LbName;
    }
}

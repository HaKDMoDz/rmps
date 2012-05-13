namespace Me.Amon.Pwd.V.Pro
{
    partial class BeanCall
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
            this.BtOpt = new System.Windows.Forms.Button();
            this.TbData = new System.Windows.Forms.TextBox();
            this.LbData = new System.Windows.Forms.Label();
            this.TbText = new System.Windows.Forms.TextBox();
            this.LbText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtOpt
            // 
            this.BtOpt.Location = new System.Drawing.Point(56, 57);
            this.BtOpt.Name = "BtOpt";
            this.BtOpt.Size = new System.Drawing.Size(21, 21);
            this.BtOpt.TabIndex = 10;
            this.BtOpt.UseVisualStyleBackColor = true;
            this.BtOpt.Click += new System.EventHandler(this.BtOpt_Click);
            // 
            // TbData
            // 
            this.TbData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbData.Location = new System.Drawing.Point(56, 30);
            this.TbData.Name = "TbData";
            this.TbData.Size = new System.Drawing.Size(307, 21);
            this.TbData.TabIndex = 9;
            // 
            // LbData
            // 
            this.LbData.AutoSize = true;
            this.LbData.Location = new System.Drawing.Point(3, 33);
            this.LbData.Name = "LbData";
            this.LbData.Size = new System.Drawing.Size(47, 12);
            this.LbData.TabIndex = 8;
            this.LbData.Text = "数据(&D)";
            // 
            // TbText
            // 
            this.TbText.Location = new System.Drawing.Point(56, 3);
            this.TbText.Name = "TbText";
            this.TbText.Size = new System.Drawing.Size(100, 21);
            this.TbText.TabIndex = 7;
            // 
            // LbText
            // 
            this.LbText.AutoSize = true;
            this.LbText.Location = new System.Drawing.Point(3, 6);
            this.LbText.Name = "LbText";
            this.LbText.Size = new System.Drawing.Size(47, 12);
            this.LbText.TabIndex = 6;
            this.LbText.Text = "名称(&N)";
            // 
            // BeanCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtOpt);
            this.Controls.Add(this.TbData);
            this.Controls.Add(this.LbData);
            this.Controls.Add(this.TbText);
            this.Controls.Add(this.LbText);
            this.Name = "BeanCall";
            this.Size = new System.Drawing.Size(366, 81);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtOpt;
        private System.Windows.Forms.TextBox TbData;
        private System.Windows.Forms.Label LbData;
        private System.Windows.Forms.TextBox TbText;
        private System.Windows.Forms.Label LbText;
    }
}

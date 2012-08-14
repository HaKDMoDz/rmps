namespace Me.Amon.Pwd.V.Pro
{
    partial class BeanHint
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
            this.BtHint = new System.Windows.Forms.Button();
            this.LbData = new System.Windows.Forms.Label();
            this.TbData = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LbText
            // 
            this.LbText.AutoSize = true;
            this.LbText.Location = new System.Drawing.Point(3, 7);
            this.LbText.Name = "LbText";
            this.LbText.Size = new System.Drawing.Size(47, 12);
            this.LbText.TabIndex = 0;
            this.LbText.Text = "计划(&N)";
            // 
            // BtHint
            // 
            this.BtHint.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtHint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtHint.Location = new System.Drawing.Point(56, 3);
            this.BtHint.Name = "BtHint";
            this.BtHint.Size = new System.Drawing.Size(21, 21);
            this.BtHint.TabIndex = 1;
            this.BtHint.UseVisualStyleBackColor = true;
            this.BtHint.Click += new System.EventHandler(this.BtName_Click);
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
            // BeanHint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbData);
            this.Controls.Add(this.LbData);
            this.Controls.Add(this.BtHint);
            this.Controls.Add(this.LbText);
            this.Name = "BeanHint";
            this.Size = new System.Drawing.Size(366, 81);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbText;
        private System.Windows.Forms.Button BtHint;
        private System.Windows.Forms.Label LbData;
        private System.Windows.Forms.TextBox TbData;
    }
}

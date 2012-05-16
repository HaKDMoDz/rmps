namespace Me.Amon.Pwd.Bean
{
    partial class FindBar
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
            this.LbFind = new System.Windows.Forms.Label();
            this.TbFind = new System.Windows.Forms.TextBox();
            this.BtFind = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbFind
            // 
            this.LbFind.AutoSize = true;
            this.LbFind.Location = new System.Drawing.Point(3, 9);
            this.LbFind.Name = "LbFind";
            this.LbFind.Size = new System.Drawing.Size(47, 12);
            this.LbFind.TabIndex = 0;
            this.LbFind.Text = "查找(&F)";
            // 
            // TbFind
            // 
            this.TbFind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbFind.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TbFind.Location = new System.Drawing.Point(56, 3);
            this.TbFind.Name = "TbFind";
            this.TbFind.Size = new System.Drawing.Size(222, 23);
            this.TbFind.TabIndex = 1;
            this.TbFind.TextChanged += new System.EventHandler(this.TbFind_TextChanged);
            // 
            // BtFind
            // 
            this.BtFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtFind.Location = new System.Drawing.Point(284, 3);
            this.BtFind.Name = "BtFind";
            this.BtFind.Size = new System.Drawing.Size(75, 23);
            this.BtFind.TabIndex = 2;
            this.BtFind.Text = "查询(&Q)";
            this.BtFind.UseVisualStyleBackColor = true;
            this.BtFind.Click += new System.EventHandler(this.BtFind_Click);
            // 
            // FindBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtFind);
            this.Controls.Add(this.TbFind);
            this.Controls.Add(this.LbFind);
            this.Name = "FindBar";
            this.Size = new System.Drawing.Size(362, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbFind;
        private System.Windows.Forms.TextBox TbFind;
        private System.Windows.Forms.Button BtFind;
    }
}

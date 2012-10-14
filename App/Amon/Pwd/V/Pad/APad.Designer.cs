namespace Me.Amon.Pwd.V.Pad
{
    partial class APad
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
            this.findBar1 = new Me.Amon.Pwd.V.FindBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BtFill = new System.Windows.Forms.Button();
            this.LbKey = new System.Windows.Forms.ListBox();
            this.TbKey = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // findBar1
            // 
            this.findBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.findBar1.APwd = null;
            this.findBar1.Location = new System.Drawing.Point(3, 3);
            this.findBar1.Name = "findBar1";
            this.findBar1.Size = new System.Drawing.Size(294, 29);
            this.findBar1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 38);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LbKey);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TbKey);
            this.splitContainer1.Size = new System.Drawing.Size(294, 250);
            this.splitContainer1.SplitterDistance = 125;
            this.splitContainer1.TabIndex = 1;
            // 
            // BtFill
            // 
            this.BtFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtFill.Location = new System.Drawing.Point(222, 294);
            this.BtFill.Name = "BtFill";
            this.BtFill.Size = new System.Drawing.Size(75, 23);
            this.BtFill.TabIndex = 2;
            this.BtFill.Text = "填充(&F)";
            this.BtFill.UseVisualStyleBackColor = true;
            // 
            // LbKey
            // 
            this.LbKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbKey.FormattingEnabled = true;
            this.LbKey.IntegralHeight = false;
            this.LbKey.ItemHeight = 12;
            this.LbKey.Location = new System.Drawing.Point(0, 0);
            this.LbKey.Name = "LbKey";
            this.LbKey.Size = new System.Drawing.Size(294, 125);
            this.LbKey.TabIndex = 0;
            // 
            // TbKey
            // 
            this.TbKey.BackColor = System.Drawing.SystemColors.Window;
            this.TbKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbKey.Location = new System.Drawing.Point(0, 0);
            this.TbKey.Multiline = true;
            this.TbKey.Name = "TbKey";
            this.TbKey.ReadOnly = true;
            this.TbKey.Size = new System.Drawing.Size(294, 121);
            this.TbKey.TabIndex = 0;
            // 
            // APad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtFill);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.findBar1);
            this.Name = "APad";
            this.Size = new System.Drawing.Size(300, 320);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private V.FindBar findBar1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button BtFill;
        private System.Windows.Forms.ListBox LbKey;
        private System.Windows.Forms.TextBox TbKey;

    }
}

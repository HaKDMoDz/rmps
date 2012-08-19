namespace Me.Amon.Gtd.V
{
    partial class UhApps
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
            this.LlPath = new System.Windows.Forms.Label();
            this.TbPath = new System.Windows.Forms.TextBox();
            this.BtPath = new System.Windows.Forms.Button();
            this.TbArgs = new System.Windows.Forms.TextBox();
            this.LbArgs = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LlPath
            // 
            this.LlPath.AutoSize = true;
            this.LlPath.Location = new System.Drawing.Point(3, 6);
            this.LlPath.Name = "LlPath";
            this.LlPath.Size = new System.Drawing.Size(29, 12);
            this.LlPath.TabIndex = 0;
            this.LlPath.Text = "路径";
            // 
            // TbPath
            // 
            this.TbPath.Location = new System.Drawing.Point(38, 3);
            this.TbPath.Name = "TbPath";
            this.TbPath.Size = new System.Drawing.Size(151, 21);
            this.TbPath.TabIndex = 1;
            // 
            // BtPath
            // 
            this.BtPath.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtPath.Location = new System.Drawing.Point(195, 3);
            this.BtPath.Margin = new System.Windows.Forms.Padding(0);
            this.BtPath.Name = "BtPath";
            this.BtPath.Size = new System.Drawing.Size(21, 21);
            this.BtPath.TabIndex = 2;
            this.BtPath.Text = "..";
            this.BtPath.UseVisualStyleBackColor = true;
            this.BtPath.Click += new System.EventHandler(this.BtPath_Click);
            // 
            // TbArgs
            // 
            this.TbArgs.Location = new System.Drawing.Point(38, 30);
            this.TbArgs.Name = "TbArgs";
            this.TbArgs.Size = new System.Drawing.Size(178, 21);
            this.TbArgs.TabIndex = 4;
            // 
            // LbArgs
            // 
            this.LbArgs.AutoSize = true;
            this.LbArgs.Location = new System.Drawing.Point(3, 33);
            this.LbArgs.Name = "LbArgs";
            this.LbArgs.Size = new System.Drawing.Size(29, 12);
            this.LbArgs.TabIndex = 3;
            this.LbArgs.Text = "参数";
            // 
            // UhApps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbArgs);
            this.Controls.Add(this.LbArgs);
            this.Controls.Add(this.BtPath);
            this.Controls.Add(this.TbPath);
            this.Controls.Add(this.LlPath);
            this.Name = "UhApps";
            this.Size = new System.Drawing.Size(219, 74);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LlPath;
        private System.Windows.Forms.TextBox TbPath;
        private System.Windows.Forms.Button BtPath;
        private System.Windows.Forms.TextBox TbArgs;
        private System.Windows.Forms.Label LbArgs;
    }
}

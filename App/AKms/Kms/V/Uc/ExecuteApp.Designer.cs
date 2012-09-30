namespace Me.Amon.Kms.V.Uc
{
    partial class ExecuteApp
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
            this.components = new System.ComponentModel.Container();
            this.LbPath = new System.Windows.Forms.Label();
            this.TbPath = new System.Windows.Forms.TextBox();
            this.PbPath = new System.Windows.Forms.PictureBox();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.FdFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.PbPath)).BeginInit();
            this.SuspendLayout();
            // 
            // LbPath
            // 
            this.LbPath.AutoSize = true;
            this.LbPath.Location = new System.Drawing.Point(3, 7);
            this.LbPath.Name = "LbPath";
            this.LbPath.Size = new System.Drawing.Size(47, 12);
            this.LbPath.TabIndex = 0;
            this.LbPath.Text = "路径(&P)";
            // 
            // TbPath
            // 
            this.TbPath.Location = new System.Drawing.Point(56, 3);
            this.TbPath.Name = "TbPath";
            this.TbPath.Size = new System.Drawing.Size(181, 21);
            this.TbPath.TabIndex = 1;
            this.TpTips.SetToolTip(this.TbPath, "系统命令、文件或网址");
            // 
            // PbPath
            // 
            this.PbPath.Image = global::Me.Amon.Properties.Resources.open;
            this.PbPath.Location = new System.Drawing.Point(243, 5);
            this.PbPath.Name = "PbPath";
            this.PbPath.Size = new System.Drawing.Size(16, 16);
            this.PbPath.TabIndex = 2;
            this.PbPath.TabStop = false;
            this.TpTips.SetToolTip(this.PbPath, "打开文件");
            this.PbPath.Click += new System.EventHandler(this.PbPath_Click);
            // 
            // FdFile
            // 
            this.FdFile.Title = "打开";
            // 
            // ExecuteApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbPath);
            this.Controls.Add(this.TbPath);
            this.Controls.Add(this.LbPath);
            this.Name = "ExecuteApp";
            this.Size = new System.Drawing.Size(262, 27);
            ((System.ComponentModel.ISupportInitialize)(this.PbPath)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbPath;
        private System.Windows.Forms.TextBox TbPath;
        private System.Windows.Forms.PictureBox PbPath;
        private System.Windows.Forms.ToolTip TpTips;
        private System.Windows.Forms.OpenFileDialog FdFile;
    }
}

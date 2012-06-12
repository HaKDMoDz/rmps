namespace Me.Amon.Sec.V.Wiz
{
    partial class AWiz
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
            this.LbOpt = new System.Windows.Forms.Label();
            this.CbDir = new System.Windows.Forms.ComboBox();
            this.CbFun = new System.Windows.Forms.ComboBox();
            this.TpText = new System.Windows.Forms.TabPage();
            this.TpFile = new System.Windows.Forms.TabPage();
            this.TcCrypto = new System.Windows.Forms.ATabControl();
            this.UcFile = new Me.Amon.Sec.V.Wiz.AFile();
            this.UcText = new Me.Amon.Sec.V.Wiz.AText();
            this.TpText.SuspendLayout();
            this.TpFile.SuspendLayout();
            this.TcCrypto.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbOpt
            // 
            this.LbOpt.AutoSize = true;
            this.LbOpt.Location = new System.Drawing.Point(0, 3);
            this.LbOpt.Name = "LbOpt";
            this.LbOpt.Size = new System.Drawing.Size(47, 12);
            this.LbOpt.TabIndex = 0;
            this.LbOpt.Text = "操作(&T)";
            // 
            // CbDir
            // 
            this.CbDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbDir.FormattingEnabled = true;
            this.CbDir.Location = new System.Drawing.Point(53, 0);
            this.CbDir.Name = "CbDir";
            this.CbDir.Size = new System.Drawing.Size(56, 20);
            this.CbDir.TabIndex = 1;
            this.CbDir.SelectedIndexChanged += new System.EventHandler(this.CbDir_SelectedIndexChanged);
            // 
            // CbFun
            // 
            this.CbFun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbFun.FormattingEnabled = true;
            this.CbFun.Location = new System.Drawing.Point(115, 0);
            this.CbFun.Name = "CbFun";
            this.CbFun.Size = new System.Drawing.Size(61, 20);
            this.CbFun.TabIndex = 2;
            this.CbFun.SelectedIndexChanged += new System.EventHandler(this.CbFun_SelectedIndexChanged);
            // 
            // TpText
            // 
            this.TpText.Controls.Add(this.UcText);
            this.TpText.Location = new System.Drawing.Point(4, 4);
            this.TpText.Name = "TpText";
            this.TpText.Size = new System.Drawing.Size(333, 206);
            this.TpText.TabIndex = 3;
            this.TpText.Text = "文本";
            this.TpText.UseVisualStyleBackColor = true;
            // 
            // TpFile
            // 
            this.TpFile.Controls.Add(this.UcFile);
            this.TpFile.Location = new System.Drawing.Point(4, 4);
            this.TpFile.Name = "TpFile";
            this.TpFile.Size = new System.Drawing.Size(333, 206);
            this.TpFile.TabIndex = 2;
            this.TpFile.Text = "文件";
            this.TpFile.UseVisualStyleBackColor = true;
            // 
            // TcCrypto
            // 
            this.TcCrypto.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.TcCrypto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TcCrypto.Controls.Add(this.TpFile);
            this.TcCrypto.Controls.Add(this.TpText);
            // 
            // 
            // 
            this.TcCrypto.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.TcCrypto.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.TcCrypto.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.TcCrypto.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.TcCrypto.DisplayStyleProvider.FocusTrack = true;
            this.TcCrypto.DisplayStyleProvider.HotTrack = true;
            this.TcCrypto.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TcCrypto.DisplayStyleProvider.Opacity = 1F;
            this.TcCrypto.DisplayStyleProvider.Overlap = 0;
            this.TcCrypto.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
            this.TcCrypto.DisplayStyleProvider.Radius = 2;
            this.TcCrypto.DisplayStyleProvider.ShowTabCloser = false;
            this.TcCrypto.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.TcCrypto.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.TcCrypto.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.TcCrypto.HotTrack = true;
            this.TcCrypto.Location = new System.Drawing.Point(0, 26);
            this.TcCrypto.Multiline = true;
            this.TcCrypto.Name = "TcCrypto";
            this.TcCrypto.SelectedIndex = 0;
            this.TcCrypto.Size = new System.Drawing.Size(360, 214);
            this.TcCrypto.TabIndex = 3;
            // 
            // UcFile
            // 
            this.UcFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UcFile.Location = new System.Drawing.Point(0, 0);
            this.UcFile.Name = "UcFile";
            this.UcFile.Size = new System.Drawing.Size(333, 206);
            this.UcFile.TabIndex = 0;
            // 
            // UcText
            // 
            this.UcText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UcText.Location = new System.Drawing.Point(0, 0);
            this.UcText.Name = "UcText";
            this.UcText.Size = new System.Drawing.Size(333, 206);
            this.UcText.TabIndex = 0;
            // 
            // AWiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TcCrypto);
            this.Controls.Add(this.CbFun);
            this.Controls.Add(this.CbDir);
            this.Controls.Add(this.LbOpt);
            this.Name = "AWiz";
            this.Size = new System.Drawing.Size(360, 240);
            this.TpText.ResumeLayout(false);
            this.TpFile.ResumeLayout(false);
            this.TcCrypto.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbOpt;
        private System.Windows.Forms.ComboBox CbDir;
        private System.Windows.Forms.ComboBox CbFun;
        private System.Windows.Forms.TabPage TpText;
        private System.Windows.Forms.TabPage TpFile;
        private System.Windows.Forms.ATabControl TcCrypto;
        private AText UcText;
        private AFile UcFile;
    }
}

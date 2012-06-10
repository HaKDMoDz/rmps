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
            this.TcCrypto = new System.Windows.Forms.ATabControl();
            this.TpFile = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LbData = new System.Windows.Forms.Label();
            this.GvFile = new System.Windows.Forms.DataGridView();
            this.TpText = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TbSrc = new System.Windows.Forms.TextBox();
            this.TbDst = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TcCrypto.SuspendLayout();
            this.TpFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvFile)).BeginInit();
            this.TpText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // TpFile
            // 
            this.TpFile.Controls.Add(this.pictureBox1);
            this.TpFile.Controls.Add(this.textBox1);
            this.TpFile.Controls.Add(this.LbData);
            this.TpFile.Controls.Add(this.GvFile);
            this.TpFile.Location = new System.Drawing.Point(4, 4);
            this.TpFile.Name = "TpFile";
            this.TpFile.Size = new System.Drawing.Size(333, 206);
            this.TpFile.TabIndex = 2;
            this.TpFile.Text = "文件";
            this.TpFile.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(56, 182);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(252, 21);
            this.textBox1.TabIndex = 2;
            // 
            // LbData
            // 
            this.LbData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LbData.AutoSize = true;
            this.LbData.Location = new System.Drawing.Point(3, 185);
            this.LbData.Name = "LbData";
            this.LbData.Size = new System.Drawing.Size(47, 12);
            this.LbData.TabIndex = 1;
            this.LbData.Text = "口令(&K)";
            // 
            // GvFile
            // 
            this.GvFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GvFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvFile.Location = new System.Drawing.Point(3, 3);
            this.GvFile.Name = "GvFile";
            this.GvFile.RowTemplate.Height = 23;
            this.GvFile.Size = new System.Drawing.Size(327, 173);
            this.GvFile.TabIndex = 0;
            this.GvFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.GvFile_DragDrop);
            this.GvFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.GvFile_DragEnter);
            // 
            // TpText
            // 
            this.TpText.Controls.Add(this.splitContainer1);
            this.TpText.Location = new System.Drawing.Point(4, 4);
            this.TpText.Name = "TpText";
            this.TpText.Size = new System.Drawing.Size(333, 206);
            this.TpText.TabIndex = 3;
            this.TpText.Text = "文本";
            this.TpText.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TbSrc);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TbDst);
            this.splitContainer1.Size = new System.Drawing.Size(323, 200);
            this.splitContainer1.SplitterDistance = 107;
            this.splitContainer1.TabIndex = 0;
            // 
            // TbSrc
            // 
            this.TbSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbSrc.Location = new System.Drawing.Point(0, 0);
            this.TbSrc.Multiline = true;
            this.TbSrc.Name = "TbSrc";
            this.TbSrc.Size = new System.Drawing.Size(323, 107);
            this.TbSrc.TabIndex = 0;
            // 
            // TbDst
            // 
            this.TbDst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbDst.Location = new System.Drawing.Point(0, 0);
            this.TbDst.Multiline = true;
            this.TbDst.Name = "TbDst";
            this.TbDst.ReadOnly = true;
            this.TbDst.Size = new System.Drawing.Size(323, 89);
            this.TbDst.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(314, 185);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
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
            this.TcCrypto.ResumeLayout(false);
            this.TpFile.ResumeLayout(false);
            this.TpFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvFile)).EndInit();
            this.TpText.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbOpt;
        private System.Windows.Forms.ComboBox CbDir;
        private System.Windows.Forms.ComboBox CbFun;
        private System.Windows.Forms.ATabControl TcCrypto;
        private System.Windows.Forms.TabPage TpFile;
        private System.Windows.Forms.TabPage TpText;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label LbData;
        private System.Windows.Forms.DataGridView GvFile;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox TbDst;
        private System.Windows.Forms.TextBox TbSrc;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

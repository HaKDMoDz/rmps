namespace Me.Amon.Sec.V.Wiz
{
    partial class UcSrc
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
            this.PbMask = new System.Windows.Forms.PictureBox();
            this.TcSrc = new System.Windows.Forms.ATabControl();
            this.TpText = new System.Windows.Forms.TabPage();
            this.TbText = new System.Windows.Forms.TextBox();
            this.TpFile = new System.Windows.Forms.TabPage();
            this.UcFile = new Me.Amon.Sec.V.Wiz.UcSrcFile();
            ((System.ComponentModel.ISupportInitialize)(this.PbMask)).BeginInit();
            this.TcSrc.SuspendLayout();
            this.TpText.SuspendLayout();
            this.TpFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // PbMask
            // 
            this.PbMask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PbMask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbMask.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbMask.Location = new System.Drawing.Point(3, 181);
            this.PbMask.Name = "PbMask";
            this.PbMask.Size = new System.Drawing.Size(16, 16);
            this.PbMask.TabIndex = 1;
            this.PbMask.TabStop = false;
            this.PbMask.Click += new System.EventHandler(this.PbMask_Click);
            // 
            // TcSrc
            // 
            this.TcSrc.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TcSrc.Controls.Add(this.TpText);
            this.TcSrc.Controls.Add(this.TpFile);
            // 
            // 
            // 
            this.TcSrc.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.TcSrc.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.TcSrc.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.TcSrc.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.TcSrc.DisplayStyleProvider.FocusTrack = true;
            this.TcSrc.DisplayStyleProvider.HotTrack = true;
            this.TcSrc.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TcSrc.DisplayStyleProvider.Opacity = 1F;
            this.TcSrc.DisplayStyleProvider.Overlap = 0;
            this.TcSrc.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
            this.TcSrc.DisplayStyleProvider.Radius = 2;
            this.TcSrc.DisplayStyleProvider.ShowTabCloser = false;
            this.TcSrc.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.TcSrc.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.TcSrc.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.TcSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TcSrc.HotTrack = true;
            this.TcSrc.Location = new System.Drawing.Point(0, 0);
            this.TcSrc.Multiline = true;
            this.TcSrc.Name = "TcSrc";
            this.TcSrc.SelectedIndex = 0;
            this.TcSrc.Size = new System.Drawing.Size(240, 200);
            this.TcSrc.TabIndex = 0;
            this.TcSrc.SelectedIndexChanged += new System.EventHandler(this.TcSrc_SelectedIndexChanged);
            // 
            // TpText
            // 
            this.TpText.Controls.Add(this.TbText);
            this.TpText.Location = new System.Drawing.Point(23, 4);
            this.TpText.Name = "TpText";
            this.TpText.Padding = new System.Windows.Forms.Padding(3);
            this.TpText.Size = new System.Drawing.Size(213, 192);
            this.TpText.TabIndex = 0;
            this.TpText.Text = "文本";
            this.TpText.UseVisualStyleBackColor = true;
            // 
            // TbText
            // 
            this.TbText.AllowDrop = true;
            this.TbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbText.Location = new System.Drawing.Point(3, 3);
            this.TbText.Multiline = true;
            this.TbText.Name = "TbText";
            this.TbText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbText.Size = new System.Drawing.Size(207, 186);
            this.TbText.TabIndex = 0;
            this.TbText.DragDrop += new System.Windows.Forms.DragEventHandler(this.TbText_DragDrop);
            this.TbText.DragEnter += new System.Windows.Forms.DragEventHandler(this.TbText_DragEnter);
            // 
            // TpFile
            // 
            this.TpFile.Controls.Add(this.UcFile);
            this.TpFile.Location = new System.Drawing.Point(23, 4);
            this.TpFile.Name = "TpFile";
            this.TpFile.Padding = new System.Windows.Forms.Padding(3);
            this.TpFile.Size = new System.Drawing.Size(213, 192);
            this.TpFile.TabIndex = 1;
            this.TpFile.Text = "文件";
            this.TpFile.UseVisualStyleBackColor = true;
            // 
            // UcFile
            // 
            this.UcFile.AllowDrop = true;
            this.UcFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UcFile.Location = new System.Drawing.Point(3, 3);
            this.UcFile.Name = "UcFile";
            this.UcFile.Size = new System.Drawing.Size(207, 186);
            this.UcFile.TabIndex = 0;
            this.UcFile.UserFile = null;
            this.UcFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.LbFile_DragDrop);
            this.UcFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.LbFile_DragEnter);
            // 
            // UcSrc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbMask);
            this.Controls.Add(this.TcSrc);
            this.Name = "UcSrc";
            this.Size = new System.Drawing.Size(240, 200);
            ((System.ComponentModel.ISupportInitialize)(this.PbMask)).EndInit();
            this.TcSrc.ResumeLayout(false);
            this.TpText.ResumeLayout(false);
            this.TpText.PerformLayout();
            this.TpFile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ATabControl TcSrc;
        private System.Windows.Forms.TabPage TpText;
        private System.Windows.Forms.TabPage TpFile;
        private System.Windows.Forms.TextBox TbText;
        private UcSrcFile UcFile;
        private System.Windows.Forms.PictureBox PbMask;
    }
}

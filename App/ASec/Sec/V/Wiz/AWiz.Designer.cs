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
            this.ScMain = new System.Windows.Forms.SplitContainer();
            this.PlSrc = new System.Windows.Forms.Panel();
            this.PbSrcPath = new System.Windows.Forms.PictureBox();
            this.PbIUdc = new System.Windows.Forms.PictureBox();
            this.PbAlg = new System.Windows.Forms.PictureBox();
            this.CbDir = new System.Windows.Forms.ComboBox();
            this.LlDir = new System.Windows.Forms.Label();
            this.PlDst = new System.Windows.Forms.Panel();
            this.PbDstPath = new System.Windows.Forms.PictureBox();
            this.PbOUdc = new System.Windows.Forms.PictureBox();
            this.PbKey = new System.Windows.Forms.PictureBox();
            this.TbKey = new System.Windows.Forms.TextBox();
            this.LlKey = new System.Windows.Forms.Label();
            this.TcSrc = new System.Windows.Forms.ATabControl();
            this.TpSrcFile = new System.Windows.Forms.TabPage();
            this.LbSrcFile = new System.Windows.Forms.ListBox();
            this.TpSrcText = new System.Windows.Forms.TabPage();
            this.TbSrcText = new System.Windows.Forms.TextBox();
            this.TcDst = new System.Windows.Forms.ATabControl();
            this.TpDstFile = new System.Windows.Forms.TabPage();
            this.LbDstFile = new System.Windows.Forms.ListBox();
            this.TpDstText = new System.Windows.Forms.TabPage();
            this.TbDstText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).BeginInit();
            this.ScMain.Panel1.SuspendLayout();
            this.ScMain.Panel2.SuspendLayout();
            this.ScMain.SuspendLayout();
            this.PlSrc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbSrcPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbIUdc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbAlg)).BeginInit();
            this.PlDst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbDstPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbOUdc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbKey)).BeginInit();
            this.TcSrc.SuspendLayout();
            this.TpSrcFile.SuspendLayout();
            this.TpSrcText.SuspendLayout();
            this.TcDst.SuspendLayout();
            this.TpDstFile.SuspendLayout();
            this.TpDstText.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScMain
            // 
            this.ScMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScMain.Location = new System.Drawing.Point(0, 0);
            this.ScMain.Name = "ScMain";
            // 
            // ScMain.Panel1
            // 
            this.ScMain.Panel1.Controls.Add(this.PlSrc);
            this.ScMain.Panel1MinSize = 180;
            // 
            // ScMain.Panel2
            // 
            this.ScMain.Panel2.Controls.Add(this.PlDst);
            this.ScMain.Panel2MinSize = 200;
            this.ScMain.Size = new System.Drawing.Size(526, 266);
            this.ScMain.SplitterDistance = 261;
            this.ScMain.TabIndex = 0;
            this.ScMain.TabStop = false;
            // 
            // PlSrc
            // 
            this.PlSrc.Controls.Add(this.PbSrcPath);
            this.PlSrc.Controls.Add(this.TcSrc);
            this.PlSrc.Controls.Add(this.PbIUdc);
            this.PlSrc.Controls.Add(this.PbAlg);
            this.PlSrc.Controls.Add(this.CbDir);
            this.PlSrc.Controls.Add(this.LlDir);
            this.PlSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlSrc.Location = new System.Drawing.Point(0, 0);
            this.PlSrc.Name = "PlSrc";
            this.PlSrc.Size = new System.Drawing.Size(261, 266);
            this.PlSrc.TabIndex = 0;
            // 
            // PbSrcPath
            // 
            this.PbSrcPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PbSrcPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbSrcPath.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbSrcPath.Location = new System.Drawing.Point(4, 244);
            this.PbSrcPath.Name = "PbSrcPath";
            this.PbSrcPath.Size = new System.Drawing.Size(16, 16);
            this.PbSrcPath.TabIndex = 5;
            this.PbSrcPath.TabStop = false;
            this.PbSrcPath.Click += new System.EventHandler(this.PbSrcPath_Click);
            // 
            // PbIUdc
            // 
            this.PbIUdc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbIUdc.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbIUdc.Location = new System.Drawing.Point(158, 5);
            this.PbIUdc.Name = "PbIUdc";
            this.PbIUdc.Size = new System.Drawing.Size(16, 16);
            this.PbIUdc.TabIndex = 3;
            this.PbIUdc.TabStop = false;
            this.PbIUdc.Click += new System.EventHandler(this.PbIUdc_Click);
            // 
            // PbAlg
            // 
            this.PbAlg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbAlg.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbAlg.Location = new System.Drawing.Point(136, 5);
            this.PbAlg.Name = "PbAlg";
            this.PbAlg.Size = new System.Drawing.Size(16, 16);
            this.PbAlg.TabIndex = 2;
            this.PbAlg.TabStop = false;
            this.PbAlg.Click += new System.EventHandler(this.PbAlg_Click);
            // 
            // CbDir
            // 
            this.CbDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbDir.FormattingEnabled = true;
            this.CbDir.Location = new System.Drawing.Point(56, 3);
            this.CbDir.Name = "CbDir";
            this.CbDir.Size = new System.Drawing.Size(74, 20);
            this.CbDir.TabIndex = 1;
            this.CbDir.SelectedIndexChanged += new System.EventHandler(this.CbDir_SelectedIndexChanged);
            // 
            // LlDir
            // 
            this.LlDir.AutoSize = true;
            this.LlDir.Location = new System.Drawing.Point(3, 6);
            this.LlDir.Name = "LlDir";
            this.LlDir.Size = new System.Drawing.Size(47, 12);
            this.LlDir.TabIndex = 0;
            this.LlDir.Text = "操作(&O)";
            // 
            // PlDst
            // 
            this.PlDst.Controls.Add(this.PbDstPath);
            this.PlDst.Controls.Add(this.TcDst);
            this.PlDst.Controls.Add(this.PbOUdc);
            this.PlDst.Controls.Add(this.PbKey);
            this.PlDst.Controls.Add(this.TbKey);
            this.PlDst.Controls.Add(this.LlKey);
            this.PlDst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlDst.Location = new System.Drawing.Point(0, 0);
            this.PlDst.Name = "PlDst";
            this.PlDst.Size = new System.Drawing.Size(261, 266);
            this.PlDst.TabIndex = 0;
            // 
            // PbDstPath
            // 
            this.PbDstPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PbDstPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbDstPath.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbDstPath.Location = new System.Drawing.Point(4, 244);
            this.PbDstPath.Name = "PbDstPath";
            this.PbDstPath.Size = new System.Drawing.Size(16, 16);
            this.PbDstPath.TabIndex = 6;
            this.PbDstPath.TabStop = false;
            this.PbDstPath.Click += new System.EventHandler(this.PbDstPath_Click);
            // 
            // PbOUdc
            // 
            this.PbOUdc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbOUdc.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbOUdc.Location = new System.Drawing.Point(184, 5);
            this.PbOUdc.Name = "PbOUdc";
            this.PbOUdc.Size = new System.Drawing.Size(16, 16);
            this.PbOUdc.TabIndex = 4;
            this.PbOUdc.TabStop = false;
            this.PbOUdc.Visible = false;
            this.PbOUdc.Click += new System.EventHandler(this.PbOUdc_Click);
            // 
            // PbKey
            // 
            this.PbKey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbKey.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbKey.Location = new System.Drawing.Point(162, 5);
            this.PbKey.Name = "PbKey";
            this.PbKey.Size = new System.Drawing.Size(16, 16);
            this.PbKey.TabIndex = 3;
            this.PbKey.TabStop = false;
            this.PbKey.Visible = false;
            this.PbKey.Click += new System.EventHandler(this.PbKey_Click);
            // 
            // TbKey
            // 
            this.TbKey.Location = new System.Drawing.Point(56, 3);
            this.TbKey.Name = "TbKey";
            this.TbKey.Size = new System.Drawing.Size(100, 21);
            this.TbKey.TabIndex = 1;
            this.TbKey.Visible = false;
            // 
            // LlKey
            // 
            this.LlKey.AutoSize = true;
            this.LlKey.Location = new System.Drawing.Point(3, 6);
            this.LlKey.Name = "LlKey";
            this.LlKey.Size = new System.Drawing.Size(47, 12);
            this.LlKey.TabIndex = 0;
            this.LlKey.Text = "口令(&K)";
            this.LlKey.Visible = false;
            // 
            // TcSrc
            // 
            this.TcSrc.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TcSrc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TcSrc.Controls.Add(this.TpSrcFile);
            this.TcSrc.Controls.Add(this.TpSrcText);
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
            this.TcSrc.HotTrack = true;
            this.TcSrc.Location = new System.Drawing.Point(0, 29);
            this.TcSrc.Multiline = true;
            this.TcSrc.Name = "TcSrc";
            this.TcSrc.SelectedIndex = 0;
            this.TcSrc.Size = new System.Drawing.Size(261, 237);
            this.TcSrc.TabIndex = 4;
            this.TcSrc.SelectedIndexChanged += new System.EventHandler(this.TcSrc_SelectedIndexChanged);
            // 
            // TpSrcFile
            // 
            this.TpSrcFile.Controls.Add(this.LbSrcFile);
            this.TpSrcFile.Location = new System.Drawing.Point(23, 4);
            this.TpSrcFile.Name = "TpSrcFile";
            this.TpSrcFile.Padding = new System.Windows.Forms.Padding(3);
            this.TpSrcFile.Size = new System.Drawing.Size(234, 229);
            this.TpSrcFile.TabIndex = 0;
            this.TpSrcFile.Text = "文件";
            this.TpSrcFile.UseVisualStyleBackColor = true;
            // 
            // LbSrcFile
            // 
            this.LbSrcFile.AllowDrop = true;
            this.LbSrcFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbSrcFile.FormattingEnabled = true;
            this.LbSrcFile.IntegralHeight = false;
            this.LbSrcFile.ItemHeight = 12;
            this.LbSrcFile.Location = new System.Drawing.Point(3, 3);
            this.LbSrcFile.Name = "LbSrcFile";
            this.LbSrcFile.Size = new System.Drawing.Size(228, 223);
            this.LbSrcFile.TabIndex = 0;
            this.LbSrcFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.LbSrcFile_DragDrop);
            this.LbSrcFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.LbSrcFile_DragEnter);
            // 
            // TpSrcText
            // 
            this.TpSrcText.Controls.Add(this.TbSrcText);
            this.TpSrcText.Location = new System.Drawing.Point(23, 4);
            this.TpSrcText.Name = "TpSrcText";
            this.TpSrcText.Padding = new System.Windows.Forms.Padding(3);
            this.TpSrcText.Size = new System.Drawing.Size(244, 229);
            this.TpSrcText.TabIndex = 1;
            this.TpSrcText.Text = "文本";
            this.TpSrcText.UseVisualStyleBackColor = true;
            // 
            // TbSrcText
            // 
            this.TbSrcText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbSrcText.Location = new System.Drawing.Point(3, 3);
            this.TbSrcText.Multiline = true;
            this.TbSrcText.Name = "TbSrcText";
            this.TbSrcText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbSrcText.Size = new System.Drawing.Size(234, 223);
            this.TbSrcText.TabIndex = 0;
            this.TbSrcText.DragDrop += new System.Windows.Forms.DragEventHandler(this.TbSrcText_DragDrop);
            this.TbSrcText.DragEnter += new System.Windows.Forms.DragEventHandler(this.TbSrcText_DragEnter);
            // 
            // TcDst
            // 
            this.TcDst.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TcDst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TcDst.Controls.Add(this.TpDstFile);
            this.TcDst.Controls.Add(this.TpDstText);
            // 
            // 
            // 
            this.TcDst.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.TcDst.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.TcDst.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.TcDst.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.TcDst.DisplayStyleProvider.FocusTrack = true;
            this.TcDst.DisplayStyleProvider.HotTrack = true;
            this.TcDst.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TcDst.DisplayStyleProvider.Opacity = 1F;
            this.TcDst.DisplayStyleProvider.Overlap = 0;
            this.TcDst.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
            this.TcDst.DisplayStyleProvider.Radius = 2;
            this.TcDst.DisplayStyleProvider.ShowTabCloser = false;
            this.TcDst.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.TcDst.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.TcDst.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.TcDst.HotTrack = true;
            this.TcDst.Location = new System.Drawing.Point(0, 29);
            this.TcDst.Multiline = true;
            this.TcDst.Name = "TcDst";
            this.TcDst.SelectedIndex = 0;
            this.TcDst.Size = new System.Drawing.Size(261, 237);
            this.TcDst.TabIndex = 5;
            this.TcDst.SelectedIndexChanged += new System.EventHandler(this.TcDst_SelectedIndexChanged);
            // 
            // TpDstFile
            // 
            this.TpDstFile.Controls.Add(this.LbDstFile);
            this.TpDstFile.Location = new System.Drawing.Point(23, 4);
            this.TpDstFile.Name = "TpDstFile";
            this.TpDstFile.Padding = new System.Windows.Forms.Padding(3);
            this.TpDstFile.Size = new System.Drawing.Size(234, 229);
            this.TpDstFile.TabIndex = 0;
            this.TpDstFile.Text = "文件";
            this.TpDstFile.UseVisualStyleBackColor = true;
            // 
            // LbDstFile
            // 
            this.LbDstFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbDstFile.FormattingEnabled = true;
            this.LbDstFile.IntegralHeight = false;
            this.LbDstFile.ItemHeight = 12;
            this.LbDstFile.Location = new System.Drawing.Point(3, 3);
            this.LbDstFile.Name = "LbDstFile";
            this.LbDstFile.Size = new System.Drawing.Size(228, 223);
            this.LbDstFile.TabIndex = 0;
            // 
            // TpDstText
            // 
            this.TpDstText.Controls.Add(this.TbDstText);
            this.TpDstText.Location = new System.Drawing.Point(23, 4);
            this.TpDstText.Name = "TpDstText";
            this.TpDstText.Padding = new System.Windows.Forms.Padding(3);
            this.TpDstText.Size = new System.Drawing.Size(244, 229);
            this.TpDstText.TabIndex = 1;
            this.TpDstText.Text = "文本";
            this.TpDstText.UseVisualStyleBackColor = true;
            // 
            // TbDstText
            // 
            this.TbDstText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbDstText.Location = new System.Drawing.Point(3, 3);
            this.TbDstText.Multiline = true;
            this.TbDstText.Name = "TbDstText";
            this.TbDstText.ReadOnly = true;
            this.TbDstText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbDstText.Size = new System.Drawing.Size(234, 223);
            this.TbDstText.TabIndex = 0;
            // 
            // AWiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ScMain);
            this.Name = "AWiz";
            this.Size = new System.Drawing.Size(526, 266);
            this.ScMain.Panel1.ResumeLayout(false);
            this.ScMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).EndInit();
            this.ScMain.ResumeLayout(false);
            this.PlSrc.ResumeLayout(false);
            this.PlSrc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbSrcPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbIUdc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbAlg)).EndInit();
            this.PlDst.ResumeLayout(false);
            this.PlDst.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbDstPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbOUdc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbKey)).EndInit();
            this.TcSrc.ResumeLayout(false);
            this.TpSrcFile.ResumeLayout(false);
            this.TpSrcText.ResumeLayout(false);
            this.TpSrcText.PerformLayout();
            this.TcDst.ResumeLayout(false);
            this.TpDstFile.ResumeLayout(false);
            this.TpDstText.ResumeLayout(false);
            this.TpDstText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer ScMain;
        private System.Windows.Forms.Panel PlSrc;
        private System.Windows.Forms.Panel PlDst;
        private System.Windows.Forms.ComboBox CbDir;
        private System.Windows.Forms.Label LlDir;
        private System.Windows.Forms.PictureBox PbIUdc;
        private System.Windows.Forms.PictureBox PbAlg;
        private System.Windows.Forms.ATabControl TcSrc;
        private System.Windows.Forms.TabPage TpSrcFile;
        private System.Windows.Forms.TabPage TpSrcText;
        private System.Windows.Forms.TextBox TbKey;
        private System.Windows.Forms.Label LlKey;
        private System.Windows.Forms.PictureBox PbOUdc;
        private System.Windows.Forms.PictureBox PbKey;
        private System.Windows.Forms.ATabControl TcDst;
        private System.Windows.Forms.TabPage TpDstFile;
        private System.Windows.Forms.TabPage TpDstText;
        private System.Windows.Forms.PictureBox PbSrcPath;
        private System.Windows.Forms.PictureBox PbDstPath;
        private System.Windows.Forms.ListBox LbSrcFile;
        private System.Windows.Forms.ListBox LbDstFile;
        private System.Windows.Forms.TextBox TbSrcText;
        private System.Windows.Forms.TextBox TbDstText;

    }
}

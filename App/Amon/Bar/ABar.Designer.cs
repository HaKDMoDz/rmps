namespace Me.Amon.Bar
{
    partial class ABar
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABar));
            this.LbOpt = new System.Windows.Forms.Label();
            this.CbOpt = new System.Windows.Forms.ComboBox();
            this.PbIcon = new System.Windows.Forms.PictureBox();
            this.GbSet = new System.Windows.Forms.GroupBox();
            this.UcUserSet = new Me.Amon.Bar.UserSet();
            this.GbOpt = new System.Windows.Forms.GroupBox();
            this.PbMenu = new System.Windows.Forms.PictureBox();
            this.BtEnc = new System.Windows.Forms.Button();
            this.LbEcho = new System.Windows.Forms.Label();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.MiDecLoc = new System.Windows.Forms.ToolStripMenuItem();
            this.MiDecUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PbIcon)).BeginInit();
            this.GbSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).BeginInit();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbOpt
            // 
            this.LbOpt.AutoSize = true;
            this.LbOpt.Location = new System.Drawing.Point(12, 15);
            this.LbOpt.Name = "LbOpt";
            this.LbOpt.Size = new System.Drawing.Size(47, 12);
            this.LbOpt.TabIndex = 0;
            this.LbOpt.Text = "操作(&O)";
            // 
            // CbOpt
            // 
            this.CbOpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbOpt.FormattingEnabled = true;
            this.CbOpt.Location = new System.Drawing.Point(65, 12);
            this.CbOpt.Name = "CbOpt";
            this.CbOpt.Size = new System.Drawing.Size(121, 20);
            this.CbOpt.TabIndex = 1;
            this.CbOpt.SelectedIndexChanged += new System.EventHandler(this.CbOpt_SelectedIndexChanged);
            // 
            // PbIcon
            // 
            this.PbIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbIcon.Location = new System.Drawing.Point(12, 45);
            this.PbIcon.Name = "PbIcon";
            this.PbIcon.Size = new System.Drawing.Size(256, 256);
            this.PbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PbIcon.TabIndex = 2;
            this.PbIcon.TabStop = false;
            // 
            // GbSet
            // 
            this.GbSet.Controls.Add(this.UcUserSet);
            this.GbSet.Location = new System.Drawing.Point(274, 12);
            this.GbSet.Name = "GbSet";
            this.GbSet.Size = new System.Drawing.Size(308, 102);
            this.GbSet.TabIndex = 3;
            this.GbSet.TabStop = false;
            this.GbSet.Text = "设置";
            // 
            // UcUserSet
            // 
            this.UcUserSet.Location = new System.Drawing.Point(6, 20);
            this.UcUserSet.Name = "UcUserSet";
            this.UcUserSet.Size = new System.Drawing.Size(296, 76);
            this.UcUserSet.TabIndex = 0;
            // 
            // GbOpt
            // 
            this.GbOpt.Location = new System.Drawing.Point(274, 120);
            this.GbOpt.Name = "GbOpt";
            this.GbOpt.Size = new System.Drawing.Size(308, 181);
            this.GbOpt.TabIndex = 4;
            this.GbOpt.TabStop = false;
            this.GbOpt.Text = "数据";
            // 
            // PbMenu
            // 
            this.PbMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PbMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbMenu.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbMenu.Location = new System.Drawing.Point(12, 309);
            this.PbMenu.Name = "PbMenu";
            this.PbMenu.Size = new System.Drawing.Size(16, 16);
            this.PbMenu.TabIndex = 6;
            this.PbMenu.TabStop = false;
            this.PbMenu.Text = "解析(&D)";
            this.TpTips.SetToolTip(this.PbMenu, "系统选单");
            this.PbMenu.Click += new System.EventHandler(this.PbMenu_Click);
            // 
            // BtEnc
            // 
            this.BtEnc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtEnc.Location = new System.Drawing.Point(507, 307);
            this.BtEnc.Name = "BtEnc";
            this.BtEnc.Size = new System.Drawing.Size(75, 23);
            this.BtEnc.TabIndex = 5;
            this.BtEnc.Text = "生成(&G)";
            this.BtEnc.UseVisualStyleBackColor = true;
            this.BtEnc.Click += new System.EventHandler(this.BtEnc_Click);
            // 
            // LbEcho
            // 
            this.LbEcho.AutoSize = true;
            this.LbEcho.Location = new System.Drawing.Point(34, 312);
            this.LbEcho.Name = "LbEcho";
            this.LbEcho.Size = new System.Drawing.Size(0, 12);
            this.LbEcho.TabIndex = 7;
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiSave,
            this.MiSep0,
            this.MiDecLoc,
            this.MiDecUrl});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(166, 98);
            // 
            // MiSave
            // 
            this.MiSave.Name = "MiSave";
            this.MiSave.Size = new System.Drawing.Size(165, 22);
            this.MiSave.Text = "另存为(&S)";
            this.MiSave.Click += new System.EventHandler(this.MiSave_Click);
            // 
            // MiSep0
            // 
            this.MiSep0.Name = "MiSep0";
            this.MiSep0.Size = new System.Drawing.Size(162, 6);
            // 
            // MiDecLoc
            // 
            this.MiDecLoc.Name = "MiDecLoc";
            this.MiDecLoc.Size = new System.Drawing.Size(165, 22);
            this.MiDecLoc.Text = "打开本地文件(&L)";
            this.MiDecLoc.Click += new System.EventHandler(this.MiDecLoc_Click);
            // 
            // MiDecUrl
            // 
            this.MiDecUrl.Name = "MiDecUrl";
            this.MiDecUrl.Size = new System.Drawing.Size(165, 22);
            this.MiDecUrl.Text = "打开网络地址(&U)";
            this.MiDecUrl.Click += new System.EventHandler(this.MiDecUrl_Click);
            // 
            // ABar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 342);
            this.Controls.Add(this.LbEcho);
            this.Controls.Add(this.BtEnc);
            this.Controls.Add(this.PbMenu);
            this.Controls.Add(this.GbOpt);
            this.Controls.Add(this.GbSet);
            this.Controls.Add(this.PbIcon);
            this.Controls.Add(this.CbOpt);
            this.Controls.Add(this.LbOpt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ABar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "阿木二维码";
            this.Load += new System.EventHandler(this.ABar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbIcon)).EndInit();
            this.GbSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).EndInit();
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbOpt;
        private System.Windows.Forms.ComboBox CbOpt;
        private System.Windows.Forms.PictureBox PbIcon;
        private System.Windows.Forms.GroupBox GbSet;
        private System.Windows.Forms.GroupBox GbOpt;
        private System.Windows.Forms.PictureBox PbMenu;
        private System.Windows.Forms.Button BtEnc;
        private UserSet UcUserSet;
        private System.Windows.Forms.Label LbEcho;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiDecLoc;
        private System.Windows.Forms.ToolStripMenuItem MiDecUrl;
        private System.Windows.Forms.ToolStripMenuItem MiSave;
        private System.Windows.Forms.ToolStripSeparator MiSep0;
        private System.Windows.Forms.ToolTip TpTips;
    }
}
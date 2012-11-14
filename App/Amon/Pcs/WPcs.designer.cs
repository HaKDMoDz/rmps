namespace Me.Amon.Pcs
{
    partial class WPcs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.SbEcho = new System.Windows.Forms.StatusStrip();
            this.TlEcho = new System.Windows.Forms.ToolStripStatusLabel();
            this.TlTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.MbMenu = new System.Windows.Forms.MenuStrip();
            this.TcMain = new System.Windows.Forms.ToolStripContainer();
            this.ScMain = new System.Windows.Forms.SplitContainer();
            this.TcMeta = new System.Windows.Forms.ATabControl();
            this.wListView1 = new Me.Amon.Pcs.V.WListView();
            this.UcUri = new Me.Amon.Pcs.V.MetaUri();
            this.TbTool = new System.Windows.Forms.ToolStrip();
            this.TtTips = new System.Windows.Forms.ToolTip(this.components);
            this.IlPcsList = new System.Windows.Forms.ImageList(this.components);
            this.SbEcho.SuspendLayout();
            this.TcMain.ContentPanel.SuspendLayout();
            this.TcMain.TopToolStripPanel.SuspendLayout();
            this.TcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).BeginInit();
            this.ScMain.Panel1.SuspendLayout();
            this.ScMain.Panel2.SuspendLayout();
            this.ScMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // SbEcho
            // 
            this.SbEcho.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TlEcho,
            this.TlTime});
            this.SbEcho.Location = new System.Drawing.Point(0, 420);
            this.SbEcho.Name = "SbEcho";
            this.SbEcho.Size = new System.Drawing.Size(624, 22);
            this.SbEcho.TabIndex = 0;
            this.SbEcho.Text = "statusStrip1";
            // 
            // TlEcho
            // 
            this.TlEcho.Name = "TlEcho";
            this.TlEcho.Size = new System.Drawing.Size(553, 17);
            this.TlEcho.Spring = true;
            this.TlEcho.Text = "系统加载中,请稍候……";
            this.TlEcho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TlTime
            // 
            this.TlTime.Name = "TlTime";
            this.TlTime.Size = new System.Drawing.Size(56, 17);
            this.TlTime.Text = "当前时间";
            // 
            // MbMenu
            // 
            this.MbMenu.Location = new System.Drawing.Point(0, 0);
            this.MbMenu.Name = "MbMenu";
            this.MbMenu.Size = new System.Drawing.Size(624, 24);
            this.MbMenu.TabIndex = 1;
            this.MbMenu.Text = "menuStrip1";
            // 
            // TcMain
            // 
            // 
            // TcMain.ContentPanel
            // 
            this.TcMain.ContentPanel.Controls.Add(this.ScMain);
            this.TcMain.ContentPanel.Controls.Add(this.UcUri);
            this.TcMain.ContentPanel.Size = new System.Drawing.Size(624, 371);
            this.TcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TcMain.Location = new System.Drawing.Point(0, 24);
            this.TcMain.Name = "TcMain";
            this.TcMain.Size = new System.Drawing.Size(624, 396);
            this.TcMain.TabIndex = 2;
            this.TcMain.Text = "toolStripContainer1";
            // 
            // TcMain.TopToolStripPanel
            // 
            this.TcMain.TopToolStripPanel.Controls.Add(this.TbTool);
            // 
            // ScMain
            // 
            this.ScMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ScMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.ScMain.Location = new System.Drawing.Point(6, 41);
            this.ScMain.Name = "ScMain";
            this.ScMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ScMain.Panel1
            // 
            this.ScMain.Panel1.Controls.Add(this.TcMeta);
            // 
            // ScMain.Panel2
            // 
            this.ScMain.Panel2.Controls.Add(this.wListView1);
            this.ScMain.Size = new System.Drawing.Size(612, 327);
            this.ScMain.SplitterDistance = 227;
            this.ScMain.TabIndex = 1;
            // 
            // TcMeta
            // 
            // 
            // 
            // 
            this.TcMeta.DisplayStyleProvider.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.TcMeta.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.TcMeta.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.TcMeta.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.TcMeta.DisplayStyleProvider.FocusTrack = true;
            this.TcMeta.DisplayStyleProvider.HotTrack = true;
            this.TcMeta.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TcMeta.DisplayStyleProvider.Opacity = 1F;
            this.TcMeta.DisplayStyleProvider.Overlap = 0;
            this.TcMeta.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
            this.TcMeta.DisplayStyleProvider.Radius = 2;
            this.TcMeta.DisplayStyleProvider.ShowTabCloser = true;
            this.TcMeta.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.TcMeta.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.TcMeta.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.TcMeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TcMeta.HotTrack = true;
            this.TcMeta.ImageList = this.IlPcsList;
            this.TcMeta.Location = new System.Drawing.Point(0, 0);
            this.TcMeta.Name = "TcMeta";
            this.TcMeta.SelectedIndex = 0;
            this.TcMeta.ShowToolTips = true;
            this.TcMeta.Size = new System.Drawing.Size(612, 227);
            this.TcMeta.TabIndex = 0;
            this.TcMeta.TabClosing += new System.EventHandler<System.Windows.Forms.TabControlCancelEventArgs>(this.TcMeta_TabClosing);
            this.TcMeta.SelectedIndexChanged += new System.EventHandler(this.TcMeta_SelectedIndexChanged);
            // 
            // wListView1
            // 
            this.wListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wListView1.FullRowSelect = true;
            this.wListView1.Location = new System.Drawing.Point(0, 0);
            this.wListView1.Name = "wListView1";
            this.wListView1.OwnerDraw = true;
            this.wListView1.ProgressBackColor = System.Drawing.Color.Green;
            this.wListView1.ProgressColumnIndex = 0;
            this.wListView1.ProgressForeColor = System.Drawing.Color.Black;
            this.wListView1.Size = new System.Drawing.Size(612, 96);
            this.wListView1.TabIndex = 0;
            this.wListView1.UseCompatibleStateImageBehavior = false;
            this.wListView1.View = System.Windows.Forms.View.Details;
            // 
            // UcUri
            // 
            this.UcUri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UcUri.Icon = null;
            this.UcUri.Location = new System.Drawing.Point(6, 3);
            this.UcUri.Name = "UcUri";
            this.UcUri.Path = "pcs://首页";
            this.UcUri.Size = new System.Drawing.Size(612, 32);
            this.UcUri.TabIndex = 0;
            // 
            // TbTool
            // 
            this.TbTool.Dock = System.Windows.Forms.DockStyle.None;
            this.TbTool.Location = new System.Drawing.Point(3, 0);
            this.TbTool.Name = "TbTool";
            this.TbTool.Size = new System.Drawing.Size(111, 25);
            this.TbTool.TabIndex = 0;
            // 
            // IlPcsList
            // 
            this.IlPcsList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.IlPcsList.ImageSize = new System.Drawing.Size(16, 16);
            this.IlPcsList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // WPcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.TcMain);
            this.Controls.Add(this.SbEcho);
            this.Controls.Add(this.MbMenu);
            this.MainMenuStrip = this.MbMenu;
            this.Name = "WPcs";
            this.Text = "阿木云存储";
            this.SbEcho.ResumeLayout(false);
            this.SbEcho.PerformLayout();
            this.TcMain.ContentPanel.ResumeLayout(false);
            this.TcMain.TopToolStripPanel.ResumeLayout(false);
            this.TcMain.TopToolStripPanel.PerformLayout();
            this.TcMain.ResumeLayout(false);
            this.TcMain.PerformLayout();
            this.ScMain.Panel1.ResumeLayout(false);
            this.ScMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).EndInit();
            this.ScMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip SbEcho;
        private System.Windows.Forms.ToolStripStatusLabel TlEcho;
        private System.Windows.Forms.ToolStripStatusLabel TlTime;
        private System.Windows.Forms.MenuStrip MbMenu;
        private System.Windows.Forms.ToolStripContainer TcMain;
        private System.Windows.Forms.ToolStrip TbTool;
        private V.MetaUri UcUri;
        private System.Windows.Forms.SplitContainer ScMain;
        private System.Windows.Forms.ATabControl TcMeta;
        private V.WListView wListView1;
        private System.Windows.Forms.ToolTip TtTips;
        private System.Windows.Forms.ImageList IlPcsList;
    }
}
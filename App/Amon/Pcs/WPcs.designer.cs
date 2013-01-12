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
            this.IlPcsList = new System.Windows.Forms.ImageList(this.components);
            this.UcTaskList = new Me.Amon.Http.Task.TaskList();
            this.UcUri = new Me.Amon.Pcs.V.MetaUri();
            this.TbTool = new System.Windows.Forms.ToolStrip();
            this.TtTips = new System.Windows.Forms.ToolTip(this.components);
            this.BwWork = new System.ComponentModel.BackgroundWorker();
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
            this.SbEcho.Text = "SbEcho";
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
            this.MbMenu.Text = "MbMenu";
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
            this.TcMain.Text = "TcMain";
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
            this.ScMain.Panel2.Controls.Add(this.UcTaskList);
            this.ScMain.Panel2Collapsed = true;
            this.ScMain.Size = new System.Drawing.Size(612, 327);
            this.ScMain.SplitterDistance = 223;
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
            this.TcMeta.DisplayStyleProvider.ShowTabCloser = false;
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
            this.TcMeta.Size = new System.Drawing.Size(612, 327);
            this.TcMeta.TabIndex = 0;
            this.TcMeta.TabClosing += new System.EventHandler<System.Windows.Forms.TabControlCancelEventArgs>(this.TcMeta_TabClosing);
            this.TcMeta.SelectedIndexChanged += new System.EventHandler(this.TcMeta_SelectedIndexChanged);
            // 
            // IlPcsList
            // 
            this.IlPcsList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.IlPcsList.ImageSize = new System.Drawing.Size(16, 16);
            this.IlPcsList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // UcTaskList
            // 
            this.UcTaskList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UcTaskList.Location = new System.Drawing.Point(0, 0);
            this.UcTaskList.Name = "UcTaskList";
            this.UcTaskList.ProgressBackColor = System.Drawing.Color.Empty;
            this.UcTaskList.ProgressForeColor = System.Drawing.Color.Empty;
            this.UcTaskList.Size = new System.Drawing.Size(150, 46);
            this.UcTaskList.TabIndex = 0;
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
            // BwWork
            // 
            this.BwWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwWork_DoWork);
            this.BwWork.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BwWork_ProgressChanged);
            this.BwWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwWork_RunWorkerCompleted);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private Me.Amon.Http.Task.TaskList UcTaskList;
        private System.Windows.Forms.ToolTip TtTips;
        private System.Windows.Forms.ImageList IlPcsList;
        private System.ComponentModel.BackgroundWorker BwWork;
    }
}
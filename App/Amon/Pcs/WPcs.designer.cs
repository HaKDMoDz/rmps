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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SbEcho = new System.Windows.Forms.StatusStrip();
            this.TlEcho = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.MbMenu = new System.Windows.Forms.MenuStrip();
            this.TcMain = new System.Windows.Forms.ToolStripContainer();
            this.TbTool = new System.Windows.Forms.ToolStrip();
            this.TtTips = new System.Windows.Forms.ToolTip(this.components);
            this.TcMeta = new System.Windows.Forms.ATabControl();
            this.TpDef = new System.Windows.Forms.TabPage();
            this.metaUri1 = new Me.Amon.Pcs.V.MetaUri();
            this.SbEcho.SuspendLayout();
            this.TcMain.ContentPanel.SuspendLayout();
            this.TcMain.TopToolStripPanel.SuspendLayout();
            this.TcMain.SuspendLayout();
            this.TcMeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // SbEcho
            // 
            this.SbEcho.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TlEcho,
            this.toolStripStatusLabel2});
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
            this.TlEcho.Text = "系统加载中，请稍候……";
            this.TlEcho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel2.Text = "当前时间";
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
            this.TcMain.ContentPanel.Controls.Add(this.TcMeta);
            this.TcMain.ContentPanel.Controls.Add(this.metaUri1);
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
            // TbTool
            // 
            this.TbTool.Dock = System.Windows.Forms.DockStyle.None;
            this.TbTool.Location = new System.Drawing.Point(3, 0);
            this.TbTool.Name = "TbTool";
            this.TbTool.Size = new System.Drawing.Size(111, 25);
            this.TbTool.TabIndex = 0;
            // 
            // TcMeta
            // 
            this.TcMeta.Controls.Add(this.TpDef);
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
            this.TcMeta.HotTrack = true;
            this.TcMeta.Location = new System.Drawing.Point(12, 41);
            this.TcMeta.Name = "TcMeta";
            this.TcMeta.SelectedIndex = 0;
            this.TcMeta.Size = new System.Drawing.Size(600, 327);
            this.TcMeta.TabIndex = 1;
            // 
            // TpDef
            // 
            this.TpDef.Location = new System.Drawing.Point(4, 23);
            this.TpDef.Name = "TpDef";
            this.TpDef.Padding = new System.Windows.Forms.Padding(3);
            this.TpDef.Size = new System.Drawing.Size(592, 300);
            this.TpDef.TabIndex = 0;
            this.TpDef.Text = "首页";
            this.TpDef.UseVisualStyleBackColor = true;
            // 
            // metaUri1
            // 
            this.metaUri1.Icon = null;
            this.metaUri1.Location = new System.Drawing.Point(12, 3);
            this.metaUri1.Name = "metaUri1";
            this.metaUri1.Size = new System.Drawing.Size(600, 32);
            this.metaUri1.TabIndex = 0;
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
            this.Text = "WPcs";
            this.SbEcho.ResumeLayout(false);
            this.SbEcho.PerformLayout();
            this.TcMain.ContentPanel.ResumeLayout(false);
            this.TcMain.TopToolStripPanel.ResumeLayout(false);
            this.TcMain.TopToolStripPanel.PerformLayout();
            this.TcMain.ResumeLayout(false);
            this.TcMain.PerformLayout();
            this.TcMeta.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip SbEcho;
        private System.Windows.Forms.MenuStrip MbMenu;
        private System.Windows.Forms.ToolStripStatusLabel TlEcho;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripContainer TcMain;
        private System.Windows.Forms.ToolStrip TbTool;
        private System.Windows.Forms.ATabControl TcMeta;
        private System.Windows.Forms.TabPage TpDef;
        private V.MetaUri metaUri1;
        private System.Windows.Forms.ToolTip TtTips;
    }
}
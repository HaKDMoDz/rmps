namespace Me.Amon.Kms.V.Uc
{
    partial class KeybdInput
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
            this.LbKeybd = new System.Windows.Forms.Label();
            this.TbKeybd = new System.Windows.Forms.TextBox();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiListen = new System.Windows.Forms.ToolStripMenuItem();
            this.MiAction = new System.Windows.Forms.ToolStripMenuItem();
            this.MiPress = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiDown = new System.Windows.Forms.ToolStripMenuItem();
            this.MiUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSpace = new System.Windows.Forms.ToolStripMenuItem();
            this.MiBackspace = new System.Windows.Forms.ToolStripMenuItem();
            this.MiEnter = new System.Windows.Forms.ToolStripMenuItem();
            this.SpSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.MiEsc = new System.Windows.Forms.ToolStripMenuItem();
            this.MiTab = new System.Windows.Forms.ToolStripMenuItem();
            this.MiCaps = new System.Windows.Forms.ToolStripMenuItem();
            this.PbKeybd = new System.Windows.Forms.PictureBox();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.CmMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbKeybd)).BeginInit();
            this.SuspendLayout();
            // 
            // LbKeybd
            // 
            this.LbKeybd.AutoSize = true;
            this.LbKeybd.Location = new System.Drawing.Point(3, 7);
            this.LbKeybd.Name = "LbKeybd";
            this.LbKeybd.Size = new System.Drawing.Size(47, 12);
            this.LbKeybd.TabIndex = 0;
            this.LbKeybd.Text = "键值(&K)";
            // 
            // TbKeybd
            // 
            this.TbKeybd.Location = new System.Drawing.Point(56, 3);
            this.TbKeybd.Name = "TbKeybd";
            this.TbKeybd.Size = new System.Drawing.Size(181, 21);
            this.TbKeybd.TabIndex = 1;
            this.TpTips.SetToolTip(this.TbKeybd, "格式：键 事件");
            this.TbKeybd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbKeybd_KeyDown);
            this.TbKeybd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbKeybd_KeyUp);
            this.TbKeybd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbKeybd_KeyPress);
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiListen,
            this.MiAction,
            this.MiSystem});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(125, 70);
            // 
            // MiListen
            // 
            this.MiListen.Checked = true;
            this.MiListen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MiListen.Name = "MiListen";
            this.MiListen.Size = new System.Drawing.Size(124, 22);
            this.MiListen.Text = "主动侦听";
            this.MiListen.Click += new System.EventHandler(this.MiListen_Click);
            // 
            // MiAction
            // 
            this.MiAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiPress,
            this.toolStripSeparator1,
            this.MiDown,
            this.MiUp});
            this.MiAction.Name = "MiAction";
            this.MiAction.Size = new System.Drawing.Size(124, 22);
            this.MiAction.Text = "事件(&E)";
            // 
            // MiPress
            // 
            this.MiPress.Checked = true;
            this.MiPress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MiPress.Name = "MiPress";
            this.MiPress.Size = new System.Drawing.Size(100, 22);
            this.MiPress.Text = "敲击";
            this.MiPress.Click += new System.EventHandler(this.MiPress_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(97, 6);
            // 
            // MiDown
            // 
            this.MiDown.Name = "MiDown";
            this.MiDown.Size = new System.Drawing.Size(100, 22);
            this.MiDown.Text = "按下";
            this.MiDown.Click += new System.EventHandler(this.MiDown_Click);
            // 
            // MiUp
            // 
            this.MiUp.Name = "MiUp";
            this.MiUp.Size = new System.Drawing.Size(100, 22);
            this.MiUp.Text = "松开";
            this.MiUp.Click += new System.EventHandler(this.MiUp_Click);
            // 
            // MiSystem
            // 
            this.MiSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiSpace,
            this.MiBackspace,
            this.MiEnter,
            this.SpSep0,
            this.MiEsc,
            this.MiTab,
            this.MiCaps});
            this.MiSystem.Name = "MiSystem";
            this.MiSystem.Size = new System.Drawing.Size(124, 22);
            this.MiSystem.Text = "常用";
            // 
            // MiSpace
            // 
            this.MiSpace.Name = "MiSpace";
            this.MiSpace.Size = new System.Drawing.Size(138, 22);
            this.MiSpace.Text = "Space";
            this.MiSpace.Click += new System.EventHandler(this.MiSpace_Click);
            // 
            // MiBackspace
            // 
            this.MiBackspace.Name = "MiBackspace";
            this.MiBackspace.Size = new System.Drawing.Size(138, 22);
            this.MiBackspace.Text = "Backspace";
            this.MiBackspace.Click += new System.EventHandler(this.MiBackspace_Click);
            // 
            // MiEnter
            // 
            this.MiEnter.Name = "MiEnter";
            this.MiEnter.Size = new System.Drawing.Size(138, 22);
            this.MiEnter.Text = "Enter";
            this.MiEnter.Click += new System.EventHandler(this.MiEnter_Click);
            // 
            // SpSep0
            // 
            this.SpSep0.Name = "SpSep0";
            this.SpSep0.Size = new System.Drawing.Size(135, 6);
            // 
            // MiEsc
            // 
            this.MiEsc.Name = "MiEsc";
            this.MiEsc.Size = new System.Drawing.Size(138, 22);
            this.MiEsc.Text = "Esc";
            this.MiEsc.Click += new System.EventHandler(this.MiEsc_Click);
            // 
            // MiTab
            // 
            this.MiTab.Name = "MiTab";
            this.MiTab.Size = new System.Drawing.Size(138, 22);
            this.MiTab.Text = "Tab";
            this.MiTab.Click += new System.EventHandler(this.MiTab_Click);
            // 
            // MiCaps
            // 
            this.MiCaps.Name = "MiCaps";
            this.MiCaps.Size = new System.Drawing.Size(138, 22);
            this.MiCaps.Text = "Caps Lock";
            this.MiCaps.Click += new System.EventHandler(this.MiCaps_Click);
            // 
            // PbKeybd
            // 
            this.PbKeybd.Image = global::Me.Amon.Properties.Resources._opt;
            this.PbKeybd.Location = new System.Drawing.Point(243, 5);
            this.PbKeybd.Margin = new System.Windows.Forms.Padding(0);
            this.PbKeybd.Name = "PbKeybd";
            this.PbKeybd.Size = new System.Drawing.Size(16, 16);
            this.PbKeybd.TabIndex = 2;
            this.PbKeybd.TabStop = false;
            this.TpTips.SetToolTip(this.PbKeybd, "选项");
            this.PbKeybd.Click += new System.EventHandler(this.PbKeybd_Click);
            // 
            // KeybdInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbKeybd);
            this.Controls.Add(this.LbKeybd);
            this.Controls.Add(this.PbKeybd);
            this.Name = "KeybdInput";
            this.Size = new System.Drawing.Size(262, 27);
            this.CmMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbKeybd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbKeybd;
        private System.Windows.Forms.TextBox TbKeybd;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiSystem;
        private System.Windows.Forms.ToolStripMenuItem MiEsc;
        private System.Windows.Forms.ToolStripMenuItem MiTab;
        private System.Windows.Forms.ToolStripMenuItem MiCaps;
        private System.Windows.Forms.ToolStripMenuItem MiAction;
        private System.Windows.Forms.ToolStripMenuItem MiListen;
        private System.Windows.Forms.PictureBox PbKeybd;
        private System.Windows.Forms.ToolStripMenuItem MiDown;
        private System.Windows.Forms.ToolStripMenuItem MiUp;
        private System.Windows.Forms.ToolStripMenuItem MiPress;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MiSpace;
        private System.Windows.Forms.ToolStripMenuItem MiBackspace;
        private System.Windows.Forms.ToolStripMenuItem MiEnter;
        private System.Windows.Forms.ToolStripSeparator SpSep0;
        private System.Windows.Forms.ToolTip TpTips;
    }
}

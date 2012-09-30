namespace Me.Amon
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiTalk = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiWork = new System.Windows.Forms.ToolStripMenuItem();
            this.MiHalt = new System.Windows.Forms.ToolStripMenuItem();
            this.MiNext = new System.Windows.Forms.ToolStripMenuItem();
            this.MiStop = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.MuSolution = new System.Windows.Forms.ToolStripMenuItem();
            this.MuTarget = new System.Windows.Forms.ToolStripMenuItem();
            this.MiTarget = new System.Windows.Forms.ToolStripMenuItem();
            this.MiTargetSep = new System.Windows.Forms.ToolStripSeparator();
            this.MuMethod = new System.Windows.Forms.ToolStripMenuItem();
            this.MiMethod = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiAnswer = new System.Windows.Forms.ToolStripMenuItem();
            this.MiActive = new System.Windows.Forms.ToolStripMenuItem();
            this.MiAttack = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.MiOpts = new System.Windows.Forms.ToolStripMenuItem();
            this.MiTray = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep4 = new System.Windows.Forms.ToolStripSeparator();
            this.MiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.NiTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.MiAction = new System.Windows.Forms.ToolStripMenuItem();
            this.CmMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiTalk,
            this.MiSep1,
            this.MiWork,
            this.MiHalt,
            this.MiNext,
            this.MiStop,
            this.MiSep2,
            this.MuSolution,
            this.MuTarget,
            this.MuMethod,
            this.MiAction,
            this.MiSep3,
            this.MiOpts,
            this.MiTray,
            this.MiSep4,
            this.MiExit});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(177, 314);
            // 
            // MiTalk
            // 
            this.MiTalk.Name = "MiTalk";
            this.MiTalk.Size = new System.Drawing.Size(176, 22);
            this.MiTalk.Text = "训练(&T)";
            this.MiTalk.Click += new System.EventHandler(this.MiTalk_Click);
            // 
            // MiSep1
            // 
            this.MiSep1.Name = "MiSep1";
            this.MiSep1.Size = new System.Drawing.Size(173, 6);
            // 
            // MiWork
            // 
            this.MiWork.Name = "MiWork";
            this.MiWork.Size = new System.Drawing.Size(176, 22);
            this.MiWork.Text = "开始(&S)";
            this.MiWork.Click += new System.EventHandler(this.MiWork_Click);
            // 
            // MiHalt
            // 
            this.MiHalt.Enabled = false;
            this.MiHalt.Name = "MiHalt";
            this.MiHalt.Size = new System.Drawing.Size(176, 22);
            this.MiHalt.Text = "暂停(&H)";
            this.MiHalt.Click += new System.EventHandler(this.MiHalt_Click);
            // 
            // MiNext
            // 
            this.MiNext.Enabled = false;
            this.MiNext.Name = "MiNext";
            this.MiNext.Size = new System.Drawing.Size(176, 22);
            this.MiNext.Text = "继续(&C)";
            this.MiNext.Click += new System.EventHandler(this.MiNext_Click);
            // 
            // MiStop
            // 
            this.MiStop.Enabled = false;
            this.MiStop.Name = "MiStop";
            this.MiStop.Size = new System.Drawing.Size(176, 22);
            this.MiStop.Text = "结束(&E)";
            this.MiStop.Click += new System.EventHandler(this.MiStop_Click);
            // 
            // MiSep2
            // 
            this.MiSep2.Name = "MiSep2";
            this.MiSep2.Size = new System.Drawing.Size(173, 6);
            // 
            // MuSolution
            // 
            this.MuSolution.Name = "MuSolution";
            this.MuSolution.Size = new System.Drawing.Size(176, 22);
            this.MuSolution.Text = "方案(&S)";
            // 
            // MuTarget
            // 
            this.MuTarget.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiTarget,
            this.MiTargetSep});
            this.MuTarget.Name = "MuTarget";
            this.MuTarget.Size = new System.Drawing.Size(176, 22);
            this.MuTarget.Text = "目标(&G)";
            // 
            // MiTarget
            // 
            this.MiTarget.Checked = true;
            this.MiTarget.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MiTarget.Name = "MiTarget";
            this.MiTarget.Size = new System.Drawing.Size(152, 22);
            this.MiTarget.Text = "默认(&D)";
            this.MiTarget.Click += new System.EventHandler(this.MiTargetDef_Click);
            // 
            // MiTargetSep
            // 
            this.MiTargetSep.Name = "MiTargetSep";
            this.MiTargetSep.Size = new System.Drawing.Size(149, 6);
            // 
            // MuMethod
            // 
            this.MuMethod.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiMethod,
            this.toolStripSeparator1,
            this.MiAnswer,
            this.MiActive,
            this.MiAttack});
            this.MuMethod.Name = "MuMethod";
            this.MuMethod.Size = new System.Drawing.Size(176, 22);
            this.MuMethod.Text = "方式(&M)";
            // 
            // MiMethod
            // 
            this.MiMethod.Checked = true;
            this.MiMethod.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MiMethod.Name = "MiMethod";
            this.MiMethod.Size = new System.Drawing.Size(152, 22);
            this.MiMethod.Text = "默认(&D)";
            this.MiMethod.Click += new System.EventHandler(this.MiMethod_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // MiAnswer
            // 
            this.MiAnswer.Name = "MiAnswer";
            this.MiAnswer.Size = new System.Drawing.Size(152, 22);
            this.MiAnswer.Text = "应答式交互(&1)";
            this.MiAnswer.Click += new System.EventHandler(this.MiAnswer_Click);
            // 
            // MiActive
            // 
            this.MiActive.Name = "MiActive";
            this.MiActive.Size = new System.Drawing.Size(152, 22);
            this.MiActive.Text = "手控式交互(&2)";
            this.MiActive.Click += new System.EventHandler(this.MiActive_Click);
            // 
            // MiAttack
            // 
            this.MiAttack.Name = "MiAttack";
            this.MiAttack.Size = new System.Drawing.Size(152, 22);
            this.MiAttack.Text = "攻击式交互(&3)";
            this.MiAttack.Click += new System.EventHandler(this.MiAttack_Click);
            // 
            // MiSep3
            // 
            this.MiSep3.Name = "MiSep3";
            this.MiSep3.Size = new System.Drawing.Size(173, 6);
            // 
            // MiOpts
            // 
            this.MiOpts.Name = "MiOpts";
            this.MiOpts.Size = new System.Drawing.Size(176, 22);
            this.MiOpts.Text = "选项(&O)";
            this.MiOpts.Click += new System.EventHandler(this.MiOpts_Click);
            // 
            // MiTray
            // 
            this.MiTray.Name = "MiTray";
            this.MiTray.Size = new System.Drawing.Size(176, 22);
            this.MiTray.Text = "显示为托盘模式(&V)";
            this.MiTray.Click += new System.EventHandler(this.MiTray_Click);
            // 
            // MiSep4
            // 
            this.MiSep4.Name = "MiSep4";
            this.MiSep4.Size = new System.Drawing.Size(173, 6);
            // 
            // MiExit
            // 
            this.MiExit.Name = "MiExit";
            this.MiExit.Size = new System.Drawing.Size(176, 22);
            this.MiExit.Text = "退出(&X)";
            this.MiExit.Click += new System.EventHandler(this.MiExit_Click);
            // 
            // NiTray
            // 
            this.NiTray.ContextMenuStrip = this.CmMenu;
            this.NiTray.Icon = ((System.Drawing.Icon)(resources.GetObject("NiTray.Icon")));
            this.NiTray.Text = "妙语连珠";
            this.NiTray.Visible = true;
            this.NiTray.DoubleClick += new System.EventHandler(this.NiTray_DoubleClick);
            // 
            // PbLogo
            // 
            this.PbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PbLogo.Image = global::Me.Amon.Properties.Resources.logo24;
            this.PbLogo.Location = new System.Drawing.Point(0, 0);
            this.PbLogo.Margin = new System.Windows.Forms.Padding(0);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(24, 24);
            this.PbLogo.TabIndex = 1;
            this.PbLogo.TabStop = false;
            this.PbLogo.DoubleClick += new System.EventHandler(this.PbLogo_DoubleClick);
            this.PbLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrayPtn_MouseDown);
            this.PbLogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TrayPtn_MouseMove);
            this.PbLogo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrayPtn_MouseUp);
            // 
            // MiAction
            // 
            this.MiAction.Name = "MiAction";
            this.MiAction.Size = new System.Drawing.Size(176, 22);
            this.MiAction.Text = "启用打字效果";
            this.MiAction.Click += new System.EventHandler(this.MiAction_Click);
            // 
            // AKms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(24, 24);
            this.ContextMenuStrip = this.CmMenu;
            this.ControlBox = false;
            this.Controls.Add(this.PbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AKms";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TrayPtn";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AKms_FormClosing);
            this.Load += new System.EventHandler(this.AKms_Load);
            this.CmMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiExit;
        private System.Windows.Forms.NotifyIcon NiTray;
        private System.Windows.Forms.ToolStripSeparator MiSep1;
        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.ToolStripMenuItem MiOpts;
        private System.Windows.Forms.ToolTip TpTips;
        private System.Windows.Forms.ToolStripMenuItem MuSolution;
        private System.Windows.Forms.ToolStripMenuItem MiTalk;
        private System.Windows.Forms.ToolStripMenuItem MuTarget;
        private System.Windows.Forms.ToolStripMenuItem MiTarget;
        private System.Windows.Forms.ToolStripSeparator MiTargetSep;
        private System.Windows.Forms.ToolStripSeparator MiSep3;
        private System.Windows.Forms.ToolStripSeparator MiSep2;
        private System.Windows.Forms.ToolStripMenuItem MiWork;
        private System.Windows.Forms.ToolStripMenuItem MiHalt;
        private System.Windows.Forms.ToolStripMenuItem MiNext;
        private System.Windows.Forms.ToolStripMenuItem MiStop;
        private System.Windows.Forms.ToolStripMenuItem MuMethod;
        private System.Windows.Forms.ToolStripMenuItem MiMethod;
        private System.Windows.Forms.ToolStripMenuItem MiAnswer;
        private System.Windows.Forms.ToolStripMenuItem MiActive;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MiAttack;
        private System.Windows.Forms.ToolStripMenuItem MiTray;
        private System.Windows.Forms.ToolStripSeparator MiSep4;
        private System.Windows.Forms.ToolStripMenuItem MiAction;
    }
}
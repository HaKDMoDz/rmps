namespace Me.Amon.Kms.V.Uc
{
    partial class PostAction
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
            this.TbAction = new System.Windows.Forms.TextBox();
            this.PbAction = new System.Windows.Forms.PictureBox();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiKeybd = new System.Windows.Forms.ToolStripMenuItem();
            this.MiMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSpecial = new System.Windows.Forms.ToolStripMenuItem();
            this.MiEnter = new System.Windows.Forms.ToolStripMenuItem();
            this.MiBackspace = new System.Windows.Forms.ToolStripMenuItem();
            this.MiHome = new System.Windows.Forms.ToolStripMenuItem();
            this.MiEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.MiInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.MiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiMouse = new System.Windows.Forms.ToolStripMenuItem();
            this.MiRelative = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PbAction)).BeginInit();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbAction
            // 
            this.TbAction.Location = new System.Drawing.Point(0, 0);
            this.TbAction.Name = "TbAction";
            this.TbAction.Size = new System.Drawing.Size(182, 21);
            this.TbAction.TabIndex = 0;
            this.TbAction.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbAction_KeyDown);
            this.TbAction.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbAction_KeyUp);
            this.TbAction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbAction_KeyPress);
            // 
            // PbAction
            // 
            this.PbAction.Image = global::Me.Amon.Properties.Resources._opt;
            this.PbAction.Location = new System.Drawing.Point(188, 3);
            this.PbAction.Name = "PbAction";
            this.PbAction.Size = new System.Drawing.Size(16, 16);
            this.PbAction.TabIndex = 1;
            this.PbAction.TabStop = false;
            this.PbAction.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbAction_MouseMove);
            this.PbAction.Click += new System.EventHandler(this.PbAction_Click);
            this.PbAction.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbAction_MouseDown);
            this.PbAction.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbAction_MouseUp);
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiKeybd,
            this.MiMonitor,
            this.MiSpecial,
            this.toolStripSeparator1,
            this.MiMouse,
            this.MiRelative});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(125, 120);
            // 
            // MiKeybd
            // 
            this.MiKeybd.Checked = true;
            this.MiKeybd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MiKeybd.Name = "MiKeybd";
            this.MiKeybd.Size = new System.Drawing.Size(124, 22);
            this.MiKeybd.Text = "键盘事件";
            this.MiKeybd.Click += new System.EventHandler(this.MiKeybd_Click);
            // 
            // MiMonitor
            // 
            this.MiMonitor.Checked = true;
            this.MiMonitor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MiMonitor.Name = "MiMonitor";
            this.MiMonitor.Size = new System.Drawing.Size(124, 22);
            this.MiMonitor.Text = "主动侦听";
            // 
            // MiSpecial
            // 
            this.MiSpecial.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiEnter,
            this.MiBackspace,
            this.MiHome,
            this.MiEnd,
            this.MiInsert,
            this.MiDelete});
            this.MiSpecial.Name = "MiSpecial";
            this.MiSpecial.Size = new System.Drawing.Size(124, 22);
            this.MiSpecial.Text = "特殊按键";
            // 
            // MiEnter
            // 
            this.MiEnter.Name = "MiEnter";
            this.MiEnter.Size = new System.Drawing.Size(138, 22);
            this.MiEnter.Text = "Enter";
            this.MiEnter.Click += new System.EventHandler(this.MiEnter_Click);
            // 
            // MiBackspace
            // 
            this.MiBackspace.Name = "MiBackspace";
            this.MiBackspace.Size = new System.Drawing.Size(138, 22);
            this.MiBackspace.Text = "Backspace";
            this.MiBackspace.Click += new System.EventHandler(this.MiBackspace_Click);
            // 
            // MiHome
            // 
            this.MiHome.Name = "MiHome";
            this.MiHome.Size = new System.Drawing.Size(138, 22);
            this.MiHome.Text = "Home";
            this.MiHome.Click += new System.EventHandler(this.MiHome_Click);
            // 
            // MiEnd
            // 
            this.MiEnd.Name = "MiEnd";
            this.MiEnd.Size = new System.Drawing.Size(138, 22);
            this.MiEnd.Text = "End";
            this.MiEnd.Click += new System.EventHandler(this.MiEnd_Click);
            // 
            // MiInsert
            // 
            this.MiInsert.Name = "MiInsert";
            this.MiInsert.Size = new System.Drawing.Size(138, 22);
            this.MiInsert.Text = "Insert";
            this.MiInsert.Click += new System.EventHandler(this.MiInsert_Click);
            // 
            // MiDelete
            // 
            this.MiDelete.Name = "MiDelete";
            this.MiDelete.Size = new System.Drawing.Size(138, 22);
            this.MiDelete.Text = "Delete";
            this.MiDelete.Click += new System.EventHandler(this.MiDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // MiMouse
            // 
            this.MiMouse.Name = "MiMouse";
            this.MiMouse.Size = new System.Drawing.Size(124, 22);
            this.MiMouse.Text = "鼠标事件";
            this.MiMouse.Click += new System.EventHandler(this.MiMouse_Click);
            // 
            // MiRelative
            // 
            this.MiRelative.Checked = true;
            this.MiRelative.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MiRelative.Enabled = false;
            this.MiRelative.Name = "MiRelative";
            this.MiRelative.Size = new System.Drawing.Size(124, 22);
            this.MiRelative.Text = "相对位置";
            // 
            // PostAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbAction);
            this.Controls.Add(this.TbAction);
            this.Name = "PostAction";
            this.Size = new System.Drawing.Size(207, 21);
            ((System.ComponentModel.ISupportInitialize)(this.PbAction)).EndInit();
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbAction;
        private System.Windows.Forms.PictureBox PbAction;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiKeybd;
        private System.Windows.Forms.ToolStripMenuItem MiMonitor;
        private System.Windows.Forms.ToolStripMenuItem MiSpecial;
        private System.Windows.Forms.ToolStripMenuItem MiEnter;
        private System.Windows.Forms.ToolStripMenuItem MiBackspace;
        private System.Windows.Forms.ToolStripMenuItem MiHome;
        private System.Windows.Forms.ToolStripMenuItem MiEnd;
        private System.Windows.Forms.ToolStripMenuItem MiInsert;
        private System.Windows.Forms.ToolStripMenuItem MiDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MiMouse;
        private System.Windows.Forms.ToolStripMenuItem MiRelative;
    }
}

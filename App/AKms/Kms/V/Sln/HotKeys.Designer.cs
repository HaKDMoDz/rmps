namespace Me.Amon.Kms.V.Sln
{
    partial class HotKeys
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
            this.TbKeys = new System.Windows.Forms.TextBox();
            this.PbKeys = new System.Windows.Forms.PictureBox();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiEnter = new System.Windows.Forms.ToolStripMenuItem();
            this.MiBackspace = new System.Windows.Forms.ToolStripMenuItem();
            this.MiHome = new System.Windows.Forms.ToolStripMenuItem();
            this.MiEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.MiInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.MiDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PbKeys)).BeginInit();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbKeys
            // 
            this.TbKeys.Location = new System.Drawing.Point(0, 0);
            this.TbKeys.Name = "TbKeys";
            this.TbKeys.Size = new System.Drawing.Size(182, 21);
            this.TbKeys.TabIndex = 0;
            this.TbKeys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbKeys_KeyDown);
            this.TbKeys.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbKeys_KeyUp);
            this.TbKeys.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbKeys_KeyPress);
            // 
            // PbKeys
            // 
            this.PbKeys.Image = global::Me.Amon.Properties.Resources._opt;
            this.PbKeys.Location = new System.Drawing.Point(188, 3);
            this.PbKeys.Name = "PbKeys";
            this.PbKeys.Size = new System.Drawing.Size(16, 16);
            this.PbKeys.TabIndex = 1;
            this.PbKeys.TabStop = false;
            this.PbKeys.Click += new System.EventHandler(this.PbKeys_Click);
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiMonitor,
            this.MiSep1,
            this.MiEnter,
            this.MiBackspace,
            this.MiHome,
            this.MiEnd,
            this.MiInsert,
            this.MiDelete});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(139, 164);
            // 
            // MiMonitor
            // 
            this.MiMonitor.Name = "MiMonitor";
            this.MiMonitor.Size = new System.Drawing.Size(138, 22);
            this.MiMonitor.Text = "主动侦听";
            this.MiMonitor.Click += new System.EventHandler(this.MiMonitor_Click);
            // 
            // MiSep1
            // 
            this.MiSep1.Name = "MiSep1";
            this.MiSep1.Size = new System.Drawing.Size(135, 6);
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
            // HotKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbKeys);
            this.Controls.Add(this.TbKeys);
            this.Name = "HotKeys";
            this.Size = new System.Drawing.Size(207, 21);
            ((System.ComponentModel.ISupportInitialize)(this.PbKeys)).EndInit();
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbKeys;
        private System.Windows.Forms.PictureBox PbKeys;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiMonitor;
        private System.Windows.Forms.ToolStripSeparator MiSep1;
        private System.Windows.Forms.ToolStripMenuItem MiEnter;
        private System.Windows.Forms.ToolStripMenuItem MiBackspace;
        private System.Windows.Forms.ToolStripMenuItem MiHome;
        private System.Windows.Forms.ToolStripMenuItem MiEnd;
        private System.Windows.Forms.ToolStripMenuItem MiInsert;
        private System.Windows.Forms.ToolStripMenuItem MiDelete;
    }
}

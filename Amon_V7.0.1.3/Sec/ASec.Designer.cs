namespace Me.Amon.Sec
{
    partial class ASec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ASec));
            this.LbInfo = new System.Windows.Forms.Label();
            this.BtDo = new System.Windows.Forms.Button();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.PbMenu = new System.Windows.Forms.PictureBox();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.MiWiz = new System.Windows.Forms.ToolStripMenuItem();
            this.MiPro = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).BeginInit();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbInfo
            // 
            this.LbInfo.AutoSize = true;
            this.LbInfo.Location = new System.Drawing.Point(36, 275);
            this.LbInfo.Name = "LbInfo";
            this.LbInfo.Size = new System.Drawing.Size(0, 12);
            this.LbInfo.TabIndex = 2;
            // 
            // BtDo
            // 
            this.BtDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtDo.Location = new System.Drawing.Point(177, 270);
            this.BtDo.Name = "BtDo";
            this.BtDo.Size = new System.Drawing.Size(75, 23);
            this.BtDo.TabIndex = 1;
            this.BtDo.Text = "执行(&R)";
            this.BtDo.UseVisualStyleBackColor = true;
            this.BtDo.Click += new System.EventHandler(this.BtDo_Click);
            // 
            // Worker
            // 
            this.Worker.WorkerSupportsCancellation = true;
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DoWorkerCompleted);
            // 
            // PbMenu
            // 
            this.PbMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PbMenu.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbMenu.Location = new System.Drawing.Point(12, 272);
            this.PbMenu.Name = "PbMenu";
            this.PbMenu.Size = new System.Drawing.Size(18, 18);
            this.PbMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PbMenu.TabIndex = 3;
            this.PbMenu.TabStop = false;
            this.PbMenu.Visible = false;
            this.PbMenu.Click += new System.EventHandler(this.PbMenu_Click);
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiOpen,
            this.MiSave,
            this.MiSep0,
            this.MiWiz,
            this.MiPro});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(145, 98);
            // 
            // MiOpen
            // 
            this.MiOpen.Name = "MiOpen";
            this.MiOpen.Size = new System.Drawing.Size(144, 22);
            this.MiOpen.Text = "打开(&O)";
            this.MiOpen.Click += new System.EventHandler(this.MiLoad_Click);
            // 
            // MiSave
            // 
            this.MiSave.Name = "MiSave";
            this.MiSave.Size = new System.Drawing.Size(144, 22);
            this.MiSave.Text = "保存(&S)";
            this.MiSave.Click += new System.EventHandler(this.MiSave_Click);
            // 
            // MiSep0
            // 
            this.MiSep0.Name = "MiSep0";
            this.MiSep0.Size = new System.Drawing.Size(141, 6);
            // 
            // MiWiz
            // 
            this.MiWiz.Name = "MiWiz";
            this.MiWiz.Size = new System.Drawing.Size(144, 22);
            this.MiWiz.Text = "向导模式(&W)";
            this.MiWiz.Click += new System.EventHandler(this.MiWiz_Click);
            // 
            // MiPro
            // 
            this.MiPro.Name = "MiPro";
            this.MiPro.Size = new System.Drawing.Size(144, 22);
            this.MiPro.Text = "专业模式(&P)";
            this.MiPro.Click += new System.EventHandler(this.MiPro_Click);
            // 
            // ASec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 305);
            this.Controls.Add(this.BtDo);
            this.Controls.Add(this.PbMenu);
            this.Controls.Add(this.LbInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ASec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "阿木加密器";
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).EndInit();
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtDo;
        private System.Windows.Forms.Label LbInfo;
        private System.ComponentModel.BackgroundWorker Worker;
        private System.Windows.Forms.ToolTip TpTips;
        private System.Windows.Forms.PictureBox PbMenu;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiWiz;
        private System.Windows.Forms.ToolStripMenuItem MiPro;
        private System.Windows.Forms.ToolStripSeparator MiSep0;
        private System.Windows.Forms.ToolStripMenuItem MiOpen;
        private System.Windows.Forms.ToolStripMenuItem MiSave;
    }
}
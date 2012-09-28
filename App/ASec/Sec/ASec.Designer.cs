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
            this.PlMain = new System.Windows.Forms.Panel();
            this.PbMenu = new System.Windows.Forms.PictureBox();
            this.LlEcho = new System.Windows.Forms.Label();
            this.BtDo = new System.Windows.Forms.Button();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CmSrc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CmDst = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // PlMain
            // 
            this.PlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlMain.Location = new System.Drawing.Point(12, 12);
            this.PlMain.Name = "PlMain";
            this.PlMain.Size = new System.Drawing.Size(370, 219);
            this.PlMain.TabIndex = 0;
            // 
            // PbMenu
            // 
            this.PbMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PbMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbMenu.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbMenu.Location = new System.Drawing.Point(12, 239);
            this.PbMenu.Name = "PbMenu";
            this.PbMenu.Size = new System.Drawing.Size(18, 18);
            this.PbMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PbMenu.TabIndex = 1;
            this.PbMenu.TabStop = false;
            this.TpTips.SetToolTip(this.PbMenu, "选单");
            this.PbMenu.Click += new System.EventHandler(this.PbMenu_Click);
            // 
            // LlEcho
            // 
            this.LlEcho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LlEcho.AutoSize = true;
            this.LlEcho.Location = new System.Drawing.Point(36, 242);
            this.LlEcho.Name = "LlEcho";
            this.LlEcho.Size = new System.Drawing.Size(0, 12);
            this.LlEcho.TabIndex = 2;
            // 
            // BtDo
            // 
            this.BtDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtDo.Location = new System.Drawing.Point(307, 237);
            this.BtDo.Name = "BtDo";
            this.BtDo.Size = new System.Drawing.Size(75, 23);
            this.BtDo.TabIndex = 3;
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
            // CmMenu
            // 
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // CmSrc
            // 
            this.CmSrc.Name = "CmSrc";
            this.CmSrc.Size = new System.Drawing.Size(61, 4);
            // 
            // CmDst
            // 
            this.CmDst.Name = "CmDst";
            this.CmDst.Size = new System.Drawing.Size(61, 4);
            // 
            // ASec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 272);
            this.Controls.Add(this.PlMain);
            this.Controls.Add(this.PbMenu);
            this.Controls.Add(this.LlEcho);
            this.Controls.Add(this.BtDo);
            this.Name = "ASec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "阿木加密器";
            this.Load += new System.EventHandler(this.ASec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PlMain;
        private System.Windows.Forms.PictureBox PbMenu;
        private System.Windows.Forms.Label LlEcho;
        private System.Windows.Forms.Button BtDo;
        private System.Windows.Forms.ToolTip TpTips;
        private System.ComponentModel.BackgroundWorker Worker;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ContextMenuStrip CmSrc;
        private System.Windows.Forms.ContextMenuStrip CmDst;
    }
}
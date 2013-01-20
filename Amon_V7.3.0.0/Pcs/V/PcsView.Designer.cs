namespace Me.Amon.Pcs.V
{
    partial class PcsView
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
            this.ScMain = new System.Windows.Forms.SplitContainer();
            this.ScView = new System.Windows.Forms.SplitContainer();
            this.TvPath = new System.Windows.Forms.TreeView();
            this.LvMeta = new System.Windows.Forms.ListView();
            this.BwWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).BeginInit();
            this.ScMain.Panel1.SuspendLayout();
            this.ScMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScView)).BeginInit();
            this.ScView.Panel1.SuspendLayout();
            this.ScView.Panel2.SuspendLayout();
            this.ScView.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScMain
            // 
            this.ScMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScMain.Location = new System.Drawing.Point(3, 3);
            this.ScMain.Name = "ScMain";
            this.ScMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ScMain.Panel1
            // 
            this.ScMain.Panel1.Controls.Add(this.ScView);
            this.ScMain.Panel2Collapsed = true;
            this.ScMain.Size = new System.Drawing.Size(394, 294);
            this.ScMain.SplitterDistance = 240;
            this.ScMain.TabIndex = 0;
            // 
            // ScView
            // 
            this.ScView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScView.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ScView.Location = new System.Drawing.Point(0, 0);
            this.ScView.Name = "ScView";
            // 
            // ScView.Panel1
            // 
            this.ScView.Panel1.Controls.Add(this.TvPath);
            // 
            // ScView.Panel2
            // 
            this.ScView.Panel2.Controls.Add(this.LvMeta);
            this.ScView.Size = new System.Drawing.Size(394, 294);
            this.ScView.SplitterDistance = 160;
            this.ScView.TabIndex = 0;
            // 
            // TvPath
            // 
            this.TvPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvPath.HideSelection = false;
            this.TvPath.Location = new System.Drawing.Point(0, 0);
            this.TvPath.Name = "TvPath";
            this.TvPath.Size = new System.Drawing.Size(160, 294);
            this.TvPath.TabIndex = 0;
            this.TvPath.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvPath_AfterSelect);
            // 
            // LvMeta
            // 
            this.LvMeta.AllowDrop = true;
            this.LvMeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvMeta.Location = new System.Drawing.Point(0, 0);
            this.LvMeta.Name = "LvMeta";
            this.LvMeta.Size = new System.Drawing.Size(230, 294);
            this.LvMeta.TabIndex = 0;
            this.LvMeta.UseCompatibleStateImageBehavior = false;
            this.LvMeta.SelectedIndexChanged += new System.EventHandler(this.LvMeta_SelectedIndexChanged);
            this.LvMeta.DragDrop += new System.Windows.Forms.DragEventHandler(this.LvMeta_DragDrop);
            this.LvMeta.DragEnter += new System.Windows.Forms.DragEventHandler(this.LvMeta_DragEnter);
            this.LvMeta.DoubleClick += new System.EventHandler(this.LvMeta_DoubleClick);
            this.LvMeta.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LvMeta_MouseUp);
            // 
            // BwWorker
            // 
            this.BwWorker.WorkerReportsProgress = true;
            this.BwWorker.WorkerSupportsCancellation = true;
            this.BwWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwWorker_DoWork);
            this.BwWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BwWorker_ProgressChanged);
            this.BwWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwWorker_RunWorkerCompleted);
            // 
            // PcsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ScMain);
            this.Name = "PcsView";
            this.Size = new System.Drawing.Size(400, 300);
            this.ScMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).EndInit();
            this.ScMain.ResumeLayout(false);
            this.ScView.Panel1.ResumeLayout(false);
            this.ScView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScView)).EndInit();
            this.ScView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer ScMain;
        private System.Windows.Forms.SplitContainer ScView;
        private System.Windows.Forms.TreeView TvPath;
        private System.Windows.Forms.ListView LvMeta;
        private System.ComponentModel.BackgroundWorker BwWorker;
    }
}

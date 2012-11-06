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
            this.components = new System.ComponentModel.Container();
            this.ScMain = new System.Windows.Forms.SplitContainer();
            this.ScView = new System.Windows.Forms.SplitContainer();
            this.TvPath = new System.Windows.Forms.TreeView();
            this.LvMeta = new System.Windows.Forms.ListView();
            this.LbInfo = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).BeginInit();
            this.ScMain.Panel1.SuspendLayout();
            this.ScMain.Panel2.SuspendLayout();
            this.ScMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScView)).BeginInit();
            this.ScView.Panel1.SuspendLayout();
            this.ScView.Panel2.SuspendLayout();
            this.ScView.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScMain
            // 
            this.ScMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScMain.Location = new System.Drawing.Point(0, 0);
            this.ScMain.Name = "ScMain";
            this.ScMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ScMain.Panel1
            // 
            this.ScMain.Panel1.Controls.Add(this.ScView);
            // 
            // ScMain.Panel2
            // 
            this.ScMain.Panel2.Controls.Add(this.LbInfo);
            this.ScMain.Size = new System.Drawing.Size(400, 300);
            this.ScMain.SplitterDistance = 209;
            this.ScMain.TabIndex = 0;
            // 
            // ScView
            // 
            this.ScView.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.ScView.Size = new System.Drawing.Size(400, 209);
            this.ScView.SplitterDistance = 133;
            this.ScView.TabIndex = 0;
            // 
            // TvPath
            // 
            this.TvPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvPath.ImageIndex = 0;
            this.TvPath.Location = new System.Drawing.Point(0, 0);
            this.TvPath.Name = "TvPath";
            this.TvPath.SelectedImageIndex = 0;
            this.TvPath.Size = new System.Drawing.Size(133, 209);
            this.TvPath.TabIndex = 0;
            // 
            // LvMeta
            // 
            this.LvMeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvMeta.Location = new System.Drawing.Point(0, 0);
            this.LvMeta.Name = "LvMeta";
            this.LvMeta.Size = new System.Drawing.Size(263, 209);
            this.LvMeta.TabIndex = 0;
            this.LvMeta.UseCompatibleStateImageBehavior = false;
            // 
            // LbInfo
            // 
            this.LbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbInfo.FormattingEnabled = true;
            this.LbInfo.ItemHeight = 12;
            this.LbInfo.Location = new System.Drawing.Point(0, 0);
            this.LbInfo.Name = "LbInfo";
            this.LbInfo.Size = new System.Drawing.Size(400, 87);
            this.LbInfo.TabIndex = 0;
            // 
            // TabPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ScMain);
            this.Name = "TabPage";
            this.Size = new System.Drawing.Size(400, 300);
            this.ScMain.Panel1.ResumeLayout(false);
            this.ScMain.Panel2.ResumeLayout(false);
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
        private System.Windows.Forms.ListBox LbInfo;
        private System.Windows.Forms.TreeView TvPath;
        private System.Windows.Forms.ListView LvMeta;
    }
}

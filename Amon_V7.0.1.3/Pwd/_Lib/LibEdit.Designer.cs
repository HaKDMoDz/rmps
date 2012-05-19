namespace Me.Amon.Pwd._Lib
{
    partial class LibEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibEdit));
            this.TvLibView = new System.Windows.Forms.TreeView();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiAppendLibd = new System.Windows.Forms.ToolStripMenuItem();
            this.MiDeleteLibd = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.MiAppendLibh = new System.Windows.Forms.ToolStripMenuItem();
            this.MiDeleteLibh = new System.Windows.Forms.ToolStripMenuItem();
            this.BtUpdate = new System.Windows.Forms.Button();
            this.BtCancel = new System.Windows.Forms.Button();
            this.GbGroup = new System.Windows.Forms.GroupBox();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TvLibView
            // 
            this.TvLibView.ContextMenuStrip = this.CmMenu;
            this.TvLibView.Location = new System.Drawing.Point(12, 12);
            this.TvLibView.Name = "TvLibView";
            this.TvLibView.Size = new System.Drawing.Size(141, 209);
            this.TvLibView.TabIndex = 0;
            this.TvLibView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvLibTree_AfterSelect);
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiAppendLibd,
            this.MiDeleteLibd,
            this.MiSep0,
            this.MiAppendLibh,
            this.MiDeleteLibh});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(153, 120);
            // 
            // MiAppendLibd
            // 
            this.MiAppendLibd.Name = "MiAppendLibd";
            this.MiAppendLibd.Size = new System.Drawing.Size(152, 22);
            this.MiAppendLibd.Text = "添加属性(&1)";
            this.MiAppendLibd.Click += new System.EventHandler(this.MiAppendLibd_Click);
            // 
            // MiDeleteLibd
            // 
            this.MiDeleteLibd.Name = "MiDeleteLibd";
            this.MiDeleteLibd.Size = new System.Drawing.Size(152, 22);
            this.MiDeleteLibd.Text = "删除属性(&2)";
            this.MiDeleteLibd.Click += new System.EventHandler(this.MiDeleteLibd_Click);
            // 
            // MiSep0
            // 
            this.MiSep0.Name = "MiSep0";
            this.MiSep0.Size = new System.Drawing.Size(149, 6);
            // 
            // MiAppendLibh
            // 
            this.MiAppendLibh.Name = "MiAppendLibh";
            this.MiAppendLibh.Size = new System.Drawing.Size(152, 22);
            this.MiAppendLibh.Text = "添加模板(&3)";
            this.MiAppendLibh.Click += new System.EventHandler(this.MiAppendLibh_Click);
            // 
            // MiDeleteLibh
            // 
            this.MiDeleteLibh.Name = "MiDeleteLibh";
            this.MiDeleteLibh.Size = new System.Drawing.Size(152, 22);
            this.MiDeleteLibh.Text = "删除模板(&4)";
            this.MiDeleteLibh.Click += new System.EventHandler(this.MiDeleteLibh_Click);
            // 
            // BtUpdate
            // 
            this.BtUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtUpdate.Location = new System.Drawing.Point(246, 227);
            this.BtUpdate.Name = "BtUpdate";
            this.BtUpdate.Size = new System.Drawing.Size(75, 23);
            this.BtUpdate.TabIndex = 2;
            this.BtUpdate.Text = "保存(&S)";
            this.BtUpdate.UseVisualStyleBackColor = true;
            this.BtUpdate.Click += new System.EventHandler(this.BtUpdate_Click);
            // 
            // BtCancel
            // 
            this.BtCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtCancel.Location = new System.Drawing.Point(327, 227);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(75, 23);
            this.BtCancel.TabIndex = 3;
            this.BtCancel.Text = "取消(&C)";
            this.BtCancel.UseVisualStyleBackColor = true;
            this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // GbGroup
            // 
            this.GbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbGroup.Location = new System.Drawing.Point(159, 12);
            this.GbGroup.Name = "GbGroup";
            this.GbGroup.Size = new System.Drawing.Size(243, 209);
            this.GbGroup.TabIndex = 4;
            this.GbGroup.TabStop = false;
            this.GbGroup.Text = "信息";
            // 
            // LibEdit
            // 
            this.AcceptButton = this.BtUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtCancel;
            this.ClientSize = new System.Drawing.Size(414, 262);
            this.Controls.Add(this.GbGroup);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.TvLibView);
            this.Controls.Add(this.BtUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LibEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模板管理";
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TvLibView;
        private System.Windows.Forms.Button BtUpdate;
        private System.Windows.Forms.Button BtCancel;
        private System.Windows.Forms.GroupBox GbGroup;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiAppendLibh;
        private System.Windows.Forms.ToolStripMenuItem MiDeleteLibh;
        private System.Windows.Forms.ToolStripSeparator MiSep0;
        private System.Windows.Forms.ToolStripMenuItem MiAppendLibd;
        private System.Windows.Forms.ToolStripMenuItem MiDeleteLibd;
    }
}
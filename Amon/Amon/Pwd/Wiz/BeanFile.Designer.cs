namespace Me.Amon.Pwd.Wiz
{
    partial class BeanFile
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
            this.TbData = new System.Windows.Forms.TextBox();
            this.BtOpen = new System.Windows.Forms.Button();
            this.BtView = new System.Windows.Forms.Button();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiSysViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.MiPwdViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbData
            // 
            this.TbData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbData.Location = new System.Drawing.Point(0, 0);
            this.TbData.Name = "TbData";
            this.TbData.Size = new System.Drawing.Size(293, 21);
            this.TbData.TabIndex = 0;
            // 
            // BtOpen
            // 
            this.BtOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtOpen.Location = new System.Drawing.Point(326, 0);
            this.BtOpen.Name = "BtOpen";
            this.BtOpen.Size = new System.Drawing.Size(21, 21);
            this.BtOpen.TabIndex = 2;
            this.BtOpen.Text = "button1";
            this.BtOpen.UseVisualStyleBackColor = true;
            this.BtOpen.Click += new System.EventHandler(this.BtOpen_Click);
            // 
            // BtView
            // 
            this.BtView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtView.Location = new System.Drawing.Point(299, 0);
            this.BtView.Name = "BtView";
            this.BtView.Size = new System.Drawing.Size(21, 21);
            this.BtView.TabIndex = 1;
            this.BtView.Text = "button2";
            this.BtView.UseVisualStyleBackColor = true;
            this.BtView.Click += new System.EventHandler(this.BtView_Click);
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiPwdViewer,
            this.MiSysViewer});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // MiSysViewer
            // 
            this.MiSysViewer.Name = "MiSysViewer";
            this.MiSysViewer.Size = new System.Drawing.Size(152, 22);
            this.MiSysViewer.Text = "系统查看器";
            this.MiSysViewer.Click += new System.EventHandler(this.MiSysViewer_Click);
            // 
            // MiPwdViewer
            // 
            this.MiPwdViewer.Name = "MiPwdViewer";
            this.MiPwdViewer.Size = new System.Drawing.Size(152, 22);
            this.MiPwdViewer.Text = "内置查看器";
            this.MiPwdViewer.Click += new System.EventHandler(this.MiPwdViewer_Click);
            // 
            // BeanFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtView);
            this.Controls.Add(this.BtOpen);
            this.Controls.Add(this.TbData);
            this.Name = "BeanFile";
            this.Size = new System.Drawing.Size(350, 24);
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbData;
        private System.Windows.Forms.Button BtOpen;
        private System.Windows.Forms.Button BtView;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiSysViewer;
        private System.Windows.Forms.ToolStripMenuItem MiPwdViewer;
    }
}

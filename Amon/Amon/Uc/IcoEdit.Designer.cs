namespace Me.Amon.Uc
{
    partial class IcoEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IcoEdit));
            this.LvIco = new System.Windows.Forms.ListView();
            this.BtChoose = new System.Windows.Forms.Button();
            this.BtAppend = new System.Windows.Forms.Button();
            this.BtCancel = new System.Windows.Forms.Button();
            this.LbDir = new System.Windows.Forms.ListBox();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiAppend = new System.Windows.Forms.ToolStripMenuItem();
            this.MiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.MiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LvIco
            // 
            this.LvIco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LvIco.Location = new System.Drawing.Point(138, 12);
            this.LvIco.Name = "LvIco";
            this.LvIco.Size = new System.Drawing.Size(244, 220);
            this.LvIco.TabIndex = 1;
            this.LvIco.UseCompatibleStateImageBehavior = false;
            this.LvIco.View = System.Windows.Forms.View.SmallIcon;
            // 
            // BtChoose
            // 
            this.BtChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtChoose.Location = new System.Drawing.Point(145, 238);
            this.BtChoose.Name = "BtChoose";
            this.BtChoose.Size = new System.Drawing.Size(75, 23);
            this.BtChoose.TabIndex = 2;
            this.BtChoose.Text = "选择(&S)";
            this.BtChoose.UseVisualStyleBackColor = true;
            this.BtChoose.Click += new System.EventHandler(this.BtChoose_Click);
            // 
            // BtAppend
            // 
            this.BtAppend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtAppend.Location = new System.Drawing.Point(226, 238);
            this.BtAppend.Name = "BtAppend";
            this.BtAppend.Size = new System.Drawing.Size(75, 23);
            this.BtAppend.TabIndex = 3;
            this.BtAppend.Text = "追加(&A)";
            this.BtAppend.UseVisualStyleBackColor = true;
            this.BtAppend.Click += new System.EventHandler(this.BtAppend_Click);
            // 
            // BtCancel
            // 
            this.BtCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtCancel.Location = new System.Drawing.Point(307, 238);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(75, 23);
            this.BtCancel.TabIndex = 4;
            this.BtCancel.Text = "取消(&C)";
            this.BtCancel.UseVisualStyleBackColor = true;
            this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // LbDir
            // 
            this.LbDir.ContextMenuStrip = this.CmMenu;
            this.LbDir.FormattingEnabled = true;
            this.LbDir.ItemHeight = 12;
            this.LbDir.Location = new System.Drawing.Point(12, 12);
            this.LbDir.Name = "LbDir";
            this.LbDir.Size = new System.Drawing.Size(120, 220);
            this.LbDir.TabIndex = 0;
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiAppend,
            this.MiUpdate,
            this.MiDelete});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(153, 92);
            // 
            // MiAppend
            // 
            this.MiAppend.Name = "MiAppend";
            this.MiAppend.Size = new System.Drawing.Size(152, 22);
            this.MiAppend.Text = "添加分类(&A)";
            this.MiAppend.Click += new System.EventHandler(this.MiAppend_Click);
            // 
            // MiUpdate
            // 
            this.MiUpdate.Name = "MiUpdate";
            this.MiUpdate.Size = new System.Drawing.Size(152, 22);
            this.MiUpdate.Text = "更新分类(&U)";
            this.MiUpdate.Click += new System.EventHandler(this.MiUpdate_Click);
            // 
            // MiDelete
            // 
            this.MiDelete.Name = "MiDelete";
            this.MiDelete.Size = new System.Drawing.Size(152, 22);
            this.MiDelete.Text = "删除分类(&D)";
            this.MiDelete.Click += new System.EventHandler(this.MiDelete_Click);
            // 
            // IcoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 273);
            this.Controls.Add(this.LbDir);
            this.Controls.Add(this.LvIco);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.BtAppend);
            this.Controls.Add(this.BtChoose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IcoEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图标管理";
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LvIco;
        private System.Windows.Forms.Button BtChoose;
        private System.Windows.Forms.Button BtAppend;
        private System.Windows.Forms.Button BtCancel;
        private System.Windows.Forms.ListBox LbDir;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiAppend;
        private System.Windows.Forms.ToolStripMenuItem MiUpdate;
        private System.Windows.Forms.ToolStripMenuItem MiDelete;
    }
}
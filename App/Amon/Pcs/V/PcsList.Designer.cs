namespace Me.Amon.Pcs.V
{
    partial class PcsList
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
            this.LbItem = new System.Windows.Forms.ListBox();
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.TbMemo = new System.Windows.Forms.TextBox();
            this.BnOpen = new System.Windows.Forms.Button();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MiVerify = new System.Windows.Forms.ToolStripMenuItem();
            this.MiDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbItem
            // 
            this.LbItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LbItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LbItem.FormattingEnabled = true;
            this.LbItem.IntegralHeight = false;
            this.LbItem.ItemHeight = 32;
            this.LbItem.Location = new System.Drawing.Point(3, 3);
            this.LbItem.Name = "LbItem";
            this.LbItem.Size = new System.Drawing.Size(160, 294);
            this.LbItem.TabIndex = 0;
            this.LbItem.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LbItem_DrawItem);
            this.LbItem.SelectedIndexChanged += new System.EventHandler(this.LbItem_SelectedIndexChanged);
            this.LbItem.DoubleClick += new System.EventHandler(this.LbItem_DoubleClick);
            this.LbItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LbItem_MouseUp);
            // 
            // PbLogo
            // 
            this.PbLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PbLogo.Location = new System.Drawing.Point(169, 3);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(228, 128);
            this.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PbLogo.TabIndex = 1;
            this.PbLogo.TabStop = false;
            // 
            // TbMemo
            // 
            this.TbMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbMemo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbMemo.Location = new System.Drawing.Point(169, 137);
            this.TbMemo.Multiline = true;
            this.TbMemo.Name = "TbMemo";
            this.TbMemo.ReadOnly = true;
            this.TbMemo.Size = new System.Drawing.Size(228, 131);
            this.TbMemo.TabIndex = 2;
            // 
            // BnOpen
            // 
            this.BnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnOpen.Location = new System.Drawing.Point(322, 274);
            this.BnOpen.Name = "BnOpen";
            this.BnOpen.Size = new System.Drawing.Size(75, 23);
            this.BnOpen.TabIndex = 3;
            this.BnOpen.Text = "打开(&O)";
            this.BnOpen.UseVisualStyleBackColor = true;
            this.BnOpen.Click += new System.EventHandler(this.BnOpen_Click);
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiCreate,
            this.MiVerify,
            this.MiDelete});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(139, 70);
            // 
            // MiCreate
            // 
            this.MiCreate.Name = "MiCreate";
            this.MiCreate.Size = new System.Drawing.Size(138, 22);
            this.MiCreate.Text = "新建(&N)";
            this.MiCreate.Click += new System.EventHandler(this.MiCreate_Click);
            // 
            // MiVerify
            // 
            this.MiVerify.Name = "MiVerify";
            this.MiVerify.Size = new System.Drawing.Size(138, 22);
            this.MiVerify.Text = "重新授权(&R)";
            this.MiVerify.Click += new System.EventHandler(this.MiVerify_Click);
            // 
            // MiDelete
            // 
            this.MiDelete.Name = "MiDelete";
            this.MiDelete.Size = new System.Drawing.Size(138, 22);
            this.MiDelete.Text = "删除(&D)";
            this.MiDelete.Click += new System.EventHandler(this.MiDelete_Click);
            // 
            // PcsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BnOpen);
            this.Controls.Add(this.TbMemo);
            this.Controls.Add(this.PbLogo);
            this.Controls.Add(this.LbItem);
            this.Name = "PcsList";
            this.Size = new System.Drawing.Size(400, 300);
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LbItem;
        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.TextBox TbMemo;
        private System.Windows.Forms.Button BnOpen;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiCreate;
        private System.Windows.Forms.ToolStripMenuItem MiVerify;
        private System.Windows.Forms.ToolStripMenuItem MiDelete;
    }
}

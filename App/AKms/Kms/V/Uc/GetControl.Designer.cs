namespace Me.Amon.Kms.V.Uc
{
    partial class GetControl
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
            this.LbNum = new System.Windows.Forms.Label();
            this.TbCtl = new System.Windows.Forms.TextBox();
            this.PbCtl = new System.Windows.Forms.PictureBox();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiOnTimeFind = new System.Windows.Forms.ToolStripMenuItem();
            this.MiFocusedCmp = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PbCtl)).BeginInit();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbNum
            // 
            this.LbNum.AutoSize = true;
            this.LbNum.Location = new System.Drawing.Point(3, 7);
            this.LbNum.Name = "LbNum";
            this.LbNum.Size = new System.Drawing.Size(47, 12);
            this.LbNum.TabIndex = 0;
            this.LbNum.Text = "组件(&C)";
            // 
            // TbCtl
            // 
            this.TbCtl.Location = new System.Drawing.Point(56, 3);
            this.TbCtl.Name = "TbCtl";
            this.TbCtl.Size = new System.Drawing.Size(181, 21);
            this.TbCtl.TabIndex = 3;
            this.TpTips.SetToolTip(this.TbCtl, "格式：索引,组件类型");
            // 
            // PbCtl
            // 
            this.PbCtl.Image = global::Me.Amon.Properties.Resources.Find;
            this.PbCtl.Location = new System.Drawing.Point(243, 5);
            this.PbCtl.Name = "PbCtl";
            this.PbCtl.Size = new System.Drawing.Size(16, 16);
            this.PbCtl.TabIndex = 4;
            this.PbCtl.TabStop = false;
            this.PbCtl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbCtl_MouseMove);
            this.PbCtl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbCtl_MouseDown);
            this.PbCtl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbCtl_MouseUp);
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiFocusedCmp,
            this.MiOnTimeFind});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // MiOnTimeFind
            // 
            this.MiOnTimeFind.Name = "MiOnTimeFind";
            this.MiOnTimeFind.Size = new System.Drawing.Size(152, 22);
            this.MiOnTimeFind.Text = "运行时查找";
            this.MiOnTimeFind.Click += new System.EventHandler(this.MiOnTimeFind_Click);
            // 
            // MiFocusedCmp
            // 
            this.MiFocusedCmp.Name = "MiFocusedCmp";
            this.MiFocusedCmp.Size = new System.Drawing.Size(152, 22);
            this.MiFocusedCmp.Text = "焦点组件";
            this.MiFocusedCmp.Click += new System.EventHandler(this.MiFocusedCmp_Click);
            // 
            // GetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbCtl);
            this.Controls.Add(this.TbCtl);
            this.Controls.Add(this.LbNum);
            this.Name = "GetControl";
            this.Size = new System.Drawing.Size(262, 27);
            ((System.ComponentModel.ISupportInitialize)(this.PbCtl)).EndInit();
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbNum;
        private System.Windows.Forms.TextBox TbCtl;
        private System.Windows.Forms.PictureBox PbCtl;
        private System.Windows.Forms.ToolTip TpTips;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiOnTimeFind;
        private System.Windows.Forms.ToolStripMenuItem MiFocusedCmp;
    }
}

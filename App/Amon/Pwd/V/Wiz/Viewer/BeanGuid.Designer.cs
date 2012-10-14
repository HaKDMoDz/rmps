namespace Me.Amon.Pwd.V.Wiz.Viewer
{
    partial class BeanGuid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BeanGuid));
            this.CbLib = new System.Windows.Forms.ComboBox();
            this.LbLib = new System.Windows.Forms.Label();
            this.PbCard = new System.Windows.Forms.PictureBox();
            this.CmCard = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CcHtm = new System.Windows.Forms.ToolStripMenuItem();
            this.CcTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.CcImg = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CcAll = new System.Windows.Forms.ToolStripMenuItem();
            this.UcTips = new Me.Amon.Uc.GtdTips();
            ((System.ComponentModel.ISupportInitialize)(this.PbCard)).BeginInit();
            this.CmCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // CbLib
            // 
            this.CbLib.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbLib.FormattingEnabled = true;
            this.CbLib.Location = new System.Drawing.Point(63, 3);
            this.CbLib.Name = "CbLib";
            this.CbLib.Size = new System.Drawing.Size(121, 20);
            this.CbLib.TabIndex = 3;
            // 
            // LbLib
            // 
            this.LbLib.AutoSize = true;
            this.LbLib.Location = new System.Drawing.Point(10, 6);
            this.LbLib.Name = "LbLib";
            this.LbLib.Size = new System.Drawing.Size(47, 12);
            this.LbLib.TabIndex = 2;
            this.LbLib.Text = "模板(&L)";
            // 
            // PbCard
            // 
            this.PbCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbCard.Location = new System.Drawing.Point(63, 29);
            this.PbCard.Name = "PbCard";
            this.PbCard.Size = new System.Drawing.Size(24, 24);
            this.PbCard.TabIndex = 4;
            this.PbCard.TabStop = false;
            this.PbCard.Click += new System.EventHandler(this.PbCard_Click);
            // 
            // CmCard
            // 
            this.CmCard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CcHtm,
            this.CcTxt,
            this.CcImg,
            this.toolStripSeparator1,
            this.CcAll});
            this.CmCard.Name = "CmCard";
            this.CmCard.Size = new System.Drawing.Size(143, 98);
            // 
            // CcHtm
            // 
            this.CcHtm.Name = "CcHtm";
            this.CcHtm.Size = new System.Drawing.Size(142, 22);
            this.CcHtm.Text = "网页格式(&H)";
            // 
            // CcTxt
            // 
            this.CcTxt.Name = "CcTxt";
            this.CcTxt.Size = new System.Drawing.Size(142, 22);
            this.CcTxt.Text = "文本格式(&T)";
            // 
            // CcImg
            // 
            this.CcImg.Name = "CcImg";
            this.CcImg.Size = new System.Drawing.Size(142, 22);
            this.CcImg.Text = "图像格式(&I)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // CcAll
            // 
            this.CcAll.Name = "CcAll";
            this.CcAll.Size = new System.Drawing.Size(142, 22);
            this.CcAll.Text = "其它格式(&O)";
            // 
            // UcTips
            // 
            this.UcTips.BackColor = System.Drawing.Color.Transparent;
            this.UcTips.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UcTips.BackgroundImage")));
            this.UcTips.Location = new System.Drawing.Point(42, 59);
            this.UcTips.Name = "UcTips";
            this.UcTips.Size = new System.Drawing.Size(270, 208);
            this.UcTips.TabIndex = 5;
            this.UcTips.Visible = false;
            // 
            // BeanGuid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbCard);
            this.Controls.Add(this.CbLib);
            this.Controls.Add(this.UcTips);
            this.Controls.Add(this.LbLib);
            this.Name = "BeanGuid";
            this.Size = new System.Drawing.Size(350, 250);
            ((System.ComponentModel.ISupportInitialize)(this.PbCard)).EndInit();
            this.CmCard.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CbLib;
        private System.Windows.Forms.Label LbLib;
        private System.Windows.Forms.PictureBox PbCard;
        private System.Windows.Forms.ContextMenuStrip CmCard;
        private System.Windows.Forms.ToolStripMenuItem CcHtm;
        private System.Windows.Forms.ToolStripMenuItem CcTxt;
        private System.Windows.Forms.ToolStripMenuItem CcImg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CcAll;
        private Uc.GtdTips UcTips;
    }
}

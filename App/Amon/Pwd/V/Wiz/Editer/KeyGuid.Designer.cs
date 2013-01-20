namespace Me.Amon.Pwd.V.Wiz.Editer
{
    partial class KeyGuid
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
            this.LbLib = new System.Windows.Forms.Label();
            this.PbCard = new System.Windows.Forms.PictureBox();
            this.CmCard = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CcHtm = new System.Windows.Forms.ToolStripMenuItem();
            this.CcTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.CcImg = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CcAll = new System.Windows.Forms.ToolStripMenuItem();
            this.PbFill = new System.Windows.Forms.PictureBox();
            this.UcHint = new Me.Amon.Uc.GtdHint();
            ((System.ComponentModel.ISupportInitialize)(this.PbCard)).BeginInit();
            this.CmCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbFill)).BeginInit();
            this.SuspendLayout();
            // 
            // LbLib
            // 
            this.LbLib.AutoSize = true;
            this.LbLib.Location = new System.Drawing.Point(3, 9);
            this.LbLib.Name = "LbLib";
            this.LbLib.Size = new System.Drawing.Size(47, 12);
            this.LbLib.TabIndex = 2;
            this.LbLib.Text = "操作(&O)";
            // 
            // PbCard
            // 
            this.PbCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbCard.Location = new System.Drawing.Point(93, 3);
            this.PbCard.Name = "PbCard";
            this.PbCard.Size = new System.Drawing.Size(24, 24);
            this.PbCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
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
            this.CmCard.Size = new System.Drawing.Size(141, 98);
            // 
            // CcHtm
            // 
            this.CcHtm.Name = "CcHtm";
            this.CcHtm.Size = new System.Drawing.Size(140, 22);
            this.CcHtm.Text = "网页格式(&H)";
            // 
            // CcTxt
            // 
            this.CcTxt.Name = "CcTxt";
            this.CcTxt.Size = new System.Drawing.Size(140, 22);
            this.CcTxt.Text = "文本格式(&T)";
            // 
            // CcImg
            // 
            this.CcImg.Name = "CcImg";
            this.CcImg.Size = new System.Drawing.Size(140, 22);
            this.CcImg.Text = "图像格式(&I)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // CcAll
            // 
            this.CcAll.Name = "CcAll";
            this.CcAll.Size = new System.Drawing.Size(140, 22);
            this.CcAll.Text = "其它格式(&O)";
            // 
            // PbFill
            // 
            this.PbFill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbFill.Location = new System.Drawing.Point(63, 3);
            this.PbFill.Name = "PbFill";
            this.PbFill.Size = new System.Drawing.Size(24, 24);
            this.PbFill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PbFill.TabIndex = 6;
            this.PbFill.TabStop = false;
            this.PbFill.Click += new System.EventHandler(this.PbFill_Click);
            // 
            // UcHint
            // 
            this.UcHint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UcHint.BackColor = System.Drawing.Color.Transparent;
            this.UcHint.Handler = null;
            this.UcHint.Location = new System.Drawing.Point(25, 32);
            this.UcHint.Name = "UcHint";
            this.UcHint.Size = new System.Drawing.Size(300, 220);
            this.UcHint.TabIndex = 7;
            this.UcHint.Visible = false;
            // 
            // KeyGuid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UcHint);
            this.Controls.Add(this.PbFill);
            this.Controls.Add(this.PbCard);
            this.Controls.Add(this.LbLib);
            this.Name = "KeyGuid";
            this.Size = new System.Drawing.Size(350, 250);
            ((System.ComponentModel.ISupportInitialize)(this.PbCard)).EndInit();
            this.CmCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbFill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbLib;
        private System.Windows.Forms.PictureBox PbCard;
        private System.Windows.Forms.ContextMenuStrip CmCard;
        private System.Windows.Forms.ToolStripMenuItem CcHtm;
        private System.Windows.Forms.ToolStripMenuItem CcTxt;
        private System.Windows.Forms.ToolStripMenuItem CcImg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CcAll;
        private System.Windows.Forms.PictureBox PbFill;
        private Uc.GtdHint UcHint;
    }
}

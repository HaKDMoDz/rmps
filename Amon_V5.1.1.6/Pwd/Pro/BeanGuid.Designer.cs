namespace Me.Amon.Pwd.Pro
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
            this.LbName = new System.Windows.Forms.Label();
            this.CbName = new System.Windows.Forms.ComboBox();
            this.PbCard = new System.Windows.Forms.PictureBox();
            this.CmCard = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CcHtm = new System.Windows.Forms.ToolStripMenuItem();
            this.CcTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.CcImg = new System.Windows.Forms.ToolStripMenuItem();
            this.CcSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.CcAll = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.PbCard)).BeginInit();
            this.CmCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(3, 6);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(47, 12);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "模板(&T)";
            // 
            // CbName
            // 
            this.CbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbName.FormattingEnabled = true;
            this.CbName.Location = new System.Drawing.Point(56, 3);
            this.CbName.Name = "CbName";
            this.CbName.Size = new System.Drawing.Size(121, 20);
            this.CbName.TabIndex = 1;
            // 
            // PbCard
            // 
            this.PbCard.Location = new System.Drawing.Point(56, 29);
            this.PbCard.Name = "PbCard";
            this.PbCard.Size = new System.Drawing.Size(16, 16);
            this.PbCard.TabIndex = 2;
            this.PbCard.TabStop = false;
            this.PbCard.Visible = false;
            this.PbCard.Click += new System.EventHandler(this.PbCard_Click);
            // 
            // CmCard
            // 
            this.CmCard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CcHtm,
            this.CcTxt,
            this.CcImg,
            this.CcSep0,
            this.CcAll});
            this.CmCard.Name = "CmCard";
            this.CmCard.Size = new System.Drawing.Size(153, 120);
            // 
            // CcHtm
            // 
            this.CcHtm.Name = "CcHtm";
            this.CcHtm.Size = new System.Drawing.Size(152, 22);
            this.CcHtm.Text = "网页格式(&H)";
            // 
            // CcTxt
            // 
            this.CcTxt.Name = "CcTxt";
            this.CcTxt.Size = new System.Drawing.Size(152, 22);
            this.CcTxt.Text = "文本格式(&T)";
            // 
            // CcImg
            // 
            this.CcImg.Name = "CcImg";
            this.CcImg.Size = new System.Drawing.Size(152, 22);
            this.CcImg.Text = "图像格式(&I)";
            // 
            // CcSep0
            // 
            this.CcSep0.Name = "CcSep0";
            this.CcSep0.Size = new System.Drawing.Size(149, 6);
            // 
            // CcAll
            // 
            this.CcAll.Name = "CcAll";
            this.CcAll.Size = new System.Drawing.Size(152, 22);
            this.CcAll.Text = "其它格式(&O)";
            // 
            // BeanGuid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbCard);
            this.Controls.Add(this.CbName);
            this.Controls.Add(this.LbName);
            this.Name = "BeanGuid";
            this.Size = new System.Drawing.Size(366, 81);
            ((System.ComponentModel.ISupportInitialize)(this.PbCard)).EndInit();
            this.CmCard.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.ComboBox CbName;
        private System.Windows.Forms.PictureBox PbCard;
        private System.Windows.Forms.ContextMenuStrip CmCard;
        private System.Windows.Forms.ToolStripMenuItem CcHtm;
        private System.Windows.Forms.ToolStripMenuItem CcTxt;
        private System.Windows.Forms.ToolStripMenuItem CcImg;
        private System.Windows.Forms.ToolStripSeparator CcSep0;
        private System.Windows.Forms.ToolStripMenuItem CcAll;
    }
}

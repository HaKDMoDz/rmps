namespace Me.Amon.Sec.V.Wiz
{
    partial class AWiz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AWiz));
            this.LlOpt = new System.Windows.Forms.Label();
            this.CbOpt = new System.Windows.Forms.ComboBox();
            this.PbAlg = new System.Windows.Forms.PictureBox();
            this.LlKey = new System.Windows.Forms.Label();
            this.TbKey = new System.Windows.Forms.TextBox();
            this.PbKey = new System.Windows.Forms.PictureBox();
            this.SbDir = new Me.Amon.Uc.SwitchButton();
            this.ScMain = new System.Windows.Forms.SplitContainer();
            this._UcSrc = new Me.Amon.Sec.V.Wiz.UcSrc();
            this._UcDst = new Me.Amon.Sec.V.Wiz.UcDst();
            ((System.ComponentModel.ISupportInitialize)(this.PbAlg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).BeginInit();
            this.ScMain.Panel1.SuspendLayout();
            this.ScMain.Panel2.SuspendLayout();
            this.ScMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // LlOpt
            // 
            this.LlOpt.AutoSize = true;
            this.LlOpt.Location = new System.Drawing.Point(3, 6);
            this.LlOpt.Name = "LlOpt";
            this.LlOpt.Size = new System.Drawing.Size(47, 12);
            this.LlOpt.TabIndex = 0;
            this.LlOpt.Text = "操作(&O)";
            // 
            // CbOpt
            // 
            this.CbOpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbOpt.FormattingEnabled = true;
            this.CbOpt.Location = new System.Drawing.Point(56, 3);
            this.CbOpt.Name = "CbOpt";
            this.CbOpt.Size = new System.Drawing.Size(100, 20);
            this.CbOpt.TabIndex = 1;
            this.CbOpt.SelectedIndexChanged += new System.EventHandler(this.CbOpt_SelectedIndexChanged);
            // 
            // PbAlg
            // 
            this.PbAlg.Location = new System.Drawing.Point(162, 6);
            this.PbAlg.Name = "PbAlg";
            this.PbAlg.Size = new System.Drawing.Size(16, 16);
            this.PbAlg.TabIndex = 2;
            this.PbAlg.TabStop = false;
            this.PbAlg.Click += new System.EventHandler(this.PbAlg_Click);
            // 
            // LlKey
            // 
            this.LlKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LlKey.AutoSize = true;
            this.LlKey.Location = new System.Drawing.Point(262, 6);
            this.LlKey.Name = "LlKey";
            this.LlKey.Size = new System.Drawing.Size(47, 12);
            this.LlKey.TabIndex = 3;
            this.LlKey.Text = "口令(&K)";
            // 
            // TbKey
            // 
            this.TbKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TbKey.Location = new System.Drawing.Point(315, 3);
            this.TbKey.Name = "TbKey";
            this.TbKey.Size = new System.Drawing.Size(100, 21);
            this.TbKey.TabIndex = 4;
            // 
            // PbKey
            // 
            this.PbKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbKey.Location = new System.Drawing.Point(421, 6);
            this.PbKey.Name = "PbKey";
            this.PbKey.Size = new System.Drawing.Size(16, 16);
            this.PbKey.TabIndex = 5;
            this.PbKey.TabStop = false;
            this.PbKey.Click += new System.EventHandler(this.PbKey_Click);
            // 
            // SbDir
            // 
            this.SbDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SbDir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SbDir.BackgroundImage")));
            this.SbDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SbDir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SbDir.Location = new System.Drawing.Point(443, 3);
            this.SbDir.Name = "SbDir";
            this.SbDir.On = false;
            this.SbDir.Size = new System.Drawing.Size(80, 22);
            this.SbDir.TabIndex = 6;
            this.SbDir.Click += new System.EventHandler(this.SbDir_Click);
            // 
            // ScMain
            // 
            this.ScMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ScMain.Location = new System.Drawing.Point(3, 29);
            this.ScMain.Name = "ScMain";
            // 
            // ScMain.Panel1
            // 
            this.ScMain.Panel1.Controls.Add(this._UcSrc);
            this.ScMain.Panel1MinSize = 125;
            // 
            // ScMain.Panel2
            // 
            this.ScMain.Panel2.Controls.Add(this._UcDst);
            this.ScMain.Panel2MinSize = 125;
            this.ScMain.Size = new System.Drawing.Size(520, 234);
            this.ScMain.SplitterDistance = 258;
            this.ScMain.TabIndex = 7;
            // 
            // _UcSrc
            // 
            this._UcSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this._UcSrc.Location = new System.Drawing.Point(0, 0);
            this._UcSrc.Name = "_UcSrc";
            this._UcSrc.Size = new System.Drawing.Size(258, 234);
            this._UcSrc.TabIndex = 0;
            // 
            // _UcDst
            // 
            this._UcDst.Dock = System.Windows.Forms.DockStyle.Fill;
            this._UcDst.Location = new System.Drawing.Point(0, 0);
            this._UcDst.Name = "_UcDst";
            this._UcDst.Size = new System.Drawing.Size(258, 234);
            this._UcDst.TabIndex = 0;
            // 
            // AWiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ScMain);
            this.Controls.Add(this.SbDir);
            this.Controls.Add(this.PbKey);
            this.Controls.Add(this.TbKey);
            this.Controls.Add(this.LlKey);
            this.Controls.Add(this.PbAlg);
            this.Controls.Add(this.CbOpt);
            this.Controls.Add(this.LlOpt);
            this.Name = "AWiz";
            this.Size = new System.Drawing.Size(526, 266);
            ((System.ComponentModel.ISupportInitialize)(this.PbAlg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbKey)).EndInit();
            this.ScMain.Panel1.ResumeLayout(false);
            this.ScMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).EndInit();
            this.ScMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LlOpt;
        private System.Windows.Forms.ComboBox CbOpt;
        private System.Windows.Forms.PictureBox PbAlg;
        private System.Windows.Forms.Label LlKey;
        private System.Windows.Forms.TextBox TbKey;
        private System.Windows.Forms.PictureBox PbKey;
        private Me.Amon.Uc.SwitchButton SbDir;
        private System.Windows.Forms.SplitContainer ScMain;
        private UcSrc _UcSrc;
        private UcDst _UcDst;


    }
}

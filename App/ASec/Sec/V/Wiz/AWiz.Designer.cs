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
            this.ScMain = new System.Windows.Forms.SplitContainer();
            this.PlSrc = new System.Windows.Forms.Panel();
            this._UcSrc = new Me.Amon.Sec.V.Wiz.UcSrc();
            this.PbOpt = new System.Windows.Forms.PictureBox();
            this.CbOpt = new System.Windows.Forms.ComboBox();
            this.LlOpt = new System.Windows.Forms.Label();
            this.PlDst = new System.Windows.Forms.Panel();
            this.PbDir = new System.Windows.Forms.PictureBox();
            this._UcDst = new Me.Amon.Sec.V.Wiz.UcDst();
            this.PbKey = new System.Windows.Forms.PictureBox();
            this.TbKey = new System.Windows.Forms.TextBox();
            this.LlKey = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).BeginInit();
            this.ScMain.Panel1.SuspendLayout();
            this.ScMain.Panel2.SuspendLayout();
            this.ScMain.SuspendLayout();
            this.PlSrc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbOpt)).BeginInit();
            this.PlDst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbKey)).BeginInit();
            this.SuspendLayout();
            // 
            // ScMain
            // 
            this.ScMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScMain.Location = new System.Drawing.Point(0, 0);
            this.ScMain.Name = "ScMain";
            // 
            // ScMain.Panel1
            // 
            this.ScMain.Panel1.Controls.Add(this.PlSrc);
            this.ScMain.Panel1MinSize = 180;
            // 
            // ScMain.Panel2
            // 
            this.ScMain.Panel2.Controls.Add(this.PlDst);
            this.ScMain.Panel2MinSize = 200;
            this.ScMain.Size = new System.Drawing.Size(526, 266);
            this.ScMain.SplitterDistance = 261;
            this.ScMain.TabIndex = 0;
            this.ScMain.TabStop = false;
            // 
            // PlSrc
            // 
            this.PlSrc.Controls.Add(this._UcSrc);
            this.PlSrc.Controls.Add(this.PbOpt);
            this.PlSrc.Controls.Add(this.CbOpt);
            this.PlSrc.Controls.Add(this.LlOpt);
            this.PlSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlSrc.Location = new System.Drawing.Point(0, 0);
            this.PlSrc.Name = "PlSrc";
            this.PlSrc.Size = new System.Drawing.Size(261, 266);
            this.PlSrc.TabIndex = 0;
            // 
            // _UcSrc
            // 
            this._UcSrc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._UcSrc.Location = new System.Drawing.Point(3, 30);
            this._UcSrc.Name = "_UcSrc";
            this._UcSrc.Size = new System.Drawing.Size(255, 233);
            this._UcSrc.TabIndex = 3;
            // 
            // PbOpt
            // 
            this.PbOpt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbOpt.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbOpt.Location = new System.Drawing.Point(152, 5);
            this.PbOpt.Name = "PbOpt";
            this.PbOpt.Size = new System.Drawing.Size(16, 16);
            this.PbOpt.TabIndex = 2;
            this.PbOpt.TabStop = false;
            this.PbOpt.Click += new System.EventHandler(this.PbAlg_Click);
            // 
            // CbOpt
            // 
            this.CbOpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbOpt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CbOpt.FormattingEnabled = true;
            this.CbOpt.Location = new System.Drawing.Point(56, 3);
            this.CbOpt.Name = "CbOpt";
            this.CbOpt.Size = new System.Drawing.Size(90, 20);
            this.CbOpt.TabIndex = 1;
            this.CbOpt.SelectedIndexChanged += new System.EventHandler(this.CbDir_SelectedIndexChanged);
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
            // PlDst
            // 
            this.PlDst.Controls.Add(this.PbDir);
            this.PlDst.Controls.Add(this._UcDst);
            this.PlDst.Controls.Add(this.PbKey);
            this.PlDst.Controls.Add(this.TbKey);
            this.PlDst.Controls.Add(this.LlKey);
            this.PlDst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlDst.Location = new System.Drawing.Point(0, 0);
            this.PlDst.Name = "PlDst";
            this.PlDst.Size = new System.Drawing.Size(261, 266);
            this.PlDst.TabIndex = 0;
            // 
            // PbDir
            // 
            this.PbDir.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbDir.Location = new System.Drawing.Point(174, 3);
            this.PbDir.Name = "PbDir";
            this.PbDir.Size = new System.Drawing.Size(42, 20);
            this.PbDir.TabIndex = 5;
            this.PbDir.TabStop = false;
            // 
            // _UcDst
            // 
            this._UcDst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._UcDst.Location = new System.Drawing.Point(3, 30);
            this._UcDst.Name = "_UcDst";
            this._UcDst.Size = new System.Drawing.Size(255, 233);
            this._UcDst.TabIndex = 4;
            // 
            // PbKey
            // 
            this.PbKey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbKey.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbKey.Location = new System.Drawing.Point(152, 5);
            this.PbKey.Name = "PbKey";
            this.PbKey.Size = new System.Drawing.Size(16, 16);
            this.PbKey.TabIndex = 3;
            this.PbKey.TabStop = false;
            this.PbKey.Visible = false;
            this.PbKey.Click += new System.EventHandler(this.PbKey_Click);
            // 
            // TbKey
            // 
            this.TbKey.Location = new System.Drawing.Point(56, 3);
            this.TbKey.Name = "TbKey";
            this.TbKey.Size = new System.Drawing.Size(90, 21);
            this.TbKey.TabIndex = 1;
            this.TbKey.Visible = false;
            // 
            // LlKey
            // 
            this.LlKey.AutoSize = true;
            this.LlKey.Location = new System.Drawing.Point(3, 6);
            this.LlKey.Name = "LlKey";
            this.LlKey.Size = new System.Drawing.Size(47, 12);
            this.LlKey.TabIndex = 0;
            this.LlKey.Text = "口令(&K)";
            this.LlKey.Visible = false;
            // 
            // AWiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ScMain);
            this.Name = "AWiz";
            this.Size = new System.Drawing.Size(526, 266);
            this.ScMain.Panel1.ResumeLayout(false);
            this.ScMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScMain)).EndInit();
            this.ScMain.ResumeLayout(false);
            this.PlSrc.ResumeLayout(false);
            this.PlSrc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbOpt)).EndInit();
            this.PlDst.ResumeLayout(false);
            this.PlDst.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbKey)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer ScMain;
        private System.Windows.Forms.Panel PlSrc;
        private System.Windows.Forms.Panel PlDst;
        private System.Windows.Forms.ComboBox CbOpt;
        private System.Windows.Forms.Label LlOpt;
        private System.Windows.Forms.PictureBox PbOpt;
        private System.Windows.Forms.TextBox TbKey;
        private System.Windows.Forms.Label LlKey;
        private System.Windows.Forms.PictureBox PbKey;
        private UcSrc _UcSrc;
        private UcDst _UcDst;
        private System.Windows.Forms.PictureBox PbDir;

    }
}

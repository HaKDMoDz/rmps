namespace Me.Amon.Img.V.Pro
{
    partial class UcOpt
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
            this.PlHead = new System.Windows.Forms.Panel();
            this.LlText = new System.Windows.Forms.Label();
            this.PbHide = new System.Windows.Forms.PictureBox();
            this.PbMenu = new System.Windows.Forms.PictureBox();
            this.GbBody = new System.Windows.Forms.GroupBox();
            this.BtApply = new System.Windows.Forms.Button();
            this.BtReset = new System.Windows.Forms.Button();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiScale = new System.Windows.Forms.ToolStripMenuItem();
            this.MiRound = new System.Windows.Forms.ToolStripMenuItem();
            this.MIWater = new System.Windows.Forms.ToolStripMenuItem();
            this.PlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).BeginInit();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlHead
            // 
            this.PlHead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlHead.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PlHead.Controls.Add(this.LlText);
            this.PlHead.Controls.Add(this.PbHide);
            this.PlHead.Controls.Add(this.PbMenu);
            this.PlHead.Location = new System.Drawing.Point(3, 3);
            this.PlHead.Name = "PlHead";
            this.PlHead.Size = new System.Drawing.Size(194, 22);
            this.PlHead.TabIndex = 0;
            // 
            // LlText
            // 
            this.LlText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LlText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LlText.Location = new System.Drawing.Point(5, 5);
            this.LlText.Name = "LlText";
            this.LlText.Size = new System.Drawing.Size(142, 12);
            this.LlText.TabIndex = 0;
            this.LlText.Text = "功能";
            this.LlText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LlText_MouseClick);
            // 
            // PbHide
            // 
            this.PbHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbHide.Location = new System.Drawing.Point(175, 3);
            this.PbHide.Name = "PbHide";
            this.PbHide.Size = new System.Drawing.Size(16, 16);
            this.PbHide.TabIndex = 1;
            this.PbHide.TabStop = false;
            this.PbHide.Click += new System.EventHandler(this.PbHide_Click);
            // 
            // PbMenu
            // 
            this.PbMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbMenu.Location = new System.Drawing.Point(153, 3);
            this.PbMenu.Name = "PbMenu";
            this.PbMenu.Size = new System.Drawing.Size(16, 16);
            this.PbMenu.TabIndex = 2;
            this.PbMenu.TabStop = false;
            this.PbMenu.Click += new System.EventHandler(this.PbMenu_Click);
            // 
            // GbBody
            // 
            this.GbBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbBody.Location = new System.Drawing.Point(3, 31);
            this.GbBody.Name = "GbBody";
            this.GbBody.Size = new System.Drawing.Size(194, 300);
            this.GbBody.TabIndex = 1;
            this.GbBody.TabStop = false;
            this.GbBody.Text = "标题";
            // 
            // BtApply
            // 
            this.BtApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtApply.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtApply.Location = new System.Drawing.Point(41, 337);
            this.BtApply.Name = "BtApply";
            this.BtApply.Size = new System.Drawing.Size(75, 23);
            this.BtApply.TabIndex = 2;
            this.BtApply.Text = "应用(&A)";
            this.BtApply.UseVisualStyleBackColor = true;
            this.BtApply.Click += new System.EventHandler(this.BtApply_Click);
            // 
            // BtReset
            // 
            this.BtReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtReset.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtReset.Location = new System.Drawing.Point(122, 337);
            this.BtReset.Name = "BtReset";
            this.BtReset.Size = new System.Drawing.Size(75, 23);
            this.BtReset.TabIndex = 3;
            this.BtReset.Text = "重置(&R)";
            this.BtReset.UseVisualStyleBackColor = true;
            this.BtReset.Click += new System.EventHandler(this.BtReset_Click);
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiScale,
            this.MiRound,
            this.MIWater});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(121, 70);
            // 
            // MiScale
            // 
            this.MiScale.Name = "MiScale";
            this.MiScale.Size = new System.Drawing.Size(120, 22);
            this.MiScale.Text = "缩放(&S)";
            this.MiScale.Click += new System.EventHandler(this.MiScale_Click);
            // 
            // MiRound
            // 
            this.MiRound.Name = "MiRound";
            this.MiRound.Size = new System.Drawing.Size(120, 22);
            this.MiRound.Text = "圆角(&R)";
            this.MiRound.Click += new System.EventHandler(this.MiRound_Click);
            // 
            // MIWater
            // 
            this.MIWater.Name = "MIWater";
            this.MIWater.Size = new System.Drawing.Size(120, 22);
            this.MIWater.Text = "水印(&W)";
            this.MIWater.Click += new System.EventHandler(this.MIWater_Click);
            // 
            // UcOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtReset);
            this.Controls.Add(this.BtApply);
            this.Controls.Add(this.GbBody);
            this.Controls.Add(this.PlHead);
            this.Name = "UcOpt";
            this.Size = new System.Drawing.Size(200, 363);
            this.PlHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).EndInit();
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlHead;
        private System.Windows.Forms.PictureBox PbHide;
        private System.Windows.Forms.PictureBox PbMenu;
        private System.Windows.Forms.GroupBox GbBody;
        private System.Windows.Forms.Button BtApply;
        private System.Windows.Forms.Button BtReset;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiScale;
        private System.Windows.Forms.ToolStripMenuItem MiRound;
        private System.Windows.Forms.ToolStripMenuItem MIWater;
        private System.Windows.Forms.Label LlText;
    }
}

namespace Me.Amon.Pwd.Wiz
{
    partial class BeanPass
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
            this.BtOpt = new System.Windows.Forms.Button();
            this.BtGen = new System.Windows.Forms.Button();
            this.BtMod = new System.Windows.Forms.Button();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MuCharLen = new System.Windows.Forms.ToolStripMenuItem();
            this.MiCharLenDef = new System.Windows.Forms.ToolStripMenuItem();
            this.MiCharLenSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.MiCharLenDiy = new System.Windows.Forms.ToolStripMenuItem();
            this.MiCharLenSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MuCharSet = new System.Windows.Forms.ToolStripMenuItem();
            this.MiCharSet0 = new System.Windows.Forms.ToolStripMenuItem();
            this.MiCharSetSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.MiRepeatable = new System.Windows.Forms.ToolStripMenuItem();
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
            this.TbData.Size = new System.Drawing.Size(266, 21);
            this.TbData.TabIndex = 0;
            // 
            // BtOpt
            // 
            this.BtOpt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOpt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtOpt.Location = new System.Drawing.Point(326, 0);
            this.BtOpt.Name = "BtOpt";
            this.BtOpt.Size = new System.Drawing.Size(21, 21);
            this.BtOpt.TabIndex = 3;
            this.BtOpt.Text = "button1";
            this.BtOpt.UseVisualStyleBackColor = true;
            this.BtOpt.Click += new System.EventHandler(this.BtOpt_Click);
            // 
            // BtGen
            // 
            this.BtGen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtGen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtGen.Location = new System.Drawing.Point(299, 0);
            this.BtGen.Name = "BtGen";
            this.BtGen.Size = new System.Drawing.Size(21, 21);
            this.BtGen.TabIndex = 2;
            this.BtGen.Text = "button2";
            this.BtGen.UseVisualStyleBackColor = true;
            this.BtGen.Click += new System.EventHandler(this.BtGen_Click);
            // 
            // BtMod
            // 
            this.BtMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtMod.Location = new System.Drawing.Point(272, 0);
            this.BtMod.Name = "BtMod";
            this.BtMod.Size = new System.Drawing.Size(21, 21);
            this.BtMod.TabIndex = 1;
            this.BtMod.Text = "button3";
            this.BtMod.UseVisualStyleBackColor = true;
            this.BtMod.Click += new System.EventHandler(this.BtMod_Click);
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MuCharLen,
            this.MuCharSet,
            this.MiRepeatable});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(165, 92);
            // 
            // MuCharLen
            // 
            this.MuCharLen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiCharLenDef,
            this.MiCharLenSep0,
            this.MiCharLenSep1,
            this.MiCharLenDiy});
            this.MuCharLen.Name = "MuCharLen";
            this.MuCharLen.Size = new System.Drawing.Size(164, 22);
            this.MuCharLen.Text = "口令长度(&L)";
            // 
            // MiCharLenDef
            // 
            this.MiCharLenDef.Name = "MiCharLenDef";
            this.MiCharLenDef.Size = new System.Drawing.Size(152, 22);
            this.MiCharLenDef.Text = "默认(&D)";
            // 
            // MiCharLenSep0
            // 
            this.MiCharLenSep0.Name = "MiCharLenSep0";
            this.MiCharLenSep0.Size = new System.Drawing.Size(149, 6);
            // 
            // MiCharLenDiy
            // 
            this.MiCharLenDiy.Name = "MiCharLenDiy";
            this.MiCharLenDiy.Size = new System.Drawing.Size(152, 22);
            this.MiCharLenDiy.Text = "32位";
            // 
            // MiCharLenSep1
            // 
            this.MiCharLenSep1.Name = "MiCharLenSep1";
            this.MiCharLenSep1.Size = new System.Drawing.Size(149, 6);
            // 
            // MuCharSet
            // 
            this.MuCharSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiCharSet0,
            this.MiCharSetSep0});
            this.MuCharSet.Name = "MuCharSet";
            this.MuCharSet.Size = new System.Drawing.Size(164, 22);
            this.MuCharSet.Text = "字符空间(&C)";
            // 
            // MiCharSet0
            // 
            this.MiCharSet0.Name = "MiCharSet0";
            this.MiCharSet0.Size = new System.Drawing.Size(152, 22);
            this.MiCharSet0.Text = "默认(&D)";
            this.MiCharSet0.Click += new System.EventHandler(this.MiCharSet_Click);
            // 
            // MiCharSetSep0
            // 
            this.MiCharSetSep0.Name = "MiCharSetSep0";
            this.MiCharSetSep0.Size = new System.Drawing.Size(149, 6);
            // 
            // MiRepeatable
            // 
            this.MiRepeatable.Name = "MiRepeatable";
            this.MiRepeatable.Size = new System.Drawing.Size(164, 22);
            this.MiRepeatable.Text = "允许字符重复(&A)";
            this.MiRepeatable.Click += new System.EventHandler(this.MiRepeatable_Click);
            // 
            // BeanPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtMod);
            this.Controls.Add(this.BtGen);
            this.Controls.Add(this.BtOpt);
            this.Controls.Add(this.TbData);
            this.Name = "BeanPass";
            this.Size = new System.Drawing.Size(350, 24);
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbData;
        private System.Windows.Forms.Button BtOpt;
        private System.Windows.Forms.Button BtGen;
        private System.Windows.Forms.Button BtMod;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MuCharLen;
        private System.Windows.Forms.ToolStripMenuItem MiCharLenDef;
        private System.Windows.Forms.ToolStripSeparator MiCharLenSep0;
        private System.Windows.Forms.ToolStripMenuItem MiCharLenDiy;
        private System.Windows.Forms.ToolStripSeparator MiCharLenSep1;
        private System.Windows.Forms.ToolStripMenuItem MuCharSet;
        private System.Windows.Forms.ToolStripMenuItem MiCharSet0;
        private System.Windows.Forms.ToolStripSeparator MiCharSetSep0;
        private System.Windows.Forms.ToolStripMenuItem MiRepeatable;
    }
}

namespace Me.Amon.User
{
    partial class SignAc
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
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.PbMenu = new System.Windows.Forms.PictureBox();
            this.BtOk = new System.Windows.Forms.Button();
            this.BtNo = new System.Windows.Forms.Button();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.MiOnSignUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MiOfSignUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MiPcSignUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiSignFk = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.MiUpgrade = new System.Windows.Forms.ToolStripMenuItem();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).BeginInit();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PbLogo
            // 
            this.PbLogo.Image = global::Me.Amon.Properties.Resources.Guid;
            this.PbLogo.Location = new System.Drawing.Point(0, 0);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(250, 40);
            this.PbLogo.TabIndex = 0;
            this.PbLogo.TabStop = false;
            // 
            // PbMenu
            // 
            this.PbMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PbMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbMenu.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbMenu.Location = new System.Drawing.Point(12, 62);
            this.PbMenu.Name = "PbMenu";
            this.PbMenu.Size = new System.Drawing.Size(16, 16);
            this.PbMenu.TabIndex = 2;
            this.PbMenu.TabStop = false;
            this.TpTips.SetToolTip(this.PbMenu, "系统选单");
            this.PbMenu.Click += new System.EventHandler(this.PbMenu_Click);
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(82, 59);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 3;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // BtNo
            // 
            this.BtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtNo.Location = new System.Drawing.Point(163, 59);
            this.BtNo.Name = "BtNo";
            this.BtNo.Size = new System.Drawing.Size(75, 23);
            this.BtNo.TabIndex = 4;
            this.BtNo.Text = "取消(&C)";
            this.BtNo.UseVisualStyleBackColor = true;
            this.BtNo.Click += new System.EventHandler(this.BtNo_Click);
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiOpen,
            this.MiSep0,
            this.MiOnSignUp,
            this.MiOfSignUp,
            this.MiPcSignUp,
            this.MiSep1,
            this.MiSignFk,
            this.MiSep2,
            this.MiUpgrade});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(153, 176);
            // 
            // MiOpen
            // 
            this.MiOpen.Name = "MiOpen";
            this.MiOpen.Size = new System.Drawing.Size(152, 22);
            this.MiOpen.Text = "打开(&O)";
            this.MiOpen.Click += new System.EventHandler(this.MiOpen_Click);
            // 
            // MiSep0
            // 
            this.MiSep0.Name = "MiSep0";
            this.MiSep0.Size = new System.Drawing.Size(149, 6);
            // 
            // MiOnSignUp
            // 
            this.MiOnSignUp.Name = "MiOnSignUp";
            this.MiOnSignUp.Size = new System.Drawing.Size(152, 22);
            this.MiOnSignUp.Text = "联机注册(&R)";
            this.MiOnSignUp.Visible = false;
            this.MiOnSignUp.Click += new System.EventHandler(this.MiOnSignUp_Click);
            // 
            // MiOfSignUp
            // 
            this.MiOfSignUp.Name = "MiOfSignUp";
            this.MiOfSignUp.Size = new System.Drawing.Size(152, 22);
            this.MiOfSignUp.Text = "脱机注册(&N)";
            this.MiOfSignUp.Visible = false;
            this.MiOfSignUp.Click += new System.EventHandler(this.MiOfSignUp_Click);
            // 
            // MiPcSignUp
            // 
            this.MiPcSignUp.Name = "MiPcSignUp";
            this.MiPcSignUp.Size = new System.Drawing.Size(152, 22);
            this.MiPcSignUp.Text = "注册(&P)";
            this.MiPcSignUp.Click += new System.EventHandler(this.MiPcSignUp_Click);
            // 
            // MiSep1
            // 
            this.MiSep1.Name = "MiSep1";
            this.MiSep1.Size = new System.Drawing.Size(149, 6);
            // 
            // MiSignFk
            // 
            this.MiSignFk.Enabled = false;
            this.MiSignFk.Name = "MiSignFk";
            this.MiSignFk.Size = new System.Drawing.Size(152, 22);
            this.MiSignFk.Text = "找回口令(&F)";
            this.MiSignFk.Click += new System.EventHandler(this.MiSignFk_Click);
            // 
            // MiSep2
            // 
            this.MiSep2.Name = "MiSep2";
            this.MiSep2.Size = new System.Drawing.Size(149, 6);
            // 
            // MiUpgrade
            // 
            this.MiUpgrade.Enabled = false;
            this.MiUpgrade.Name = "MiUpgrade";
            this.MiUpgrade.Size = new System.Drawing.Size(152, 22);
            this.MiUpgrade.Text = "升级(&U)";
            this.MiUpgrade.Click += new System.EventHandler(this.MiUpgrade_Click);
            // 
            // SignAc
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtNo;
            this.ClientSize = new System.Drawing.Size(250, 94);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.PbMenu);
            this.Controls.Add(this.PbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignAc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "登录";
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).EndInit();
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.PictureBox PbMenu;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtNo;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiOpen;
        private System.Windows.Forms.ToolStripSeparator MiSep0;
        private System.Windows.Forms.ToolStripMenuItem MiOnSignUp;
        private System.Windows.Forms.ToolStripMenuItem MiOfSignUp;
        private System.Windows.Forms.ToolStripMenuItem MiPcSignUp;
        private System.Windows.Forms.ToolStripSeparator MiSep1;
        private System.Windows.Forms.ToolStripMenuItem MiSignFk;
        private System.Windows.Forms.ToolStripSeparator MiSep2;
        private System.Windows.Forms.ToolStripMenuItem MiUpgrade;
        private System.Windows.Forms.ToolTip TpTips;
    }
}
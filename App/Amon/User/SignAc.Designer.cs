﻿namespace Me.Amon.Auth
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MiPcSignUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiSignFk = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.MiUpgrade = new System.Windows.Forms.ToolStripMenuItem();
            this.MiOfSignUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MiOnSignUp = new System.Windows.Forms.ToolStripMenuItem();
            this.BtNo = new System.Windows.Forms.Button();
            this.MiSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.BtOk = new System.Windows.Forms.Button();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.PbMenu = new System.Windows.Forms.PictureBox();
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.CmMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            this.SuspendLayout();
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
            // MiOfSignUp
            // 
            this.MiOfSignUp.Name = "MiOfSignUp";
            this.MiOfSignUp.Size = new System.Drawing.Size(152, 22);
            this.MiOfSignUp.Text = "脱机注册(&N)";
            this.MiOfSignUp.Visible = false;
            this.MiOfSignUp.Click += new System.EventHandler(this.MiOfSignUp_Click);
            // 
            // MiOnSignUp
            // 
            this.MiOnSignUp.Name = "MiOnSignUp";
            this.MiOnSignUp.Size = new System.Drawing.Size(152, 22);
            this.MiOnSignUp.Text = "联机注册(&R)";
            this.MiOnSignUp.Visible = false;
            this.MiOnSignUp.Click += new System.EventHandler(this.MiOnSignUp_Click);
            // 
            // BtNo
            // 
            this.BtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtNo.Location = new System.Drawing.Point(162, 58);
            this.BtNo.Name = "BtNo";
            this.BtNo.Size = new System.Drawing.Size(75, 23);
            this.BtNo.TabIndex = 8;
            this.BtNo.Text = "取消(&C)";
            this.BtNo.UseVisualStyleBackColor = true;
            this.BtNo.Click += new System.EventHandler(this.BtNo_Click);
            // 
            // MiSep0
            // 
            this.MiSep0.Name = "MiSep0";
            this.MiSep0.Size = new System.Drawing.Size(149, 6);
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
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(81, 58);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 7;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // PbMenu
            // 
            this.PbMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PbMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbMenu.Image = global::Me.Amon.Properties.Resources.Menu;
            this.PbMenu.Location = new System.Drawing.Point(12, 61);
            this.PbMenu.Name = "PbMenu";
            this.PbMenu.Size = new System.Drawing.Size(16, 16);
            this.PbMenu.TabIndex = 6;
            this.PbMenu.TabStop = false;
            this.TpTips.SetToolTip(this.PbMenu, "系统选单");
            this.PbMenu.Click += new System.EventHandler(this.PbMenu_Click);
            // 
            // PbLogo
            // 
            this.PbLogo.Image = global::Me.Amon.Properties.Resources.Guid;
            this.PbLogo.Location = new System.Drawing.Point(0, 0);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(250, 40);
            this.PbLogo.TabIndex = 5;
            this.PbLogo.TabStop = false;
            // 
            // SignAc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbLogo);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.PbMenu);
            this.Name = "SignAc";
            this.Size = new System.Drawing.Size(250, 92);
            this.CmMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.ToolStripMenuItem MiPcSignUp;
        private System.Windows.Forms.ToolStripSeparator MiSep1;
        private System.Windows.Forms.ToolStripMenuItem MiSignFk;
        private System.Windows.Forms.ToolStripSeparator MiSep2;
        private System.Windows.Forms.ToolStripMenuItem MiUpgrade;
        private System.Windows.Forms.ToolStripMenuItem MiOfSignUp;
        private System.Windows.Forms.ToolStripMenuItem MiOnSignUp;
        private System.Windows.Forms.Button BtNo;
        private System.Windows.Forms.ToolStripSeparator MiSep0;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiOpen;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.ToolTip TpTips;
        private System.Windows.Forms.PictureBox PbMenu;
    }
}

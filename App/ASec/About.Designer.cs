﻿namespace Me.Amon
{
    partial class About
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
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
            this.LtName = new System.Windows.Forms.Label();
            this.LbName = new System.Windows.Forms.Label();
            this.LtVersion = new System.Windows.Forms.Label();
            this.LbVersion = new System.Windows.Forms.Label();
            this.LtCopyright = new System.Windows.Forms.Label();
            this.LbCopyright = new System.Windows.Forms.Label();
            this.LtHomepage = new System.Windows.Forms.Label();
            this.LbHomepage = new System.Windows.Forms.LinkLabel();
            this.LtMail = new System.Windows.Forms.Label();
            this.LbMail = new System.Windows.Forms.LinkLabel();
            this.TbDescription = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LtName
            // 
            this.LtName.AutoSize = true;
            this.LtName.Location = new System.Drawing.Point(120, 11);
            this.LtName.Name = "LtName";
            this.LtName.Size = new System.Drawing.Size(41, 12);
            this.LtName.TabIndex = 1;
            this.LtName.Text = "软件：";
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(167, 11);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(41, 12);
            this.LbName.TabIndex = 2;
            this.LbName.Text = "label2";
            // 
            // LtVersion
            // 
            this.LtVersion.AutoSize = true;
            this.LtVersion.Location = new System.Drawing.Point(120, 34);
            this.LtVersion.Name = "LtVersion";
            this.LtVersion.Size = new System.Drawing.Size(41, 12);
            this.LtVersion.TabIndex = 3;
            this.LtVersion.Text = "版本：";
            // 
            // LbVersion
            // 
            this.LbVersion.AutoSize = true;
            this.LbVersion.Location = new System.Drawing.Point(167, 34);
            this.LbVersion.Name = "LbVersion";
            this.LbVersion.Size = new System.Drawing.Size(41, 12);
            this.LbVersion.TabIndex = 4;
            this.LbVersion.Text = "label4";
            // 
            // LtCopyright
            // 
            this.LtCopyright.AutoSize = true;
            this.LtCopyright.Location = new System.Drawing.Point(120, 57);
            this.LtCopyright.Name = "LtCopyright";
            this.LtCopyright.Size = new System.Drawing.Size(41, 12);
            this.LtCopyright.TabIndex = 5;
            this.LtCopyright.Text = "版权：";
            // 
            // LbCopyright
            // 
            this.LbCopyright.AutoSize = true;
            this.LbCopyright.Location = new System.Drawing.Point(167, 57);
            this.LbCopyright.Name = "LbCopyright";
            this.LbCopyright.Size = new System.Drawing.Size(41, 12);
            this.LbCopyright.TabIndex = 6;
            this.LbCopyright.Text = "label6";
            // 
            // LtHomepage
            // 
            this.LtHomepage.AutoSize = true;
            this.LtHomepage.Location = new System.Drawing.Point(120, 80);
            this.LtHomepage.Name = "LtHomepage";
            this.LtHomepage.Size = new System.Drawing.Size(41, 12);
            this.LtHomepage.TabIndex = 7;
            this.LtHomepage.Text = "网站：";
            // 
            // LbHomepage
            // 
            this.LbHomepage.AutoSize = true;
            this.LbHomepage.Location = new System.Drawing.Point(167, 80);
            this.LbHomepage.Name = "LbHomepage";
            this.LbHomepage.Size = new System.Drawing.Size(95, 12);
            this.LbHomepage.TabIndex = 8;
            this.LbHomepage.TabStop = true;
            this.LbHomepage.Text = "http://amon.me/";
            this.LbHomepage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LbHomepage_LinkClicked);
            // 
            // LtMail
            // 
            this.LtMail.AutoSize = true;
            this.LtMail.Location = new System.Drawing.Point(120, 103);
            this.LtMail.Name = "LtMail";
            this.LtMail.Size = new System.Drawing.Size(41, 12);
            this.LtMail.TabIndex = 9;
            this.LtMail.Text = "邮件：";
            // 
            // LbMail
            // 
            this.LbMail.AutoSize = true;
            this.LbMail.Location = new System.Drawing.Point(167, 103);
            this.LbMail.Name = "LbMail";
            this.LbMail.Size = new System.Drawing.Size(83, 12);
            this.LbMail.TabIndex = 10;
            this.LbMail.TabStop = true;
            this.LbMail.Text = "admin@amon.me";
            this.LbMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LbMail_LinkClicked);
            // 
            // TbDescription
            // 
            this.TbDescription.Location = new System.Drawing.Point(120, 126);
            this.TbDescription.Multiline = true;
            this.TbDescription.Name = "TbDescription";
            this.TbDescription.ReadOnly = true;
            this.TbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbDescription.Size = new System.Drawing.Size(262, 107);
            this.TbDescription.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::Me.Amon.Properties.Resources.Info;
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 222);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(307, 238);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 12;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 272);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.TbDescription);
            this.Controls.Add(this.LbMail);
            this.Controls.Add(this.LtMail);
            this.Controls.Add(this.LbHomepage);
            this.Controls.Add(this.LtHomepage);
            this.Controls.Add(this.LbCopyright);
            this.Controls.Add(this.LtCopyright);
            this.Controls.Add(this.LbVersion);
            this.Controls.Add(this.LtVersion);
            this.Controls.Add(this.LbName);
            this.Controls.Add(this.LtName);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LtName;
        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.Label LtVersion;
        private System.Windows.Forms.Label LbVersion;
        private System.Windows.Forms.Label LtCopyright;
        private System.Windows.Forms.Label LbCopyright;
        private System.Windows.Forms.Label LtHomepage;
        private System.Windows.Forms.LinkLabel LbHomepage;
        private System.Windows.Forms.Label LtMail;
        private System.Windows.Forms.LinkLabel LbMail;
        private System.Windows.Forms.TextBox TbDescription;
        private System.Windows.Forms.Button BtOk;

    }
}

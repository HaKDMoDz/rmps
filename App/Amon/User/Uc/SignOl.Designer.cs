﻿namespace Me.Amon.User.Uc
{
    partial class SignOl
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
            this.TbPass1 = new System.Windows.Forms.TextBox();
            this.LbPass1 = new System.Windows.Forms.Label();
            this.TbMail = new System.Windows.Forms.TextBox();
            this.LbMail = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LbName = new System.Windows.Forms.Label();
            this.LbPass2 = new System.Windows.Forms.Label();
            this.TbPass2 = new System.Windows.Forms.TextBox();
            this.BtPath = new System.Windows.Forms.Button();
            this.TbPath = new System.Windows.Forms.TextBox();
            this.LbPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TbPass1
            // 
            this.TbPass1.Location = new System.Drawing.Point(89, 57);
            this.TbPass1.Name = "TbPass1";
            this.TbPass1.Size = new System.Drawing.Size(127, 21);
            this.TbPass1.TabIndex = 5;
            this.TbPass1.UseSystemPasswordChar = true;
            // 
            // LbPass1
            // 
            this.LbPass1.AutoSize = true;
            this.LbPass1.Location = new System.Drawing.Point(12, 60);
            this.LbPass1.Name = "LbPass1";
            this.LbPass1.Size = new System.Drawing.Size(71, 12);
            this.LbPass1.TabIndex = 4;
            this.LbPass1.Text = "登录口令(&K)";
            // 
            // TbMail
            // 
            this.TbMail.Location = new System.Drawing.Point(89, 30);
            this.TbMail.Name = "TbMail";
            this.TbMail.Size = new System.Drawing.Size(127, 21);
            this.TbMail.TabIndex = 3;
            // 
            // LbMail
            // 
            this.LbMail.AutoSize = true;
            this.LbMail.Location = new System.Drawing.Point(12, 33);
            this.LbMail.Name = "LbMail";
            this.LbMail.Size = new System.Drawing.Size(71, 12);
            this.LbMail.TabIndex = 2;
            this.LbMail.Text = "电子邮件(&M)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(89, 3);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(127, 21);
            this.TbName.TabIndex = 1;
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(12, 6);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(71, 12);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "登录用户(&N)";
            // 
            // LbPass2
            // 
            this.LbPass2.AutoSize = true;
            this.LbPass2.Location = new System.Drawing.Point(12, 87);
            this.LbPass2.Name = "LbPass2";
            this.LbPass2.Size = new System.Drawing.Size(71, 12);
            this.LbPass2.TabIndex = 6;
            this.LbPass2.Text = "口令确认(&V)";
            // 
            // TbPass2
            // 
            this.TbPass2.Location = new System.Drawing.Point(89, 84);
            this.TbPass2.Name = "TbPass2";
            this.TbPass2.Size = new System.Drawing.Size(127, 21);
            this.TbPass2.TabIndex = 7;
            this.TbPass2.UseSystemPasswordChar = true;
            // 
            // BtPath
            // 
            this.BtPath.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtPath.Image = global::Me.Amon.Properties.Resources.Find;
            this.BtPath.Location = new System.Drawing.Point(195, 111);
            this.BtPath.Name = "BtPath";
            this.BtPath.Size = new System.Drawing.Size(21, 21);
            this.BtPath.TabIndex = 10;
            this.BtPath.UseVisualStyleBackColor = true;
            this.BtPath.Click += new System.EventHandler(this.BtPath_Click);
            // 
            // TbPath
            // 
            this.TbPath.Location = new System.Drawing.Point(89, 111);
            this.TbPath.Name = "TbPath";
            this.TbPath.ReadOnly = true;
            this.TbPath.Size = new System.Drawing.Size(100, 21);
            this.TbPath.TabIndex = 9;
            this.TbPath.TabStop = false;
            // 
            // LbPath
            // 
            this.LbPath.AutoSize = true;
            this.LbPath.Location = new System.Drawing.Point(12, 114);
            this.LbPath.Name = "LbPath";
            this.LbPath.Size = new System.Drawing.Size(71, 12);
            this.LbPath.TabIndex = 8;
            this.LbPath.Text = "存储路径(&P)";
            // 
            // SignOl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtPath);
            this.Controls.Add(this.TbPath);
            this.Controls.Add(this.LbPath);
            this.Controls.Add(this.TbPass2);
            this.Controls.Add(this.LbPass2);
            this.Controls.Add(this.TbPass1);
            this.Controls.Add(this.LbPass1);
            this.Controls.Add(this.TbMail);
            this.Controls.Add(this.LbMail);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.Name = "SignOl";
            this.Size = new System.Drawing.Size(226, 135);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbPass1;
        private System.Windows.Forms.Label LbPass1;
        private System.Windows.Forms.TextBox TbMail;
        private System.Windows.Forms.Label LbMail;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.Label LbPass2;
        private System.Windows.Forms.TextBox TbPass2;
        private System.Windows.Forms.Button BtPath;
        private System.Windows.Forms.TextBox TbPath;
        private System.Windows.Forms.Label LbPath;
    }
}

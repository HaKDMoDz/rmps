namespace Me.Amon.User.Sign
{
    partial class SignPc
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
            this.LbName = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LbPass1 = new System.Windows.Forms.Label();
            this.TbPass1 = new System.Windows.Forms.TextBox();
            this.LbPass2 = new System.Windows.Forms.Label();
            this.TbPass2 = new System.Windows.Forms.TextBox();
            this.LbPath = new System.Windows.Forms.Label();
            this.TbPath = new System.Windows.Forms.TextBox();
            this.BtPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(89, 3);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(127, 21);
            this.TbName.TabIndex = 1;
            // 
            // LbPass1
            // 
            this.LbPass1.AutoSize = true;
            this.LbPass1.Location = new System.Drawing.Point(12, 33);
            this.LbPass1.Name = "LbPass1";
            this.LbPass1.Size = new System.Drawing.Size(71, 12);
            this.LbPass1.TabIndex = 2;
            this.LbPass1.Text = "登录口令(&K)";
            // 
            // TbPass1
            // 
            this.TbPass1.Location = new System.Drawing.Point(89, 30);
            this.TbPass1.Name = "TbPass1";
            this.TbPass1.Size = new System.Drawing.Size(127, 21);
            this.TbPass1.TabIndex = 3;
            this.TbPass1.UseSystemPasswordChar = true;
            // 
            // LbPass2
            // 
            this.LbPass2.AutoSize = true;
            this.LbPass2.Location = new System.Drawing.Point(12, 60);
            this.LbPass2.Name = "LbPass2";
            this.LbPass2.Size = new System.Drawing.Size(71, 12);
            this.LbPass2.TabIndex = 4;
            this.LbPass2.Text = "口令确认(&V)";
            // 
            // TbPass2
            // 
            this.TbPass2.Location = new System.Drawing.Point(89, 57);
            this.TbPass2.Name = "TbPass2";
            this.TbPass2.Size = new System.Drawing.Size(127, 21);
            this.TbPass2.TabIndex = 5;
            this.TbPass2.UseSystemPasswordChar = true;
            // 
            // LbPath
            // 
            this.LbPath.AutoSize = true;
            this.LbPath.Location = new System.Drawing.Point(12, 87);
            this.LbPath.Name = "LbPath";
            this.LbPath.Size = new System.Drawing.Size(71, 12);
            this.LbPath.TabIndex = 6;
            this.LbPath.Text = "存储路径(&P)";
            // 
            // TbPath
            // 
            this.TbPath.Location = new System.Drawing.Point(89, 84);
            this.TbPath.Name = "TbPath";
            this.TbPath.ReadOnly = true;
            this.TbPath.Size = new System.Drawing.Size(100, 21);
            this.TbPath.TabIndex = 7;
            this.TbPath.TabStop = false;
            // 
            // BtPath
            // 
            this.BtPath.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtPath.Image = global::Me.Amon.Properties.Resources.Find;
            this.BtPath.Location = new System.Drawing.Point(195, 84);
            this.BtPath.Name = "BtPath";
            this.BtPath.Size = new System.Drawing.Size(21, 21);
            this.BtPath.TabIndex = 8;
            this.BtPath.UseVisualStyleBackColor = true;
            this.BtPath.Click += new System.EventHandler(this.BtPath_Click);
            // 
            // SignPc
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
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.Name = "SignPc";
            this.Size = new System.Drawing.Size(226, 108);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbPass1;
        private System.Windows.Forms.TextBox TbPass1;
        private System.Windows.Forms.Label LbPass2;
        private System.Windows.Forms.TextBox TbPass2;
        private System.Windows.Forms.Label LbPath;
        private System.Windows.Forms.TextBox TbPath;
        private System.Windows.Forms.Button BtPath;
    }
}

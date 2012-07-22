namespace Me.Amon.V.Sign
{
    partial class SignUl
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
            this.LbPass = new System.Windows.Forms.Label();
            this.TbPass = new System.Windows.Forms.TextBox();
            this.LbPath = new System.Windows.Forms.Label();
            this.TbPath = new System.Windows.Forms.TextBox();
            this.BtPath = new System.Windows.Forms.Button();
            this.LbText = new System.Windows.Forms.Label();
            this.TbText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(3, 6);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(71, 12);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "登录用户(&N)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(80, 3);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(127, 21);
            this.TbName.TabIndex = 1;
            // 
            // LbPass
            // 
            this.LbPass.AutoSize = true;
            this.LbPass.Location = new System.Drawing.Point(3, 33);
            this.LbPass.Name = "LbPass";
            this.LbPass.Size = new System.Drawing.Size(71, 12);
            this.LbPass.TabIndex = 2;
            this.LbPass.Text = "登录口令(&K)";
            // 
            // TbPass
            // 
            this.TbPass.Location = new System.Drawing.Point(80, 30);
            this.TbPass.Name = "TbPass";
            this.TbPass.Size = new System.Drawing.Size(127, 21);
            this.TbPass.TabIndex = 3;
            this.TbPass.UseSystemPasswordChar = true;
            // 
            // LbPath
            // 
            this.LbPath.AutoSize = true;
            this.LbPath.Location = new System.Drawing.Point(3, 60);
            this.LbPath.Name = "LbPath";
            this.LbPath.Size = new System.Drawing.Size(71, 12);
            this.LbPath.TabIndex = 4;
            this.LbPath.Text = "存储路径(&P)";
            // 
            // TbPath
            // 
            this.TbPath.Location = new System.Drawing.Point(80, 57);
            this.TbPath.Name = "TbPath";
            this.TbPath.ReadOnly = true;
            this.TbPath.Size = new System.Drawing.Size(100, 21);
            this.TbPath.TabIndex = 5;
            this.TbPath.TabStop = false;
            // 
            // BtPath
            // 
            this.BtPath.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtPath.Image = global::Me.Amon.Properties.Resources.Find;
            this.BtPath.Location = new System.Drawing.Point(186, 57);
            this.BtPath.Name = "BtPath";
            this.BtPath.Size = new System.Drawing.Size(21, 21);
            this.BtPath.TabIndex = 6;
            this.BtPath.UseVisualStyleBackColor = true;
            this.BtPath.Click += new System.EventHandler(this.BtPath_Click);
            // 
            // LbText
            // 
            this.LbText.AutoSize = true;
            this.LbText.Location = new System.Drawing.Point(3, 87);
            this.LbText.Name = "LbText";
            this.LbText.Size = new System.Drawing.Size(71, 12);
            this.LbText.TabIndex = 7;
            this.LbText.Text = "令牌数据(&T)";
            // 
            // TbText
            // 
            this.TbText.Location = new System.Drawing.Point(80, 84);
            this.TbText.Multiline = true;
            this.TbText.Name = "TbText";
            this.TbText.Size = new System.Drawing.Size(143, 48);
            this.TbText.TabIndex = 8;
            // 
            // SignUl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbText);
            this.Controls.Add(this.LbText);
            this.Controls.Add(this.BtPath);
            this.Controls.Add(this.TbPath);
            this.Controls.Add(this.LbPath);
            this.Controls.Add(this.TbPass);
            this.Controls.Add(this.LbPass);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.Name = "SignUl";
            this.Size = new System.Drawing.Size(226, 135);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbPass;
        private System.Windows.Forms.TextBox TbPass;
        private System.Windows.Forms.Label LbPath;
        private System.Windows.Forms.TextBox TbPath;
        private System.Windows.Forms.Button BtPath;
        private System.Windows.Forms.Label LbText;
        private System.Windows.Forms.TextBox TbText;
    }
}

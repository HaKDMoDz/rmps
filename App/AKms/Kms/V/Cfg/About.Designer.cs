namespace Me.Amon.Kms.V.Cfg
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
            this.LtName = new System.Windows.Forms.Label();
            this.LbVersion = new System.Windows.Forms.Label();
            this.LtVersion = new System.Windows.Forms.Label();
            this.LbHomepage = new System.Windows.Forms.Label();
            this.LtHomepage = new System.Windows.Forms.LinkLabel();
            this.TbDesp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(3, 6);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(65, 12);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "软件名称：";
            // 
            // LtName
            // 
            this.LtName.AutoSize = true;
            this.LtName.Location = new System.Drawing.Point(62, 6);
            this.LtName.Name = "LtName";
            this.LtName.Size = new System.Drawing.Size(53, 12);
            this.LtName.TabIndex = 1;
            this.LtName.Text = "妙语连珠";
            // 
            // LbVersion
            // 
            this.LbVersion.AutoSize = true;
            this.LbVersion.Location = new System.Drawing.Point(3, 22);
            this.LbVersion.Name = "LbVersion";
            this.LbVersion.Size = new System.Drawing.Size(65, 12);
            this.LbVersion.TabIndex = 2;
            this.LbVersion.Text = "当前版本：";
            // 
            // LtVersion
            // 
            this.LtVersion.AutoSize = true;
            this.LtVersion.Location = new System.Drawing.Point(62, 22);
            this.LtVersion.Name = "LtVersion";
            this.LtVersion.Size = new System.Drawing.Size(53, 12);
            this.LtVersion.TabIndex = 3;
            this.LtVersion.Text = "V1.0.0.0";
            // 
            // LbHomepage
            // 
            this.LbHomepage.AutoSize = true;
            this.LbHomepage.Location = new System.Drawing.Point(3, 38);
            this.LbHomepage.Name = "LbHomepage";
            this.LbHomepage.Size = new System.Drawing.Size(65, 12);
            this.LbHomepage.TabIndex = 4;
            this.LbHomepage.Text = "软件首页：";
            // 
            // LtHomepage
            // 
            this.LtHomepage.AutoSize = true;
            this.LtHomepage.Location = new System.Drawing.Point(62, 38);
            this.LtHomepage.Name = "LtHomepage";
            this.LtHomepage.Size = new System.Drawing.Size(125, 12);
            this.LtHomepage.TabIndex = 5;
            this.LtHomepage.TabStop = true;
            this.LtHomepage.Text = "http://mkms.amon.me/";
            this.LtHomepage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LtHomepage_LinkClicked);
            // 
            // TbDesp
            // 
            this.TbDesp.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TbDesp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbDesp.Location = new System.Drawing.Point(3, 54);
            this.TbDesp.Multiline = true;
            this.TbDesp.Name = "TbDesp";
            this.TbDesp.ReadOnly = true;
            this.TbDesp.Size = new System.Drawing.Size(219, 130);
            this.TbDesp.TabIndex = 6;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbDesp);
            this.Controls.Add(this.LtHomepage);
            this.Controls.Add(this.LbHomepage);
            this.Controls.Add(this.LtVersion);
            this.Controls.Add(this.LbVersion);
            this.Controls.Add(this.LtName);
            this.Controls.Add(this.LbName);
            this.Name = "About";
            this.Size = new System.Drawing.Size(225, 187);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.Label LtName;
        private System.Windows.Forms.Label LbVersion;
        private System.Windows.Forms.Label LtVersion;
        private System.Windows.Forms.Label LbHomepage;
        private System.Windows.Forms.LinkLabel LtHomepage;
        private System.Windows.Forms.TextBox TbDesp;
    }
}

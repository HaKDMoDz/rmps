namespace Msec.Uc
{
    partial class Uk
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtSalt = new System.Windows.Forms.Button();
            this.TbSalt = new System.Windows.Forms.TextBox();
            this.LbSalt = new System.Windows.Forms.Label();
            this.BtPass = new System.Windows.Forms.Button();
            this.TbPass = new System.Windows.Forms.TextBox();
            this.LbPass = new System.Windows.Forms.Label();
            this.CbSize = new System.Windows.Forms.ComboBox();
            this.LbSize = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.BtSalt);
            this.groupBox1.Controls.Add(this.TbSalt);
            this.groupBox1.Controls.Add(this.LbSalt);
            this.groupBox1.Controls.Add(this.BtPass);
            this.groupBox1.Controls.Add(this.TbPass);
            this.groupBox1.Controls.Add(this.LbPass);
            this.groupBox1.Controls.Add(this.CbSize);
            this.groupBox1.Controls.Add(this.LbSize);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "口令";
            // 
            // BtSalt
            // 
            this.BtSalt.Location = new System.Drawing.Point(183, 67);
            this.BtSalt.Name = "BtSalt";
            this.BtSalt.Size = new System.Drawing.Size(19, 21);
            this.BtSalt.TabIndex = 7;
            this.BtSalt.Text = ".";
            this.BtSalt.UseVisualStyleBackColor = true;
            this.BtSalt.Visible = false;
            this.BtSalt.Click += new System.EventHandler(this.BtSalt_Click);
            // 
            // TbSalt
            // 
            this.TbSalt.Location = new System.Drawing.Point(56, 67);
            this.TbSalt.Name = "TbSalt";
            this.TbSalt.Size = new System.Drawing.Size(121, 21);
            this.TbSalt.TabIndex = 6;
            this.TbSalt.Visible = false;
            // 
            // LbSalt
            // 
            this.LbSalt.AutoSize = true;
            this.LbSalt.Location = new System.Drawing.Point(6, 70);
            this.LbSalt.Name = "LbSalt";
            this.LbSalt.Size = new System.Drawing.Size(47, 12);
            this.LbSalt.TabIndex = 5;
            this.LbSalt.Text = "向量(&V)";
            this.LbSalt.Visible = false;
            // 
            // BtPass
            // 
            this.BtPass.Location = new System.Drawing.Point(183, 42);
            this.BtPass.Name = "BtPass";
            this.BtPass.Size = new System.Drawing.Size(19, 21);
            this.BtPass.TabIndex = 4;
            this.BtPass.Text = ".";
            this.BtPass.UseVisualStyleBackColor = true;
            this.BtPass.Click += new System.EventHandler(this.BtPass_Click);
            // 
            // TbPass
            // 
            this.TbPass.Location = new System.Drawing.Point(56, 42);
            this.TbPass.Name = "TbPass";
            this.TbPass.Size = new System.Drawing.Size(121, 21);
            this.TbPass.TabIndex = 3;
            // 
            // LbPass
            // 
            this.LbPass.AutoSize = true;
            this.LbPass.Location = new System.Drawing.Point(6, 44);
            this.LbPass.Name = "LbPass";
            this.LbPass.Size = new System.Drawing.Size(47, 12);
            this.LbPass.TabIndex = 2;
            this.LbPass.Text = "口令(&K)";
            // 
            // CbSize
            // 
            this.CbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbSize.FormattingEnabled = true;
            this.CbSize.Location = new System.Drawing.Point(56, 18);
            this.CbSize.Name = "CbSize";
            this.CbSize.Size = new System.Drawing.Size(121, 20);
            this.CbSize.TabIndex = 1;
            this.CbSize.SelectedIndexChanged += new System.EventHandler(this.CbSize_SelectedIndexChanged);
            // 
            // LbSize
            // 
            this.LbSize.AutoSize = true;
            this.LbSize.Location = new System.Drawing.Point(6, 23);
            this.LbSize.Name = "LbSize";
            this.LbSize.Size = new System.Drawing.Size(47, 12);
            this.LbSize.TabIndex = 0;
            this.LbSize.Text = "长度(&L)";
            // 
            // Uk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "Uk";
            this.Size = new System.Drawing.Size(240, 102);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label LbSize;
        public System.Windows.Forms.ComboBox CbSize;
        public System.Windows.Forms.Label LbPass;
        public System.Windows.Forms.TextBox TbPass;
        public System.Windows.Forms.Button BtPass;
        public System.Windows.Forms.Label LbSalt;
        public System.Windows.Forms.TextBox TbSalt;
        public System.Windows.Forms.Button BtSalt;

    }
}

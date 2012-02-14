namespace Me.Amon.Sec.Uc
{
    partial class Cm
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
            this.CbPads = new System.Windows.Forms.ComboBox();
            this.LbPads = new System.Windows.Forms.Label();
            this.CbMode = new System.Windows.Forms.ComboBox();
            this.LbMode = new System.Windows.Forms.Label();
            this.CbName = new System.Windows.Forms.ComboBox();
            this.LbName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.CbPads);
            this.groupBox1.Controls.Add(this.LbPads);
            this.groupBox1.Controls.Add(this.CbMode);
            this.groupBox1.Controls.Add(this.LbMode);
            this.groupBox1.Controls.Add(this.CbName);
            this.groupBox1.Controls.Add(this.LbName);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "算法";
            // 
            // CbPads
            // 
            this.CbPads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbPads.FormattingEnabled = true;
            this.CbPads.Location = new System.Drawing.Point(56, 73);
            this.CbPads.Name = "CbPads";
            this.CbPads.Size = new System.Drawing.Size(121, 21);
            this.CbPads.TabIndex = 5;
            this.CbPads.SelectedIndexChanged += new System.EventHandler(this.CbPads_SelectedIndexChanged);
            // 
            // LbPads
            // 
            this.LbPads.AutoSize = true;
            this.LbPads.Location = new System.Drawing.Point(6, 76);
            this.LbPads.Name = "LbPads";
            this.LbPads.Size = new System.Drawing.Size(43, 13);
            this.LbPads.TabIndex = 4;
            this.LbPads.Text = "长度(&L)";
            // 
            // CbMode
            // 
            this.CbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbMode.FormattingEnabled = true;
            this.CbMode.Location = new System.Drawing.Point(56, 46);
            this.CbMode.Name = "CbMode";
            this.CbMode.Size = new System.Drawing.Size(121, 21);
            this.CbMode.TabIndex = 3;
            this.CbMode.SelectedIndexChanged += new System.EventHandler(this.CbMode_SelectedIndexChanged);
            // 
            // LbMode
            // 
            this.LbMode.AutoSize = true;
            this.LbMode.Location = new System.Drawing.Point(6, 49);
            this.LbMode.Name = "LbMode";
            this.LbMode.Size = new System.Drawing.Size(44, 13);
            this.LbMode.TabIndex = 2;
            this.LbMode.Text = "模式(&B)";
            // 
            // CbName
            // 
            this.CbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbName.FormattingEnabled = true;
            this.CbName.Location = new System.Drawing.Point(56, 19);
            this.CbName.Name = "CbName";
            this.CbName.Size = new System.Drawing.Size(121, 21);
            this.CbName.TabIndex = 1;
            this.CbName.SelectedIndexChanged += new System.EventHandler(this.CbName_SelectedIndexChanged);
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(6, 22);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(44, 13);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "算法(&C)";
            // 
            // Cm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "Cm";
            this.Size = new System.Drawing.Size(240, 110);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox CbMode;
        public System.Windows.Forms.Label LbMode;
        public System.Windows.Forms.ComboBox CbName;
        public System.Windows.Forms.Label LbName;
        public System.Windows.Forms.ComboBox CbPads;
        public System.Windows.Forms.Label LbPads;
    }
}

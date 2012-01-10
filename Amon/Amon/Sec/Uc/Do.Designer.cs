namespace Me.Amon.Sec.Uc
{
    partial class Do
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
            this.BtMask = new System.Windows.Forms.Button();
            this.BtData = new System.Windows.Forms.Button();
            this.CbMask = new System.Windows.Forms.ComboBox();
            this.LbMask = new System.Windows.Forms.Label();
            this.TbData = new System.Windows.Forms.TextBox();
            this.LbData = new System.Windows.Forms.Label();
            this.CbType = new System.Windows.Forms.ComboBox();
            this.LbType = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.BtMask);
            this.groupBox1.Controls.Add(this.BtData);
            this.groupBox1.Controls.Add(this.CbMask);
            this.groupBox1.Controls.Add(this.LbMask);
            this.groupBox1.Controls.Add(this.TbData);
            this.groupBox1.Controls.Add(this.LbData);
            this.groupBox1.Controls.Add(this.CbType);
            this.groupBox1.Controls.Add(this.LbType);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输出";
            // 
            // BtMask
            // 
            this.BtMask.Location = new System.Drawing.Point(183, 66);
            this.BtMask.Name = "BtMask";
            this.BtMask.Size = new System.Drawing.Size(19, 20);
            this.BtMask.TabIndex = 7;
            this.BtMask.Text = ".";
            this.BtMask.UseVisualStyleBackColor = true;
            this.BtMask.Click += new System.EventHandler(this.BtMask_Click);
            // 
            // BtData
            // 
            this.BtData.Location = new System.Drawing.Point(183, 42);
            this.BtData.Name = "BtData";
            this.BtData.Size = new System.Drawing.Size(19, 21);
            this.BtData.TabIndex = 6;
            this.BtData.Text = ".";
            this.BtData.UseVisualStyleBackColor = true;
            this.BtData.Click += new System.EventHandler(this.BtData_Click);
            // 
            // CbMask
            // 
            this.CbMask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbMask.FormattingEnabled = true;
            this.CbMask.Location = new System.Drawing.Point(57, 66);
            this.CbMask.Name = "CbMask";
            this.CbMask.Size = new System.Drawing.Size(121, 20);
            this.CbMask.TabIndex = 5;
            this.CbMask.SelectedIndexChanged += new System.EventHandler(this.CbMask_SelectedIndexChanged);
            // 
            // LbMask
            // 
            this.LbMask.AutoSize = true;
            this.LbMask.Location = new System.Drawing.Point(6, 69);
            this.LbMask.Name = "LbMask";
            this.LbMask.Size = new System.Drawing.Size(47, 12);
            this.LbMask.TabIndex = 4;
            this.LbMask.Text = "掩码(&M)";
            // 
            // TbData
            // 
            this.TbData.AllowDrop = true;
            this.TbData.Location = new System.Drawing.Point(57, 42);
            this.TbData.Name = "TbData";
            this.TbData.ReadOnly = true;
            this.TbData.Size = new System.Drawing.Size(121, 21);
            this.TbData.TabIndex = 3;
            this.TbData.DragDrop += new System.Windows.Forms.DragEventHandler(this.TbData_DragDrop);
            this.TbData.DragEnter += new System.Windows.Forms.DragEventHandler(this.TbData_DragEnter);
            // 
            // LbData
            // 
            this.LbData.AutoSize = true;
            this.LbData.Location = new System.Drawing.Point(6, 45);
            this.LbData.Name = "LbData";
            this.LbData.Size = new System.Drawing.Size(47, 12);
            this.LbData.TabIndex = 2;
            this.LbData.Text = "输出(&D)";
            // 
            // CbType
            // 
            this.CbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbType.FormattingEnabled = true;
            this.CbType.Location = new System.Drawing.Point(57, 18);
            this.CbType.Name = "CbType";
            this.CbType.Size = new System.Drawing.Size(121, 20);
            this.CbType.TabIndex = 1;
            this.CbType.SelectedIndexChanged += new System.EventHandler(this.CbType_SelectedIndexChanged);
            // 
            // LbType
            // 
            this.LbType.AutoSize = true;
            this.LbType.Location = new System.Drawing.Point(6, 20);
            this.LbType.Name = "LbType";
            this.LbType.Size = new System.Drawing.Size(47, 12);
            this.LbType.TabIndex = 0;
            this.LbType.Text = "方式(&O)";
            // 
            // Do
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "Do";
            this.Size = new System.Drawing.Size(240, 102);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox TbData;
        public System.Windows.Forms.Label LbData;
        public System.Windows.Forms.ComboBox CbType;
        public System.Windows.Forms.Label LbType;
        public System.Windows.Forms.ComboBox CbMask;
        public System.Windows.Forms.Label LbMask;
        public System.Windows.Forms.Button BtData;
        public System.Windows.Forms.Button BtMask;
    }
}

namespace Me.Amon.Gtd.V
{
    partial class GtdEditor
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
            this.LbTitle = new System.Windows.Forms.Label();
            this.TbTitle = new System.Windows.Forms.TextBox();
            this.LbType = new System.Windows.Forms.Label();
            this.CbType = new System.Windows.Forms.ComboBox();
            this.GpTime = new System.Windows.Forms.GroupBox();
            this.GpHint = new System.Windows.Forms.GroupBox();
            this.BtOk = new System.Windows.Forms.Button();
            this.BtNo = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.NpHint = new System.Windows.Forms.Panel();
            this.GpHint.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Location = new System.Drawing.Point(12, 15);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(47, 12);
            this.LbTitle.TabIndex = 0;
            this.LbTitle.Text = "名称(&N)";
            // 
            // TbTitle
            // 
            this.TbTitle.Location = new System.Drawing.Point(65, 12);
            this.TbTitle.Name = "TbTitle";
            this.TbTitle.Size = new System.Drawing.Size(100, 21);
            this.TbTitle.TabIndex = 1;
            // 
            // LbType
            // 
            this.LbType.AutoSize = true;
            this.LbType.Location = new System.Drawing.Point(12, 42);
            this.LbType.Name = "LbType";
            this.LbType.Size = new System.Drawing.Size(47, 12);
            this.LbType.TabIndex = 2;
            this.LbType.Text = "类型(&T)";
            // 
            // CbType
            // 
            this.CbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbType.FormattingEnabled = true;
            this.CbType.Location = new System.Drawing.Point(65, 39);
            this.CbType.Name = "CbType";
            this.CbType.Size = new System.Drawing.Size(121, 20);
            this.CbType.TabIndex = 3;
            this.CbType.SelectedIndexChanged += new System.EventHandler(this.CbType_SelectedIndexChanged);
            // 
            // GpTime
            // 
            this.GpTime.Location = new System.Drawing.Point(12, 65);
            this.GpTime.Name = "GpTime";
            this.GpTime.Size = new System.Drawing.Size(306, 150);
            this.GpTime.TabIndex = 4;
            this.GpTime.TabStop = false;
            this.GpTime.Text = "时间";
            // 
            // GpHint
            // 
            this.GpHint.Controls.Add(this.NpHint);
            this.GpHint.Controls.Add(this.label1);
            this.GpHint.Controls.Add(this.radioButton3);
            this.GpHint.Controls.Add(this.radioButton2);
            this.GpHint.Controls.Add(this.radioButton1);
            this.GpHint.Location = new System.Drawing.Point(12, 221);
            this.GpHint.Name = "GpHint";
            this.GpHint.Size = new System.Drawing.Size(306, 100);
            this.GpHint.TabIndex = 5;
            this.GpHint.TabStop = false;
            this.GpHint.Text = "提示";
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(164, 364);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 6;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // BtNo
            // 
            this.BtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtNo.Location = new System.Drawing.Point(245, 364);
            this.BtNo.Name = "BtNo";
            this.BtNo.Size = new System.Drawing.Size(75, 23);
            this.BtNo.TabIndex = 7;
            this.BtNo.Text = "取消(&C)";
            this.BtNo.UseVisualStyleBackColor = true;
            this.BtNo.Click += new System.EventHandler(this.BtNo_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(65, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "消息(&I)";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "应用(&S)";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 64);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(65, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "邮件(&M)";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(77, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 80);
            this.label1.TabIndex = 3;
            // 
            // NpHint
            // 
            this.NpHint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NpHint.Location = new System.Drawing.Point(85, 20);
            this.NpHint.Name = "NpHint";
            this.NpHint.Size = new System.Drawing.Size(215, 74);
            this.NpHint.TabIndex = 4;
            // 
            // GtdEditor
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtNo;
            this.ClientSize = new System.Drawing.Size(332, 399);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.GpHint);
            this.Controls.Add(this.GpTime);
            this.Controls.Add(this.CbType);
            this.Controls.Add(this.LbType);
            this.Controls.Add(this.TbTitle);
            this.Controls.Add(this.LbTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GtdEditor";
            this.Text = "提醒";
            this.Load += new System.EventHandler(this.GtdEditor_Load);
            this.GpHint.ResumeLayout(false);
            this.GpHint.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.TextBox TbTitle;
        private System.Windows.Forms.Label LbType;
        private System.Windows.Forms.ComboBox CbType;
        private System.Windows.Forms.GroupBox GpTime;
        private System.Windows.Forms.GroupBox GpHint;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtNo;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel NpHint;

    }
}
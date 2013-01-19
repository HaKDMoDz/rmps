namespace Me.Amon.Pwd.V.Cfg
{
    partial class UcSecurity
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
            this.LdClear = new System.Windows.Forms.Label();
            this.SpClear = new System.Windows.Forms.NumericUpDown();
            this.LtClear = new System.Windows.Forms.Label();
            this.LdPassLength = new System.Windows.Forms.Label();
            this.SpPassLength = new System.Windows.Forms.NumericUpDown();
            this.LtPassLength = new System.Windows.Forms.Label();
            this.CbPassCharset = new System.Windows.Forms.ComboBox();
            this.LtPassCharset = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SpClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpPassLength)).BeginInit();
            this.SuspendLayout();
            // 
            // LdClear
            // 
            this.LdClear.AutoSize = true;
            this.LdClear.Location = new System.Drawing.Point(152, 7);
            this.LdClear.Name = "LdClear";
            this.LdClear.Size = new System.Drawing.Size(101, 12);
            this.LdClear.TabIndex = 2;
            this.LdClear.Text = "秒后自动清剪贴板";
            // 
            // SpClear
            // 
            this.SpClear.Location = new System.Drawing.Point(92, 3);
            this.SpClear.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.SpClear.Name = "SpClear";
            this.SpClear.Size = new System.Drawing.Size(54, 21);
            this.SpClear.TabIndex = 1;
            // 
            // LtClear
            // 
            this.LtClear.AutoSize = true;
            this.LtClear.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LtClear.Location = new System.Drawing.Point(16, 7);
            this.LtClear.Name = "LtClear";
            this.LtClear.Size = new System.Drawing.Size(70, 12);
            this.LtClear.TabIndex = 0;
            this.LtClear.Text = "剪贴板保护";
            // 
            // LdPassLength
            // 
            this.LdPassLength.AutoSize = true;
            this.LdPassLength.Location = new System.Drawing.Point(152, 34);
            this.LdPassLength.Name = "LdPassLength";
            this.LdPassLength.Size = new System.Drawing.Size(41, 12);
            this.LdPassLength.TabIndex = 8;
            this.LdPassLength.Text = "个字符";
            // 
            // SpPassLength
            // 
            this.SpPassLength.Location = new System.Drawing.Point(92, 30);
            this.SpPassLength.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.SpPassLength.Name = "SpPassLength";
            this.SpPassLength.Size = new System.Drawing.Size(54, 21);
            this.SpPassLength.TabIndex = 7;
            // 
            // LtPassLength
            // 
            this.LtPassLength.AutoSize = true;
            this.LtPassLength.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LtPassLength.Location = new System.Drawing.Point(3, 34);
            this.LtPassLength.Name = "LtPassLength";
            this.LtPassLength.Size = new System.Drawing.Size(83, 12);
            this.LtPassLength.TabIndex = 6;
            this.LtPassLength.Text = "默认密码长度";
            // 
            // CbPassCharset
            // 
            this.CbPassCharset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbPassCharset.Location = new System.Drawing.Point(92, 57);
            this.CbPassCharset.Name = "CbPassCharset";
            this.CbPassCharset.Size = new System.Drawing.Size(199, 20);
            this.CbPassCharset.TabIndex = 10;
            // 
            // LtPassCharset
            // 
            this.LtPassCharset.AutoSize = true;
            this.LtPassCharset.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LtPassCharset.Location = new System.Drawing.Point(3, 61);
            this.LtPassCharset.Name = "LtPassCharset";
            this.LtPassCharset.Size = new System.Drawing.Size(83, 12);
            this.LtPassCharset.TabIndex = 9;
            this.LtPassCharset.Text = "默认字符空间";
            // 
            // UcSecurity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CbPassCharset);
            this.Controls.Add(this.LtPassCharset);
            this.Controls.Add(this.LdPassLength);
            this.Controls.Add(this.SpPassLength);
            this.Controls.Add(this.LtPassLength);
            this.Controls.Add(this.LdClear);
            this.Controls.Add(this.SpClear);
            this.Controls.Add(this.LtClear);
            this.Name = "UcSecurity";
            this.Size = new System.Drawing.Size(322, 163);
            ((System.ComponentModel.ISupportInitialize)(this.SpClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpPassLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LdClear;
        private System.Windows.Forms.NumericUpDown SpClear;
        private System.Windows.Forms.Label LtClear;
        private System.Windows.Forms.Label LdPassLength;
        private System.Windows.Forms.NumericUpDown SpPassLength;
        private System.Windows.Forms.Label LtPassLength;
        private System.Windows.Forms.ComboBox CbPassCharset;
        private System.Windows.Forms.Label LtPassCharset;
    }
}

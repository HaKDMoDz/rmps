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
            this.PbFillKey = new System.Windows.Forms.PictureBox();
            this.TbFillKey = new System.Windows.Forms.TextBox();
            this.LtFillKey = new System.Windows.Forms.Label();
            this.LdClear = new System.Windows.Forms.Label();
            this.SpClear = new System.Windows.Forms.NumericUpDown();
            this.LtClear = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbFillKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpClear)).BeginInit();
            this.SuspendLayout();
            // 
            // PbFillKey
            // 
            this.PbFillKey.Location = new System.Drawing.Point(297, 33);
            this.PbFillKey.Name = "PbFillKey";
            this.PbFillKey.Size = new System.Drawing.Size(16, 16);
            this.PbFillKey.TabIndex = 20;
            this.PbFillKey.TabStop = false;
            // 
            // TbFillKey
            // 
            this.TbFillKey.Location = new System.Drawing.Point(79, 30);
            this.TbFillKey.Name = "TbFillKey";
            this.TbFillKey.Size = new System.Drawing.Size(212, 21);
            this.TbFillKey.TabIndex = 19;
            this.TbFillKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbFillKey_KeyDown);
            // 
            // LtFillKey
            // 
            this.LtFillKey.AutoSize = true;
            this.LtFillKey.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LtFillKey.Location = new System.Drawing.Point(16, 33);
            this.LtFillKey.Name = "LtFillKey";
            this.LtFillKey.Size = new System.Drawing.Size(57, 12);
            this.LtFillKey.TabIndex = 18;
            this.LtFillKey.Text = "自动填充";
            // 
            // LdClear
            // 
            this.LdClear.AutoSize = true;
            this.LdClear.Location = new System.Drawing.Point(139, 7);
            this.LdClear.Name = "LdClear";
            this.LdClear.Size = new System.Drawing.Size(101, 12);
            this.LdClear.TabIndex = 17;
            this.LdClear.Text = "秒后自动清剪贴板";
            // 
            // SpClear
            // 
            this.SpClear.Location = new System.Drawing.Point(79, 3);
            this.SpClear.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.SpClear.Name = "SpClear";
            this.SpClear.Size = new System.Drawing.Size(54, 21);
            this.SpClear.TabIndex = 16;
            // 
            // LtClear
            // 
            this.LtClear.AutoSize = true;
            this.LtClear.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LtClear.Location = new System.Drawing.Point(3, 7);
            this.LtClear.Name = "LtClear";
            this.LtClear.Size = new System.Drawing.Size(70, 12);
            this.LtClear.TabIndex = 15;
            this.LtClear.Text = "剪贴板保护";
            // 
            // UcSecurity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbFillKey);
            this.Controls.Add(this.TbFillKey);
            this.Controls.Add(this.LtFillKey);
            this.Controls.Add(this.LdClear);
            this.Controls.Add(this.SpClear);
            this.Controls.Add(this.LtClear);
            this.Name = "UcSecurity";
            this.Size = new System.Drawing.Size(322, 163);
            ((System.ComponentModel.ISupportInitialize)(this.PbFillKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpClear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbFillKey;
        private System.Windows.Forms.TextBox TbFillKey;
        private System.Windows.Forms.Label LtFillKey;
        private System.Windows.Forms.Label LdClear;
        private System.Windows.Forms.NumericUpDown SpClear;
        private System.Windows.Forms.Label LtClear;
    }
}

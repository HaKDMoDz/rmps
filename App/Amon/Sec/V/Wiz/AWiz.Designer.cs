namespace Me.Amon.Sec.Wiz
{
    partial class AWiz
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
            this.LbOpt = new System.Windows.Forms.Label();
            this.CbDir = new System.Windows.Forms.ComboBox();
            this.CbFun = new System.Windows.Forms.ComboBox();
            this.CbMod = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cipherFile1 = new Me.Amon.Sec.Wiz.CipherFile();
            this.SuspendLayout();
            // 
            // LbOpt
            // 
            this.LbOpt.AutoSize = true;
            this.LbOpt.Location = new System.Drawing.Point(0, 3);
            this.LbOpt.Name = "LbOpt";
            this.LbOpt.Size = new System.Drawing.Size(47, 12);
            this.LbOpt.TabIndex = 0;
            this.LbOpt.Text = "操作(&T)";
            // 
            // CbDir
            // 
            this.CbDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbDir.FormattingEnabled = true;
            this.CbDir.Location = new System.Drawing.Point(53, 0);
            this.CbDir.Name = "CbDir";
            this.CbDir.Size = new System.Drawing.Size(56, 20);
            this.CbDir.TabIndex = 1;
            this.CbDir.SelectedIndexChanged += new System.EventHandler(this.CbDir_SelectedIndexChanged);
            // 
            // CbFun
            // 
            this.CbFun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbFun.FormattingEnabled = true;
            this.CbFun.Location = new System.Drawing.Point(115, 0);
            this.CbFun.Name = "CbFun";
            this.CbFun.Size = new System.Drawing.Size(61, 20);
            this.CbFun.TabIndex = 2;
            this.CbFun.SelectedIndexChanged += new System.EventHandler(this.CbFun_SelectedIndexChanged);
            // 
            // CbMod
            // 
            this.CbMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbMod.FormattingEnabled = true;
            this.CbMod.Location = new System.Drawing.Point(182, 0);
            this.CbMod.Name = "CbMod";
            this.CbMod.Size = new System.Drawing.Size(56, 20);
            this.CbMod.TabIndex = 3;
            this.CbMod.SelectedIndexChanged += new System.EventHandler(this.CbMod_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(53, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 21);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "口令(&K)";
            // 
            // cipherFile1
            // 
            this.cipherFile1.Location = new System.Drawing.Point(0, 53);
            this.cipherFile1.Name = "cipherFile1";
            this.cipherFile1.Size = new System.Drawing.Size(240, 183);
            this.cipherFile1.TabIndex = 6;
            // 
            // AWiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cipherFile1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbMod);
            this.Controls.Add(this.CbFun);
            this.Controls.Add(this.CbDir);
            this.Controls.Add(this.LbOpt);
            this.Name = "AWiz";
            this.Size = new System.Drawing.Size(240, 236);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbOpt;
        private System.Windows.Forms.ComboBox CbDir;
        private System.Windows.Forms.ComboBox CbFun;
        private System.Windows.Forms.ComboBox CbMod;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private CipherFile cipherFile1;
    }
}

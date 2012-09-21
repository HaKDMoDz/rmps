namespace Me.Amon.Bar
{
    partial class UserSet
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
            this.LbForeColor = new System.Windows.Forms.Label();
            this.BtForeColor = new System.Windows.Forms.Button();
            this.LbBackColor = new System.Windows.Forms.Label();
            this.BtBackColor = new System.Windows.Forms.Button();
            this.LbDimW = new System.Windows.Forms.Label();
            this.SpDimW = new System.Windows.Forms.NumericUpDown();
            this.LbDimH = new System.Windows.Forms.Label();
            this.SpDimH = new System.Windows.Forms.NumericUpDown();
            this.LbError = new System.Windows.Forms.Label();
            this.CbError = new System.Windows.Forms.ComboBox();
            this.LbCoding = new System.Windows.Forms.Label();
            this.CbCoding = new System.Windows.Forms.ComboBox();
            this.CdDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.SpDimW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpDimH)).BeginInit();
            this.SuspendLayout();
            // 
            // LbForeColor
            // 
            this.LbForeColor.AutoSize = true;
            this.LbForeColor.Location = new System.Drawing.Point(0, 5);
            this.LbForeColor.Name = "LbForeColor";
            this.LbForeColor.Size = new System.Drawing.Size(47, 12);
            this.LbForeColor.TabIndex = 0;
            this.LbForeColor.Text = "前景(&F)";
            // 
            // BtForeColor
            // 
            this.BtForeColor.BackColor = System.Drawing.Color.Black;
            this.BtForeColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtForeColor.Location = new System.Drawing.Point(53, 0);
            this.BtForeColor.Name = "BtForeColor";
            this.BtForeColor.Size = new System.Drawing.Size(45, 23);
            this.BtForeColor.TabIndex = 1;
            this.BtForeColor.UseVisualStyleBackColor = false;
            this.BtForeColor.Click += new System.EventHandler(this.BtForeColor_Click);
            // 
            // LbBackColor
            // 
            this.LbBackColor.AutoSize = true;
            this.LbBackColor.Location = new System.Drawing.Point(104, 5);
            this.LbBackColor.Name = "LbBackColor";
            this.LbBackColor.Size = new System.Drawing.Size(47, 12);
            this.LbBackColor.TabIndex = 2;
            this.LbBackColor.Text = "背景(&B)";
            // 
            // BtBackColor
            // 
            this.BtBackColor.BackColor = System.Drawing.Color.White;
            this.BtBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtBackColor.Location = new System.Drawing.Point(157, 0);
            this.BtBackColor.Name = "BtBackColor";
            this.BtBackColor.Size = new System.Drawing.Size(45, 23);
            this.BtBackColor.TabIndex = 3;
            this.BtBackColor.UseVisualStyleBackColor = false;
            this.BtBackColor.Click += new System.EventHandler(this.BtBackColor_Click);
            // 
            // LbDimW
            // 
            this.LbDimW.AutoSize = true;
            this.LbDimW.Location = new System.Drawing.Point(0, 31);
            this.LbDimW.Name = "LbDimW";
            this.LbDimW.Size = new System.Drawing.Size(47, 12);
            this.LbDimW.TabIndex = 4;
            this.LbDimW.Text = "宽度(&W)";
            // 
            // SpDimW
            // 
            this.SpDimW.Location = new System.Drawing.Point(53, 29);
            this.SpDimW.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.SpDimW.Minimum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.SpDimW.Name = "SpDimW";
            this.SpDimW.Size = new System.Drawing.Size(45, 21);
            this.SpDimW.TabIndex = 5;
            this.SpDimW.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // LbDimH
            // 
            this.LbDimH.AutoSize = true;
            this.LbDimH.Location = new System.Drawing.Point(104, 31);
            this.LbDimH.Name = "LbDimH";
            this.LbDimH.Size = new System.Drawing.Size(47, 12);
            this.LbDimH.TabIndex = 6;
            this.LbDimH.Text = "高度(&H)";
            // 
            // SpDimH
            // 
            this.SpDimH.Location = new System.Drawing.Point(157, 29);
            this.SpDimH.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.SpDimH.Minimum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.SpDimH.Name = "SpDimH";
            this.SpDimH.Size = new System.Drawing.Size(45, 21);
            this.SpDimH.TabIndex = 7;
            this.SpDimH.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // LbError
            // 
            this.LbError.AutoSize = true;
            this.LbError.Location = new System.Drawing.Point(0, 59);
            this.LbError.Name = "LbError";
            this.LbError.Size = new System.Drawing.Size(47, 12);
            this.LbError.TabIndex = 8;
            this.LbError.Text = "纠错(&E)";
            // 
            // CbError
            // 
            this.CbError.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbError.FormattingEnabled = true;
            this.CbError.Location = new System.Drawing.Point(53, 56);
            this.CbError.Name = "CbError";
            this.CbError.Size = new System.Drawing.Size(45, 20);
            this.CbError.TabIndex = 9;
            // 
            // LbCoding
            // 
            this.LbCoding.AutoSize = true;
            this.LbCoding.Location = new System.Drawing.Point(104, 59);
            this.LbCoding.Name = "LbCoding";
            this.LbCoding.Size = new System.Drawing.Size(47, 12);
            this.LbCoding.TabIndex = 10;
            this.LbCoding.Text = "编码(&C)";
            // 
            // CbCoding
            // 
            this.CbCoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbCoding.FormattingEnabled = true;
            this.CbCoding.Location = new System.Drawing.Point(157, 56);
            this.CbCoding.Name = "CbCoding";
            this.CbCoding.Size = new System.Drawing.Size(139, 20);
            this.CbCoding.TabIndex = 11;
            // 
            // CdDialog
            // 
            this.CdDialog.FullOpen = true;
            // 
            // UserSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CbCoding);
            this.Controls.Add(this.LbCoding);
            this.Controls.Add(this.CbError);
            this.Controls.Add(this.LbError);
            this.Controls.Add(this.SpDimH);
            this.Controls.Add(this.LbDimH);
            this.Controls.Add(this.SpDimW);
            this.Controls.Add(this.LbDimW);
            this.Controls.Add(this.BtBackColor);
            this.Controls.Add(this.LbBackColor);
            this.Controls.Add(this.BtForeColor);
            this.Controls.Add(this.LbForeColor);
            this.Name = "UserSet";
            this.Size = new System.Drawing.Size(296, 76);
            ((System.ComponentModel.ISupportInitialize)(this.SpDimW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpDimH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbForeColor;
        private System.Windows.Forms.Button BtForeColor;
        private System.Windows.Forms.Label LbBackColor;
        private System.Windows.Forms.Button BtBackColor;
        private System.Windows.Forms.Label LbDimW;
        private System.Windows.Forms.NumericUpDown SpDimW;
        private System.Windows.Forms.Label LbDimH;
        private System.Windows.Forms.NumericUpDown SpDimH;
        private System.Windows.Forms.Label LbError;
        private System.Windows.Forms.ComboBox CbError;
        private System.Windows.Forms.Label LbCoding;
        private System.Windows.Forms.ComboBox CbCoding;
        private System.Windows.Forms.ColorDialog CdDialog;
    }
}

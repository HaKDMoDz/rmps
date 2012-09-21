namespace Me.Amon.Kms.Target.Asc
{
    partial class AscWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LbImgDim = new System.Windows.Forms.Label();
            this.TB_LocX = new System.Windows.Forms.TextBox();
            this.LbWinLocX = new System.Windows.Forms.Label();
            this.Tb_LocY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TbWinDimW = new System.Windows.Forms.TextBox();
            this.LbWinDimW = new System.Windows.Forms.Label();
            this.TbWinDimH = new System.Windows.Forms.TextBox();
            this.LbWinDimH = new System.Windows.Forms.Label();
            this.Ck_Scale = new System.Windows.Forms.CheckBox();
            this.Ck_Ratio = new System.Windows.Forms.CheckBox();
            this.Tb_Time = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.Tb_Time)).BeginInit();
            this.SuspendLayout();
            // 
            // LbImgDim
            // 
            this.LbImgDim.AutoSize = true;
            this.LbImgDim.Location = new System.Drawing.Point(12, 15);
            this.LbImgDim.Name = "LbImgDim";
            this.LbImgDim.Size = new System.Drawing.Size(71, 12);
            this.LbImgDim.TabIndex = 0;
            this.LbImgDim.Text = "图像大小(&D)";
            // 
            // TB_LocX
            // 
            this.TB_LocX.Location = new System.Drawing.Point(89, 91);
            this.TB_LocX.Name = "TB_LocX";
            this.TB_LocX.Size = new System.Drawing.Size(50, 21);
            this.TB_LocX.TabIndex = 1;
            // 
            // LbWinLocX
            // 
            this.LbWinLocX.AutoSize = true;
            this.LbWinLocX.Location = new System.Drawing.Point(60, 94);
            this.LbWinLocX.Name = "LbWinLocX";
            this.LbWinLocX.Size = new System.Drawing.Size(23, 12);
            this.LbWinLocX.TabIndex = 2;
            this.LbWinLocX.Text = "&X：";
            // 
            // Tb_LocY
            // 
            this.Tb_LocY.Location = new System.Drawing.Point(186, 91);
            this.Tb_LocY.Name = "Tb_LocY";
            this.Tb_LocY.Size = new System.Drawing.Size(50, 21);
            this.Tb_LocY.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Y：";
            // 
            // TbWinDimW
            // 
            this.TbWinDimW.Location = new System.Drawing.Point(89, 38);
            this.TbWinDimW.Name = "TbWinDimW";
            this.TbWinDimW.Size = new System.Drawing.Size(50, 21);
            this.TbWinDimW.TabIndex = 5;
            // 
            // LbWinDimW
            // 
            this.LbWinDimW.AutoSize = true;
            this.LbWinDimW.Location = new System.Drawing.Point(48, 41);
            this.LbWinDimW.Name = "LbWinDimW";
            this.LbWinDimW.Size = new System.Drawing.Size(35, 12);
            this.LbWinDimW.TabIndex = 6;
            this.LbWinDimW.Text = "宽(&W)";
            // 
            // TbWinDimH
            // 
            this.TbWinDimH.Location = new System.Drawing.Point(186, 38);
            this.TbWinDimH.Name = "TbWinDimH";
            this.TbWinDimH.Size = new System.Drawing.Size(50, 21);
            this.TbWinDimH.TabIndex = 7;
            // 
            // LbWinDimH
            // 
            this.LbWinDimH.AutoSize = true;
            this.LbWinDimH.Location = new System.Drawing.Point(145, 41);
            this.LbWinDimH.Name = "LbWinDimH";
            this.LbWinDimH.Size = new System.Drawing.Size(35, 12);
            this.LbWinDimH.TabIndex = 8;
            this.LbWinDimH.Text = "高(&H)";
            // 
            // Ck_Scale
            // 
            this.Ck_Scale.AutoSize = true;
            this.Ck_Scale.Location = new System.Drawing.Point(89, 118);
            this.Ck_Scale.Name = "Ck_Scale";
            this.Ck_Scale.Size = new System.Drawing.Size(72, 16);
            this.Ck_Scale.TabIndex = 9;
            this.Ck_Scale.Text = "缩放窗口";
            this.Ck_Scale.UseVisualStyleBackColor = true;
            // 
            // Ck_Ratio
            // 
            this.Ck_Ratio.AutoSize = true;
            this.Ck_Ratio.Location = new System.Drawing.Point(164, 118);
            this.Ck_Ratio.Name = "Ck_Ratio";
            this.Ck_Ratio.Size = new System.Drawing.Size(72, 16);
            this.Ck_Ratio.TabIndex = 10;
            this.Ck_Ratio.Text = "保持比例";
            this.Ck_Ratio.UseVisualStyleBackColor = true;
            // 
            // Tb_Time
            // 
            this.Tb_Time.Location = new System.Drawing.Point(94, 227);
            this.Tb_Time.Name = "Tb_Time";
            this.Tb_Time.Size = new System.Drawing.Size(50, 21);
            this.Tb_Time.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "执行等待(&I)";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "适应窗口",
            "指定大小"});
            this.comboBox1.Location = new System.Drawing.Point(89, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "窗口位置(&M)";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "居中",
            "左上角",
            "右上角",
            "左下角",
            "右下角",
            "自定义"});
            this.comboBox2.Location = new System.Drawing.Point(89, 65);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 16;
            // 
            // AscWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Tb_Time);
            this.Controls.Add(this.Ck_Ratio);
            this.Controls.Add(this.Ck_Scale);
            this.Controls.Add(this.LbWinDimH);
            this.Controls.Add(this.TbWinDimH);
            this.Controls.Add(this.LbWinDimW);
            this.Controls.Add(this.TbWinDimW);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Tb_LocY);
            this.Controls.Add(this.LbWinLocX);
            this.Controls.Add(this.TB_LocX);
            this.Controls.Add(this.LbImgDim);
            this.Name = "AscWindow";
            this.Text = "AscWindow";
            ((System.ComponentModel.ISupportInitialize)(this.Tb_Time)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbImgDim;
        private System.Windows.Forms.TextBox TB_LocX;
        private System.Windows.Forms.Label LbWinLocX;
        private System.Windows.Forms.TextBox Tb_LocY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TbWinDimW;
        private System.Windows.Forms.Label LbWinDimW;
        private System.Windows.Forms.TextBox TbWinDimH;
        private System.Windows.Forms.Label LbWinDimH;
        private System.Windows.Forms.CheckBox Ck_Scale;
        private System.Windows.Forms.CheckBox Ck_Ratio;
        private System.Windows.Forms.NumericUpDown Tb_Time;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}
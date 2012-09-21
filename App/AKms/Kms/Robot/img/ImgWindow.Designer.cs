namespace Me.Amon.Kms.Robot.img
{
    partial class ImgWindow
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
            this.LbImgDim = new System.Windows.Forms.Label();
            this.CbImgDim = new System.Windows.Forms.ComboBox();
            this.LbImgDimW = new System.Windows.Forms.Label();
            this.SpImgDimW = new System.Windows.Forms.NumericUpDown();
            this.LbImgDimH = new System.Windows.Forms.Label();
            this.SpImgDimH = new System.Windows.Forms.NumericUpDown();
            this.LbWinLoc = new System.Windows.Forms.Label();
            this.CbWinLoc = new System.Windows.Forms.ComboBox();
            this.LbWinLocX = new System.Windows.Forms.Label();
            this.SpWinLocX = new System.Windows.Forms.NumericUpDown();
            this.LbWinLocY = new System.Windows.Forms.Label();
            this.SpWinLocY = new System.Windows.Forms.NumericUpDown();
            this.CkRatio = new System.Windows.Forms.CheckBox();
            this.LbWait = new System.Windows.Forms.Label();
            this.SpWait = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SpImgDimW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpImgDimH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpWinLocX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpWinLocY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpWait)).BeginInit();
            this.SuspendLayout();
            // 
            // LbImgDim
            // 
            this.LbImgDim.AutoSize = true;
            this.LbImgDim.Location = new System.Drawing.Point(0, 3);
            this.LbImgDim.Name = "LbImgDim";
            this.LbImgDim.Size = new System.Drawing.Size(71, 12);
            this.LbImgDim.TabIndex = 0;
            this.LbImgDim.Text = "图像大小(&D)";
            // 
            // CbImgDim
            // 
            this.CbImgDim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbImgDim.FormattingEnabled = true;
            this.CbImgDim.Location = new System.Drawing.Point(77, 0);
            this.CbImgDim.Name = "CbImgDim";
            this.CbImgDim.Size = new System.Drawing.Size(95, 20);
            this.CbImgDim.TabIndex = 1;
            this.CbImgDim.SelectedIndexChanged += new System.EventHandler(this.CbImgDim_SelectedIndexChanged);
            // 
            // LbImgDimW
            // 
            this.LbImgDimW.AutoSize = true;
            this.LbImgDimW.Location = new System.Drawing.Point(36, 30);
            this.LbImgDimW.Name = "LbImgDimW";
            this.LbImgDimW.Size = new System.Drawing.Size(35, 12);
            this.LbImgDimW.TabIndex = 2;
            this.LbImgDimW.Text = "宽(&W)";
            // 
            // SpImgDimW
            // 
            this.SpImgDimW.Location = new System.Drawing.Point(77, 26);
            this.SpImgDimW.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.SpImgDimW.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpImgDimW.Name = "SpImgDimW";
            this.SpImgDimW.Size = new System.Drawing.Size(52, 21);
            this.SpImgDimW.TabIndex = 3;
            this.SpImgDimW.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // LbImgDimH
            // 
            this.LbImgDimH.AutoSize = true;
            this.LbImgDimH.Location = new System.Drawing.Point(36, 57);
            this.LbImgDimH.Name = "LbImgDimH";
            this.LbImgDimH.Size = new System.Drawing.Size(35, 12);
            this.LbImgDimH.TabIndex = 4;
            this.LbImgDimH.Text = "高(&H)";
            // 
            // SpImgDimH
            // 
            this.SpImgDimH.Location = new System.Drawing.Point(77, 53);
            this.SpImgDimH.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.SpImgDimH.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpImgDimH.Name = "SpImgDimH";
            this.SpImgDimH.Size = new System.Drawing.Size(52, 21);
            this.SpImgDimH.TabIndex = 5;
            this.SpImgDimH.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // LbWinLoc
            // 
            this.LbWinLoc.AutoSize = true;
            this.LbWinLoc.Location = new System.Drawing.Point(0, 105);
            this.LbWinLoc.Name = "LbWinLoc";
            this.LbWinLoc.Size = new System.Drawing.Size(71, 12);
            this.LbWinLoc.TabIndex = 6;
            this.LbWinLoc.Text = "窗口位置(&L)";
            // 
            // CbWinLoc
            // 
            this.CbWinLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbWinLoc.FormattingEnabled = true;
            this.CbWinLoc.Location = new System.Drawing.Point(77, 102);
            this.CbWinLoc.Name = "CbWinLoc";
            this.CbWinLoc.Size = new System.Drawing.Size(95, 20);
            this.CbWinLoc.TabIndex = 7;
            this.CbWinLoc.SelectedIndexChanged += new System.EventHandler(this.CbWinLoc_SelectedIndexChanged);
            // 
            // LbWinLocX
            // 
            this.LbWinLocX.AutoSize = true;
            this.LbWinLocX.Location = new System.Drawing.Point(36, 132);
            this.LbWinLocX.Name = "LbWinLocX";
            this.LbWinLocX.Size = new System.Drawing.Size(41, 12);
            this.LbWinLocX.TabIndex = 8;
            this.LbWinLocX.Text = "&X 坐标";
            // 
            // SpWinLocX
            // 
            this.SpWinLocX.Location = new System.Drawing.Point(77, 128);
            this.SpWinLocX.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.SpWinLocX.Name = "SpWinLocX";
            this.SpWinLocX.Size = new System.Drawing.Size(52, 21);
            this.SpWinLocX.TabIndex = 9;
            // 
            // LbWinLocY
            // 
            this.LbWinLocY.AutoSize = true;
            this.LbWinLocY.Location = new System.Drawing.Point(36, 159);
            this.LbWinLocY.Name = "LbWinLocY";
            this.LbWinLocY.Size = new System.Drawing.Size(41, 12);
            this.LbWinLocY.TabIndex = 10;
            this.LbWinLocY.Text = "&Y 坐标";
            // 
            // SpWinLocY
            // 
            this.SpWinLocY.Location = new System.Drawing.Point(77, 155);
            this.SpWinLocY.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.SpWinLocY.Name = "SpWinLocY";
            this.SpWinLocY.Size = new System.Drawing.Size(52, 21);
            this.SpWinLocY.TabIndex = 11;
            // 
            // CkRatio
            // 
            this.CkRatio.AutoSize = true;
            this.CkRatio.Checked = true;
            this.CkRatio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CkRatio.Location = new System.Drawing.Point(77, 80);
            this.CkRatio.Name = "CkRatio";
            this.CkRatio.Size = new System.Drawing.Size(90, 16);
            this.CkRatio.TabIndex = 13;
            this.CkRatio.Text = "维持比例(&R)";
            this.CkRatio.UseVisualStyleBackColor = true;
            // 
            // LbWait
            // 
            this.LbWait.AutoSize = true;
            this.LbWait.Location = new System.Drawing.Point(0, 186);
            this.LbWait.Name = "LbWait";
            this.LbWait.Size = new System.Drawing.Size(71, 12);
            this.LbWait.TabIndex = 14;
            this.LbWait.Text = "执行等待(&T)";
            // 
            // SpWait
            // 
            this.SpWait.Location = new System.Drawing.Point(77, 182);
            this.SpWait.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.SpWait.Name = "SpWait";
            this.SpWait.Size = new System.Drawing.Size(52, 21);
            this.SpWait.TabIndex = 15;
            this.SpWait.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(135, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "秒";
            // 
            // ImgWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.SpWait);
            this.Controls.Add(this.LbWait);
            this.Controls.Add(this.CkRatio);
            this.Controls.Add(this.SpWinLocY);
            this.Controls.Add(this.LbWinLocY);
            this.Controls.Add(this.SpWinLocX);
            this.Controls.Add(this.LbWinLocX);
            this.Controls.Add(this.CbWinLoc);
            this.Controls.Add(this.LbWinLoc);
            this.Controls.Add(this.SpImgDimH);
            this.Controls.Add(this.LbImgDimH);
            this.Controls.Add(this.SpImgDimW);
            this.Controls.Add(this.LbImgDimW);
            this.Controls.Add(this.CbImgDim);
            this.Controls.Add(this.LbImgDim);
            this.Name = "ImgWindow";
            this.Size = new System.Drawing.Size(172, 208);
            ((System.ComponentModel.ISupportInitialize)(this.SpImgDimW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpImgDimH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpWinLocX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpWinLocY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbImgDim;
        private System.Windows.Forms.ComboBox CbImgDim;
        private System.Windows.Forms.Label LbImgDimW;
        private System.Windows.Forms.NumericUpDown SpImgDimW;
        private System.Windows.Forms.Label LbImgDimH;
        private System.Windows.Forms.NumericUpDown SpImgDimH;
        private System.Windows.Forms.Label LbWinLoc;
        private System.Windows.Forms.ComboBox CbWinLoc;
        private System.Windows.Forms.Label LbWinLocX;
        private System.Windows.Forms.NumericUpDown SpWinLocX;
        private System.Windows.Forms.Label LbWinLocY;
        private System.Windows.Forms.NumericUpDown SpWinLocY;
        private System.Windows.Forms.CheckBox CkRatio;
        private System.Windows.Forms.Label LbWait;
        private System.Windows.Forms.NumericUpDown SpWait;
        private System.Windows.Forms.Label label8;
    }
}

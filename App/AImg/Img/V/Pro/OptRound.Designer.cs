namespace Me.Amon.Img.V.Pro
{
    partial class OptRound
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LtWidth = new System.Windows.Forms.Label();
            this.SpWidth = new System.Windows.Forms.NumericUpDown();
            this.SpHeight = new System.Windows.Forms.NumericUpDown();
            this.LtHeight = new System.Windows.Forms.Label();
            this.LvWidth = new System.Windows.Forms.Label();
            this.LvHeight = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PbColor = new System.Windows.Forms.PictureBox();
            this.CkColor = new System.Windows.Forms.CheckBox();
            this.UcLoc = new Me.Amon.Img.V.Pro.BeanPos();
            ((System.ComponentModel.ISupportInitialize)(this.SpWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbColor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "位置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "大小";
            // 
            // LtWidth
            // 
            this.LtWidth.AutoSize = true;
            this.LtWidth.Location = new System.Drawing.Point(28, 145);
            this.LtWidth.Name = "LtWidth";
            this.LtWidth.Size = new System.Drawing.Size(29, 12);
            this.LtWidth.TabIndex = 3;
            this.LtWidth.Text = "水平";
            // 
            // SpWidth
            // 
            this.SpWidth.Location = new System.Drawing.Point(63, 141);
            this.SpWidth.Name = "SpWidth";
            this.SpWidth.Size = new System.Drawing.Size(61, 21);
            this.SpWidth.TabIndex = 4;
            // 
            // SpHeight
            // 
            this.SpHeight.Location = new System.Drawing.Point(63, 168);
            this.SpHeight.Name = "SpHeight";
            this.SpHeight.Size = new System.Drawing.Size(61, 21);
            this.SpHeight.TabIndex = 6;
            // 
            // LtHeight
            // 
            this.LtHeight.AutoSize = true;
            this.LtHeight.Location = new System.Drawing.Point(28, 172);
            this.LtHeight.Name = "LtHeight";
            this.LtHeight.Size = new System.Drawing.Size(29, 12);
            this.LtHeight.TabIndex = 5;
            this.LtHeight.Text = "垂直";
            // 
            // LvWidth
            // 
            this.LvWidth.AutoSize = true;
            this.LvWidth.Location = new System.Drawing.Point(130, 145);
            this.LvWidth.Name = "LvWidth";
            this.LvWidth.Size = new System.Drawing.Size(29, 12);
            this.LvWidth.TabIndex = 7;
            this.LvWidth.Text = "像素";
            // 
            // LvHeight
            // 
            this.LvHeight.AutoSize = true;
            this.LvHeight.Location = new System.Drawing.Point(129, 172);
            this.LvHeight.Name = "LvHeight";
            this.LvHeight.Size = new System.Drawing.Size(29, 12);
            this.LvHeight.TabIndex = 8;
            this.LvHeight.Text = "像素";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "背景";
            // 
            // PbColor
            // 
            this.PbColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbColor.Location = new System.Drawing.Point(38, 205);
            this.PbColor.Name = "PbColor";
            this.PbColor.Size = new System.Drawing.Size(20, 20);
            this.PbColor.TabIndex = 10;
            this.PbColor.TabStop = false;
            this.PbColor.Click += new System.EventHandler(this.PbColor_Click);
            // 
            // CkColor
            // 
            this.CkColor.AutoSize = true;
            this.CkColor.Location = new System.Drawing.Point(64, 207);
            this.CkColor.Name = "CkColor";
            this.CkColor.Size = new System.Drawing.Size(48, 16);
            this.CkColor.TabIndex = 11;
            this.CkColor.Text = "透明";
            this.CkColor.UseVisualStyleBackColor = true;
            this.CkColor.CheckedChanged += new System.EventHandler(this.CkColor_CheckedChanged);
            // 
            // UcLoc
            // 
            this.UcLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UcLoc.Location = new System.Drawing.Point(28, 24);
            this.UcLoc.Name = "UcLoc";
            this.UcLoc.Size = new System.Drawing.Size(130, 75);
            this.UcLoc.TabIndex = 1;
            // 
            // OptRound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CkColor);
            this.Controls.Add(this.PbColor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LvHeight);
            this.Controls.Add(this.LvWidth);
            this.Controls.Add(this.SpHeight);
            this.Controls.Add(this.LtHeight);
            this.Controls.Add(this.SpWidth);
            this.Controls.Add(this.LtWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UcLoc);
            this.Controls.Add(this.label1);
            this.Name = "OptRound";
            this.Size = new System.Drawing.Size(194, 310);
            ((System.ComponentModel.ISupportInitialize)(this.SpWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private BeanPos UcLoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LtWidth;
        private System.Windows.Forms.NumericUpDown SpWidth;
        private System.Windows.Forms.NumericUpDown SpHeight;
        private System.Windows.Forms.Label LtHeight;
        private System.Windows.Forms.Label LvWidth;
        private System.Windows.Forms.Label LvHeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox PbColor;
        private System.Windows.Forms.CheckBox CkColor;
    }
}

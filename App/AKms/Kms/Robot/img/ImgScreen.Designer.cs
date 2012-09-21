namespace Me.Amon.Kms.Robot.img
{
    partial class ImgScreen
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
            this.CkHide = new System.Windows.Forms.CheckBox();
            this.LbWait = new System.Windows.Forms.Label();
            this.SpWait = new System.Windows.Forms.NumericUpDown();
            this.LbUnit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SpWait)).BeginInit();
            this.SuspendLayout();
            // 
            // CkHide
            // 
            this.CkHide.AutoSize = true;
            this.CkHide.Checked = true;
            this.CkHide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CkHide.Location = new System.Drawing.Point(0, 0);
            this.CkHide.Name = "CkHide";
            this.CkHide.Size = new System.Drawing.Size(102, 16);
            this.CkHide.TabIndex = 0;
            this.CkHide.Text = "隐藏主界面(&M)";
            this.CkHide.UseVisualStyleBackColor = true;
            // 
            // LbWait
            // 
            this.LbWait.AutoSize = true;
            this.LbWait.Location = new System.Drawing.Point(3, 26);
            this.LbWait.Name = "LbWait";
            this.LbWait.Size = new System.Drawing.Size(71, 12);
            this.LbWait.TabIndex = 1;
            this.LbWait.Text = "执行等待(&T)";
            // 
            // SpWait
            // 
            this.SpWait.Location = new System.Drawing.Point(80, 22);
            this.SpWait.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.SpWait.Name = "SpWait";
            this.SpWait.Size = new System.Drawing.Size(50, 21);
            this.SpWait.TabIndex = 2;
            this.SpWait.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LbUnit
            // 
            this.LbUnit.AutoSize = true;
            this.LbUnit.Location = new System.Drawing.Point(136, 26);
            this.LbUnit.Name = "LbUnit";
            this.LbUnit.Size = new System.Drawing.Size(17, 12);
            this.LbUnit.TabIndex = 3;
            this.LbUnit.Text = "秒";
            // 
            // ImgScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LbUnit);
            this.Controls.Add(this.SpWait);
            this.Controls.Add(this.LbWait);
            this.Controls.Add(this.CkHide);
            this.Name = "ImgScreen";
            this.Size = new System.Drawing.Size(172, 208);
            ((System.ComponentModel.ISupportInitialize)(this.SpWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CkHide;
        private System.Windows.Forms.Label LbWait;
        private System.Windows.Forms.NumericUpDown SpWait;
        private System.Windows.Forms.Label LbUnit;
    }
}

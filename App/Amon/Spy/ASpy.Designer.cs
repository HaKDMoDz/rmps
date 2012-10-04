namespace Me.Amon.Spy
{
    partial class ASpy
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
            this.TbSpy = new System.Windows.Forms.TextBox();
            this.PbSpy = new System.Windows.Forms.PictureBox();
            this.LlSpy = new System.Windows.Forms.Label();
            this.PbCopy = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbSpy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbCopy)).BeginInit();
            this.SuspendLayout();
            // 
            // TbSpy
            // 
            this.TbSpy.BackColor = System.Drawing.SystemColors.Window;
            this.TbSpy.Location = new System.Drawing.Point(50, 32);
            this.TbSpy.Name = "TbSpy";
            this.TbSpy.ReadOnly = true;
            this.TbSpy.Size = new System.Drawing.Size(185, 21);
            this.TbSpy.TabIndex = 2;
            this.TbSpy.TabStop = false;
            // 
            // PbSpy
            // 
            this.PbSpy.Location = new System.Drawing.Point(12, 20);
            this.PbSpy.Name = "PbSpy";
            this.PbSpy.Size = new System.Drawing.Size(32, 32);
            this.PbSpy.TabIndex = 0;
            this.PbSpy.TabStop = false;
            this.PbSpy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbApp_MouseDown);
            this.PbSpy.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbApp_MouseMove);
            this.PbSpy.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbApp_MouseUp);
            // 
            // LlSpy
            // 
            this.LlSpy.AutoSize = true;
            this.LlSpy.Location = new System.Drawing.Point(50, 17);
            this.LlSpy.Name = "LlSpy";
            this.LlSpy.Size = new System.Drawing.Size(185, 12);
            this.LlSpy.TabIndex = 1;
            this.LlSpy.Text = "请拖动图标到您要查看的控件上：";
            // 
            // PbCopy
            // 
            this.PbCopy.Location = new System.Drawing.Point(241, 36);
            this.PbCopy.Name = "PbCopy";
            this.PbCopy.Size = new System.Drawing.Size(16, 16);
            this.PbCopy.TabIndex = 3;
            this.PbCopy.TabStop = false;
            // 
            // ASpy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 79);
            this.Controls.Add(this.PbCopy);
            this.Controls.Add(this.LlSpy);
            this.Controls.Add(this.TbSpy);
            this.Controls.Add(this.PbSpy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ASpy";
            this.Text = "ASpy";
            ((System.ComponentModel.ISupportInitialize)(this.PbSpy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbCopy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbSpy;
        private System.Windows.Forms.PictureBox PbSpy;
        private System.Windows.Forms.Label LlSpy;
        private System.Windows.Forms.PictureBox PbCopy;

    }
}
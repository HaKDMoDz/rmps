namespace Me.Amon.Kms.Robot.img
{
    partial class ImgControl
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
            this.TbCmpTitle = new System.Windows.Forms.TextBox();
            this.LbCmpTitle = new System.Windows.Forms.Label();
            this.TbCmpClass = new System.Windows.Forms.TextBox();
            this.LbCmpClass = new System.Windows.Forms.Label();
            this.TbCmpDim = new System.Windows.Forms.TextBox();
            this.LbCmpDim = new System.Windows.Forms.Label();
            this.TbCmpLoc = new System.Windows.Forms.TextBox();
            this.LbCmpLoc = new System.Windows.Forms.Label();
            this.PbApp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbApp)).BeginInit();
            this.SuspendLayout();
            // 
            // TbCmpTitle
            // 
            this.TbCmpTitle.Location = new System.Drawing.Point(53, 81);
            this.TbCmpTitle.Multiline = true;
            this.TbCmpTitle.Name = "TbCmpTitle";
            this.TbCmpTitle.ReadOnly = true;
            this.TbCmpTitle.Size = new System.Drawing.Size(119, 55);
            this.TbCmpTitle.TabIndex = 18;
            this.TbCmpTitle.TabStop = false;
            // 
            // LbCmpTitle
            // 
            this.LbCmpTitle.AutoSize = true;
            this.LbCmpTitle.Location = new System.Drawing.Point(0, 84);
            this.LbCmpTitle.Name = "LbCmpTitle";
            this.LbCmpTitle.Size = new System.Drawing.Size(47, 12);
            this.LbCmpTitle.TabIndex = 17;
            this.LbCmpTitle.Text = "标题(&T)";
            // 
            // TbCmpClass
            // 
            this.TbCmpClass.Location = new System.Drawing.Point(53, 54);
            this.TbCmpClass.Name = "TbCmpClass";
            this.TbCmpClass.ReadOnly = true;
            this.TbCmpClass.Size = new System.Drawing.Size(119, 21);
            this.TbCmpClass.TabIndex = 16;
            this.TbCmpClass.TabStop = false;
            // 
            // LbCmpClass
            // 
            this.LbCmpClass.AutoSize = true;
            this.LbCmpClass.Location = new System.Drawing.Point(0, 57);
            this.LbCmpClass.Name = "LbCmpClass";
            this.LbCmpClass.Size = new System.Drawing.Size(47, 12);
            this.LbCmpClass.TabIndex = 15;
            this.LbCmpClass.Text = "类型(&C)";
            // 
            // TbCmpDim
            // 
            this.TbCmpDim.Location = new System.Drawing.Point(91, 27);
            this.TbCmpDim.Name = "TbCmpDim";
            this.TbCmpDim.ReadOnly = true;
            this.TbCmpDim.Size = new System.Drawing.Size(81, 21);
            this.TbCmpDim.TabIndex = 14;
            this.TbCmpDim.TabStop = false;
            // 
            // LbCmpDim
            // 
            this.LbCmpDim.AutoSize = true;
            this.LbCmpDim.Location = new System.Drawing.Point(38, 30);
            this.LbCmpDim.Name = "LbCmpDim";
            this.LbCmpDim.Size = new System.Drawing.Size(47, 12);
            this.LbCmpDim.TabIndex = 13;
            this.LbCmpDim.Text = "大小(&S)";
            // 
            // TbCmpLoc
            // 
            this.TbCmpLoc.Location = new System.Drawing.Point(91, 0);
            this.TbCmpLoc.Name = "TbCmpLoc";
            this.TbCmpLoc.ReadOnly = true;
            this.TbCmpLoc.Size = new System.Drawing.Size(81, 21);
            this.TbCmpLoc.TabIndex = 12;
            this.TbCmpLoc.TabStop = false;
            // 
            // LbCmpLoc
            // 
            this.LbCmpLoc.AutoSize = true;
            this.LbCmpLoc.Location = new System.Drawing.Point(38, 3);
            this.LbCmpLoc.Name = "LbCmpLoc";
            this.LbCmpLoc.Size = new System.Drawing.Size(47, 12);
            this.LbCmpLoc.TabIndex = 11;
            this.LbCmpLoc.Text = "坐标(&L)";
            // 
            // PbApp
            // 
            this.PbApp.Image = global::Me.Amon.Properties.Resources._def;
            this.PbApp.Location = new System.Drawing.Point(0, 6);
            this.PbApp.Name = "PbApp";
            this.PbApp.Size = new System.Drawing.Size(32, 32);
            this.PbApp.TabIndex = 10;
            this.PbApp.TabStop = false;
            this.PbApp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbApp_MouseMove);
            this.PbApp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbApp_MouseDown);
            this.PbApp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbApp_MouseUp);
            // 
            // ImgControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbCmpTitle);
            this.Controls.Add(this.LbCmpTitle);
            this.Controls.Add(this.TbCmpClass);
            this.Controls.Add(this.LbCmpClass);
            this.Controls.Add(this.TbCmpDim);
            this.Controls.Add(this.LbCmpDim);
            this.Controls.Add(this.TbCmpLoc);
            this.Controls.Add(this.LbCmpLoc);
            this.Controls.Add(this.PbApp);
            this.Name = "ImgControl";
            this.Size = new System.Drawing.Size(172, 208);
            ((System.ComponentModel.ISupportInitialize)(this.PbApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbCmpTitle;
        private System.Windows.Forms.Label LbCmpTitle;
        private System.Windows.Forms.TextBox TbCmpClass;
        private System.Windows.Forms.Label LbCmpClass;
        private System.Windows.Forms.TextBox TbCmpDim;
        private System.Windows.Forms.Label LbCmpDim;
        private System.Windows.Forms.TextBox TbCmpLoc;
        private System.Windows.Forms.Label LbCmpLoc;
        private System.Windows.Forms.PictureBox PbApp;
    }
}

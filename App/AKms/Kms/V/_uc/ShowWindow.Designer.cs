namespace Me.Amon._uc
{
    partial class ShowWindow
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
            this.components = new System.ComponentModel.Container();
            this.LbWin = new System.Windows.Forms.Label();
            this.TbWin = new System.Windows.Forms.TextBox();
            this.PbWin = new System.Windows.Forms.PictureBox();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PbWin)).BeginInit();
            this.SuspendLayout();
            // 
            // LbWin
            // 
            this.LbWin.AutoSize = true;
            this.LbWin.Location = new System.Drawing.Point(3, 7);
            this.LbWin.Name = "LbWin";
            this.LbWin.Size = new System.Drawing.Size(47, 12);
            this.LbWin.TabIndex = 0;
            this.LbWin.Text = "窗口(&W)";
            // 
            // TbWin
            // 
            this.TbWin.Location = new System.Drawing.Point(56, 3);
            this.TbWin.Name = "TbWin";
            this.TbWin.Size = new System.Drawing.Size(181, 21);
            this.TbWin.TabIndex = 1;
            this.TpTips.SetToolTip(this.TbWin, "格式：窗口类型:窗口名称");
            // 
            // PbWin
            // 
            this.PbWin.Image = global::Me.Amon.Properties.Resources.Find;
            this.PbWin.Location = new System.Drawing.Point(243, 5);
            this.PbWin.Margin = new System.Windows.Forms.Padding(0);
            this.PbWin.Name = "PbWin";
            this.PbWin.Size = new System.Drawing.Size(16, 16);
            this.PbWin.TabIndex = 2;
            this.PbWin.TabStop = false;
            this.TpTips.SetToolTip(this.PbWin, "拖动以查找窗口");
            this.PbWin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbWin_MouseMove);
            this.PbWin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbWin_MouseDown);
            this.PbWin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbWin_MouseUp);
            // 
            // ShowWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbWin);
            this.Controls.Add(this.TbWin);
            this.Controls.Add(this.LbWin);
            this.Name = "ShowWindow";
            this.Size = new System.Drawing.Size(262, 27);
            ((System.ComponentModel.ISupportInitialize)(this.PbWin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbWin;
        private System.Windows.Forms.TextBox TbWin;
        private System.Windows.Forms.PictureBox PbWin;
        private System.Windows.Forms.ToolTip TpTips;
    }
}

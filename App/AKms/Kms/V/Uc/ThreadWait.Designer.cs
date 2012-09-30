namespace Me.Amon.Kms.V.Uc
{
    partial class ThreadWait
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
            this.LbTime = new System.Windows.Forms.Label();
            this.TbTime = new System.Windows.Forms.TextBox();
            this.CbTime = new System.Windows.Forms.CheckBox();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // LbTime
            // 
            this.LbTime.AutoSize = true;
            this.LbTime.Location = new System.Drawing.Point(3, 7);
            this.LbTime.Name = "LbTime";
            this.LbTime.Size = new System.Drawing.Size(47, 12);
            this.LbTime.TabIndex = 0;
            this.LbTime.Text = "时长(&T)";
            // 
            // TbTime
            // 
            this.TbTime.Location = new System.Drawing.Point(56, 3);
            this.TbTime.Name = "TbTime";
            this.TbTime.Size = new System.Drawing.Size(131, 21);
            this.TbTime.TabIndex = 1;
            this.TpTips.SetToolTip(this.TbTime, "单位：毫秒");
            // 
            // CbTime
            // 
            this.CbTime.AutoSize = true;
            this.CbTime.Location = new System.Drawing.Point(193, 6);
            this.CbTime.Name = "CbTime";
            this.CbTime.Size = new System.Drawing.Size(66, 16);
            this.CbTime.TabIndex = 2;
            this.CbTime.Text = "随机(&R)";
            this.CbTime.UseVisualStyleBackColor = true;
            this.CbTime.CheckedChanged += new System.EventHandler(this.CbTime_CheckedChanged);
            // 
            // ThreadWait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CbTime);
            this.Controls.Add(this.TbTime);
            this.Controls.Add(this.LbTime);
            this.Name = "ThreadWait";
            this.Size = new System.Drawing.Size(262, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbTime;
        private System.Windows.Forms.TextBox TbTime;
        private System.Windows.Forms.CheckBox CbTime;
        private System.Windows.Forms.ToolTip TpTips;
    }
}

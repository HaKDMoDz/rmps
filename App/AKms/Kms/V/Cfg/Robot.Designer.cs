namespace Me.Amon.Kms.V.Cfg
{
    partial class Robot
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
            this.LbRobot = new System.Windows.Forms.Label();
            this.TbRobot = new System.Windows.Forms.TextBox();
            this.LbOwner = new System.Windows.Forms.Label();
            this.TbOwner = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LbRobot
            // 
            this.LbRobot.AutoSize = true;
            this.LbRobot.Location = new System.Drawing.Point(3, 6);
            this.LbRobot.Name = "LbRobot";
            this.LbRobot.Size = new System.Drawing.Size(83, 12);
            this.LbRobot.TabIndex = 0;
            this.LbRobot.Text = "机器人名字(&R)";
            // 
            // TbRobot
            // 
            this.TbRobot.Location = new System.Drawing.Point(92, 3);
            this.TbRobot.Name = "TbRobot";
            this.TbRobot.Size = new System.Drawing.Size(130, 21);
            this.TbRobot.TabIndex = 1;
            // 
            // LbOwner
            // 
            this.LbOwner.AutoSize = true;
            this.LbOwner.Location = new System.Drawing.Point(3, 33);
            this.LbOwner.Name = "LbOwner";
            this.LbOwner.Size = new System.Drawing.Size(71, 12);
            this.LbOwner.TabIndex = 2;
            this.LbOwner.Text = "您的名字(&U)";
            // 
            // TbOwner
            // 
            this.TbOwner.Location = new System.Drawing.Point(92, 30);
            this.TbOwner.Name = "TbOwner";
            this.TbOwner.Size = new System.Drawing.Size(130, 21);
            this.TbOwner.TabIndex = 3;
            // 
            // Robot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbOwner);
            this.Controls.Add(this.LbOwner);
            this.Controls.Add(this.TbRobot);
            this.Controls.Add(this.LbRobot);
            this.Name = "Robot";
            this.Size = new System.Drawing.Size(225, 187);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbRobot;
        private System.Windows.Forms.TextBox TbRobot;
        private System.Windows.Forms.Label LbOwner;
        private System.Windows.Forms.TextBox TbOwner;
    }
}

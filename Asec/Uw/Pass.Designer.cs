namespace Msec.Uw
{
    partial class Pass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pass));
            this.PlPass = new System.Windows.Forms.Panel();
            this.LbPass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PlPass
            // 
            this.PlPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlPass.Location = new System.Drawing.Point(12, 12);
            this.PlPass.Name = "PlPass";
            this.PlPass.Size = new System.Drawing.Size(128, 128);
            this.PlPass.TabIndex = 0;
            // 
            // LbPass
            // 
            this.LbPass.AutoSize = true;
            this.LbPass.Location = new System.Drawing.Point(10, 148);
            this.LbPass.Name = "LbPass";
            this.LbPass.Size = new System.Drawing.Size(101, 12);
            this.LbPass.TabIndex = 1;
            this.LbPass.Text = "请移动您的鼠标！";
            // 
            // Pass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(152, 169);
            this.Controls.Add(this.LbPass);
            this.Controls.Add(this.PlPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pass";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "口令";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PlPass;
        private System.Windows.Forms.Label LbPass;
    }
}
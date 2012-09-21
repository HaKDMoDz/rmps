namespace Me.Amon.Uw
{
    partial class Waiting
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
            this.LbMsg = new System.Windows.Forms.Label();
            this.PbImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbImg)).BeginInit();
            this.SuspendLayout();
            // 
            // LbMsg
            // 
            this.LbMsg.Location = new System.Drawing.Point(12, 35);
            this.LbMsg.Name = "LbMsg";
            this.LbMsg.Size = new System.Drawing.Size(160, 12);
            this.LbMsg.TabIndex = 1;
            this.LbMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PbImg
            // 
            this.PbImg.Image = global::Me.Amon.Properties.Resources.Waiting;
            this.PbImg.Location = new System.Drawing.Point(12, 12);
            this.PbImg.Name = "PbImg";
            this.PbImg.Size = new System.Drawing.Size(160, 20);
            this.PbImg.TabIndex = 0;
            this.PbImg.TabStop = false;
            // 
            // Waiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 56);
            this.Controls.Add(this.LbMsg);
            this.Controls.Add(this.PbImg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Waiting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Waiting";
            ((System.ComponentModel.ISupportInitialize)(this.PbImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PbImg;
        private System.Windows.Forms.Label LbMsg;
    }
}
namespace Me.Amon.V.Guid
{
    partial class Tips
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PbImg = new System.Windows.Forms.PictureBox();
            this.LlTip = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbImg)).BeginInit();
            this.SuspendLayout();
            // 
            // PbImg
            // 
            this.PbImg.Location = new System.Drawing.Point(0, 0);
            this.PbImg.Name = "PbImg";
            this.PbImg.Size = new System.Drawing.Size(280, 140);
            this.PbImg.TabIndex = 0;
            this.PbImg.TabStop = false;
            // 
            // LlTip
            // 
            this.LlTip.Location = new System.Drawing.Point(12, 36);
            this.LlTip.Name = "LlTip";
            this.LlTip.Size = new System.Drawing.Size(256, 62);
            this.LlTip.TabIndex = 1;
            this.LlTip.Text = "label1";
            this.LlTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 140);
            this.Controls.Add(this.LlTip);
            this.Controls.Add(this.PbImg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Tips";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tips";
            this.TransparencyKey = System.Drawing.Color.Cyan;
            ((System.ComponentModel.ISupportInitialize)(this.PbImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PbImg;
        private System.Windows.Forms.Label LlTip;
    }
}
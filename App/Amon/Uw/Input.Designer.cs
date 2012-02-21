namespace Me.Amon.Uw
{
    partial class Input
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Input));
            this.PbIcon = new System.Windows.Forms.PictureBox();
            this.LbTips = new System.Windows.Forms.Label();
            this.TbText = new System.Windows.Forms.TextBox();
            this.BtOk = new System.Windows.Forms.Button();
            this.BtCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // PbIcon
            // 
            this.PbIcon.Location = new System.Drawing.Point(12, 27);
            this.PbIcon.Name = "PbIcon";
            this.PbIcon.Size = new System.Drawing.Size(32, 32);
            this.PbIcon.TabIndex = 0;
            this.PbIcon.TabStop = false;
            // 
            // LbTips
            // 
            this.LbTips.AutoSize = true;
            this.LbTips.Location = new System.Drawing.Point(50, 23);
            this.LbTips.Name = "LbTips";
            this.LbTips.Size = new System.Drawing.Size(41, 12);
            this.LbTips.TabIndex = 1;
            this.LbTips.Text = "label1";
            // 
            // TbText
            // 
            this.TbText.Location = new System.Drawing.Point(52, 38);
            this.TbText.Name = "TbText";
            this.TbText.Size = new System.Drawing.Size(206, 21);
            this.TbText.TabIndex = 2;
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(106, 77);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 3;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // BtCancel
            // 
            this.BtCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtCancel.Location = new System.Drawing.Point(187, 77);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(75, 23);
            this.BtCancel.TabIndex = 4;
            this.BtCancel.Text = "取消(&C)";
            this.BtCancel.UseVisualStyleBackColor = true;
            this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // Input
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtCancel;
            this.ClientSize = new System.Drawing.Size(274, 112);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.TbText);
            this.Controls.Add(this.LbTips);
            this.Controls.Add(this.PbIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Input";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "输入";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Input_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbIcon;
        private System.Windows.Forms.Label LbTips;
        private System.Windows.Forms.TextBox TbText;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtCancel;
    }
}
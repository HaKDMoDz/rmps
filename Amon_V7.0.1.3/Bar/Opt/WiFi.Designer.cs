namespace Me.Amon.Bar.Opt
{
    partial class Wifi
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
            this.LbType = new System.Windows.Forms.Label();
            this.CbType = new System.Windows.Forms.ComboBox();
            this.LbSsid = new System.Windows.Forms.Label();
            this.TbSsid = new System.Windows.Forms.TextBox();
            this.LbPass = new System.Windows.Forms.Label();
            this.TbPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LbType
            // 
            this.LbType.AutoSize = true;
            this.LbType.Location = new System.Drawing.Point(0, 3);
            this.LbType.Name = "LbType";
            this.LbType.Size = new System.Drawing.Size(29, 12);
            this.LbType.TabIndex = 0;
            this.LbType.Text = "类型";
            // 
            // CbType
            // 
            this.CbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbType.FormattingEnabled = true;
            this.CbType.Items.AddRange(new object[] {
            "WPA",
            "WEP",
            "No encryption"});
            this.CbType.Location = new System.Drawing.Point(35, 0);
            this.CbType.Name = "CbType";
            this.CbType.Size = new System.Drawing.Size(121, 20);
            this.CbType.TabIndex = 1;
            // 
            // LbSsid
            // 
            this.LbSsid.AutoSize = true;
            this.LbSsid.Location = new System.Drawing.Point(0, 29);
            this.LbSsid.Name = "LbSsid";
            this.LbSsid.Size = new System.Drawing.Size(29, 12);
            this.LbSsid.TabIndex = 2;
            this.LbSsid.Text = "SSID";
            // 
            // TbSsid
            // 
            this.TbSsid.Location = new System.Drawing.Point(35, 26);
            this.TbSsid.Name = "TbSsid";
            this.TbSsid.Size = new System.Drawing.Size(261, 21);
            this.TbSsid.TabIndex = 3;
            // 
            // LbPass
            // 
            this.LbPass.AutoSize = true;
            this.LbPass.Location = new System.Drawing.Point(0, 56);
            this.LbPass.Name = "LbPass";
            this.LbPass.Size = new System.Drawing.Size(29, 12);
            this.LbPass.TabIndex = 4;
            this.LbPass.Text = "口令";
            // 
            // TbPass
            // 
            this.TbPass.Location = new System.Drawing.Point(35, 53);
            this.TbPass.Name = "TbPass";
            this.TbPass.Size = new System.Drawing.Size(261, 21);
            this.TbPass.TabIndex = 5;
            // 
            // Wifi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbPass);
            this.Controls.Add(this.LbPass);
            this.Controls.Add(this.TbSsid);
            this.Controls.Add(this.LbSsid);
            this.Controls.Add(this.CbType);
            this.Controls.Add(this.LbType);
            this.Name = "Wifi";
            this.Size = new System.Drawing.Size(296, 156);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbType;
        private System.Windows.Forms.ComboBox CbType;
        private System.Windows.Forms.Label LbSsid;
        private System.Windows.Forms.TextBox TbSsid;
        private System.Windows.Forms.Label LbPass;
        private System.Windows.Forms.TextBox TbPass;
    }
}

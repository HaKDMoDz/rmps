namespace Me.Amon.Pwd.Pro
{
    partial class BeanGuid
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
            this.LbName = new System.Windows.Forms.Label();
            this.CbName = new System.Windows.Forms.ComboBox();
            this.BtOpt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(3, 6);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(47, 12);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "模板(&T)";
            // 
            // CbName
            // 
            this.CbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbName.FormattingEnabled = true;
            this.CbName.Location = new System.Drawing.Point(56, 3);
            this.CbName.Name = "CbName";
            this.CbName.Size = new System.Drawing.Size(121, 20);
            this.CbName.TabIndex = 1;
            // 
            // BtOpt
            // 
            this.BtOpt.Location = new System.Drawing.Point(56, 29);
            this.BtOpt.Name = "BtOpt";
            this.BtOpt.Size = new System.Drawing.Size(21, 21);
            this.BtOpt.TabIndex = 2;
            this.BtOpt.Text = "button1";
            this.BtOpt.UseVisualStyleBackColor = true;
            this.BtOpt.Click += new System.EventHandler(this.button1_Click);
            // 
            // BeanGuid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtOpt);
            this.Controls.Add(this.CbName);
            this.Controls.Add(this.LbName);
            this.Name = "BeanGuid";
            this.Size = new System.Drawing.Size(366, 81);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.ComboBox CbName;
        private System.Windows.Forms.Button BtOpt;
    }
}

namespace Me.Amon.Spy
{
    partial class ASpy
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
            this.appWindow1 = new com.magickms.target.app.AppWindow();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // appWindow1
            // 
            this.appWindow1.Location = new System.Drawing.Point(12, 12);
            this.appWindow1.Name = "appWindow1";
            this.appWindow1.Size = new System.Drawing.Size(240, 122);
            this.appWindow1.TabIndex = 0;
// TODO: “”的代码生成失败，原因是出现异常“无效的基元类型: System.IntPtr。请考虑使用 CodeObjectCreateExpression。”。
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(12, 140);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(260, 110);
            this.propertyGrid1.TabIndex = 1;
            // 
            // ASpy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.appWindow1);
            this.Name = "ASpy";
            this.Text = "ASpy";
            this.ResumeLayout(false);

        }

        #endregion

        private com.magickms.target.app.AppWindow appWindow1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
    }
}
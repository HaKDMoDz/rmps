namespace Me.Amon.Spy.V.Pro
{
    partial class APro
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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.appWindow1 = new Me.Amon.Spy.V.Wiz.AWiz();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(3, 131);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(260, 178);
            this.propertyGrid1.TabIndex = 3;
            // 
            // appWindow1
            // 
            this.appWindow1.Location = new System.Drawing.Point(3, 3);
            this.appWindow1.Name = "appWindow1";
            this.appWindow1.Size = new System.Drawing.Size(240, 122);
            this.appWindow1.TabIndex = 2;
            // TODO: “this.appWindow1.UserWindow”的代码生成失败，原因是出现异常“无效的基元类型: System.IntPtr。请考虑使用 CodeObjectCreateExpression。”。
            // 
            // APro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.appWindow1);
            this.Name = "APro";
            this.Size = new System.Drawing.Size(291, 314);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Wiz.AWiz appWindow1;
    }
}

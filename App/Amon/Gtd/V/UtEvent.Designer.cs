namespace Me.Amon.Gtd.V
{
    partial class UtEvent
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
            this.CkLoad = new System.Windows.Forms.CheckBox();
            this.CkExit = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CkLoad
            // 
            this.CkLoad.AutoSize = true;
            this.CkLoad.Location = new System.Drawing.Point(3, 3);
            this.CkLoad.Name = "CkLoad";
            this.CkLoad.Size = new System.Drawing.Size(60, 16);
            this.CkLoad.TabIndex = 0;
            this.CkLoad.Text = "启动后";
            this.CkLoad.UseVisualStyleBackColor = true;
            // 
            // CkExit
            // 
            this.CkExit.AutoSize = true;
            this.CkExit.Location = new System.Drawing.Point(3, 25);
            this.CkExit.Name = "CkExit";
            this.CkExit.Size = new System.Drawing.Size(60, 16);
            this.CkExit.TabIndex = 1;
            this.CkExit.Text = "退出前";
            this.CkExit.UseVisualStyleBackColor = true;
            // 
            // UtEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CkExit);
            this.Controls.Add(this.CkLoad);
            this.Name = "UtEvent";
            this.Size = new System.Drawing.Size(304, 160);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CkLoad;
        private System.Windows.Forms.CheckBox CkExit;
    }
}

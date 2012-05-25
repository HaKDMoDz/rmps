namespace Me.Amon.Sql.V.Input
{
    partial class Data
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
            this.TbParam = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TbParam
            // 
            this.TbParam.Location = new System.Drawing.Point(3, 3);
            this.TbParam.Name = "TbParam";
            this.TbParam.Size = new System.Drawing.Size(144, 21);
            this.TbParam.TabIndex = 0;
            // 
            // Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbParam);
            this.Name = "Data";
            this.Size = new System.Drawing.Size(150, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbParam;

    }
}

namespace Me.Amon.Pwd.V.Wiz.Viewer
{
    partial class AttList
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
            this.CbData = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CbData
            // 
            this.CbData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbData.FormattingEnabled = true;
            this.CbData.Location = new System.Drawing.Point(0, 0);
            this.CbData.Name = "CbData";
            this.CbData.Size = new System.Drawing.Size(121, 20);
            this.CbData.TabIndex = 0;
            // 
            // BeanList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CbData);
            this.Name = "BeanList";
            this.Size = new System.Drawing.Size(350, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CbData;
    }
}

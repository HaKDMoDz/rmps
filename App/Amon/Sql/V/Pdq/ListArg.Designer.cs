namespace Me.Amon.Sql.V.Pdq
{
    partial class List
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
            this.CbParam = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CbParam
            // 
            this.CbParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbParam.FormattingEnabled = true;
            this.CbParam.Location = new System.Drawing.Point(3, 3);
            this.CbParam.Name = "CbParam";
            this.CbParam.Size = new System.Drawing.Size(121, 20);
            this.CbParam.TabIndex = 0;
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CbParam);
            this.Name = "List";
            this.Size = new System.Drawing.Size(250, 27);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CbParam;
    }
}

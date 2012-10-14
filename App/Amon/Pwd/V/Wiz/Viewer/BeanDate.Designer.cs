namespace Me.Amon.Pwd.V.Wiz.Viewer
{
    partial class BeanDate
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
            this.DtData = new System.Windows.Forms.DateTimePicker();
            this.BtCopy = new System.Windows.Forms.Button();
            this.BtFill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DtData
            // 
            this.DtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DtData.Location = new System.Drawing.Point(0, 0);
            this.DtData.Name = "DtData";
            this.DtData.Size = new System.Drawing.Size(293, 21);
            this.DtData.TabIndex = 0;
            // 
            // BtCopy
            // 
            this.BtCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtCopy.FlatAppearance.BorderSize = 0;
            this.BtCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtCopy.Location = new System.Drawing.Point(299, 0);
            this.BtCopy.Name = "BtCopy";
            this.BtCopy.Size = new System.Drawing.Size(21, 21);
            this.BtCopy.TabIndex = 1;
            this.BtCopy.TabStop = false;
            this.BtCopy.UseVisualStyleBackColor = true;
            this.BtCopy.Click += new System.EventHandler(this.BtCopy_Click);
            // 
            // BtFill
            // 
            this.BtFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtFill.FlatAppearance.BorderSize = 0;
            this.BtFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtFill.Location = new System.Drawing.Point(326, 0);
            this.BtFill.Name = "BtFill";
            this.BtFill.Size = new System.Drawing.Size(21, 21);
            this.BtFill.TabIndex = 2;
            this.BtFill.TabStop = false;
            this.BtFill.UseVisualStyleBackColor = true;
            this.BtFill.Click += new System.EventHandler(this.BtFill_Click);
            // 
            // BeanDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtFill);
            this.Controls.Add(this.BtCopy);
            this.Controls.Add(this.DtData);
            this.Name = "BeanDate";
            this.Size = new System.Drawing.Size(350, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DtData;
        private System.Windows.Forms.Button BtCopy;
        private System.Windows.Forms.Button BtFill;
    }
}

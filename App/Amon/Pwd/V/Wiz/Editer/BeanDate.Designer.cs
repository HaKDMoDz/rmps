namespace Me.Amon.Pwd.V.Wiz.Editer
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
            this.BtNow = new System.Windows.Forms.Button();
            this.BtOpt = new System.Windows.Forms.Button();
            this.BtCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DtData
            // 
            this.DtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtData.Location = new System.Drawing.Point(0, 0);
            this.DtData.Name = "DtData";
            this.DtData.Size = new System.Drawing.Size(266, 21);
            this.DtData.TabIndex = 0;
            // 
            // BtNow
            // 
            this.BtNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNow.FlatAppearance.BorderSize = 0;
            this.BtNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtNow.Location = new System.Drawing.Point(272, 0);
            this.BtNow.Name = "BtNow";
            this.BtNow.Size = new System.Drawing.Size(21, 21);
            this.BtNow.TabIndex = 1;
            this.BtNow.TabStop = false;
            this.BtNow.UseVisualStyleBackColor = true;
            this.BtNow.Click += new System.EventHandler(this.BtNow_Click);
            // 
            // BtOpt
            // 
            this.BtOpt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOpt.FlatAppearance.BorderSize = 0;
            this.BtOpt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtOpt.Location = new System.Drawing.Point(299, 0);
            this.BtOpt.Name = "BtOpt";
            this.BtOpt.Size = new System.Drawing.Size(21, 21);
            this.BtOpt.TabIndex = 2;
            this.BtOpt.TabStop = false;
            this.BtOpt.UseVisualStyleBackColor = true;
            this.BtOpt.Click += new System.EventHandler(this.BtOpt_Click);
            // 
            // BtCopy
            // 
            this.BtCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtCopy.FlatAppearance.BorderSize = 0;
            this.BtCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtCopy.Location = new System.Drawing.Point(326, 0);
            this.BtCopy.Name = "BtCopy";
            this.BtCopy.Size = new System.Drawing.Size(21, 21);
            this.BtCopy.TabIndex = 3;
            this.BtCopy.TabStop = false;
            this.BtCopy.UseVisualStyleBackColor = true;
            this.BtCopy.Click += new System.EventHandler(this.BtCopy_Click);
            // 
            // BeanDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtCopy);
            this.Controls.Add(this.BtOpt);
            this.Controls.Add(this.BtNow);
            this.Controls.Add(this.DtData);
            this.Name = "BeanDate";
            this.Size = new System.Drawing.Size(350, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DtData;
        private System.Windows.Forms.Button BtNow;
        private System.Windows.Forms.Button BtOpt;
        private System.Windows.Forms.Button BtCopy;
    }
}

namespace Me.Amon.Pwd.V.Wiz.Viewer
{
    partial class AttFile
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
            this.TbData = new System.Windows.Forms.TextBox();
            this.BtView = new System.Windows.Forms.Button();
            this.BtCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TbData
            // 
            this.TbData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TbData.Location = new System.Drawing.Point(0, 0);
            this.TbData.Name = "TbData";
            this.TbData.Size = new System.Drawing.Size(293, 21);
            this.TbData.TabIndex = 0;
            // 
            // BtView
            // 
            this.BtView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtView.FlatAppearance.BorderSize = 0;
            this.BtView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtView.Location = new System.Drawing.Point(299, 0);
            this.BtView.Name = "BtView";
            this.BtView.Size = new System.Drawing.Size(21, 21);
            this.BtView.TabIndex = 1;
            this.BtView.TabStop = false;
            this.BtView.UseVisualStyleBackColor = true;
            this.BtView.Click += new System.EventHandler(this.BtView_Click);
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
            // BeanFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtCopy);
            this.Controls.Add(this.BtView);
            this.Controls.Add(this.TbData);
            this.Name = "BeanFile";
            this.Size = new System.Drawing.Size(350, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbData;
        private System.Windows.Forms.Button BtView;
        private System.Windows.Forms.Button BtCopy;
    }
}

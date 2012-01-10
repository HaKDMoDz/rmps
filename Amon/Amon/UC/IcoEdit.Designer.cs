namespace Me.Amon.UC
{
    partial class IcoEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IcoEdit));
            this.LvIcon = new System.Windows.Forms.ListView();
            this.BtChoose = new System.Windows.Forms.Button();
            this.BtAppend = new System.Windows.Forms.Button();
            this.BtCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LvIcon
            // 
            this.LvIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LvIcon.Location = new System.Drawing.Point(12, 12);
            this.LvIcon.Name = "LvIcon";
            this.LvIcon.Size = new System.Drawing.Size(370, 219);
            this.LvIcon.TabIndex = 0;
            this.LvIcon.UseCompatibleStateImageBehavior = false;
            this.LvIcon.View = System.Windows.Forms.View.SmallIcon;
            // 
            // BtChoose
            // 
            this.BtChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtChoose.Location = new System.Drawing.Point(145, 237);
            this.BtChoose.Name = "BtChoose";
            this.BtChoose.Size = new System.Drawing.Size(75, 23);
            this.BtChoose.TabIndex = 1;
            this.BtChoose.Text = "选择(&S)";
            this.BtChoose.UseVisualStyleBackColor = true;
            this.BtChoose.Click += new System.EventHandler(this.BtChoose_Click);
            // 
            // BtAppend
            // 
            this.BtAppend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtAppend.Location = new System.Drawing.Point(226, 237);
            this.BtAppend.Name = "BtAppend";
            this.BtAppend.Size = new System.Drawing.Size(75, 23);
            this.BtAppend.TabIndex = 2;
            this.BtAppend.Text = "追加(&A)";
            this.BtAppend.UseVisualStyleBackColor = true;
            this.BtAppend.Click += new System.EventHandler(this.BtAppend_Click);
            // 
            // BtCancel
            // 
            this.BtCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtCancel.Location = new System.Drawing.Point(307, 237);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(75, 23);
            this.BtCancel.TabIndex = 3;
            this.BtCancel.Text = "取消(&C)";
            this.BtCancel.UseVisualStyleBackColor = true;
            this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // IcoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 272);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.BtAppend);
            this.Controls.Add(this.BtChoose);
            this.Controls.Add(this.LvIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IcoEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IcoEdit";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LvIcon;
        private System.Windows.Forms.Button BtChoose;
        private System.Windows.Forms.Button BtAppend;
        private System.Windows.Forms.Button BtCancel;
    }
}
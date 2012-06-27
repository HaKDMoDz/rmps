namespace Me.Amon.Pwd._Cat
{
    partial class CatTree
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
            this.TvCatTree = new System.Windows.Forms.TreeView();
            this.BtSelect = new System.Windows.Forms.Button();
            this.BtCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TvCatTree
            // 
            this.TvCatTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TvCatTree.Location = new System.Drawing.Point(12, 12);
            this.TvCatTree.Name = "TvCatTree";
            this.TvCatTree.Size = new System.Drawing.Size(190, 209);
            this.TvCatTree.TabIndex = 0;
            // 
            // BtSelect
            // 
            this.BtSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtSelect.Location = new System.Drawing.Point(46, 237);
            this.BtSelect.Name = "BtSelect";
            this.BtSelect.Size = new System.Drawing.Size(75, 23);
            this.BtSelect.TabIndex = 1;
            this.BtSelect.Text = "选择(&S)";
            this.BtSelect.UseVisualStyleBackColor = true;
            this.BtSelect.Click += new System.EventHandler(this.BtSelect_Click);
            // 
            // BtCancel
            // 
            this.BtCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtCancel.Location = new System.Drawing.Point(127, 237);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(75, 23);
            this.BtCancel.TabIndex = 2;
            this.BtCancel.Text = "取消(&C)";
            this.BtCancel.UseVisualStyleBackColor = true;
            this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // CatTree
            // 
            this.AcceptButton = this.BtSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtCancel;
            this.ClientSize = new System.Drawing.Size(214, 272);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.BtSelect);
            this.Controls.Add(this.TvCatTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CatTree";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "类别";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TvCatTree;
        private System.Windows.Forms.Button BtSelect;
        private System.Windows.Forms.Button BtCancel;
    }
}
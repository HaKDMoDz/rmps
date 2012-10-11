namespace Me.Amon.Pwd._Key
{
    partial class DirEditer
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
            this.LbName = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LbTips = new System.Windows.Forms.Label();
            this.TbTips = new System.Windows.Forms.TextBox();
            this.BtUpdate = new System.Windows.Forms.Button();
            this.BtCancel = new System.Windows.Forms.Button();
            this.LbMemo = new System.Windows.Forms.Label();
            this.TbMemo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(3, 6);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(47, 12);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "名称(&N)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(56, 3);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(100, 21);
            this.TbName.TabIndex = 1;
            // 
            // LbTips
            // 
            this.LbTips.AutoSize = true;
            this.LbTips.Location = new System.Drawing.Point(3, 33);
            this.LbTips.Name = "LbTips";
            this.LbTips.Size = new System.Drawing.Size(47, 12);
            this.LbTips.TabIndex = 2;
            this.LbTips.Text = "提示(&T)";
            // 
            // TbTips
            // 
            this.TbTips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbTips.Location = new System.Drawing.Point(56, 30);
            this.TbTips.Name = "TbTips";
            this.TbTips.Size = new System.Drawing.Size(100, 21);
            this.TbTips.TabIndex = 3;
            // 
            // BtUpdate
            // 
            this.BtUpdate.Location = new System.Drawing.Point(85, 223);
            this.BtUpdate.Name = "BtUpdate";
            this.BtUpdate.Size = new System.Drawing.Size(75, 23);
            this.BtUpdate.TabIndex = 6;
            this.BtUpdate.Text = "确定(&O)";
            this.BtUpdate.UseVisualStyleBackColor = true;
            this.BtUpdate.Click += new System.EventHandler(this.BtUpdate_Click);
            // 
            // BtCancel
            // 
            this.BtCancel.Location = new System.Drawing.Point(166, 223);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(75, 23);
            this.BtCancel.TabIndex = 7;
            this.BtCancel.Text = "取消(&C)";
            this.BtCancel.UseVisualStyleBackColor = true;
            this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // LbMemo
            // 
            this.LbMemo.AutoSize = true;
            this.LbMemo.Location = new System.Drawing.Point(3, 60);
            this.LbMemo.Name = "LbMemo";
            this.LbMemo.Size = new System.Drawing.Size(47, 12);
            this.LbMemo.TabIndex = 4;
            this.LbMemo.Text = "说明(&D)";
            // 
            // TbMemo
            // 
            this.TbMemo.Location = new System.Drawing.Point(56, 57);
            this.TbMemo.Multiline = true;
            this.TbMemo.Name = "TbMemo";
            this.TbMemo.Size = new System.Drawing.Size(185, 62);
            this.TbMemo.TabIndex = 5;
            // 
            // DirEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbMemo);
            this.Controls.Add(this.LbMemo);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.BtUpdate);
            this.Controls.Add(this.TbTips);
            this.Controls.Add(this.LbTips);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.Name = "DirEdit";
            this.Size = new System.Drawing.Size(244, 249);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbTips;
        private System.Windows.Forms.TextBox TbTips;
        private System.Windows.Forms.Button BtUpdate;
        private System.Windows.Forms.Button BtCancel;
        private System.Windows.Forms.Label LbMemo;
        private System.Windows.Forms.TextBox TbMemo;
    }
}

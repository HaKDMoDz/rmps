namespace Me.Amon.Uw
{
    partial class UdcEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UdcEditor));
            this.LsUdc = new System.Windows.Forms.ListBox();
            this.LbName = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LbTips = new System.Windows.Forms.Label();
            this.TbTips = new System.Windows.Forms.TextBox();
            this.LbChar = new System.Windows.Forms.Label();
            this.TbChar = new System.Windows.Forms.TextBox();
            this.BtAppend = new System.Windows.Forms.Button();
            this.BtUpdate = new System.Windows.Forms.Button();
            this.BtCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LsUdc
            // 
            this.LsUdc.FormattingEnabled = true;
            this.LsUdc.ItemHeight = 12;
            this.LsUdc.Location = new System.Drawing.Point(12, 12);
            this.LsUdc.Name = "LsUdc";
            this.LsUdc.Size = new System.Drawing.Size(120, 208);
            this.LsUdc.TabIndex = 0;
            this.LsUdc.SelectedIndexChanged += new System.EventHandler(this.LsUcs_SelectedIndexChanged);
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(138, 15);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(47, 12);
            this.LbName.TabIndex = 1;
            this.LbName.Text = "名称(&N)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(191, 12);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(100, 21);
            this.TbName.TabIndex = 2;
            // 
            // LbTips
            // 
            this.LbTips.AutoSize = true;
            this.LbTips.Location = new System.Drawing.Point(138, 42);
            this.LbTips.Name = "LbTips";
            this.LbTips.Size = new System.Drawing.Size(47, 12);
            this.LbTips.TabIndex = 3;
            this.LbTips.Text = "提示(&T)";
            // 
            // TbTips
            // 
            this.TbTips.Location = new System.Drawing.Point(191, 39);
            this.TbTips.Name = "TbTips";
            this.TbTips.Size = new System.Drawing.Size(100, 21);
            this.TbTips.TabIndex = 4;
            // 
            // LbChar
            // 
            this.LbChar.AutoSize = true;
            this.LbChar.Location = new System.Drawing.Point(138, 69);
            this.LbChar.Name = "LbChar";
            this.LbChar.Size = new System.Drawing.Size(47, 12);
            this.LbChar.TabIndex = 5;
            this.LbChar.Text = "字符(&C)";
            // 
            // TbChar
            // 
            this.TbChar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbChar.Location = new System.Drawing.Point(138, 84);
            this.TbChar.Multiline = true;
            this.TbChar.Name = "TbChar";
            this.TbChar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbChar.Size = new System.Drawing.Size(244, 136);
            this.TbChar.TabIndex = 6;
            // 
            // BtAppend
            // 
            this.BtAppend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtAppend.Location = new System.Drawing.Point(145, 226);
            this.BtAppend.Name = "BtAppend";
            this.BtAppend.Size = new System.Drawing.Size(75, 23);
            this.BtAppend.TabIndex = 7;
            this.BtAppend.Text = "添加(&A)";
            this.BtAppend.UseVisualStyleBackColor = true;
            this.BtAppend.Click += new System.EventHandler(this.BtAppend_Click);
            // 
            // BtUpdate
            // 
            this.BtUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtUpdate.Location = new System.Drawing.Point(226, 226);
            this.BtUpdate.Name = "BtUpdate";
            this.BtUpdate.Size = new System.Drawing.Size(75, 23);
            this.BtUpdate.TabIndex = 8;
            this.BtUpdate.Text = "保存(&U)";
            this.BtUpdate.UseVisualStyleBackColor = true;
            this.BtUpdate.Click += new System.EventHandler(this.BtUpdate_Click);
            // 
            // BtCancel
            // 
            this.BtCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtCancel.Location = new System.Drawing.Point(307, 226);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(75, 23);
            this.BtCancel.TabIndex = 9;
            this.BtCancel.Text = "取消(&C)";
            this.BtCancel.UseVisualStyleBackColor = true;
            this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // UdcEditor
            // 
            this.AcceptButton = this.BtUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtCancel;
            this.ClientSize = new System.Drawing.Size(394, 261);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.BtUpdate);
            this.Controls.Add(this.BtAppend);
            this.Controls.Add(this.TbChar);
            this.Controls.Add(this.LbChar);
            this.Controls.Add(this.TbTips);
            this.Controls.Add(this.LbTips);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.Controls.Add(this.LsUdc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UdcEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "字符管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LsUdc;
        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbTips;
        private System.Windows.Forms.TextBox TbTips;
        private System.Windows.Forms.Label LbChar;
        private System.Windows.Forms.TextBox TbChar;
        private System.Windows.Forms.Button BtAppend;
        private System.Windows.Forms.Button BtUpdate;
        private System.Windows.Forms.Button BtCancel;
    }
}
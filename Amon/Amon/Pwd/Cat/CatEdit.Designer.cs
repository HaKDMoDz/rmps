namespace Me.Amon.Pwd.Cat
{
    partial class CatEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatEdit));
            this.LbName = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LbTips = new System.Windows.Forms.Label();
            this.TbTips = new System.Windows.Forms.TextBox();
            this.LbValue = new System.Windows.Forms.Label();
            this.TbValue = new System.Windows.Forms.TextBox();
            this.LbMemo = new System.Windows.Forms.Label();
            this.TbMemo = new System.Windows.Forms.TextBox();
            this.BtOk = new System.Windows.Forms.Button();
            this.BtNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(12, 15);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(47, 12);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "名称(&N)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(65, 12);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(140, 21);
            this.TbName.TabIndex = 1;
            // 
            // LbTips
            // 
            this.LbTips.AutoSize = true;
            this.LbTips.Location = new System.Drawing.Point(12, 42);
            this.LbTips.Name = "LbTips";
            this.LbTips.Size = new System.Drawing.Size(47, 12);
            this.LbTips.TabIndex = 2;
            this.LbTips.Text = "提示(&T)";
            // 
            // TbTips
            // 
            this.TbTips.Location = new System.Drawing.Point(65, 39);
            this.TbTips.Name = "TbTips";
            this.TbTips.Size = new System.Drawing.Size(140, 21);
            this.TbTips.TabIndex = 3;
            // 
            // LbValue
            // 
            this.LbValue.AutoSize = true;
            this.LbValue.Location = new System.Drawing.Point(12, 69);
            this.LbValue.Name = "LbValue";
            this.LbValue.Size = new System.Drawing.Size(47, 12);
            this.LbValue.TabIndex = 4;
            this.LbValue.Text = "键值(&V)";
            // 
            // TbValue
            // 
            this.TbValue.Location = new System.Drawing.Point(65, 66);
            this.TbValue.Name = "TbValue";
            this.TbValue.Size = new System.Drawing.Size(140, 21);
            this.TbValue.TabIndex = 5;
            // 
            // LbMemo
            // 
            this.LbMemo.AutoSize = true;
            this.LbMemo.Location = new System.Drawing.Point(12, 96);
            this.LbMemo.Name = "LbMemo";
            this.LbMemo.Size = new System.Drawing.Size(47, 12);
            this.LbMemo.TabIndex = 6;
            this.LbMemo.Text = "说明(&D)";
            // 
            // TbMemo
            // 
            this.TbMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbMemo.Location = new System.Drawing.Point(65, 93);
            this.TbMemo.Multiline = true;
            this.TbMemo.Name = "TbMemo";
            this.TbMemo.Size = new System.Drawing.Size(197, 58);
            this.TbMemo.TabIndex = 7;
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(106, 157);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 8;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // BtNo
            // 
            this.BtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNo.Location = new System.Drawing.Point(187, 157);
            this.BtNo.Name = "BtNo";
            this.BtNo.Size = new System.Drawing.Size(75, 23);
            this.BtNo.TabIndex = 9;
            this.BtNo.Text = "取消(&C)";
            this.BtNo.UseVisualStyleBackColor = true;
            this.BtNo.Click += new System.EventHandler(this.BtNo_Click);
            // 
            // CatEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 192);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.TbMemo);
            this.Controls.Add(this.LbMemo);
            this.Controls.Add(this.TbValue);
            this.Controls.Add(this.LbValue);
            this.Controls.Add(this.TbTips);
            this.Controls.Add(this.LbTips);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CatEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "类别管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbTips;
        private System.Windows.Forms.TextBox TbTips;
        private System.Windows.Forms.Label LbValue;
        private System.Windows.Forms.TextBox TbValue;
        private System.Windows.Forms.Label LbMemo;
        private System.Windows.Forms.TextBox TbMemo;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtNo;
    }
}
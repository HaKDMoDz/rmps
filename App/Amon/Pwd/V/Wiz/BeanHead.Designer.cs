namespace Me.Amon.Pwd.V.Wiz
{
    partial class BeanHead
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
            this.LbMeta = new System.Windows.Forms.Label();
            this.TbMeta = new System.Windows.Forms.TextBox();
            this.LbIcon = new System.Windows.Forms.Label();
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.LbHint = new System.Windows.Forms.Label();
            this.BtHint = new System.Windows.Forms.PictureBox();
            this.TbHint = new System.Windows.Forms.Label();
            this.LbMemo = new System.Windows.Forms.Label();
            this.TbMemo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtHint)).BeginInit();
            this.SuspendLayout();
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(10, 6);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(47, 12);
            this.LbName.TabIndex = 0;
            this.LbName.Text = "标题(&T)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(63, 3);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(120, 21);
            this.TbName.TabIndex = 1;
            // 
            // LbMeta
            // 
            this.LbMeta.AutoSize = true;
            this.LbMeta.Location = new System.Drawing.Point(10, 33);
            this.LbMeta.Name = "LbMeta";
            this.LbMeta.Size = new System.Drawing.Size(47, 12);
            this.LbMeta.TabIndex = 2;
            this.LbMeta.Text = "搜索(&M)";
            // 
            // TbMeta
            // 
            this.TbMeta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbMeta.Location = new System.Drawing.Point(63, 30);
            this.TbMeta.Multiline = true;
            this.TbMeta.Name = "TbMeta";
            this.TbMeta.Size = new System.Drawing.Size(284, 60);
            this.TbMeta.TabIndex = 3;
            // 
            // LbIcon
            // 
            this.LbIcon.AutoSize = true;
            this.LbIcon.Location = new System.Drawing.Point(10, 98);
            this.LbIcon.Name = "LbIcon";
            this.LbIcon.Size = new System.Drawing.Size(47, 12);
            this.LbIcon.TabIndex = 4;
            this.LbIcon.Text = "徽标(&I)";
            // 
            // PbLogo
            // 
            this.PbLogo.BackColor = System.Drawing.SystemColors.Window;
            this.PbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbLogo.Location = new System.Drawing.Point(63, 96);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(18, 18);
            this.PbLogo.TabIndex = 5;
            this.PbLogo.TabStop = false;
            this.PbLogo.Click += new System.EventHandler(this.PbLogo_Click);
            // 
            // LbHint
            // 
            this.LbHint.AutoSize = true;
            this.LbHint.Location = new System.Drawing.Point(10, 123);
            this.LbHint.Name = "LbHint";
            this.LbHint.Size = new System.Drawing.Size(47, 12);
            this.LbHint.TabIndex = 6;
            this.LbHint.Text = "提醒(&H)";
            // 
            // BtHint
            // 
            this.BtHint.BackColor = System.Drawing.SystemColors.Window;
            this.BtHint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BtHint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtHint.Location = new System.Drawing.Point(63, 120);
            this.BtHint.Name = "BtHint";
            this.BtHint.Size = new System.Drawing.Size(18, 18);
            this.BtHint.TabIndex = 7;
            this.BtHint.TabStop = false;
            this.BtHint.Click += new System.EventHandler(this.BtHint_Click);
            // 
            // TbHint
            // 
            this.TbHint.AutoSize = true;
            this.TbHint.Location = new System.Drawing.Point(87, 123);
            this.TbHint.Name = "TbHint";
            this.TbHint.Size = new System.Drawing.Size(0, 12);
            this.TbHint.TabIndex = 8;
            // 
            // LbMemo
            // 
            this.LbMemo.AutoSize = true;
            this.LbMemo.Location = new System.Drawing.Point(10, 147);
            this.LbMemo.Name = "LbMemo";
            this.LbMemo.Size = new System.Drawing.Size(47, 12);
            this.LbMemo.TabIndex = 9;
            this.LbMemo.Text = "备注(&R)";
            // 
            // TbMemo
            // 
            this.TbMemo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbMemo.Location = new System.Drawing.Point(63, 144);
            this.TbMemo.Multiline = true;
            this.TbMemo.Name = "TbMemo";
            this.TbMemo.Size = new System.Drawing.Size(284, 60);
            this.TbMemo.TabIndex = 10;
            // 
            // BeanHead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbMemo);
            this.Controls.Add(this.LbMemo);
            this.Controls.Add(this.TbHint);
            this.Controls.Add(this.BtHint);
            this.Controls.Add(this.LbHint);
            this.Controls.Add(this.PbLogo);
            this.Controls.Add(this.LbIcon);
            this.Controls.Add(this.TbMeta);
            this.Controls.Add(this.LbMeta);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.Name = "BeanHead";
            this.Size = new System.Drawing.Size(350, 250);
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtHint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbMeta;
        private System.Windows.Forms.TextBox TbMeta;
        private System.Windows.Forms.Label LbIcon;
        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.Label LbHint;
        private System.Windows.Forms.PictureBox BtHint;
        private System.Windows.Forms.Label TbHint;
        private System.Windows.Forms.Label LbMemo;
        private System.Windows.Forms.TextBox TbMemo;

    }
}

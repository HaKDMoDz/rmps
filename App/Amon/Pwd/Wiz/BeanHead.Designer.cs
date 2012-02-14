namespace Me.Amon.Pwd.Wiz
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
            this.LbLib = new System.Windows.Forms.Label();
            this.CbLib = new System.Windows.Forms.ComboBox();
            this.LbName = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LbMeta = new System.Windows.Forms.Label();
            this.TbMeta = new System.Windows.Forms.TextBox();
            this.LbIcon = new System.Windows.Forms.Label();
            this.PbIcon = new System.Windows.Forms.PictureBox();
            this.LbHint = new System.Windows.Forms.Label();
            this.TbHint = new System.Windows.Forms.TextBox();
            this.LbMemo = new System.Windows.Forms.Label();
            this.TbMemo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // LbLib
            // 
            this.LbLib.AutoSize = true;
            this.LbLib.Location = new System.Drawing.Point(10, 6);
            this.LbLib.Name = "LbLib";
            this.LbLib.Size = new System.Drawing.Size(47, 12);
            this.LbLib.TabIndex = 0;
            this.LbLib.Text = "模板(&L)";
            // 
            // CbLib
            // 
            this.CbLib.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbLib.FormattingEnabled = true;
            this.CbLib.Location = new System.Drawing.Point(63, 3);
            this.CbLib.Name = "CbLib";
            this.CbLib.Size = new System.Drawing.Size(121, 20);
            this.CbLib.TabIndex = 1;
            this.CbLib.SelectedIndexChanged += new System.EventHandler(this.CbLib_SelectedIndexChanged);
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(10, 32);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(47, 12);
            this.LbName.TabIndex = 2;
            this.LbName.Text = "标题(&T)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(63, 29);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(100, 21);
            this.TbName.TabIndex = 3;
            // 
            // LbMeta
            // 
            this.LbMeta.AutoSize = true;
            this.LbMeta.Location = new System.Drawing.Point(10, 59);
            this.LbMeta.Name = "LbMeta";
            this.LbMeta.Size = new System.Drawing.Size(47, 12);
            this.LbMeta.TabIndex = 4;
            this.LbMeta.Text = "搜索(&M)";
            // 
            // TbMeta
            // 
            this.TbMeta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbMeta.Location = new System.Drawing.Point(63, 56);
            this.TbMeta.Multiline = true;
            this.TbMeta.Name = "TbMeta";
            this.TbMeta.Size = new System.Drawing.Size(284, 60);
            this.TbMeta.TabIndex = 5;
            // 
            // LbIcon
            // 
            this.LbIcon.AutoSize = true;
            this.LbIcon.Location = new System.Drawing.Point(10, 124);
            this.LbIcon.Name = "LbIcon";
            this.LbIcon.Size = new System.Drawing.Size(47, 12);
            this.LbIcon.TabIndex = 6;
            this.LbIcon.Text = "徽标(&I)";
            // 
            // PbIcon
            // 
            this.PbIcon.BackColor = System.Drawing.SystemColors.Window;
            this.PbIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbIcon.Location = new System.Drawing.Point(63, 122);
            this.PbIcon.Name = "PbIcon";
            this.PbIcon.Size = new System.Drawing.Size(16, 16);
            this.PbIcon.TabIndex = 7;
            this.PbIcon.TabStop = false;
            this.PbIcon.Click += new System.EventHandler(this.PbIcon_Click);
            // 
            // LbHint
            // 
            this.LbHint.AutoSize = true;
            this.LbHint.Location = new System.Drawing.Point(10, 147);
            this.LbHint.Name = "LbHint";
            this.LbHint.Size = new System.Drawing.Size(47, 12);
            this.LbHint.TabIndex = 8;
            this.LbHint.Text = "提醒(&H)";
            // 
            // TbHint
            // 
            this.TbHint.Location = new System.Drawing.Point(63, 144);
            this.TbHint.Name = "TbHint";
            this.TbHint.Size = new System.Drawing.Size(100, 21);
            this.TbHint.TabIndex = 9;
            // 
            // LbMemo
            // 
            this.LbMemo.AutoSize = true;
            this.LbMemo.Location = new System.Drawing.Point(10, 174);
            this.LbMemo.Name = "LbMemo";
            this.LbMemo.Size = new System.Drawing.Size(47, 12);
            this.LbMemo.TabIndex = 10;
            this.LbMemo.Text = "备注(&R)";
            // 
            // TbMemo
            // 
            this.TbMemo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbMemo.Location = new System.Drawing.Point(63, 171);
            this.TbMemo.Multiline = true;
            this.TbMemo.Name = "TbMemo";
            this.TbMemo.Size = new System.Drawing.Size(284, 60);
            this.TbMemo.TabIndex = 11;
            // 
            // BeanHead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbMemo);
            this.Controls.Add(this.LbMemo);
            this.Controls.Add(this.TbHint);
            this.Controls.Add(this.LbHint);
            this.Controls.Add(this.PbIcon);
            this.Controls.Add(this.LbIcon);
            this.Controls.Add(this.TbMeta);
            this.Controls.Add(this.LbMeta);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.Controls.Add(this.CbLib);
            this.Controls.Add(this.LbLib);
            this.Name = "BeanHead";
            this.Size = new System.Drawing.Size(350, 250);
            ((System.ComponentModel.ISupportInitialize)(this.PbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbLib;
        private System.Windows.Forms.ComboBox CbLib;
        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbMeta;
        private System.Windows.Forms.TextBox TbMeta;
        private System.Windows.Forms.Label LbIcon;
        private System.Windows.Forms.PictureBox PbIcon;
        private System.Windows.Forms.Label LbHint;
        private System.Windows.Forms.TextBox TbHint;
        private System.Windows.Forms.Label LbMemo;
        private System.Windows.Forms.TextBox TbMemo;

    }
}

namespace Me.Amon.Pwd.Lib
{
    partial class LibDetail
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
            this.LbType = new System.Windows.Forms.Label();
            this.CbType = new System.Windows.Forms.ComboBox();
            this.LbName = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LbData = new System.Windows.Forms.Label();
            this.TbData = new System.Windows.Forms.TextBox();
            this.LbMemo = new System.Windows.Forms.Label();
            this.TbMemo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LbType
            // 
            this.LbType.AutoSize = true;
            this.LbType.Location = new System.Drawing.Point(3, 6);
            this.LbType.Name = "LbType";
            this.LbType.Size = new System.Drawing.Size(71, 12);
            this.LbType.TabIndex = 0;
            this.LbType.Text = "类　　型(&T)";
            // 
            // CbType
            // 
            this.CbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbType.FormattingEnabled = true;
            this.CbType.Location = new System.Drawing.Point(80, 3);
            this.CbType.Name = "CbType";
            this.CbType.Size = new System.Drawing.Size(100, 20);
            this.CbType.TabIndex = 1;
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(3, 32);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(71, 12);
            this.LbName.TabIndex = 2;
            this.LbName.Text = "属性名称(&N)";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(80, 29);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(100, 21);
            this.TbName.TabIndex = 3;
            // 
            // LbData
            // 
            this.LbData.AutoSize = true;
            this.LbData.Location = new System.Drawing.Point(3, 59);
            this.LbData.Name = "LbData";
            this.LbData.Size = new System.Drawing.Size(71, 12);
            this.LbData.TabIndex = 4;
            this.LbData.Text = "默认数据(&D)";
            // 
            // TbData
            // 
            this.TbData.Location = new System.Drawing.Point(80, 56);
            this.TbData.Name = "TbData";
            this.TbData.Size = new System.Drawing.Size(100, 21);
            this.TbData.TabIndex = 5;
            // 
            // LbMemo
            // 
            this.LbMemo.AutoSize = true;
            this.LbMemo.Location = new System.Drawing.Point(3, 91);
            this.LbMemo.Name = "LbMemo";
            this.LbMemo.Size = new System.Drawing.Size(71, 12);
            this.LbMemo.TabIndex = 6;
            this.LbMemo.Text = "说　　明(&M)";
            // 
            // TbMemo
            // 
            this.TbMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbMemo.Location = new System.Drawing.Point(80, 83);
            this.TbMemo.Multiline = true;
            this.TbMemo.Name = "TbMemo";
            this.TbMemo.Size = new System.Drawing.Size(148, 60);
            this.TbMemo.TabIndex = 7;
            // 
            // LibDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbMemo);
            this.Controls.Add(this.LbMemo);
            this.Controls.Add(this.TbData);
            this.Controls.Add(this.LbData);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LbName);
            this.Controls.Add(this.CbType);
            this.Controls.Add(this.LbType);
            this.Name = "LibDetail";
            this.Size = new System.Drawing.Size(231, 183);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbType;
        private System.Windows.Forms.ComboBox CbType;
        private System.Windows.Forms.Label LbName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LbData;
        private System.Windows.Forms.TextBox TbData;
        private System.Windows.Forms.Label LbMemo;
        private System.Windows.Forms.TextBox TbMemo;
    }
}

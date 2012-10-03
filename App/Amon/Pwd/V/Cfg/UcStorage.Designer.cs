namespace Me.Amon.Pwd.V.Cfg
{
    partial class UcStorage
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
            this.PbPass = new System.Windows.Forms.PictureBox();
            this.TbPass = new System.Windows.Forms.TextBox();
            this.LtPass = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LtName = new System.Windows.Forms.Label();
            this.CbType = new System.Windows.Forms.ComboBox();
            this.LtType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbPass)).BeginInit();
            this.SuspendLayout();
            // 
            // PbPass
            // 
            this.PbPass.Location = new System.Drawing.Point(193, 59);
            this.PbPass.Name = "PbPass";
            this.PbPass.Size = new System.Drawing.Size(16, 16);
            this.PbPass.TabIndex = 13;
            this.PbPass.TabStop = false;
            this.PbPass.Click += new System.EventHandler(this.PbPass_Click);
            // 
            // TbPass
            // 
            this.TbPass.Location = new System.Drawing.Point(66, 56);
            this.TbPass.Name = "TbPass";
            this.TbPass.Size = new System.Drawing.Size(121, 21);
            this.TbPass.TabIndex = 12;
            // 
            // LtPass
            // 
            this.LtPass.AutoSize = true;
            this.LtPass.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LtPass.Location = new System.Drawing.Point(3, 59);
            this.LtPass.Name = "LtPass";
            this.LtPass.Size = new System.Drawing.Size(57, 12);
            this.LtPass.TabIndex = 11;
            this.LtPass.Text = "登录口令";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(66, 29);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(121, 21);
            this.TbName.TabIndex = 10;
            // 
            // LtName
            // 
            this.LtName.AutoSize = true;
            this.LtName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LtName.Location = new System.Drawing.Point(3, 32);
            this.LtName.Name = "LtName";
            this.LtName.Size = new System.Drawing.Size(57, 12);
            this.LtName.TabIndex = 9;
            this.LtName.Text = "登录用户";
            // 
            // CbType
            // 
            this.CbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbType.FormattingEnabled = true;
            this.CbType.Location = new System.Drawing.Point(66, 3);
            this.CbType.Name = "CbType";
            this.CbType.Size = new System.Drawing.Size(121, 20);
            this.CbType.TabIndex = 8;
            this.CbType.SelectedIndexChanged += new System.EventHandler(this.CbType_SelectedIndexChanged);
            // 
            // LtType
            // 
            this.LtType.AutoSize = true;
            this.LtType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LtType.Location = new System.Drawing.Point(3, 6);
            this.LtType.Name = "LtType";
            this.LtType.Size = new System.Drawing.Size(57, 12);
            this.LtType.TabIndex = 7;
            this.LtType.Text = "存储类型";
            // 
            // UcStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbPass);
            this.Controls.Add(this.TbPass);
            this.Controls.Add(this.LtPass);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LtName);
            this.Controls.Add(this.CbType);
            this.Controls.Add(this.LtType);
            this.Name = "UcStorage";
            this.Size = new System.Drawing.Size(322, 163);
            ((System.ComponentModel.ISupportInitialize)(this.PbPass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbPass;
        private System.Windows.Forms.TextBox TbPass;
        private System.Windows.Forms.Label LtPass;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LtName;
        private System.Windows.Forms.ComboBox CbType;
        private System.Windows.Forms.Label LtType;
    }
}

namespace Me.Amon.Pwd.V.Cfg
{
    partial class UcGeneral
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
            this.LdBakCount = new System.Windows.Forms.Label();
            this.SpBakCount = new System.Windows.Forms.NumericUpDown();
            this.LtBakCount = new System.Windows.Forms.Label();
            this.PbBakPath = new System.Windows.Forms.PictureBox();
            this.TbBakPath = new System.Windows.Forms.TextBox();
            this.LtBakPath = new System.Windows.Forms.Label();
            this.PbDatPath = new System.Windows.Forms.PictureBox();
            this.TbDatPath = new System.Windows.Forms.TextBox();
            this.LtDatPath = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SpBakCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBakPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbDatPath)).BeginInit();
            this.SuspendLayout();
            // 
            // LdBakCount
            // 
            this.LdBakCount.AutoSize = true;
            this.LdBakCount.Location = new System.Drawing.Point(227, 61);
            this.LdBakCount.Name = "LdBakCount";
            this.LdBakCount.Size = new System.Drawing.Size(17, 12);
            this.LdBakCount.TabIndex = 8;
            this.LdBakCount.Text = "个";
            // 
            // SpBakCount
            // 
            this.SpBakCount.Location = new System.Drawing.Point(171, 57);
            this.SpBakCount.Name = "SpBakCount";
            this.SpBakCount.Size = new System.Drawing.Size(50, 21);
            this.SpBakCount.TabIndex = 7;
            // 
            // LtBakCount
            // 
            this.LtBakCount.AutoSize = true;
            this.LtBakCount.Location = new System.Drawing.Point(64, 61);
            this.LtBakCount.Name = "LtBakCount";
            this.LtBakCount.Size = new System.Drawing.Size(101, 12);
            this.LtBakCount.TabIndex = 6;
            this.LtBakCount.Text = "最大备份文件数量";
            // 
            // PbBakPath
            // 
            this.PbBakPath.Location = new System.Drawing.Point(297, 33);
            this.PbBakPath.Name = "PbBakPath";
            this.PbBakPath.Size = new System.Drawing.Size(16, 16);
            this.PbBakPath.TabIndex = 5;
            this.PbBakPath.TabStop = false;
            // 
            // TbBakPath
            // 
            this.TbBakPath.Location = new System.Drawing.Point(66, 30);
            this.TbBakPath.Name = "TbBakPath";
            this.TbBakPath.Size = new System.Drawing.Size(225, 21);
            this.TbBakPath.TabIndex = 4;
            // 
            // LtBakPath
            // 
            this.LtBakPath.AutoSize = true;
            this.LtBakPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LtBakPath.Location = new System.Drawing.Point(3, 33);
            this.LtBakPath.Name = "LtBakPath";
            this.LtBakPath.Size = new System.Drawing.Size(57, 12);
            this.LtBakPath.TabIndex = 3;
            this.LtBakPath.Text = "备份路径";
            // 
            // PbDatPath
            // 
            this.PbDatPath.Location = new System.Drawing.Point(297, 6);
            this.PbDatPath.Name = "PbDatPath";
            this.PbDatPath.Size = new System.Drawing.Size(16, 16);
            this.PbDatPath.TabIndex = 2;
            this.PbDatPath.TabStop = false;
            // 
            // TbDatPath
            // 
            this.TbDatPath.Location = new System.Drawing.Point(66, 3);
            this.TbDatPath.Name = "TbDatPath";
            this.TbDatPath.ReadOnly = true;
            this.TbDatPath.Size = new System.Drawing.Size(225, 21);
            this.TbDatPath.TabIndex = 1;
            // 
            // LtDatPath
            // 
            this.LtDatPath.AutoSize = true;
            this.LtDatPath.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LtDatPath.Location = new System.Drawing.Point(3, 6);
            this.LtDatPath.Name = "LtDatPath";
            this.LtDatPath.Size = new System.Drawing.Size(57, 12);
            this.LtDatPath.TabIndex = 0;
            this.LtDatPath.Text = "数据路径";
            // 
            // UcGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LdBakCount);
            this.Controls.Add(this.SpBakCount);
            this.Controls.Add(this.LtBakCount);
            this.Controls.Add(this.PbBakPath);
            this.Controls.Add(this.TbBakPath);
            this.Controls.Add(this.LtBakPath);
            this.Controls.Add(this.PbDatPath);
            this.Controls.Add(this.TbDatPath);
            this.Controls.Add(this.LtDatPath);
            this.Name = "UcGeneral";
            this.Size = new System.Drawing.Size(322, 163);
            ((System.ComponentModel.ISupportInitialize)(this.SpBakCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBakPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbDatPath)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LdBakCount;
        private System.Windows.Forms.NumericUpDown SpBakCount;
        private System.Windows.Forms.Label LtBakCount;
        private System.Windows.Forms.PictureBox PbBakPath;
        private System.Windows.Forms.TextBox TbBakPath;
        private System.Windows.Forms.Label LtBakPath;
        private System.Windows.Forms.PictureBox PbDatPath;
        private System.Windows.Forms.TextBox TbDatPath;
        private System.Windows.Forms.Label LtDatPath;
    }
}

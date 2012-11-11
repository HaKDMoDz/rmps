namespace Me.Amon.Pcs.V.Mgr
{
    partial class Config
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
            this.LlNote = new System.Windows.Forms.Label();
            this.LlLocal = new System.Windows.Forms.Label();
            this.TbLocal = new System.Windows.Forms.TextBox();
            this.BnLocal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LlNote
            // 
            this.LlNote.AutoSize = true;
            this.LlNote.Location = new System.Drawing.Point(3, 10);
            this.LlNote.Name = "LlNote";
            this.LlNote.Size = new System.Drawing.Size(125, 12);
            this.LlNote.TabIndex = 0;
            this.LlNote.Text = "请选择本地存储路径：";
            // 
            // LlLocal
            // 
            this.LlLocal.AutoSize = true;
            this.LlLocal.Location = new System.Drawing.Point(15, 36);
            this.LlLocal.Name = "LlLocal";
            this.LlLocal.Size = new System.Drawing.Size(95, 12);
            this.LlLocal.TabIndex = 1;
            this.LlLocal.Text = "本地存储路径(&P)";
            // 
            // TbLocal
            // 
            this.TbLocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TbLocal.Location = new System.Drawing.Point(116, 33);
            this.TbLocal.Name = "TbLocal";
            this.TbLocal.Size = new System.Drawing.Size(175, 21);
            this.TbLocal.TabIndex = 2;
            // 
            // BnLocal
            // 
            this.BnLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BnLocal.Location = new System.Drawing.Point(297, 31);
            this.BnLocal.Name = "BnLocal";
            this.BnLocal.Size = new System.Drawing.Size(75, 23);
            this.BnLocal.TabIndex = 3;
            this.BnLocal.Text = "选择(&S)";
            this.BnLocal.UseVisualStyleBackColor = true;
            this.BnLocal.Click += new System.EventHandler(this.BnLocal_Click);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BnLocal);
            this.Controls.Add(this.TbLocal);
            this.Controls.Add(this.LlLocal);
            this.Controls.Add(this.LlNote);
            this.Name = "Config";
            this.Size = new System.Drawing.Size(375, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LlNote;
        private System.Windows.Forms.Label LlLocal;
        private System.Windows.Forms.TextBox TbLocal;
        private System.Windows.Forms.Button BnLocal;
    }
}

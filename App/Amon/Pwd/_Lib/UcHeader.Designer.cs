namespace Me.Amon.Pwd._Lib
{
    partial class UcHeader
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
            this.LbText = new System.Windows.Forms.Label();
            this.TbText = new System.Windows.Forms.TextBox();
            this.LbTarget = new System.Windows.Forms.Label();
            this.TbTarget = new System.Windows.Forms.TextBox();
            this.TbMemo = new System.Windows.Forms.TextBox();
            this.LbMemo = new System.Windows.Forms.Label();
            this.TbScript = new System.Windows.Forms.TextBox();
            this.LbScript = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LbText
            // 
            this.LbText.AutoSize = true;
            this.LbText.Location = new System.Drawing.Point(3, 6);
            this.LbText.Name = "LbText";
            this.LbText.Size = new System.Drawing.Size(71, 12);
            this.LbText.TabIndex = 0;
            this.LbText.Text = "模板名称(&N)";
            // 
            // TbText
            // 
            this.TbText.Location = new System.Drawing.Point(80, 3);
            this.TbText.Name = "TbText";
            this.TbText.Size = new System.Drawing.Size(100, 21);
            this.TbText.TabIndex = 1;
            // 
            // LbTarget
            // 
            this.LbTarget.AutoSize = true;
            this.LbTarget.Location = new System.Drawing.Point(3, 33);
            this.LbTarget.Name = "LbTarget";
            this.LbTarget.Size = new System.Drawing.Size(71, 12);
            this.LbTarget.TabIndex = 2;
            this.LbTarget.Text = "窗体对象(&O)";
            // 
            // TbTarget
            // 
            this.TbTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbTarget.Location = new System.Drawing.Point(80, 30);
            this.TbTarget.Name = "TbTarget";
            this.TbTarget.Size = new System.Drawing.Size(100, 21);
            this.TbTarget.TabIndex = 3;
            // 
            // TbMemo
            // 
            this.TbMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbMemo.Location = new System.Drawing.Point(80, 84);
            this.TbMemo.Multiline = true;
            this.TbMemo.Name = "TbMemo";
            this.TbMemo.Size = new System.Drawing.Size(148, 60);
            this.TbMemo.TabIndex = 7;
            // 
            // LbMemo
            // 
            this.LbMemo.AutoSize = true;
            this.LbMemo.Location = new System.Drawing.Point(3, 92);
            this.LbMemo.Name = "LbMemo";
            this.LbMemo.Size = new System.Drawing.Size(71, 12);
            this.LbMemo.TabIndex = 6;
            this.LbMemo.Text = "说　　明(&M)";
            // 
            // TbScript
            // 
            this.TbScript.Location = new System.Drawing.Point(80, 57);
            this.TbScript.Name = "TbScript";
            this.TbScript.Size = new System.Drawing.Size(100, 21);
            this.TbScript.TabIndex = 5;
            // 
            // LbScript
            // 
            this.LbScript.AutoSize = true;
            this.LbScript.Location = new System.Drawing.Point(3, 60);
            this.LbScript.Name = "LbScript";
            this.LbScript.Size = new System.Drawing.Size(71, 12);
            this.LbScript.TabIndex = 4;
            this.LbScript.Text = "执行脚本(&S)";
            // 
            // UcHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TbMemo);
            this.Controls.Add(this.LbMemo);
            this.Controls.Add(this.TbScript);
            this.Controls.Add(this.LbScript);
            this.Controls.Add(this.TbTarget);
            this.Controls.Add(this.LbTarget);
            this.Controls.Add(this.TbText);
            this.Controls.Add(this.LbText);
            this.Name = "UcHeader";
            this.Size = new System.Drawing.Size(231, 183);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbText;
        private System.Windows.Forms.TextBox TbText;
        private System.Windows.Forms.Label LbTarget;
        private System.Windows.Forms.TextBox TbTarget;
        private System.Windows.Forms.TextBox TbMemo;
        private System.Windows.Forms.Label LbMemo;
        private System.Windows.Forms.TextBox TbScript;
        private System.Windows.Forms.Label LbScript;
    }
}

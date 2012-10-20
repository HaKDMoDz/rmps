namespace Me.Amon.Pwd.V.Wiz.Editer
{
    partial class AttPass
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
            this.TbData = new System.Windows.Forms.TextBox();
            this.BtGen = new System.Windows.Forms.Button();
            this.BtMod = new System.Windows.Forms.Button();
            this.BtCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TbData
            // 
            this.TbData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TbData.Location = new System.Drawing.Point(0, 0);
            this.TbData.Name = "TbData";
            this.TbData.Size = new System.Drawing.Size(266, 21);
            this.TbData.TabIndex = 0;
            this.TbData.UseSystemPasswordChar = true;
            // 
            // BtGen
            // 
            this.BtGen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtGen.FlatAppearance.BorderSize = 0;
            this.BtGen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtGen.Location = new System.Drawing.Point(299, 0);
            this.BtGen.Name = "BtGen";
            this.BtGen.Size = new System.Drawing.Size(21, 21);
            this.BtGen.TabIndex = 2;
            this.BtGen.TabStop = false;
            this.BtGen.UseVisualStyleBackColor = true;
            this.BtGen.Click += new System.EventHandler(this.BtGen_Click);
            // 
            // BtMod
            // 
            this.BtMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtMod.FlatAppearance.BorderSize = 0;
            this.BtMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtMod.Location = new System.Drawing.Point(272, 0);
            this.BtMod.Name = "BtMod";
            this.BtMod.Size = new System.Drawing.Size(21, 21);
            this.BtMod.TabIndex = 1;
            this.BtMod.TabStop = false;
            this.BtMod.UseVisualStyleBackColor = true;
            this.BtMod.Click += new System.EventHandler(this.BtMod_Click);
            // 
            // BtCopy
            // 
            this.BtCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtCopy.FlatAppearance.BorderSize = 0;
            this.BtCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtCopy.Location = new System.Drawing.Point(326, 0);
            this.BtCopy.Name = "BtCopy";
            this.BtCopy.Size = new System.Drawing.Size(21, 21);
            this.BtCopy.TabIndex = 4;
            this.BtCopy.TabStop = false;
            this.BtCopy.UseVisualStyleBackColor = true;
            this.BtCopy.Click += new System.EventHandler(this.BtCopy_Click);
            // 
            // BeanPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtCopy);
            this.Controls.Add(this.BtMod);
            this.Controls.Add(this.BtGen);
            this.Controls.Add(this.TbData);
            this.Name = "BeanPass";
            this.Size = new System.Drawing.Size(350, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbData;
        private System.Windows.Forms.Button BtGen;
        private System.Windows.Forms.Button BtMod;
        private System.Windows.Forms.Button BtCopy;
    }
}

﻿namespace Me.Amon.Pwd.V.Wiz.Editer
{
    partial class UcLineAtt
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
            this.BtOpt = new System.Windows.Forms.Button();
            this.TbData = new System.Windows.Forms.TextBox();
            this.BtFill = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtOpt
            // 
            this.BtOpt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOpt.FlatAppearance.BorderSize = 0;
            this.BtOpt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtOpt.Location = new System.Drawing.Point(299, 0);
            this.BtOpt.Name = "BtOpt";
            this.BtOpt.Size = new System.Drawing.Size(21, 21);
            this.BtOpt.TabIndex = 1;
            this.BtOpt.TabStop = false;
            this.BtOpt.UseVisualStyleBackColor = true;
            this.BtOpt.Click += new System.EventHandler(this.BtOpt_Click);
            // 
            // TbData
            // 
            this.TbData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TbData.Location = new System.Drawing.Point(0, 0);
            this.TbData.Name = "TbData";
            this.TbData.Size = new System.Drawing.Size(293, 21);
            this.TbData.TabIndex = 0;
            // 
            // BtFill
            // 
            this.BtFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtFill.FlatAppearance.BorderSize = 0;
            this.BtFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtFill.Location = new System.Drawing.Point(326, 0);
            this.BtFill.Name = "BtFill";
            this.BtFill.Size = new System.Drawing.Size(21, 21);
            this.BtFill.TabIndex = 2;
            this.BtFill.TabStop = false;
            this.BtFill.UseVisualStyleBackColor = true;
            this.BtFill.Click += new System.EventHandler(this.BtFill_Click);
            // 
            // UcLineAtt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtFill);
            this.Controls.Add(this.BtOpt);
            this.Controls.Add(this.TbData);
            this.Name = "UcLineAtt";
            this.Size = new System.Drawing.Size(350, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtOpt;
        private System.Windows.Forms.TextBox TbData;
        private System.Windows.Forms.Button BtFill;
    }
}

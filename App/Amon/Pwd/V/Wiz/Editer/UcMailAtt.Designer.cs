﻿namespace Me.Amon.Pwd.V.Wiz.Editer
{
    partial class UcMailAtt
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
            this.BtSend = new System.Windows.Forms.Button();
            this.BtFill = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            // BtSend
            // 
            this.BtSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtSend.FlatAppearance.BorderSize = 0;
            this.BtSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtSend.Location = new System.Drawing.Point(299, 0);
            this.BtSend.Name = "BtSend";
            this.BtSend.Size = new System.Drawing.Size(21, 21);
            this.BtSend.TabIndex = 1;
            this.BtSend.TabStop = false;
            this.BtSend.UseVisualStyleBackColor = true;
            this.BtSend.Click += new System.EventHandler(this.BtSend_Click);
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
            // UcMailAtt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtFill);
            this.Controls.Add(this.BtSend);
            this.Controls.Add(this.TbData);
            this.Name = "UcMailAtt";
            this.Size = new System.Drawing.Size(350, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbData;
        private System.Windows.Forms.Button BtSend;
        private System.Windows.Forms.Button BtFill;
    }
}

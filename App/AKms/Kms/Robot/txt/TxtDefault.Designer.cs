﻿namespace Me.Amon.Kms.Robot.txt
{
    partial class TxtDefault
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
            this.LsRes = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LsRes
            // 
            this.LsRes.FormattingEnabled = true;
            this.LsRes.ItemHeight = 12;
            this.LsRes.Location = new System.Drawing.Point(0, 0);
            this.LsRes.Name = "LsRes";
            this.LsRes.Size = new System.Drawing.Size(172, 208);
            this.LsRes.TabIndex = 0;
            this.LsRes.DoubleClick += new System.EventHandler(this.LsRes_DoubleClick);
            // 
            // TxtList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LsRes);
            this.Name = "TxtList";
            this.Size = new System.Drawing.Size(172, 208);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LsRes;
    }
}

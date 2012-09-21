namespace Me.Amon.Kms.Training.Opt
{
    partial class Opinions
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
            this.TsToolBar = new System.Windows.Forms.ToolStrip();
            this.LbInfo = new System.Windows.Forms.ToolStripLabel();
            this.BtOk = new System.Windows.Forms.ToolStripButton();
            this.BtNo = new System.Windows.Forms.ToolStripButton();
            this.TsToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // TsToolBar
            // 
            this.TsToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LbInfo,
            this.BtOk,
            this.BtNo});
            this.TsToolBar.Location = new System.Drawing.Point(0, 0);
            this.TsToolBar.Name = "TsToolBar";
            this.TsToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.TsToolBar.Size = new System.Drawing.Size(290, 25);
            this.TsToolBar.TabIndex = 0;
            this.TsToolBar.Text = "toolStrip1";
            // 
            // LbInfo
            // 
            this.LbInfo.Name = "LbInfo";
            this.LbInfo.Size = new System.Drawing.Size(44, 22);
            this.LbInfo.Text = "意见：";
            // 
            // BtOk
            // 
            this.BtOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtOk.Image = global::Me.Amon.Properties.Resources.ok;
            this.BtOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(23, 22);
            this.BtOk.Text = "好的";
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // BtNo
            // 
            this.BtNo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtNo.Image = global::Me.Amon.Properties.Resources.no;
            this.BtNo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtNo.Name = "BtNo";
            this.BtNo.Size = new System.Drawing.Size(23, 22);
            this.BtNo.Text = "不了";
            this.BtNo.Click += new System.EventHandler(this.BtNo_Click);
            // 
            // Opinions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TsToolBar);
            this.Name = "Opinions";
            this.Size = new System.Drawing.Size(290, 25);
            this.TsToolBar.ResumeLayout(false);
            this.TsToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TsToolBar;
        private System.Windows.Forms.ToolStripButton BtOk;
        private System.Windows.Forms.ToolStripButton BtNo;
        private System.Windows.Forms.ToolStripLabel LbInfo;

    }
}

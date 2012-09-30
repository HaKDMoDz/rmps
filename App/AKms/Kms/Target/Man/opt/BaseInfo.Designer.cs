namespace Me.Amon.Kms.Target.Man
{
    partial class BaseInfo
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
            this.CbLanguage = new System.Windows.Forms.ToolStripComboBox();
            this.CbStyle = new System.Windows.Forms.ToolStripComboBox();
            this.TsToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // TsToolBar
            // 
            this.TsToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LbInfo,
            this.CbLanguage,
            this.CbStyle});
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
            this.LbInfo.Text = "基本：";
            // 
            // CbLanguage
            // 
            this.CbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbLanguage.Font = new System.Drawing.Font("宋体", 9F);
            this.CbLanguage.Name = "CbLanguage";
            this.CbLanguage.Size = new System.Drawing.Size(121, 25);
            this.CbLanguage.SelectedIndexChanged += new System.EventHandler(this.CbLanguage_SelectedIndexChanged);
            // 
            // CbStyle
            // 
            this.CbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbStyle.Font = new System.Drawing.Font("宋体", 9F);
            this.CbStyle.Name = "CbStyle";
            this.CbStyle.Size = new System.Drawing.Size(75, 25);
            this.CbStyle.SelectedIndexChanged += new System.EventHandler(this.CbStyle_SelectedIndexChanged);
            // 
            // BaseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TsToolBar);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BaseInfo";
            this.Size = new System.Drawing.Size(290, 25);
            this.TsToolBar.ResumeLayout(false);
            this.TsToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TsToolBar;
        private System.Windows.Forms.ToolStripComboBox CbLanguage;
        private System.Windows.Forms.ToolStripComboBox CbStyle;
        private System.Windows.Forms.ToolStripLabel LbInfo;

    }
}

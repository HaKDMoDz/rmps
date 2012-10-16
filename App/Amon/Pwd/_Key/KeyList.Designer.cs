namespace Me.Amon.Pwd._Key
{
    partial class KeyList
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
            this.LbKey = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LbKey
            // 
            this.LbKey.AllowDrop = true;
            this.LbKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbKey.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LbKey.FormattingEnabled = true;
            this.LbKey.IntegralHeight = false;
            this.LbKey.ItemHeight = 32;
            this.LbKey.Location = new System.Drawing.Point(0, 0);
            this.LbKey.Name = "LbKey";
            this.LbKey.Size = new System.Drawing.Size(150, 150);
            this.LbKey.TabIndex = 0;
            this.LbKey.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LbKey_DrawItem);
            this.LbKey.SelectedIndexChanged += new System.EventHandler(this.LbKey_SelectedIndexChanged);
            this.LbKey.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LbKey_MouseDown);
            this.LbKey.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LbKey_MouseUp);
            // 
            // KeyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LbKey);
            this.Name = "KeyList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LbKey;
    }
}

namespace Me.Amon.Img.V.Ico
{
    partial class IcoEditor
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
            this.LbIco = new System.Windows.Forms.ListBox();
            this.PbIco = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbIco)).BeginInit();
            this.SuspendLayout();
            // 
            // LbIco
            // 
            this.LbIco.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LbIco.FormattingEnabled = true;
            this.LbIco.IntegralHeight = false;
            this.LbIco.Location = new System.Drawing.Point(0, 0);
            this.LbIco.Name = "LbIco";
            this.LbIco.Size = new System.Drawing.Size(120, 260);
            this.LbIco.TabIndex = 0;
            this.LbIco.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LbIco_DrawItem);
            this.LbIco.SelectedIndexChanged += new System.EventHandler(this.LbIco_SelectedIndexChanged);
            // 
            // PbIco
            // 
            this.PbIco.Location = new System.Drawing.Point(126, 0);
            this.PbIco.Name = "PbIco";
            this.PbIco.Size = new System.Drawing.Size(256, 260);
            this.PbIco.TabIndex = 1;
            this.PbIco.TabStop = false;
            // 
            // IcoEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbIco);
            this.Controls.Add(this.LbIco);
            this.Name = "IcoEditor";
            this.Size = new System.Drawing.Size(486, 260);
            ((System.ComponentModel.ISupportInitialize)(this.PbIco)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LbIco;
        private System.Windows.Forms.PictureBox PbIco;

    }
}

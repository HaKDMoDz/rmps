namespace Me.Amon.Kms.Robot
{
    partial class KmsHuman
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
            this.components = new System.ComponentModel.Container();
            this.CbRes = new System.Windows.Forms.ComboBox();
            this.BtRes = new System.Windows.Forms.PictureBox();
            this.CtMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MiTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.MiImg = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.BtRes)).BeginInit();
            this.CtMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CbRes
            // 
            this.CbRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbRes.FormattingEnabled = true;
            this.CbRes.Location = new System.Drawing.Point(5, 3);
            this.CbRes.Name = "CbRes";
            this.CbRes.Size = new System.Drawing.Size(130, 20);
            this.CbRes.TabIndex = 0;
            this.CbRes.SelectedIndexChanged += new System.EventHandler(this.CbRes_SelectedIndexChanged);
            // 
            // BtRes
            // 
            this.BtRes.Location = new System.Drawing.Point(141, 3);
            this.BtRes.Name = "BtRes";
            this.BtRes.Size = new System.Drawing.Size(36, 20);
            this.BtRes.TabIndex = 1;
            this.BtRes.TabStop = false;
            this.BtRes.MouseLeave += new System.EventHandler(this.BtRes_MouseLeave);
            this.BtRes.Click += new System.EventHandler(this.BtRes_Click);
            this.BtRes.MouseEnter += new System.EventHandler(this.BtRes_MouseEnter);
            // 
            // CtMenu
            // 
            this.CtMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiTxt,
            this.MiImg});
            this.CtMenu.Name = "CtMenu";
            this.CtMenu.Size = new System.Drawing.Size(95, 48);
            // 
            // MiTxt
            // 
            this.MiTxt.Name = "MiTxt";
            this.MiTxt.Size = new System.Drawing.Size(94, 22);
            this.MiTxt.Text = "文本";
            this.MiTxt.Click += new System.EventHandler(this.MiTxt_Click);
            // 
            // MiImg
            // 
            this.MiImg.Name = "MiImg";
            this.MiImg.Size = new System.Drawing.Size(94, 22);
            this.MiImg.Text = "截图";
            this.MiImg.Click += new System.EventHandler(this.MiImg_Click);
            // 
            // KmsHuman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtRes);
            this.Controls.Add(this.CbRes);
            this.Name = "KmsHuman";
            this.Size = new System.Drawing.Size(182, 242);
            ((System.ComponentModel.ISupportInitialize)(this.BtRes)).EndInit();
            this.CtMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CbRes;
        private System.Windows.Forms.PictureBox BtRes;
        private System.Windows.Forms.ContextMenuStrip CtMenu;
        private System.Windows.Forms.ToolStripMenuItem MiTxt;
        private System.Windows.Forms.ToolStripMenuItem MiImg;
    }
}

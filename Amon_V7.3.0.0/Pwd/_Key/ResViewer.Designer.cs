namespace Me.Amon.Pwd._Key
{
    partial class ResViewer
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LvIco = new System.Windows.Forms.ListView();
            this.IlIco = new System.Windows.Forms.ImageList(this.components);
            this.BnOk = new System.Windows.Forms.Button();
            this.BnNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LvIco
            // 
            this.LvIco.LargeImageList = this.IlIco;
            this.LvIco.Location = new System.Drawing.Point(12, 12);
            this.LvIco.MultiSelect = false;
            this.LvIco.Name = "LvIco";
            this.LvIco.Size = new System.Drawing.Size(270, 219);
            this.LvIco.TabIndex = 0;
            this.LvIco.UseCompatibleStateImageBehavior = false;
            this.LvIco.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LvIco_MouseDoubleClick);
            // 
            // IlIco
            // 
            this.IlIco.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.IlIco.ImageSize = new System.Drawing.Size(32, 32);
            this.IlIco.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // BnOk
            // 
            this.BnOk.Location = new System.Drawing.Point(126, 237);
            this.BnOk.Name = "BnOk";
            this.BnOk.Size = new System.Drawing.Size(75, 23);
            this.BnOk.TabIndex = 1;
            this.BnOk.Text = "确定(&O)";
            this.BnOk.UseVisualStyleBackColor = true;
            this.BnOk.Click += new System.EventHandler(this.BnOk_Click);
            // 
            // BnNo
            // 
            this.BnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BnNo.Location = new System.Drawing.Point(207, 237);
            this.BnNo.Name = "BnNo";
            this.BnNo.Size = new System.Drawing.Size(75, 23);
            this.BnNo.TabIndex = 2;
            this.BnNo.Text = "取消(&C)";
            this.BnNo.UseVisualStyleBackColor = true;
            this.BnNo.Click += new System.EventHandler(this.BnNo_Click);
            // 
            // IcoList
            // 
            this.AcceptButton = this.BnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BnNo;
            this.ClientSize = new System.Drawing.Size(294, 272);
            this.Controls.Add(this.BnNo);
            this.Controls.Add(this.BnOk);
            this.Controls.Add(this.LvIco);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IcoList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图标资源";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LvIco;
        private System.Windows.Forms.Button BnOk;
        private System.Windows.Forms.Button BnNo;
        private System.Windows.Forms.ImageList IlIco;
    }
}
namespace Me.Amon.Uw
{
    partial class PngSeeker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PngSeeker));
            this.IlPng = new System.Windows.Forms.ImageList(this.components);
            this.LvPng = new System.Windows.Forms.ListView();
            this.BtSelect = new System.Windows.Forms.Button();
            this.BtAppend = new System.Windows.Forms.Button();
            this.BtCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IlPng
            // 
            this.IlPng.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.IlPng.ImageSize = new System.Drawing.Size(16, 16);
            this.IlPng.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // LvPng
            // 
            this.LvPng.LargeImageList = this.IlPng;
            this.LvPng.Location = new System.Drawing.Point(12, 12);
            this.LvPng.Name = "LvPng";
            this.LvPng.Size = new System.Drawing.Size(260, 209);
            this.LvPng.TabIndex = 0;
            this.LvPng.UseCompatibleStateImageBehavior = false;
            this.LvPng.DoubleClick += new System.EventHandler(this.LvPng_DoubleClick);
            // 
            // BtSelect
            // 
            this.BtSelect.Location = new System.Drawing.Point(35, 227);
            this.BtSelect.Name = "BtSelect";
            this.BtSelect.Size = new System.Drawing.Size(75, 23);
            this.BtSelect.TabIndex = 1;
            this.BtSelect.Text = "选择(&S)";
            this.BtSelect.UseVisualStyleBackColor = true;
            this.BtSelect.Click += new System.EventHandler(this.BtSelect_Click);
            // 
            // BtAppend
            // 
            this.BtAppend.Location = new System.Drawing.Point(116, 227);
            this.BtAppend.Name = "BtAppend";
            this.BtAppend.Size = new System.Drawing.Size(75, 23);
            this.BtAppend.TabIndex = 2;
            this.BtAppend.Text = "追加(&A)";
            this.BtAppend.UseVisualStyleBackColor = true;
            this.BtAppend.Click += new System.EventHandler(this.BtAppend_Click);
            // 
            // BtCancel
            // 
            this.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtCancel.Location = new System.Drawing.Point(197, 227);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(75, 23);
            this.BtCancel.TabIndex = 3;
            this.BtCancel.Text = "取消(&C)";
            this.BtCancel.UseVisualStyleBackColor = true;
            this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // PngSeeker
            // 
            this.AcceptButton = this.BtSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtCancel;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.BtAppend);
            this.Controls.Add(this.BtSelect);
            this.Controls.Add(this.LvPng);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PngSeeker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "图标管理";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList IlPng;
        private System.Windows.Forms.ListView LvPng;
        private System.Windows.Forms.Button BtSelect;
        private System.Windows.Forms.Button BtAppend;
        private System.Windows.Forms.Button BtCancel;
    }
}
namespace Me.Amon.Uw
{
    partial class ImgViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImgViewer));
            this.PlImg = new System.Windows.Forms.Panel();
            this.TlGrid = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtCursor = new System.Windows.Forms.Button();
            this.BtGrid = new System.Windows.Forms.Button();
            this.BtEraser = new System.Windows.Forms.Button();
            this.PbImg = new System.Windows.Forms.PictureBox();
            this.PlImg.SuspendLayout();
            this.TlGrid.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbImg)).BeginInit();
            this.SuspendLayout();
            // 
            // PlImg
            // 
            this.PlImg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlImg.AutoScroll = true;
            this.PlImg.Controls.Add(this.PbImg);
            this.PlImg.Location = new System.Drawing.Point(12, 12);
            this.PlImg.Name = "PlImg";
            this.PlImg.Size = new System.Drawing.Size(260, 197);
            this.PlImg.TabIndex = 0;
            // 
            // TlGrid
            // 
            this.TlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TlGrid.ColumnCount = 3;
            this.TlGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.TlGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlGrid.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.TlGrid.Location = new System.Drawing.Point(12, 215);
            this.TlGrid.Name = "TlGrid";
            this.TlGrid.RowCount = 1;
            this.TlGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlGrid.Size = new System.Drawing.Size(260, 35);
            this.TlGrid.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BtCursor);
            this.flowLayoutPanel1.Controls.Add(this.BtGrid);
            this.flowLayoutPanel1.Controls.Add(this.BtEraser);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(86, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(87, 29);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // BtCursor
            // 
            this.BtCursor.Location = new System.Drawing.Point(3, 3);
            this.BtCursor.Name = "BtCursor";
            this.BtCursor.Size = new System.Drawing.Size(23, 23);
            this.BtCursor.TabIndex = 0;
            this.BtCursor.Text = "button1";
            this.BtCursor.UseVisualStyleBackColor = true;
            this.BtCursor.Click += new System.EventHandler(this.BtCursor_Click);
            // 
            // BtGrid
            // 
            this.BtGrid.Location = new System.Drawing.Point(32, 3);
            this.BtGrid.Name = "BtGrid";
            this.BtGrid.Size = new System.Drawing.Size(23, 23);
            this.BtGrid.TabIndex = 1;
            this.BtGrid.Text = "button2";
            this.BtGrid.UseVisualStyleBackColor = true;
            this.BtGrid.Click += new System.EventHandler(this.BtGrid_Click);
            // 
            // BtEraser
            // 
            this.BtEraser.Location = new System.Drawing.Point(61, 3);
            this.BtEraser.Name = "BtEraser";
            this.BtEraser.Size = new System.Drawing.Size(23, 23);
            this.BtEraser.TabIndex = 2;
            this.BtEraser.Text = "button3";
            this.BtEraser.UseVisualStyleBackColor = true;
            this.BtEraser.Click += new System.EventHandler(this.BtEraser_Click);
            // 
            // PbImg
            // 
            this.PbImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbImg.Location = new System.Drawing.Point(81, 66);
            this.PbImg.Name = "PbImg";
            this.PbImg.Size = new System.Drawing.Size(100, 50);
            this.PbImg.TabIndex = 0;
            this.PbImg.TabStop = false;
            // 
            // ImgViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.TlGrid);
            this.Controls.Add(this.PlImg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImgViewer";
            this.Text = "图像查看器";
            this.PlImg.ResumeLayout(false);
            this.TlGrid.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlImg;
        private System.Windows.Forms.TableLayoutPanel TlGrid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button BtCursor;
        private System.Windows.Forms.Button BtGrid;
        private System.Windows.Forms.Button BtEraser;
        private System.Windows.Forms.PictureBox PbImg;
    }
}
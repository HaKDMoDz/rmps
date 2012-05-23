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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImgViewer));
            this.PlImg = new System.Windows.Forms.Panel();
            this.PbImg = new System.Windows.Forms.PictureBox();
            this.TlGrid = new System.Windows.Forms.TableLayoutPanel();
            this.FlGrid = new System.Windows.Forms.FlowLayoutPanel();
            this.BtCursor = new System.Windows.Forms.Button();
            this.BtGrid = new System.Windows.Forms.Button();
            this.BtEraser = new System.Windows.Forms.Button();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.PlImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbImg)).BeginInit();
            this.TlGrid.SuspendLayout();
            this.FlGrid.SuspendLayout();
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
            this.PlImg.Size = new System.Drawing.Size(360, 197);
            this.PlImg.TabIndex = 0;
            // 
            // PbImg
            // 
            this.PbImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbImg.Location = new System.Drawing.Point(130, 71);
            this.PbImg.Name = "PbImg";
            this.PbImg.Size = new System.Drawing.Size(100, 50);
            this.PbImg.TabIndex = 0;
            this.PbImg.TabStop = false;
            this.PbImg.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbImg_MouseClick);
            this.PbImg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbImg_MouseMove);
            // 
            // TlGrid
            // 
            this.TlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TlGrid.ColumnCount = 3;
            this.TlGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.TlGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlGrid.Controls.Add(this.FlGrid, 1, 0);
            this.TlGrid.Location = new System.Drawing.Point(12, 215);
            this.TlGrid.Name = "TlGrid";
            this.TlGrid.RowCount = 1;
            this.TlGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlGrid.Size = new System.Drawing.Size(360, 35);
            this.TlGrid.TabIndex = 1;
            // 
            // FlGrid
            // 
            this.FlGrid.Controls.Add(this.BtCursor);
            this.FlGrid.Controls.Add(this.BtGrid);
            this.FlGrid.Controls.Add(this.BtEraser);
            this.FlGrid.Location = new System.Drawing.Point(136, 3);
            this.FlGrid.Name = "FlGrid";
            this.FlGrid.Size = new System.Drawing.Size(87, 29);
            this.FlGrid.TabIndex = 0;
            // 
            // BtCursor
            // 
            this.BtCursor.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtCursor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtCursor.Image = global::Me.Amon.Properties.Resources.CurSel;
            this.BtCursor.Location = new System.Drawing.Point(3, 3);
            this.BtCursor.Name = "BtCursor";
            this.BtCursor.Size = new System.Drawing.Size(23, 23);
            this.BtCursor.TabIndex = 0;
            this.TpTips.SetToolTip(this.BtCursor, "鼠标提示");
            this.BtCursor.UseVisualStyleBackColor = true;
            this.BtCursor.Click += new System.EventHandler(this.BtCursor_Click);
            // 
            // BtGrid
            // 
            this.BtGrid.Image = global::Me.Amon.Properties.Resources.PosDef;
            this.BtGrid.Location = new System.Drawing.Point(32, 3);
            this.BtGrid.Name = "BtGrid";
            this.BtGrid.Size = new System.Drawing.Size(23, 23);
            this.BtGrid.TabIndex = 1;
            this.TpTips.SetToolTip(this.BtGrid, "位置提示");
            this.BtGrid.UseVisualStyleBackColor = true;
            this.BtGrid.Click += new System.EventHandler(this.BtGrid_Click);
            // 
            // BtEraser
            // 
            this.BtEraser.Image = global::Me.Amon.Properties.Resources.Eraser;
            this.BtEraser.Location = new System.Drawing.Point(61, 3);
            this.BtEraser.Name = "BtEraser";
            this.BtEraser.Size = new System.Drawing.Size(23, 23);
            this.BtEraser.TabIndex = 2;
            this.TpTips.SetToolTip(this.BtEraser, "清除所有标记");
            this.BtEraser.UseVisualStyleBackColor = true;
            this.BtEraser.Click += new System.EventHandler(this.BtEraser_Click);
            // 
            // ImgViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.TlGrid);
            this.Controls.Add(this.PlImg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImgViewer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图像查看器";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ImgViewer_KeyDown);
            this.Resize += new System.EventHandler(this.ImgViewer_Resize);
            this.PlImg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbImg)).EndInit();
            this.TlGrid.ResumeLayout(false);
            this.FlGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlImg;
        private System.Windows.Forms.TableLayoutPanel TlGrid;
        private System.Windows.Forms.FlowLayoutPanel FlGrid;
        private System.Windows.Forms.Button BtCursor;
        private System.Windows.Forms.Button BtGrid;
        private System.Windows.Forms.Button BtEraser;
        private System.Windows.Forms.PictureBox PbImg;
        private System.Windows.Forms.ToolTip TpTips;
    }
}
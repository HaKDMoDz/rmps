namespace Me.Amon.Img.V
{
    partial class ALarge
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
            this.PbImg = new System.Windows.Forms.PictureBox();
            this.FlGrid = new System.Windows.Forms.FlowLayoutPanel();
            this.BtCursor = new System.Windows.Forms.Button();
            this.BtGrid = new System.Windows.Forms.Button();
            this.BtEraser = new System.Windows.Forms.Button();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.TlGrid = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.PbImg)).BeginInit();
            this.FlGrid.SuspendLayout();
            this.TlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // PbImg
            // 
            this.PbImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbImg.Location = new System.Drawing.Point(3, 3);
            this.PbImg.Name = "PbImg";
            this.PbImg.Size = new System.Drawing.Size(294, 213);
            this.PbImg.TabIndex = 0;
            this.PbImg.TabStop = false;
            // 
            // FlGrid
            // 
            this.FlGrid.Controls.Add(this.BtCursor);
            this.FlGrid.Controls.Add(this.BtGrid);
            this.FlGrid.Controls.Add(this.BtEraser);
            this.FlGrid.Location = new System.Drawing.Point(103, 3);
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
            this.TlGrid.Location = new System.Drawing.Point(3, 222);
            this.TlGrid.Name = "TlGrid";
            this.TlGrid.RowCount = 1;
            this.TlGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlGrid.Size = new System.Drawing.Size(294, 35);
            this.TlGrid.TabIndex = 3;
            // 
            // ALarge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbImg);
            this.Controls.Add(this.TlGrid);
            this.Name = "ALarge";
            this.Size = new System.Drawing.Size(300, 260);
            ((System.ComponentModel.ISupportInitialize)(this.PbImg)).EndInit();
            this.FlGrid.ResumeLayout(false);
            this.TlGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtCursor;
        private System.Windows.Forms.ToolTip TpTips;
        private System.Windows.Forms.PictureBox PbImg;
        private System.Windows.Forms.Button BtGrid;
        private System.Windows.Forms.Button BtEraser;
        private System.Windows.Forms.FlowLayoutPanel FlGrid;
        private System.Windows.Forms.TableLayoutPanel TlGrid;
    }
}

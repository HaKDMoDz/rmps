namespace Me.Amon.Img.V.Dlg
{
    partial class DImg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlImg = new System.Windows.Forms.Panel();
            this.PbImg = new System.Windows.Forms.PictureBox();
            this.BtCursor = new System.Windows.Forms.Button();
            this.BtGrid = new System.Windows.Forms.Button();
            this.BtEraser = new System.Windows.Forms.Button();
            this.PlImg.SuspendLayout();
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
            this.PlImg.Size = new System.Drawing.Size(360, 209);
            this.PlImg.TabIndex = 0;
            // 
            // PbImg
            // 
            this.PbImg.Location = new System.Drawing.Point(127, 77);
            this.PbImg.Name = "PbImg";
            this.PbImg.Size = new System.Drawing.Size(100, 50);
            this.PbImg.TabIndex = 0;
            this.PbImg.TabStop = false;
            this.PbImg.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbImg_MouseClick);
            this.PbImg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbImg_MouseMove);
            // 
            // BtCursor
            // 
            this.BtCursor.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtCursor.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtCursor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtCursor.Image = global::Me.Amon.Properties.Resources.CurSel;
            this.BtCursor.Location = new System.Drawing.Point(153, 227);
            this.BtCursor.Name = "BtCursor";
            this.BtCursor.Size = new System.Drawing.Size(22, 22);
            this.BtCursor.TabIndex = 1;
            this.BtCursor.UseVisualStyleBackColor = true;
            this.BtCursor.Click += new System.EventHandler(this.BtCursor_Click);
            // 
            // BtGrid
            // 
            this.BtGrid.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtGrid.Image = global::Me.Amon.Properties.Resources.PosDef;
            this.BtGrid.Location = new System.Drawing.Point(181, 227);
            this.BtGrid.Name = "BtGrid";
            this.BtGrid.Size = new System.Drawing.Size(22, 22);
            this.BtGrid.TabIndex = 2;
            this.BtGrid.UseVisualStyleBackColor = true;
            this.BtGrid.Click += new System.EventHandler(this.BtGrid_Click);
            // 
            // BtEraser
            // 
            this.BtEraser.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtEraser.Image = global::Me.Amon.Properties.Resources.Eraser;
            this.BtEraser.Location = new System.Drawing.Point(209, 227);
            this.BtEraser.Name = "BtEraser";
            this.BtEraser.Size = new System.Drawing.Size(22, 22);
            this.BtEraser.TabIndex = 3;
            this.BtEraser.UseVisualStyleBackColor = true;
            this.BtEraser.Click += new System.EventHandler(this.BtEraser_Click);
            // 
            // DImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.BtCursor);
            this.Controls.Add(this.PlImg);
            this.Controls.Add(this.BtGrid);
            this.Controls.Add(this.BtEraser);
            this.Name = "DImg";
            this.ShowInTaskbar = false;
            this.Text = "图像查看器";
            this.PlImg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlImg;
        private System.Windows.Forms.Button BtCursor;
        private System.Windows.Forms.Button BtGrid;
        private System.Windows.Forms.Button BtEraser;
        private System.Windows.Forms.PictureBox PbImg;
    }
}
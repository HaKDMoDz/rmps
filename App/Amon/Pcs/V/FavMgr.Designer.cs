namespace Me.Amon.Pcs.V
{
    partial class FavMgr
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BnDelete = new System.Windows.Forms.Button();
            this.BnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(210, 239);
            this.listBox1.TabIndex = 0;
            // 
            // BnDelete
            // 
            this.BnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnDelete.Location = new System.Drawing.Point(66, 257);
            this.BnDelete.Name = "BnDelete";
            this.BnDelete.Size = new System.Drawing.Size(75, 23);
            this.BnDelete.TabIndex = 1;
            this.BnDelete.Text = "删除(&D)";
            this.BnDelete.UseVisualStyleBackColor = true;
            this.BnDelete.Click += new System.EventHandler(this.BnDelete_Click);
            // 
            // BnCancel
            // 
            this.BnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnCancel.Location = new System.Drawing.Point(147, 257);
            this.BnCancel.Name = "BnCancel";
            this.BnCancel.Size = new System.Drawing.Size(75, 23);
            this.BnCancel.TabIndex = 2;
            this.BnCancel.Text = "取消(&C)";
            this.BnCancel.UseVisualStyleBackColor = true;
            this.BnCancel.Click += new System.EventHandler(this.BnCancel_Click);
            // 
            // FavMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 292);
            this.Controls.Add(this.BnCancel);
            this.Controls.Add(this.BnDelete);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FavMgr";
            this.Text = "FavMgr";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BnDelete;
        private System.Windows.Forms.Button BnCancel;
    }
}
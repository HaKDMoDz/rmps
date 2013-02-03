namespace Me.Amon
{
    partial class Demo
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
            this.BtShow = new System.Windows.Forms.Button();
            this.BtHide = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtShow
            // 
            this.BtShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtShow.Location = new System.Drawing.Point(197, 226);
            this.BtShow.Name = "BtShow";
            this.BtShow.Size = new System.Drawing.Size(75, 23);
            this.BtShow.TabIndex = 0;
            this.BtShow.Text = "显示";
            this.BtShow.UseVisualStyleBackColor = true;
            this.BtShow.Click += new System.EventHandler(this.BtShow_Click);
            // 
            // BtHide
            // 
            this.BtHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtHide.Location = new System.Drawing.Point(116, 226);
            this.BtHide.Name = "BtHide";
            this.BtHide.Size = new System.Drawing.Size(75, 23);
            this.BtHide.TabIndex = 1;
            this.BtHide.Text = "隐藏";
            this.BtHide.UseVisualStyleBackColor = true;
            this.BtHide.Click += new System.EventHandler(this.BtHide_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(260, 208);
            this.textBox1.TabIndex = 2;
            // 
            // Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtHide);
            this.Controls.Add(this.BtShow);
            this.Name = "Demo";
            this.Text = "Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtShow;
        private System.Windows.Forms.Button BtHide;
        private System.Windows.Forms.TextBox textBox1;

    }
}
namespace Me.Amon.Sec.V.Wiz
{
    partial class UcKey
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
            this.BtPass = new System.Windows.Forms.Button();
            this.TbPass = new System.Windows.Forms.TextBox();
            this.LbPass = new System.Windows.Forms.Label();
            this.CbSize = new System.Windows.Forms.ComboBox();
            this.LbSize = new System.Windows.Forms.Label();
            this.BtOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtPass
            // 
            this.BtPass.Location = new System.Drawing.Point(189, 37);
            this.BtPass.Name = "BtPass";
            this.BtPass.Size = new System.Drawing.Size(19, 21);
            this.BtPass.TabIndex = 14;
            this.BtPass.Text = ".";
            this.BtPass.UseVisualStyleBackColor = true;
            // 
            // TbPass
            // 
            this.TbPass.Location = new System.Drawing.Point(62, 37);
            this.TbPass.Name = "TbPass";
            this.TbPass.Size = new System.Drawing.Size(121, 21);
            this.TbPass.TabIndex = 13;
            // 
            // LbPass
            // 
            this.LbPass.AutoSize = true;
            this.LbPass.Location = new System.Drawing.Point(12, 41);
            this.LbPass.Name = "LbPass";
            this.LbPass.Size = new System.Drawing.Size(47, 12);
            this.LbPass.TabIndex = 12;
            this.LbPass.Text = "口令(&K)";
            // 
            // CbSize
            // 
            this.CbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbSize.FormattingEnabled = true;
            this.CbSize.Location = new System.Drawing.Point(62, 12);
            this.CbSize.Name = "CbSize";
            this.CbSize.Size = new System.Drawing.Size(121, 20);
            this.CbSize.TabIndex = 11;
            // 
            // LbSize
            // 
            this.LbSize.AutoSize = true;
            this.LbSize.Location = new System.Drawing.Point(12, 16);
            this.LbSize.Name = "LbSize";
            this.LbSize.Size = new System.Drawing.Size(47, 12);
            this.LbSize.TabIndex = 10;
            this.LbSize.Text = "长度(&L)";
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(133, 64);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 15;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // UcKey
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 99);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.BtPass);
            this.Controls.Add(this.TbPass);
            this.Controls.Add(this.LbPass);
            this.Controls.Add(this.CbSize);
            this.Controls.Add(this.LbSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UcKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "口令";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button BtPass;
        public System.Windows.Forms.TextBox TbPass;
        public System.Windows.Forms.Label LbPass;
        public System.Windows.Forms.ComboBox CbSize;
        public System.Windows.Forms.Label LbSize;
        private System.Windows.Forms.Button BtOk;


    }
}
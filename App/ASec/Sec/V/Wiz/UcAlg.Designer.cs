namespace Me.Amon.Sec.V.Wiz
{
    partial class UcAlg
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
            this.CbPads = new System.Windows.Forms.ComboBox();
            this.LbPads = new System.Windows.Forms.Label();
            this.CbMode = new System.Windows.Forms.ComboBox();
            this.LbMode = new System.Windows.Forms.Label();
            this.CbName = new System.Windows.Forms.ComboBox();
            this.LbName = new System.Windows.Forms.Label();
            this.BtOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CbPads
            // 
            this.CbPads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbPads.FormattingEnabled = true;
            this.CbPads.Location = new System.Drawing.Point(62, 63);
            this.CbPads.Name = "CbPads";
            this.CbPads.Size = new System.Drawing.Size(121, 20);
            this.CbPads.TabIndex = 17;
            // 
            // LbPads
            // 
            this.LbPads.AutoSize = true;
            this.LbPads.Location = new System.Drawing.Point(12, 67);
            this.LbPads.Name = "LbPads";
            this.LbPads.Size = new System.Drawing.Size(47, 12);
            this.LbPads.TabIndex = 16;
            this.LbPads.Text = "长度(&L)";
            // 
            // CbMode
            // 
            this.CbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbMode.FormattingEnabled = true;
            this.CbMode.Location = new System.Drawing.Point(62, 37);
            this.CbMode.Name = "CbMode";
            this.CbMode.Size = new System.Drawing.Size(121, 20);
            this.CbMode.TabIndex = 15;
            // 
            // LbMode
            // 
            this.LbMode.AutoSize = true;
            this.LbMode.Location = new System.Drawing.Point(12, 41);
            this.LbMode.Name = "LbMode";
            this.LbMode.Size = new System.Drawing.Size(47, 12);
            this.LbMode.TabIndex = 14;
            this.LbMode.Text = "模式(&B)";
            // 
            // CbName
            // 
            this.CbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbName.FormattingEnabled = true;
            this.CbName.Location = new System.Drawing.Point(62, 12);
            this.CbName.Name = "CbName";
            this.CbName.Size = new System.Drawing.Size(121, 20);
            this.CbName.TabIndex = 13;
            // 
            // LbName
            // 
            this.LbName.AutoSize = true;
            this.LbName.Location = new System.Drawing.Point(12, 16);
            this.LbName.Name = "LbName";
            this.LbName.Size = new System.Drawing.Size(47, 12);
            this.LbName.TabIndex = 12;
            this.LbName.Text = "算法(&C)";
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(133, 89);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 18;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // UcAlg
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 124);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.CbPads);
            this.Controls.Add(this.LbPads);
            this.Controls.Add(this.CbMode);
            this.Controls.Add(this.LbMode);
            this.Controls.Add(this.CbName);
            this.Controls.Add(this.LbName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UcAlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "算法";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox CbPads;
        public System.Windows.Forms.Label LbPads;
        public System.Windows.Forms.ComboBox CbMode;
        public System.Windows.Forms.Label LbMode;
        public System.Windows.Forms.ComboBox CbName;
        public System.Windows.Forms.Label LbName;
        private System.Windows.Forms.Button BtOk;

    }
}
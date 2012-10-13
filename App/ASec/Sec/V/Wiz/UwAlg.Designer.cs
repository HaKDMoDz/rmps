namespace Me.Amon.Sec.V.Wiz
{
    partial class UwAlg
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
            this.CbAlg = new System.Windows.Forms.ComboBox();
            this.LlAlg = new System.Windows.Forms.Label();
            this.CbMod = new System.Windows.Forms.ComboBox();
            this.LlMod = new System.Windows.Forms.Label();
            this.CbPad = new System.Windows.Forms.ComboBox();
            this.LlPad = new System.Windows.Forms.Label();
            this.CbLen = new System.Windows.Forms.ComboBox();
            this.LlLen = new System.Windows.Forms.Label();
            this.BtOk = new System.Windows.Forms.Button();
            this.BtNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CbAlg
            // 
            this.CbAlg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbAlg.FormattingEnabled = true;
            this.CbAlg.Location = new System.Drawing.Point(65, 12);
            this.CbAlg.Name = "CbAlg";
            this.CbAlg.Size = new System.Drawing.Size(121, 20);
            this.CbAlg.TabIndex = 1;
            this.CbAlg.SelectedIndexChanged += new System.EventHandler(this.CbAlg_SelectedIndexChanged);
            // 
            // LlAlg
            // 
            this.LlAlg.AutoSize = true;
            this.LlAlg.Location = new System.Drawing.Point(12, 15);
            this.LlAlg.Name = "LlAlg";
            this.LlAlg.Size = new System.Drawing.Size(47, 12);
            this.LlAlg.TabIndex = 0;
            this.LlAlg.Text = "算法(&A)";
            // 
            // CbMod
            // 
            this.CbMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbMod.FormattingEnabled = true;
            this.CbMod.Location = new System.Drawing.Point(65, 38);
            this.CbMod.Name = "CbMod";
            this.CbMod.Size = new System.Drawing.Size(121, 20);
            this.CbMod.TabIndex = 3;
            // 
            // LlMod
            // 
            this.LlMod.AutoSize = true;
            this.LlMod.Location = new System.Drawing.Point(12, 41);
            this.LlMod.Name = "LlMod";
            this.LlMod.Size = new System.Drawing.Size(47, 12);
            this.LlMod.TabIndex = 2;
            this.LlMod.Text = "模式(&M)";
            // 
            // CbPad
            // 
            this.CbPad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbPad.FormattingEnabled = true;
            this.CbPad.Location = new System.Drawing.Point(65, 64);
            this.CbPad.Name = "CbPad";
            this.CbPad.Size = new System.Drawing.Size(121, 20);
            this.CbPad.TabIndex = 5;
            // 
            // LlPad
            // 
            this.LlPad.AutoSize = true;
            this.LlPad.Location = new System.Drawing.Point(12, 67);
            this.LlPad.Name = "LlPad";
            this.LlPad.Size = new System.Drawing.Size(47, 12);
            this.LlPad.TabIndex = 4;
            this.LlPad.Text = "填充(&P)";
            // 
            // CbLen
            // 
            this.CbLen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbLen.FormattingEnabled = true;
            this.CbLen.Location = new System.Drawing.Point(65, 90);
            this.CbLen.Name = "CbLen";
            this.CbLen.Size = new System.Drawing.Size(121, 20);
            this.CbLen.TabIndex = 7;
            // 
            // LlLen
            // 
            this.LlLen.AutoSize = true;
            this.LlLen.Location = new System.Drawing.Point(12, 93);
            this.LlLen.Name = "LlLen";
            this.LlLen.Size = new System.Drawing.Size(47, 12);
            this.LlLen.TabIndex = 6;
            this.LlLen.Text = "长度(&L)";
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(52, 116);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 8;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // BtNo
            // 
            this.BtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNo.Location = new System.Drawing.Point(133, 116);
            this.BtNo.Name = "BtNo";
            this.BtNo.Size = new System.Drawing.Size(75, 23);
            this.BtNo.TabIndex = 9;
            this.BtNo.Text = "取消(&C)";
            this.BtNo.UseVisualStyleBackColor = true;
            this.BtNo.Click += new System.EventHandler(this.BtNo_Click);
            // 
            // UwAlg
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtNo;
            this.ClientSize = new System.Drawing.Size(220, 151);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.CbLen);
            this.Controls.Add(this.LlLen);
            this.Controls.Add(this.CbPad);
            this.Controls.Add(this.LlPad);
            this.Controls.Add(this.CbMod);
            this.Controls.Add(this.LlMod);
            this.Controls.Add(this.CbAlg);
            this.Controls.Add(this.LlAlg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UwAlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "算法";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CbAlg;
        private System.Windows.Forms.Label LlAlg;
        private System.Windows.Forms.ComboBox CbMod;
        private System.Windows.Forms.Label LlMod;
        private System.Windows.Forms.ComboBox CbPad;
        private System.Windows.Forms.Label LlPad;
        private System.Windows.Forms.ComboBox CbLen;
        private System.Windows.Forms.Label LlLen;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtNo;


    }
}
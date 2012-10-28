namespace Me.Amon.Rcg
{
    partial class WRcg
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
            this.TbKey = new System.Windows.Forms.TextBox();
            this.LlLength = new System.Windows.Forms.Label();
            this.SpLength = new System.Windows.Forms.NumericUpDown();
            this.LlCharset = new System.Windows.Forms.Label();
            this.CbCharset = new System.Windows.Forms.ComboBox();
            this.LlRepeatable = new System.Windows.Forms.Label();
            this.CbRepeatable = new System.Windows.Forms.CheckBox();
            this.BtGen = new System.Windows.Forms.Button();
            this.BtOk = new System.Windows.Forms.Button();
            this.BtNo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SpLength)).BeginInit();
            this.SuspendLayout();
            // 
            // TbKey
            // 
            this.TbKey.BackColor = System.Drawing.SystemColors.Window;
            this.TbKey.Location = new System.Drawing.Point(12, 12);
            this.TbKey.Multiline = true;
            this.TbKey.Name = "TbKey";
            this.TbKey.ReadOnly = true;
            this.TbKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbKey.Size = new System.Drawing.Size(260, 57);
            this.TbKey.TabIndex = 0;
            // 
            // LlLength
            // 
            this.LlLength.AutoSize = true;
            this.LlLength.Location = new System.Drawing.Point(12, 77);
            this.LlLength.Name = "LlLength";
            this.LlLength.Size = new System.Drawing.Size(47, 12);
            this.LlLength.TabIndex = 1;
            this.LlLength.Text = "长度(&L)";
            // 
            // SpLength
            // 
            this.SpLength.Location = new System.Drawing.Point(65, 75);
            this.SpLength.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.SpLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpLength.Name = "SpLength";
            this.SpLength.Size = new System.Drawing.Size(85, 21);
            this.SpLength.TabIndex = 2;
            this.SpLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LlCharset
            // 
            this.LlCharset.AutoSize = true;
            this.LlCharset.Location = new System.Drawing.Point(12, 105);
            this.LlCharset.Name = "LlCharset";
            this.LlCharset.Size = new System.Drawing.Size(47, 12);
            this.LlCharset.TabIndex = 3;
            this.LlCharset.Text = "字符(&M)";
            // 
            // CbCharset
            // 
            this.CbCharset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbCharset.FormattingEnabled = true;
            this.CbCharset.Location = new System.Drawing.Point(65, 102);
            this.CbCharset.Name = "CbCharset";
            this.CbCharset.Size = new System.Drawing.Size(121, 20);
            this.CbCharset.TabIndex = 4;
            // 
            // LlRepeatable
            // 
            this.LlRepeatable.AutoSize = true;
            this.LlRepeatable.Location = new System.Drawing.Point(12, 129);
            this.LlRepeatable.Name = "LlRepeatable";
            this.LlRepeatable.Size = new System.Drawing.Size(47, 12);
            this.LlRepeatable.TabIndex = 5;
            this.LlRepeatable.Text = "重复(&R)";
            // 
            // CbRepeatable
            // 
            this.CbRepeatable.AutoSize = true;
            this.CbRepeatable.Location = new System.Drawing.Point(65, 128);
            this.CbRepeatable.Name = "CbRepeatable";
            this.CbRepeatable.Size = new System.Drawing.Size(90, 16);
            this.CbRepeatable.TabIndex = 6;
            this.CbRepeatable.Text = "允许重复(&A)";
            this.CbRepeatable.UseVisualStyleBackColor = true;
            // 
            // BtGen
            // 
            this.BtGen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtGen.Location = new System.Drawing.Point(35, 153);
            this.BtGen.Name = "BtGen";
            this.BtGen.Size = new System.Drawing.Size(75, 23);
            this.BtGen.TabIndex = 7;
            this.BtGen.Text = "生成(&G)";
            this.BtGen.UseVisualStyleBackColor = true;
            this.BtGen.Click += new System.EventHandler(this.BtGen_Click);
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtOk.Location = new System.Drawing.Point(116, 153);
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
            this.BtNo.Location = new System.Drawing.Point(197, 153);
            this.BtNo.Name = "BtNo";
            this.BtNo.Size = new System.Drawing.Size(75, 23);
            this.BtNo.TabIndex = 9;
            this.BtNo.Text = "取消(&C)";
            this.BtNo.UseVisualStyleBackColor = true;
            this.BtNo.Click += new System.EventHandler(this.BtNo_Click);
            // 
            // WRcg
            // 
            this.AcceptButton = this.BtGen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtOk;
            this.ClientSize = new System.Drawing.Size(284, 188);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.BtGen);
            this.Controls.Add(this.CbRepeatable);
            this.Controls.Add(this.LlRepeatable);
            this.Controls.Add(this.CbCharset);
            this.Controls.Add(this.LlCharset);
            this.Controls.Add(this.SpLength);
            this.Controls.Add(this.LlLength);
            this.Controls.Add(this.TbKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WRcg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "随机字符生成器";
            ((System.ComponentModel.ISupportInitialize)(this.SpLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbKey;
        private System.Windows.Forms.Label LlLength;
        private System.Windows.Forms.NumericUpDown SpLength;
        private System.Windows.Forms.Label LlCharset;
        private System.Windows.Forms.ComboBox CbCharset;
        private System.Windows.Forms.Label LlRepeatable;
        private System.Windows.Forms.CheckBox CbRepeatable;
        private System.Windows.Forms.Button BtGen;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtNo;
    }
}
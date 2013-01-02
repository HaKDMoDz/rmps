namespace Me.Amon.Hosts
{
    partial class HostEditer
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
            this.LlGroup = new System.Windows.Forms.Label();
            this.CbGroup = new System.Windows.Forms.ComboBox();
            this.LlIp = new System.Windows.Forms.Label();
            this.TbIp = new System.Windows.Forms.TextBox();
            this.LlDomain = new System.Windows.Forms.Label();
            this.TbDomain = new System.Windows.Forms.TextBox();
            this.LlMemo = new System.Windows.Forms.Label();
            this.TbMemo = new System.Windows.Forms.TextBox();
            this.LlEnabled = new System.Windows.Forms.Label();
            this.CbEnabled = new System.Windows.Forms.CheckBox();
            this.BtOk = new System.Windows.Forms.Button();
            this.BtNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LlGroup
            // 
            this.LlGroup.AutoSize = true;
            this.LlGroup.Location = new System.Drawing.Point(12, 15);
            this.LlGroup.Name = "LlGroup";
            this.LlGroup.Size = new System.Drawing.Size(47, 12);
            this.LlGroup.TabIndex = 0;
            this.LlGroup.Text = "分组(&G)";
            // 
            // CbGroup
            // 
            this.CbGroup.FormattingEnabled = true;
            this.CbGroup.Location = new System.Drawing.Point(65, 12);
            this.CbGroup.Name = "CbGroup";
            this.CbGroup.Size = new System.Drawing.Size(121, 20);
            this.CbGroup.TabIndex = 1;
            // 
            // LlIp
            // 
            this.LlIp.AutoSize = true;
            this.LlIp.Location = new System.Drawing.Point(12, 41);
            this.LlIp.Name = "LlIp";
            this.LlIp.Size = new System.Drawing.Size(47, 12);
            this.LlIp.TabIndex = 2;
            this.LlIp.Text = "网址(&A)";
            // 
            // TbIp
            // 
            this.TbIp.Location = new System.Drawing.Point(65, 38);
            this.TbIp.Name = "TbIp";
            this.TbIp.Size = new System.Drawing.Size(176, 21);
            this.TbIp.TabIndex = 3;
            // 
            // LlDomain
            // 
            this.LlDomain.AutoSize = true;
            this.LlDomain.Location = new System.Drawing.Point(12, 71);
            this.LlDomain.Name = "LlDomain";
            this.LlDomain.Size = new System.Drawing.Size(47, 12);
            this.LlDomain.TabIndex = 4;
            this.LlDomain.Text = "域名(&D)";
            // 
            // TbDomain
            // 
            this.TbDomain.Location = new System.Drawing.Point(65, 65);
            this.TbDomain.Name = "TbDomain";
            this.TbDomain.Size = new System.Drawing.Size(176, 21);
            this.TbDomain.TabIndex = 5;
            // 
            // LlMemo
            // 
            this.LlMemo.AutoSize = true;
            this.LlMemo.Location = new System.Drawing.Point(12, 97);
            this.LlMemo.Name = "LlMemo";
            this.LlMemo.Size = new System.Drawing.Size(47, 12);
            this.LlMemo.TabIndex = 6;
            this.LlMemo.Text = "备注(&M)";
            // 
            // TbMemo
            // 
            this.TbMemo.Location = new System.Drawing.Point(65, 92);
            this.TbMemo.Name = "TbMemo";
            this.TbMemo.Size = new System.Drawing.Size(176, 21);
            this.TbMemo.TabIndex = 7;
            // 
            // LlEnabled
            // 
            this.LlEnabled.AutoSize = true;
            this.LlEnabled.Location = new System.Drawing.Point(12, 120);
            this.LlEnabled.Name = "LlEnabled";
            this.LlEnabled.Size = new System.Drawing.Size(47, 12);
            this.LlEnabled.TabIndex = 8;
            this.LlEnabled.Text = "状态(&S)";
            // 
            // CbEnabled
            // 
            this.CbEnabled.AutoSize = true;
            this.CbEnabled.Location = new System.Drawing.Point(65, 119);
            this.CbEnabled.Name = "CbEnabled";
            this.CbEnabled.Size = new System.Drawing.Size(66, 16);
            this.CbEnabled.TabIndex = 9;
            this.CbEnabled.Text = "启用(&E)";
            this.CbEnabled.UseVisualStyleBackColor = true;
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(86, 141);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 10;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // BtNo
            // 
            this.BtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtNo.Location = new System.Drawing.Point(167, 141);
            this.BtNo.Name = "BtNo";
            this.BtNo.Size = new System.Drawing.Size(75, 23);
            this.BtNo.TabIndex = 11;
            this.BtNo.Text = "取消(&C)";
            this.BtNo.UseVisualStyleBackColor = true;
            this.BtNo.Click += new System.EventHandler(this.BtNo_Click);
            // 
            // HostEditer
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtNo;
            this.ClientSize = new System.Drawing.Size(254, 176);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.CbEnabled);
            this.Controls.Add(this.LlEnabled);
            this.Controls.Add(this.TbMemo);
            this.Controls.Add(this.LlMemo);
            this.Controls.Add(this.TbDomain);
            this.Controls.Add(this.LlDomain);
            this.Controls.Add(this.TbIp);
            this.Controls.Add(this.LlIp);
            this.Controls.Add(this.CbGroup);
            this.Controls.Add(this.LlGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HostEditer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "主机";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LlGroup;
        private System.Windows.Forms.ComboBox CbGroup;
        private System.Windows.Forms.Label LlIp;
        private System.Windows.Forms.TextBox TbIp;
        private System.Windows.Forms.Label LlDomain;
        private System.Windows.Forms.TextBox TbDomain;
        private System.Windows.Forms.Label LlMemo;
        private System.Windows.Forms.TextBox TbMemo;
        private System.Windows.Forms.Label LlEnabled;
        private System.Windows.Forms.CheckBox CbEnabled;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtNo;
    }
}
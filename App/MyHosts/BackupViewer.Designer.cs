namespace Me.Amon.Hosts
{
    partial class BackupViewer
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
            this.ScBak = new System.Windows.Forms.SplitContainer();
            this.LbBak = new System.Windows.Forms.ListBox();
            this.TbBak = new System.Windows.Forms.TextBox();
            this.BtOk = new System.Windows.Forms.Button();
            this.BtNo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ScBak)).BeginInit();
            this.ScBak.Panel1.SuspendLayout();
            this.ScBak.Panel2.SuspendLayout();
            this.ScBak.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScBak
            // 
            this.ScBak.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScBak.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ScBak.Location = new System.Drawing.Point(12, 12);
            this.ScBak.Name = "ScBak";
            // 
            // ScBak.Panel1
            // 
            this.ScBak.Panel1.Controls.Add(this.LbBak);
            // 
            // ScBak.Panel2
            // 
            this.ScBak.Panel2.Controls.Add(this.TbBak);
            this.ScBak.Size = new System.Drawing.Size(500, 268);
            this.ScBak.SplitterDistance = 157;
            this.ScBak.TabIndex = 0;
            // 
            // LbBak
            // 
            this.LbBak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbBak.FormattingEnabled = true;
            this.LbBak.IntegralHeight = false;
            this.LbBak.ItemHeight = 12;
            this.LbBak.Location = new System.Drawing.Point(0, 0);
            this.LbBak.Name = "LbBak";
            this.LbBak.Size = new System.Drawing.Size(157, 268);
            this.LbBak.TabIndex = 0;
            this.LbBak.SelectedIndexChanged += new System.EventHandler(this.LbSln_SelectedIndexChanged);
            // 
            // TbBak
            // 
            this.TbBak.BackColor = System.Drawing.SystemColors.Window;
            this.TbBak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbBak.Location = new System.Drawing.Point(0, 0);
            this.TbBak.Multiline = true;
            this.TbBak.Name = "TbBak";
            this.TbBak.ReadOnly = true;
            this.TbBak.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TbBak.Size = new System.Drawing.Size(339, 268);
            this.TbBak.TabIndex = 0;
            this.TbBak.WordWrap = false;
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(356, 286);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 1;
            this.BtOk.Text = "恢复(&R)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // BtNo
            // 
            this.BtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtNo.Location = new System.Drawing.Point(437, 286);
            this.BtNo.Name = "BtNo";
            this.BtNo.Size = new System.Drawing.Size(75, 23);
            this.BtNo.TabIndex = 2;
            this.BtNo.Text = "关闭(&C)";
            this.BtNo.UseVisualStyleBackColor = true;
            this.BtNo.Click += new System.EventHandler(this.BtNo_Click);
            // 
            // BackupViewer
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtNo;
            this.ClientSize = new System.Drawing.Size(524, 321);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.ScBak);
            this.Name = "BackupViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "恢复";
            this.ScBak.Panel1.ResumeLayout(false);
            this.ScBak.Panel2.ResumeLayout(false);
            this.ScBak.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScBak)).EndInit();
            this.ScBak.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer ScBak;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtNo;
        private System.Windows.Forms.ListBox LbBak;
        private System.Windows.Forms.TextBox TbBak;
    }
}
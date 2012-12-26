namespace Me.Amon.Hosts
{
    partial class SolutionViewer
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
            this.ScSln = new System.Windows.Forms.SplitContainer();
            this.LbSln = new System.Windows.Forms.ListBox();
            this.TbSln = new System.Windows.Forms.TextBox();
            this.BtOk = new System.Windows.Forms.Button();
            this.BtNo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ScSln)).BeginInit();
            this.ScSln.Panel1.SuspendLayout();
            this.ScSln.Panel2.SuspendLayout();
            this.ScSln.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScSln
            // 
            this.ScSln.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScSln.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.ScSln.Location = new System.Drawing.Point(12, 12);
            this.ScSln.Name = "ScSln";
            // 
            // ScSln.Panel1
            // 
            this.ScSln.Panel1.Controls.Add(this.LbSln);
            // 
            // ScSln.Panel2
            // 
            this.ScSln.Panel2.Controls.Add(this.TbSln);
            this.ScSln.Size = new System.Drawing.Size(500, 268);
            this.ScSln.SplitterDistance = 157;
            this.ScSln.TabIndex = 0;
            // 
            // LbSln
            // 
            this.LbSln.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbSln.FormattingEnabled = true;
            this.LbSln.IntegralHeight = false;
            this.LbSln.ItemHeight = 12;
            this.LbSln.Location = new System.Drawing.Point(0, 0);
            this.LbSln.Name = "LbSln";
            this.LbSln.Size = new System.Drawing.Size(157, 268);
            this.LbSln.TabIndex = 0;
            this.LbSln.SelectedIndexChanged += new System.EventHandler(this.LbSln_SelectedIndexChanged);
            // 
            // TbSln
            // 
            this.TbSln.BackColor = System.Drawing.SystemColors.Window;
            this.TbSln.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbSln.Location = new System.Drawing.Point(0, 0);
            this.TbSln.Multiline = true;
            this.TbSln.Name = "TbSln";
            this.TbSln.ReadOnly = true;
            this.TbSln.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TbSln.Size = new System.Drawing.Size(339, 268);
            this.TbSln.TabIndex = 0;
            this.TbSln.WordWrap = false;
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
            // SolutionViewer
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtNo;
            this.ClientSize = new System.Drawing.Size(524, 321);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.ScSln);
            this.Name = "SolutionViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "方案";
            this.ScSln.Panel1.ResumeLayout(false);
            this.ScSln.Panel2.ResumeLayout(false);
            this.ScSln.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScSln)).EndInit();
            this.ScSln.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer ScSln;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtNo;
        private System.Windows.Forms.ListBox LbSln;
        private System.Windows.Forms.TextBox TbSln;
    }
}
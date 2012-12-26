namespace Me.Amon.Hosts
{
    partial class SolutionEditer
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
            this.TbGroup = new System.Windows.Forms.TextBox();
            this.BtOk = new System.Windows.Forms.Button();
            this.BtNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LlGroup
            // 
            this.LlGroup.AutoSize = true;
            this.LlGroup.Location = new System.Drawing.Point(12, 21);
            this.LlGroup.Name = "LlGroup";
            this.LlGroup.Size = new System.Drawing.Size(101, 12);
            this.LlGroup.TabIndex = 0;
            this.LlGroup.Text = "请输入分组名称：";
            // 
            // TbGroup
            // 
            this.TbGroup.Location = new System.Drawing.Point(12, 42);
            this.TbGroup.Name = "TbGroup";
            this.TbGroup.Size = new System.Drawing.Size(220, 21);
            this.TbGroup.TabIndex = 1;
            // 
            // BtOk
            // 
            this.BtOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtOk.Location = new System.Drawing.Point(76, 83);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 2;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // BtNo
            // 
            this.BtNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtNo.Location = new System.Drawing.Point(157, 83);
            this.BtNo.Name = "BtNo";
            this.BtNo.Size = new System.Drawing.Size(75, 23);
            this.BtNo.TabIndex = 3;
            this.BtNo.Text = "取消(&C)";
            this.BtNo.UseVisualStyleBackColor = true;
            this.BtNo.Click += new System.EventHandler(this.BtNo_Click);
            // 
            // SolutionEditer
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtNo;
            this.ClientSize = new System.Drawing.Size(244, 118);
            this.Controls.Add(this.BtNo);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.TbGroup);
            this.Controls.Add(this.LlGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SolutionEditer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "方案";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LlGroup;
        private System.Windows.Forms.TextBox TbGroup;
        private System.Windows.Forms.Button BtOk;
        private System.Windows.Forms.Button BtNo;
    }
}
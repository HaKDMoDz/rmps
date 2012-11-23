namespace Me.Amon.Pcs.V
{
    partial class MetaRef
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
            this.PbIcon = new System.Windows.Forms.PictureBox();
            this.LlNote = new System.Windows.Forms.Label();
            this.TbUri = new System.Windows.Forms.TextBox();
            this.BnCopy = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // PbIcon
            // 
            this.PbIcon.Location = new System.Drawing.Point(24, 38);
            this.PbIcon.Name = "PbIcon";
            this.PbIcon.Size = new System.Drawing.Size(32, 32);
            this.PbIcon.TabIndex = 0;
            this.PbIcon.TabStop = false;
            // 
            // LlNote
            // 
            this.LlNote.AutoSize = true;
            this.LlNote.Location = new System.Drawing.Point(62, 58);
            this.LlNote.Name = "LlNote";
            this.LlNote.Size = new System.Drawing.Size(41, 12);
            this.LlNote.TabIndex = 1;
            this.LlNote.Text = "label1";
            // 
            // TbUri
            // 
            this.TbUri.BackColor = System.Drawing.SystemColors.Window;
            this.TbUri.Location = new System.Drawing.Point(12, 87);
            this.TbUri.Multiline = true;
            this.TbUri.Name = "TbUri";
            this.TbUri.ReadOnly = true;
            this.TbUri.Size = new System.Drawing.Size(260, 134);
            this.TbUri.TabIndex = 2;
            // 
            // BnCopy
            // 
            this.BnCopy.Location = new System.Drawing.Point(116, 227);
            this.BnCopy.Name = "BnCopy";
            this.BnCopy.Size = new System.Drawing.Size(75, 23);
            this.BnCopy.TabIndex = 3;
            this.BnCopy.Text = "复制(&C)";
            this.BnCopy.UseVisualStyleBackColor = true;
            this.BnCopy.Click += new System.EventHandler(this.BnCopy_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(197, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "关闭(&C)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MetaRef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BnCopy);
            this.Controls.Add(this.TbUri);
            this.Controls.Add(this.LlNote);
            this.Controls.Add(this.PbIcon);
            this.Name = "MetaRef";
            this.Text = "MetaRef";
            ((System.ComponentModel.ISupportInitialize)(this.PbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbIcon;
        private System.Windows.Forms.Label LlNote;
        private System.Windows.Forms.TextBox TbUri;
        private System.Windows.Forms.Button BnCopy;
        private System.Windows.Forms.Button button2;
    }
}
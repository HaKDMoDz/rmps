namespace Me.Amon.Pcs.V.Cfg
{
    partial class PcsCreate
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
            this.PlStep = new System.Windows.Forms.Panel();
            this.BnPrev = new System.Windows.Forms.Button();
            this.BnNext = new System.Windows.Forms.Button();
            this.BnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlStep
            // 
            this.PlStep.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlStep.Location = new System.Drawing.Point(12, 12);
            this.PlStep.Name = "PlStep";
            this.PlStep.Size = new System.Drawing.Size(440, 269);
            this.PlStep.TabIndex = 0;
            // 
            // BnPrev
            // 
            this.BnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnPrev.Location = new System.Drawing.Point(215, 287);
            this.BnPrev.Name = "BnPrev";
            this.BnPrev.Size = new System.Drawing.Size(75, 23);
            this.BnPrev.TabIndex = 1;
            this.BnPrev.Text = "上一步(&P)";
            this.BnPrev.UseVisualStyleBackColor = true;
            this.BnPrev.Click += new System.EventHandler(this.BnPrev_Click);
            // 
            // BnNext
            // 
            this.BnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnNext.Location = new System.Drawing.Point(296, 287);
            this.BnNext.Name = "BnNext";
            this.BnNext.Size = new System.Drawing.Size(75, 23);
            this.BnNext.TabIndex = 2;
            this.BnNext.Text = "下一步(&N)";
            this.BnNext.UseVisualStyleBackColor = true;
            this.BnNext.Click += new System.EventHandler(this.BnNext_Click);
            // 
            // BnCancel
            // 
            this.BnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BnCancel.Location = new System.Drawing.Point(377, 287);
            this.BnCancel.Name = "BnCancel";
            this.BnCancel.Size = new System.Drawing.Size(75, 23);
            this.BnCancel.TabIndex = 3;
            this.BnCancel.Text = "取消(&C)";
            this.BnCancel.UseVisualStyleBackColor = true;
            this.BnCancel.Click += new System.EventHandler(this.BnCancel_Click);
            // 
            // PcsCreate
            // 
            this.AcceptButton = this.BnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BnCancel;
            this.ClientSize = new System.Drawing.Size(464, 322);
            this.Controls.Add(this.BnCancel);
            this.Controls.Add(this.BnNext);
            this.Controls.Add(this.BnPrev);
            this.Controls.Add(this.PlStep);
            this.Name = "PcsCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OAuthMgr";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlStep;
        private System.Windows.Forms.Button BnPrev;
        private System.Windows.Forms.Button BnNext;
        private System.Windows.Forms.Button BnCancel;
    }
}
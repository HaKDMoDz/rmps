namespace Me.Amon.Kms.Training
{
    partial class Training
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BtSend = new System.Windows.Forms.Button();
            this.TbText = new System.Windows.Forms.TextBox();
            this.PlNote = new System.Windows.Forms.Panel();
            this.PbNote = new System.Windows.Forms.PictureBox();
            this.TbNote = new System.Windows.Forms.TextBox();
            this.RbText = new System.Windows.Forms.RichTextBox();
            this.PlMisc = new System.Windows.Forms.Panel();
            this.TpPanel.SuspendLayout();
            this.PlNote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbNote)).BeginInit();
            this.SuspendLayout();
            // 
            // TpPanel
            // 
            this.TpPanel.ColumnCount = 2;
            this.TpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.TpPanel.Controls.Add(this.BtSend, 1, 3);
            this.TpPanel.Controls.Add(this.TbText, 0, 3);
            this.TpPanel.Controls.Add(this.PlNote, 0, 1);
            this.TpPanel.Controls.Add(this.RbText, 0, 0);
            this.TpPanel.Controls.Add(this.PlMisc, 0, 2);
            this.TpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TpPanel.Location = new System.Drawing.Point(0, 0);
            this.TpPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TpPanel.Name = "TpPanel";
            this.TpPanel.RowCount = 4;
            this.TpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.TpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.TpPanel.Size = new System.Drawing.Size(280, 260);
            this.TpPanel.TabIndex = 0;
            // 
            // BtSend
            // 
            this.BtSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtSend.Location = new System.Drawing.Point(223, 180);
            this.BtSend.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.BtSend.Name = "BtSend";
            this.BtSend.Size = new System.Drawing.Size(54, 77);
            this.BtSend.TabIndex = 1;
            this.BtSend.Text = "发送(&S)";
            this.BtSend.UseVisualStyleBackColor = true;
            this.BtSend.Click += new System.EventHandler(this.BtSend_Click);
            // 
            // TbText
            // 
            this.TbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbText.Location = new System.Drawing.Point(3, 180);
            this.TbText.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.TbText.Multiline = true;
            this.TbText.Name = "TbText";
            this.TbText.Size = new System.Drawing.Size(214, 77);
            this.TbText.TabIndex = 0;
            // 
            // PlNote
            // 
            this.PlNote.BackColor = System.Drawing.SystemColors.Info;
            this.TpPanel.SetColumnSpan(this.PlNote, 2);
            this.PlNote.Controls.Add(this.PbNote);
            this.PlNote.Controls.Add(this.TbNote);
            this.PlNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlNote.Location = new System.Drawing.Point(3, 135);
            this.PlNote.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.PlNote.Name = "PlNote";
            this.PlNote.Size = new System.Drawing.Size(274, 19);
            this.PlNote.TabIndex = 3;
            // 
            // PbNote
            // 
            this.PbNote.Location = new System.Drawing.Point(261, 2);
            this.PbNote.Margin = new System.Windows.Forms.Padding(0);
            this.PbNote.Name = "PbNote";
            this.PbNote.Size = new System.Drawing.Size(16, 16);
            this.PbNote.TabIndex = 1;
            this.PbNote.TabStop = false;
            // 
            // TbNote
            // 
            this.TbNote.BackColor = System.Drawing.SystemColors.Info;
            this.TbNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbNote.Location = new System.Drawing.Point(3, 3);
            this.TbNote.Name = "TbNote";
            this.TbNote.ReadOnly = true;
            this.TbNote.Size = new System.Drawing.Size(255, 14);
            this.TbNote.TabIndex = 0;
            // 
            // RbText
            // 
            this.RbText.BackColor = System.Drawing.SystemColors.Window;
            this.RbText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TpPanel.SetColumnSpan(this.RbText, 2);
            this.RbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RbText.Location = new System.Drawing.Point(3, 1);
            this.RbText.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.RbText.Name = "RbText";
            this.RbText.ReadOnly = true;
            this.RbText.Size = new System.Drawing.Size(274, 133);
            this.RbText.TabIndex = 2;
            this.RbText.Text = "";
            // 
            // PlMisc
            // 
            this.TpPanel.SetColumnSpan(this.PlMisc, 2);
            this.PlMisc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlMisc.Location = new System.Drawing.Point(3, 155);
            this.PlMisc.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.PlMisc.Name = "PlMisc";
            this.PlMisc.Size = new System.Drawing.Size(274, 24);
            this.PlMisc.TabIndex = 4;
            // 
            // Training
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TpPanel);
            this.Name = "Training";
            this.Size = new System.Drawing.Size(280, 260);
            this.TpPanel.ResumeLayout(false);
            this.TpPanel.PerformLayout();
            this.PlNote.ResumeLayout(false);
            this.PlNote.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbNote)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TpPanel;
        private System.Windows.Forms.Button BtSend;
        private System.Windows.Forms.TextBox TbText;
        private System.Windows.Forms.Panel PlNote;
        private System.Windows.Forms.RichTextBox RbText;
        private System.Windows.Forms.Panel PlMisc;
        private System.Windows.Forms.TextBox TbNote;
        private System.Windows.Forms.PictureBox PbNote;
    }
}

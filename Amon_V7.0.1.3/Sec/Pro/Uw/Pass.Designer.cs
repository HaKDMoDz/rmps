namespace Me.Amon.Sec.Pro.Uw
{
    partial class Pass
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pass));
            this.TbPass = new System.Windows.Forms.TextBox();
            this.BtOk = new System.Windows.Forms.Button();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // TbPass
            // 
            this.TbPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TbPass.Location = new System.Drawing.Point(12, 12);
            this.TbPass.Multiline = true;
            this.TbPass.Name = "TbPass";
            this.TbPass.ReadOnly = true;
            this.TbPass.Size = new System.Drawing.Size(128, 128);
            this.TbPass.TabIndex = 0;
            this.TbPass.TabStop = false;
            this.TbPass.MouseEnter += new System.EventHandler(this.TbPass_MouseEnter);
            this.TbPass.MouseLeave += new System.EventHandler(this.TbPass_MouseLeave);
            this.TbPass.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TbPass_MouseMove);
            // 
            // BtOk
            // 
            this.BtOk.Location = new System.Drawing.Point(65, 146);
            this.BtOk.Name = "BtOk";
            this.BtOk.Size = new System.Drawing.Size(75, 23);
            this.BtOk.TabIndex = 1;
            this.BtOk.Text = "确定(&O)";
            this.BtOk.UseVisualStyleBackColor = true;
            this.BtOk.Click += new System.EventHandler(this.BtOk_Click);
            // 
            // Worker
            // 
            this.Worker.WorkerSupportsCancellation = true;
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            // 
            // Pass
            // 
            this.AcceptButton = this.BtOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(152, 181);
            this.Controls.Add(this.BtOk);
            this.Controls.Add(this.TbPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pass";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "口令";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbPass;
        private System.Windows.Forms.Button BtOk;
        private System.ComponentModel.BackgroundWorker Worker;
    }
}
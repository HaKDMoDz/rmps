namespace Me.Amon.Sec
{
    partial class ASec
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ASec));
            this.LbInfo = new System.Windows.Forms.Label();
            this.BtDo = new System.Windows.Forms.Button();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.TpTips = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // LbInfo
            // 
            this.LbInfo.AutoSize = true;
            this.LbInfo.Location = new System.Drawing.Point(12, 275);
            this.LbInfo.Name = "LbInfo";
            this.LbInfo.Size = new System.Drawing.Size(0, 12);
            this.LbInfo.TabIndex = 7;
            // 
            // BtDo
            // 
            this.BtDo.Location = new System.Drawing.Point(423, 270);
            this.BtDo.Name = "BtDo";
            this.BtDo.Size = new System.Drawing.Size(75, 23);
            this.BtDo.TabIndex = 8;
            this.BtDo.Text = "执行(&R)";
            this.BtDo.UseVisualStyleBackColor = true;
            this.BtDo.Click += new System.EventHandler(this.BtDo_Click);
            // 
            // Worker
            // 
            this.Worker.WorkerSupportsCancellation = true;
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DoWork);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DoWorkerCompleted);
            // 
            // ASec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 305);
            this.Controls.Add(this.BtDo);
            this.Controls.Add(this.LbInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ASec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "阿木加密器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtDo;
        private System.Windows.Forms.Label LbInfo;
        private System.ComponentModel.BackgroundWorker Worker;
        private System.Windows.Forms.ToolTip TpTips;
    }
}
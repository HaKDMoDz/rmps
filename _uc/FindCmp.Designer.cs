namespace com.magickms._uc
{
    partial class FindCmp
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
            this.LbPos = new System.Windows.Forms.Label();
            this.LbCmp = new System.Windows.Forms.Label();
            this.PbApp = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbApp)).BeginInit();
            this.SuspendLayout();
            // 
            // LbPos
            // 
            this.LbPos.AutoSize = true;
            this.LbPos.Location = new System.Drawing.Point(38, 3);
            this.LbPos.Name = "LbPos";
            this.LbPos.Size = new System.Drawing.Size(0, 12);
            this.LbPos.TabIndex = 1;
            // 
            // LbCmp
            // 
            this.LbCmp.AutoSize = true;
            this.LbCmp.Location = new System.Drawing.Point(38, 20);
            this.LbCmp.Name = "LbCmp";
            this.LbCmp.Size = new System.Drawing.Size(0, 12);
            this.LbCmp.TabIndex = 2;
            // 
            // PbApp
            // 
            this.PbApp.Image = global::com.magickms.Properties.Resources._def;
            this.PbApp.Location = new System.Drawing.Point(0, 0);
            this.PbApp.Name = "PbApp";
            this.PbApp.Size = new System.Drawing.Size(32, 32);
            this.PbApp.TabIndex = 0;
            this.PbApp.TabStop = false;
            this.PbApp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PbApp_MouseMove);
            this.PbApp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PbApp_MouseDown);
            this.PbApp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PbApp_MouseUp);
            // 
            // FindCmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LbCmp);
            this.Controls.Add(this.LbPos);
            this.Controls.Add(this.PbApp);
            this.Name = "FindCmp";
            this.Size = new System.Drawing.Size(40, 32);
            ((System.ComponentModel.ISupportInitialize)(this.PbApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbApp;
        private System.Windows.Forms.Label LbPos;
        private System.Windows.Forms.Label LbCmp;
    }
}

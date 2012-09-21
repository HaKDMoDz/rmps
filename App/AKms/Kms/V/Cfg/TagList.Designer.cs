namespace Me.Amon.Kms.V.Cfg
{
    partial class TagList
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
            this.LsTags = new System.Windows.Forms.ListBox();
            this.PbDelete = new System.Windows.Forms.PictureBox();
            this.PbMerger = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbMerger)).BeginInit();
            this.SuspendLayout();
            // 
            // LsTags
            // 
            this.LsTags.FormattingEnabled = true;
            this.LsTags.ItemHeight = 12;
            this.LsTags.Location = new System.Drawing.Point(3, 3);
            this.LsTags.Name = "LsTags";
            this.LsTags.Size = new System.Drawing.Size(219, 160);
            this.LsTags.TabIndex = 0;
            // 
            // PbDelete
            // 
            this.PbDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbDelete.Image = global::Me.Amon.Properties.Resources._del;
            this.PbDelete.Location = new System.Drawing.Point(3, 168);
            this.PbDelete.Name = "PbDelete";
            this.PbDelete.Size = new System.Drawing.Size(16, 16);
            this.PbDelete.TabIndex = 1;
            this.PbDelete.TabStop = false;
            this.PbDelete.Click += new System.EventHandler(this.PbDelete_Click);
            // 
            // PbMerger
            // 
            this.PbMerger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbMerger.Enabled = false;
            this.PbMerger.Location = new System.Drawing.Point(25, 168);
            this.PbMerger.Name = "PbMerger";
            this.PbMerger.Size = new System.Drawing.Size(16, 16);
            this.PbMerger.TabIndex = 2;
            this.PbMerger.TabStop = false;
            // 
            // TagList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbMerger);
            this.Controls.Add(this.PbDelete);
            this.Controls.Add(this.LsTags);
            this.Name = "TagList";
            this.Size = new System.Drawing.Size(225, 187);
            ((System.ComponentModel.ISupportInitialize)(this.PbDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbMerger)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LsTags;
        private System.Windows.Forms.PictureBox PbDelete;
        private System.Windows.Forms.PictureBox PbMerger;
    }
}

namespace Me.Amon.Pwd._Cat
{
    partial class CatTree
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
            this.TvCat = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // TvCat
            // 
            this.TvCat.AllowDrop = true;
            this.TvCat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvCat.HideSelection = false;
            this.TvCat.Location = new System.Drawing.Point(0, 0);
            this.TvCat.Name = "TvCat";
            this.TvCat.Size = new System.Drawing.Size(150, 150);
            this.TvCat.TabIndex = 0;
            this.TvCat.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.TvCat_ItemDrag);
            this.TvCat.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvCat_AfterSelect);
            this.TvCat.DragDrop += new System.Windows.Forms.DragEventHandler(this.TvCat_DragDrop);
            this.TvCat.DragOver += new System.Windows.Forms.DragEventHandler(this.TvCat_DragOver);
            this.TvCat.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TvCat_MouseUp);
            // 
            // CatTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TvCat);
            this.Name = "CatTree";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TvCat;
    }
}

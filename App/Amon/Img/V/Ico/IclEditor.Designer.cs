namespace Me.Amon.Img.V.Ico
{
    partial class IclEditor
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
            this.components = new System.ComponentModel.Container();
            this.LvIcl = new System.Windows.Forms.ListView();
            this.IlIcl = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // LvIcl
            // 
            this.LvIcl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvIcl.LargeImageList = this.IlIcl;
            this.LvIcl.Location = new System.Drawing.Point(0, 0);
            this.LvIcl.Name = "LvIcl";
            this.LvIcl.Size = new System.Drawing.Size(150, 150);
            this.LvIcl.TabIndex = 0;
            this.LvIcl.UseCompatibleStateImageBehavior = false;
            // 
            // IlIcl
            // 
            this.IlIcl.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.IlIcl.ImageSize = new System.Drawing.Size(32, 32);
            this.IlIcl.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // IclEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LvIcl);
            this.Name = "IclEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LvIcl;
        private System.Windows.Forms.ImageList IlIcl;
    }
}

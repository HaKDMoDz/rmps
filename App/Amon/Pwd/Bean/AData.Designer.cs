namespace Me.Amon.Pwd.Bean
{
    partial class AData
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
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.可选输入OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.特殊符号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.可选输入OToolStripMenuItem,
            this.数据集ToolStripMenuItem,
            this.特殊符号ToolStripMenuItem});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(153, 92);
            // 
            // 可选输入OToolStripMenuItem
            // 
            this.可选输入OToolStripMenuItem.Name = "可选输入OToolStripMenuItem";
            this.可选输入OToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.可选输入OToolStripMenuItem.Text = "可选输入(&O)";
            // 
            // 数据集ToolStripMenuItem
            // 
            this.数据集ToolStripMenuItem.Name = "数据集ToolStripMenuItem";
            this.数据集ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.数据集ToolStripMenuItem.Text = "取值空间(&S)";
            // 
            // 特殊符号ToolStripMenuItem
            // 
            this.特殊符号ToolStripMenuItem.Name = "特殊符号ToolStripMenuItem";
            this.特殊符号ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.特殊符号ToolStripMenuItem.Text = "特殊符号(&C)";
            // 
            // AData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "AData";
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem 可选输入OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 特殊符号ToolStripMenuItem;
        protected System.Windows.Forms.ContextMenuStrip CmMenu;
    }
}

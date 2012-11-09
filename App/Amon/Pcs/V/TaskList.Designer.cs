namespace Me.Amon.Pcs.V
{
    partial class TaskList
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
            this.LvTask = new Me.Amon.Pcs.V.WListView();
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BwWork = new System.ComponentModel.BackgroundWorker();
            this.暂停ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.继续ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.优先处理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.延后处理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LvTask
            // 
            this.LvTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvTask.FullRowSelect = true;
            this.LvTask.Location = new System.Drawing.Point(0, 0);
            this.LvTask.Name = "LvTask";
            this.LvTask.OwnerDraw = true;
            this.LvTask.ProgressBackColor = System.Drawing.Color.Green;
            this.LvTask.ProgressColumnIndex = 0;
            this.LvTask.ProgressForeColor = System.Drawing.Color.Black;
            this.LvTask.Size = new System.Drawing.Size(150, 150);
            this.LvTask.TabIndex = 0;
            this.LvTask.UseCompatibleStateImageBehavior = false;
            this.LvTask.View = System.Windows.Forms.View.Details;
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.暂停ToolStripMenuItem,
            this.继续ToolStripMenuItem,
            this.取消ToolStripMenuItem,
            this.toolStripSeparator1,
            this.优先处理ToolStripMenuItem,
            this.延后处理ToolStripMenuItem});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(125, 120);
            // 
            // 暂停ToolStripMenuItem
            // 
            this.暂停ToolStripMenuItem.Name = "暂停ToolStripMenuItem";
            this.暂停ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.暂停ToolStripMenuItem.Text = "暂停";
            // 
            // 继续ToolStripMenuItem
            // 
            this.继续ToolStripMenuItem.Name = "继续ToolStripMenuItem";
            this.继续ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.继续ToolStripMenuItem.Text = "继续";
            // 
            // 取消ToolStripMenuItem
            // 
            this.取消ToolStripMenuItem.Name = "取消ToolStripMenuItem";
            this.取消ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.取消ToolStripMenuItem.Text = "取消";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // 优先处理ToolStripMenuItem
            // 
            this.优先处理ToolStripMenuItem.Name = "优先处理ToolStripMenuItem";
            this.优先处理ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.优先处理ToolStripMenuItem.Text = "优先处理";
            // 
            // 延后处理ToolStripMenuItem
            // 
            this.延后处理ToolStripMenuItem.Name = "延后处理ToolStripMenuItem";
            this.延后处理ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.延后处理ToolStripMenuItem.Text = "延后处理";
            // 
            // TaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LvTask);
            this.Name = "TaskList";
            this.CmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WListView LvTask;
        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.ComponentModel.BackgroundWorker BwWork;
        private System.Windows.Forms.ToolStripMenuItem 暂停ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 继续ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 优先处理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 延后处理ToolStripMenuItem;
    }
}

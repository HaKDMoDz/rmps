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
            this.CmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.暂停ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.继续ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.优先处理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.延后处理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ClName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClProgress = new System.Windows.Forms.DataGridViewImageColumn();
            this.ClManage = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CmMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClName,
            this.ClSize,
            this.ClStatus,
            this.ClProgress,
            this.ClManage});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(361, 132);
            this.dataGridView1.TabIndex = 0;
            // 
            // ClName
            // 
            this.ClName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClName.HeaderText = "文件";
            this.ClName.Name = "ClName";
            this.ClName.ReadOnly = true;
            // 
            // ClSize
            // 
            this.ClSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClSize.HeaderText = "大小";
            this.ClSize.Name = "ClSize";
            this.ClSize.ReadOnly = true;
            this.ClSize.Width = 80;
            // 
            // ClStatus
            // 
            this.ClStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClStatus.HeaderText = "状态";
            this.ClStatus.Name = "ClStatus";
            this.ClStatus.ReadOnly = true;
            this.ClStatus.Width = 80;
            // 
            // ClProgress
            // 
            this.ClProgress.HeaderText = "进度";
            this.ClProgress.Name = "ClProgress";
            this.ClProgress.ReadOnly = true;
            this.ClProgress.Width = 120;
            // 
            // ClManage
            // 
            this.ClManage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClManage.HeaderText = "操作";
            this.ClManage.Name = "ClManage";
            this.ClManage.ReadOnly = true;
            this.ClManage.Width = 60;
            // 
            // TaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "TaskList";
            this.Size = new System.Drawing.Size(361, 132);
            this.CmMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem 暂停ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 继续ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 优先处理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 延后处理ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClStatus;
        private System.Windows.Forms.DataGridViewImageColumn ClProgress;
        private System.Windows.Forms.DataGridViewButtonColumn ClManage;
    }
}

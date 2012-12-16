namespace Me.Amon.Pcs.V.Task
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
            this.MiSuspendCur = new System.Windows.Forms.ToolStripMenuItem();
            this.MiResumeCur = new System.Windows.Forms.ToolStripMenuItem();
            this.MiCancelCur = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep0 = new System.Windows.Forms.ToolStripSeparator();
            this.优先处理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.延后处理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MiSuspendAll = new System.Windows.Forms.ToolStripMenuItem();
            this.MiResumeAll = new System.Windows.Forms.ToolStripMenuItem();
            this.MiCancelAll = new System.Windows.Forms.ToolStripMenuItem();
            this.MiSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.MiClear = new System.Windows.Forms.ToolStripMenuItem();
            this.GvTask = new System.Windows.Forms.DataGridView();
            this.ClName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClProgress = new Me.Amon.Pcs.V.Task.DataGridViewProgressColumn();
            this.CmMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvTask)).BeginInit();
            this.SuspendLayout();
            // 
            // CmMenu
            // 
            this.CmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiSuspendCur,
            this.MiResumeCur,
            this.MiCancelCur,
            this.MiSep0,
            this.优先处理ToolStripMenuItem,
            this.延后处理ToolStripMenuItem,
            this.MiSep1,
            this.MiSuspendAll,
            this.MiResumeAll,
            this.MiCancelAll,
            this.MiSep2,
            this.MiClear});
            this.CmMenu.Name = "CmMenu";
            this.CmMenu.Size = new System.Drawing.Size(135, 220);
            // 
            // MiSuspendCur
            // 
            this.MiSuspendCur.Name = "MiSuspendCur";
            this.MiSuspendCur.Size = new System.Drawing.Size(134, 22);
            this.MiSuspendCur.Text = "暂停";
            // 
            // MiResumeCur
            // 
            this.MiResumeCur.Name = "MiResumeCur";
            this.MiResumeCur.Size = new System.Drawing.Size(134, 22);
            this.MiResumeCur.Text = "继续";
            // 
            // MiCancelCur
            // 
            this.MiCancelCur.Name = "MiCancelCur";
            this.MiCancelCur.Size = new System.Drawing.Size(134, 22);
            this.MiCancelCur.Text = "取消";
            // 
            // MiSep0
            // 
            this.MiSep0.Name = "MiSep0";
            this.MiSep0.Size = new System.Drawing.Size(131, 6);
            // 
            // 优先处理ToolStripMenuItem
            // 
            this.优先处理ToolStripMenuItem.Name = "优先处理ToolStripMenuItem";
            this.优先处理ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.优先处理ToolStripMenuItem.Text = "优先处理";
            // 
            // 延后处理ToolStripMenuItem
            // 
            this.延后处理ToolStripMenuItem.Name = "延后处理ToolStripMenuItem";
            this.延后处理ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.延后处理ToolStripMenuItem.Text = "延后处理";
            // 
            // MiSep1
            // 
            this.MiSep1.Name = "MiSep1";
            this.MiSep1.Size = new System.Drawing.Size(131, 6);
            // 
            // MiSuspendAll
            // 
            this.MiSuspendAll.Name = "MiSuspendAll";
            this.MiSuspendAll.Size = new System.Drawing.Size(134, 22);
            this.MiSuspendAll.Text = "暂停所有";
            // 
            // MiResumeAll
            // 
            this.MiResumeAll.Name = "MiResumeAll";
            this.MiResumeAll.Size = new System.Drawing.Size(134, 22);
            this.MiResumeAll.Text = "开始所有";
            // 
            // MiCancelAll
            // 
            this.MiCancelAll.Name = "MiCancelAll";
            this.MiCancelAll.Size = new System.Drawing.Size(134, 22);
            this.MiCancelAll.Text = "取消所有";
            // 
            // MiSep2
            // 
            this.MiSep2.Name = "MiSep2";
            this.MiSep2.Size = new System.Drawing.Size(131, 6);
            // 
            // MiClear
            // 
            this.MiClear.Name = "MiClear";
            this.MiClear.Size = new System.Drawing.Size(134, 22);
            this.MiClear.Text = "清除已完成";
            // 
            // GvTask
            // 
            this.GvTask.AllowUserToAddRows = false;
            this.GvTask.AllowUserToDeleteRows = false;
            this.GvTask.AllowUserToResizeColumns = false;
            this.GvTask.AllowUserToResizeRows = false;
            this.GvTask.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GvTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GvTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClName,
            this.ClSize,
            this.ClStatus,
            this.ClProgress});
            this.GvTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GvTask.Location = new System.Drawing.Point(0, 0);
            this.GvTask.MultiSelect = false;
            this.GvTask.Name = "GvTask";
            this.GvTask.ReadOnly = true;
            this.GvTask.RowHeadersVisible = false;
            this.GvTask.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GvTask.RowTemplate.Height = 23;
            this.GvTask.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GvTask.Size = new System.Drawing.Size(361, 132);
            this.GvTask.TabIndex = 0;
            this.GvTask.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvTask_CellContentClick);
            this.GvTask.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GvTask_MouseUp);
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
            this.ClProgress.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ClProgress.Width = 120;
            // 
            // TaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GvTask);
            this.Name = "TaskList";
            this.Size = new System.Drawing.Size(361, 132);
            this.CmMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GvTask)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip CmMenu;
        private System.Windows.Forms.ToolStripMenuItem MiSuspendCur;
        private System.Windows.Forms.ToolStripMenuItem MiResumeCur;
        private System.Windows.Forms.ToolStripMenuItem MiCancelCur;
        private System.Windows.Forms.ToolStripSeparator MiSep0;
        private System.Windows.Forms.ToolStripMenuItem 优先处理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 延后处理ToolStripMenuItem;
        private System.Windows.Forms.DataGridView GvTask;
        private System.Windows.Forms.ToolStripSeparator MiSep1;
        private System.Windows.Forms.ToolStripMenuItem MiSuspendAll;
        private System.Windows.Forms.ToolStripMenuItem MiResumeAll;
        private System.Windows.Forms.ToolStripMenuItem MiCancelAll;
        private System.Windows.Forms.ToolStripSeparator MiSep2;
        private System.Windows.Forms.ToolStripMenuItem MiClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClStatus;
        private Task.DataGridViewProgressColumn ClProgress;
    }
}

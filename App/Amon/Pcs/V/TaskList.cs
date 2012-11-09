using System.ComponentModel;
using System.Windows.Forms;
using Me.Amon.Open;
using Me.Amon.Pcs.C;
using System.Threading;
using System;

namespace Me.Amon.Pcs.V
{
    public partial class TaskList : UserControl
    {
        private int _MaxThreads = 1;
        private int _CurThreads = 0;

        private ListViewGroup _Doing;
        private ListViewGroup _Wait;
        private ListViewGroup _Done;
        private ListViewGroup _Error;

        private PcsClient _Client;
        private NddEngine _Engine;

        public TaskList()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
        }

        public void Init(PcsClient client, NddEngine engine)
        {
            _Client = client;
            _Engine = engine;

            _Wait = new ListViewGroup();
            _Wait.Header = "处理中";
            LvTask.Groups.Add(_Wait);

            _Done = new ListViewGroup();
            _Done.Header = "已完成";
            LvTask.Groups.Add(_Done);

            _Error = new ListViewGroup();
            _Error.Header = "异常";
            LvTask.Groups.Add(_Error);

            ColumnHeader name = new ColumnHeader();
            name.Text = "文件";
            LvTask.Columns.Add(name);

            ColumnHeader task = new ColumnHeader();
            task.Text = "任务";
            LvTask.Columns.Add(task);

            ColumnHeader size = new ColumnHeader();
            size.Text = "状态";
            LvTask.Columns.Add(size);

            ColumnHeader state = new ColumnHeader();
            state.Text = "进度";
            LvTask.Columns.Add(state);

            LvTask.ProgressColumnIndex = 3;
        }

        public void LoadTask()
        {
        }

        public void SaveTask()
        {
            //removetpath=status
        }

        #region 公共函数
        public bool IsBusy
        {
            get
            {
                return BwWork.IsBusy;
            }
        }

        public void AddTask(string path, bool upload)
        {
            var item = new ListViewItem();
            item.Text = path;
            item.Group = _Wait;

            var task = new ListViewItem.ListViewSubItem();
            task.Name = "task";
            task.Text = upload ? "上传" : "下载";
            item.SubItems.Add(task);

            var status = new ListViewItem.ListViewSubItem();
            status.Name = "status";
            status.Text = "等待中";
            item.SubItems.Add(status);

            var progress = new ListViewItem.ListViewSubItem();
            progress.Text = "";
            progress.Tag = 0d;
            item.SubItems.Add(progress);

            var thread = new TaskThread(this, _Client, _Engine);
            thread.Meta = path;
            thread.StatusItem = status;
            thread.ProgressItem = progress;
            item.Tag = thread;
            LvTask.Items.Add(item);
        }

        public void UpdateTask(TaskThread thread)
        {
            try
            {
                Monitor.Enter(this);
                if (thread.Status == TaskStatus.DONE)
                {
                    thread.TaskItem.Group = _Done;
                }
                _CurThreads -= 1;
            }
            finally
            {
                Monitor.Exit(this);
            }
        }

        public void StartAll()
        {
            BwWork.RunWorkerAsync();
        }

        public void SuspendAll()
        {
            BwWork.CancelAsync();

            TaskThread task;
            foreach (ListViewItem item in LvTask.Items)
            {
                task = item.Tag as TaskThread;
                if (task == null)
                {
                    continue;
                }
                if (task.IsAlive)
                {
                    task.Status = TaskStatus.SUSPEND;
                    task.StatusItem.Text = "处理中";
                }
            }
            _CurThreads = 0;
        }

        public void StopAll()
        {
            BwWork.CancelAsync();

            TaskThread task;
            foreach (ListViewItem item in LvTask.Items)
            {
                task = item.Tag as TaskThread;
                if (task == null)
                {
                    continue;
                }
                task.Status = TaskStatus.STOPED;
            }
            _CurThreads = 0;
        }
        #endregion

        private void Start(TaskThread thread)
        {
            long now = DateTime.Now.Ticks;

            long cs = _Engine.BeginDownload(now, thread.Meta, true);
            if (cs > -1)
            {
                long ts = _Client.BeginRead(now, thread.Meta, cs);
                if (ts > -1)
                {
                    if (cs >= ts)
                    {
                        thread.Status = TaskStatus.DONE;
                        thread.StatusItem.Text = "下载完成";
                        thread.ProgressItem.Tag = 1d;
                    }
                    else
                    {
                        // 10M = 1024*1024*10
                        if (ts < 100000)
                        {
                            thread.Start(now, cs, ts);
                            _CurThreads += 1;
                            return;
                        }
                        //string msg = "文件大小超过10M，下载时间会比较长，建议使用厂家客户端，确认要继续吗？";
                        string msg = string.Format("文件大小超过10M，为了不影响您的使用体验，建议使用原版客户端下载。{0}仍然要继续下载吗？", Environment.NewLine);
                        if (DialogResult.Yes == MessageBox.Show(null, msg, "提示", MessageBoxButtons.YesNoCancel))
                        {
                            thread.Start(now, cs, ts);
                            _CurThreads += 1;
                            return;
                        }

                        thread.Status = TaskStatus.NOTHING;
                        thread.StatusItem.Text = "不处理";
                        thread.ProgressItem.Tag = (double)cs / ts;
                    }
                }
                _Client.EndRead(now);
            }
            _Engine.EndDownload(now);
        }

        #region 事件处理
        private void BwWork_DoWork(object sender, DoWorkEventArgs e)
        {
            bool running = true;
            while (!BwWork.CancellationPending && running)
            {
                if (_CurThreads < _MaxThreads)
                {
                    int dos = 0;
                    TaskThread task;
                    foreach (ListViewItem item in LvTask.Items)
                    {
                        task = item.Tag as TaskThread;
                        if (task == null)
                        {
                            continue;
                        }
                        if (task.Status == TaskStatus.RUNNING)
                        {
                            dos += 1;
                        }
                        if (task.Status == TaskStatus.WAIT)
                        {
                            Start(task);
                            item.Group = _Doing;
                            dos += 1;
                        }

                        if (_CurThreads >= _MaxThreads)
                        {
                            break;
                        }
                    }
                    if (dos < 1)
                    {
                        break;
                    }
                }

                LvTask.Refresh();
                Thread.Sleep(100);
            }
        }

        private void LvTask_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        }

        private ListViewItem GetSelectedItem()
        {
            if (LvTask.SelectedItems.Count < 1)
            {
                return null;
            }
            return LvTask.SelectedItems[0];
        }

        private void MiSuspend_Click(object sender, System.EventArgs e)
        {
            var item = GetSelectedItem();
            if (item == null)
            {
                return;
            }
            var thread = item.Tag as TaskThread;
            if (thread == null)
            {
                return;
            }
            thread.Status = 1;
            thread.StatusItem.Text = "处理中";
        }

        private void MiContinue_Click(object sender, System.EventArgs e)
        {
            var item = GetSelectedItem();
            if (item == null)
            {
                return;
            }
            var thread = item.Tag as TaskThread;
            if (thread == null)
            {
                return;
            }
            thread.Status = 1;
            thread.StatusItem.Text = "等待中";
        }

        private void MiCancel_Click(object sender, System.EventArgs e)
        {
            var item = GetSelectedItem();
            if (item == null)
            {
                return;
            }
            var thread = item.Tag as TaskThread;
            if (thread == null)
            {
                return;
            }
            thread.Status = 1;
            thread.StatusItem.Text = "处理中";
        }

        private void 优先处理ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void 延后处理ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }
        #endregion
    }
}

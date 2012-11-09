using System.Threading;
using System.Windows.Forms;
using Me.Amon.Open;
using Me.Amon.Pcs.C;

namespace Me.Amon.Pcs.V
{
    public class TaskThread
    {
        /// <summary>
        /// 操作的文件
        /// </summary>
        public string Meta { get; set; }
        public bool Upload { get; set; }
        /// <summary>
        /// 操作状态
        /// </summary>
        public int Status { get; set; }
        public bool IsAlive { get; private set; }
        private long _Key;
        private long _LocalSize;
        private long _TotalSize;

        private TaskList _TaskView;
        private PcsClient _Client;
        private NddEngine _Engine;

        public TaskThread(TaskList taskView, PcsClient client, NddEngine engine)
        {
            _TaskView = taskView;
            _Client = client;
            _Engine = engine;
        }

        public ListViewItem TaskItem { get; set; }

        public ListViewItem.ListViewSubItem StatusItem { get; set; }

        public ListViewItem.ListViewSubItem ProgressItem { get; set; }

        public void Start(long key, long localSize, long totalSize)
        {
            _Key = key;
            _LocalSize = localSize;
            _TotalSize = totalSize;

            IsAlive = true;
            Status = TaskStatus.RUNNING;
            new Thread(DoWork).Start();
        }

        public void DoWork()
        {
            int count;
            byte[] buffer = new byte[10240];
            while (Status == TaskStatus.RUNNING)
            {
                count = _Client.Read(_Key, buffer, 0, buffer.Length);
                if (count < 1)
                {
                    StatusItem.Text = "下载完成";
                    ProgressItem.Tag = 1d;
                    _Client.EndRead(_Key);
                    _Engine.EndDownload(_Key);
                    _TaskView.UpdateTask(this);
                    return;
                }
                _Engine.Write(_Key, buffer, 0, count);
                _LocalSize += count;
                ProgressItem.Tag = (double)_LocalSize / _TotalSize;
            }

            _Client.EndRead(_Key);
            _Engine.EndDownload(_Key);
            _TaskView.UpdateTask(this);
            // 用户暂停
            IsAlive = false;
        }

        /// <summary>
        /// 暂停
        /// </summary>
        public void Suspend()
        {
        }

        /// <summary>
        /// 继续
        /// </summary>
        public void Restart()
        {
        }

        /// <summary>
        /// 取消
        /// </summary>
        public void Cancel()
        {
        }
    }
}

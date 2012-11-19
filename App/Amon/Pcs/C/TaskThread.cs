using System;
using System.Threading;
using Me.Amon.Open;

namespace Me.Amon.Pcs.C
{
    public class TaskThread
    {
        /// <summary>
        /// 操作的文件
        /// </summary>
        public string Meta { get; set; }
        public bool Upload { get; set; }
        public double Progress { get; private set; }
        /// <summary>
        /// 操作状态
        /// </summary>
        public int Status { get; set; }
        public string Message { get; private set; }
        public bool IsAlive { get; private set; }

        private PcsClient _Client;
        private NddEngine _Engine;
        private string _RemoteMeta;
        private string _LocalFile;

        public TaskThread(PcsClient client, NddEngine engine)
        {
            _Client = client;
            _Engine = engine;
        }

        public void Init(string remoteMeta, string localFile)
        {
            _RemoteMeta = remoteMeta;
            _LocalFile = localFile;
        }

        public void Start()
        {
            IsAlive = true;
            Status = TaskStatus.RUNNING;
            new Thread(DoWork).Start();
        }

        public void DoWork()
        {
            long now = DateTime.Now.Ticks;

            long cs = _Engine.BeginDownload(now, Meta, true);
            if (cs > -1)
            {
                long ts = _Client.BeginRead(now, Meta, cs);
                if (ts > -1)
                {
                    if (cs < ts)
                    {
                        int count;
                        byte[] buffer = new byte[10240];
                        while (Status == TaskStatus.RUNNING)
                        {
                            count = _Client.Read(now, buffer, 0, buffer.Length);
                            if (count < 1)
                            {
                                break;
                            }
                            _Engine.Write(now, buffer, 0, count);
                            cs += count;
                            Progress = (double)cs / ts;
                        }
                    }
                    Status = TaskStatus.DONE;
                    Message = "下载完成";
                    Progress = 1d;
                }
                _Client.EndRead(now);
            }

            _Engine.EndDownload(now);
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

using System;
using System.Threading;
using Me.Amon.Open;

namespace Me.Amon.Pcs.C
{
    public class TaskThread
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string MetaName { get; private set; }
        /// <summary>
        /// 当前进度
        /// </summary>
        public double Progress { get; private set; }
        /// <summary>
        /// 操作状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 状态信息
        /// </summary>
        public string Message { get; private set; }
        public bool IsAlive { get; private set; }

        private PcsClient _Client;
        private NddEngine _Engine;
        private string _RemoteMeta;
        private string _LocalFile;
        public bool _Upload;

        public TaskThread(PcsClient client, NddEngine engine)
        {
            _Client = client;
            _Engine = engine;
        }

        public void Init(string remoteMeta, string localFile, bool upload)
        {
            _RemoteMeta = remoteMeta;
            _LocalFile = localFile;
            _Upload = upload;

            Status = TaskStatus.WAIT;
            Message = "等待中";
            MetaName = System.IO.Path.GetFileName(remoteMeta);
        }

        public void Start()
        {
            IsAlive = true;
            Status = TaskStatus.RUNNING;
            if (_Upload)
            {
                new Thread(DoUploadA).Start();
            }
            else
            {
                new Thread(Download).Start();
            }
        }

        private void DoUploadA()
        {
            IsAlive = true;
            Message = "上传中";
            long now = DateTime.Now.Ticks;

            if (_Client.BeginUpload(now, _RemoteMeta))
            {
                long ts = _Engine.BeginUpload(now, _LocalFile);
                if (ts > -1)
                {
                    Progress = 0.2;

                    int count;
                    byte[] buffer = new byte[10240];
                    while (Status == TaskStatus.RUNNING)
                    {
                        count = _Engine.Read(now, buffer, 0, buffer.Length);
                        if (count < 1)
                        {
                            break;
                        }
                        _Client.Write(now, buffer, 0, count);
                    }

                    Progress = 0.6;
                }
                _Engine.EndUpload(now);

                Status = TaskStatus.DONE;
                Progress = 1d;
                Message = "上传完成";
            }
            _Client.EndUpload(now);

            // 用户暂停
            IsAlive = false;
        }

        private void DoUploadB()
        {
            IsAlive = true;
            Message = "上传中";
            long now = DateTime.Now.Ticks;

            if (_Client.BeginUpload(now, _RemoteMeta))
            {
                long ts = _Engine.BeginUpload(now, _LocalFile);
                if (ts > -1)
                {
                    double cs = 0;

                    int count;
                    byte[] buffer = new byte[10240];
                    while (Status == TaskStatus.RUNNING)
                    {
                        count = _Engine.Read(now, buffer, 0, buffer.Length);
                        if (count < 1)
                        {
                            break;
                        }
                        _Client.Write(now, buffer, 0, count);
                        cs += count;
                        Progress = cs / ts;
                    }

                    Status = TaskStatus.DONE;
                    Progress = 1d;
                    Message = "上传完成";
                }
                _Engine.EndUpload(now);
            }
            _Client.EndUpload(now);

            // 用户暂停
            IsAlive = false;
        }

        private void Download()
        {
            long now = DateTime.Now.Ticks;

            long cs = _Engine.BeginDownload(now, _LocalFile, true);
            if (cs > -1)
            {
                long ts = _Client.BeginDownload(now, _RemoteMeta, cs);
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
                }
                Status = TaskStatus.DONE;
                Message = "下载完成";
                Progress = 1d;
                _Client.EndDownload(now);
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

using Me.Amon.Pcs.C;
using System.IO;
using System.Threading;

namespace Me.Amon.Http
{
    public class TaskInfo
    {
        public string Server { get; set; }
        public string UserId { get; set; }
        /// <summary>
        /// 本地引擎
        /// </summary>
        public NddEngine Engine { get; set; }
        public string Root { get; set; }
        public string Path { get; set; }
        /// <summary>
        /// 资源路径
        /// </summary>
        public string Meta { get; set; }
        public string MetaName { get; set; }
        public long MetaSize { get; set; }
        /// <summary>
        /// 本地路径
        /// </summary>
        public string File { get; set; }
        public string FileName { get; set; }
        public Stream FileStream { get; set; }
        public long FileSize { get; set; }
        /// <summary>
        /// 是否续传
        /// </summary>
        public bool IsAppend { get; set; }
        /// <summary>
        /// 进度百分比
        /// </summary>
        public double Percent { get; protected set; }
        /// <summary>
        /// 异常信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 操作状态
        /// </summary>
        public int Status { get; set; }
        public bool IsAlive { get; protected set; }

        #region 线程控制
        public void Start()
        {
            new Thread(Run).Start();
        }
        /// <summary>
        /// 暂停
        /// </summary>
        public void Suspend()
        {
            Status = TaskStatus.SUSPEND;
        }

        /// <summary>
        /// 取消
        /// </summary>
        public void Cancel()
        {
        }
        #endregion

        #region 序列化
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public bool FromTxt(string txt)
        {
            return true;
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <returns></returns>
        public string ToTxt()
        {
            return "";
        }
        #endregion

        public virtual void Run() { }

        protected void DoUpload()
        {
            //IsAlive = true;
            //Message = "上传中";

            //long ts = 0;//todo
            //if (ts > -1)
            //{
            //    double cs = 0;

            //    int count;
            //    byte[] buffer = new byte[10240];
            //    while (Status == TaskStatus.RUNNING)
            //    {
            //        count = MetaStream.Read(buffer, 0, buffer.Length);
            //        if (count < 1)
            //        {
            //            break;
            //        }
            //        FileStream.Write(buffer, 0, count);
            //        cs += count;
            //        Percent = cs / ts;
            //    }

            //    Status = TaskStatus.DONE;
            //    Percent = 1d;
            //    Message = "上传完成";
            //}
        }
    }
}

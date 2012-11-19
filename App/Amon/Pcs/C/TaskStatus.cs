namespace Me.Amon.Pcs.C
{
    public class TaskStatus
    {
        /// <summary>
        /// 异常
        /// </summary>
        public const int ERROR = -1;
        /// <summary>
        /// 等待
        /// </summary>
        public const int WAIT = 0;
        /// <summary>
        /// 进行中
        /// </summary>
        public const int RUNNING = 1;
        /// <summary>
        /// 暂停中
        /// </summary>
        public const int SUSPEND = 2;
        /// <summary>
        /// 完成
        /// </summary>
        public const int DONE = 3;
        /// <summary>
        /// 不处理
        /// </summary>
        public const int NOTHING = 4;
        public const int STOPED = 5;
    }
}

using Me.Amon.Model;

namespace Me.Amon.Gtd
{
    public class MGtdDetail : Vcs
    {
        public int Order { get; set; }
        /// <summary>
        /// 计划索引
        /// </summary>
        public string GtdId { get; set; }
        /// <summary>
        /// 指定时间
        /// </summary>
        public long Time { get; set; }
        /// <summary>
        /// 间隔单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 间隔时间
        /// </summary>
        public int Interval { get; set; }
        /// <summary>
        /// 表达式
        /// </summary>
        public string Express { get; set; }
    }
}

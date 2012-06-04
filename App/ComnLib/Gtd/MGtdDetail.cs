using Me.Amon.Model;

namespace Me.Amon.Gtd
{
    public class MGtdDetail : Vcs
    {
        public int P30F0401 { get; set; }
        /// <summary>
        /// 计划索引
        /// </summary>
        public string P30F0402 { get; set; }
        /// <summary>
        /// 指定时间
        /// </summary>
        public long P30F0403 { get; set; }
        /// <summary>
        /// 间隔单位
        /// </summary>
        public int P30F0404 { get; set; }
        /// <summary>
        /// 间隔时间
        /// </summary>
        public int P30F0405 { get; set; }
        /// <summary>
        /// 表达式
        /// </summary>
        public string P30F0406 { get; set; }
    }
}

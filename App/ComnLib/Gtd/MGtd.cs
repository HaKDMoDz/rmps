using System.Collections.Generic;
using Me.Amon.Model;

namespace Me.Amon.Gtd
{
    /// <summary>
    /// 数据模型
    /// </summary>
    public class MGtd : Vcs
    {
        /// <summary>
        /// 显示排序
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// 任务类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 任务状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 任务级别
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// 提醒周期
        /// </summary>
        public int Cycle { get; set; }
        /// <summary>
        /// 提示方式
        /// </summary>
        public int Way { get; set; }
        /// <summary>
        /// 可否共用
        /// </summary>
        public int Share { get; set; }
        /// <summary>
        /// 完成度
        /// </summary>
        public int Percent { get; set; }
        /// <summary>
        /// 上级任务
        /// </summary>
        public string Parent { get; set; }
        /// <summary>
        /// 前置任务
        /// </summary>
        public string Prepose { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        public long? Start { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public long? End { get; set; }
        /// <summary>
        /// 执行时间
        /// </summary>
        public long? Execute { get; set; }
        /// <summary>
        /// 执行参数
        /// </summary>
        public string Params { get; set; }
        /// <summary>
        /// 附加参数
        /// </summary>
        public string Args { get; set; }
        /// <summary>
        /// 是否提前
        /// </summary>
        public int? Postpone { get; set; }
        /// <summary>
        /// 提前间隔
        /// </summary>
        public int P30F0313 { get; set; }
        /// <summary>
        /// 相关说明
        /// </summary>
        public string P30F0314 { get; set; }
        /// <summary>s
        /// 提示列表
        /// </summary>
        public List<MGtdDetail> Details { get; private set; }

        public MGtd()
        {
            Details = new List<MGtdDetail>();
        }
    }
}

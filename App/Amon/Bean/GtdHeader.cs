using System.Collections.Generic;

namespace Me.Amon.Bean
{
    public class GtdHeader : Vcs
    {
        /// <summary>
        /// 显示排序
        /// </summary>
        public int P30F0301 { get; set; }
        /// <summary>
        /// 任务类型
        /// </summary>
        public int P30F0302 { get; set; }
        /// <summary>
        /// 任务状态
        /// </summary>
        public int P30F0303 { get; set; }
        /// <summary>
        /// 任务级别
        /// </summary>
        public int P30F0304 { get; set; }
        /// <summary>
        /// 提醒周期
        /// </summary>
        public int P30F0305 { get; set; }
        /// <summary>
        /// 提示方式
        /// </summary>
        public int P30F0306 { get; set; }
        /// <summary>
        /// 可否共用
        /// </summary>
        public int P30F0307 { get; set; }
        /// <summary>
        /// 完成度
        /// </summary>
        public int P30F0308 { get; set; }
        /// <summary>
        /// 任务索引
        /// </summary>
        public string P30F0309 { get; set; }
        /// <summary>
        /// 上级任务
        /// </summary>
        public string P30F030A { get; set; }
        /// <summary>
        /// 前置任务
        /// </summary>
        public string P30F030B { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        public string P30F030C { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        public long? P30F030D { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public long? P30F030E { get; set; }
        /// <summary>
        /// 执行时间
        /// </summary>
        public long? P30F030F { get; set; }
        /// <summary>
        /// 执行参数
        /// </summary>
        public string P30F0310 { get; set; }
        /// <summary>
        /// 附加参数
        /// </summary>
        public string P30F0311 { get; set; }
        /// <summary>
        /// 是否提前
        /// </summary>
        public int? P30F0312 { get; set; }
        /// <summary>
        /// 提前间隔
        /// </summary>
        public int? P30F0313 { get; set; }
        /// <summary>
        /// 相关说明
        /// </summary>
        public string P30F0314 { get; set; }
        /// <summary>s
        /// 提示列表
        /// </summary>
        public List<GtdDetail> HintList { get; set; }
    }
}

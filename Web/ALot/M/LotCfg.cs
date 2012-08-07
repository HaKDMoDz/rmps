
namespace Me.Amon.Lot.M
{
    /// <summary>
    /// 配置信息
    /// </summary>
    public class LotCfg
    {
        /// <summary>
        /// 可重复使用
        /// </summary>
        public bool Resualbe { get; set; }

        /// <summary>
        /// 主要轮次
        /// </summary>
        public int MajorRound { get; set; }

        /// <summary>
        /// 次要轮次
        /// </summary>
        public int MinorRound { get; set; }

        /// <summary>
        /// 行量
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// 列量
        /// </summary>
        public int ColCount { get; set; }

        /// <summary>
        /// 单次中标数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 显示速度
        /// </summary>
        public int Speed { get; set; }
    }
}

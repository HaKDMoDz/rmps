
namespace Me.Amon.Lot.M
{
    public class Item
    {
        /// <summary>
        /// 系统索引
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 标的索引
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 标的名称
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 标的权重
        /// </summary>
        public int Weight { get; set; }

        public string Exclude { get; set; }
        public string Include { get; set; }
    }
}

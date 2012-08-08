using System.Collections.Generic;

namespace Me.Amon.Lot.M
{
    public class Round
    {
        public string Id { get; set; }
        /// <summary>
        /// 显示排序
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 中的数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 必中对象
        /// </summary>
        public Dictionary<string, int> Includes;
        /// <summary>
        /// 不中对象
        /// </summary>
        public Dictionary<string, int> Excludes;
    }

}

using System.Collections.Generic;

namespace Me.Amon.Lot.M
{
    public class Node
    {
        /// <summary>
        /// 轮次
        /// </summary>
        public List<Round> Rounds { get; set; }

        /// <summary>
        /// 值域
        /// </summary>
        public List<Item> Items { get; set; }
    }
}

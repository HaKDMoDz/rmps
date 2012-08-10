using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace Me.Amon.Lot.M
{
    public class Round
    {
        public string Id { get; private set; }
        /// <summary>
        /// 显示排序
        /// </summary>
        public int Order { get; private set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string Title { get; private set; }

        public int RowCount { get; private set; }

        public int ColCount { get; private set; }
        /// <summary>
        /// 中的数量
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// 必中对象
        /// </summary>
        public List<Item> Includes { get; set; }
        /// <summary>
        /// 不中对象
        /// </summary>
        public List<Item> Excludes { get; set; }

        public bool FromXml(XmlReader reader)
        {
            if (reader.Name != "Round")
            {
                return false;
            }

            string tmp = reader.GetAttribute("RowCount");
            if (tmp != null && Regex.IsMatch(tmp, @"^[1-9]$"))
            {
                RowCount = int.Parse(tmp);
            }
            tmp = reader.GetAttribute("ColCount");
            if (tmp != null && Regex.IsMatch(tmp, @"^[1-9]$"))
            {
                ColCount = int.Parse(tmp);
            }
            tmp = reader.GetAttribute("Count");
            if (tmp != null && Regex.IsMatch(tmp, @"^[1-9]$"))
            {
                Count = int.Parse(tmp);
            }
            Title = reader.ReadElementContentAsString();
            return true;
        }
    }
}

using System.Text.RegularExpressions;
using System.Xml;

namespace Me.Amon.Lot.M
{
    public class Item
    {
        /// <summary>
        /// 系统索引
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// 标的索引
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// 标的名称
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// 标的权重
        /// </summary>
        public int Weight { get; private set; }

        public string Excludes { get; private set; }
        public string Includes { get; private set; }

        public int Index { get; set; }

        public bool FromXml(XmlReader reader)
        {
            if (reader.Name != "Item")
            {
                return false;
            }

            Key = reader.GetAttribute("Key");
            string tmp = reader.GetAttribute("Weight");
            if (tmp != null && Regex.IsMatch(tmp, @"^(\d+(.\d+)?|(\d+.)?\d+)$"))
            {
                Weight = int.Parse(tmp);
            }
            Excludes = reader.GetAttribute("Excludes");
            Includes = reader.GetAttribute("Includes");
            Value = reader.ReadElementContentAsString();
            return true;
        }
    }
}

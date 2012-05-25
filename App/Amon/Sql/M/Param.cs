using System.Collections.Generic;
using System.Xml;
using Me.Amon.Uc;

namespace Me.Amon.Sql.Model
{
    public class Param
    {
        /// <summary>
        /// 替换参数，系统将会置换模板中形式为#key#的内容
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 参数类型，目前支持如下：
        /// text:文本
        /// date:日期
        /// data:数值
        /// list:列表
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 参数提示信息
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 裁剪字符，当这些字符出现在首位或末位时将被忽略
        /// </summary>
        public string Trim { get; set; }

        /// <summary>
        /// 参数默认显示内容
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 输入内容为空时的提示信息
        /// </summary>
        public string Empty { get; set; }

        /// <summary>
        /// 数据输入格式
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// 输入数据不满足指定格式时的提示信息
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// 转换字符，在模糊查询时被忽略
        /// </summary>
        public string Escape { get; set; }

        /// <summary>
        /// 多组数据时，数据项分隔符
        /// </summary>
        public string Separator { get; set; }

        public List<Item> Items { get; set; }

        public void Load(XmlNode node)
        {
            if (node == null)
            {
                return;
            }

            Key = Dml.Attribute(node, "Key", "");
            Type = Dml.Attribute(node, "Type", "");
            Text = Dml.Attribute(node, "Text", "");
            Trim = Dml.Attribute(node, "Trim", "");
            Value = Dml.Attribute(node, "Value", "");
            Empty = Dml.Attribute(node, "Empty", "");
            Format = Dml.Attribute(node, "Format", "");
            Error = Dml.Attribute(node, "Error", "");
            Escape = Dml.Attribute(node, "Escape", "");
            Separator = Dml.Attribute(node, "Separator", "");

            if (Type == "list")
            {
                if (Items == null)
                {
                    Items = new List<Item>();
                }
                else
                {
                    Items.Clear();
                }

                Item item;
                foreach (XmlNode temp in node.SelectNodes("Item"))
                {
                    item = new Item();
                    item.K = Dml.Attribute(temp, "Data", "");
                    item.V = Dml.Attribute(temp, "Text", "");
                    Items.Add(item);
                }
            }
        }

        public void Save(XmlNode node)
        {
        }
    }
}

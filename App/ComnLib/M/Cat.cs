using System.Xml;

namespace Me.Amon.M
{
    public class Cat : Vcs
    {
        public int Order { get; set; }
        /// <summary>
        /// 上级索引
        /// </summary>
        public string Parent { get; set; }
        /// <summary>
        /// 是否叶子
        /// </summary>
        public bool IsLeaf { get; set; }
        /// <summary>
        /// 类别图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 类别提示
        /// </summary>
        public string Tips { get; set; }
        /// <summary>
        /// 类别键值
        /// </summary>
        public string Meta { get; set; }
        /// <summary>
        /// 类别说明
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 应用代码
        /// </summary>
        public string AppId { get; set; }

        #region 方法重写
        public override string ToString()
        {
            return Text;
        }
        #endregion

        public bool FromXml(XmlReader reader)
        {
            if (reader == null || reader.Name != "Cat" || !reader.IsStartElement())
            {
                return false;
            }

            if (reader.Name == "Order" || reader.ReadToDescendant("Order"))
            {
                Order = reader.ReadElementContentAsInt();
            }
            if (reader.Name == "Id" || reader.ReadToNextSibling("Id"))
            {
                Id = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Parent" || reader.ReadToNextSibling("Parent"))
            {
                Parent = reader.ReadElementContentAsString();
            }
            if (reader.Name == "IsLeaf" || reader.ReadToNextSibling("IsLeaf"))
            {
                IsLeaf = bool.Parse(reader.ReadElementContentAsString());
            }
            if (reader.Name == "Text" || reader.ReadToNextSibling("Text"))
            {
                Text = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Tips" || reader.ReadToNextSibling("Tips"))
            {
                Tips = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Icon" || reader.ReadToNextSibling("Icon"))
            {
                Icon = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Meta" || reader.ReadToNextSibling("Meta"))
            {
                Meta = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Memo" || reader.ReadToNextSibling("Memo"))
            {
                Memo = reader.ReadElementContentAsString();
            }
            if (reader.Name == "AppId" || reader.ReadToNextSibling("AppId"))
            {
                AppId = reader.ReadElementContentAsString();
            }

            if (reader.Name == "Cat" && reader.NodeType == XmlNodeType.EndElement)
            {
                reader.ReadEndElement();
            }
            return true;
        }

        public void ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Cat");

            writer.WriteElementString("Order", Order.ToString());
            writer.WriteElementString("Id", Id);
            writer.WriteElementString("Parent", Parent);
            writer.WriteElementString("IsLeaf", IsLeaf ? "true" : "false");
            writer.WriteElementString("Text", Text);
            writer.WriteElementString("Tips", Tips);
            writer.WriteElementString("Icon", Icon);
            writer.WriteElementString("Meta", Meta);
            writer.WriteElementString("Memo", Memo);
            writer.WriteElementString("AppId", AppId);

            writer.WriteEndElement();
        }
    }
}

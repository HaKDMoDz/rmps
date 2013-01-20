using System.Xml;
using Me.Amon.M;

namespace Me.Amon.Pwd.M
{
    public class LibDetail : Vcs
    {
        /// <summary>
        /// 显示排序
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// 属性类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Header { get; set; }

        public string Name { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 默认数据
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 相关说明
        /// </summary>
        public string Memo { get; set; }

        public override bool FromXml(XmlReader reader)
        {
            if (reader == null || reader.Name != "Item")
            {
                return false;
            }
            reader.ReadStartElement();

            if (reader.Name == "Order" || reader.ReadToNextSibling("Order"))
            {
                Order = reader.ReadElementContentAsInt();
            }
            if (reader.Name == "Id" || reader.ReadToNextSibling("Id"))
            {
                Id = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Type" || reader.ReadToNextSibling("Type"))
            {
                Type = reader.ReadElementContentAsInt();
            }
            if (reader.Name == "Name" || reader.ReadToNextSibling("Name"))
            {
                Name = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Text" || reader.ReadToNextSibling("Text"))
            {
                Text = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Data" || reader.ReadToNextSibling("Data"))
            {
                Data = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Memo" || reader.ReadToNextSibling("Memo"))
            {
                Memo = reader.ReadElementContentAsString();
            }

            reader.ReadEndElement();
            return true;
        }

        public override bool ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Item");

            writer.WriteElementString("Id", Id);
            writer.WriteElementString("Type", Type.ToString());
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Text", Text);
            writer.WriteElementString("Data", Data);
            writer.WriteElementString("Memo", Memo);

            writer.WriteEndElement();

            return true;
        }
    }
}

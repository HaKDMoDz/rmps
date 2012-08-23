using System.Xml;
using Me.Amon.M;

namespace Me.Amon.Ren
{
    /// <summary>
    /// 数据模型
    /// </summary>
    public class MRen : Vcs
    {
        /// <summary>
        /// 显示排序
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// 模板名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 模板内容
        /// </summary>
        public string Command { get; set; }
        /// <summary>
        /// 相关说明
        /// </summary>
        public string Remark { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public bool FromXml(XmlReader reader)
        {
            if (reader == null || reader.Name != "Ren" || !reader.IsStartElement())
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
            if (reader.Name == "Name" || reader.ReadToNextSibling("Name"))
            {
                Name = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Command" || reader.ReadToNextSibling("Command"))
            {
                Command = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Remark" || reader.ReadToNextSibling("Remark"))
            {
                Remark = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Ren" && reader.NodeType == XmlNodeType.EndElement)
            {
                reader.ReadEndElement();
            }
            return true;
        }

        public void ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Ren");

            writer.WriteElementString("Order", Order.ToString());
            writer.WriteElementString("Id", Id);
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Command", Command);
            writer.WriteElementString("Remark", Remark);

            writer.WriteEndElement();
        }
    }
}

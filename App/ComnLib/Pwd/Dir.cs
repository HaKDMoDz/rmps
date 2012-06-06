using System.Xml;
using Me.Amon.Model;

namespace Me.Amon.Pwd
{
    public class Dir : Vcs
    {
        public int Order { get; set; }
        public string Text { get; set; }
        public string Tips { get; set; }
        public string Path { get; set; }
        public string Memo { get; set; }

        #region 方法重写
        public override string ToString()
        {
            return Text;
        }

        public override bool Equals(object obj)
        {
            if (obj is Dir)
            {
                return Id == ((Dir)obj).Id;
            }
            if (obj is string)
            {
                return Id == (string)obj;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id != null ? Id.GetHashCode() : 0;
        }
        #endregion

        public bool FromXml(XmlReader reader)
        {
            if (reader == null || reader.Name != "Dir" || !reader.IsStartElement())
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
            if (reader.Name == "Text" || reader.ReadToNextSibling("Text"))
            {
                Text = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Tips" || reader.ReadToNextSibling("Tips"))
            {
                Tips = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Path" || reader.ReadToNextSibling("Path"))
            {
                Path = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Memo" || reader.ReadToNextSibling("Memo"))
            {
                Memo = reader.ReadElementContentAsString();
            }

            if (reader.Name == "Dir" && reader.NodeType == XmlNodeType.EndElement)
            {
                reader.ReadEndElement();
            }
            return true;
        }

        public void ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Dir");

            writer.WriteElementString("Order", Order.ToString());
            writer.WriteElementString("Id", Id);
            writer.WriteElementString("Text", Text);
            writer.WriteElementString("Tips", Tips);
            writer.WriteElementString("Path", Path);
            writer.WriteElementString("Memo", Memo);

            writer.WriteEndElement();
        }
    }
}

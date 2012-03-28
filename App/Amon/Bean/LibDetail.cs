using System.Collections;
using System.Xml;

namespace Me.Amon.Bean
{
    public class LibDetail : Vcs, IComparer
    {
        public int Order { get; set; }

        public int Type { get; set; }

        public string Header { get; set; }

        public string Name { get; set; }

        public string Data { get; set; }

        public string Memo { get; set; }

        public bool FromXml(XmlReader reader)
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

        public void ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Item");

            writer.WriteElementString("Id", Id);
            writer.WriteElementString("Type", Type.ToString());
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Data", Data);
            writer.WriteElementString("Memo", Memo);

            writer.WriteEndElement();
        }

        public int Compare(object x, object y)
        {
            return 0;
        }
    }
}

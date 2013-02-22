using System.Data;
using System.Xml;
using Me.Amon.Da.Db;

namespace Me.Amon.Bean
{
    public class LibDetail : Vcs
    {
        public int Order { get; set; }

        public int Type { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string Data { get; set; }

        public string Memo { get; set; }

        #region 接口实现
        public override bool Load(DataRow row)
        {
            Order = (int)row[DBConst.APWD0301];
            Type = (int)row[DBConst.APWD0302];
            Id = row[DBConst.APWD0304] as string;
            Text = row[DBConst.APWD0306] as string;
            Data = row[DBConst.APWD0307] as string;
            Memo = row[DBConst.APWD0308] as string;

            return true;
        }

        public override bool Read(DBAccess dba, string Id)
        {
            return true;
        }

        public override bool Save(DBAccess dba, bool update)
        {
            return true;
        }
        #endregion

        public bool FromXml(XmlReader reader)
        {
            if (reader == null || reader.Name != "Item")
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
            return true;
        }

        public void ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Item");

            writer.WriteElementString("Order", Order.ToString());
            writer.WriteElementString("Id", Id);
            writer.WriteElementString("Type", Type.ToString());
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Text", Text);
            writer.WriteElementString("Data", Data);
            writer.WriteElementString("Memo", Memo);

            writer.WriteEndElement();
        }
    }
}

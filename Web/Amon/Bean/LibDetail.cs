using System.Data;
using System.Xml;
using Me.Amon.Da;

namespace Me.Amon.Bean
{
    public class LibDetail : Vcs
    {
        public string Id { get; set; }

        public int Type { get; set; }

        public string Name { get; set; }

        public string Data { get; set; }

        public string Memo { get; set; }

        #region 接口实现
        public override bool Load(DataRow row)
        {
            Type = (int)row[DBConst.APWD0302];
            Id = row[DBConst.APWD0304] as string;
            Name = row[DBConst.APWD0306] as string;
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

            if (reader.Name == "Type" || reader.ReadToDescendant("Type"))
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
    }
}

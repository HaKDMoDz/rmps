using System.Data;
using System.Xml;
using Me.Amon.Da;

namespace Me.Amon.Bean
{
    public class LibDetail : Vcs
    {
        public int Order { get; set; }

        public int Type { get; set; }

        public string Id { get; set; }

        public string Header { get; set; }

        public string Name { get; set; }

        public string Data { get; set; }

        public string Memo { get; set; }

        #region 接口实现
        public override bool Load(DataRow row)
        {
            Type = (int)row[DBConst.APWD0302];
            Id = row[DBConst.APWD0304] as string;
            Header = row[DBConst.APWD0305] as string;
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
            dba.ReInit();
            dba.AddTable(DBConst.APWD0300);
            dba.AddParam(DBConst.APWD0301, Order);
            dba.AddParam(DBConst.APWD0302, Type);
            dba.AddParam(DBConst.APWD0305, Header);
            dba.AddParam(DBConst.APWD0306, Name);
            dba.AddParam(DBConst.APWD0307, Data);
            dba.AddParam(DBConst.APWD0308, Memo);
            dba.AddParam(DBConst.APWD0309, DBConst.SQL_NOW, false);

            if (update)
            {
                dba.AddWhere(DBConst.APWD0303, UserCode);
                dba.AddWhere(DBConst.APWD0304, Id);
                dba.AddVcs(DBConst.APWD030B, DBConst.APWD030C, Operate, Cat.OPT_UPDATE);
                return 1 == dba.ExecuteUpdate();
            }

            dba.AddParam(DBConst.APWD0303, UserCode);
            dba.AddParam(DBConst.APWD0304, Id);
            dba.AddParam(DBConst.APWD030A, DBConst.SQL_NOW, false);
            dba.AddVcs(DBConst.APWD030B, DBConst.APWD030C);
            return 1 == dba.ExecuteInsert();
        }
        #endregion

        public bool FromXml(XmlReader reader)
        {
            if (reader == null || reader.Name != "Item")
            {
                return false;
            }

            if (reader.Name == "Id" || reader.ReadToDescendant("Id"))
            {
                Id = reader.ReadElementContentAsString();
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

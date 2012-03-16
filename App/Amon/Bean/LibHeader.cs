using System.Collections.Generic;
using System.Data;
using System.Xml;
using Me.Amon.Da;

namespace Me.Amon.Bean
{
    public class LibHeader : Vcs
    {
        public int Order { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Memo { get; set; }

        public List<LibDetail> Details { get; set; }

        public LibHeader()
        {
            Details = new List<LibDetail>();
        }

        #region 接口实现
        public override bool Load(DataRow row)
        {
            Id = row[DBConst.APWD0304] as string;
            Name = row[DBConst.APWD0306] as string;
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
            dba.AddParam(DBConst.APWD0302, 0);
            dba.AddParam(DBConst.APWD0305, "0");
            dba.AddParam(DBConst.APWD0306, Name);
            dba.AddParam(DBConst.APWD0307, "");
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

        #region 方法重写
        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is string)
            {
                string id = obj as string;
                return Id == id;
            }
            if (obj is LibHeader)
            {
                LibHeader header = obj as LibHeader;
                return Id == header.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        #endregion

        public bool FromXml(XmlReader reader)
        {
            if (reader == null || reader.Name != "Lib")
            {
                return false;
            }

            if (reader.Name == "Id" || reader.ReadToDescendant("Id"))
            {
                Id = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Name" || reader.ReadToNextSibling("Name"))
            {
                Name = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Memo" || reader.ReadToNextSibling("Memo"))
            {
                Memo = reader.ReadElementContentAsString();
            }

            Details.Clear();
            LibDetail detail;
            if (reader.ReadToDescendant("Item"))
            {
                detail = new LibDetail();
                detail.FromXml(reader);
                detail.Header = Id;
                detail.UserCode = UserCode;
                detail.Order = Details.Count;
                Details.Add(detail);
            }
            while (reader.ReadToNextSibling("Item"))
            {
                detail = new LibDetail();
                detail.FromXml(reader);
                detail.Header = Id;
                detail.UserCode = UserCode;
                detail.Order = Details.Count;
                Details.Add(detail);
            }
            return true;
        }

        public void ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Lib");

            writer.WriteElementString("Id", Id);
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Memo", Memo);

            writer.WriteStartElement("Items");
            foreach (LibDetail detail in Details)
            {
                detail.ToXml(writer);
            }
            writer.WriteEndElement();

            writer.WriteEndElement();
        }
    }
}

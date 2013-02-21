using System.Collections.Generic;
using System.Data;
using System.Xml;
using Me.Amon.Da.Db;

namespace Me.Amon.Bean
{
    public class LibHeader : Vcs
    {
        public int Order { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string Memo { get; set; }

        public List<LibDetail> Details { get; set; }

        public LibHeader()
        {
            Details = new List<LibDetail>();
        }

        #region 接口实现
        public override bool Load(DataRow row)
        {
            Order = (int)row[DBConst.APWD0301];
            Id = row[DBConst.APWD0304] as string;
            Text = row[DBConst.APWD0306] as string;
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

        #region 方法重写
        public override string ToString()
        {
            return Text;
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
            if (reader.Name == "Text" || reader.ReadToNextSibling("Text"))
            {
                Text = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Memo" || reader.ReadToNextSibling("Memo"))
            {
                Memo = reader.ReadElementContentAsString();
            }
            return true;
        }

        public void ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Lib");

            writer.WriteElementString("Order", Order.ToString());
            writer.WriteElementString("Id", Id);
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Text", Text);
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

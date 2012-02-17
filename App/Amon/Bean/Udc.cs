using System.Data;
using System.Xml;
using Me.Amon.Da;

namespace Me.Amon.Bean
{
    /// <summary>
    /// 
    /// </summary>
    public class Udc : Vcs
    {
        public int Order { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Tips { get; set; }
        public string Data { get; set; }
        public string Memo { get; set; }

        #region 接口实现
        public override bool Load(DataRow row)
        {
            Order = (int)row[DBConst.AUDC0101];
            Id = row[DBConst.AUDC0103] as string;
            Name = row[DBConst.AUDC0104] as string;
            Tips = row[DBConst.AUDC0105] as string;
            Data = row[DBConst.AUDC0106] as string;
            Memo = row[DBConst.AUDC0107] as string;

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
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Udc)
            {
                return Id == ((Udc)obj).Id;
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
            if (reader == null || reader.Name != "Udc")
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
            if (reader.Name == "Tips" || reader.ReadToNextSibling("Tips"))
            {
                Tips = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Data" || reader.ReadToNextSibling("Data"))
            {
                Data = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Memo" || reader.ReadToNextSibling("Memo"))
            {
                Data = reader.ReadElementContentAsString();
            }
            return true;
        }

        public void ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Udc");

            writer.WriteElementString("Order", Order.ToString());
            writer.WriteElementString("Id", Id);
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Tips", Tips);
            writer.WriteElementString("Data", Data);
            writer.WriteElementString("Memo", Memo);

            writer.WriteEndElement();
        }
    }
}

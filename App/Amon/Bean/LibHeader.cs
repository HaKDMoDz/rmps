using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace Me.Amon.Bean
{
    public class LibHeader : Vcs, IComparer
    {
        public int Order { get; set; }

        public string Name { get; set; }

        public string Memo { get; set; }

        public List<LibDetail> Details { get; set; }

        public LibHeader()
        {
            Details = new List<LibDetail>();
        }

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
            if (reader.Name == "Memo" || reader.ReadToNextSibling("Memo"))
            {
                Memo = reader.ReadElementContentAsString();
            }

            Details.Clear();
            if (reader.Name == "Items" || reader.ReadToNextSibling("Items"))
            {
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

        public int Compare(object x, object y)
        {
            return 0;
        }
    }
}

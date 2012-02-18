using System.Collections.Generic;
using System.Xml;

namespace Me.Amon.Model
{
    public class LibHeader
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Memo { get; set; }

        public List<LibDetail> Details { get; set; }

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

        public bool FromXml(XmlReader reader)
        {
            if (reader == null)
            {
                return false;
            }
            if (reader.Name == "Id" || reader.ReadToFollowing("Id"))
            {
                Id = reader.ReadElementContentAsString();
                Name = reader.ReadElementContentAsString();
                Memo = reader.ReadElementContentAsString();
                return true;
            }
            return false;
        }

        public string ToXml()
        {
            return "";
        }
    }
}

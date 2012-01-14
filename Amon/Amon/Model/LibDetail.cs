using System.Xml;

namespace Me.Amon.Model
{
    public class LibDetail : Vcs
    {
        public string Id { get; set; }

        public int Type { get; set; }

        public string Name { get; set; }

        public string Data { get; set; }

        public string Memo { get; set; }

        public bool FromXml(XmlReader reader)
        {
            if (reader == null)
            {
                return false;
            }
            if (reader.Name == "Type" || reader.ReadToFollowing("Type"))
            {
                Type = reader.ReadElementContentAsInt();
                Name = reader.ReadElementContentAsString();
                Data = reader.ReadElementContentAsString();
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

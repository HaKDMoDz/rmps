using System.Xml;
using Me.Amon.Sql.Model;

namespace Me.Amon.Sql.M
{
    public class Rdbms
    {
        public string Id { get; set; }

        public string LibId { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string ConnectionClass { get; set; }

        public string CommandClass { get; set; }

        public string AdapterClass { get; set; }

        public string ConnectionString { get; set; }

        public string Uri { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public void FromXml(XmlNode node)
        {
            Id = Dml.Attribute(node, "Id", "");
            Name = Dml.Attribute(node, "Name", "");
            Text = Dml.Attribute(node, "Text", "");
            LibId = Dml.Attribute(node, "LibId", "");

            XmlNode temp = node.SelectSingleNode("Class/Connection");
            if (temp != null)
            {
                ConnectionClass = temp.InnerText;
            }
            temp = node.SelectSingleNode("Class/Command");
            if (temp != null)
            {
                CommandClass = temp.InnerText;
            }
            temp = node.SelectSingleNode("Class/Adapter");
            if (temp != null)
            {
                AdapterClass = temp.InnerText;
            }

            temp = node.SelectSingleNode("Resource/Config");
            if (temp != null)
            {
                ConnectionString = temp.InnerText;
            }
            temp = node.SelectSingleNode("Resource/Uri");
            if (temp != null)
            {
                Uri = temp.InnerText;
            }
            temp = node.SelectSingleNode("Resource/User");
            if (temp != null)
            {
                User = temp.InnerText;
            }
            temp = node.SelectSingleNode("Resource/Password");
            if (temp != null)
            {
                Password = temp.InnerText;
            }
        }
    }
}

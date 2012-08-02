using System.Collections.Generic;
using System.Xml;

namespace Me.Amon.Sql.Model
{
    public class Dml
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string Memo { get; set; }

        public List<Param> Params { get; set; }

        public void Load(XmlNode node)
        {
            if (node == null)
            {
                return;
            }
            Id = Attribute(node, "Id", "");
            Type = Attribute(node, "Type", "");
            Name = Attribute(node, "Name", "");

            XmlNode temp = node.SelectSingleNode("Text");
            if (temp == null)
            {
                return;
            }
            Text = (temp.InnerText ?? "").Trim();

            temp = node.SelectSingleNode("Text");
            if (temp != null)
            {
                Memo = (temp.InnerText ?? "").Trim();
            }

            if (Params == null)
            {
                Params = new List<Param>();
            }
            else
            {
                Params.Clear();
            }

            Param param;
            foreach (XmlNode t in node.SelectNodes("Params/Param"))
            {
                param = new Param();
                param.Load(t);
                Params.Add(param);
            }
        }

        public void Save(XmlNode node)
        {
        }

        public override string ToString()
        {
            return Name;
        }

        public static string Attribute(XmlNode node, string name, string text)
        {
            if (node == null || string.IsNullOrWhiteSpace(name))
            {
                return text;
            }
            XmlAttribute attr = node.Attributes[name];
            if (attr == null)
            {
                return text;
            }
            name = attr.InnerText;
            return name != null ? name : text;
        }
    }
}

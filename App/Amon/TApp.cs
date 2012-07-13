using System.Xml;
using Me.Amon.Model;

namespace Me.Amon
{
    public class TApp : Vcs
    {
        public string Type { get; set; }

        public string Logo { get; set; }

        public string Uri { get; set; }

        public string Text { get; set; }

        public string Tips { get; set; }

        public IApp App { get; set; }

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
            if (node.Name != "App")
            {
                return;
            }
            Id = Attribute(node, "Id", "");
            Type = Attribute(node, "Type", "");
            Logo = Attribute(node, "Logo", "");
            Uri = Attribute(node, "Uri", "");
            Text = Attribute(node, "Text", "");
            Tips = Attribute(node, "Tips", "");
        }
    }
}

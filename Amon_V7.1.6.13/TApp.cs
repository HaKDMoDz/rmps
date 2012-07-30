using System.Xml;
using Me.Amon.Model;

namespace Me.Amon
{
    public class TApp
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public string Logo { get; set; }

        public string Uri { get; set; }

        public string Text { get; set; }

        public string Tips { get; set; }

        public bool Default { get; set; }

        public bool NeedAuth { get; set; }

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
            Id = Vcs.Attribute(node, "Id", "");
            Type = Vcs.Attribute(node, "Type", "");
            Logo = Vcs.Attribute(node, "Logo", "");
            Uri = Vcs.Attribute(node, "Uri", "");
            Text = Vcs.Attribute(node, "Text", "");
            Tips = Vcs.Attribute(node, "Tips", "");
            Default = "true" == Vcs.Attribute(node, "Default", "").ToLower();
        }
    }
}

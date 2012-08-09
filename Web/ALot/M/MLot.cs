using System.Collections.Generic;
using System.Xml;

namespace Me.Amon.Lot.M
{
    public class MLot
    {
        public string Id { get; private set; }

        public string Title { get; private set; }

        public List<Node> Nodes { get; private set; }

        public LotCfg Cfg { get; private set; }

        public LotFav Fav { get; private set; }

        public bool FromXml(XmlReader reader)
        {
            if (reader == null || reader.Name != "Lot" || !reader.IsStartElement())
            {
                return false;
            }

            if (reader.Name == "Title" || reader.ReadToDescendant("Title"))
            {
                Title = reader.ReadElementContentAsString();
            }

            Nodes = new List<Node>();
            while (reader.ReadToNextSibling("Node"))
            {
                Node node;
                while (reader.Name == "Node" || reader.ReadToNextSibling("Node"))
                {
                    node = new Node();
                    node.FromXml(reader);
                    Nodes.Add(node);
                }
            }

            return true;
        }
    }
}

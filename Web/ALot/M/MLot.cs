using System.Collections.Generic;
using System.Xml;

namespace Me.Amon.Lot.M
{
    public class MLot
    {
        public string Id { get; private set; }

        public string Title { get; private set; }

        public List<Node> Nodes { get; private set; }

        public LotCfg Cfg { get; set; }

        public LotFav Fav { get; set; }

        public bool FromXml(XmlReader reader)
        {
            if (reader.Name != "Lot")
            {
                return false;
            }

            reader.ReadStartElement();

            if (reader.Name == "Title")
            {
                Title = reader.ReadElementContentAsString();
            }

            Nodes = new List<Node>();
            if (reader.Name == "Nodes")
            {
                reader.ReadStartElement();

                Node node;
                while (reader.Name == "Node")
                {
                    node = new Node();
                    if (!node.FromXml(reader))
                    {
                        return false;
                    }
                    Nodes.Add(node);
                }

                if (reader.Name == "Nodes" && reader.NodeType == XmlNodeType.EndElement)
                {
                    reader.ReadEndElement();
                }
            }

            if (reader.Name == "Lot" && reader.NodeType == XmlNodeType.EndElement)
            {
                reader.ReadEndElement();
            }
            return true;
        }
    }
}

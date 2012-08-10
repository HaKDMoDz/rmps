using System.Collections.Generic;
using System.Xml;

namespace Me.Amon.Lot.M
{
    public class Node
    {
        /// <summary>
        /// 轮次
        /// </summary>
        public List<Round> Rounds { get; private set; }

        /// <summary>
        /// 值域
        /// </summary>
        public List<Item> Items { get; private set; }

        public bool FromXml(XmlReader reader)
        {
            if (reader.Name != "Node")
            {
                return false;
            }

            reader.ReadStartElement();

            Rounds = new List<Round>();
            if (reader.Name == "Rounds")
            {
                reader.ReadStartElement();

                Round round;
                while (reader.Name == "Round")
                {
                    round = new Round();
                    if (!round.FromXml(reader))
                    {
                        return false;
                    }
                    Rounds.Add(round);
                }

                if (reader.Name == "Rounds" && reader.NodeType == XmlNodeType.EndElement)
                {
                    reader.ReadEndElement();
                }
            }

            Items = new List<Item>();
            if (reader.Name == "Items")
            {
                reader.ReadStartElement();

                Item item;
                while (reader.Name == "Item")
                {
                    item = new Item();
                    if (!item.FromXml(reader))
                    {
                        return false;
                    }
                    Items.Add(item);
                }

                if (reader.Name == "Items" && reader.NodeType == XmlNodeType.EndElement)
                {
                    reader.ReadEndElement();
                }
            }

            if (reader.Name == "Node" && reader.NodeType == XmlNodeType.EndElement)
            {
                reader.ReadEndElement();
            }
            return true;
        }
    }
}

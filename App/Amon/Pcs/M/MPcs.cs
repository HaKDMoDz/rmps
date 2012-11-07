using System;
using System.Drawing;
using Me.Amon.M;

namespace Me.Amon.Pcs.M
{
    public class MPcs : Vcs
    {
        public string Server;

        public string Account;

        public string DisplayName;

        [NonSerialized]
        public string Logo;

        public Image Icon;

        public override bool FromXml(System.Xml.XmlReader reader)
        {
            return true;
        }

        public override bool ToXml(System.Xml.XmlWriter writer)
        {
            return true;
        }
    }
}

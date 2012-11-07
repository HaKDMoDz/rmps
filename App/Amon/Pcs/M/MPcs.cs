using System;
using System.Drawing;
using Me.Amon.M;

namespace Me.Amon.Pcs.M
{
    public class MPcs : Vcs
    {
        public string ServerType;

        public string ServerName;

        public string UserId;

        public string UserName;

        public string LogoId;

        [NonSerialized]
        public Image Logo;

        public string Token;

        public string TokenSecret;

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

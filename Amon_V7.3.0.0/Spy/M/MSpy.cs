using Me.Amon.M;

namespace Me.Amon.Spy.M
{
    public class MSpy : Vcs
    {
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

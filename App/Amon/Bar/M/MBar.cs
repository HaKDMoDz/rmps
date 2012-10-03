using Me.Amon.M;

namespace Me.Amon.Bar.M
{
    /// <summary>
    /// 数据模型
    /// </summary>
    public class MBar : Vcs
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

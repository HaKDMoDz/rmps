using Me.Amon.M;

namespace Me.Amon.Img.M
{
    /// <summary>
    /// 数据模型
    /// </summary>
    public class MImg : Vcs
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

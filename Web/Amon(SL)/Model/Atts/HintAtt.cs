using System.Text;
using System.Xml;

namespace Me.Amon.Model.Atts
{
    public class HintAtt : Att
    {
        public MgtdHeader GtdHeader { get; set; }

        public HintAtt()
            : base(TYPE_HINT, "", "")
        {
            Order = "提示";
        }

        public override bool ExportAsTxt(StringBuilder builder)
        {
            return true;
        }

        public override bool ExportAsXml(XmlWriter writer)
        {
            writer.WriteStartElement("name");
            writer.WriteString(Name);
            writer.WriteEndElement();

            writer.WriteStartElement("data");
            writer.WriteString(Data);
            writer.WriteEndElement();
            return true;
        }

        public override bool ImportByTxt(string txt)
        {
            return true;
        }

        public override bool ImportByXml(string xml)
        {
            return true;
        }

        public override void SetDefault()
        {
        }
    }
}

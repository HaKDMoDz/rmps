using System.Text;
using System.Xml;
using Me.Amon.Util;

namespace Me.Amon.Model.Att
{
    public class LineAtt : AAtt
    {
        public const int SPEC_SIGN_TYPE = 0;//控制类型
        public const int SPEC_SIGN_TPLT = 1;//显示模板

        public LineAtt()
            : base(TYPE_LINE, "", "")
        {
        }

        public override bool ExportAsTxt(StringBuilder builder)
        {
            if (builder == null)
            {
                return false;
            }
            builder.Append(DoEscape(Name)).Append(',').Append(DoEscape(Data));
            foreach (string tmp in _Spec)
            {
                builder.Append(',').Append(tmp);
            }
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
            if (!CharUtil.IsValidate(txt))
            {
                return false;
            }
            string[] array = txt.Replace("\\,", "\f").Split(',');
            if (array == null || array.Length < 2)
            {
                return false;
            }
            int i = 0;
            Name = UnEscape(array[i++].Replace("\f", "\\,"));
            Data = UnEscape(array[i++].Replace("\f", "\\,"));

            int j = _Spec.Length + i;
            if (j > array.Length)
            {
                j = array.Length;
            }
            while (j > i)
            {
                j -= 1;
                _Spec[j - i] = array[j];
            }
            return true;
        }

        public override bool ImportByXml(XmlReader reader)
        {
            if (reader.ReadToDescendant("name"))
            {
                Name = reader.Value;
            }
            if (reader.ReadToNextSibling("data"))
            {
                Data = reader.Value;
            }
            return true;
        }

        public override void SetDefault()
        {
            if (_Spec == null)
            {
                _Spec = new string[2];
            }

            _Spec[0] = "def";
            _Spec[1] = "P30F7E02";
        }
    }
}

using System.Text;
using System.Xml;
using Me.Amon.Util;

namespace Me.Amon.Model.Att
{
    public class PassAtt : AAtt
    {
        public const int SPEC_PWDS_KEY = 0;// 字符空间索引
        public const int SPEC_PWDS_LEN = 1;// 生成口令长度
        public const int SPEC_PWDS_REP = 2;// 是否允许重复

        public PassAtt()
            : base(TYPE_PASS, "", "")
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
                _Spec = new string[3];
            }

            for (int i = 0; i < _Spec.Length; i += 1)
            {
                _Spec[i] = SPEC_VALUE_NONE;
            }
        }
    }
}

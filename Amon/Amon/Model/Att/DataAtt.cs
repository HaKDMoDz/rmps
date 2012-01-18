using System.Text;
using System.Xml;
using Me.Amon.Util;

namespace Me.Amon.Model.Att
{
    public class DataAtt : AAtt
    {
        public const int SPEC_OPT = 0;//可选输入
        public const int SPEC_SET = 1;//数据集
        public const int SPEC_DOT_INT = 2;//整数位
        public const int SPEC_DOT_DEC = 3;//小数位
        public const int SPEC_CHAR = 4;//特殊符号
        public const int SPEC_CHAR_OPT = 5;//是否可选
        public const int SPEC_CHAR_POS = 6;//符号位置
        public const int SPEC_EXP = 7;//表达式

        public DataAtt()
            : base(TYPE_DATA, "", "")
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
                _Spec = new string[8];
            }

            _Spec[0] = SPEC_VALUE_TRUE;
            _Spec[1] = "+0-";
            _Spec[2] = "0";
            _Spec[3] = "8";
            _Spec[4] = SPEC_VALUE_NONE;
            _Spec[5] = SPEC_VALUE_TRUE;
            _Spec[6] = "^";
            _Spec[7] = SPEC_VALUE_FAIL;
        }
    }
}

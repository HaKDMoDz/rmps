using System.Collections.Generic;
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

            foreach (string tmp in ext)
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
            Name = UnEscape(array[0].Replace("\f", "\\,"));
            Data = UnEscape(array[1].Replace("\f", "\\,"));

            ext.Clear();
            for (int i = 2, j = array.Length; i < j; i += 1)
            {
                ext.Add(array[i]);
            }
            return true;
        }

        public override bool ImportByXml(string xml)
        {
            return true;
        }

        public override void SetDefault()
        {
            if (ext == null)
            {
                this.ext = new List<string>(8);
            }
            else
            {
                ext.Clear();
            }

            ext.Add(SPEC_VALUE_TRUE);
            ext.Add("+0-");
            ext.Add("0");
            ext.Add("8");
            ext.Add(SPEC_VALUE_NONE);
            ext.Add(SPEC_VALUE_TRUE);
            ext.Add("^");
            ext.Add(SPEC_VALUE_FAIL);
        }
    }
}

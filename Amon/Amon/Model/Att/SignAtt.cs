using System.Collections.Generic;
using System.Text;
using System.Xml;
using Me.Amon.Util;

namespace Me.Amon.Model.Att
{
    public class SignAtt : AAtt
    {
        public const int SPEC_SIGN_TYPE = 0;//控制类型
        public const int SPEC_SIGN_TPLT = 1;//显示模板

        public SignAtt()
            : base(TYPE_SIGN, "", "")
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
                this.ext = new List<string>(2);
            }
            else
            {
                ext.Clear();
            }

            ext.Add("def");
            ext.Add("P30F7E02");
        }
    }
}

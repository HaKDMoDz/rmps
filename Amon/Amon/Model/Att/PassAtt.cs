using System.Collections.Generic;
using System.Text;
using System.Xml;
using Me.Amon.Util;

namespace Me.Amon.Model.Att
{
    public class PassAtt : AAtt
    {
        public const int SPEC_PWDS_HASH = 0;// 字符空间索引
        public const int SPEC_PWDS_SIZE = 1;// 生成口令长度
        public const int SPEC_PWDS_LOOP = 2;// 是否允许重复

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
            Name = UnEscape(array[0].Replace("\f", "\\,"));
            Data = UnEscape(array[1].Replace("\f", "\\,"));

            _Spec.Clear();
            for (int i = 2, j = array.Length; i < j; i += 1)
            {
                _Spec.Add(array[i]);
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
                this._Spec = new List<string>(3);
            }
            else
            {
                _Spec.Clear();
            }

            //ext.Add(userCfg.getPwdsKey());
            //ext.Add(userCfg.getPwdsLen());
            //ext.Add(userCfg.getPwdsLoop());
        }
    }
}

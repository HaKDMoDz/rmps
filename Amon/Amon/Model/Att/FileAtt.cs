using System.Text;
using System.Xml;
using Me.Amon.Util;

namespace Me.Amon.Model.Att
{
    public class FileAtt : AAtt
    {
        public const int SPEC_FILE_NAME = 0;// 附件原文件名
        public const int SPEC_FILE_EXTS = 1;// 附件原扩展名
        public const int SPEC_FILE_ALG = 2;// 加密算法
        public const int SPEC_FILE_KEY = 3;// 加密口令

        public FileAtt()
            : base(TYPE_FILE, "", "")
        {

        }

        public override bool ExportAsTxt(StringBuilder builder)
        {
            if (builder == null)
            {
                return false;
            }
            builder.Append(DoEscape(Name)).Append(',').Append(DoEscape(Data));
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
                _Spec = new string[4];
            }

            for (int i = 0; i < _Spec.Length; i += 1)
            {
                _Spec[i] = SPEC_VALUE_NONE;
            }
        }
    }
}

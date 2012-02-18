using System.Collections.Generic;
using System.Text;
using System.Xml;
using Me.Amon.Utils;

namespace Me.Amon.Model.Atts
{
    public class GuidAtt : Att
    {
        public bool IsAppend { get; set; }

        public GuidAtt()
            : base(TYPE_GUID, "", "")
        {
            Order = "向导";
        }

        #region
        public override bool ExportAsTxt(StringBuilder builder)
        {
            if (builder == null)
            {
                return false;
            }
            builder.Append(DoEscape(Name));
            //builder.append(',').append(doEscape(Data));
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
            string[] array = txt.Split(',');
            if (!CharUtil.isValidateDateTime(array[0]))
            {
                return false;
            }

            Name = UnEscape(array[0]);
            if (array.Length == 2)
            {
                Data = UnEscape(array[1]);
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

            ext.Add(SPEC_VALUE_NONE);
            ext.Add(SPEC_VALUE_NONE);
        }
        #endregion

        public const int SPEC_GUID_TPLT = 0;// 口令模板索引
    }
}

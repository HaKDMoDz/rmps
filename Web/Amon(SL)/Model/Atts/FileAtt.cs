﻿using System.Collections.Generic;
using System.Text;
using System.Xml;
using Me.Amon.Utils;

namespace Me.Amon.Model.Atts
{
    public class FileAtt : Att
    {
        public const int SPEC_FILE_NAME = 0;// 附件原文件名
        public const int SPEC_FILE_EXTS = 1;// 附件原扩展名

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
            if (!CharUtil.isValidate(txt))
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
                this.ext = new List<string>(1);
            }
            else
            {
                ext.Clear();
            }

            ext.Add(SPEC_VALUE_NONE);
        }
    }
}

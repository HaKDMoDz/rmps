using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Me.Amon.M;
using Me.Amon.Util;

namespace Me.Amon.Sec.M
{
    public class UserModel : AUserModel
    {
        public string SysHome { get; private set; }
        public string DatHome { get; private set; }
        public string ResHome { get; private set; }

        public bool Modified { get; private set; }

        private List<MSec> _RuleList;

        public void Init()
        {
            if (File.Exists("Amon.tag"))
            {
                SysHome = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "阿木密码箱");
                if (!Directory.Exists(SysHome))
                {
                    Directory.CreateDirectory(SysHome);
                }
            }
            else
            {
                SysHome = Environment.CurrentDirectory;
            }

            DatHome = Path.Combine(SysHome, "Dat");

            ResHome = SysHome;

            if (File.Exists(CApp.FILE_VER))
            {
                BeanUtil.UnZip(CApp.FILE_DAT, DatHome);
                File.Delete(CApp.FILE_VER);
            }
            if (!Directory.Exists(DatHome))
            {
                BeanUtil.UnZip(CApp.FILE_DAT, DatHome);
            }
        }

        public List<MSec> LoadRules()
        {
            _RuleList = new List<MSec>(32);

            string file = Path.Combine(DatHome, "ARen-Lib.xml");
            using (XmlReader reader = XmlReader.Create(file, new XmlReaderSettings { IgnoreComments = true, IgnoreWhitespace = true }))
            {
                if (reader.Name != "App" && !reader.ReadToFollowing("App") || reader.ReadElementContentAsString() != "ARen")
                {
                    return _RuleList;
                }
                if (reader.Name != "Ver" && !reader.ReadToFollowing("Ver") || reader.ReadElementContentAsString() != "1")
                {
                    return _RuleList;
                }
                MSec ren;
                while (reader.Name == "Ren" || reader.ReadToFollowing("Ren"))
                {
                    ren = new MSec();
                    if (!ren.FromXml(reader))
                    {
                        continue;
                    }
                    _RuleList.Add(ren);
                }
            }
            return _RuleList;
        }

        public void AddRule(MSec ren)
        {
            _RuleList.Add(ren);
        }

        public MSec GetRule(int idx)
        {
            if (idx < 0 || idx >= _RuleList.Count)
            {
                return null;
            }
            return _RuleList[idx];
        }

        public void RemoveRuleAt(int index)
        {
            _RuleList.RemoveAt(index);
            Modified = true;
        }

        public void SaveRules()
        {
            StreamWriter output = new StreamWriter(Path.Combine(DatHome, "ARen-Lib.xml"));
            XmlWriter writer = XmlWriter.Create(output, new XmlWriterSettings { Indent = true });
            writer.WriteStartDocument();
            writer.WriteStartElement("Amon");

            writer.WriteElementString("App", "ARen");
            writer.WriteElementString("Ver", "1");

            writer.WriteStartElement("Rens");
            foreach (MSec item in _RuleList)
            {
                item.ToXml(writer);
            }
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.Close();

            output.Close();
        }
    }
}

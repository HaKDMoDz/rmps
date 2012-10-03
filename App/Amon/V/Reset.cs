using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.M;
using Me.Amon.Pwd.M;

namespace Me.Amon.V
{
    public partial class Reset : Form
    {
        private AUserModel _UserModel;

        #region 构造函数
        public Reset()
        {
            InitializeComponent();
        }

        public Reset(AUserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }
        #endregion

        #region 数据导入
        public static void Import(AUserModel userModel)
        {
            XmlReaderSettings setting = new XmlReaderSettings { IgnoreWhitespace = true };
            ImportAPwdDir(userModel, setting);
        }

        /// <summary>
        /// 类别
        /// </summary>
        /// <param name="userModel"></param>
        /// <param name="setting"></param>
        private static void ImportAPwdCat(AUserModel userModel, XmlReaderSettings setting)
        {
            string file = Path.Combine(userModel.DatHome, "APwd-Cat.xml");
            if (!File.Exists(file))
            {
                return;
            }

            StreamReader stream = new StreamReader(file);
            using (XmlReader reader = XmlReader.Create(stream, setting))
            {
                Cat cat;
                while (reader.Name == "Cat" || reader.ReadToFollowing("Cat"))
                {
                    cat = new Cat();
                    if (!cat.FromXml(reader))
                    {
                        continue;
                    }
                    userModel.DBA.DeleteVcs(cat);
                    userModel.DBA.SaveVcs(cat);
                }
            }
            stream.Close();
        }

        private static void ImportAPwdLib(AUserModel userModel, XmlReaderSettings setting)
        {
            string file = Path.Combine(userModel.DatHome, "APwd-Lib.xml");
            if (File.Exists(file))
            {
                return;
            }

            StreamReader stream = new StreamReader(file);
            using (XmlReader reader = XmlReader.Create(stream, setting))
            {
                Lib header;
                while (reader.Name == "Lib" || reader.ReadToFollowing("Lib"))
                {
                    header = new Lib();
                    if (!header.FromXml(reader))
                    {
                        continue;
                    }
                    userModel.DBA.DeleteVcs(header);
                    userModel.DBA.SaveVcs(header);
                }
            }
            stream.Close();
        }

        /// <summary>
        /// 目录
        /// </summary>
        /// <param name="userModel"></param>
        /// <param name="setting"></param>
        private static void ImportAPwdDir(AUserModel userModel, XmlReaderSettings setting)
        {
            string file = Path.Combine(userModel.DatHome, "APwd-Dir.xml");
            if (!File.Exists(file))
            {
                return;
            }

            StreamReader stream = new StreamReader(file);
            using (XmlReader reader = XmlReader.Create(stream, setting))
            {
                Dir dir;
                while (reader.Name == "Dir" || reader.ReadToFollowing("Dir"))
                {
                    dir = new Dir();
                    if (!dir.FromXml(reader))
                    {
                        continue;
                    }
                    userModel.DBA.DeleteVcs(dir);
                    userModel.DBA.SaveVcs(dir);
                }
            }
            stream.Close();
        }
        #endregion

        #region 数据导出
        public static void Export(AUserModel userModel)
        {
            XmlWriterSettings setting = new XmlWriterSettings { Indent = true };
            ExportAPwdCat(userModel, setting);
        }

        private static void ExportAPwdCat(AUserModel userModel, XmlWriterSettings setting)
        {
            string file = Path.Combine(userModel.DatHome, "APwd-Cat.xml");
            StreamWriter stream = new StreamWriter(file);
            using (XmlWriter writer = XmlWriter.Create(stream, setting))
            {
                writer.WriteStartElement("Amon");

                writer.WriteElementString("App", "APwd");
                writer.WriteElementString("Ver", "1");

                writer.WriteStartElement("Cats");
                foreach (Cat cat in userModel.DBA.ListCat(CApp.IAPP_APWD, ""))
                {
                    cat.ToXml(writer);
                }
                writer.WriteEndElement();

                writer.WriteEndElement();
            }
            stream.Close();
        }
        #endregion

        private void BtOk_Click(object sender, System.EventArgs e)
        {
            Export(_UserModel);
        }

        private void BtNo_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}

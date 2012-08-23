using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.M;
using Me.Amon.Pwd;

namespace Me.Amon.V
{
    public partial class Reset : Form
    {
        private UserModel _UserModel;

        #region 构造函数
        public Reset()
        {
            InitializeComponent();
        }

        public Reset(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }
        #endregion

        #region 数据导入
        public static void Import(UserModel userModel)
        {
            XmlReaderSettings setting = new XmlReaderSettings { IgnoreWhitespace = true };
            ImportAPwdDir(userModel, setting);
        }

        /// <summary>
        /// 类别
        /// </summary>
        /// <param name="userModel"></param>
        /// <param name="setting"></param>
        private static void ImportAPwdCat(UserModel userModel, XmlReaderSettings setting)
        {
            string file = Path.Combine(userModel.Home, "APwd-Cat.xml");
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

        private static void ImportAPwdLib(UserModel userModel, XmlReaderSettings setting)
        {
            string file = Path.Combine(userModel.Home, "APwd-Lib.xml");
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
        private static void ImportAPwdDir(UserModel userModel, XmlReaderSettings setting)
        {
            string file = Path.Combine(userModel.Home, "APwd-Dir.xml");
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
        public static void Export(UserModel userModel)
        {
            XmlWriterSettings setting = new XmlWriterSettings { Indent = true };
            ExportAPwdCat(userModel, setting);
        }

        private static void ExportAPwdCat(UserModel userModel, XmlWriterSettings setting)
        {
            string file = Path.Combine(userModel.Home, "APwd-Cat.xml");
            StreamWriter stream = new StreamWriter(file);
            using (XmlWriter writer = XmlWriter.Create(stream, setting))
            {
                writer.WriteStartElement("Amon");

                writer.WriteElementString("App", "APwd");
                writer.WriteElementString("Ver", "1");

                writer.WriteStartElement("Cats");
                foreach (Cat cat in userModel.DBA.ListCat(""))
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

﻿using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.M;
using Me.Amon.Pwd.M;

namespace Me.Amon.V
{
    public partial class Reset : Form
    {
        private AUserModel _UserModel;
        private DataModel _DataModel;

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
        public void Import(AUserModel userModel)
        {
            XmlReaderSettings setting = new XmlReaderSettings { IgnoreWhitespace = true };
            ImportWPwdDir(userModel, setting);
        }

        /// <summary>
        /// 类别
        /// </summary>
        /// <param name="userModel"></param>
        /// <param name="setting"></param>
        private void ImportWPwdCat(AUserModel userModel, XmlReaderSettings setting)
        {
            string file = Path.Combine(userModel.DatHome, "WPwd-Cat.xml");
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
                    _DataModel.DeleteVcs(cat);
                    _DataModel.SaveVcs(cat);
                }
            }
            stream.Close();
        }

        private void ImportWPwdLib(AUserModel userModel, XmlReaderSettings setting)
        {
            string file = Path.Combine(userModel.DatHome, "WPwd-Lib.xml");
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
                    _DataModel.DeleteVcs(header);
                    _DataModel.SaveVcs(header);
                }
            }
            stream.Close();
        }

        /// <summary>
        /// 目录
        /// </summary>
        /// <param name="userModel"></param>
        /// <param name="setting"></param>
        private void ImportWPwdDir(AUserModel userModel, XmlReaderSettings setting)
        {
            string file = Path.Combine(userModel.DatHome, "WPwd-Dir.xml");
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
                    _DataModel.DeleteVcs(dir);
                    _DataModel.SaveVcs(dir);
                }
            }
            stream.Close();
        }
        #endregion

        #region 数据导出
        public void Export(AUserModel userModel)
        {
            XmlWriterSettings setting = new XmlWriterSettings { Indent = true };
            ExportWPwdCat(userModel, setting);
        }

        private void ExportWPwdCat(AUserModel userModel, XmlWriterSettings setting)
        {
            string file = Path.Combine(userModel.DatHome, "WPwd-Cat.xml");
            StreamWriter stream = new StreamWriter(file);
            using (XmlWriter writer = XmlWriter.Create(stream, setting))
            {
                writer.WriteStartElement("Amon");

                writer.WriteElementString("App", "WPwd");
                writer.WriteElementString("Ver", "1");

                writer.WriteStartElement("Cats");
                foreach (Cat cat in _DataModel.ListCat(CApp.IAPP_WPWD, ""))
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

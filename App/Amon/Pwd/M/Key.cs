using System;
using System.Drawing;
using System.Text;
using System.Xml;
using Me.Amon.Gtd.M;
using Me.Amon.M;

namespace Me.Amon.Pwd.M
{
    public class Key : Vcs
    {
        public const int OPT_PWD_UPDATE_CAT = 3;
        public const int OPT_PWD_UPDATE_LABEL = 4;
        public const int OPT_PWD_UPDATE_MAJOR = 5;

        /// <summary>
        /// 显示排序
        /// </summary>
        public int Order;
        /// <summary>
        /// 使用状态
        /// </summary>
        public int Label;
        [NonSerialized]
        public Image LabelIcon;
        /// <summary>
        /// 紧要程度
        /// </summary>
        public int Major;
        [NonSerialized]
        public Image MajorIcon;
        /// <summary>
        /// 所属类别
        /// </summary>
        public string CatId;
        /// <summary>
        /// 注册日期
        /// </summary>
        public string RegTime;
        /// <summary>
        /// 模板索引
        /// </summary>
        public string LibId;
        /// <summary>
        /// 口令标题
        /// </summary>
        public string Title;
        /// <summary>
        /// 关键搜索
        /// </summary>
        public string MetaKey;
        /// <summary>
        /// 口令图标
        /// </summary>
        public string IcoName;
        /// <summary>
        /// 图标路径
        /// </summary>
        public string IcoPath;
        /// <summary>
        /// 图标说明
        /// </summary>
        public string IcoMemo;
        [NonSerialized]
        public Image Icon;
        /// <summary>
        /// 提醒索引
        /// </summary>
        public string GtdId;
        /// <summary>
        /// 提醒备注
        /// </summary>
        public string GtdMemo;
        public MGtd Gtd;
        [NonSerialized]
        public Image GtdIcon;
        /// <summary>
        /// 窗口对象
        /// </summary>
        public string Window;
        /// <summary>
        /// 执行脚本
        /// </summary>
        public string Script;
        /// <summary>
        /// 相关说明
        /// </summary>
        public string Memo;
        /// <summary>
        /// 访问日期
        /// </summary>
        public string AccessTime;
        /// <summary>
        /// 是否备份
        /// </summary>
        public bool Backup;
        /// <summary>
        /// 加密版本
        /// </summary>
        public int CipherVer;
        /// <summary>
        /// 索性索引
        /// </summary>
        public int AttIndex;
        /// <summary>
        /// 用户数据
        /// </summary>
        public string Password;

        /// <summary>
        /// 恢复默认值
        /// </summary>
        public Key()
        {
            //Id = null;
            //Order = 0;
            //Label = 0;
            //Major = 0;
            //CatId = null;
            //RegTime = null;
            //LibId = null;
            //Title = null;
            //MetaKey = null;
            //IcoName = null;
            //IcoPath = null;
            //IcoMemo = null;
            //GtdId = null;
            //GtdMemo = null;
            //Memo = null;
            //AccessTime = null;
            Backup = true;
            //CipherVer = 0;
        }

        public override string ToString()
        {
            return Title;
        }

        #region XML
        public string ToXml()
        {
            StringBuilder buffer = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(buffer, new XmlWriterSettings { Encoding = new UTF8Encoding(false) }))
            {
                writer.WriteStartElement("mpwd");
                writer.WriteStartElement("key");

                writer.WriteElementString("Id", Id);
                writer.WriteElementString("Order", Order.ToString());
                writer.WriteElementString("Label", Label.ToString());
                writer.WriteElementString("Major", Major.ToString());
                writer.WriteElementString("CatId", CatId);
                writer.WriteElementString("RegDate", RegTime);
                writer.WriteElementString("LibId", LibId);
                writer.WriteElementString("Title", Title);
                writer.WriteElementString("MetaKey", MetaKey);
                writer.WriteElementString("IcoName", IcoName);
                writer.WriteElementString("IcoPath", IcoPath);
                writer.WriteElementString("IcoMemo", IcoMemo);
                writer.WriteElementString("GtdId", GtdId);
                writer.WriteElementString("GtdMemo", GtdMemo);
                writer.WriteElementString("Window", Window);
                writer.WriteElementString("Script", Script);
                writer.WriteElementString("Memo", Memo);
                writer.WriteElementString("VisitDate", AccessTime);
                writer.WriteElementString("CipherVer", CipherVer.ToString());
                writer.WriteElementString("Backup", Backup ? "true" : "false");

                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.Flush();
            }
            return buffer.Replace("utf-16", "utf-8").ToString();
        }

        public override bool FromXml(XmlReader reader)
        {
            if (reader == null || reader.Name != "Key")
            {
                return false;
            }

            if (reader.Name == "Id" || reader.ReadToDescendant("Id"))
            {
                Id = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Order" || reader.ReadToNextSibling("Order"))
            {
                Order = reader.ReadElementContentAsInt();
            }
            if (reader.Name == "Label" || reader.ReadToNextSibling("Label"))
            {
                Label = reader.ReadElementContentAsInt();
            }
            if (reader.Name == "Major" || reader.ReadToNextSibling("Major"))
            {
                Major = reader.ReadElementContentAsInt();
            }
            if (reader.Name == "CatId" || reader.ReadToNextSibling("CatId"))
            {
                CatId = reader.ReadElementContentAsString();
            }
            if (reader.Name == "RegDate" || reader.ReadToNextSibling("RegDate"))
            {
                RegTime = reader.ReadElementContentAsString();
            }
            if (reader.Name == "LibId" || reader.ReadToNextSibling("LibId"))
            {
                LibId = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Title" || reader.ReadToNextSibling("Title"))
            {
                Title = reader.ReadElementContentAsString();
            }
            if (reader.Name == "MetaKey" || reader.ReadToNextSibling("MetaKey"))
            {
                MetaKey = reader.ReadElementContentAsString();
            }
            if (reader.Name == "IcoName" || reader.ReadToNextSibling("IcoName"))
            {
                IcoName = reader.ReadElementContentAsString();
            }
            if (reader.Name == "IcoPath" || reader.ReadToNextSibling("IcoPath"))
            {
                IcoPath = reader.ReadElementContentAsString();
            }
            if (reader.Name == "IcoMemo" || reader.ReadToNextSibling("IcoMemo"))
            {
                IcoMemo = reader.ReadElementContentAsString();
            }
            if (reader.Name == "GtdId" || reader.ReadToNextSibling("GtdId"))
            {
                GtdId = reader.ReadElementContentAsString();
            }
            if (reader.Name == "GtdMemo" || reader.ReadToNextSibling("GtdMemo"))
            {
                GtdMemo = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Window" || reader.ReadToNextSibling("Window"))
            {
                Window = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Script" || reader.ReadToNextSibling("Script"))
            {
                Script = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Memo" || reader.ReadToNextSibling("Memo"))
            {
                Memo = reader.ReadElementContentAsString();
            }
            if (reader.Name == "VisitDate" || reader.ReadToNextSibling("VisitDate"))
            {
                AccessTime = reader.ReadElementContentAsString();
            }
            if (reader.Name == "CipherVer" || reader.ReadToNextSibling("CipherVer"))
            {
                CipherVer = reader.ReadElementContentAsInt();
            }
            return true;
        }

        public override bool ToXml(XmlWriter writer)
        {
            return true;
        }
        #endregion

        public KeyLog ToLog()
        {
            KeyLog log = new KeyLog();
            log.RefId = Id;
            log.Order = Order;
            log.Label = Label;
            log.Major = Major;
            log.CatId = CatId;
            log.RegTime = RegTime;
            log.LibId = LibId;
            log.Title = Title;
            log.MetaKey = MetaKey;
            log.IcoName = IcoName;
            log.IcoPath = IcoPath;
            log.IcoMemo = IcoMemo;
            log.GtdId = GtdId;
            log.GtdMemo = GtdMemo;
            log.Window = Window;
            log.Script = Script;
            log.Memo = Memo;
            log.AccessTime = AccessTime;
            log.Backup = Backup;
            log.CipherVer = CipherVer;
            log.AttIndex = AttIndex;
            log.Password = Password;
            return log;
        }

        public bool FromLog(KeyLog log)
        {
            if (log == null)
            {
                return false;
            }

            Id = log.RefId;
            Order = log.Order;
            Label = log.Label;
            Major = log.Major;
            CatId = log.CatId;
            RegTime = log.RegTime;
            LibId = log.LibId;
            Title = log.Title;
            MetaKey = log.MetaKey;
            IcoName = log.IcoName;
            IcoPath = log.IcoPath;
            IcoMemo = log.IcoMemo;
            GtdId = log.GtdId;
            GtdMemo = log.GtdMemo;
            Window = log.Window;
            Script = log.Script;
            Memo = log.Memo;
            AccessTime = log.AccessTime;
            Backup = log.Backup;
            CipherVer = log.CipherVer;
            AttIndex = log.AttIndex;
            Password = log.Password;
            return true;
        }
    }
}

using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using Me.Amon.Da;
using System.Collections.Generic;

namespace Me.Amon.Model
{
    public sealed class Key : Vcs
    {
        public const int OPT_PWD_UPDATE_CAT = 3;
        public const int OPT_PWD_UPDATE_LABEL = 4;
        public const int OPT_PWD_UPDATE_MAJOR = 5;

        /// <summary>
        /// 口令索引
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 显示排序
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// 使用状态
        /// </summary>
        public int Label { get; set; }
        /// <summary>
        /// 紧要程度
        /// </summary>
        public int Major { get; set; }
        /// <summary>
        /// 所属类别
        /// </summary>
        public string CatId { get; set; }
        /// <summary>
        /// 注册日期
        /// </summary>
        public string RegDate { get; set; }
        /// <summary>
        /// 模板索引
        /// </summary>
        public string LibId { get; set; }
        /// <summary>
        /// 口令标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 关键搜索
        /// </summary>
        public string MetaKey { get; set; }
        /// <summary>
        /// 口令图标
        /// </summary>
        public string IcoName { get; set; }
        /// <summary>
        /// 图标路径
        /// </summary>
        public string IcoPath { get; set; }
        /// <summary>
        /// 图标说明
        /// </summary>
        public string IcoMemo { get; set; }
        /// <summary>
        /// 提醒索引
        /// </summary>
        public string GtdId { get; set; }
        /// <summary>
        /// 提醒备注
        /// </summary>
        public string GtdMemo { get; set; }
        /// <summary>
        /// 相关说明
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 访问日期
        /// </summary>
        public string VisitDate { get; set; }
        /// <summary>
        /// 加密版本
        /// </summary>
        public string CipherVer { get; set; }

        /// <summary>
        /// 加密口令
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 定时任务
        /// </summary>
        public GtdHeader GtdHeader { get; set; }

        /// <summary>
        /// 是否备份
        /// </summary>
        public bool Backup { get; set; }

        /// <summary>
        /// 是否更新
        /// </summary>
        public bool IsUpdate { get { return _IsUpdate; } }
        private bool _IsUpdate;

        public bool Modified { get; set; }
        public Image Icon { get; set; }
        public Image Hint { get; set; }

        #region 接口实现
        public override bool Load(DataRow row)
        {
            Id = row[DBConst.APWD0105] as string;
            Order = (int)row[DBConst.APWD0101];
            Label = (int)row[DBConst.APWD0102];
            Major = (int)row[DBConst.APWD0103];
            CatId = row[DBConst.APWD0106] as string;
            RegDate = row[DBConst.APWD0107] as string;
            LibId = row[DBConst.APWD0108] as string;
            Title = row[DBConst.APWD0109] as string;
            MetaKey = row[DBConst.APWD010A] as string;
            IcoName = row[DBConst.APWD010B] as string;
            IcoPath = row[DBConst.APWD010C] as string;
            IcoMemo = row[DBConst.APWD010D] as string;
            GtdId = row[DBConst.APWD010E] as string;
            GtdMemo = row[DBConst.APWD010F] as string;
            Memo = row[DBConst.APWD0110] as string;

            VisitDate = row[DBConst.APWD0111] as string;
            Backup = (string)row[DBConst.APWD0112] == "t";
            CipherVer = row[DBConst.APWD0113] as string;

            _IsUpdate = true;
            Modified = false;

            return true;
        }

        public override bool Read(DBAccess dba, string Id)
        {
            return true;
        }

        public override bool Save(DBAccess dba, bool update)
        {
            return true;
        }
        #endregion

        /// <summary>
        /// 恢复默认值
        /// </summary>
        public void SetDefault()
        {
            Id = null;
            Order = 0;
            Label = 0;
            Major = 0;
            CatId = null;
            RegDate = null;
            LibId = null;
            Title = null;
            MetaKey = null;
            IcoName = null;
            IcoPath = null;
            IcoMemo = null;
            GtdId = null;
            GtdMemo = null;
            Memo = null;
            VisitDate = null;
            CipherVer = null;

            Password = null;
            GtdHeader = null;

            _IsUpdate = false;
            Backup = true;
            Modified = false;
        }

        public override string ToString()
        {
            return Title;
        }

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
                writer.WriteElementString("RegDate", RegDate);
                writer.WriteElementString("LibId", LibId);
                writer.WriteElementString("Title", Title);
                writer.WriteElementString("MetaKey", MetaKey);
                writer.WriteElementString("IcoName", IcoName);
                writer.WriteElementString("IcoPath", IcoPath);
                writer.WriteElementString("IcoMemo", IcoMemo);
                writer.WriteElementString("GtdId", GtdId);
                writer.WriteElementString("GtdMemo", GtdMemo);
                writer.WriteElementString("Memo", Memo);
                writer.WriteElementString("VisitDate", VisitDate);
                writer.WriteElementString("CipherVer", CipherVer);
                writer.WriteElementString("Backup", Backup ? "true" : "false");
                writer.WriteElementString("Password", Password);

                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.Flush();
            }
            return buffer.Replace("utf-16", "utf-8").ToString();
        }

        public void FromXml(XmlReader reader)
        {
            if (reader == null)
            {
                return;
            }

            if (reader.Name == "Id" || reader.ReadToNextSibling("Id"))
            {
                Id = reader.ReadElementContentAsString();
            }
            Order = reader.ReadElementContentAsInt();
            Label = reader.ReadElementContentAsInt();
            Major = reader.ReadElementContentAsInt();
            CatId = reader.ReadElementContentAsString();
            RegDate = reader.ReadElementContentAsString();
            LibId = reader.ReadElementContentAsString();
            Title = reader.ReadElementContentAsString();
            MetaKey = reader.ReadElementContentAsString();
            IcoName = reader.ReadElementContentAsString();
            IcoPath = reader.ReadElementContentAsString();
            IcoMemo = reader.ReadElementContentAsString();
            GtdId = reader.ReadElementContentAsString();
            GtdMemo = reader.ReadElementContentAsString();
            Memo = reader.ReadElementContentAsString();
            VisitDate = reader.ReadElementContentAsString();
            CipherVer = reader.ReadElementContentAsString();
        }
    }
}

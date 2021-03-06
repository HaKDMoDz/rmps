﻿
using System.IO;
using System.Text;
using System.Xml;
namespace Me.Amon
{
    public class Key
    {
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
        public MgtdHeader GtdHeader { get; set; }

        /// <summary>
        /// 是否备份
        /// </summary>
        public bool Backup { get; set; }

        private bool _IsUpdate;
        public bool IsUpdate { get { return _IsUpdate; } }
        public bool Modified { get; set; }

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

            Backup = true;
            _IsUpdate = false;
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
            Id = reader.ReadElementContentAsString();
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

            _IsUpdate = true;
        }
    }
}

﻿using System;
using System.Xml;

namespace Me.Amon.M
{
    /// <summary>
    /// 
    /// </summary>
    public class Udc : Vcs
    {
        public int Order { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 简短提示
        /// </summary>
        public string Tips { get; set; }
        /// <summary>
        /// 字符空间
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 相关说明
        /// </summary>
        public string Memo { get; set; }

        [NonSerialized]
        public bool IsSys;

        #region 方法重写
        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Udc)
            {
                return Id == ((Udc)obj).Id;
            }
            if (obj is string)
            {
                return Id == (string)obj;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id != null ? Id.GetHashCode() : 0;
        }
        #endregion

        public override bool FromXml(XmlReader reader)
        {
            if (reader == null || reader.Name != "Udc" || !reader.IsStartElement())
            {
                return false;
            }

            if (reader.Name == "Order" || reader.ReadToDescendant("Order"))
            {
                Order = reader.ReadElementContentAsInt();
            }
            if (reader.Name == "Id" || reader.ReadToNextSibling("Id"))
            {
                Id = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Name" || reader.ReadToNextSibling("Name"))
            {
                Name = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Tips" || reader.ReadToNextSibling("Tips"))
            {
                Tips = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Data" || reader.ReadToNextSibling("Data"))
            {
                Data = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Memo" || reader.ReadToNextSibling("Memo"))
            {
                Data = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Udc" && reader.NodeType == XmlNodeType.EndElement)
            {
                reader.ReadEndElement();
            }
            return true;
        }

        public override bool ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Udc");

            writer.WriteElementString("Order", Order.ToString());
            writer.WriteElementString("Id", Id);
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Tips", Tips);
            writer.WriteElementString("Data", Data);
            writer.WriteElementString("Memo", Memo);

            writer.WriteEndElement();

            return true;
        }
    }
}

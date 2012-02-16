﻿using System.Collections.Generic;
using System.Data;
using System.Xml;
using Me.Amon.Da;

namespace Me.Amon.Model
{
    public class LibHeader : Vcs
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Memo { get; set; }

        public List<LibDetail> Details { get; set; }

        public LibHeader()
        {
            Details = new List<LibDetail>();
        }

        #region 接口实现
        public override bool Load(DataRow row)
        {
            Id = row[DBConst.APWD0304] as string;
            Name = row[DBConst.APWD0306] as string;
            Memo = row[DBConst.APWD0308] as string;

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

        #region 方法重写
        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is string)
            {
                string id = obj as string;
                return Id == id;
            }
            if (obj is LibHeader)
            {
                LibHeader header = obj as LibHeader;
                return Id == header.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        #endregion

        public bool FromXml(XmlReader reader)
        {
            if (reader == null)
            {
                return false;
            }
            if (reader.Name == "Id" || reader.ReadToFollowing("Id"))
            {
                Id = reader.ReadElementContentAsString();
                Name = reader.ReadElementContentAsString();
                Memo = reader.ReadElementContentAsString();
                return true;
            }
            return false;
        }

        public void ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Lib");

            writer.WriteElementString("Id", Id);
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Memo", Memo);

            writer.WriteStartElement("Items");
            foreach (LibDetail detail in Details)
            {
                detail.ToXml(writer);
            }
            writer.WriteEndElement();

            writer.WriteEndElement();
        }
    }
}

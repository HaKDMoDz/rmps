using System.Collections.Generic;
using System.Data;
using System.Xml;
using Me.Amon.Da;
using Me.Amon.Util;

namespace Me.Amon.Model
{
    public class Cat : Vcs
    {
        public int Order { get; set; }
        /// <summary>
        /// 用户代码
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 类别索引
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 上级索引
        /// </summary>
        public string Parent { get; set; }
        /// <summary>
        /// 类别图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 类别提示
        /// </summary>
        public string Tips { get; set; }
        /// <summary>
        /// 类别键值
        /// </summary>
        public string Meta { get; set; }
        /// <summary>
        /// 类别说明
        /// </summary>
        public string Memo { get; set; }

        #region 接口实现
        public override bool Load(DataRow row)
        {
            Order = (int)row[DBConst.ACAT0201];
            Id = row[DBConst.ACAT0203] as string;
            Parent = row[DBConst.ACAT0204] as string;
            Text = row[DBConst.ACAT0205] as string;
            Tips = row[DBConst.ACAT0206] as string;
            Icon = row[DBConst.ACAT0207] as string;
            Meta = row[DBConst.ACAT0208] as string;
            Memo = row[DBConst.ACAT0209] as string;

            return true;
        }

        public override bool Read(DBAccess dba, string Id)
        {
            return true;
        }

        public override bool Save(DBAccess dba, bool update)
        {
            dba.ReInit();
            dba.AddTable(DBConst.ACAT0200);
            dba.AddParam(DBConst.ACAT0201, Order);
            dba.AddParam(DBConst.ACAT0204, Parent);
            dba.AddParam(DBConst.ACAT0205, Text);
            dba.AddParam(DBConst.ACAT0206, Tips);
            dba.AddParam(DBConst.ACAT0207, Icon);
            dba.AddParam(DBConst.ACAT0208, Meta);
            dba.AddParam(DBConst.ACAT0209, Memo);
            dba.AddParam(DBConst.ACAT020A, DBConst.SQL_NOW, false);

            if (update)
            {
                dba.AddWhere(DBConst.ACAT0202, UserCode);
                dba.AddWhere(DBConst.ACAT0203, Id);
                dba.AddVcs(DBConst.ACAT020C, DBConst.ACAT020D, Operate, Cat.OPT_UPDATE);
                return 1 == dba.ExecuteUpdate();
            }

            dba.AddParam(DBConst.ACAT0202, UserCode);
            dba.AddParam(DBConst.ACAT0203, Id);
            dba.AddParam(DBConst.ACAT020B, DBConst.SQL_NOW, false);
            dba.AddVcs(DBConst.ACAT020C, DBConst.ACAT020D);
            return 1 == dba.ExecuteInsert();
        }
        #endregion

        #region 方法重写
        public override string ToString()
        {
            return Text;
        }
        #endregion

        public bool FromXml(XmlNode root)
        {
            if (root.Name != "Cat")
            {
                return false;
            }

            foreach (XmlNode node in root.ChildNodes)
            {
                if (node == null)
                {
                    continue;
                }
                if (node.Name == "Order")
                {
                    if (CharUtil.IsValidateLong(node.InnerText))
                    {
                        Order = int.Parse(node.InnerText);
                    }
                    continue;
                }
                if (node.Name == "Id")
                {
                    if (CharUtil.IsValidateHash(node.InnerText))
                    {
                        Id = node.InnerText;
                    }
                    continue;
                }
                if (node.Name == "Parent")
                {
                    if (CharUtil.IsValidateHash(node.InnerText))
                    {
                        Parent = node.InnerText;
                    }
                }
                if (node.Name == "Text")
                {
                    if (CharUtil.IsValidate(node.InnerText))
                    {
                        Text = node.InnerText;
                    }
                }
                if (node.Name == "Tips")
                {
                    Tips = node.InnerText;
                }
                if (node.Name == "Icon")
                {
                    if (CharUtil.IsValidateHash(node.InnerText))
                    {
                        Icon = node.InnerText;
                    }
                }
                if (node.Name == "Meta")
                {
                    Meta = node.InnerText;
                }
                if (node.Name == "Memo")
                {
                    Memo = node.InnerText;
                }
            }
            return true;
        }

        public void ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Cat");

            writer.WriteElementString("Order", Order.ToString());
            writer.WriteElementString("Id", Id);
            writer.WriteElementString("Parent", Parent);
            writer.WriteElementString("Text", Text);
            writer.WriteElementString("Tips", Tips);
            writer.WriteElementString("Icon", Icon);
            writer.WriteElementString("Meta", Meta);
            writer.WriteElementString("Memo", Memo);

            writer.WriteEndElement();
        }
    }
}

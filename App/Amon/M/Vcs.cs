using System;
using System.Xml;

namespace Me.Amon.M
{
    public abstract class Vcs
    {
        public const int OPT_CONFUSE = -2;
        public const int OPT_DELETE = -1;
        public const int OPT_INSERT = 0;
        public const int OPT_DEFAULT = 1;
        public const int OPT_UPDATE = 2;

        /// <summary>
        /// 索引
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 用户代码
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// 当前操作
        /// </summary>
        public int Operate { get; set; }

        /// <summary>
        /// 版本控制
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is string)
            {
                return Id == (string)obj;
            }
            if (obj is Vcs)
            {
                return Id == ((Vcs)obj).Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id != null ? Id.GetHashCode() : 0;
        }

        public static string Attribute(XmlNode node, string name, string value)
        {
            if (node == null)
            {
                return value;
            }
            XmlAttribute attr = node.Attributes[name];
            return attr != null ? attr.InnerText : value;
        }
    }
}

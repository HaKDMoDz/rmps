using System;
using System.Drawing;
using Me.Amon.M;

namespace Me.Amon.Pcs.M
{
    public class MPcs : Vcs
    {
        /// <summary>
        /// 服务器类型
        /// </summary>
        public string ServerType;

        [NonSerialized]
        public string ServerName;

        /// <summary>
        /// 服务徽标
        /// </summary>
        public string ServerLogo;

        [NonSerialized]
        public Image Logo;

        /// <summary>
        /// 用户索引
        /// </summary>
        public string UserId;

        /// <summary>
        /// 显示名称
        /// </summary>
        public string UserName;

        /// <summary>
        /// 本地路径
        /// </summary>
        public string LocalRoot;

        /// <summary>
        /// 应用授权
        /// </summary>
        public string Token;

        public string TokenSecret;

        public override bool FromXml(System.Xml.XmlReader reader)
        {
            return true;
        }

        public override bool ToXml(System.Xml.XmlWriter writer)
        {
            return true;
        }

        public override string ToString()
        {
            return ServerName;
        }
    }
}

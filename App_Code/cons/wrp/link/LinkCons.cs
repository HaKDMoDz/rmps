using System;

namespace cons.wrp.link
{
    /// <summary>
    /// Summary description for LinkCons
    /// </summary>
    public class LinkCons
    {
        private LinkCons()
        {
        }

        public const String LINK_HASH = "13070000";

        /// <summary>
        /// 用户类别
        /// </summary>
        public const String LINK_USER_HASH = "sctfszxeayexzebw";

        /// <summary>
        /// 搜索引擎
        /// </summary>
        public const String LINK_SRCH_HASH = "sctfzgewbfxcqszc";

        /// <summary>
        /// 门户网站
        /// </summary>
        public const String LINK_PORT_HASH = "sctvbtevtwdsrwqd";

        /// <summary>
        /// 友情链接
        /// </summary>
        public const String LINK_SITE_HASH = "sctvqrsegrxcbgvz";

        /// <summary>
        /// 正常状态
        /// </summary>
        public const int LINK_STAT_NORMAL = 0;
        /// <summary>
        /// 删除状态
        /// </summary>
        public const int LINK_STAT_DELETE = 1;

        /// <summary>
        /// 导航图标路径
        /// </summary>
        public const string LINK_ICON_PATH = EnvCons.DIR_DAT + "link/";
    }
}

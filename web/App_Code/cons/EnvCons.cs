using System;

namespace cons
{
    /// <summary>
    /// EnvCons 的摘要说明
    /// </summary>
    public class EnvCons
    {
        private static string pre;
        private static string dev;
        private static string uri;

        private EnvCons()
        {
        }

        /// <summary>
        /// 开发环境路径前缀
        /// </summary>
        public static string PRE_URL
        {
            get
            {
                if (pre == null)
                {
                    pre = System.Configuration.ConfigurationManager.AppSettings["pre"];
                }
                return pre;
            }
        }

        /// <summary>
        /// 网页精灵是否需要每次读取模板文档，发布时应当为false;
        /// </summary>
        public static bool NET_DEV
        {
            get
            {
                if (dev == null)
                {
                    dev = System.Configuration.ConfigurationManager.AppSettings["dev"];
                }
                return "true" == dev;
            }
        }

        /// <summary>
        /// 数据库连接方式
        /// </summary>
        public static String SQL_URL
        {
            get
            {
                if (uri == null)
                {
                    uri = string.Format("server={0};uid=winshine;pwd={1};database=winshine;charset=utf8",
                        System.Configuration.ConfigurationManager.AppSettings["uri"],
                        System.Configuration.ConfigurationManager.AppSettings["key"]);
                }
                return uri;
            }
        }

        /// <summary>
        /// 数据取当前时间的方法
        /// </summary>
        public const String SQL_NOW = "NOW()";

        public const String DIR_DAT = "~/data/";
        public const String DIR_BAK = "~/back/";
        public const String DIR_TMP = "~/temp/";

        public const String HOST_BLOG = "amonsoft.com";
        public const String SITE_BLOG = "http://amonsoft.com/";

        public const String HOST_SOFT = "amonsoft.net";
        public const String SITE_SOFT = "http://amonsoft.net/";

        public const String HOST_CORP = "winshine.biz";
        public const String SITE_CORP = "http://winshine.biz/";

        public const String HOST_MPWD = "magicpwd.com";
        public const String SITE_MPWD = "http://magicpwd.com/";
    }
}
namespace Me.Amon
{
    public class IEnv
    {
        /// <summary>
        /// 默认数据目录
        /// </summary>
        public const string DATA_DIR = "DAT";
        /// <summary>
        /// 图标大小
        /// </summary>
        public const int ICON_DIM = 32;
        /// <summary>
        /// 系统日期格式
        /// </summary>
        public const string DATEIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
        
        /// <summary>
        /// 服务器路径
        /// </summary>
        /// public const string SERVER_PATH = "http://mpwd.sinaapp.com/s.php";
        public const string SERVER_PATH = "http://localhost:65169/s.ashx";
        /// <summary>
        /// 服务器类型
        /// </summary>
        public const string SERVER_TYPE = "NET";

        /// <summary>
        /// 系统配置数据
        /// </summary>
        public const string AMON_SYS = "Amon.sys";
        public const string AMON_SYS_CODE = "amon.{0}.code";
        public const string AMON_SYS_HOME = "amon.{0}.home";

        /// <summary>
        /// 用户配置数据
        /// </summary>
        public const string AMON_CFG = "Amon.cfg";
        public const string USER_CFG = "User.cfg";
        public const string AMON_CFG_NAME = "amon.name";
        public const string AMON_CFG_CODE = "amon.code";
        public const string AMON_CFG_INFO = "amon.info";
        public const string AMON_CFG_DATA = "amon.data";
        public const string AMON_CFG_LOOK = "amon.look";
        public const string AMON_CFG_FEEL = "amon.feel";

        /// <summary>
        /// 系统应用
        /// </summary>
        public const int IAPP_NONE = 0;
        public const int IAPP_APWD = 1;
        public const int IAPP_ASEC = 2;

        /// <summary>
        /// 视图类型
        /// </summary>
        public const int KEY_APWD = 0x1;
        public const int KEY_AWIZ = 0x2;
        public const int KEY_APAD = 0x4;

        /// <summary>
        /// 加密文件
        /// </summary>
        public const string FILE_ACF = ".acf";
        /// <summary>
        /// 视图文件
        /// </summary>
        public const string FILE_FEEL = ".asf";
        /// <summary>
        /// 风格文件
        /// </summary>
        public const string FILE_LOOK = ".asl";
    }
}

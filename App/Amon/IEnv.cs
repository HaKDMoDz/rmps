namespace Me.Amon
{
    public class IEnv
    {
        /// <summary>
        /// 默认数据目录
        /// </summary>
        public const string DATA_DIR = "Dat";
        /// <summary>
        /// 
        /// </summary>
        public const string FILE_LOG = "Amon.log";
        public const string FILE_DB = "Amon.db3";
        /// <summary>
        /// 系统日期格式
        /// </summary>
        public const string DATEIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 服务器路径
        /// </summary>
        //public const string SERVER_PATH = "http://amon.me/s.ashx";
        public const string SERVER_PATH = "http://localhost:49587/s.ashx";
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
        public const string AMON_CFG_DATA = "amon.data";
        public const string AMON_CFG_INFO = "amon.info";
        public const string AMON_CFG_LOCK = "amon.lock";
        public const string AMON_CFG_MAIN = "amon.main";
        public const string AMON_CFG_SAFE = "amon.safe";
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

        public const string FILE_IMG = "图像文件|*.png;*.jpg;*.gif;*.bmp|PNG文件|*.png|JPG文件|*.jpg|BMP文件|*.bmp";
        /// <summary>
        /// 加密文件
        /// </summary>
        public const string FILE_ACF = ".acf";
        /// <summary>
        /// 视图文件
        /// </summary>
        public const string FILE_FEEL = "feel.asf";
        /// <summary>
        /// 风格文件
        /// </summary>
        public const string FILE_LOOK = "look.asl";

        public const string VALUE_TRUE = "true";
        public const string VALUE_FALSE = "false";

        public const string USER_AMON = "A0000000";
        public const string USER_DEMO = "A0000010";
        public const string USER_TEST = "A0000020";

        public const int IMG_KEY_EDIT_DIM = 16;
        public const string IMG_KEY_EDIT_EXT = ".16";

        public const int IMG_KEY_LIST_DIM = 24;
        public const string IMG_KEY_LIST_EXT = ".24";
    }
}

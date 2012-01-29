namespace Me.Amon
{
    public class IEnv
    {
        public const string DATA_DIR = "dat";
        public const int ICON_DIM = 32;
        public const string DATEIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
        //public const string SERVER_PATH = "http://mpwd.sinaapp.com/s.php";
        public const string SERVER_PATH = "http://localhost:65169/s.ashx";
        public const string SERVER_TYPE = "NET";

        public const int KEY_APWD = 0x1;
        public const int KEY_AWIZ = 0x2;
        public const int KEY_APAD = 0x3;

        public const string AMON_CFG = "Amon.cfg";
        public const string USER_CFG = "User.cfg";

        public const int IAPP_NONE = 0;
        public const int IAPP_APWD = 1;
        public const int IAPP_ASEC = 2;

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

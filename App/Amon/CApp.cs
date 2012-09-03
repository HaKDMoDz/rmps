namespace Me.Amon
{
    public class CApp
    {
        public const int PATTERN_LOGO = 0;
        public const int PATTERN_TRAY = 1;

        public const int SEC_NONE = 0;
        public const int SEC_BASE64 = 1;
        public const int SEC_AES = 2;

        public const string VER_DB = "1";

        /// <summary>
        /// 默认数据目录
        /// </summary>
        public const string DIR_DATA = "Dat";
        public const string DIR_BACK = "Bak";
        /// <summary>
        /// 
        /// </summary>
        public const string FILE_LOG = "Amon.log";
        public const string FILE_DB = "Amon.dbo";
        /// <summary>
        /// 系统日期格式
        /// </summary>
        public const string DATEIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 服务器路径
        /// </summary>
        public const string SERVER_PATH = "http://amon.me/s.ashx";
        //public const string SERVER_PATH = "http://localhost:49587/s.ashx";

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
        public const string IAPP_NONE = "";
        public const string IAPP_APWD = "apwd";
        public const string IAPP_ASEC = "asec";
        public const string IAPP_ABAR = "abar";
        public const string IAPP_AREN = "aren";
        public const string IAPP_AICO = "aico";
        public const string IAPP_AIMG = "aimg";
        public const string IAPP_ASPY = "aspy";
        public const string IAPP_ASQL = "asql";

        public const string FILE_OPEN_ALL = "所有文件|*.*";
        public const string FILE_OPEN_IMG = "图片文件（*.png,*.jpg,*.bmp）|*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.dib;*.rle|PNG文件（*.png）|*.png|JPG文件（*.jpg,*.jpeg,*.jpe,*.jfif）|*.jpg;*.jpeg;*.jpe;*.jfif|BMP文件（*.bmp,*dib,*.rle）|*.bmp;*.dib;*.rle";
        public const string FILE_OPEN_IMG_GIF = "图片文件（*.png,*.jpg,*.bmp,*.gif）|*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.dib;*.rle;*.gif|PNG文件（*.png）|*.png|JPG文件（*.jpg,*.jpeg,*.jpe,*.jfif）|*.jpg;*.jpeg;*.jpe;*.jfif|BMP文件（*.bmp,*dib,*.rle）|*.bmp;*.dib;*.rle|GIF文件（*.gif）|*.gif";
        public const string FILE_OPEN_IMG_ICO = "图片文件（*.png,*.jpg,*.bmp,*.ico）|*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.dib;*.rle;*.ico|PNG文件（*.png）|*.png|JPG文件（*.jpg,*.jpeg,*.jpe,*.jfif）|*.jpg;*.jpeg;*.jpe;*.jfif|BMP文件（*.bmp,*dib,*.rle）|*.bmp;*.dib;*.rle|ICO文件（*.ico）|*.ico";
        public const string FILE_OPEN_IMG_RES = "图片文件（*.png,*.jpg,*.bmp,*.ico,*.exe,*.dll）|*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.dib;*.rle;*.ico;*.icl;*.dll;*.exe;*.ocx;*.cpl;*.src|PNG文件（*.png）|*.png|JPG文件（*.jpg,*.jpeg,*.jpe,*.jfif）|*.jpg;*.jpeg;*.jpe;*.jfif|BMP文件（*.bmp,*dib,*.rle）|*.bmp;*.dib;*.rle|ICO文件（*.ico）|*.ico|ICL文件（*.icl）|*.icl|DLL文件（*.dll）|*.dll|EXE文件（*.exe）|*.exe|OCX文件（*.ocx）|*.ocx|CPL文件（*.cpl）|*.cpl|SRC文件（*.src）|*.src";
        public const string FILE_OPEN_RES = "资源文件|*.ico;*.icl;*.dll;*.exe;*.ocx;*.cpl;*.src|ICO文件（*.ico）|*.ico|ICL文件（*.icl）|*.icl|DLL文件（*.dll）|*.dll|EXE文件（*.exe）|*.exe|OCX文件（*.ocx）|*.ocx|CPL文件（*.cpl）|*.cpl|SRC文件（*.src）|*.src";
        public const string FILE_SAVE_ALL = "所有文件|*.*";
        public const string FILE_SAVE_PNG = "图片文件（*.png）|*.png";
        public const string FILE_SAVE_ICO = "图标文件（*.ico）|*.ico";
        public const string FILE_SAVE_ICL = "图集文件（*.icl）|*.icl";
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

        public const string LIB_CARD = "qqqqqaavaqdfscdv";

        public const int EMOTION_EYE = 0;
        public const int EMOTION_ICO = 1;
    }
}

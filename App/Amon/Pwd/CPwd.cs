namespace Me.Amon.Pwd
{
    public class CPwd
    {
        public const string APP_KEY = "WPwd";

        public const string DEF_CAT_ID = "0";
        public const string DEF_CAT_IMG = "0";

        public const string PATTERN_PRO = "pro";

        public const string PATTERN_WIZ = "wiz";

        public const string PATTERN_PAD = "pad";

        public const string PATTERN_INF = "inf";

        public const string KEY_LABEL = "key-label";
        public const string KEY_MAJOR = "key-major";

        /// <summary>
        /// 菜单配置文件
        /// </summary>
        public const string XML_MENU = "WPwd.xml";

        #region 视图风格
        /// <summary>
        /// 视图类型
        /// </summary>
        public const int KEY_APRO = 0x1;
        public const int KEY_AWIZ = 0x2;
        public const int KEY_APAD = 0x4;
        #endregion

        #region 界面布局
        /// <summary>
        /// 紧凑视图
        /// </summary>
        public const int LAYOUT_STYLE_0 = 0;
        /// <summary>
        /// 未知
        /// </summary>
        public const int LAYOUT_STYLE_1 = 1;
        /// <summary>
        /// 三列视图
        /// </summary>
        public const int LAYOUT_STYLE_2 = 2;
        #endregion

        #region 窗口状态
        public const int WINDOW_STATE_NORMAL = 0;
        public const int WINDOW_STATE_MINIMIZED = 1;
        public const int WINDOW_STATE_MAXIMIZED = 2;
        #endregion

        #region 特殊目录键值
        public const string TAG_MAIL = "mail";
        public const string TAG_LINK = "link";
        public const string TAG_NOTE = "note";
        public const string TAG_TASK = "task";
        public const string TAG_TASK_VAR = TAG_TASK + ":";
        public const string TAG_TASK_VAL_EXPIRED = TAG_TASK + ":expired";
        #endregion
    }
}

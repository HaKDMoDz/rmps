namespace com.magickms.api.Enum
{
    public enum WindowMessage : int
    {
        /// <summary>
        /// 设置文本
        /// </summary>
        WM_SETTEXT = 0x000C,
        /// <summary>
        /// 获取文本
        /// </summary>
        WM_GETTEXT = 0x000D,
        /// <summary>
        /// 获取文本长度
        /// </summary>
        WM_GETTEXTLENGTH = 0x000E,
        /// <summary>
        /// 按钮压下
        /// </summary>
        WM_LBUTTONDOWN = 0x0201,
        /// <summary>
        /// 按钮松起
        /// </summary>
        WM_LBUTTONUP = 0x0202,
        /// <summary>
        /// 关闭
        /// </summary>
        WM_CLOSE = 0x0010,
        WM_KEYDOWN = 0X100,
        WM_KEYUP = 0X101,
        WM_SYSCHAR = 0X106,
        WM_SYSKEYUP = 0X105,
        WM_SYSKEYDOWN = 0X104,
        WM_CHAR = 0X102,
        WM_CUT = 0x0300,
        WM_COPY = 0x0301,
        WM_PASTE = 0x0302,
        WM_CLEAR = 0x0303
    }
}

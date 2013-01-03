namespace Me.Amon.Api.Enums
{
    public enum WindowLongFlags : int
    {
        /// <summary>
        /// 扩展窗口样式
        /// </summary>
        GWL_EXSTYLE = -20,
        /// <summary>
        /// 拥有窗口的实例的句柄
        /// </summary>
        GWLP_HINSTANCE = -6,
        /// <summary>
        /// 该窗口之父的句柄。不要用SetWindowWord来改变这个值
        /// </summary>
        GWLP_HWNDPARENT = -8,
        /// <summary>
        /// 对话框中一个子窗口的标识符
        /// </summary>
        GWL_ID = -12,
        /// <summary>
        /// 窗口样式
        /// </summary>
        GWL_STYLE = -16,
        /// <summary>
        /// 含义由应用程序规定
        /// </summary>
        GWL_USERDATA = -21,
        /// <summary>
        /// 该窗口的窗口函数的地址
        /// </summary>
        GWL_WNDPROC = -4,
        /// <summary>
        /// 含义由应用程序规定
        /// </summary>
        DWLP_USER = 0x8,
        /// <summary>
        /// 在对话框函数中处理的一条消息返回的值
        /// </summary>
        DWLP_MSGRESULT = 0x0,
        /// <summary>
        /// 这个窗口的对话框函数地址
        /// </summary>
        DWLP_DLGPROC = 0x4
    }
}

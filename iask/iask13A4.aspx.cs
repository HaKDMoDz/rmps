using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.wrp;

public partial class iask_iask13A4 : Page
{
    // K: 属性名称
    // V1:属性简介
    // V2:显示类型
    // V3:对应类型下的默认值
    protected ArrayList spcProp = new ArrayList(6);
    protected ArrayList w3cName = new ArrayList(6);
    protected ArrayList w3cProp = new ArrayList(6);

    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "浏览器信息";
        Session[cons.wrp.WrpCons.SCRIPTID] = "iask13A4";

        List<K1V2> guidList = Wrps.GuidIask(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/iask/iask13A4.aspx";
        guidItem.V1 = "浏览器信息";
        guidItem.V2 = "浏览器信息";

        if (IsPostBack)
        {
            return;
        }

        // W3C标准属性
        //window
        ArrayList list = new ArrayList();
        w3cProp.Add(list);
        w3cName.Add("window属性：");
        list.Add(new K1V3("closed", "text", "window.closed", "返回窗口是否已被关闭。"));
        list.Add(new K1V3("defaultStatus", "text", "window.defaultStatus", "设置或返回窗口状态栏中的默认文本。"));
        list.Add(new K1V3("document", "link", "#a1", "对 Document 对象的只读引用。请参阅 Document 对象。"));
        list.Add(new K1V3("history", "link", "#a5", "对 History 对象的只读引用。请参数 History 对象。"));
        list.Add(new K1V3("innerheight", "text", "window.innerheight", "返回窗口的文档显示区的高度。"));
        list.Add(new K1V3("innerwidth", "text", "window.innerwidth", "返回窗口的文档显示区的宽度。"));
        list.Add(new K1V3("length", "text", "window.length", "设置或返回窗口中的框架数量。"));
        list.Add(new K1V3("location", "link", "#a4", "用于窗口或框架的 Location 对象。请参阅 Location 对象。"));
        list.Add(new K1V3("name", "text", "window.name", "设置或返回窗口的名称。"));
        list.Add(new K1V3("navigator", "link", "#a2", "对 Navigator 对象的只读引用。请参数 Navigator 对象。"));
        list.Add(new K1V3("opener", "text", "window.opener", "返回对创建此窗口的窗口的引用。"));
        list.Add(new K1V3("outerheight", "text", "window.outerheight", "返回窗口的外部高度。"));
        list.Add(new K1V3("outerwidth", "text", "window.outerwidth", "返回窗口的外部宽度。"));
        list.Add(new K1V3("pageXOffset", "text", "window.pageXOffset", "设置或返回当前页面相对于窗口显示区左上角的 X 位置。"));
        list.Add(new K1V3("pageYOffset", "text", "window.pageYOffset", "设置或返回当前页面相对于窗口显示区左上角的 Y 位置。"));
        list.Add(new K1V3("parent", "text", "window.parent", "返回父窗口。"));
        list.Add(new K1V3("screen", "link", "#a3", "对 Screen 对象的只读引用。请参数 Screen 对象。"));
        list.Add(new K1V3("self", "link", "#a0", "返回对当前窗口的引用。等价于 Window 属性。"));
        list.Add(new K1V3("status", "text", "window.status", "设置窗口状态栏的文本。"));
        list.Add(new K1V3("top", "text", "window.top", "返回最顶层的先辈窗口。"));
        list.Add(new K1V3("window", "link", "#a0", "window 属性等价于 self 属性，它包含了对窗口自身的引用。"));

        //document
        list = new ArrayList();
        w3cProp.Add(list);
        w3cName.Add("document属性：");
        list.Add(new K1V3("body", "text", "document.body", "提供对 &lt;body&gt; 元素的直接访问。对于定义了框架集的文档，该属性引用最外层的 &lt;frameset&gt;。"));
        list.Add(new K1V3("cookie", "text", "document.cookie", "设置或返回与当前文档有关的所有 cookie。"));
        list.Add(new K1V3("domain", "text", "document.domain", "返回当前文档的域名。"));
        list.Add(new K1V3("lastModified", "text", "document.lastModified", "返回文档被最后修改的日期和时间。"));
        list.Add(new K1V3("referrer", "text", "document.referrer", "返回载入当前文档的文档的 URL。"));
        list.Add(new K1V3("title", "text", "document.title", "返回当前文档的标题。"));
        list.Add(new K1V3("URL", "text", "document.URL", "返回当前文档的 URL。"));

        //navigator
        list = new ArrayList();
        w3cProp.Add(list);
        w3cName.Add("navigator属性：");
        list.Add(new K1V3("appCodeName", "text", "navigator.appCodeName", "返回浏览器的代码名。"));
        list.Add(new K1V3("appMinorVersion", "text", "navigator.appMinorVersion", "返回浏览器的次级版本。"));
        list.Add(new K1V3("appName", "text", "navigator.appName", "返回浏览器的名称。"));
        list.Add(new K1V3("appVersion", "text", "navigator.appVersion", "返回浏览器的平台和版本信息。"));
        list.Add(new K1V3("browserLanguage", "text", "navigator.browserLanguage", "返回当前浏览器的语言。"));
        list.Add(new K1V3("cookieEnabled", "text", "navigator.cookieEnabled", "返回指明浏览器中是否启用 cookie 的布尔值。"));
        list.Add(new K1V3("cpuClass", "text", "navigator.cpuClass", "返回浏览器系统的 CPU 等级。"));
        list.Add(new K1V3("onLine", "text", "navigator.onLine", "返回指明系统是否处于脱机模式的布尔值。"));
        list.Add(new K1V3("platform", "text", "navigator.platform", "返回运行浏览器的操作系统平台。"));
        list.Add(new K1V3("systemLanguage", "text", "navigator.systemLanguage", "返回 OS 使用的默认语言。"));
        list.Add(new K1V3("userAgent", "text", "navigator.userAgent", "返回由客户机发送服务器的 user-agent 头部的值。"));
        list.Add(new K1V3("userLanguage", "text", "navigator.userLanguage", "返回 OS 的自然语言设置。"));

        // screen
        list = new ArrayList();
        w3cProp.Add(list);
        w3cName.Add("screen属性：");
        list.Add(new K1V3("availHeight", "text", "screen.availHeight", "返回显示屏幕的高度 (除 Windows 任务栏之外)。"));
        list.Add(new K1V3("availWidth", "text", "screen.availWidth", "返回显示屏幕的宽度 (除 Windows 任务栏之外)。"));
        list.Add(new K1V3("bufferDepth", "text", "screen.bufferDepth", "设置或返回在 off-screen bitmap buffer 中调色板的比特深度。"));
        list.Add(new K1V3("colorDepth", "text", "screen.colorDepth", "返回目标设备或缓冲器上的调色板的比特深度。"));
        list.Add(new K1V3("deviceXDPI", "text", "screen.deviceXDPI", "返回显示屏幕的每英寸水平点数。"));
        list.Add(new K1V3("deviceYDPI", "text", "screen.deviceYDPI", "返回显示屏幕的每英寸垂直点数。"));
        list.Add(new K1V3("fontSmoothingEnabled", "text", "screen.fontSmoothingEnabled", "返回用户是否在显示控制面板中启用了字体平滑。"));
        list.Add(new K1V3("height", "text", "screen.height", "返回显示屏幕的高度。"));
        list.Add(new K1V3("logicalXDPI", "text", "screen.logicalXDPI", "返回显示屏幕每英寸的水平方向的常规点数。"));
        list.Add(new K1V3("logicalYDPI", "text", "screen.logicalYDPI", "返回显示屏幕每英寸的垂直方向的常规点数。"));
        list.Add(new K1V3("pixelDepth", "text", "screen.pixelDepth", "返回显示屏幕的颜色分辨率（比特每像素）。"));
        list.Add(new K1V3("updateInterval", "text", "screen.updateInterval", "设置或返回屏幕的刷新率。"));
        list.Add(new K1V3("width", "text", "screen.width", "返回显示器屏幕的宽度。"));

        // location
        list = new ArrayList();
        w3cProp.Add(list);
        w3cName.Add("location属性：");
        list.Add(new K1V3("hash", "text", "location.hash", "设置或返回从井号 (#) 开始的 URL（锚）。"));
        list.Add(new K1V3("host", "text", "location.host", "设置或返回主机名和当前 URL 的端口号。"));
        list.Add(new K1V3("hostname", "text", "location.hostname", "设置或返回当前 URL 的主机名。"));
        list.Add(new K1V3("href", "text", "location.href", "设置或返回完整的 URL。"));
        list.Add(new K1V3("pathname", "text", "location.pathname", "设置或返回当前 URL 的路径部分。"));
        list.Add(new K1V3("port", "text", "location.port", "设置或返回当前 URL 的端口号。"));
        list.Add(new K1V3("protocol", "text", "location.protocol", "设置或返回当前 URL 的协议。"));
        list.Add(new K1V3("search", "text", "location.search", "设置或返回从问号 (?) 开始的 URL（查询部分）。"));

        // history
        list = new ArrayList();
        w3cProp.Add(list);
        w3cName.Add("history属性：");
        list.Add(new K1V3("length", "text", "history.length", "返回浏览器历史列表中的 URL 数量"));

        //String ua = Request.Browser.Browser;
        spcProp.Add(new ArrayList());
        spcProp.Add(new ArrayList());
        spcProp.Add(new ArrayList());
        spcProp.Add(new ArrayList());
        spcProp.Add(new ArrayList());
        spcProp.Add(new ArrayList());
    }
}
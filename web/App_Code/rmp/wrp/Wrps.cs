using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

using cons;

using rmp.bean;
using rmp.comn.user;
using rmp.util;
using System.Collections;
using System.Configuration;

namespace rmp.wrp
{
    /// <summary>
    /// Wrps 的摘要说明
    /// </summary>
    public class Wrps
    {
        private static String comnScript;
        private static System.Drawing.Image markImage;
        private static Dictionary<String, String> siteList;

        /// <summary>
        /// 获取用户使用风格
        /// </summary>
        /// <param name="Session"></param>
        /// <param name="module"></param>
        /// <returns></returns>
        public static String GetStyles(HttpSessionState Session, String module)
        {
            string skin = Session[cons.wrp.WrpCons.USERSKIN] + "";
            if (!StringUtil.isValidate(skin, 4))
            {
                skin = skin.Trim().PadLeft(4, '0');
                Session[cons.wrp.WrpCons.USERSKIN] = skin;
            }
            return String.Format("<link type=\"text/css\" rel=\"stylesheet\" href=\"{0}/_styles/{1}/{2}.css\" charset=\"utf-8\" />", EnvCons.PRE_URL, skin, module);
        }

        /// <summary>
        /// 保存用户使用风格
        /// </summary>
        /// <param name="Session"></param>
        /// <param name="id"></param>
        public static void SetStyles(HttpSessionState Session, String id)
        {
            // 定长4位数字
            Session[cons.wrp.WrpCons.USERSKIN] = (id ?? "0000").Trim().PadLeft(4, '0');
        }

        /// <summary>
        /// 获取指定模块的脚本
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public static String GetScript(String module)
        {
            return String.Format("<script type=\"text/javascript\" src=\"{0}/_script/{1}.js\"></script>", EnvCons.PRE_URL, module);
        }

        /// <summary>
        /// 公共头部信息
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static String ComnHead(string mode)
        {
            mode = (mode ?? "").Trim();

            StringBuilder head = new StringBuilder();
            head.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            head.Append("<meta http-equiv=\"Content-Style-Type\" content=\"text/css\"/>");
            head.Append("<meta http-equiv=\"Content-Script-Type\" content=\"text/javascript\"/>");

            // 风格读取
            string skin = HttpContext.Current.Session[cons.wrp.WrpCons.USERSKIN] + "";
            if (!StringUtil.isValidate(skin, 4))
            {
                skin = skin.Trim().PadLeft(4, '0');
                HttpContext.Current.Session[cons.wrp.WrpCons.USERSKIN] = skin;
            }
            // 公共样式
            head.Append(string.Format("<link type=\"text/css\" rel=\"stylesheet\" href=\"{0}{1}\" charset=\"utf-8\" />", EnvCons.PRE_URL, ConfigurationManager.AppSettings["jqueryuicss"]));
            head.Append(string.Format("<link type=\"text/css\" rel=\"stylesheet\" href=\"{0}/_styles/{1}/comn.css\" charset=\"utf-8\" />", EnvCons.PRE_URL, skin));
            // 模块样式
            if (mode.Length == 4)
            {
                head.Append(string.Format("<link type=\"text/css\" rel=\"stylesheet\" href=\"{0}/_styles/{1}/{2}.css\" charset=\"utf-8\" />", EnvCons.PRE_URL, skin, mode));
            }

            head.Append("<script type=\"text/javascript\">");
            head.Append("var _DOC=document;");
            head.Append("var _WIN=window;");
            head.Append("var _PRE='ctl00_AmonView_';");
            head.Append("var _URI='").Append(cons.EnvCons.PRE_URL).Append("';");
            head.Append("</script>");

            // 公共脚本
            head.Append(string.Format("<script type=\"text/javascript\" src=\"{0}{1}\"></script>", EnvCons.PRE_URL, ConfigurationManager.AppSettings["jquery"]));
            head.Append(string.Format("<script type=\"text/javascript\" src=\"{0}{1}\"></script>", EnvCons.PRE_URL, ConfigurationManager.AppSettings["jqueryui"]));
            head.Append(string.Format("<script type=\"text/javascript\" src=\"{0}/_script/comn.js\"></script>", EnvCons.PRE_URL));
            // 模块脚本
            if (mode.Length == 4)
            {
                head.Append(string.Format("<script type=\"text/javascript\" src=\"{0}/_script/{1}.js\"></script>", EnvCons.PRE_URL, mode));
            }

            // 网站徵标
            head.Append(string.Format("<link rel=\"shortcut icon\" href=\"{0}/logo/logo.ico\" />", EnvCons.PRE_URL));
            // 域名缓存
            head.Append(string.Format("<link rel=\"dns-prefetch\" href=\"{0}\" />", HttpContext.Current.Request.Url.Host));
            return head.ToString();
        }

        /// <summary>
        /// 公共底部信息
        /// </summary>
        /// <returns></returns>
        public static string ComnFoot()
        {
            string foot = "";
            return foot;
        }

        /// <summary>
        /// 获取水印图片
        /// </summary>
        public static System.Drawing.Image MarkImage
        {
            get
            {
                if (markImage == null)
                {
                    markImage = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("~/_images/mark.png"));
                }
                return markImage;
            }
        }

        /// <summary>
        /// 获得共用Javascript脚本
        /// </summary>
        /// <returns></returns>
        public static String ComnScript(HttpSessionState Session, String model)
        {
            if (comnScript == null)
            {
                // String script = "";
                //script += "<script type=\"text/javascript\" src=\"/{0}code/iDateObj/c/iDateObj.js\"></script>\n";
                //script += "<script type=\"text/javascript\" src=\"/{0}code/iDateObj/c/iDateDat.js\"></script>\n";
                //script += "<script type=\"text/javascript\" src=\"/{0}code/iMenuObj/c/iMenuObj.js\"></script>\n";
                //script += "<script type=\"text/javascript\" src=\"/{0}code/iMenuObj/c/iMenuDat.js\"></script>\n";
                //script += "<script type=\"text/javascript\" src=\"/{0}code/iSrchObj/c/iSrchObj.js\"></script>\n";
                //script += "<script type=\"text/javascript\" src=\"/{0}code/iSrchObj/c/iSrchDat.js\"></script>\n";

                // Google Stat
                //script += "<script type=\"text/javascript\">\n";
                //script += "var gaJsHost = ((\"https:\" == document.location.protocol) ? \"https://ssl.\" : \"http://www.\");\n";
                //script += "document.write(unescape(\"%3Cscript src='\" + gaJsHost + \"google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E\"));\n";
                //script += "</script>\n";
                //script += "<script type=\"text/javascript\">\n";
                //script += "var pageTracker = _gat._getTracker(\"UA-6036907-2\");\n";
                //script += "pageTracker._trackPageview();\n";
                //script += "</script>\n";

                // Linezing
                //comnScript = String.Format(script, EnvCons.PRE_URL);
                comnScript = "<script type=\"text/javascript\" src=\"/{0}{1}/{2}.js\"></script>";
                comnScript += "<script type=\"text/javascript\" src=\"/{0}inet/inet0002.ashx?sid={3}\"></script>";
                comnScript += "<script type=\"text/javascript\" src=\"http://js.tongji.linezing.com/1078296/tongji.js\"></script>";
            }
            return string.Format(comnScript, EnvCons.PRE_URL, model, Session[cons.wrp.WrpCons.SCRIPTID], UserInfo.Current(Session).UserCode);
        }

        /// <summary>
        /// 显示错误提示信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="mesg"></param>
        public static void ShowMesg(TemplateControl page, String mesg)
        {
            Label label = (Label)page.FindControl("lb_ErrMsg");
            if (label != null)
            {
                label.Text = mesg;
                Control tr = page.FindControl("tr_ErrMsg");
                if (tr != null)
                {
                    tr.Visible = true;
                }
            }
        }

        /// <summary>
        /// 页面回传地址
        /// </summary>
        /// <param name="Session"></param>
        /// <param name="newUrl"></param>
        /// <returns></returns>
        public static String CallBack(HttpSessionState Session, String newUrl)
        {
            // 记录已有URL地址
            String oldUrl = (String)Session[cons.wrp.WrpCons.BACKCALL];

            // 设置新的URL地址
            Session.Add(cons.wrp.WrpCons.BACKCALL, newUrl);

            return oldUrl;
        }

        public static Dictionary<String, String> SiteList
        {
            get
            {
                if (siteList == null)
                {
                    siteList = new Dictionary<String, String>();
                    System.Collections.Specialized.NameValueCollection appSettings = System.Configuration.ConfigurationManager.AppSettings;
                    String tmp;
                    foreach (String key in appSettings.AllKeys)
                    {
                        if (key == null)
                        {
                            continue;
                        }
                        tmp = key.ToLower().Trim();
                        if (key.StartsWith("guid:"))
                        {
                            siteList[key.Substring(5)] = (appSettings[tmp] ?? "").ToLower();
                        }
                    }
                }
                return siteList;
            }
        }

        #region Session导航
        /// <summary>
        /// Card模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidCard(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_CARD];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/card/index.aspx", "Amon卡片", "Amon卡片"));
                guidList.Add(new K1V2("/card/card0001.aspx", "获取代码", "获取代码"));
                guidList.Add(new K1V2("/card/card0002.aspx", "创建卡片", "创建卡片"));
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_CARD, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// Code模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidCode(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_CODE];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/code/index.aspx", "Amon源码", "Amon源码"));
                guidList.Add(new K1V2());
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_CODE, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// Comn模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidComn(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_COMN];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/comn/index.aspx", "共用资源", "共用资源"));
                guidList.Add(new K1V2("/comn/amon0001.aspx", "国别资源", "国别资源"));
                guidList.Add(new K1V2("/comn/amon0001.aspx", "语言资源", "语言资源"));
                guidList.Add(new K1V2("/comn/amon0001.aspx", "信息资源", "信息资源"));
                guidList.Add(new K1V2("/comn/amon0002.aspx", "用户资源", "用户资源"));
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_COMN, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// Date模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidDate(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_DATE];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/date/index.aspx", "博时网", "博时网"));
                guidList.Add(new K1V2());
                guidList.Add(new K1V2());
                guidList.Add(new K1V2()); //管理
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_DATE, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// Exts模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidEdit(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_EDIT];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/edit/index.aspx", "网页在线编辑", "网页在线编辑"));
                guidList.Add(new K1V2("/edit/edit0001.aspx", "精简模式", "精简模式"));
                guidList.Add(new K1V2("/edit/edit0002.aspx", "高级模式", "高级模式"));
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_EDIT, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// Exts模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidExts(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_EXTS];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("index.aspx", "后缀解析", "后缀解析"));
                guidList.Add(new K1V2("/exts/exts1000.aspx", "相关知识", "相关知识"));
                guidList.Add(new K1V2("/exts/exts0001.aspx", "在线查询", "在线查询"));
                guidList.Add(new K1V2()); //管理
                guidList.Add(new K1V2()); //管理（查询）
                guidList.Add(new K1V2()); //管理（详细）
                guidList.Add(new K1V2()); //管理（更新）
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_EXTS, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// Help模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidHelp(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_HELP];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/help/index.aspx", "使用帮助", "使用帮助"));
                guidList.Add(new K1V2());
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_HELP, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// Iask模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidIask(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_IASK];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/iask/index.aspx", "Amon在线", "Amon在线"));
                guidList.Add(new K1V2());
                guidList.Add(new K1V2());
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_IASK, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// Idea模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidIdea(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_IDEA];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/idea/index.aspx", "意见反馈", "意见反馈"));
                guidList.Add(new K1V2("/idea/idea0001.aspx", "我有话说", "我有话说"));
                guidList.Add(new K1V2());
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_IDEA, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// Info模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidInet(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_INET];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/inet/index.aspx", "网页精灵", "网页精灵"));
                guidList.Add(new K1V2());
                guidList.Add(new K1V2());
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_INET, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// Info模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidInfo(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_INFO];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/info/index.aspx", "关于作者", "关于作者"));
                guidList.Add(new K1V2());
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_INFO, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// Link模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidLink(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_LINK];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/link/index.aspx", "网络导航", "网络导航"));
                guidList.Add(new K1V2("/link/link0001.aspx", "我的导航", "我的导航"));
                guidList.Add(new K1V2("/link/link1001.aspx", "友情链接", "友情链接"));
                guidList.Add(new K1V2("/link/link0100.aspx", "链接管理", "链接管理"));
                guidList.Add(new K1V2("/link/link0200.aspx", "类别管理", "类别管理"));
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_LINK, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// Math模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidMath(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_MATH];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/math/index.aspx", "计算助理", "计算助理"));
                guidList.Add(new K1V2());
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_MATH, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// Myim模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidMyim(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_MYIM];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/myim/index.aspx", "即时通讯", "即时通讯"));
                guidList.Add(new K1V2());
                guidList.Add(new K1V2());
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_MYIM, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// Soft模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidMpwd(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_MPWD];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/mpwd/index.aspx", "首页", "首页"));
                guidList.Add(new K1V2("/mpwd/mpwd0001.aspx", "历史", "历史"));
                guidList.Add(new K1V2("/mpwd/mpwd0002.aspx", "下载", "下载"));
                guidList.Add(new K1V2("/mpwd/mpwd0003.aspx", "关于", "关于"));
                guidList.Add(new K1V2("/mpwd/mpwd0004.aspx", "帮助", "帮助"));
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_MPWD, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// Soft模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidSoft(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_SOFT];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/soft/index.aspx", "Amon软件", "Amon软件"));
                guidList.Add(new K1V2());
                guidList.Add(new K1V2("", "历史版本", "历史版本"));
                guidList.Add(new K1V2("", "在线使用", "在线使用"));
                guidList.Add(new K1V2("", "其它下载", "其它下载"));
                guidList.Add(new K1V2("", "软件管理", "软件管理")); //管理
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_SOFT, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// Srch全能搜索
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidSrch(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_SRCH];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/srch/index.aspx", "全能搜索", "全能搜索"));
                guidList.Add(new K1V2());
                guidList.Add(new K1V2());
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_SRCH, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// Tplt模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidTplt(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_TPLT];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/tplt/index.aspx", "模板首页", "模板首页"));
                guidList.Add(new K1V2());
                guidList.Add(new K1V2("", "模板管理", "模板管理")); //管理
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_TPLT, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// User模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidUser(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_USER];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/user/index.aspx", "用户管理", "用户管理"));
                guidList.Add(new K1V2());
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_USER, guidList);
            }
            return guidList;
        }

        /// <summary>
        /// Wime模块导航
        /// </summary>
        /// <param name="Session"></param>
        /// <returns></returns>
        public static List<K1V2> GuidWime(HttpSessionState Session)
        {
            List<K1V2> guidList = (List<K1V2>)Session["amon_guid_" + cons.wrp.WrpCons.MODULE_WIME];
            if (guidList == null)
            {
                guidList = new List<K1V2>();
                guidList.Add(new K1V2("/wime/index.aspx", "网页五笔", "网页五笔"));
                guidList.Add(new K1V2());
                Session.Add("amon_guid_" + cons.wrp.WrpCons.MODULE_WIME, guidList);
            }
            return guidList;
        }
        #endregion
    }
}
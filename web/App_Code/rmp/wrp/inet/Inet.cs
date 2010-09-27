using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using cons.io.db.wrp;
using rmp.bean;
using rmp.util;

namespace rmp.wrp.inet
{
    /// <summary>
    /// Inet 的摘要说明
    /// </summary>
    public class Inet
    {
        private static String TPLT_CODE;
        /// <summary>
        /// 用户偏好TAB索引
        /// </summary>
        private readonly static Dictionary<String, int> UserFavs = new Dictionary<string, int>(100);
        private readonly static Dictionary<String, K1V2> InetList = new Dictionary<string, K1V2>(100);

        private Inet()
        {
        }

        /// <summary>
        /// 获取用户偏好索引
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public static int GetUserFav(String userCode)
        {
            if (StringUtil.isValidate(userCode, 8) && UserFavs.ContainsKey(userCode))
            {
                return UserFavs[userCode];
            }
            return 0;
        }

        /// <summary>
        /// 记录用户偏好索引
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="tabIndex"></param>
        public static void SetUserFav(String userCode, int tabIndex)
        {
            if (StringUtil.isValidate(userCode, 8))
            {
                UserFavs[userCode] = tabIndex;
            }
        }

        /// <summary>
        /// 获取用户常用的网摘链接对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static K1V2 GetInetItem(String key)
        {
            return InetList.ContainsKey(key) ? InetList[key] : null;
        }

        /// <summary>
        /// 记录用户常用的网摘链接对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="item"></param>
        public static void SetInetItem(String key, K1V2 item)
        {
            InetList[key] = item;
        }

        /// <summary>
        /// 读取Script模板代码
        /// </summary>
        public static String TpltCode
        {
            get
            {
                if (TPLT_CODE == null)
                {
                    LoadData(true);
                }
                // 开发时使用，用于按原格式显示脚本内容。
                if (cons.EnvCons.NET_DEV)
                {
                    LoadData(false);
                }
                return TPLT_CODE;
            }
        }

        /// <summary>
        /// 读取文档数据
        /// </summary>
        /// <param name="trim">是否去除注释及空白字符</param>
        public static void LoadData(bool trim)
        {
            TPLT_CODE = "";
            if (trim)
            {
                StreamReader sr = File.OpenText(HttpContext.Current.Server.MapPath("~/inet/c/NetHelper.js"));
                TPLT_CODE = WrpUtil.TrimCode(sr);
                sr.Close();
            }
            else
            {
                TPLT_CODE = File.ReadAllText(HttpContext.Current.Server.MapPath("~/inet/c/NetHelper.js"), Encoding.UTF8);
            }
        }

        public static void GenTable(DataView data, StringBuilder html, String stid, int rows, int cols, bool disp)
        {
            html.Append("<div style=\"height:").Append(rows * 20).Append(disp ? "px;" : "px;display:none;").Append("\" id=\"Net_Amonsoft_NetHelper_").Append(stid).Append("_DV\" class=\"Net_Amonsoft_NetHelper_Help\">");
            html.Append("<table id=\"Net_Amonsoft_NetHelper_").Append(stid).Append("_TB\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" style=\"border-width:0px;width:100%;border-collapse:collapse;\">");
            stid = stid.Substring(2);

            int n = rows * cols;
            int i = 0;
            if (data != null)
            {
                int j = n > data.Count ? data.Count : n;
                while (i < j)
                {
                    DataRowView v = data[i];
                    if (i % cols == 0) html.Append("<tr>");
                    html.Append("<td align=\"left\" style=\"height:20px;\">");
                    html.Append("<a href=\"/inet/inet0002.aspx?sid=").Append(v[WrpCons.W2019102]).Append("\" target=\"_blank\" s=\"").Append(v[WrpCons.W2019102]).Append("\" w=\"").Append(v[WrpCons.W201910A]).Append("\" h=\"").Append(v[WrpCons.W201910B]).Append("\" k=\"").Append(stid).Append("\" title=\"").Append(v[WrpCons.W2019107]).Append("\" onclick=\"return openLink(this);\">");
                    html.Append("<img src=\"/data/inet/").Append(v[WrpCons.W2019105]).Append(".gif\" alt=\"\" />").Append(v[WrpCons.W2019106]);
                    html.Append("</a>");
                    html.Append("</td>");
                    i += 1;
                    if (i % cols == 0) html.Append("</tr>");
                }
            }

            while (i < n)
            {
                if (i % cols == 0) html.Append("<tr>");
                html.Append("<td align=\"left\" style=\"height:20px;\">&nbsp;</td>");
                i += 1;
                if (i % cols == 0) html.Append("</tr>");
            }

            html.Append("</table>");
            html.Append("</div>");
        }

        public static void GenSite(DataView data, StringBuilder html, String stid, int rows, bool disp)
        {
            html.Append("<div style=\"height:").Append(rows * 20).Append(disp ? "px;" : "px;display:none;").Append("\" id=\"Net_Amonsoft_NetHelper_").Append(stid).Append("_DV\" class=\"Net_Amonsoft_NetHelper_Help\">");
            html.Append("<table id=\"Net_Amonsoft_NetHelper_").Append(stid).Append("_TB\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" style=\"border-width:0px;width:100%;border-collapse:collapse;\">");
            stid = stid.Substring(2);

            int i = 0;
            if (data != null)
            {
                int j = rows > data.Count ? data.Count : rows;
                while (i < j)
                {
                    DataRowView v = data[i++];
                    html.Append("<tr>");
                    html.Append("<td style=\"width: 20%;\" align=\"left\">");
                    html.Append("<label for=\"").Append(v[WrpCons.W2019102]).Append("_Cbox\"><input type=\"checkbox\" id=\"").Append(v[WrpCons.W2019102]).Append("_Cbox\" onclick=\"siteView(this, '").Append(v[WrpCons.W2019102]).Append("')\" />").Append(v[WrpCons.W2019106]).Append("</label>");
                    html.Append("</td>");
                    html.Append("<td style=\"width: 20%;\" align=\"right\">收录信息</td>");
                    html.Append("<td style=\"width: 20%;\" align=\"left\" id=\"").Append(v[WrpCons.W2019102]).Append("_Site\">……</td>");
                    html.Append("<td style=\"width: 20%;\" align=\"right\">反向链接</td>");
                    html.Append("<td style=\"width: 20%;\" align=\"left\" id=\"").Append(v[WrpCons.W2019102]).Append("_Link\">……</td>");
                    html.Append("</tr>");
                }
            }

            while (i++ < rows)
            {
                html.Append("<tr><td align=\"left\" style=\"height:20px;\">&nbsp;</td></tr>");
            }

            html.Append("</table>");
            html.Append("</div>");
        }
    }
}
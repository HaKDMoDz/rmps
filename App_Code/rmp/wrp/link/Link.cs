using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using cons.io.db.prp;
using cons.wrp.link;
using rmp.bean;
using rmp.io.db;
using rmp.util;

namespace rmp.wrp.link
{
    /// <summary>
    /// Summary description for Link
    /// </summary>
    public class Link
    {
        private static readonly List<K1V2> guidLink = new List<K1V2>(20);
        private static readonly List<K1V2> extsLink = new List<K1V2>(10);
        private static readonly List<K1V2> inetLink = new List<K1V2>(10);
        private static readonly List<K1V2> mpwdLink = new List<K1V2>(10);
        /// <summary>
        /// 门户链接信息
        /// </summary>
        private static String portLink = "";
        /// <summary>
        /// 上一工作日，用于每日更新门户链接信息
        /// </summary>
        private static int lastDays;
        /// <summary>
        /// 线程锁
        /// </summary>
        private static readonly object locker = new object();

        private Link()
        {
        }

        #region 后缀解析
        /// <summary>
        /// 后缀解析友链
        /// </summary>
        public static List<K1V2> ExtsLink
        {
            get
            {
                if (extsLink.Count < 1)
                {
                    try
                    {
                        // 等待线程进入
                        Monitor.Enter(locker);
                        ReadExts();
                    }
                    catch (Exception)
                    {
                        ReadExts();
                    }
                    finally
                    {
                        // 释放对象锁
                        Monitor.Exit(locker);
                    }
                }
                return extsLink;
            }
        }

        public static void ReadExts()
        {
            extsLink.Clear();
            ReadLink("sctvratvcgxtfyzb", extsLink, 20);
        }
        #endregion

        #region 网页精灵
        /// <summary>
        /// 网页精灵友链
        /// </summary>
        public static List<K1V2> InetLink
        {
            get
            {
                if (inetLink.Count < 1)
                {
                    try
                    {
                        // 等待线程进入
                        Monitor.Enter(locker);
                        ReadInet();
                    }
                    catch (Exception)
                    {
                        ReadInet();
                    }
                    finally
                    {
                        // 释放对象锁
                        Monitor.Exit(locker);
                    }
                }
                return inetLink;
            }
        }

        public static void ReadInet()
        {
            inetLink.Clear();
            ReadLink("sctvratvrrwtcxet", inetLink, 10);
        }
        #endregion

        #region 网络导航
        /// <summary>
        /// 网络导航友链
        /// </summary>
        public static List<K1V2> GuidLink
        {
            get
            {
                if (guidLink.Count < 1)
                {
                    try
                    {
                        // 等待线程进入
                        Monitor.Enter(locker);
                        ReadGuid();
                    }
                    catch (Exception)
                    {
                        ReadGuid();
                    }
                    finally
                    {
                        // 释放对象锁
                        Monitor.Exit(locker);
                    }
                }
                return guidLink;
            }
        }

        public static void ReadGuid()
        {
            guidLink.Clear();
            ReadLink("sctvratvfzqqqfwb", guidLink, 10);
        }
        #endregion

        #region 魔方密码
        /// <summary>
        /// 魔方密码
        /// </summary>
        public static List<K1V2> MpwdLink
        {
            get
            {
                if (mpwdLink.Count < 1)
                {
                    try
                    {
                        // 等待线程进入
                        Monitor.Enter(locker);
                        ReadMpwd();
                    }
                    catch (Exception)
                    {
                        ReadMpwd();
                    }
                    finally
                    {
                        // 释放对象锁
                        Monitor.Exit(locker);
                    }
                }
                return mpwdLink;
            }
        }

        public static void ReadMpwd()
        {
            mpwdLink.Clear();
            ReadLink("sctvraydxttvfdrb", mpwdLink, 10);
        }
        #endregion

        #region 门户网站
        /// <summary>
        /// 门户网站链接
        /// </summary>
        public static String PortLink()
        {
            int day = DateTime.Now.Day;
            if (portLink == "" || lastDays != day)
            {
                ReadPort(4);
                lastDays = day;
            }
            return portLink;
        }

        public static void ReadPort(int col)
        {
            DBAccess dba = new DBAccess();

            // 读取类别信息
            dba.addTable(cons.io.db.comn.info.C2010000.C2010100);
            dba.addColumn(cons.io.db.comn.info.C2010000.C2010105);
            dba.addColumn(cons.io.db.comn.info.C2010000.C2010107);
            dba.addWhere(cons.io.db.comn.info.C2010000.C2010106, LinkCons.LINK_PORT_HASH);
            dba.addWhere(cons.io.db.comn.info.C2010000.C2010101, ">", "-1", false);
            dba.addSort(cons.io.db.comn.info.C2010000.C2010101, false);
            IList<K1V1> type = new List<K1V1>();
            foreach (DataRow row in dba.executeSelect().Rows)
            {
                type.Add(new K1V1(row[cons.io.db.comn.info.C2010000.C2010105] + "", row[cons.io.db.comn.info.C2010000.C2010107] + ""));
            }
            dba.reset();

            dba.addTable(PrpCons.P3070100);
            dba.addTable(PrpCons.P3070200);
            dba.addTable(cons.io.db.comn.info.C2010000.C2010100);
            dba.addColumn(cons.io.db.comn.info.C2010000.C2010105);
            dba.addColumn(PrpCons.P3070105);
            dba.addColumn(PrpCons.P3070108);
            dba.addColumn(PrpCons.P3070109);
            dba.addColumn(PrpCons.P307010B);
            dba.addWhere(PrpCons.P3070105, PrpCons.P3070204, false);
            dba.addWhere(PrpCons.P3070203, cons.io.db.comn.info.C2010000.C2010105, false);
            dba.addWhere(cons.io.db.comn.info.C2010000.C2010106, LinkCons.LINK_PORT_HASH);
            dba.addSort(PrpCons.P3070101, false);

            DataView view = dba.executeSelect().DefaultView;

            StringBuilder html = new StringBuilder();
            html.Append("<table border=\"0\" cellpadding=\"1\" cellspacing=\"0\" width=\"460\" class=\"TB_LinkPort\">");
            int idx = 0;
            bool alt = false;
            foreach (K1V1 item in type)
            {
                html.Append("<tr class=").Append(alt ? "TR_LinkPort_A" : "TR_LinkPort_D").Append(">");
                html.Append("<td align=\"center\" style=\"width:80px;height:18px;\">〖" + item.V + "〗</td>");
                alt = !alt;

                view.RowFilter = cons.io.db.comn.info.C2010000.C2010105 + "='" + item.K + '\'';
                foreach (DataRowView row in view)
                {
                    if (idx < col)
                    {
                        html.Append("<td align=\"center\" style=\"width:80px;\">");
                        html.Append(String.Format("<a target=\"_blank\" href=\"{0}\" title=\"{1}\" onclick=\"feqs('{2}','{3}');\">{4}</a>", row[PrpCons.P3070109], row[PrpCons.P307010B], row[PrpCons.P3070105], item.K, StringUtil.FixWidth(row[PrpCons.P3070108] + "", 4)));
                        html.Append("</td>");
                        idx += 1;
                    }
                }
                while (idx < col)
                {
                    html.Append("<td align=\"center\" style=\"width:80px;\">&nbsp;</td>");
                    idx += 1;
                }
                html.Append("<td align=\"right\" style=\"width:80px;\"><a href=\"/link/link0001.aspx?sid=").Append(item.K).Append("&sys=1\" target=\"_self\">更多>></a></td>");
                html.Append("</tr>");
                idx = 0;
            }
            html.Append("</table>");

            portLink = html.ToString();
        }
        #endregion

        /// <summary>
        /// 读取专用模块的友情链接
        /// </summary>
        /// <param name="type"></param>
        /// <param name="list"></param>
        /// <param name="size"></param>
        private static void ReadLink(String type, ICollection<K1V2> list, int size)
        {
            DBAccess dba = new DBAccess();
            dba.addTable(PrpCons.P3070100);
            dba.addTable(PrpCons.P3070200);
            dba.addColumn(PrpCons.P3070109);
            dba.addColumn(PrpCons.P3070107);
            dba.addColumn(PrpCons.P3070108);
            dba.addWhere(PrpCons.P3070105, PrpCons.P3070202, false);
            dba.addWhere(PrpCons.P3070203, type);
            dba.addSort(PrpCons.P3070101, false);

            DataTable data = dba.executeSelect();
            if (data != null)
            {
                if (data.Rows.Count < size)
                {
                    size = data.Rows.Count;
                }

                for (int i = 0; i < size; i += 1)
                {
                    DataRow row = data.Rows[i];
                    list.Add(new K1V2(row[PrpCons.P3070109].ToString(), row[PrpCons.P3070107].ToString(), row[PrpCons.P3070108].ToString()));
                }
            }
        }

        /// <summary>
        /// 根据快捷地址读取链接信息
        /// </summary>
        /// <param name="quick"></param>
        /// <returns></returns>
        public static String Read(String quick)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(quick, "^[0-9A-Za-z_\\$]{1,8}$"))
            {
                return null;
            }

            DBAccess dba = new DBAccess();
            dba.addTable(PrpCons.P3070100);
            dba.addColumn(PrpCons.P3070109);
            dba.addWhere(PrpCons.P3070104, quick);
            DataTable dt = dba.executeSelect();
            return dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : "";
        }

        /// <summary>
        /// 添加一个链接数据
        /// </summary>
        /// <param name="dba"></param>
        /// <param name="sid">系统代码</param>
        /// <param name="hash">链接索引</param>
        /// <param name="path">链接路径</param>
        /// <param name="desc">链接说明</param>
        /// <param name="updt">是否更新链接原始信息</param>
        /// <returns></returns>
        public static String Save(DBAccess dba, String sid, String hash, String path, String desc, bool updt)
        {
            // 判断系统代码及链接路径的合法性
            if (!StringUtil.isValidateCode(sid) || !StringUtil.isValidate(path))
            {
                return null;
            }

            DataTable dt;
            String temp = WrpUtil.text2Db(path);

            // 查询数据中是否已有对应链接，若有则记录已有数据的Hash值
            if (!StringUtil.isValidateHash(hash))
            {
                dba.reset();
                dba.addTable(PrpCons.P3070100);
                dba.addColumn(PrpCons.P3070105);
                dba.addWhere(PrpCons.P3070109, temp);
                dt = dba.executeSelect();
                hash = dt.Rows.Count > 0 ? dt.Rows[0][PrpCons.P3070105].ToString() : null;
            }

            String logo = "";
            String title = "";
            String keyword = "";
            String descrption = "";

            // 新增链接数据
            if (!StringUtil.isValidateHash(hash))
            {
                // 读取链接网页内容
                try
                {
                    String html = WrpUtil.readHtmlCode(path);
                    title = FindTag(html, "title");
                    keyword = FindAttr(html, "meta", "content", "keywords");
                    descrption = FindAttr(html, "meta", "content", "description");
                }
                catch (Exception)
                {
                }

                // 生成快捷地址
                dba.reset();
                dba.addTable(PrpCons.P3070100);
                dba.addColumn(String.Format("COUNT({0})", PrpCons.P3070104), PrpCons.P3070104);// 查询记录总量
                dt = dba.executeSelect();
                int cnt = dt.Rows.Count > 0 ? int.Parse(dt.Rows[0][PrpCons.P3070104].ToString()) : 0;

                // 插入数据
                dba.reset();
                hash = HashUtil.getCurrTimeHex(false);
                dba.addTable(PrpCons.P3070100);
                dba.addParam(PrpCons.P3070101, "0");
                dba.addParam(PrpCons.P3070102, "0");
                dba.addParam(PrpCons.P3070103, sid);
                dba.addParam(PrpCons.P3070104, Encode64(cnt + 1, 64));
                dba.addParam(PrpCons.P3070105, hash);
                dba.addParam(PrpCons.P3070106, "0");
                dba.addParam(PrpCons.P3070107, logo);
                dba.addParam(PrpCons.P3070108, WrpUtil.text2Db(title));
                dba.addParam(PrpCons.P3070109, temp);
                dba.addParam(PrpCons.P307010A, WrpUtil.text2Db(keyword));
                dba.addParam(PrpCons.P307010B, WrpUtil.text2Db(descrption));
                dba.addParam(PrpCons.P307010C, WrpUtil.text2Db(desc));
                dba.addParam(PrpCons.P307010D, cons.EnvCons.SQL_NOW, false);
                dba.addParam(PrpCons.P307010E, cons.EnvCons.SQL_NOW, false);
                dba.executeInsert();
            }
            else if (updt)
            {
                // 读取链接网页内容
                try
                {
                    String html = WrpUtil.readHtmlCode(path);
                    title = FindTag(html, "title");
                    keyword = FindAttr(html, "meta", "content", "keywords");
                    descrption = FindAttr(html, "meta", "content", "description");
                }
                catch (Exception)
                {
                }

                dba.reset();
                dba.addTable(PrpCons.P3070100);
                dba.addParam(PrpCons.P3070102, "0");
                dba.addParam(PrpCons.P3070103, sid);
                dba.addParam(PrpCons.P3070106, "0");
                dba.addParam(PrpCons.P3070107, logo);
                dba.addParam(PrpCons.P3070108, WrpUtil.text2Db(title));
                dba.addParam(PrpCons.P3070109, temp);
                dba.addParam(PrpCons.P307010A, WrpUtil.text2Db(keyword));
                dba.addParam(PrpCons.P307010B, WrpUtil.text2Db(descrption));
                dba.addParam(PrpCons.P307010C, WrpUtil.text2Db(desc));
                dba.addParam(PrpCons.P307010D, cons.EnvCons.SQL_NOW, false);
                dba.addWhere(PrpCons.P3070105, hash);
                dba.executeUpdate();
            }
            return hash;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l">10进制数值</param>
        /// <param name="r">进制</param>
        /// <returns></returns>
        public static String Encode64(int l, int r)
        {
            const String T = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_-";
            var s = new StringBuilder();
            while (l != 0)
            {
                int b = l % r;
                s.Insert(0, T[b]);
                l = (l - b) / r;
            }
            return s.ToString();
        }

        /// <summary>
        /// 查找网页中指定标签的内容
        /// </summary>
        /// <param name="html"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private static String FindTag(String html, String name)
        {
            name = "<\\s*" + name + "[^>]*>(.|\\n)*?<\\s*/\\s*" + name + "\\s*>";
            System.Text.RegularExpressions.MatchCollection mc = System.Text.RegularExpressions.Regex.Matches(html, name, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            return mc.Count > 0 ? System.Text.RegularExpressions.Regex.Replace(mc[0].Value, "<[^>]*>", "").Trim() : "";
        }

        /// <summary>
        /// 查找标签内容
        /// </summary>
        /// <param name="html"></param>
        /// <param name="tag">HTML标签名称</param>
        /// <param name="attr">属性名称</param>
        /// <permission cref="">属性区分键值</permission>
        /// <returns></returns>
        private static String FindAttr(String html, String tag, String attr, String value)
        {
            System.Text.RegularExpressions.MatchCollection mc = System.Text.RegularExpressions.Regex.Matches(html,
                "<\\s*" + tag + "(.|\\n)*?(" + value + ")(.|\\n)*?>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            if (mc.Count > 0)
            {
                String data = System.Text.RegularExpressions.Regex.Replace(mc[0].Value, "<\\s*" + tag + "(.|\\n)*?" + attr + "\\s*=\\s*", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                return System.Text.RegularExpressions.Regex.Replace(data, "[\\s/]*>$", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase).Trim('"', '\'', ' ');
            }
            return "";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using rmp.bean;
using rmp.io.db;

namespace rmp.wrp.code
{
    public class GenHtml
    {
        private String userTxt;
        private UserOpt userOpt;
        private CodeCat codeCat;
        private String bodyCss;
        private String lineCss;

        public GenHtml(String userTxt, UserOpt userOpt)
        {
            this.userTxt = userTxt;
            this.userOpt = userOpt;
        }

        public String ToHtml()
        {
            #region 读取语言信息
            DBAccess dba = new DBAccess();
            dba.addTable(cons.io.db.wrp.WrpCons.W2050300);
            dba.addWhere(cons.io.db.wrp.WrpCons.W2050301, "SCTGDZGWYZEACCTZ");
            DataTable dt = dba.executeSelect();
            int cnt = dt.Rows.Count;
            if (cnt != 1)
            {
                return null;
            }
            DataRow row = dt.Rows[0];
            codeCat = new CodeCat();
            codeCat.W2050301 = row[cons.io.db.wrp.WrpCons.W2050301] + "";
            codeCat.W2050302 = row[cons.io.db.wrp.WrpCons.W2050302] + "";
            codeCat.W2050303 = row[cons.io.db.wrp.WrpCons.W2050303] + "";
            codeCat.W2050304 = row[cons.io.db.wrp.WrpCons.W2050304] + "";
            codeCat.W2050305 = row[cons.io.db.wrp.WrpCons.W2050305] + "";
            codeCat.W2050306 = row[cons.io.db.wrp.WrpCons.W2050306] + "";
            codeCat.W2050307 = row[cons.io.db.wrp.WrpCons.W2050307] + "";
            codeCat.W2050308 = row[cons.io.db.wrp.WrpCons.W2050308] + "";
            codeCat.W2050309 = row[cons.io.db.wrp.WrpCons.W2050309] + "";
            codeCat.W205030A = row[cons.io.db.wrp.WrpCons.W205030A] + "";
            codeCat.W205030B = row[cons.io.db.wrp.WrpCons.W205030B] + "";
            codeCat.W205030C = row[cons.io.db.wrp.WrpCons.W205030C] + "";
            codeCat.W205030D = row[cons.io.db.wrp.WrpCons.W205030D] + "";
            codeCat.W205030E = row[cons.io.db.wrp.WrpCons.W205030E] + "";
            #endregion

            StringBuilder buffer = new StringBuilder();

            #region 读取风格信息
            dba.reset();
            dba.addTable(cons.io.db.wrp.WrpCons.W2050200);
            dba.addWhere(cons.io.db.wrp.WrpCons.W2050203, "SCTGDZGWYZEACCTZ");
            dba.addSort(cons.io.db.wrp.WrpCons.W2050201, true);
            dt = dba.executeSelect();
            cnt = dt.Rows.Count;
            Dictionary<String, CodeCss> cssDict = new Dictionary<String, CodeCss>(cnt + 10);
            CodeCss css;
            String tmp;
            List<String> cssList = new List<String>();
            for (int i = 0; i < cnt; i += 1)
            {
                row = dt.Rows[i];
                css = new CodeCss();
                css.CodeCat = codeCat;

                tmp = row[cons.io.db.wrp.WrpCons.W2050202] + "";
                css.W2050202 = tmp;
                css.W2050203 = row[cons.io.db.wrp.WrpCons.W2050203] + "";
                css.W2050204 = row[cons.io.db.wrp.WrpCons.W2050204] + "";
                css.W2050205 = row[cons.io.db.wrp.WrpCons.W2050205] + "";
                css.W2050206 = row[cons.io.db.wrp.WrpCons.W2050206] + "";
                css.W2050207 = row[cons.io.db.wrp.WrpCons.W2050207] + "";
                css.W2050208 = row[cons.io.db.wrp.WrpCons.W2050208] + "";
                css.W2050209 = row[cons.io.db.wrp.WrpCons.W2050209] + "";
                css.W205020A = (int)row[cons.io.db.wrp.WrpCons.W205020A];
                css.W205020B = row[cons.io.db.wrp.WrpCons.W205020B] + "";

                getStyle(buffer, css);
                if (userOpt.InLineStyle)
                {
                    if ("my_Code_Body" == css.W2050205)
                    {
                        bodyCss = buffer.ToString();
                        css.W2050205 = bodyCss;
                    }
                    else if ("my_Code_Line" == css.W2050205)
                    {
                        lineCss = buffer.ToString();
                        css.W2050205 = lineCss;
                    }
                    else
                    {
                        css.W2050205 = buffer.ToString();
                    }
                }
                else
                {
                    cssList.Add('.' + css.W2050205 + '{' + buffer + '}');
                }
                buffer.Remove(0, buffer.Length);

                cssDict[tmp] = css;
            }
            #endregion

            #region 读取语法信息
            dba.reset();
            dba.addTable(cons.io.db.wrp.WrpCons.W2050100);
            dba.addWhere(cons.io.db.wrp.WrpCons.W2050102, "SCTGDZGWYZEACCTZ");
            dt = dba.executeSelect();
            cnt = dt.Rows.Count;
            Dictionary<String, CodeKey> keyDict = new Dictionary<String, CodeKey>(cnt + 10);
            CodeKey key;
            for (int i = 0; i < cnt; i += 1)
            {
                row = dt.Rows[i];
                key = new CodeKey();

                key.W2050101 = row[cons.io.db.wrp.WrpCons.W2050101] + "";
                key.W2050102 = row[cons.io.db.wrp.WrpCons.W2050102] + "";
                key.CodeCat = codeCat;
                tmp = row[cons.io.db.wrp.WrpCons.W2050103] + "";
                key.W2050103 = tmp;
                key.CodeCss = cssDict[tmp];
                tmp = row[cons.io.db.wrp.WrpCons.W2050104] + "";
                key.W2050104 = tmp;
                key.W2050105 = row[cons.io.db.wrp.WrpCons.W2050105] + "";
                key.W2050106 = row[cons.io.db.wrp.WrpCons.W2050106] + "";
                key.W2050107 = row[cons.io.db.wrp.WrpCons.W2050107] + "";

                keyDict[tmp] = key;
            }
            #endregion

            #region 生成HTML代码
            buffer.Append("<html>");
            buffer.Append("<head>");
            buffer.Append("<title>").Append("").Append("</title>");
            buffer.Append("<meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\" />");
            if (!userOpt.InLineStyle)
            {
                buffer.Append("<style type=\"text/css\">");
                buffer.Append("<!--");
                for (int i = 0, j = cssList.Count; i < j; i += 1)
                {
                    buffer.Append(cssList[i]);
                }
                buffer.Append("//-->");
                buffer.Append("</style>");
            }
            buffer.Append("</head>");
            buffer.Append("<body>");
            buffer.Append(getTagS());
            String[] text = userTxt.Replace("\r\n", "\n").Replace("\r", "\n").Split('\n');
            int size = text.Length;
            cnt = size.ToString().Length;
            for (int i = 0; i < size; i += 1)
            {
                if (userOpt.ShowLineNbr)
                {
                    enCodeLine(buffer, i, cnt);
                }
                buffer.Append(enCodeHtml(text[i], keyDict)).Append(getLine());
            }
            buffer.Append(getTagE());
            buffer.Append("</body>");
            buffer.Append("</html>");
            #endregion

            return buffer.ToString();
        }

        /// <summary>
        /// 内容起始标签
        /// </summary>
        /// <returns></returns>
        private String getTagS()
        {
            switch (userOpt.TagStyle)
            {
                case UserOpt.TAG_STYLE_PRE:
                    return userOpt.InLineStyle ? "<pre style=\"" + bodyCss + "\">" : "<pre class=\"my_Code_Body\">";
                case UserOpt.TAG_STYLE_TBL:
                    return userOpt.InLineStyle ? "<table style=\"" + bodyCss + "\">" : "<table class=\"my_Code_Body\">";
                default:
                    return userOpt.InLineStyle ? "<pre style=\"" + bodyCss + "\">" : "<div class=\"my_Code_Body\">";
            }
        }

        /// <summary>
        /// 换行标签
        /// </summary>
        /// <returns></returns>
        private String getLine()
        {
            switch (userOpt.TagStyle)
            {
                case UserOpt.TAG_STYLE_PRE:
                    return "\n";
                case UserOpt.TAG_STYLE_TBL:
                    return "";
                default:
                    return "<br />";
            }
        }

        /// <summary>
        /// 内容结束标签
        /// </summary>
        /// <returns></returns>
        private String getTagE()
        {
            switch (userOpt.TagStyle)
            {
                case UserOpt.TAG_STYLE_PRE:
                    return "</pre>";
                case UserOpt.TAG_STYLE_TBL:
                    return "</table>";
                default:
                    return "</div>";
            }
        }

        /// <summary>
        /// 填充空格
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private String fixSpace(String text)
        {
            text = text.Replace("\t", " ".PadLeft(userOpt.TabCount, ' '));
            switch (userOpt.TagStyle)
            {
                case UserOpt.TAG_STYLE_PRE:
                    return text;
                case UserOpt.TAG_STYLE_TBL:
                default:
                    return text.Replace("  ", "&nbsp;&nbsp;");
            }
        }

        private void enCodeLine(StringBuilder buf, int lineNbr, int lineCnt)
        {
            buf.Append("<span ").Append(userOpt.InLineStyle ? "style=\"" + lineCss + "\">" : "class=\"my_Code_Line\">");
            buf.Append("<font color=\"#e8e8e8\">");
            String tmp = (lineNbr + 1).ToString();
            for (int i = tmp.Length, j = lineCnt + 2; i < j; i += 1)
            {
                buf.Append("0");
            }
            buf.Append("</font>");
            buf.Append(tmp);
            buf.Append("&nbsp;</span>");
        }

        private String enCodeHtml(String text, Dictionary<String, CodeKey> srcDict)
        {
            String tmp = null;

            bool p1 = !String.IsNullOrEmpty(codeCat.W2050305);
            bool p2 = !String.IsNullOrEmpty(codeCat.W2050307);
            if (p1 && p2)
            {
                int s1 = text.IndexOf(codeCat.W2050305);
                int s2 = text.IndexOf(codeCat.W2050307);
                if (s1 >= 0 && s2 >= 0)
                {
                    tmp = s1 < s2 ? codeCat.W2050305 : codeCat.W2050307;
                }
                else if (s1 > 0)
                {
                    tmp = codeCat.W2050305;
                }
                else if (s1 > 0)
                {
                    tmp = codeCat.W2050307;
                }
            }
            else if (p1)
            {
                tmp = codeCat.W2050305;
            }
            else if (p2)
            {
                tmp = codeCat.W2050307;
            }

            if (!String.IsNullOrEmpty(tmp))
            {
                text = text.Replace(codeCat.W2050303 + tmp, "\b");
                if (Regex.IsMatch(text, tmp + ".*?" + tmp))
                {
                    Match match = Regex.Match(text, "\".*?\"");
                    StringBuilder buf = new StringBuilder();
                    int ids = 0;
                    int ide;
                    while (match.Success)
                    {
                        ide = match.Index;
                        buf.Append(replace(text.Substring(ids, ide - ids), srcDict));
                        tmp = match.Value;
                        buf.Append(formatStr(tmp.Replace("\b", codeCat.W2050303 + tmp)));
                        ids = ide + tmp.Length;
                        match = match.NextMatch();
                    }
                    text = buf.Append(replace(text.Substring(ids, text.Length - ids), srcDict)).ToString();
                }
                else
                {
                    text = replace(text, srcDict);
                }
            }

            return fixSpace(text);
        }

        private String replace(String text, Dictionary<String, CodeKey> dict)
        {
            StringBuilder buf = new StringBuilder(text);
            List<I1S1> list = new List<I1S1>();
            Match match = Regex.Match(text, "[$\\w\\d]+");
            while (match.Success)
            {
                list.Add(new I1S1(match.Index, match.Value));
                match = match.NextMatch();
            }

            I1S1 item;
            for (int i = list.Count - 1; i >= 0; i -= 1)
            {
                item = list[i];
                if (dict.ContainsKey(item.V))
                {
                    buf.Remove(item.K, item.V.Length).Insert(item.K, formatKey(dict[item.V]));
                }
            }
            return buf.ToString();
        }

        public String formatStr(String str)
        {
            return String.Format("<span style=\"color:#AAAAAA\">{0}</span>", str);
        }

        public String formatKey(CodeKey key)
        {
            StringBuilder buf = new StringBuilder();

            String tag;
            if (userOpt.ShowLinkUri)
            {
                tag = "a";
                buf.Append('<').Append(tag);
                if (!String.IsNullOrEmpty(key.W2050105))
                {
                    buf.Append(" href=\"").Append(key.W2050105).Append("\" target=\"_blank\"");
                }
                if (!String.IsNullOrEmpty(key.W2050106))
                {
                    buf.Append(" title=\"").Append(key.W2050106).Append("\"");
                }
            }
            else
            {
                tag = "span";
                buf.Append('<').Append(tag);
            }

            buf.Append(userOpt.InLineStyle ? " style=\"" : " class=\"");
            buf.Append(key.CodeCss.W2050205);
            buf.Append("\">");

            buf.Append(key.W2050104);

            return buf.Append("</").Append(tag).Append(">").ToString();
        }

        public void getStyle(StringBuilder buf, CodeCss css)
        {
            if (css.IsValidateBgColor())
            {
                buf.Append("background-color:").Append(css.W2050206).Append(';');
            }
            if (css.IsValidateFgColor())
            {
                buf.Append("color:").Append(css.W2050207).Append(';');
            }
            buf.Append("font-family:").Append(css.W2050208).Append(';');
            buf.Append("font-size:").Append(css.W2050209).Append(';');

            int tmp = css.W205020A;
            if (tmp == CodeCss.STYLE_NORMAL)
            {
                return;
            }

            if ((tmp & CodeCss.STYLE_BOLD) != 0)
            {
                buf.Append("font-weight:bold;");
            }
            if ((tmp & CodeCss.STYLE_ITALIC) != 0)
            {
                buf.Append("font-style:italic;");
            }
            if ((tmp & CodeCss.STYLE_STROKE) != 0)
            {
                buf.Append("text-decoration:line-through;vertical-align: middle;");
            }
            if ((tmp & CodeCss.STYLE_UNDER_LINE) != 0)
            {
                buf.Append("text-decoration:underline;");
            }
            if ((tmp & CodeCss.STYLE_OVER_LINE) != 0)
            {
                buf.Append("text-decoration:overline;");
            }
        }
    }
}

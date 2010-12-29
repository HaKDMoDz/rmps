using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using rmp.bean;
using rmp.io.db;
using System.Data;

namespace rmp.wrp.code
{
    public class GenHtml
    {
        private String userTxt;
        private UserOpt userOpt;
        private CodeCat codeCat;

        private const int STATUS_MULTILINE_STRING = 1;
        private const int STATUS_MULTILINE_COMMENT = STATUS_MULTILINE_STRING + 1;
        private const int STATUS_DOCUMENT_COMMENT = STATUS_MULTILINE_COMMENT + 1;

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
            dba.addWhere(cons.io.db.wrp.WrpCons.W2050301, userOpt.Language);
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
            codeCat.W205030E = "1" == (row[cons.io.db.wrp.WrpCons.W205030E] + "");
            codeCat.W205030F = row[cons.io.db.wrp.WrpCons.W205030F] + "";
            codeCat.W2050310 = row[cons.io.db.wrp.WrpCons.W2050310] + "";
            codeCat.W2050311 = row[cons.io.db.wrp.WrpCons.W2050311] + "";
            if (String.IsNullOrEmpty(codeCat.W2050310))
            {
                codeCat.W2050310 = "((\\d*\\.\\d+)|(\\d+(\\.\\d*)?)([*]?[eE][-+]?\\d+)?)";
            }
            #endregion

            StringBuilder buffer = new StringBuilder();

            #region 读取风格信息
            dba.reset();
            dba.addTable(cons.io.db.wrp.WrpCons.W2050200);
            dba.addWhere(cons.io.db.wrp.WrpCons.W2050203, userOpt.Language);
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

                getFont(buffer, css);
                if (userOpt.InLineStyle)
                {
                    css.W2050205 = buffer.ToString();
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
            // 关键字信息
            dba.reset();
            dba.addTable(cons.io.db.wrp.WrpCons.W2050100);
            dba.addWhere(cons.io.db.wrp.WrpCons.W2050102, userOpt.Language);
            dba.addWhere(cons.io.db.wrp.WrpCons.W2050107, CodeKey.TYPE_NORMAL.ToString());
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
                key.W2050108 = row[cons.io.db.wrp.WrpCons.W2050108] + "";

                keyDict[codeCat.W205030E ? tmp.ToLower() : tmp] = key;
            }

            // 表达式信息
            dba.reset();
            dba.addTable(cons.io.db.wrp.WrpCons.W2050100);
            dba.addWhere(cons.io.db.wrp.WrpCons.W2050102, userOpt.Language);
            dba.addWhere(cons.io.db.wrp.WrpCons.W2050107, CodeKey.TYPE_REGEXP.ToString());
            dt = dba.executeSelect();
            cnt = dt.Rows.Count;
            Dictionary<String, CodeKey> regDict = new Dictionary<String, CodeKey>(cnt + 10);
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
                key.W2050108 = row[cons.io.db.wrp.WrpCons.W2050108] + "";

                regDict[tmp] = key;
            }
            #endregion

            #region 语法分析
            String[] text = userTxt.Replace("\r\n", "\n").Replace("\r", "\n").Split('\n');
            int size = text.Length;
            List<K1V2> html = new List<K1V2>(size);
            int status = 0;
            const String SP11 = "\u001C";
            const String SP12 = "\u001D";
            const String SP13 = "\u001E";
            const String SP14 = "\u001F";
            const String SP21 = "\u0010";
            const String SP22 = "\u0011";
            const String SP23 = "\u0012";
            const String SP24 = "\u0013";
            for (int i = 0; i < size; i += 1)
            {
                tmp = text[i];
                if (!String.IsNullOrEmpty(codeCat.W2050303))
                {
                    if (!String.IsNullOrEmpty(codeCat.W2050305))
                    {
                        tmp = tmp.Replace(codeCat.W2050303 + codeCat.W2050305, SP11);
                    }
                    if (!String.IsNullOrEmpty(codeCat.W2050306))
                    {
                        tmp = tmp.Replace(codeCat.W2050303 + codeCat.W2050306, SP12);
                    }
                    if (!String.IsNullOrEmpty(codeCat.W2050307))
                    {
                        tmp = tmp.Replace(codeCat.W2050303 + codeCat.W2050307, SP13);
                    }
                    if (!String.IsNullOrEmpty(codeCat.W2050308))
                    {
                        tmp = tmp.Replace(codeCat.W2050303 + codeCat.W2050308, SP14);
                    }
                }
                if (!String.IsNullOrEmpty(codeCat.W2050304))
                {
                    if (!String.IsNullOrEmpty(codeCat.W2050305))
                    {
                        tmp = tmp.Replace(codeCat.W2050304 + codeCat.W2050305, SP21);
                    }
                    if (!String.IsNullOrEmpty(codeCat.W2050306))
                    {
                        tmp = tmp.Replace(codeCat.W2050304 + codeCat.W2050306, SP22);
                    }
                    if (!String.IsNullOrEmpty(codeCat.W2050307))
                    {
                        tmp = tmp.Replace(codeCat.W2050304 + codeCat.W2050307, SP23);
                    }
                    if (!String.IsNullOrEmpty(codeCat.W2050308))
                    {
                        tmp = tmp.Replace(codeCat.W2050304 + codeCat.W2050308, SP24);
                    }
                }

                status = enCodeText(buffer, tmp.Replace("<", "&lt;").Replace(">", "&gt;"), keyDict, regDict, status);
                fixSpace(buffer);
                buffer.Replace(SP11, codeCat.W2050303 + codeCat.W2050305).Replace(SP12, codeCat.W2050303 + codeCat.W2050306);
                buffer.Replace(SP13, codeCat.W2050303 + codeCat.W2050307).Replace(SP14, codeCat.W2050303 + codeCat.W2050308);
                buffer.Replace(SP21, codeCat.W2050304 + codeCat.W2050305).Replace(SP22, codeCat.W2050304 + codeCat.W2050306);
                buffer.Replace(SP23, codeCat.W2050304 + codeCat.W2050307).Replace(SP24, codeCat.W2050304 + codeCat.W2050308);

                html.Add(new K1V2("", tmp, buffer.ToString()));
                buffer.Remove(0, buffer.Length);
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
            buffer.Append(getTagS(keyDict));
            cnt = size.ToString().Length;
            bool tbl = userOpt.TagStyle == UserOpt.TAG_STYLE_TBL;
            for (int i = 0; i < size; i += 1)
            {
                if (tbl)
                {
                    buffer.Append("<tr>");
                }

                if (userOpt.ShowLineNbr)
                {
                    enCodeLine(buffer, i, cnt, keyDict);
                }

                if (tbl)
                {
                    buffer.Append("<td>");
                }

                buffer.Append(html[i].V2).Append(getLine());

                if (tbl)
                {
                    buffer.Append("</td>");
                    buffer.Append("</tr>");
                }
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
        private String getTagS(Dictionary<String, CodeKey> keyDict)
        {
            switch (userOpt.TagStyle)
            {
                case UserOpt.TAG_STYLE_PRE:
                    return "<pre " + (userOpt.InLineStyle ? "style=\"" : "class=\"") + keyDict["※body"].CodeCss.W2050205 + "\">";
                case UserOpt.TAG_STYLE_TBL:
                    return "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" " + (userOpt.InLineStyle ? "style=\"" : "class=\"") + keyDict["※body"].CodeCss.W2050205 + "\">";
                default:
                    return "<div " + (userOpt.InLineStyle ? "style=\"" : "class=\"") + keyDict["※body"].CodeCss.W2050205 + "\">";
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
        private StringBuilder fixSpace(StringBuilder text)
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

        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="lineNbr"></param>
        /// <param name="lineCnt"></param>
        private void enCodeLine(StringBuilder buf, int lineNbr, int lineCnt, Dictionary<String, CodeKey> keyDict)
        {
            String tag = (userOpt.TagStyle == UserOpt.TAG_STYLE_TBL ? "td" : "span");
            buf.Append('<').Append(tag).Append(' ').Append(userOpt.InLineStyle ? "style=\"" : "class=\"").Append(keyDict["※line_nbr"].CodeCss.W2050205).Append("\">");
            buf.Append("<span style=\"color:").Append(keyDict["※line_nbr"].CodeCss.W2050206).Append("\">");
            String tmp = (lineNbr + 1).ToString();
            for (int i = tmp.Length, j = lineCnt + 2; i < j; i += 1)
            {
                buf.Append("0");
            }
            buf.Append("</span>");
            buf.Append(tmp);
            buf.Append("&nbsp;</").Append(tag).Append(">");
        }

        private int enCodeText(StringBuilder buf, String text, Dictionary<String, CodeKey> keyDict, Dictionary<String, CodeKey> regDict, int status)
        {
            // 字符处理结束
            if (String.IsNullOrEmpty(text))
            {
                return status;
            }

            #region 文档注释
            if (status == STATUS_DOCUMENT_COMMENT)
            {
                int c3 = text.IndexOf(codeCat.W205030D);
                // 继续文档注释
                if (c3 < 0)
                {
                    getSpan(buf, text, keyDict["※document_comment"].CodeCss);
                    return status;
                }

                c3 += codeCat.W205030D.Length;
                getSpan(buf, text.Substring(0, c3), keyDict["※document_comment"].CodeCss);
                return enCodeText(buf, text.Substring(c3), keyDict, regDict, 0);
            }
            #endregion

            #region 多行注释
            if (status == STATUS_MULTILINE_COMMENT)
            {
                int c2 = text.IndexOf(codeCat.W205030B);
                if (c2 < 0)
                {
                    getSpan(buf, text, keyDict["※multiline_comment"].CodeCss);
                    return status;
                }

                c2 += codeCat.W205030B.Length;
                getSpan(buf, text.Substring(0, c2), keyDict["※multiline_comment"].CodeCss);
                return enCodeText(buf, text.Substring(c2), keyDict, regDict, 0);
            }
            #endregion

            #region 多行字符串，暂不处理
            if (status == STATUS_MULTILINE_STRING)
            {
                return 0;
            }
            #endregion

            // 未做任何处理状态
            #region 判断用户使用哪个字符开始标记
            // 判断字符串标记，如javascript可以同时使用'和"
            int i0 = -1;
            String s1 = codeCat.W2050303 + codeCat.W2050304;
            String s2 = (String.IsNullOrEmpty(s1) ? "" : "[^{2}]") + "[{0}{1}]";
            Match match = Regex.Match(text, String.Format(s2, codeCat.W2050305, codeCat.W2050307, s1).Replace("\\", "\\\\"));
            if (match.Success)
            {
                i0 = match.Index + 1;
                s1 = String.IsNullOrEmpty(s1) ? match.Value : match.Value.Substring(1);
                s2 = (s1 == codeCat.W2050305 ? codeCat.W2050306 : codeCat.W2050308);
            }

            // 文档注释
            if (!String.IsNullOrEmpty(codeCat.W205030C))
            {
                int i3 = text.IndexOf(codeCat.W205030C);
                if (i3 > -1 && (i3 < i0 || i0 < 0))
                {
                    enCodeText(buf, text.Substring(0, i3), keyDict, regDict, 0);
                    int i = text.IndexOf(codeCat.W205030D, i3 + codeCat.W205030C.Length);
                    if (i < 0)
                    {
                        getSpan(buf, text.Substring(i3), keyDict["※document_comment"].CodeCss);
                        return STATUS_DOCUMENT_COMMENT;
                    }
                    i += codeCat.W205030D.Length;
                    getSpan(buf, text.Substring(i3, i - i3), keyDict["※multiline_comment"].CodeCss);
                    return enCodeText(buf, text.Substring(i), keyDict, regDict, 0);
                }
            }

            // 多行注释
            if (!String.IsNullOrEmpty(codeCat.W205030A))
            {
                int i2 = text.IndexOf(codeCat.W205030A);
                if (i2 > -1 && (i2 < i0 || i0 < 0))
                {
                    enCodeText(buf, text.Substring(0, i2), keyDict, regDict, 0);
                    int i = text.IndexOf(codeCat.W205030B, i2 + codeCat.W205030A.Length);
                    if (i < 0)
                    {
                        getSpan(buf, text.Substring(i2), keyDict["※multiline_comment"].CodeCss);
                        return STATUS_MULTILINE_COMMENT;
                    }
                    i += codeCat.W205030B.Length;
                    getSpan(buf, text.Substring(i2, i - i2), keyDict["※multiline_comment"].CodeCss);
                    return enCodeText(buf, text.Substring(i), keyDict, regDict, 0);
                }
            }

            // 单行注释
            if (!String.IsNullOrEmpty(codeCat.W2050309))
            {
                int i1 = text.IndexOf(codeCat.W2050309);
                if (i1 > -1 && (i1 < i0 || i0 < 0))
                {
                    enCodeText(buf, text.Substring(0, i1), keyDict, regDict, 0);
                    getSpan(buf, text.Substring(i1), keyDict["※singleline_comment"].CodeCss);
                    return 0;
                }
            }

            // 字符串
            if (i0 > -1)
            {
                match = Regex.Match(text, String.Format("{0}.*?{1}", s1, s2, codeCat.W2050303, codeCat.W2050304));
                if (match.Success)
                {
                    int i = match.Index;
                    buf.Append(replace(text.Substring(0, i), keyDict, regDict));
                    String t = match.Value;
                    getSpan(buf, t, keyDict["※string"].CodeCss);
                    return enCodeText(buf, text.Substring(i + t.Length), keyDict, regDict, 0);
                }
            }

            buf.Append(replace(text, keyDict, regDict));
            return 0;

            #endregion
        }

        private String replace(String text, Dictionary<String, CodeKey> keyDict, Dictionary<String, CodeKey> regDict)
        {
            StringBuilder buf = new StringBuilder();
            // 用户表达式
            foreach (String reg in regDict.Keys)
            {
                buf.Append(reg).Append('|');
            }

            // 通用表达式
            buf.Append('[');
            if (!String.IsNullOrEmpty(codeCat.W205030F))
            {
                buf.Append(codeCat.W205030F);
            }
            buf.Append("$\\w\\d]+").Append('|');

            // 数值表达式
            buf.Append(codeCat.W2050310);

            List<I1S1> list = new List<I1S1>();
            Match match = Regex.Match(text, buf.ToString());
            while (match.Success)
            {
                list.Add(new I1S1(match.Index, match.Value));
                match = match.NextMatch();
            }

            I1S1 item;
            bool next = false;
            buf.Remove(0, buf.Length).Append(text);
            for (int i = list.Count - 1; i >= 0; i -= 1)
            {
                item = list[i];
                foreach (String reg in regDict.Keys)
                {
                    if (Regex.IsMatch(item.V, reg))
                    {
                        next = true;
                        buf.Remove(item.K, item.V.Length).Insert(item.K, formatKey(item.V, regDict[reg]));
                        break;
                    }
                }

                if (next)
                {
                    next = false;
                    continue;
                }

                if (keyDict.ContainsKey(item.V))
                {
                    buf.Remove(item.K, item.V.Length).Insert(item.K, formatKey(item.V, keyDict[item.V]));
                    continue;
                }

                if (Regex.IsMatch(item.V, codeCat.W2050310))
                {
                    buf.Remove(item.K, item.V.Length).Insert(item.K, formatNum(item.V, keyDict["※number"]));
                }
            }

            return buf.ToString();
        }

        public String formatKey(String txt, CodeKey key)
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

            buf.Append(txt);

            return buf.Append("</").Append(tag).Append(">").ToString();
        }

        public String formatNum(String num, CodeKey key)
        {
            StringBuilder buf = new StringBuilder();
            getSpan(buf, num, key.CodeCss);
            return buf.ToString();
        }

        public void getFont(StringBuilder buf, CodeCss css)
        {
            if (css.IsValidateBgColor())
            {
                buf.Append("background-color:").Append(css.W2050206).Append(';');
            }
            if (css.IsValidateFgColor())
            {
                buf.Append("color:").Append(css.W2050207).Append(';');
            }
            if (!String.IsNullOrEmpty(css.W2050208))
            {
                buf.Append("font-family:").Append(css.W2050208).Append(';');
            }
            if (!String.IsNullOrEmpty(css.W2050209))
            {
                buf.Append("font-size:").Append(css.W2050209).Append(';');
            }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="txt"></param>
        /// <param name="css"></param>
        public void getSpan(StringBuilder buf, String txt, CodeCss css)
        {
            buf.Append("<span").Append(userOpt.InLineStyle ? " style=\"" : " class=\"");
            buf.Append(css.W2050205);
            buf.Append("\">");
            buf.Append(txt).Append("</span>");
        }
    }
}

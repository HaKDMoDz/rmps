using System;
using System.Text.RegularExpressions;

namespace Me.Amon.Util
{
    public class HttpUtil
    {
        public static string ToBase64String(byte[] input)
        {
            return Convert.ToBase64String(input).Replace("+", "-").Replace("/", "_");
        }

        public static byte[] FromBase64String(string input)
        {
            return Convert.FromBase64String(input.Replace("-", "+").Replace("_", "/"));
        }

        /// <summary>
        /// 普通文本到数据库字符串的转换
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static String Text2Db(String text)
        {
            return text != null ? text.Replace("\\", "\\\\").Replace("'", "\\'") : "";
        }

        public static String Text2Like(String text)
        {
            text = Regex.Replace(Text2Db(text), "[\\s%_]+", "%");
            if (text[0] != '%')
            {
                text = '%' + text;
            }
            if (text[text.Length - 1] != '%')
            {
                text += '%';
            }
            return text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static String Db2Html(Object obj)
        {
            if (obj == null)
            {
                return "&nbsp;";
            }
            String text = obj.ToString();
            if (text == "")
            {
                return "&nbsp;";
            }
            return text.Replace("&", "&amp;").Replace("  ", "&nbsp;&nbsp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("\r\n", "<br />").Replace("\n", "<br />");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Db2Xml(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            String text = obj.ToString().Trim();
            if (text == "")
            {
                return "";
            }
            return text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");
        }
    }
}

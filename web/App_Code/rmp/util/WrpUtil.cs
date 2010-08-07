using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using cons;
using System.Text.RegularExpressions;

namespace rmp.util
{
    /// <summary>
    /// WrpUtil 的摘要说明
    /// </summary>
    public class WrpUtil
    {
        private static String syncScript;

        private WrpUtil()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static String SyncScript
        {
            get
            {
                if (syncScript == null)
                {
                    syncScript = "";
                    StreamReader sr = File.OpenText(HttpContext.Current.Server.MapPath("~/_script/sync.js"));
                    syncScript = TrimCode(sr);
                    sr.Close();
                }
                return syncScript;
            }
        }

        /// <summary>
        /// 普通文本到数据库字符串的转换
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static String text2Db(String text)
        {
            return text != null ? text.Replace("\\", "\\\\").Replace("'", "\\'") : "";
        }

        public static String text2Like(String text)
        {
            text = Regex.Replace(text2Db(text), "[\\s%_]+", "%");
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
        public static String db2Html(Object obj)
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
        public static string db2Xml(object obj)
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

        /// <summary>
        /// 属性数据编码
        /// </summary>
        /// <param name="control">列表控件</param>
        /// <param name="attribute">要添加的属性名称</param>
        /// <param name="escapeChar">属性值分隔符</param>
        public static void EncodeAttributes(System.Web.UI.WebControls.ListControl control, String attribute, char escapeChar)
        {
            System.Text.StringBuilder buf = new System.Text.StringBuilder();
            foreach (System.Web.UI.WebControls.ListItem item in control.Items)
            {
                buf.Append(item.Attributes[attribute]).Append(escapeChar);
            }
            control.Attributes.Add(attribute, buf.ToString(0, buf.Length - 1));
        }

        /// <summary>
        /// 属性数据解码
        /// </summary>
        /// <param name="control">列表控件</param>
        /// <param name="attribute">要添加的属性名称</param>
        /// <param name="escapeChar">属性值分隔符</param>
        public static void DecodeAttributes(System.Web.UI.WebControls.ListControl control, String attribute, char escapeChar)
        {
            String tmp = control.Attributes[attribute];
            if (String.IsNullOrEmpty(tmp))
            {
                return;
            }
            String[] values = tmp.Split(escapeChar);
            System.Web.UI.WebControls.ListItemCollection items = control.Items;
            for (int i = 0, j = values.Length > items.Count ? items.Count : values.Length; i < j; i += 1)
            {
                items[i].Attributes.Add(attribute, values[i]);
            }
        }

        /// <summary>
        /// 查看指定页面的源代码
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static String readHtmlCode(String url)
        {
            WebRequest Request = WebRequest.Create(url);
            WebResponse Response = Request.GetResponse();
            Stream Stream = Response.GetResponseStream();
            StreamReader Reader = new StreamReader(Stream, getEncoding(Response));
            String htmlCode = Reader.ReadToEnd();
            Reader.Close();
            Stream.Close();

            return htmlCode;
        }

        /// <summary>
        /// 获取页面的字符编码信息
        /// </summary>
        /// <param name="Response"></param>
        /// <returns></returns>
        public static Encoding getEncoding(WebResponse Response)
        {
            String ContentType = Response.ContentType;
            int i = ContentType.IndexOf("charset=");
            if (i >= 0)
            {
                i += 8;
                int j = ContentType.IndexOf(';', i);
                if (j >= i)
                {
                    return Encoding.GetEncoding(ContentType.Substring(i, j - i).Trim());
                }
                return Encoding.GetEncoding(ContentType.Substring(i));
            }
            return Encoding.Default;
        }

        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="f">发送人的邮件地址</param>
        /// <param name="t">要发送的邮件地址</param>
        /// <param name="s">邮件标题</param>
        /// <param name="b">邮件内容</param>
        public static void sendMail(String f, String t, String s, String b)
        {
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(f);//发件人信箱
            mm.To.Add(t);//收件人信箱
            mm.Subject = s;//主题
            mm.Body = b;//内容

            mm.Priority = MailPriority.Low;//优先级
            mm.IsBodyHtml = true;

            //mm.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername","username");
            //mm.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword","password");
            //mm.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate","1");
            //mm.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver","smtpserver");

            //附件的添加 
            //System.Web.Mail.MailAttachment _attach=null; 
            //if(this.inputmail.Value!="") //客户端的'浏览文件'控件
            //{
            //	_attach=new MailAttachment(this.inputmail.Value);
            //	mm.Attachments.Add(_attach);
            //}
            SmtpClient sc = new SmtpClient();
            sc.Host = "smtp.amonsoft.cn";
            sc.Send(mm);
        }

        /// <summary>
        /// 根据默认编码方式对字符串进行编码
        /// </summary>
        /// <param name="text"></param>
        /// <param name="code"></param>
        public static String EncodeText(String text, String code)
        {
            String ansi = "";
            byte[] temp = Encoding.GetEncoding(code).GetBytes(text);
            foreach (byte b in temp)
            {
                ansi += "%" + Convert.ToString(b, 16);
            }
            return ansi;
        }

        /// <summary>
        /// 获取系统支持的所有编码方案
        /// </summary>
        /// <param name="sortByName"></param>
        /// <returns></returns>
        public static EncodingInfo[] GetEncodings(bool sortByName)
        {
            EncodingInfo[] infos = Encoding.GetEncodings();
            if (!sortByName)
            {
                return infos;
            }

            EncodingInfo info;
            for (int i = 0; i < infos.Length; i += 1)
            {
                for (int j = i + 1; j < infos.Length; j += 1)
                {
                    if (infos[i].Name.ToLower().CompareTo(infos[j].Name.ToLower()) > 0)
                    {
                        info = infos[j];
                        infos[j] = infos[i];
                        infos[i] = info;
                    }
                }
            }
            return infos;
        }

        /// <summary>
        /// 代码压缩
        /// </summary>
        /// <param name="sr"></param>
        /// <returns></returns>
        public static String TrimCode(StreamReader sr)
        {
            StringBuilder sb = new StringBuilder();
            String line;
            bool inComment = false;
            bool copyRight = false;
            while (true)
            {
                line = sr.ReadLine();

                // 文档结束
                if (line == null)
                {
                    break;
                }

                // 文档注释开始
                if (line.StartsWith("/***"))
                {
                    copyRight = true;
                }

                // 多行注释中
                if (copyRight)
                {
                    // 多行注释结束
                    if (line.EndsWith("***/"))
                    {
                        copyRight = false;
                    }
                    sb.Append(line).Append("\n");
                    continue;
                }

                // 空行
                line = line.Trim();
                if (line == "")
                {
                    continue;
                }

                // 单行注释
                if (line.StartsWith("//"))
                {
                    continue;
                }

                // 多行注释开始
                if (line.StartsWith("/*"))
                {
                    inComment = true;
                }

                // 多行注释中
                if (inComment)
                {
                    // 多行注释结束
                    if (line.EndsWith("*/"))
                    {
                        inComment = false;
                    }
                    continue;
                }

                sb.Append(line);
            }

            return sb.ToString();
        }
    }
}
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace Me.Amon.Http
{
    public class HttpUtil
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// Headers
        /// </summary>
        public WebHeaderCollection Headers { get; private set; }

        /// <summary>
        /// 是否跳转后的页面
        /// </summary>
        public bool AllowAutoRedirect { get; set; }

        /// <summary>
        /// Referer
        /// </summary>
        public string Referer { get; set; }

        /// <summary>
        /// Accept
        /// </summary>
        public string Accept { get; set; }

        /// <summary>
        /// AcceptEncoding 'gzip, deflate
        /// </summary>
        public string AcceptEncoding { get; set; }

        /// <summary>
        /// AcceptLanguage  'zh-CN
        /// </summary>
        public string AcceptLanguage { get; set; }

        /// <summary>
        /// ContentType
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// KeepAlive
        /// </summary>
        public bool KeepAlive { get; set; }

        /// <summary>
        /// UserAgent
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// 模式
        /// </summary>
        public HttpMethod Method { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public Encoding Encoding { get; set; }

        /// <summary>
        /// 获取错误
        /// </summary>
        public string ErrMsg { get; set; }

        /// <summary>
        /// 获取结果
        /// </summary>
        public string Html { get; set; }

        public bool Post(string url, byte[] data)
        {
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            try
            {
                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                if (!string.IsNullOrEmpty(Referer))
                {
                    httpWebRequest.Referer = Referer;
                }
                httpWebRequest.Accept = Accept;
                if (!string.IsNullOrEmpty(AcceptLanguage))
                {
                    httpWebRequest.Headers[HttpRequestHeader.AcceptLanguage] = AcceptLanguage;
                }
                if (!string.IsNullOrEmpty(AcceptEncoding))
                {
                    httpWebRequest.Headers[HttpRequestHeader.AcceptEncoding] = AcceptEncoding;
                }
                //httpWebRequest.KeepAlive = KeepAlive;
                httpWebRequest.UserAgent = UserAgent;
                httpWebRequest.Method = Enum.GetName(typeof(HttpMethod), Method);
                httpWebRequest.ServicePoint.Expect100Continue = false;
                httpWebRequest.AllowAutoRedirect = AllowAutoRedirect;
                if (Method == HttpMethod.POST && data != null && data.Length > 0)
                {
                    httpWebRequest.ContentType = ContentType;
                    httpWebRequest.ContentLength = data.Length;
                    Stream stream = httpWebRequest.GetRequestStream();
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                }

                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Headers = httpWebResponse.Headers;
                StreamReader streamReader = null;
                if (httpWebResponse.ContentEncoding != null && httpWebResponse.ContentEncoding.Equals("gzip", StringComparison.InvariantCultureIgnoreCase))
                {
                    using (streamReader = new StreamReader(new GZipStream(httpWebResponse.GetResponseStream(), CompressionMode.Decompress), Encoding))
                    {
                        Html = streamReader.ReadToEnd();
                    }
                }
                else
                {
                    using (streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding))
                    {
                        Html = streamReader.ReadToEnd();
                    }
                }
                StatusCode = httpWebResponse.StatusCode;
                return true;
            }
            catch (Exception e)
            {
                ErrMsg = e.Message;
                return false;
            }
            finally
            {
                if (httpWebRequest != null)
                {
                    httpWebRequest.Abort();
                }
                if (httpWebResponse != null)
                {
                    httpWebResponse.Close();
                }
            }
        }

        public static string ToBase64String(byte[] input)
        {
            return Convert.ToBase64String(input).Replace("+", "-").Replace("/", "_");
        }

        public static byte[] FromBase64String(string input)
        {
            return Convert.FromBase64String(input.Replace("-", "+").Replace("_", "/"));
        }

        public static string Escape(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if (Char.IsLetterOrDigit(c))
                {
                    sb.Append(c);
                    continue;
                }
                // -_.~
                if (c == '-' || c == '_' || c == '.' || c == '~')
                {
                    sb.Append(c);
                    continue;
                }
                sb.Append(Uri.HexEscape(c));
            }
            return sb.ToString();
        }
    }
}

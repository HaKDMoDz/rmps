using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Me.Amon.Open
{
    public abstract class OAuthServer
    {
        public byte[] Get(string url, string data)
        {
            url += url.IndexOf("?") >= 0 ? '&' : '?';
            url += data;

            WebClient client = new WebClient();
            return client.DownloadData(url);
        }

        public byte[] MultipartPost(string url, Dictionary<string, object> posts, string agent, string connection, int timeOut)
        {
            var boundary = string.Format("----------{0}", DateTime.Now.Ticks.ToString("x"));

            var iStream = GenMultipart(posts, boundary);

            #region 发送请求
            var request = WebRequest.Create(url) as HttpWebRequest;
            if (request == null)
            {
                return null;
            }

            request.Method = "POST";
            request.ContentLength = iStream.Length;
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            if (!string.IsNullOrWhiteSpace(agent))
            {
                request.UserAgent = agent;
            }
            if (!string.IsNullOrWhiteSpace(connection))
            {
                request.Connection = connection;
            }
            if (timeOut > 0)
            {
                request.Timeout = timeOut;
            }
            request.CookieContainer = new CookieContainer();

            var oStream = request.GetRequestStream();
            iStream.WriteTo(oStream);
            oStream.Close();
            iStream.Close();

            var response = request.GetResponse() as HttpWebResponse;
            var buffer = new byte[response.ContentLength];
            using (var rStream = response.GetResponseStream())
            {
                rStream.Read(buffer, 0, buffer.Length);
                response.Close();
            }

            request.Abort();
            #endregion

            return buffer;
        }

        private MemoryStream GenMultipart(Dictionary<string, object> posts, string boundary)
        {
            // CLRF
            var CLRF = "\r\n";

            var memStream = new MemoryStream();

            #region 参数
            // 写入起始边界符
            string header = string.Format("--{0}{1}", boundary, CLRF);
            byte[] buffer = Encoding.ASCII.GetBytes(header);
            memStream.Write(buffer, 0, buffer.Length);

            // 写入字符串的Key
            foreach (var param in posts)
            {
                if (param.Value is FileParameter)
                {
                    FileParameter file = (FileParameter)param.Value;

                    header = string.Format("--{0}{1}", boundary, CLRF);
                    buffer = Encoding.ASCII.GetBytes(header);
                    memStream.Write(buffer, 0, buffer.Length);

                    header = string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}", param.Key, file.FileName ?? param.Key, CLRF);
                    buffer = Encoding.UTF8.GetBytes(header);
                    memStream.Write(buffer, 0, buffer.Length);

                    header = string.Format("Content-Type: {0}{1}{1}", file.ContentType ?? "application/octet-stream", CLRF);
                    buffer = Encoding.UTF8.GetBytes(header);
                    memStream.Write(buffer, 0, buffer.Length);

                    memStream.Write(file.File, 0, file.File.Length);
                }
                else
                {
                    header = string.Format("--{0}{1}", boundary, CLRF);
                    buffer = Encoding.ASCII.GetBytes(header);
                    memStream.Write(buffer, 0, buffer.Length);

                    header = string.Format("Content-Disposition: form-data; name=\"{0}\"{1}{1}", param.Key, CLRF);
                    buffer = Encoding.ASCII.GetBytes(header);
                    memStream.Write(buffer, 0, buffer.Length);

                    header = string.Format("{0}", param.Value);
                    buffer = Encoding.UTF8.GetBytes(header);
                    memStream.Write(buffer, 0, buffer.Length);
                }
            }
            #endregion

            // 写入结束边界符
            header = string.Format("{0}--{1}--{0}", CLRF, boundary);
            buffer = Encoding.ASCII.GetBytes(header);
            memStream.Write(buffer, 0, buffer.Length);

            return memStream;
        }

        public class FileParameter
        {
            public byte[] File { get; set; }

            public string FileName { get; set; }

            public string ContentType { get; set; }

            public FileParameter(byte[] file) : this(file, null) { }

            public FileParameter(byte[] file, string filename) : this(file, filename, null) { }

            public FileParameter(byte[] file, string filename, string contenttype)
            {
                File = file;
                FileName = filename;
                ContentType = contenttype;
            }
        }
    }
}

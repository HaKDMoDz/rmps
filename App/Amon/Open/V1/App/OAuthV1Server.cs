using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Me.Amon.Open.V1.App
{
    public class OAuthV1Server
    {
        public string RequestTokenUrl { get; protected set; }
        public string VerifierUrl { get; protected set; }
        public string AccessTokenUrl { get; protected set; }
        public string ProfileUrl { get; protected set; }
        public string SignatureMethod { get; protected set; }

        public byte[] MakeHttpRequest(string method, string url, Dictionary<string, string> headers, string data)
        {
            if (method == "GET" && !string.IsNullOrEmpty(data))
            {
                url += url.IndexOf("?") >= 0 ? '&' : '?';
                url += data;
            }

            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.Proxy = null;
            ServicePointManager.Expect100Continue = false;
            HttpWebResponse response = null;

            request.Method = method;

            if (method.ToUpper() == "POST")
            {
                request.ContentType = "application/x-www-form-urlencoded";
            }

            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            if (method != "GET" && !string.IsNullOrEmpty(data))
            {
                Stream s = request.GetRequestStream();
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                s.Write(bytes, 0, bytes.Length);
                s.Close();
            }

            byte[] resultData = null;

            try
            {
                response = request.GetResponse() as HttpWebResponse;

                MemoryStream ms = new MemoryStream();
                BinaryReader br = new BinaryReader(response.GetResponseStream());
                BinaryWriter bw = new BinaryWriter(ms);

                int cnt;
                byte[] buf = new byte[1024];
                while (true)
                {
                    cnt = br.Read(buf, 0, buf.Length);
                    if (cnt < 1)
                    {
                        break;
                    }

                    bw.Write(buf, 0, cnt);
                }

                br.Close();
                bw.Flush();

                resultData = ms.ToArray();
                bw.Close();
                ms.Close();
            }
            finally
            {
                response.Close();
            }

            return resultData;
        }
    }
}

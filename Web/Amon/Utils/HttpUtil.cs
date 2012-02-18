using System.Net;
using System.Threading;
using System.Windows;
using System;
using System.IO;

namespace Me.Amon.Utils
{
    public class HttpUtil
    {
        private SynchronizationContext syncContext;
        private string postData = string.Empty;
        private void PostData(object sender, RoutedEventArgs e)
        {
            //请注意：Silverlight 里的 HttpWebRequest, Encoding 类的属性和方法与常规的 .NET Framework 里面还是不同的。
            postData = "paramXml=data.Text"; //要提交的内容 
            Uri url = new Uri("http://128.128.4.189:131/", UriKind.Absolute);
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST"; // Silverlight 只支持 GET 和 POST 方法
            request.AllowReadStreamBuffering = true;
            request.ContentType = "application/x-www-form-urlencoded";
            request.BeginGetRequestStream(new AsyncCallback(RequestReady), request);
        }

        private void RequestReady(IAsyncResult asyncResult)
        {
            HttpWebRequest request = asyncResult.AsyncState as HttpWebRequest;
            StreamWriter postStream = new StreamWriter(request.EndGetRequestStream(asyncResult));
            //byte[] byteArray = Encoding.UTF8.GetBytes(postData); //Encoding.GetEncoding()方法只支持四种编码。utf-8 , utf-16 , utf-16BE , utf-16LE
            postStream.Write(postData); //处理中文的问题。不要使用 Stream 的 Write 方法。 
            postStream.Close();
            postStream.Dispose();
            request.BeginGetResponse(new AsyncCallback(ResponseReady), request);
        }

        private void ResponseReady(IAsyncResult asyncResult)
        {
            HttpWebRequest request = asyncResult.AsyncState as HttpWebRequest;
            WebResponse response = request.EndGetResponse(asyncResult) as WebResponse; //同步线程上下文
            if (syncContext == null) syncContext = new SynchronizationContext();
            syncContext.Post(ExtractResponse, response);
        }

        private void ExtractResponse(object state)
        {
            WebResponse response = state as WebResponse;
            Stream responseStream = response.GetResponseStream();
            StreamReader streamRead = new StreamReader(responseStream); //显示返回的数据
            string Text = new StreamReader(responseStream).ReadToEnd();
            response.Close();
            responseStream.Close();
            responseStream.Dispose();
            streamRead.Close();
            streamRead.Dispose();
        }
    }
}

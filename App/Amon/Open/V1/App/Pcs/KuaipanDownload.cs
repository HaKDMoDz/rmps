using System;
using System.IO;
using System.Net;
using System.Threading;
using Me.Amon.Http;

namespace Me.Amon.Open.V1.App.Pcs
{
    public class KuaipanDownload : TaskInfo
    {
        private KuaipanClient _Client;

        public KuaipanDownload(KuaipanClient client)
        {
            _Client = client;
        }

        protected override void DoWork()
        {
            var request = _Client.BeginDownload(this);
            if (FileSize > 0)
            {
                request.AddRange(FileSize); //设置Range值
            }

            HttpWebResponse response = null;
            Stream iStream = null;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
                if (response.StatusCode == HttpStatusCode.Accepted)
                {
                    Message = "Error!!!";
                    return;
                }

                MetaSize = response.ContentLength;
                if (MetaSize > -1 && FileSize < MetaSize)
                {
                    iStream = response.GetResponseStream();

                    int count;
                    byte[] buffer = new byte[10240];
                    while (Status == TaskStatus.RUNNING)
                    {
                        count = iStream.Read(buffer, 0, buffer.Length);
                        if (count < 1)
                        {
                            break;
                        }
                        FileStream.Write(buffer, 0, count);
                        FileSize += count;
                        Percent = (double)FileSize / MetaSize;
                    }
                }

                Status = TaskStatus.DONE;
                Percent = 1d;
                Message = "下载完成";
            }
            catch (Exception exp)
            {
                Message = exp.Message;
            }
            finally
            {
                if (iStream != null)
                {
                    iStream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (FileStream != null)
                {
                    FileStream.Close();
                }

                // 用户暂停
                IsAlive = false;
            }
        }
    }
}

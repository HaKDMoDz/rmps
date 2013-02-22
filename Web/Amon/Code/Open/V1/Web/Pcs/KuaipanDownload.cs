using System;
using System.IO;
using System.Net;
using Me.Amon.Http;

namespace Me.Amon.Open.V1.Web.Pcs
{
    public class KuaipanDownload : TaskInfo
    {
        private KuaipanClient _Client;

        public KuaipanDownload(KuaipanClient client)
        {
            _Client = client;
        }

        public override void Run()
        {
            IsAlive = true;
            Status = TaskStatus.RUNNING;

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
                    IsAlive = false;
                    Status = TaskStatus.ERROR;
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
                Status = TaskStatus.ERROR;
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

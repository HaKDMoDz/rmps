using System;
using System.IO;
using System.Text;
using Me.Amon.Http;

namespace Me.Amon.Open.V1.App.Pcs
{
    public class KuaipanUpload : TaskInfo
    {
        private KuaipanClient _Client;

        public KuaipanUpload(KuaipanClient client)
        {
            _Client = client;
        }

        public override void Run()
        {
            IsAlive = true;
            Status = TaskStatus.RUNNING;

            var uri = _Client.BeginUpload(this);
            if (string.IsNullOrWhiteSpace(uri))
            {
                IsAlive = false;
                Status = TaskStatus.ERROR;
                return;
            }
            var oStream = new MemoryStream();

            IsAlive = true;
            Message = "上传中";

            if (FileSize > -1)
            {
                Percent = 0.2;

                int count;
                byte[] buffer = new byte[10240];
                while (Status == TaskStatus.RUNNING)
                {
                    count = FileStream.Read(buffer, 0, buffer.Length);
                    if (count < 1)
                    {
                        break;
                    }
                    oStream.Write(buffer, 0, count);
                }

                Percent = 0.6;
            }
            FileStream.Close();
            oStream.Close();

            try
            {
                MsMultiPartFormData form = new MsMultiPartFormData();
                form.AddStreamFile("file", MetaName, oStream.ToArray());
                form.PrepareFormData();

                uri = _Client.ChangeUploadUrl(uri, Meta);

                HttpUtil http = new HttpUtil();
                http.Encoding = Encoding.UTF8;
                http.Method = HttpMethod.POST;
                http.ContentType = "multipart/form-data; boundary=" + form.Boundary;
                http.Post(uri, form.GetFormData().ToArray());

                var t = http.Html;

                Percent = 1d;
                Message = "上传完成";

                Status = TaskStatus.DONE;
            }
            catch (Exception exp)
            {
                Message = exp.Message;
                Status = TaskStatus.ERROR;
            }
            finally
            {
                // 用户暂停
                IsAlive = false;
            }
        }
    }
}

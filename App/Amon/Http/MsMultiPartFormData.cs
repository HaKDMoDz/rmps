using System;
using System.Collections.Generic;
using System.Text;

namespace Me.Amon.Http
{
    public class MsMultiPartFormData
    {
        private const string CRLF = "\r\n";
        private const string CONTENTTYPE = "Content-Type: {0}{1}{2}";
        private const string CONTENT_DISPOSITION = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}";

        private List<byte> formData;
        public string Boundary = string.Format("--{0}--", Guid.NewGuid());
        private Encoding encode = Encoding.GetEncoding("UTF-8");

        public MsMultiPartFormData()
        {
            formData = new List<byte>();
        }

        public void AddFile(string FieldName, string FileName, byte[] FileContent, string ContentType)
        {
            formData.AddRange(encode.GetBytes(string.Format("--{0}{1}", Boundary, CRLF)));
            formData.AddRange(encode.GetBytes(string.Format(CONTENT_DISPOSITION, FieldName, FileName, CRLF)));
            formData.AddRange(encode.GetBytes(string.Format(CONTENTTYPE, ContentType, CRLF, CRLF)));
            formData.AddRange(FileContent);
            formData.AddRange(encode.GetBytes(CRLF));
        }

        public void AddStreamFile(string FieldName, string FileName, byte[] FileContent)
        {
            AddFile(FieldName, FileName, FileContent, "application/octet-stream");
        }

        public void PrepareFormData()
        {
            formData.AddRange(encode.GetBytes("--" + Boundary + "--"));
        }

        public List<byte> GetFormData()
        {
            return formData;
        }
    }
}

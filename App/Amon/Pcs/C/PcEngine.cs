using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Me.Amon.Pcs.C
{
    public class PcEngine
    {
        public FileStream OpenWrite(string path)
        {
            return File.OpenWrite(path);
        }

        public FileStream OpenRead(string file)
        {
            return File.OpenRead(file);
        }

        public string ComputeHash(string file)
        {
            FileStream stream = File.OpenRead(file);
            HashAlgorithm alg = HashAlgorithm.Create("MD5");
            byte[] buf = alg.ComputeHash(stream);
            stream.Close();

            StringBuilder builder = new StringBuilder();
            foreach (byte b in buf)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}

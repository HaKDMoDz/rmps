using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Me.Amon.Util
{
    public sealed class SafeUtil
    {
        public static bool EncryptFile(string alg, string key, string srcFile, string dstFile)
        {
            try
            {
                SymmetricAlgorithm cipher = SymmetricAlgorithm.Create(alg);
                cipher.Key = Encoding.Default.GetBytes(key);
                cipher.IV = cipher.Key;

                FileStream iStream = File.OpenRead(srcFile);
                FileStream oStream = new FileStream(dstFile, FileMode.Create);

                CryptoStream cStream = new CryptoStream(oStream, cipher.CreateEncryptor(), CryptoStreamMode.Write);
                byte[] buffer = new byte[4096];
                int len = iStream.Read(buffer, 0, buffer.Length);
                while (len > 0)
                {
                    cStream.Write(buffer, 0, len);
                    len = iStream.Read(buffer, 0, buffer.Length);
                }

                cStream.Flush();
                cStream.Close();

                oStream.Close();
                iStream.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DecryptFile(string alg, string key, string srcFile, string dstFile)
        {
            try
            {
                SymmetricAlgorithm cipher = SymmetricAlgorithm.Create(alg);
                cipher.Key = Encoding.Default.GetBytes(key);
                cipher.IV = cipher.Key;

                FileStream iStream = File.OpenRead(srcFile);
                FileStream oStream = new FileStream(dstFile, FileMode.Create);

                CryptoStream cStream = new CryptoStream(oStream, cipher.CreateDecryptor(), CryptoStreamMode.Write);
                byte[] buffer = new byte[4096];
                int len = iStream.Read(buffer, 0, buffer.Length);
                while (len > 0)
                {
                    cStream.Write(buffer, 0, len);
                    len = iStream.Read(buffer, 0, buffer.Length);
                }

                cStream.Flush();
                cStream.Close();

                oStream.Close();
                iStream.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Me.Amon.Util
{
    public sealed class SafeUtil
    {
        private static string _OldText;
        private static Timer _Timer;
        public static void Copy(string newText)
        {
            Copy(newText, 5);
        }

        public static void Copy(string newText, int seconds)
        {
            if (string.IsNullOrEmpty(newText))
            {
                return;
            }

            _OldText = Clipboard.GetText();
            Clipboard.SetText(newText);
            if (_Timer == null)
            {
                _Timer = new Timer();
                _Timer.Tick += new EventHandler(Timer_Tick);
            }
            _Timer.Interval = 1000 * seconds;
            _Timer.Start();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_OldText))
            {
                Clipboard.Clear();
            }
            else
            {
                Clipboard.SetText(_OldText);
            }
            _OldText = null;
            _Timer.Stop();
        }

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

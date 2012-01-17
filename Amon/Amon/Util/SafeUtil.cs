using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Me.Amon.Util
{
    public sealed class SafeUtil
    {
        public static string EncryptPass(string pass)
        {
            if (string.IsNullOrEmpty(pass))
            {
                return "";
            }
            byte[] temp = Encoding.UTF8.GetBytes(pass);
            temp = new SHA256Managed().ComputeHash(temp);
            //temp = MD5.Create("MD5").ComputeHash(temp);
            return Convert.ToBase64String(temp);
        }

        private static string _OldText;
        private static Timer _Timer;
        public static void Copy(string newText)
        {
            _OldText = System.Windows.Forms.Clipboard.GetText();
            System.Windows.Forms.Clipboard.SetText(newText);
            if (_Timer == null)
            {
                _Timer = new Timer();
                _Timer.Tick += new EventHandler(Timer_Tick);
            }
            _Timer.Interval = 1000 * 5;
            _Timer.Start();
        }

        public static void Copy(string newText, int minutes)
        {
            _OldText = System.Windows.Forms.Clipboard.GetText();
            System.Windows.Forms.Clipboard.SetText(newText);
            if (_Timer == null)
            {
                _Timer = new Timer();
                _Timer.Tick += new EventHandler(Timer_Tick);
            }
            _Timer.Interval = 1000 * minutes;
            _Timer.Start();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(_OldText);
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

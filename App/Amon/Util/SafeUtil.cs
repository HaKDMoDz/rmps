using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Me.Amon.Util
{
    public sealed class SafeUtil
    {
        #region 剪贴板事件
        private static string _OldText;
        private static Timer _Timer;
        public static void Copy(string newText)
        {
            Copy(newText, 60);
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
        #endregion

        #region 文件处理
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
        #endregion

        #region 随机口令
        public static string GenPass(string data, int length)
        {
            StringBuilder buf = new StringBuilder(data);
            for (int i = buf.Length, j = length; i < j; i += 1)
            {
                buf.Append(' ');
            }
            return buf.ToString();
        }

        /// <summary>
        /// 随机用户口令
        /// </summary>
        /// <returns></returns>
        public static char[] GenerateUserKeys()
        {
            char[] c = new char[94];
            int i = 0;
            char t = '!';
            while (i < 94)
            {
                c[i++] = t++;
            }

            return NextRandomKey(c, 8, false);
        }

        public static char[] GenerateFileKeys()
        {
            char[] c = new char[94];
            int i = 0;
            char t = '!';
            while (i < 94)
            {
                c[i++] = t++;
            }

            return NextRandomKey(c, 16, false);
        }

        /// <summary>
        /// 随机字符生成
        /// </summary>
        /// <param name="sets"></param>
        /// <param name="size"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        public static char[] NextRandomKey(char[] sets, int size, bool loop)
        {
            if (sets == null || (!loop && sets.Length < size))
            {
                return null;
            }

            char[] r = new char[size];
            Random random = new Random();
            for (int i = 0, l = sets.Length, t; i < size; i++)
            {
                t = random.Next(l);
                r[i] = sets[t];
                if (!loop)
                {
                    l -= 1;
                    sets[t] = sets[l];
                }
            }

            return r;
        }
        #endregion
    }
}

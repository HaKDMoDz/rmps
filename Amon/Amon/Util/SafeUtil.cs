using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

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
        public static void dd()
        {
            _OldText = System.Windows.Forms.Clipboard.GetText();
            if (_Timer == null)
            {
                _Timer = new Timer(new TimerCallback(TimerEnd_CallBack));
            }
            _Timer.Change(0, 1000 * 60);
        }

        private static void TimerEnd_CallBack(object state)
        {
            System.Windows.Forms.Clipboard.SetText(_OldText);
            _Timer.Change(-1, -1);
        }
    }
}

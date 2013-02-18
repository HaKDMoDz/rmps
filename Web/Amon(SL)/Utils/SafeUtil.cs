using System;
using System.Security.Cryptography;
using System.Text;

namespace Me.Amon.Utils
{
    public class SafeUtil
    {
        public static string EncryptPass(string pass)
        {
            if (string.IsNullOrEmpty(pass))
            {
                return "";
            }
            byte[] temp = Encoding.UTF8.GetBytes(pass);
            temp = new SHA256Managed().ComputeHash(temp);
            return Convert.ToBase64String(temp);
        }
    }
}
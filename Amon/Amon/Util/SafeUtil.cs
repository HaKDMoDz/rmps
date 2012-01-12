using System;
using System.Security.Cryptography;
using System.Text;

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
    }
}

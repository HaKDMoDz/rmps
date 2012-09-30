using System;
using System.Security.Cryptography;
using System.Text;

namespace Me.Amon.Open
{
    public class OAuthUtility
    {
        private const string ReservedChars = @"`!@#$%^&*()_-+=.~,:;'?/|\[] ";
        private const string UnReservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

        /// <summary>
        /// URL Encoding Function.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string UrlEncode(string value)
        {
            StringBuilder result = new StringBuilder();

            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            foreach (var symbol in value)
            {
                if (UnReservedChars.IndexOf(symbol) != -1)
                {
                    result.Append(symbol);
                }
                else if (ReservedChars.IndexOf(symbol) != -1)
                {
                    result.Append('%' + String.Format("{0:X2}", (int)symbol).ToUpper());
                }
                else
                {
                    var encoded = ""; // HttpUtility.UrlEncode(symbol.ToString()).ToUpper();

                    if (!string.IsNullOrEmpty(encoded))
                    {
                        result.Append(encoded);
                    }
                }
            }

            return result.ToString();
        }

        public virtual byte[] GetBytes(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        public static string GetOAuthNonce()
        {
            //StringBuilder nonceData = new StringBuilder();
            //byte[] data = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(GetOAuthTimestamp()));

            //foreach (byte d in data)
            //{
            //    nonceData.Append(d.ToString("x2").ToLower());
            //}

            //return nonceData.ToString();
            return new Random().Next(123400, 9999999).ToString();
        }

        public static string GetOAuthTimestamp()
        {
            //TimeSpan span = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
            //return Math.Ceiling(span.TotalSeconds).ToString();
            DateTime dt = new DateTime(1970, 1, 1);
            if (dt.Kind == DateTimeKind.Unspecified)
            {
                DateTime.SpecifyKind(dt, DateTimeKind.Local);
            }
            TimeSpan ts = DateTime.Now - dt;
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        public static string ComputeHMACSHA1Hash(string Key, string HashData)
        {
            HMACSHA1 hashAlgorithm = new HMACSHA1(Encoding.UTF8.GetBytes(Key));
            byte[] hashedData = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(HashData));
            hashAlgorithm = null;
            return Convert.ToBase64String(hashedData);
        }
    }
}

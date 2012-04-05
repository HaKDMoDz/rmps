using System;

namespace Me.Amon.Util
{
    public class HttpUtil
    {
        public static string ToBase64String(byte[] input)
        {
            return Convert.ToBase64String(input).Replace("+", "-").Replace("/", "_");
        }

        public static byte[] FromBase64String(string input)
        {
            return Convert.FromBase64String(input.Replace("-", "+").Replace("_", "/"));
        }
    }
}

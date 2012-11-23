using System;
using System.Text;

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

        public static string Escape(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if (Char.IsLetterOrDigit(c))
                {
                    sb.Append(c);
                    continue;
                }
                // -_.~
                if (c == '-' || c == '_' || c == '.' || c == '~')
                {
                    sb.Append(c);
                    continue;
                }
                sb.Append(Uri.HexEscape(c));
            }
            return sb.ToString();
        }
    }
}

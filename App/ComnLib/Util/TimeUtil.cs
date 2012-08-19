using System;
using System.Text.RegularExpressions;

namespace Me.Amon.Util
{
    public class TimeUtil
    {
        public static DateTime Parse(string str, char a, char b, char c)
        {
            DateTime now = DateTime.Now;
            if (str == null)
            {
                return now;
            }
            str = str.Trim();
            if (!Regex.IsMatch(str, string.Format("[^{0}{1}{2}\\d]", a, b, c)))
            {
                return now;
            }
            int i = str.IndexOf(c);
            if (i < 0)
            {
                return ParseDate(now, str, a);
            }

            now = ParseDate(now, str.Substring(0, i), a);
            return ParseTime(now, str.Substring(i + 1), b);
        }

        public static DateTime ParseDate(DateTime now, string str, char s)
        {
            string[] arr = str.Split(s);
            if (arr.Length == 3)
            {
                //now.Year = int.Parse(arr[0]);
                //now.Month = int.Parse(arr[1]);
                //now.Day = int.Parse(arr[2]);
            }
            Convert.ToDateTime("", null);
            return now;
        }

        public static DateTime ParseTime(DateTime now, string str, char s)
        {
            return now;
        }
    }
}

using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Me.Amon.Utils
{
    public class CharUtil
    {
        private static char[] DEF_CHAR = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

        public static bool isValidate(string t)
        {
            return t != null ? t.Trim().Length > 0 : false;
        }

        public static bool isValidate(string t, int size)
        {
            return t != null ? t.Trim().Length == size : false;
        }

        public static bool isValidate(string t, int min, int max)
        {
            if (t == null)
            {
                return false;
            }
            int l = t.Trim().Length;
            return (l >= min && l <= max);
        }

        public static bool isValidateCode(string text)
        {
            if (text == null)
            {
                return false;
            }
            return Regex.IsMatch(text, "^[0-9A-Z]{8}$");
        }

        public static bool isValidateHash(string text)
        {
            if (text == null)
            {
                return false;
            }
            //return Regex.IsMatch(text, "^[0-1A-Za-z]{16}$");
            return Regex.IsMatch(text, "^\\w{16}$");
        }

        public static bool isValidateDate(string text, bool formatOnly)
        {
            if (text == null)
            {
                return false;
            }
            if (formatOnly)
            {
                return Regex.IsMatch(text, "(^[1-9][0-9]{0,3}[-\\/\\._](0[1-9]|1[012])[-\\/\\._](0[1-9]|[12][0-9]|3[01])$)");
            }
            return Regex.IsMatch(text, "((^((1[8-9]\\d{2})|([2-9]\\d{3}))([-\\/\\._])(10|12|0?[13578])([-\\/\\._])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\\d{2})|([2-9]\\d{3}))([-\\/\\._])(11|0?[469])([-\\/\\._])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\\d{2})|([2-9]\\d{3}))([-\\/\\._])(0?2)([-\\/\\._])(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\\/\\._])(0?2)([-\\/\\._])(29)$)|(^([3579][26]00)([-\\/\\._])(0?2)([-\\/\\._])(29)$)|(^([1][89][0][48])([-\\/\\._])(0?2)([-\\/\\._])(29)$)|(^([2-9][0-9][0][48])([-\\/\\._])(0?2)([-\\/\\._])(29)$)|(^([1][89][2468][048])([-\\/\\._])(0?2)([-\\/\\._])(29)$)|(^([2-9][0-9][2468][048])([-\\/\\._])(0?2)([-\\/\\._])(29)$)|(^([1][89][13579][26])([-\\/\\._])(0?2)([-\\/\\._])(29)$)|(^([2-9][0-9][13579][26])([-\\/\\._])(0?2)([-\\/\\._])(29)$))");
        }

        public static bool isValidateTime(string text)
        {
            if (text == null)
            {
                return false;
            }
            return Regex.IsMatch(text, "(^([01][0-9]|2[0-3])[:\\.]([0-5][0-9])[:\\.]([0-5][0-9])$)");
        }

        public static bool isValidateDateTime(string text)
        {
            if (text == null)
            {
                return false;
            }
            return Regex.IsMatch(text, "^[1-9][0-9]{0,3}[-\\/\\._](0[1-9]|1[012])[-\\/\\._](0[1-9]|[12][0-9]|3[01]) ([01][0-9]|2[0-3])[:\\.]([0-5][0-9])[:\\.]([0-5][0-9])$");
        }

        public static byte[] DecodeString(string s)
        {
            return DecodeString(s, DEF_CHAR);
        }

        /// <summary>
        /// 按指定变换规则进行字符串到字节数组的变换
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static byte[] DecodeString(string s, char[] c)
        {
            int i = 0, j = 0, k = s.Length;
            byte[] b = new byte[k >> 1];
            byte t;
            while (i < k)
            {
                t = 0;
                t |= charIndex(s[i++], c);

                t <<= 4;
                t |= charIndex(s[i++], c);

                b[j++] = t;
            }
            return b;
        }

        private static byte charIndex(char a, char[] c)
        {
            byte i = 0;
            foreach (char t in c)
            {
                if (a == t)
                {
                    break;
                }
                i += 1;
            }
            return i;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string EncodeString(byte[] b)
        {
            return EncodeString(b, DEF_CHAR);
        }

        /// <summary>
        ///指定转换参考码内的可显示字符串数据
        /// </summary>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string EncodeString(byte[] b, char[] c)
        {
            // 转换参考码及字节数组合法性判断
            if (b == null || b.Length < 1 || c == null || c.Length < 16)
            {
                return "";
            }

            // 缓冲字符串大小判断及创建
            StringBuilder buf = new StringBuilder(b.Length << 1);

            // 字节数据转换为可显示字符串数据
            foreach (byte t in b)
            {
                buf.Append(c[t >> 4]);
                buf.Append(c[t & 0xF]);
            }

            return buf.ToString();
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

        /// <summary>
        /// 随机用户掩码
        /// </summary>
        /// <returns></returns>
        private char[] GenerateDataChar()
        {
            char[] c = new char[93];
            char t = '!';
            int i = 0;
            while (i < 6)
            {
                c[i++] = t++;
            }
            t = '(';
            while (i < 93)
            {
                c[i++] = t++;
            }

            return NextRandomKey(c, 16, false);
        }

        /// <summary>
        /// 随机加密口令
        /// </summary>
        /// <returns></returns>
        private byte[] GenerateDataKeys()
        {
            byte[] b = new byte[16];
            new Random().NextBytes(b);
            return b;
        }

        /// <summary>
        /// 随机用户口令
        /// </summary>
        /// <returns></returns>
        public static char[] GenerateUserChar()
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
    }
}

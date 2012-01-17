using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Me.Amon.Util
{/// <summary>
    /// StringUtil 的摘要说明
    /// </summary>
    public class CharUtil
    {
        /// <summary>
        /// 用户代码
        /// </summary>
        private static readonly Regex _UserCode = new Regex("^[0-9A-Za-z]{8}$");
        /// <summary>
        /// 数据主键
        /// </summary>
        private static readonly Regex _DataHash = new Regex("^[0-9A-Za-z]{16}$");
        /// <summary>
        /// 图标路径
        /// </summary>
        private static readonly Regex _PathHash = new Regex("^[A-Za-z]{4},([0-9]{4},[0-9A-Za-z]{16}|_[A-Z]{3})$");
        /// <summary>
        /// 整数数字
        /// </summary>
        private static readonly Regex _LongHash = new Regex("^\\d+$");

        private CharUtil()
        {
        }

        /// <summary>
        /// 判断是否为合法的用户代码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool IsValidateCode(string code)
        {
            return code != null ? _UserCode.IsMatch(code) : false;
        }

        /// <summary>
        /// 判断是否为合法的数据主键
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool IsValidateHash(string hash)
        {
            return hash != null ? _DataHash.IsMatch(hash) : false;
        }

        public static bool IsValidatePath(string hash)
        {
            return hash != null ? _PathHash.IsMatch(hash) : false;
        }

        /// <summary>
        /// 判断是否为合法的整形数值
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool IsValidateLong(string hash)
        {
            return hash != null ? _LongHash.IsMatch(hash) : false;
        }

        public static String EncodeLong(long l, bool bigCase)
        {
            // 不同进制使用的数值表示字符
            char[] digits = bigCase ? new char[] { 'Q', 'A', 'Z', 'W', 'S', 'X', 'E', 'D', 'C', 'R', 'F', 'V', 'T', 'G', 'B', 'Y' } : new char[] { 'q', 'a', 'z', 'w', 's', 'x', 'e', 'd', 'c', 'r', 'f', 'v', 't', 'g', 'b', 'y' };

            // 缓冲字符数组
            char[] buf = new char[16];
            int charPos = 16;
            do
            {
                buf[--charPos] = digits[(int)(l & 0xF)];
                l >>= 4;
            }
            while (charPos > 0);

            // 返回符合用户要求格式的数组字符串
            return new String(buf);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="bigCase"></param>
        /// <returns></returns>
        public static String EncodeBytes(byte[] b, bool bigCase)
        {
            // 不同进制使用的数值表示字符
            char[] digits = bigCase ? new char[] { 'Q', 'A', 'Z', 'W', 'S', 'X', 'E', 'D', 'C', 'R', 'F', 'V', 'T', 'G', 'B', 'Y' } : new char[] { 'q', 'a', 'z', 'w', 's', 'x', 'e', 'd', 'c', 'r', 'f', 'v', 't', 'g', 'b', 'y' };

            StringBuilder sb = new StringBuilder(32);
            foreach (char t in b)
            {
                sb.Append(digits[t & 0xF]).Append(digits[(t >> 4) & 0xF]);
            }
            return sb.ToString();
        }


        /// <summary>
        /// 判断一个字符串是否为有效字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidate(String value)
        {
            return (value != null && value.Trim().Length > 0);
        }

        /// <summary>
        /// 判断一个字符串是否为有效字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fix"></param>
        /// <returns></returns>
        public static bool IsValidate(String value, int fix)
        {
            return (value != null && value.Trim().Length == fix);
        }

        /// <summary>
        /// 判断一个字符串是否为有效字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsValidate(String value, int min, int max)
        {
            if (value != null)
            {
                value = value.Trim();
                return value.Length >= min && value.Length <= max;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static byte[] getBytes(String text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            int len = text.Length;
            char[] chr = text.ToCharArray();
            byte[] rst = new byte[len << 1];
            char tmp;
            for (int i = 0, j = i; i < len; i += 1, j = i << 1)
            {
                tmp = chr[i];
                rst[j + 0] = (byte)(tmp & 0xFF);
                rst[j + 1] = (byte)((tmp >> 8) & 0xFF);
            }
            return rst;
        }

        public static String lpad(String text, int length, String padStr)
        {
            int s = text.Length;
            int e = padStr.Length;
            while (s < length)
            {
                text = padStr + text;
                s += e;
            }
            if (s > length)
            {
                text = text.Substring(s - length);
            }
            return text;
        }

        public static String trim(String text, int size)
        {
            if (text == null)
            {
                return "";
            }

            if (text.Length <= size)
            {
                return text;
            }

            int i = 0;
            int j = 0;
            bool b = false;
            size <<= 1;
            foreach (char t in text)
            {
                b = t > 127;
                j += b ? 2 : 1;
                if (j > size)
                {
                    break;
                }
                i += 1;
            }
            return text.Length > i ? text.Substring(0, i - (b ? 1 : 2)) + '…' : text;
        }

        /// <summary>
        /// 将字符串按宽字符方式转换为定长显示的字符串，两个英文字符作为一个汉字
        /// </summary>
        /// <param name="src"></param>
        /// <param name="len">中文字符个数</param>
        /// <returns></returns>
        public static string FixWidth(String src, int len)
        {
            if (src.Length > len)
            {
                len <<= 1;
                StringBuilder tmp = new StringBuilder();
                int cur = 0;
                foreach (char c in src)
                {
                    cur += c < 128 ? 1 : 2;
                    if (cur > len)
                    {
                        break;
                    }
                    tmp.Append(c);
                }
                src = tmp.ToString();
            }
            return src;
        }

        /// <summary>
        /// 全角转半角
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string CharConverter(string source)
        {
            StringBuilder result = new StringBuilder(source.Length);
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] >= 65281 && source[i] <= 65373)
                {
                    result.Append((char)(source[i] - 65248));
                }
                else if (source[i] == 12288)
                {
                    result.Append(' ');
                }
                else
                {
                    result.Append(source[i]);
                }
            }
            return result.ToString();
        }


        private static char[] DEF_CHAR = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

        public static bool IsValidateDate(string text, bool formatOnly)
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

        public static bool IsValidateTime(string text)
        {
            if (text == null)
            {
                return false;
            }
            return Regex.IsMatch(text, "(^([01][0-9]|2[0-3])[:\\.]([0-5][0-9])[:\\.]([0-5][0-9])$)");
        }

        public static bool IsValidateDateTime(string text)
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

        public static string GenPass(string data, int length)
        {
            StringBuilder buf = new StringBuilder(data);
            for (int i = buf.Length, j = length; i < j; i += 1)
            {
                buf.Append(' ');
            }
            return buf.ToString();
        }

        public static string Text2DB(string text)
        {
            return text != null ? text.Replace("'", "''") : "";
        }

        public static string Db2Text(string text)
        {
            return "";
        }
    }
}

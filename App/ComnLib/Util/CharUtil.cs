using System.Text;
using System.Text.RegularExpressions;

namespace Me.Amon.Util
{
    /// <summary>
    /// CharUtil 的摘要说明
    /// </summary>
    public class CharUtil
    {
        private static char[] DEF_CHAR = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
        private static char[] UPPER_CHAR = { 'Q', 'A', 'Z', 'W', 'S', 'X', 'E', 'D', 'C', 'R', 'F', 'V', 'T', 'G', 'B', 'Y' };
        private static char[] LOWER_CHAR = { 'q', 'a', 'z', 'w', 's', 'x', 'e', 'd', 'c', 'r', 'f', 'v', 't', 'g', 'b', 'y' };

        private CharUtil()
        {
        }

        #region 字符判断
        /// <summary>
        /// 判断一个字符串是否为有效字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidate(string value)
        {
            return (value != null && value.Trim().Length > 0);
        }

        /// <summary>
        /// 判断一个字符串是否为有效字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fix"></param>
        /// <returns></returns>
        public static bool IsValidate(string value, int fix)
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
        public static bool IsValidate(string value, int min, int max)
        {
            if (value != null)
            {
                value = value.Trim();
                return value.Length >= min && value.Length <= max;
            }
            return false;
        }

        public static bool IsValidateCall(string call)
        {
            return call != null ? Regex.IsMatch(call, "^([+]?\\d{2,3}[^\\d]+)?0?((\\d{11})|(\\d{2,3}[^\\d]+)?\\d{7,8}([^\\d]+\\d{1,})?)$") : false;
        }

        /// <summary>
        /// 判断是否为合法的用户代码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool IsValidateCode(string code)
        {
            return code != null ? Regex.IsMatch(code, "^[0-9A-Za-z]{8}$") : false;
        }

        /// <summary>
        /// 判断是否为合法的数据主键
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool IsValidateHash(string hash)
        {
            return hash != null ? Regex.IsMatch(hash, "^[0-9A-Za-z]{16}$") : false;
        }

        /// <summary>
        /// 判断是否为合法的整形数值
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsValidateLong(string text)
        {
            return text != null ? Regex.IsMatch(text, "^[-+]?\\d+$") : false;
        }

        public static bool IsValidateMail(string text)
        {
            if (text == null)
            {
                return false;
            }
            return Regex.IsMatch(text, "^[-.\\w]+@[-\\w]+([.][-\\w]+)+$");
        }

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

        /// <summary>
        /// 判断是否为合法的用户名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsValidateName(string name)
        {
            return name != null ? Regex.IsMatch(name, "^\\w+[\\w\\d\\.]{3,31}$") : false;
        }

        public static bool IsValidateURL(string name)
        {
            return name != null ? Regex.IsMatch(name, "^[a-zA-z]{2,}:/{2,3}[^\\s]+") : false;
        }

        /// <summary>
        /// 图标路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsValidatePath(string path)
        {
            return path != null ? Regex.IsMatch(path, "^[A-Za-z]{4},([0-9]{4},[0-9A-Za-z]{16}|_[A-Z]{3})$") : false;
        }

        public static bool IsValidateNegative(string text)
        {
            return true;
        }

        public static bool IsValidatePositive(string text)
        {
            return true;
        }

        public static bool IsValidateDecimal(string text)
        {
            return true;
        }
        #endregion

        #region 字符转换
        /// <summary>
        /// 
        /// </summary>
        /// <param name="l"></param>
        /// <param name="bigCase"></param>
        /// <returns></returns>
        public static string EncodeLong(long l, bool bigCase)
        {
            // 不同进制使用的数值表示字符
            char[] digits = bigCase ? UPPER_CHAR : LOWER_CHAR;

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
            return new string(buf);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="bigCase"></param>
        /// <returns></returns>
        public static string EncodeBytes(byte[] b, bool bigCase)
        {
            // 不同进制使用的数值表示字符
            char[] digits = bigCase ? UPPER_CHAR : LOWER_CHAR;

            StringBuilder sb = new StringBuilder(32);
            foreach (char t in b)
            {
                sb.Append(digits[t & 0xF]).Append(digits[(t >> 4) & 0xF]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static byte[] getBytes(string text)
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

        public static string Lpad(string text, int length, string padStr)
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

        public static string Trim(string text, int size)
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

        /// <summary>
        /// 解密转换
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte[] DecodeString(string s)
        {
            return DecodeString(s, DEF_CHAR);
        }

        /// <summary>
        /// 解密转换
        /// </summary>
        /// <param name="s">明文字符</param>
        /// <param name="c">掩码数组</param>
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
        /// 加密转换
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string EncodeString(byte[] b)
        {
            return EncodeString(b, DEF_CHAR);
        }

        /// <summary>
        /// 加密转换
        /// </summary>
        /// <param name="b">字节数组</param>
        /// <param name="c">掩码数组</param>
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
        #endregion
    }
}

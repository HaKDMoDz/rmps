using System;
using System.Text;
using System.Text.RegularExpressions;

namespace rmp.util
{
    /// <summary>
    /// StringUtil 的摘要说明
    /// </summary>
    public class StringUtil
    {
        /// <summary>
        /// 用户代码
        /// </summary>
        private static readonly Regex userCode = new Regex("^[0-9A-Za-z]{8}$");
        /// <summary>
        /// 数据主键
        /// </summary>
        private static readonly Regex dataHash = new Regex("^[0-9A-Za-z]{16}$");
        /// <summary>
        /// 图标路径
        /// </summary>
        private static readonly Regex pathHash = new Regex("^[A-Za-z]{4},([0-9]{4},[0-9A-Za-z]{16}|_[A-Z]{3})$");
        /// <summary>
        /// 整数数字
        /// </summary>
        private static readonly Regex longHash = new Regex("^\\d+$");

        private StringUtil()
        {
        }

        /// <summary>
        /// 判断是否为合法的用户代码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool isValidateCode(string code)
        {
            return code != null ? userCode.IsMatch(code) : false;
        }

        /// <summary>
        /// 判断是否为合法的数据主键
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool isValidateHash(string hash)
        {
            return hash != null ? dataHash.IsMatch(hash) : false;
        }

        public static bool isValidatePath(string hash)
        {
            return hash != null ? pathHash.IsMatch(hash) : false;
        }

        /// <summary>
        /// 判断是否为合法的整形数值
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool isValidateLong(string hash)
        {
            return hash != null ? longHash.IsMatch(hash) : false;
        }

        public static String encodeLong(long l, bool bigCase)
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
        public static bool isValidate(String value)
        {
            return (value != null && value.Trim().Length > 0);
        }

        /// <summary>
        /// 判断一个字符串是否为有效字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fix"></param>
        /// <returns></returns>
        public static bool isValidate(String value, int fix)
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
        public static bool isValidate(String value, int min, int max)
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
    }
}
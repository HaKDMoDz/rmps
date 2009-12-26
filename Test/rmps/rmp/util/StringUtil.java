/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.util;

import java.util.StringTokenizer;

import com.amonsoft.util.CharUtil;

import cons.SysCons;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 字符串处理类
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public final class StringUtil
{
    /**
     * 
     */
    private StringUtil()
    {
    }

    /**
     * 按正常十六进制将字节数组转换为可以显示的字符串数据
     * 
     * @param v
     *            等进行转换的字节数组
     * @param bigCase
     *            返回结果字符串是否使用大写字符，true大写，false小写
     * @return
     */
    public static String bytesToString(byte[] v, boolean bigCase)
    {
        return bytesToString(bigCase ? SysCons.UPPER_NUMBER : SysCons.LOWER_NUMBER, v);
    }

    /**
     * 指定转换参考码内的可显示字符串数据
     * 
     * @param c
     *            字节转换参考码，其长度不能小于16
     * @param v
     *            待转换的字节数组
     * @return
     */
    public static String bytesToString(char[] c, byte[] v)
    {
        // 转换参考码及字节数组合法性判断
        if (c == null || c.length < 16 || v == null || v.length < 1)
        {
            return "";
        }

        // 缓冲字符串大小判断及创建
        int len = v.length;
        StringBuffer strBuf = new StringBuffer(len << 1);

        // 字节数据转换为可显示字符串数据
        byte tmp;
        for (int i = 0; i < len; ++i)
        {
            tmp = v[i];
            strBuf.append(c[(tmp >>> 4) & 0xF]);
            strBuf.append(c[tmp & 0xF]);
        }

        return strBuf.toString();
    }

    /**
     * 将指定的十进制整型数据转换为指定进制的数据格式
     * 
     * @param i
     *            有待进行进制转换的十进制整型数值
     * @param shift
     *            目标进制间位进制所占Bit位数，如16进制占4Bit等
     * @param bigCase
     *            是否转换后的字符串格式使用大写格式（在需要的情况下），true大写，false小写
     * @param append
     *            是否需要左端补0显示，true左端补0显示，false，左端不补0显示
     * @return 格式化转换后的字符串数据
     */
    public static String intToString(int i, int shift, boolean bigCase, boolean append)
    {
        // 进制的合法性检查，不可能出现小于2进制及不可能出现大于32进制的数值
        if (shift < 1 || shift > 5)
        {
            return null;
        }

        // 不同进制使用的数值表示字符
        char[] digits = bigCase ? SysCons.UPPER_NUMBER : SysCons.LOWER_NUMBER;

        // 缓冲字符数组
        char[] buf = new char[32];
        int charPos = 32;
        int mask = (1 << shift) - 1;
        do
        {
            buf[--charPos] = digits[i & mask];
            i >>>= shift;
        }
        while (i != 0);

        // 若左端补0显示，则修改显示位置为字符数组起始位置
        if (append)
        {
            int start = 32 - 32 / shift;
            if (32 % shift > 0)
            {
                start -= 1;
            }
            while (charPos > start)
            {
                buf[--charPos] = '0';
            }
        }

        // 返回符合用户要求格式的数组字符串
        return new String(buf, charPos, (32 - charPos));
    }

    /**
     * @param b
     * @param bigCase
     * @return
     */
    public static String byteToString(byte b, boolean bigCase)
    {
        // 不同进制使用的数值表示字符
        char[] digits = bigCase ? SysCons.UPPER_DIGEST : SysCons.LOWER_DIGEST;

        char[] buf = new char[2];
        buf[1] = digits[b & 0xF];
        b >>>= 4;
        buf[0] = digits[b & 0xF];

        return new String(buf);
    }

    /**
     * @param b
     * @param bigCase
     * @return
     */
    public static String EncodeBytes(byte[] b, boolean bigCase)
    {
        // 不同进制使用的数值表示字符
        char[] digits = bigCase ? SysCons.UPPER_DIGEST : SysCons.LOWER_DIGEST;

        StringBuffer sb = new StringBuffer(32);
        byte t;
        for (int i = 0, j = b.length; i < j; i += 1)
        {
            t = b[i];
            sb.append(digits[t & 0xF]);
            t >>>= 4;
            sb.append(digits[t & 0xF]);
        }
        return sb.toString();
    }

    /**
     * @param i
     * @param bigCase
     * @return
     */
    public static String intToString(int i, boolean bigCase)
    {
        // 不同进制使用的数值表示字符
        char[] digits = bigCase ? SysCons.UPPER_NUMBER : SysCons.LOWER_NUMBER;

        // 缓冲字符数组
        char[] buf = new char[8];
        int charPos = 8;
        int v = (int) i;
        do
        {
            buf[--charPos] = digits[v & 0xF];
            v >>= 4;
        }
        while (charPos > 0);

        // 返回符合用户要求格式的数组字符串
        return new String(buf);
    }

    /**
     * 生成指定的图像文件名称
     * 
     * @param i
     *            待转换的整形数值
     * @param bigCase
     *            是否使用大写字符：true:大写；false:小写
     * @return
     */
    public static String encodeInt(int i, boolean bigCase)
    {
        // 不同进制使用的数值表示字符
        char[] digits = bigCase ? SysCons.UPPER_DIGEST : SysCons.LOWER_DIGEST;

        // 缓冲字符数组
        char[] buf = new char[8];
        int charPos = 8;
        int v = (int) i;
        do
        {
            buf[--charPos] = digits[v & 0xF];
            v >>= 4;
        }
        while (charPos > 0);

        // 返回符合用户要求格式的数组字符串
        return new String(buf);
    }

    /**
     * @param l
     * @param bigCase
     * @return
     */
    public static String longToString(long l, boolean bigCase)
    {
        // 不同进制使用的数值表示字符
        char[] digits = bigCase ? SysCons.UPPER_NUMBER : SysCons.LOWER_NUMBER;

        // 缓冲字符数组
        char[] buf = new char[16];
        int charPos = 16;
        do
        {
            buf[--charPos] = digits[(int) (l & 0xF)];
            l >>>= 4;
        }
        while (charPos > 0);

        // 返回符合用户要求格式的数组字符串
        return new String(buf);
    }

    /**
     * 此方法目前主要用于时间的格式转化，用于生成指定格式的时间，数据表格主键。
     * 
     * @param l
     *            待转换的整形数值
     * @param bigCase
     *            是否使用大写字符：true:大写；false:小写
     * @return
     */
    public static String encodeLong(long l, boolean bigCase)
    {
        // 不同进制使用的数值表示字符
        char[] digits = bigCase ? SysCons.UPPER_DIGEST : SysCons.LOWER_DIGEST;

        // 缓冲字符数组
        char[] buf = new char[16];
        int charPos = 16;
        do
        {
            buf[--charPos] = digits[(int) (l & 0xF)];
            l >>>= 4;
        }
        while (charPos > 0);

        // 返回符合用户要求格式的数组字符串
        return new String(buf);
    }

    /**
     * 按常规规则进行字符串到字节数组的变换
     * 
     * @param s
     * @return
     */
    public static byte[] stringToBytes(String s, boolean bigCase)
    {
        return stringToBytes(s, bigCase ? SysCons.UPPER_NUMBER : SysCons.LOWER_NUMBER);
    }

    /**
     * 按指定变换规则进行字符串到字节数组的变换
     * 
     * @param s
     * @param c
     * @return
     */
    public static byte[] stringToBytes(String s, char[] c)
    {
        char[] t = s.toCharArray();
        int i = 0, j = 0, k = t.length;
        byte[] b = new byte[k >>> 1];
        byte p;
        while (i < k)
        {
            p = 0;
            p |= charIndex(t[i++], c) << 4;
            p |= charIndex(t[i++], c);
            b[j++] = p;
        }
        return b;
    }

    private static int charIndex(char a, char[] c)
    {
        int i = 0;
        for (char t : c)
        {
            if (a == t)
            {
                break;
            }
            i += 1;
        }
        return i;
    }

    /**
     * 格式化带有参数的字符串为适当的形式
     * 
     * @param srcStr
     *            源字符串
     * @param srcHash
     *            源字符串是否为索引值
     * @param argHash
     *            参数列表是否为索引值
     * @param args
     *            字符串参数列表
     * @return
     */
    public static final String format(String srcStr, String... args)
    {
        if (!CheckUtil.isValidate(srcStr))
        {
            return "";
        }

        int i = 0;
        for (String c : args)
        {
            srcStr = srcStr.replace("{" + (i++) + "}", c);
        }
        return srcStr;
    }

    /**
     * @param srcStr
     * @param args
     * @return
     */
    public static final String format(String srcStr, long... args)
    {
        if (!CheckUtil.isValidate(srcStr))
        {
            return "";
        }

        int i = 0;
        for (long c : args)
        {
            srcStr = srcStr.replace("{" + (i++) + "}", Long.toString(c));
        }
        return srcStr;
    }

    /**
     * 字符串转换为字节数组，此方法根据字符的Unicode码转换成相应的字符，对应字符的低字节前置， 如字符‘A’转换后的结果为[65][0]
     * 
     * @param text
     *            待进行字节转换的字符串
     * @return 转换后的结果
     */
    public static byte[] getBytes(String text)
    {
        if (text == null && text.length() < 1)
        {
            return null;
        }

        int len = text.length();
        char[] chr = text.toCharArray();
        byte[] rst = new byte[len << 1];
        char tmp;
        for (int i = 0, j = i; i < len; i += 1, j = i << 1)
        {
            tmp = chr[i];
            rst[j + 0] = (byte) (tmp & 0xFF);
            rst[j + 1] = (byte) ((tmp >>> 8) & 0xFF);
        }
        return rst;
    }

    /**
     * 数据更新或者新增时，用户输入字符串中存在数据库关键字符（如单引号 ' ），
     * 这种情况下会造成数据库更新或者新增异常，此方法主要用于用户输入字符到数据库合法字符的转换。
     * 
     * @param text
     *            待转换的用户输入字符
     * @return 数据库允许的字符
     */
    public static String toDBText(String text)
    {
        if (text == null)
        {
            return text;
        }

        return text.replace("'", "''");
    }

    /**
     * @param orgText
     *            源字符串
     * @param srcText
     *            待替换字符串
     * @param dstText
     *            目标字符串
     * @return
     */
    public static String replace(String orgText, String srcText, String dstText)
    {
        return replace(new StringBuffer(orgText), srcText, dstText).toString();
    }

    /**
     * @param orgBuf
     *            源字符串
     * @param srcText
     *            待替换字符串
     * @param dstText
     *            目标字符串
     * @return
     */
    public static StringBuffer replace(StringBuffer orgBuf, String srcText, String dstText)
    {
        // 数据合法性判断
        if (orgBuf == null || srcText == null || dstText == null)
        {
            return orgBuf;
        }

        // 待替换字符串长度
        int sLen = srcText.length();
        // 源字符串中第一个等替换字符起始位置
        int sIdx = orgBuf.indexOf(srcText);

        // 循环替换每一个待替换字符串
        while (sIdx >= 0)
        {
            // 待替换字符串替换成目标字符串
            orgBuf = orgBuf.replace(sIdx, sIdx + sLen, dstText);
            // 定位下一个待替换字符串的位置
            sIdx = orgBuf.indexOf(srcText, sIdx + sLen);
        }

        // 返回替换后的字符串数据
        return orgBuf;
    }

    /**
     * 把字符串orgText中所有处于sText与eText之间的字符数据（包含标记字符串）替换为目标字符串dstText
     * 
     * @param orgText
     *            源字符串
     * @param sText
     *            起始标记字符串
     * @param eText
     *            结束标记字符串
     * @param dstText
     *            目标字符串
     * @return 替换后的字符串
     */
    public static String replace(String orgText, String sText, String eText, String dstText)
    {
        return replace(new StringBuffer(orgText), sText, eText, dstText).toString();
    }

    /**
     * @param orgBuf
     * @param sText
     * @param eText
     * @param dstText
     * @return
     */
    public static StringBuffer replace(StringBuffer orgBuf, String sText, String eText, String dstText)
    {
        if (orgBuf == null || sText == null || eText == null || dstText == null)
        {
            return orgBuf;
        }

        int sIndx = orgBuf.indexOf(sText);
        int eIndx = orgBuf.indexOf(eText, sIndx);
        while (sIndx >= 0)
        {
            orgBuf = orgBuf.replace(sIndx, eIndx, dstText);

            sIndx = orgBuf.indexOf(sText);
            eIndx = orgBuf.indexOf(eText, sIndx);
        }

        return null;
    }

    /**
     * 给定字符串是否为一个数值字符串
     * 
     * @param str
     * @return
     */
    public static boolean isNumber(String str)
    {
        if ((str == null) || (str.length() == 0))
        {
            return false;
        }

        char[] chars = str.toCharArray();
        int sz = chars.length;
        boolean hasExp = false;
        boolean hasDecPoint = false;
        boolean allowSigns = false;
        boolean foundDigit = false;
        // deal with any possible sign up front
        int start = (chars[0] == '-') ? 1 : 0;
        if (sz > start + 1)
        {
            if (chars[start] == '0' && chars[start + 1] == 'x')
            {
                int i = start + 2;
                if (i == sz)
                {
                    return false; // str == "0x"
                }
                // checking hex (it can't be anything else)
                for (; i < chars.length; i++)
                {
                    if ((chars[i] < '0' || chars[i] > '9') && (chars[i] < 'a' || chars[i] > 'f') && (chars[i] < 'A' || chars[i] > 'F'))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        sz--; // don't want to loop to the last char, check it afterwords
        // for type qualifiers
        int i = start;
        // loop to the next to last char or to the last char if we need another
        // digit to
        // make a valid number (e.g. chars[0..5] = "1234E")
        while (i < sz || (i < sz + 1 && allowSigns && !foundDigit))
        {
            if (chars[i] >= '0' && chars[i] <= '9')
            {
                foundDigit = true;
                allowSigns = false;

            }
            else if (chars[i] == '.')
            {
                if (hasDecPoint || hasExp)
                {
                    // two decimal points or dec in exponent
                    return false;
                }
                hasDecPoint = true;
            }
            else if (chars[i] == 'e' || chars[i] == 'E')
            {
                // we've already taken care of hex.
                if (hasExp)
                {
                    // two E's
                    return false;
                }
                if (!foundDigit)
                {
                    return false;
                }
                hasExp = true;
                allowSigns = true;
            }
            else if (chars[i] == '+' || chars[i] == '-')
            {
                if (!allowSigns)
                {
                    return false;
                }
                allowSigns = false;
                foundDigit = false; // we need a digit after the E
            }
            else
            {
                return false;
            }
            i++;
        }
        if (i < chars.length)
        {
            if (chars[i] >= '0' && chars[i] <= '9')
            {
                // no type qualifier, OK
                return true;
            }
            if (chars[i] == 'e' || chars[i] == 'E')
            {
                // can't have an E at the last byte
                return false;
            }
            if (!allowSigns && (chars[i] == 'd' || chars[i] == 'D' || chars[i] == 'f' || chars[i] == 'F'))
            {
                return foundDigit;
            }
            if (chars[i] == 'l' || chars[i] == 'L')
            {
                // not allowing L with an exponoent
                return foundDigit && !hasExp;
            }
            // last character is illegal
            return false;
        }
        // allowSigns is true iff the val ends in 'E'
        // found digit it to make sure weird stuff like '.' and '1E-' doesn't
        // pass
        return !allowSigns && foundDigit;
    }

    /**
     * 给定字符串是否为整数
     * 
     * @param str
     * @return
     */
    public static boolean isInteger(String str)
    {
        char[] ch = str.toCharArray();
        char t = ch[0];

        int s = 0;
        if ('-' == t)
        {
            s = 1;
        }

        for (int l = ch.length; s < l; s += 1)
        {
            t = ch[s];
            if (t < '0' || t > '9')
            {
                return false;
            }
        }
        return true;
    }

    /**
     * 给定字符串是否为英文字母
     * 
     * @param str
     * @return
     */
    public static boolean isLetter(String str)
    {
        char[] ch = str.toCharArray();
        char t = ch[0];

        int s = 0;
        if ('-' == t)
        {
            s = 1;
        }

        for (int l = ch.length; s < l; s += 1)
        {
            t = ch[s];
            if (t < 'A' || (t > 'Z' && t < 'a') || t > 'z')
            {
                return false;
            }
        }
        return true;
    }

    /**
     * Unicode转换到Unicode转换码
     * 
     * @param uniStr
     *            Unicode正常字符串
     * @return
     */
    public static String unicode2UnicodeEsc(String uniStr)
    {
        // 非空判断
        if (uniStr == null)
        {
            return null;
        }

        char[] chrStr = uniStr.toCharArray();
        StringBuilder sb = new StringBuilder();

        for (char tmp : chrStr)
        {
            if (tmp == '\\')
            {
                sb.append("\\\\");
                continue;
            }

            // 窄字符直接显示
            if (tmp <= 127)
            {
                sb.append(tmp);
                continue;
            }

            // 宽字符到转换码转换
            sb.append("\\u").append(CharUtil.lPad(Integer.toHexString(tmp), 4, '0'));
        }

        return sb.toString();
    }

    /**
     * Unicode转换码到Unicode字符
     * 
     * @param escStr
     *            Unicode转换码字符串
     * @return
     * @throws Exception
     */
    public static String unicodeEsc2Unicode(String escStr) throws Exception
    {
        // 非空判断
        if (escStr == null)
        {
            return null;
        }

        boolean isPs = false;
        char ch1;
        int i = 0;
        char[] chrStr = escStr.toCharArray();
        StringBuilder sb = new StringBuilder();
        StringBuilder tmp = new StringBuilder();

        while (i < chrStr.length)
        {
            ch1 = chrStr[i++];

            // 转换标记
            if (ch1 == '\\')
            {
                if (isPs)
                {
                    sb.append(ch1);
                    isPs = false;
                }
                else
                {
                    isPs = true;
                }
                continue;
            }

            // 非转换码标记 \\ u
            if (ch1 == 'u' || ch1 == 'U')
            {
                if (isPs)
                {
                    // 四字符Unicode转换码
                    tmp.append(chrStr[i++]);
                    tmp.append(chrStr[i++]);
                    tmp.append(chrStr[i++]);
                    tmp.append(chrStr[i++]);
                    sb.append((char) Integer.parseInt(tmp.toString(), 16));
                    tmp.delete(0, tmp.length());
                    isPs = false;
                }
                else
                {
                    sb.append(ch1);
                }
                continue;
            }

            if (isPs)
            {
                throw new Exception("文档解析出错，未知转义字符：\\");
            }

            // 窄字符直接显示
            sb.append(ch1);
        }

        if (isPs)
        {
            throw new Exception("文档解析出错，未知转义字符：\\");
        }

        return sb.toString();
    }

    /**
     * @param ver
     * @param delim
     * @param width
     * @return
     */
    public static String regVer(String ver, String delim, int width)
    {
        if (!CheckUtil.isValidate(ver))
        {
            ver = "1.0.0.0";
        }

        if (!CheckUtil.isValidate(delim))
        {
            delim = ".";
        }

        if (width < 1)
        {
            width = 1;
        }

        StringBuffer sb = new StringBuffer();
        StringTokenizer st = new StringTokenizer(ver, delim);
        while (st.hasMoreTokens())
        {
            sb.append(delim).append(CharUtil.lPad(st.nextToken(), width, '0'));
        }
        return sb.substring(delim.length());
    }
}

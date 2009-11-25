/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.util;

import java.security.MessageDigest;
import java.security.Provider;
import java.security.Security;
import java.util.Calendar;
import java.util.Random;
import java.util.TimeZone;

import javax.crypto.Cipher;
import javax.crypto.spec.IvParameterSpec;

import rmp.bean.CipherKey;
import com.amonsoft.rmps.IRmps;
import cons.SysCons;
import cryptix.jce.provider.CryptixCrypto;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * @author Amon
 */
public final class HashUtil
{
    /**
     * 
     */
    private HashUtil()
    {
    }

    /*
     * (non-Javadoc)
     * 
     * @see rmp.face.IRmps#init()
     */
    public boolean wInit()
    {
        return true;
    }

    /**
     * 字符串信息摘要，并以掩码结果显示，默认使用MD5摘要算法对指定的字符串进行数据摘要
     * 
     * @param text 要进行数据摘要的原字符串
     * @param bigCase 返回结果字符串是否使用大写字符，true大写，false小写
     * @return 字符串信息摘要结果
     */
    public static String digest(String text, boolean bigCase)
    {
        return StringUtil.EncodeBytes(digest(text, "MD5"), bigCase);
    }

    /**
     * 信息摘要，按正常结果显示
     * 
     * @param text 等进行摘要的字符串
     * @param hash 信息摘要算法
     * @return 字符串信息摘要结果
     */
    public static byte[] digest(String text, String hash)
    {
        // 参数为不空检测
        if (CheckUtil.isValidate(text) && CheckUtil.isValidate(hash))
        {
            try
            {
                // 获取摘要对象实例
                MessageDigest md = MessageDigest.getInstance(hash);
                // 字符串到字节转换
                byte[] mesg = StringUtil.getBytes(text);
                // 数据摘要
                return md.digest(mesg);
            }
            catch (Exception exp)
            {
                LogUtil.exception(exp);
            }
        }

        return (new byte[0]);
    }

    /**
     * 此方法用要用于表格主键的生成。 C# 计算开始时间：1601年1月1日12：00：00 Java计算开始时间：1970年1月1日00：00：00
     * 时间相关数值为： 116444736000000000
     * 
     * @param bigCase 返回字符串是否大写
     * @return
     */
    public static String getCurrTimeHex(boolean bigCase)
    {
        Calendar cal = Calendar.getInstance(TimeZone.getTimeZone("GMT-0:00"));
        return StringUtil.encodeLong(cal.getTimeInMillis(), bigCase);
    }

    /**
     * 根据指定的语言字符串，获取其唯一的标记信息ID
     * 
     * @param language 语言字符串，如:English,简体中文,日本語……等。
     * @return 语言为空时，返回结果为NULL其它情况下为一个非空字符串
     */
    public static String getLanguageID(String language)
    {
        // 若字符串为空，长度为0,则不进行Hash操作
        if (language == null || language.length() < 1)
        {
            return null;
        }

        int hash = 0;
        byte bk[] = StringUtil.getBytes(language);
        for (int i = 0, len = bk.length; i < len; ++i)
        {
            hash *= 16777619;
            hash ^= bk[i];
        }
        return StringUtil.encodeInt(hash, false);
    }

    /**
     * PHP中出现的字符串Hash函数
     * 
     * @param arKey
     * @return
     */
    public static long hash1(char[] arKey)
    {
        long h = 0, g;

        for (int i = 0; i < arKey.length; i += 1)
        {
            h <<= 4;
            h += arKey[i];
            g = h & 0xF0000000;
            if (g != 0)
            {
                h = h ^ (g >> 24);
                h = h ^ g;
            }
        }
        return h;
    }

    /**
     * MySql中出现的字符串Hash函数
     * 
     * @param key
     * @return
     */
    public static long hash4(char[] key)
    {
        long nr = 1, nr2 = 4;
        for (int i = key.length - 1; i >= 0; i -= 1)
        {
            nr ^= (((nr & 63) + nr2) * (key[i])) + (nr << 8);
            nr2 += 3;
        }
        return nr;
    }

    /**
     * MySql中出现的字符串Hash函数
     * 
     * @param key
     * @return
     */
    public static long hash5(char[] key)
    {
        long hash = 0;
        for (int i = 0; i < key.length; i += 1)
        {
            hash *= 16777619;
            hash ^= key[i];
        }
        return hash;
    }

    /**
     * 经验字符串Hash函数
     * 
     * @param str
     * @return
     */
    public static long hash6(char[] str)
    {
        long h = 0;

        for (int i = 0; i < str.length; i += 1)
        {
            h = 31 * h + str[i];
        }
        return h;
    }

    /**
     * 注册加密算法提供
     * 
     * @return
     */
    public static boolean addProvider()
    {
        // 
        Provider cryptix_provider = new CryptixCrypto();

        //
        int result = Security.addProvider(cryptix_provider);

        //
        return result != -1;
    }

    /**
     * 数据流加密
     * 
     * @param text 明文数据
     * @param key 用户口令
     * @return 密文数据
     */
    public static String encrypt(String text, byte[] key)
    {
        byte[] c = cipher(Cipher.ENCRYPT_MODE, "RC6", "CBC", "None", "CryptixCrypto", text, key);
        return StringUtil.bytesToString(c, true);
    }

    /**
     * 数据流解密
     * 
     * @param text 密文数据
     * @param key 用户口令
     * @return 明文数据
     */
    public static String decrypt(String text, byte[] key)
    {
        byte[] c = cipher(Cipher.DECRYPT_MODE, "RC6", "CBC", "None", "CryptixCrypto", text, key);
        return StringUtil.bytesToString(c, true);
    }

    /**
     * 数据流加解密
     * 
     * @param cipherMode 加密模式，其值为：Cipher.ENCRYPT_MODE或者Cipher.DECRYPT_MODE
     * @param algorithm 加密算法名称
     * @param mode 加密模式，如CBC、EBC等
     * @param padding 扩充模式
     * @param provider 加密算法提供者
     * @param text 等加密文本
     * @param key 加密口令
     */
    public static byte[] cipher(int cipherMode, String algorithm, String mode, String padding, String provider,
            String text, byte[] key)
    {
        try
        {
            // 算法合成
            String c = algorithm;
            if (mode.length() > 0)
            {
                c += "/" + mode;
            }
            if (padding.length() > 0)
            {
                c += "/" + padding;
            }

            // 加密算法实例化
            Cipher cipher = Cipher.getInstance(c, provider);

            // 加密密钥
            CipherKey cKey = new CipherKey(key);
            // cKey.setCdSize(Cipher.getMaxAllowedKeyLength(c));
            // cKey.setIvSize(cipher.getBlockSize());
            IvParameterSpec spec = new IvParameterSpec(key);

            // 算法初始化
            cipher.init(cipherMode, cKey, spec);

            // 数据加密
            return cipher.doFinal(StringUtil.getBytes(text));
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }

        return (new byte[0]);
    }

    /**
     * 根据当前输入ID生成符合条件的下一个用户ID
     * 
     * @param lastID 用于生成特定ID的上一个ID。
     * @param idType ID类别：1表示内部员工ID；2表示商业伙伴ID；其它表示系统用户ID
     * @return
     */
    public static String nextUserID(String lastID, int idType)
    {
        String id = null;

        switch (idType)
        {
            // 内部员工
            case 1:
            {
                // 默认标记
                if (!CheckUtil.isValidate(lastID))
                {
                    id = "a0000000";
                }
            }
            break;
            // 商业伙伴
            case 2:
            {
            }
            break;
            // 默认类型
            default:
            {
                // 默认标记
                if (!CheckUtil.isValidate(lastID))
                {
                    id = "10000000";
                    break;
                }

                char[] t = SysCons.LOWER_NUMBER;
                char[] s = lastID.toCharArray();
                char c;
                boolean b;
                for (int i = s.length - 1; i >= 0; i -= 1)
                {
                    c = s[i];
                    b = false;
                    for (int j = 0; j < 36; j += 1)
                    {
                        // 获取当前字符的下一个有序字符
                        if (c == t[j])
                        {
                            j += 1;
                            if (j == 36)
                            {
                                j = 0;
                                b = true;
                            }
                            s[i] = t[j];
                            break;
                        }
                    }

                    // 不需要进位的情况下，结束循环
                    if (!b)
                    {
                        break;
                    }
                }
                id = new String(s);
            }
        }
        return id;
    }

    /**
     * 由用户指定的口令字符串空间随机生成复合用户要求的定长字符
     * 
     * @param sets 口令字符空间
     * @param size 生成随机口令长度
     * @param noRepeat 生成口令是否不可重复
     * @return
     * @throws Exception
     */
    public static char[] nextRandomKey(String sets, int size, boolean noRepeat) throws Exception
    {
        if (sets == null)
        {
            throw new Exception("随机口令生成异常：口令字符空间不能为空！");
        }
        return nextRandomKey(sets.toCharArray(), size, noRepeat);
    }

    /**
     * 由用户指定的口令字符串空间随机生成复合用户要求的定长字符
     * 
     * @param sets 口令字符空间
     * @param size 生成随机口令长度
     * @param noRepeat 生成口令是否不可重复
     * @return
     * @throws Exception
     */
    public static char[] nextRandomKey(char[] sets, int size, boolean noRepeat) throws Exception
    {
        if (sets == null)
        {
            throw new Exception("随机口令生成异常：口令字符空间不能为空！");
        }
        if (noRepeat && sets.length < size)
        {
            throw new Exception("随机口令生成异常：口令长度 " + size + " 大于口令字符空间长度 " + sets.length + " ，无法正确生成不可重复口令！");
        }

        char[] r = new char[size];
        Random random = new Random();
        for (int i = 0, l = sets.length, t; i < size; i++)
        {
            t = random.nextInt(l);
            r[i] = sets[t];
            if (noRepeat)
            {
                l -= 1;
                sets[t] = sets[l];
            }
        }

        return r;
    }
}

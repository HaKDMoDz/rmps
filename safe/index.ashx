<%@ WebHandler Language="C#" Class="index" %>

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Web;
using System.Web.SessionState;
using System.Text;
using System.Text.RegularExpressions;

public class index : IHttpHandler, IRequiresSessionState
{
    private HttpRequest Request;
    private HttpResponse Response;
    private HttpSessionState Session;
    private const string CAT_DIGEST = "digest";
    private const string CAT_CONFUSE = "confuse";
    private const string CAT_PRIVATE = "private";
    private const string CAT_PUBLIC = "public";
    private const string CAT_DIGITAL = "digital";

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/javascript";
        Request = context.Request;
        Response = context.Response;
        Session = context.Session;

        string ms = (Request["ms"] ?? "").Trim();//加密方案
        string mf = (Request["mf"] ?? "").Trim();//加密算法
        string md = (Request["md"] ?? "").Trim();//加密方向
        string mc = (Request["mc"] ?? "").Trim();//掩码
        string ut = Request["ut"];//明文
        string uk = Request["uk"];//口令

        bool encrypt = ("1" != md);

        if (encrypt)
        {
            // 输入文本
            if (string.IsNullOrEmpty(ut))
            {
                Write("ut", "请输入明文！");
                return;
            }

            // 加密方案
            if (string.IsNullOrEmpty(ms) || "0" == ms)
            {
                Write("ms", "请选择一个加密方案！");
                return;
            }

            // 加密算法
            if (string.IsNullOrEmpty(mf) || "0" == mf)
            {
                Write("mf", "请选择一个加密算法！");
                return;
            }
        }
        else
        {
            ms = Session["category"] as string;
            mf = Session["function"] as string;
        }

        if (string.IsNullOrEmpty(uk))
        {
            Write("uk", "请输入口令！");
            return;
        }

        // 执行加密
        if (CAT_DIGEST == ms)
        {
            DigestCipher(mf, ut);
            return;
        }
        if (CAT_PRIVATE == ms)
        {
            PrivateCipher(mf, ut, uk, encrypt);
            return;
        }
        if (CAT_PUBLIC == ms)
        {
            PublicCipher(mf, ut, uk, encrypt);
            return;
        }
        if (CAT_DIGITAL == ms)
        {
            return;
        }
    }

    private void Write(string value, string error)
    {
        StringBuilder buf = new StringBuilder();
        buf.Append("{\"value\":\"").Append(value ?? "").Append("\",");
        buf.Append(" \"error\":\"").Append(error ?? "").Append("\"}");
        Response.Write(buf.ToString());
        Response.End();
    }

    #region 内部方法
    /// <summary>
    /// 密文文本到字节转换
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    private byte[] DecodeBytes(string source)
    {
        string charKey = Session["charKey"] as string;
        if (string.IsNullOrEmpty(charKey) || "0" == charKey || !Regex.IsMatch(charKey, "^[\\dA-F]{16}$"))
        {
            return me.amon.Safe.Hex2Bytes(source);
        }

        char[] array = source.ToCharArray();
        return DecodeBytes(array, 0, array.Length, 0, null);
    }

    /// <summary>
    /// 密文字节到文本转换
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    private string EncodeBytes(byte[] array)
    {
        return EncodeBytes(array, 0, array.Length);
    }

    /// <summary>
    /// 密文字节到文本转换
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    private string EncodeBytes(byte[] array, int index, int count)
    {
        string charKey = Session["charKey"] as string;
        if (string.IsNullOrEmpty(charKey) || "0" == charKey || !Regex.IsMatch(charKey, "^[\\dA-F]{16}$"))
        {
            return me.amon.Safe.Bytes2Hex(array);
        }
        return EncodeBytes(array, index, count, 0, null);
    }

    #region 掩码处理
    private const int MAX_BITS = 8;
    /// <summary>
    /// 按指定位制及掩码对数组进行加密
    /// </summary>
    /// <param name="array">待处理的字节数组</param>
    /// <param name="index">起始索引</param>
    /// <param name="count">处理长度</param>
    /// <param name="ratio">输出位制</param>
    /// <param name="model">输出掩码</param>
    /// <returns></returns>
    private static string EncodeBytes(byte[] array, int index, int count, int ratio, char[] model)
    {
        StringBuilder buf = new StringBuilder();

        #region 正常处理
        int i = 0;//中间变量：当前整数
        int c = 0;//中间变量：当前整数中有效位数
        int m = (1 << ratio) - 1;//中间变量：位操作掩码
        int n = index + count;// 结束索引
        int t;
        for (int j = index; j < n; j += 1)
        {
            i = (i << MAX_BITS) | (array[j] & 0xFF);
            c += MAX_BITS;

            while (c >= ratio)
            {
                c -= ratio;
                t = (i >> c) & m;
                buf.Append(model[t]);
            }
            i &= ((1 << c) - 1);
        }
        #endregion

        #region 特殊处理
        if (c > 0)
        {
            buf.Append(model[i & m]);
        }
        #endregion

        return buf.ToString();
    }

    /// <summary>
    /// 按指定位制及掩码对数组进行解密
    /// </summary>
    /// <param name="array"></param>
    /// <param name="index">起始索引</param>
    /// <param name="count">处理长度</param>
    /// <param name="ratio"></param>
    /// <param name="model"></param>
    private static byte[] DecodeBytes(char[] array, int index, int count, int ratio, char[] model)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        for (int j = 0; j < model.Length; j += 1)
        {
            dict[model[j]] = j;
        }

        #region 末位是否需要特殊处理
        int m = 1;
        // 判断是否为2的次幂
        bool s = (ratio == m);
        int i = 0;
        while (i++ < 3 && !s)
        {
            m <<= 1;
            s = (ratio == m);
        }
        #endregion

        #region 正常处理
        List<byte> buf = new List<byte>();
        i = 0;
        int c = 0;
        m = (1 << ratio) - 1;//中间变量：位操作掩码
        int n = index + (s ? count : count - 1);
        int t;
        for (int j = index; j < n; j += 1)
        {
            i = (i << ratio) | dict[array[j]];
            c += ratio;
            if (c >= MAX_BITS)
            {
                c -= MAX_BITS;
                t = (i >> c) & 0xFF;
                buf.Add((byte)t);
                i &= ((1 << c) - 1);
            }
        }
        #endregion

        #region 特殊处理
        if (!s)
        {
            t = ((i << (MAX_BITS - c)) | dict[array[n]]) & 0xFF;
            buf.Add((byte)t);
        }
        #endregion

        return buf.ToArray();
    }
    #endregion

    #region 编码处理
    /// <summary>
    /// 明文文本到字节转换
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    private byte[] String2Bytes(string source)
    {
        return Encoding.UTF8.GetBytes(source);
    }

    /// <summary>
    /// 明文字节到字符转换
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    private string Bytes2String(byte[] array)
    {
        return Bytes2String(array, 0, array.Length);
    }

    /// <summary>
    /// 明文字节到字符转换
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    private string Bytes2String(byte[] array, int index, int count)
    {
        return Encoding.UTF8.GetString(array, index, count);
    }
    #endregion
    #endregion

    #region 消息摘要
    /// <summary>
    /// 摘要
    /// </summary>
    /// <param name="algName">算法名称</param>
    public void DigestCipher(string algName, string source)
    {
        HashAlgorithm algorithm = HashAlgorithm.Create(algName);
        byte[] byteOut = algorithm.ComputeHash(String2Bytes(source));
        Write(EncodeBytes(byteOut), "");
    }
    #endregion

    #region 私钥加密
    private byte[] CreateSalt(int length)
    {
        // Create a buffer
        byte[] randBytes;

        if (length < 1)
        {
            length = 1;
        }
        randBytes = new byte[length];

        // Fill the buffer with random bytes.
        new RNGCryptoServiceProvider().GetBytes(randBytes);

        // return the bytes.
        return randBytes;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="algName">算法名称</param>
    private void PrivateCipher(string algName, string userKey, string userDat, bool encrypt)
    {
        Write(encrypt ? PrivateEncrypt(algName, userKey, userDat) : PrivateDecrypt(algName, userKey, userDat), "");
    }

    /// <summary>   
    /// 加密
    /// </summary>   
    /// <param name="Source">待加密的串</param>   
    /// <returns>经过加密的串</returns>   
    private string PrivateEncrypt(string algName, string Source, string password)
    {
        SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create(algName);
        byte[] salt = CreateSalt(8);
        byte[] iv1 = algorithm.IV;
        byte[] iv2 = new byte[iv1.Length];
        Array.Copy(iv1, iv2, iv1.Length);
        PasswordDeriveBytes derive = new PasswordDeriveBytes(password, salt);
        algorithm.Key = derive.CryptDeriveKey(algName, "SHA1", algorithm.KeySize, iv2);

        byte[] byteIn = String2Bytes(Source);
        byte[] byteOut;

        //algorithm.Key = GetLegalKey(algorithm);
        //algorithm.IV = GetLegalIV(algorithm);
        using (ICryptoTransform Encryptor = algorithm.CreateEncryptor())
        {
            using (MemoryStream MemStream = new MemoryStream())
            {
                using (CryptoStream CryptoStream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write))
                {
                    CryptoStream.Write(byteIn, 0, byteIn.Length);
                    CryptoStream.FlushFinalBlock();
                    byteOut = MemStream.ToArray();
                    CryptoStream.Close();
                    MemStream.Close();
                }
            }
        }

        Session["salt"] = salt;
        Session["iv"] = iv1;

        string text = EncodeBytes(byteOut);
        SaveCipher(CAT_PRIVATE, algName, algorithm.KeySize, "", salt, iv1, text);
        return text;
    }
    /// <summary>   
    /// 解密
    /// </summary>   
    /// <param name="Source">待解密的串</param>   
    /// <returns>经过解密的串</returns>   
    private string PrivateDecrypt(string algName, string source, string password)
    {
        SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create(algName);
        byte[] salt = Session["salt"] as byte[];
        byte[] iv1 = Session["iv"] as byte[];
        byte[] iv2 = new byte[iv1.Length];
        Array.Copy(iv1, iv2, iv1.Length);
        PasswordDeriveBytes derive = new PasswordDeriveBytes(password, salt);
        algorithm.Key = derive.CryptDeriveKey(algName, "SHA1", algorithm.KeySize, iv2);
        algorithm.IV = iv1;

        byte[] byteIn = DecodeBytes(source);
        byte[] byteOut = new byte[byteIn.Length];
        int byteCnt;

        //algorithm.Key = GetLegalKey(algorithm);
        //algorithm.IV = GetLegalIV(algorithm);
        using (ICryptoTransform Decryptor = algorithm.CreateDecryptor())
        {
            using (MemoryStream MemStream = new MemoryStream(byteIn))
            {
                using (CryptoStream CryptoStream = new CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read))
                {
                    byteCnt = CryptoStream.Read(byteOut, 0, byteOut.Length);
                    CryptoStream.Close();
                    MemStream.Close();
                }
            }
        }
        return Bytes2String(byteOut, 0, byteCnt);
    }
    #endregion

    #region 公钥加密
    private void PublicCipher(string fun, string userDat, string userKey, bool encrypt)
    {
        Write(encrypt ? PublicEncrypt(userDat, userKey) : PublicDecrypt(userDat, userKey), "");
    }

    /// <summary>
    /// 加密
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    private string PublicEncrypt(string userDat, string userKey)
    {
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        rsa.FromXmlString(userKey);

        byte[] srcBytes = String2Bytes(userDat);
        byte[] dstBytes = rsa.Encrypt(srcBytes, false);

        return EncodeBytes(dstBytes);
    }

    /// <summary>
    /// 解密
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    private string PublicDecrypt(string userDat, string userKey)
    {
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        rsa.FromXmlString(userKey);

        byte[] srcBytes = DecodeBytes(userDat);
        byte[] dstBytes = rsa.Decrypt(srcBytes, false);

        return Bytes2String(dstBytes);
    }
    #endregion

    #region 数字签名
    private void DigitalCipher(string algName, string userDat, string userKey, bool encrypt)
    {
        algName = algName.ToUpper();
        if (encrypt)
        {
            if ("RSA" == algName)
            {
                RSACreate(userDat);
                return;
            }
            if ("DSA" == algName)
            {
                DSACreate(userDat);
            }
        }
        else
        {
            if ("RSA" == algName)
            {
                RSAVerify();
                return;
            }
            if ("DSA" == algName)
            {
                DSAVerify();
            }
        }
    }

    /// <summary>
    /// DSA签名
    /// </summary>
    private void RSACreate(string userDat)
    {
        byte[] bytes = String2Bytes(userDat);
        //选择签名体式格局，有RSA和DSA
        DSACryptoServiceProvider dsa = new DSACryptoServiceProvider();
        byte[] sign = dsa.SignData(bytes);
        //sign就是出来的签名效果。
    }
    /// <summary>
    /// 解密
    /// </summary>
    private void RSAVerify()
    {
        byte[] bytes = null;
        byte[] sign = null;
        DSACryptoServiceProvider dsa = new DSACryptoServiceProvider();
        dsa.FromXmlString(dsa.ToXmlString(false));
        bool ver = dsa.VerifyData(bytes, sign);
        if (ver)
        {
            Console.WriteLine("经由过程");
        }
        else
        {
            Console.WriteLine("不克不及经由过程");
        }
    }

    /// <summary>
    /// DSA签名
    /// </summary>
    private void DSACreate(string userDat)
    {
        byte[] bytes = String2Bytes(userDat);
        //选择签名体式格局，有RSA和DSA
        DSACryptoServiceProvider dsa = new DSACryptoServiceProvider();
        byte[] sign = dsa.SignData(bytes);
        //sign就是出来的签名效果。
    }
    /// <summary>
    /// 解密
    /// </summary>
    private void DSAVerify()
    {
        byte[] bytes = null;
        byte[] sign = null;
        DSACryptoServiceProvider dsa = new DSACryptoServiceProvider();
        dsa.FromXmlString(dsa.ToXmlString(false));
        bool ver = dsa.VerifyData(bytes, sign);
        if (ver)
        {
            Console.WriteLine("经由过程");
        }
        else
        {
            Console.WriteLine("不克不及经由过程");
        }
    }
    #endregion

    private string SaveCipher(string category, string function, int keySize, string charSet, byte[] salt, byte[] iv, string text)
    {
        long time = DateTime.Now.Millisecond;
        string key = time.ToString();
        me.amon.db.DBAccess dba = new me.amon.db.DBAccess();
        dba.addTable("cipher_text");
        dba.addParam("id", me.amon.util.CharUtil.encodeLong(time, false));//访问键值
        dba.addParam("code", key);//访问键值
        dba.addParam("cat", category);//加密算法
        dba.addParam("fun", function);//加密算法
        dba.addParam("keysize", keySize);//口令长度
        dba.addParam("charset", charSet);//字符集
        dba.addParam("salt", me.amon.Safe.Bytes2Hex(salt));//salt
        dba.addParam("iv", me.amon.Safe.Bytes2Hex(iv));//iv
        dba.addParam("text", text);//密文
        dba.addParam("create_time", "now()", false);//创建日间
        dba.executeInsert();
        return key;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
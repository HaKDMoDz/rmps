using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Me.Amon.Da;
using Me.Amon.Util;

namespace Me.Amon.Model
{
    public sealed class UserModel
    {
        #region 全局变量
        private string _Name;
        private string _Pass;
        private string _Code;
        private byte[] keys;
        private byte[] salt;
        private char[] mask;

        public string Name { get { return _Name; } }
        public string Code { get { return _Code; } }
        #endregion

        public string Digest(string name, string pass)
        {
            return Convert.ToBase64String(Digest(name + '%' + pass + "@APwd"));
        }

        public byte[] Digest(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }
            byte[] temp = Encoding.UTF8.GetBytes(data);
            return HashAlgorithm.Create("SHA256").ComputeHash(temp);
        }

        private byte[] GenK(string name, string code, string pass)
        {
            return Digest(name + '@' + code + "&Amon.Me/" + pass);
        }

        private byte[] GenV(string name, string code, string pass)
        {
            return Encoding.UTF8.GetBytes(code + "@Amon.Me");
        }

        #region 权限认证
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public bool SignIn(string name, string code, string pass, string data)
        {
            #region 口令散列
            // 口令
            byte[] k = GenK(name, code, pass);
            // 向量
            byte[] v = GenV(name, code, pass);
            // 数据
            byte[] t = Encoding.UTF8.GetBytes(data);
            #endregion

            #region AES 解密
            AesManaged aes = new AesManaged();
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(k, v), CryptoStreamMode.Write))
                {
                    cStream.Write(t, 0, t.Length);
                    cStream.FlushFinalBlock();
                    t = mStream.ToArray();
                }
            }
            aes.Clear();
            #endregion

            if (t.Length != 72)
            {
                return false;
            }

            _Code = Encoding.UTF8.GetString(t, 0, 8);
            int i = 8;
            salt = new byte[16];
            Array.Copy(t, i, salt, 0, salt.Length);
            i += salt.Length;
            keys = new byte[32];
            Array.Copy(t, i, keys, 0, keys.Length);
            i += keys.Length;
            mask = Encoding.UTF8.GetChars(t, 48, 16);

            _Name = name;
            _Code = code;
            return true;
        }

        public bool SignRs(string name, string pass)
        {
            return (name == _Name && pass == _Pass);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SignPb()
        {
            return true;
        }

        /// <summary>
        /// 网络登录
        /// </summary>
        /// <returns></returns>
        public bool SignNw()
        {
            return true;
        }

        /// <summary>
        /// 修改登录口令
        /// </summary>
        /// <param name="oldPwds"></param>
        /// <param name="newPwds"></param>
        /// <returns></returns>
        public bool SignPk(string oldPwds, string newPwds)
        {
            // 已有口令校验
            //pwds = oldPwds;
            //byte[] temp = signInDigest();
            //if (!Util.bytesToString(temp, true).equals(userMdl.getCfg(ConsCfg.CFG_USER_INFO, "")))
            //{
            //    return false;
            //}

            //// 摘要用户登录信息
            //pwds = newPwds;
            //temp = signInDigest();
            //userMdl.setCfg(ConsCfg.CFG_USER_INFO, Util.bytesToString(temp, true));

            //// 生成加密密钥及字符空间
            //byte[] t = new byte[32];
            //temp = new string(mask).getBytes();
            //System.arraycopy(temp, 0, t, 0, temp.length);
            //System.arraycopy(keys, 0, t, 16, keys.length);

            //// 摘要用户加密信息
            //temp = keys;
            //keys = cipherDigest();

            //// 加密安全数据
            //Cipher aes = Cipher.getInstance(ConsEnv.NAME_CIPHER);
            //aes.init(Cipher.ENCRYPT_MODE, this);
            //keys = aes.doFinal(t);
            //userMdl.setCfg(ConsCfg.CFG_USER_PKEY, Util.bytesToString(keys, true));

            //// 恢复原有数据加密口令
            //keys = temp;
            return true;
        }

        /// <summary>
        /// 口令找回
        /// </summary>
        /// <param name="usrName"></param>
        /// <param name="secPwds"></param>
        /// <returns></returns>
        public bool SignFp(string usrName, StringBuilder secPwds)
        {
            //name = usrName;

            //// 用户登录身份认证
            //string text = userMdl.getCfg(ConsCfg.CFG_USER_SKEY, "");
            //if (!com.magicpwd._util.Char.isValidate(text))
            //{
            //    return false;
            //}

            //pwds = secPwds.toString();
            //byte[] temp = signSkDigest();
            //if (text.indexOf(Util.bytesToString(temp, true)) != 0)
            //{
            //    return false;
            //}

            //// 获取用户配置密文
            //keys = cipherDigest();

            //text = text.substring(128);
            //temp = Char.toBytes(text, true);

            //// 解密用户配置密文获得解密数据
            //Cipher aes = Cipher.getInstance(ConsEnv.NAME_CIPHER);
            //aes.init(Cipher.DECRYPT_MODE, this);
            //temp = aes.doFinal(temp);

            //// 生成随机口令
            //this.name = usrName;
            //this.pwds = new string(generateUserChar());
            //byte[] t = signInDigest();
            //userMdl.setCfg(ConsCfg.CFG_USER_INFO, Util.bytesToString(t, true));

            //this.keys = cipherDigest();
            //aes.init(Cipher.ENCRYPT_MODE, this);
            //t = aes.doFinal(temp);
            //userMdl.setCfg(ConsCfg.CFG_USER_PKEY, Util.bytesToString(t, true));

            //System.arraycopy(temp, 16, keys, 0, temp.length - 16);
            //mask = new string(temp, 0, 16).toCharArray();
            //secPwds.delete(0, secPwds.length()).append(pwds);
            return true;
        }

        /// <summary>
        /// 设定安全口令
        /// </summary>
        /// <param name="oldPwds"></param>
        /// <param name="secPwds"></param>
        /// <returns></returns>
        public bool SignSk(string oldPwds, string secPwds)
        {
            //// 已有口令校验
            //pwds = oldPwds;
            //byte[] temp = signInDigest();
            //if (!Util.bytesToString(temp, true).equals(userMdl.getCfg(ConsCfg.CFG_USER_INFO, "")))
            //{
            //    return false;
            //}

            //// 认证信息
            //this.pwds = secPwds;
            //string sKey = Util.bytesToString(signSkDigest(), true);

            //temp = new string(mask).getBytes();

            //// 生成加密密钥及字符空间
            //byte[] t = new byte[32];
            //System.arraycopy(temp, 0, t, 0, temp.length);// 字符空间
            //System.arraycopy(keys, 0, t, 16, keys.length);// 加密密钥

            //// 摘要用户加密信息
            //temp = keys;
            //keys = cipherDigest();

            //// 加密安全数据
            //Cipher aes = Cipher.getInstance(ConsEnv.NAME_CIPHER);
            //aes.init(Cipher.ENCRYPT_MODE, this);
            //t = aes.doFinal(t);
            //userMdl.setCfg(ConsCfg.CFG_USER_SKEY, sKey + Util.bytesToString(t, true));

            //this.keys = temp;
            //this.pwds = null;

            return true;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        public string SignUp(string name, string pass)
        {
            _Code = "A0000000";
            byte[] k = GenK(name, _Code, pass);
            byte[] v = GenV(name, _Code, pass);

            Random r = new Random();
            salt = new byte[16];
            r.NextBytes(salt);
            keys = new byte[32];
            r.NextBytes(keys);
            mask = GenChar();

            byte[] t = new byte[72];
            byte[] a = Encoding.UTF8.GetBytes(_Code);
            int i = 0;
            Array.Copy(a, 0, t, i, a.Length);
            i += a.Length;
            Array.Copy(salt, 0, t, i, salt.Length);
            i += salt.Length;
            Array.Copy(keys, 0, t, i, keys.Length);
            i += keys.Length;
            a = Encoding.UTF8.GetBytes(mask);
            Array.Copy(a, 0, t, i, a.Length);

            #region AES 加密
            AesManaged aes = new AesManaged();
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(k, v), CryptoStreamMode.Write))
                {
                    cStream.Write(t, 0, t.Length);
                    cStream.FlushFinalBlock();
                    t = mStream.ToArray();
                }
            }
            aes.Clear();
            #endregion

            return Convert.ToBase64String(t);
        }
        #endregion

        private char[] GenChar()
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
            return CharUtil.NextRandomKey(c, 16, false);
        }

        #region 数据安全
        public string Decode(string data)
        {
            AesManaged aes = new AesManaged();

            byte[] buf = CharUtil.DecodeString(data, mask);
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(keys, salt), CryptoStreamMode.Write))
                {
                    cStream.Write(buf, 0, buf.Length);
                    cStream.FlushFinalBlock();
                    buf = mStream.ToArray();
                }
            }
            aes.Clear();

            return Encoding.UTF8.GetString(buf, 0, buf.Length);
        }

        public string Encode(string data)
        {
            AesManaged aes = new AesManaged();

            byte[] buf = Encoding.UTF8.GetBytes(data);
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(keys, salt), CryptoStreamMode.Write))
                {
                    cStream.Write(buf, 0, buf.Length);
                    cStream.FlushFinalBlock();
                    buf = mStream.ToArray();
                }
            }
            aes.Clear();

            return CharUtil.EncodeString(buf, mask);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Post(string data)
        {
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            //client.UploadStringAsync(new Uri(EnvConst.SERVER_PATH), "POST", "c=" + Code + "&t=" + _Token + data);
        }

        private DBAccess _DBAccess;
        private DCAccess _DCAccess;
        private DFAccess _DFAccess;

        public void Init()
        {
            _DBAccess = new DBAccess();
            _DBAccess.Init(this);
            _DCAccess = new DCAccess();
            _DCAccess.Init(this);
            _DFAccess = new DFAccess();
            _DFAccess.Init(this);
        }

        public DBAccess DBAccess { get { return _DBAccess; } }
        public DCAccess DCAccess { get { return _DCAccess; } }
        public DFAccess DFAccess { get { return _DFAccess; } }
    }
}

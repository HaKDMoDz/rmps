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

        #region 权限认证
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        private bool Verify(string name, string pass, string code)
        {
            #region 口令散列
            byte[] temp = Encoding.UTF8.GetBytes(name + code);
            // 口令
            //byte[] key = new SHA256Managed().ComputeHash(temp);
            byte[] key = MD5.Create("MD5").ComputeHash(temp);
            // 向量
            byte[] iv = Encoding.UTF8.GetBytes(code + "@Amon.Me");
            // 数据
            byte[] data = Convert.FromBase64String(pass);
            #endregion

            #region AES 解密
            AesManaged aes = new AesManaged();
            //aes.Mode = CipherMode.CBC;
            //aes.Padding = PaddingMode.Zeros;

            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(key, iv), CryptoStreamMode.Write))
                {
                    cStream.Write(data, 0, data.Length);
                    cStream.FlushFinalBlock();
                    data = mStream.ToArray();
                }
            }
            aes.Clear();
            #endregion

            salt = new byte[16];
            Array.Copy(data, 0, salt, 0, 16);
            keys = new byte[32];
            Array.Copy(data, 16, keys, 0, 32);
            mask = Encoding.UTF8.GetChars(data, 48, 16);

            _Name = name;
            _Pass = pass;
            _Code = code;
            return true;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public bool SignIn(string name, string pass, string code)
        {
            return Verify(name, pass, code);
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
        public bool SignUp(string name, string pass, string code)
        {
            return Verify(name, pass, code);
        }
        #endregion

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

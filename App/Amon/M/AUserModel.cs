using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Me.Amon.Da.Df;
using Me.Amon.Util;

namespace Me.Amon.M
{
    public class AUserModel
    {
        #region 全局变量
        #region 用户信息
        public string Code { get; protected set; }
        public string Name { get; protected set; }
        #endregion

        #region 安全信息
        private string _Info;
        private string _Lock;
        private byte[] _Data;

        private byte[] _Keys;
        private byte[] _Salt;
        private char[] _Mask;
        #endregion

        #region 路径信息
        /// <summary>
        /// 系统配置所在目录
        /// </summary>
        public string SysHome { get; protected set; }
        /// <summary>
        /// 用户数据所在目录
        /// </summary>
        public string DatHome { get; protected set; }
        /// <summary>
        /// 备份数据所在目录
        /// </summary>
        public string BakHome { get; protected set; }
        /// <summary>
        /// 资源文件所在目录
        /// </summary>
        public string ResHome { get; protected set; }
        #endregion

        #region 存储信息
        /// <summary>
        /// 云存储类型
        /// </summary>
        public string CsType { get; set; }
        /// <summary>
        /// 云存储授权
        /// </summary>
        public string CsAuth { get; set; }
        #endregion

        #region 皮肤信息
        /// <summary>
        /// 外观文件
        /// </summary>
        public string Look { get; set; }
        /// <summary>
        /// 风格文件
        /// </summary>
        public string Feel { get; set; }
        #endregion

        #region 应用信息
        /// <summary>
        /// 上次登录应用
        /// </summary>
        public string LastApps { get; set; }
        /// <summary>
        /// 上次登录用户
        /// </summary>
        public string LastUser { get; set; }
        #endregion

        /// <summary>
        /// 提醒检测间隔
        /// </summary>
        public int NoticeInterval { get; set; }
        #endregion

        #region 初始化
        public virtual void Init()
        {
            if (File.Exists("Amon.tag"))
            {
                SysHome = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "阿木密码箱");
                if (!Directory.Exists(SysHome))
                {
                    Directory.CreateDirectory(SysHome);
                }
            }
            else
            {
                SysHome = Environment.CurrentDirectory;
            }
        }

        public virtual void Load()
        {
            ResHome = SysHome;
            DatHome = Path.Combine(SysHome, "Dat", Code);
        }
        #endregion

        #region 权限认证
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public bool CaSignIn(string home, string code, string name, string pass)
        {
            string file = Path.Combine(home, CApp.AMON_CFG);
            if (!File.Exists(file))
            {
                return false;
            }

            DFEngine prop = new DFEngine();
            prop.Load(file);

            string data = prop.Get(CApp.AMON_CFG_DATA);
            if (!CharUtil.IsValidate(data, 344))
            {
                return false;
            }
            _Data = Convert.FromBase64String(data);

            string info = Digest(name, pass);
            if (info != prop.Get(CApp.AMON_CFG_INFO))
            {
                return false;
            }

            string main = prop.Get(CApp.AMON_CFG_MAIN);
            if (!Decrypt(name, code, pass, main))
            {
                return false;
            }

            _Lock = prop.Get(CApp.AMON_CFG_LOCK);

            this.Name = name;
            this.Code = code;
            this.DatHome = home;
            _Info = info;
            Look = "Default";
            Feel = "Default";
            return true;
        }

        /// <summary>
        /// 重新认证
        /// </summary>
        /// <param name="name"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool CaSignRc(string name, string pass)
        {
            return (name == this.Name && _Info == Digest(this.Name, pass));
        }

        /// <summary>
        /// 屏幕加锁
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        public bool CaAuthRc(string pass)
        {
            return _Lock == Digest(this.Name, pass);
        }

        /// <summary>
        /// 修改登录口令
        /// </summary>
        /// <param name="oldPass"></param>
        /// <param name="newPass"></param>
        /// <returns></returns>
        public bool CaAuthPk(string oldPass, string newPass)
        {
            DFEngine prop = new DFEngine();
            prop.Load(Path.Combine(this.DatHome, CApp.AMON_CFG));

            // 已有口令校验
            string info = Digest(Name, oldPass);
            if (info != prop.Get(CApp.AMON_CFG_INFO))
            {
                return false;
            }

            // 生成加密密钥及字符空间
            byte[] t = new byte[72];
            byte[] a = Encoding.UTF8.GetBytes(Code);
            int i = 0;
            Array.Copy(a, 0, t, i, a.Length);
            i += a.Length;
            Array.Copy(_Salt, 0, t, i, _Salt.Length);
            i += _Salt.Length;
            Array.Copy(_Keys, 0, t, i, _Keys.Length);
            i += _Keys.Length;
            a = Encoding.UTF8.GetBytes(_Mask);
            Array.Copy(a, 0, t, i, a.Length);

            // 口令
            byte[] k = GenK(Name, Code, newPass);
            // 向量
            byte[] v = GenV(Name, Code, newPass);

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

            // 摘要用户登录信息
            info = Digest(Name, newPass);

            string main = Convert.ToBase64String(t);
            prop.Set(CApp.AMON_CFG_INFO, info);
            prop.Set(CApp.AMON_CFG_MAIN, main);
            prop.Save(Path.Combine(this.DatHome, CApp.AMON_CFG));

            return true;
        }

        /// <summary>
        /// 口令找回
        /// </summary>
        /// <param name="usrName"></param>
        /// <param name="secPass"></param>
        /// <returns></returns>
        public bool CaSignFk(string usrName, StringBuilder secPass)
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
        /// 设定锁屏口令
        /// </summary>
        /// <returns></returns>
        public bool CaAuthLk(string oldPass, string newPass)
        {
            if (_Lock != Digest(this.Name, oldPass))
            {
                return false;
            }

            _Lock = Digest(Name, newPass);

            DFEngine prop = new DFEngine();
            prop.Load(Path.Combine(this.DatHome, CApp.AMON_CFG));
            prop.Set(CApp.AMON_CFG_LOCK, _Lock);
            prop.Save(Path.Combine(this.DatHome, CApp.AMON_CFG));
            return true;
        }

        /// <summary>
        /// 设定安全口令
        /// </summary>
        /// <param name="oldPass"></param>
        /// <param name="secPass"></param>
        /// <returns></returns>
        public bool CaAuthSk(string oldPass, string secPass)
        {
            DFEngine prop = new DFEngine();
            prop.Load(Path.Combine(this.DatHome, CApp.AMON_CFG));

            // 已有口令校验
            string info = Digest(Name, oldPass);
            if (info != prop.Get(CApp.AMON_CFG_INFO))
            {
                return false;
            }

            // 生成加密密钥及字符空间
            byte[] t = new byte[72];
            byte[] a = Encoding.UTF8.GetBytes(Code);
            int i = 0;
            Array.Copy(a, 0, t, i, a.Length);
            i += a.Length;
            Array.Copy(_Salt, 0, t, i, _Salt.Length);
            i += _Salt.Length;
            Array.Copy(_Keys, 0, t, i, _Keys.Length);
            i += _Keys.Length;
            a = Encoding.UTF8.GetBytes(_Mask);
            Array.Copy(a, 0, t, i, a.Length);

            // 口令
            byte[] k = GenK(Name, Code, secPass);
            // 向量
            byte[] v = GenV(Name, Code, secPass);

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

            prop.Set(CApp.AMON_CFG_SAFE, Convert.ToBase64String(t));
            prop.Save(Path.Combine(this.DatHome, CApp.AMON_CFG));
            return true;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        public bool CaSignUp(string root, string code, string name, string pass)
        {
            byte[] k = GenK(name, code, pass);
            byte[] v = GenV(name, code, pass);

            Random r = new Random();
            _Salt = new byte[16];
            r.NextBytes(_Salt);
            _Keys = new byte[32];
            r.NextBytes(_Keys);
            _Mask = GenChar();

            byte[] t = new byte[72];
            byte[] a = Encoding.UTF8.GetBytes(code);
            int i = 0;
            Array.Copy(a, 0, t, i, a.Length);
            i += a.Length;
            Array.Copy(_Salt, 0, t, i, _Salt.Length);
            i += _Salt.Length;
            Array.Copy(_Keys, 0, t, i, _Keys.Length);
            i += _Keys.Length;
            a = Encoding.UTF8.GetBytes(_Mask);
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
            string main = Convert.ToBase64String(t);

            _Data = new byte[256];
            r.NextBytes(_Data);
            string info = Digest(name, pass);

            this.DatHome = Path.Combine(root, code);
            if (!Directory.Exists(this.DatHome))
            {
                Directory.CreateDirectory(this.DatHome);
            }
            DFEngine prop = new DFEngine();
            prop.Set(CApp.AMON_CFG_NAME, name);
            prop.Set(CApp.AMON_CFG_CODE, code);
            prop.Set(CApp.AMON_CFG_DATA, Convert.ToBase64String(_Data));
            prop.Set(CApp.AMON_CFG_INFO, info);
            prop.Set(CApp.AMON_CFG_LOCK, info);
            prop.Set(CApp.AMON_CFG_MAIN, main);
            prop.Set(CApp.AMON_CFG_SAFE, "");
            prop.Save(Path.Combine(this.DatHome, CApp.AMON_CFG));

            this.Name = name;
            this.Code = code;
            _Info = info;
            _Lock = info;
            Look = "Default";
            Feel = "Default";
            return true;
        }

        public void CaSignOf()
        {
            _Lock = null;
            _Keys = null;
            _Salt = null;
            _Mask = null;

            this.Name = null;
            this.Code = null;
            this.DatHome = null;
        }

        /// <summary>
        /// 网络登录
        /// </summary>
        /// <returns></returns>
        public bool WsSignIn(string home, string code, string name, string pass, XmlReader reader)
        {
            string data = null;
            if (reader.Name == "Data" || reader.ReadToFollowing("Data"))
            {
                data = reader.ReadElementContentAsString();
            }
            if (!Regex.IsMatch(data, "^[A-Za-z0-9+/=]{256,}$"))
            {
                return false;
            }

            string info = null;
            if (reader.Name == "Info" || reader.ReadToFollowing("Info"))
            {
                info = reader.ReadElementContentAsString();
            }
            if (!Regex.IsMatch(info, "^[A-Za-z0-9+/=]{44}$"))
            {
                return false;
            }

            string main = null;
            if (reader.Name == "Main" || reader.ReadToFollowing("Main"))
            {
                main = reader.ReadElementContentAsString();
            }
            if (!Regex.IsMatch(main, "^[A-Za-z0-9+/=]{108}$"))
            {
                return false;
            }

            string safe = null;
            if (reader.Name == "Safe" || reader.ReadToFollowing("Safe"))
            {
                safe = reader.ReadElementContentAsString();
            }

            _Data = Convert.FromBase64String(data);
            if (info != Digest(name, pass))
            {
                return false;
            }

            if (!Decrypt(name, code, pass, main))
            {
                return false;
            }

            this.DatHome = home;
            DFEngine prop = new DFEngine();
            prop.Set(CApp.AMON_CFG_NAME, name);
            prop.Set(CApp.AMON_CFG_CODE, code);
            prop.Set(CApp.AMON_CFG_DATA, data);
            prop.Set(CApp.AMON_CFG_INFO, info);
            prop.Set(CApp.AMON_CFG_LOCK, info);
            prop.Set(CApp.AMON_CFG_MAIN, main);
            prop.Set(CApp.AMON_CFG_SAFE, safe);
            prop.Save(Path.Combine(this.DatHome, CApp.AMON_CFG));

            this.Name = name;
            this.Code = code;
            _Info = info;
            _Lock = info;
            Look = "Default";
            Feel = "Default";
            return true;
        }

        public bool WsSignPk(string oldPass, string newPass, XmlReader reader)
        {
            string code = null;
            if (reader.Name == "Code" || reader.ReadToFollowing("Code"))
            {
                code = reader.ReadElementContentAsString();
            }
            if (!CharUtil.IsValidateCode(code))
            {
                return false;
            }

            string data = null;
            if (reader.Name == "Data" || reader.ReadToFollowing("Data"))
            {
                data = reader.ReadElementContentAsString();
            }
            if (!Regex.IsMatch(data, "^[A-Za-z0-9+/=]{256,}$"))
            {
                return false;
            }

            string info = null;
            if (reader.Name == "Info" || reader.ReadToFollowing("Info"))
            {
                info = reader.ReadElementContentAsString();
            }
            if (!Regex.IsMatch(info, "^[A-Za-z0-9+/=]{44}$"))
            {
                return false;
            }

            string main = null;
            if (reader.Name == "Main" || reader.ReadToFollowing("Main"))
            {
                main = reader.ReadElementContentAsString();
            }
            if (!Regex.IsMatch(main, "^[A-Za-z0-9+/=]{108}$"))
            {
                return false;
            }

            string safe = null;
            if (reader.Name == "Safe" || reader.ReadToFollowing("Safe"))
            {
                safe = reader.ReadElementContentAsString();
            }

            _Data = Convert.FromBase64String(data);
            if (info != Digest(oldPass, newPass))
            {
                return false;
            }

            if (!Decrypt(oldPass, code, newPass, main))
            {
                return false;
            }

            DFEngine prop = new DFEngine();
            prop.Load(Path.Combine(this.DatHome, CApp.AMON_CFG));
            prop.Set(CApp.AMON_CFG_NAME, oldPass);
            prop.Set(CApp.AMON_CFG_CODE, code);
            prop.Set(CApp.AMON_CFG_DATA, data);
            prop.Set(CApp.AMON_CFG_INFO, info);
            prop.Set(CApp.AMON_CFG_LOCK, _Lock);
            prop.Set(CApp.AMON_CFG_MAIN, main);
            prop.Set(CApp.AMON_CFG_SAFE, safe);
            prop.Save(Path.Combine(this.DatHome, CApp.AMON_CFG));

            return true;
        }

        public bool WsSignSk(XmlReader reader)
        {
            return true;
        }
        #endregion

        #region 数据安全
        private string Digest(string name, string pass)
        {
            byte[] s = Encoding.UTF8.GetBytes(name + '%' + pass + "@Amon");
            byte[] t = new byte[_Data.Length + s.Length];
            Array.Copy(_Data, t, _Data.Length);
            Array.Copy(s, 0, t, _Data.Length, s.Length);

            return Convert.ToBase64String(Digest(t));
        }

        private byte[] Digest(byte[] data)
        {
            return HashAlgorithm.Create("SHA256").ComputeHash(data);
        }

        private byte[] GenK(string name, string code, string pass)
        {
            return Digest(Encoding.UTF8.GetBytes(name + '@' + code + "&Amon.Me/" + pass));
        }

        private byte[] GenV(string name, string code, string pass)
        {
            return Encoding.UTF8.GetBytes(code + "@Amon.Me");
        }

        private bool Decrypt(string name, string code, string pass, string main)
        {
            #region 口令散列
            // 口令
            byte[] k = GenK(name, code, pass);
            // 向量
            byte[] v = GenV(name, code, pass);
            // 数据
            byte[] t = Convert.FromBase64String(main);
            pass = null;
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

            this.Code = Encoding.UTF8.GetString(t, 0, 8);
            int i = 8;
            _Salt = new byte[16];
            Array.Copy(t, i, _Salt, 0, _Salt.Length);
            i += _Salt.Length;
            _Keys = new byte[32];
            Array.Copy(t, i, _Keys, 0, _Keys.Length);
            i += _Keys.Length;
            _Mask = Encoding.UTF8.GetChars(t, i, 16);
            return true;
        }

        public string Decode(string dat, int sec)
        {
            byte[] buf;
            if (sec == CApp.SEC_AES)
            {
                AesManaged aes = new AesManaged();

                buf = CharUtil.DecodeString(dat, _Mask);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(_Keys, _Salt), CryptoStreamMode.Write))
                    {
                        cStream.Write(buf, 0, buf.Length);
                        cStream.FlushFinalBlock();
                        buf = mStream.ToArray();
                    }
                }
                aes.Clear();

                return Encoding.UTF8.GetString(buf, 0, buf.Length);
            }

            if (sec == CApp.SEC_BASE64)
            {
                buf = Convert.FromBase64String(dat);
                return Encoding.UTF8.GetString(buf, 0, buf.Length);
            }

            return dat;
        }

        public string EncodeKey(string data)
        {
            AesManaged aes = new AesManaged();

            byte[] buf = Encoding.UTF8.GetBytes(data);
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(_Keys, _Salt), CryptoStreamMode.Write))
                {
                    cStream.Write(buf, 0, buf.Length);
                    cStream.FlushFinalBlock();
                    buf = mStream.ToArray();
                }
            }
            aes.Clear();

            return CharUtil.EncodeString(buf, _Mask);
        }
        #endregion

        #region 私有函数
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
            return SafeUtil.NextRandomKey(c, 16, false);
        }
        #endregion
    }
}

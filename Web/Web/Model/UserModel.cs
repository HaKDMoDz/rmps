using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.SessionState;
using System.Xml;
using Me.Amon.Da;
using Me.Amon.Util;

namespace Me.Amon.Model
{
    public sealed class UserModel
    {
        #region 全局变量
        //private string _Info;
        private byte[] _Data;
        private byte[] _Keys;
        private byte[] _Salt;
        private char[] _Mask;

        private string Hash { get { return _Hash; } }
        private string _Hash;
        public int Rank { get { return _Rank; } }
        private int _Rank;
        public string Code { get { return _Code; } }
        private string _Code;
        public string Name { get { return _Name; } }
        private string _Name;
        //public string Home { get { return _Home; } }
        //private string _Home;
        public string Mail { get { return _Mail; } }
        private string _Mail;
        #endregion

        public UserModel()
        {
            _Rank = 0;
            _Hash = "";
            _Code = "A0000000";
            _Name = "用户";
            _Mail = "user@amonsoft.cn";
        }

        #region 静态函数
        public static UserModel Current(HttpSessionState Session)
        {
            var um = (UserModel)Session[IEnv.SESSION_USER];
            if (um == null)
            {
                um = new UserModel();
                Session[IEnv.SESSION_USER] = um;
            }
            return um;
        }
        #endregion

        #region 权限认证
        /// <summary>
        /// 网页登录
        /// </summary>
        /// <returns></returns>
        public bool WpSignIn(string name, string pass)
        {
            var dba = new DBAccess();

            // 登录用户验证
            dba.ReInit();
            dba.AddTable(DBConst.C3010400);
            dba.AddTable(DBConst.C3010300);
            dba.AddColumn(DBConst.C3010401);
            dba.AddColumn(DBConst.C3010302);
            dba.AddColumn(DBConst.C3010407);
            dba.AddWhere(DBConst.C3010405, HttpUtil.Text2Db(name));
            dba.AddWhere(DBConst.C3010402, DBConst.C3010302, false);
            DataTable dt = dba.ExecuteSelect();
            if (dt == null || dt.Rows.Count != 1)
            {
                return false;
            }

            string tmpHash = dt.Rows[0][DBConst.C3010401] as string;
            string tmpCode = dt.Rows[0][DBConst.C3010302] as string;
            _Name = dt.Rows[0][DBConst.C3010407] as string;

            // 登录口令验证
            dba.ReInit();
            dba.AddTable(DBConst.C3010600);
            dba.AddColumn(DBConst.C3010603);
            dba.AddColumn(DBConst.C301060F);
            dba.AddWhere(DBConst.C3010602, tmpHash);
            dt = dba.ExecuteSelect();
            if (dt == null || dt.Rows.Count != 1)
            {
                return false;
            }

            string t = dt.Rows[0][DBConst.C301060F] as string;
            if (string.IsNullOrEmpty(t))
            {
                return false;
            }
            _Data = Convert.FromBase64String(t);
            string tmpPwds = Digest(name.ToLower(), pass, _Data);
            if (tmpPwds != dt.Rows[0][DBConst.C3010603].ToString())
            {
                return false;
            }

            // 登录权限读取
            dba.ReInit();
            dba.AddTable(DBConst.C3010F00);
            dba.AddTable(DBConst.C3010200);
            dba.AddColumn(DBConst.C3010F02);
            dba.AddWhere(DBConst.C3010203, DBConst.C3010F03, false);
            dba.AddWhere(DBConst.C3010202, tmpHash);
            dba.AddWhere(DBConst.C3010204, "APWD0000");
            dt = dba.ExecuteSelect();
            if (dt == null || dt.Rows.Count != 1)
            {
                return false;
            }

            _Code = tmpCode;
            _Hash = tmpHash;
            _Rank = (int)dt.Rows[0][DBConst.C3010F02];

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void WpSignOf()
        {
            _Rank = 0;
            _Hash = "";
            _Code = "A0000000";
            _Name = "用户";
            _Mail = "user@amonsoft.cn";
        }

        /// <summary>
        /// 修改登录口令
        /// </summary>
        /// <param name="oldPass"></param>
        /// <param name="newPass"></param>
        /// <returns></returns>
        public bool WpSignPk(string oldPass, string newPass)
        {
            // 口令验证
            string tmpPwds = Digest(_Name, oldPass, _Data);

            // 执行查询
            var dba = new DBAccess();
            dba.AddTable(DBConst.C3010600);
            dba.AddColumn(DBConst.C3010603);
            dba.AddWhere(DBConst.C3010602, _Hash);
            DataTable dt = dba.ExecuteSelect();

            // 数据验证
            if (dt.Rows.Count != 1)
            {
                return false;
            }
            oldPass = dt.Rows[0][0].ToString();
            if (tmpPwds != oldPass)
            {
                return false;
            }

            tmpPwds = Digest(_Name, newPass, _Data);

            // 修改口令
            dba.ReInit();
            dba.AddTable(DBConst.C3010600);
            dba.AddParam(DBConst.C3010603, tmpPwds);
            dba.AddParam(DBConst.C3010610, DBConst.SQL_NOW, false);
            dba.AddWhere(DBConst.C3010602, _Hash);
            return 1 == dba.ExecuteUpdate();
        }

        /// <summary>
        /// 口令找回
        /// </summary>
        /// <param name="usrName"></param>
        /// <param name="secPwds"></param>
        /// <returns></returns>
        public bool WpSignFp(string usrName, StringBuilder secPwds)
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
        public bool WpSignSk(string oldPwds, string secPwds)
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
        /// 用户注册（网页方式）
        /// </summary>
        /// <param name="name">登录用户</param>
        /// <param name="pass">用户口令</param>
        /// <param name="mail">电子邮件</param>
        /// <returns></returns>
        public int WpSignUp(string name, string pass, string mail)
        {
            #region 用户名判断
            DBAccess dba = new DBAccess();
            dba.AddTable(DBConst.C3010400);
            dba.AddColumn(DBConst.C3010402);
            dba.AddWhere(string.Format("{0}='{1}' OR {2}='{3}'", DBConst.C3010405, name, DBConst.C3010406, mail));
            DataTable dt = dba.ExecuteSelect();
            if (dt.Rows.Count != 0)
            {
                return IMsg.MSG_SIGNUP_EXIST;
            }
            #endregion

            #region 用户信息
            dba.ReInit();
            dba.AddTable(DBConst.C3010400);
            dba.AddColumn(string.Format("MAX({0}) {0}", DBConst.C3010402));
            dba.AddWhere(string.Format("LENGTH({0})=8", DBConst.C3010402));
            dt = dba.ExecuteSelect();
            string code = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                code = dt.Rows[0][0].ToString();
            }
            if (CharUtil.IsValidateCode(code))
            {
                code = CharUtil.GenerateUserCode(code);
            }
            else
            {
                code = "A0000000";
            }
            #endregion

            string hash = HashUtil.UtcTimeInHex(false);

            #region 真实信息
            dba.ReInit();
            dba.AddTable(DBConst.C3010300);
            dba.AddParam(DBConst.C3010301, hash);
            dba.AddParam(DBConst.C3010302, code);
            dba.AddParam(DBConst.C3010303, "");
            dba.AddParam(DBConst.C3010304, "");
            dba.AddParam(DBConst.C3010305, 1);
            dba.AddParam(DBConst.C3010306, null);
            dba.AddParam(DBConst.C3010307, "");
            dba.AddParam(DBConst.C3010308, DBConst.SQL_NOW, false);
            dba.AddParam(DBConst.C3010309, DBConst.SQL_NOW, false);
            if (dba.ExecuteInsert() != 1)
            {
                return IMsg.MSG_SIGNUP_INNER;
            }
            #endregion

            #region 在线信息
            dba.ReInit();
            dba.AddTable(DBConst.C3010400);
            dba.AddParam(DBConst.C3010401, hash);
            dba.AddParam(DBConst.C3010402, code);
            dba.AddParam(DBConst.C3010403, "0");
            dba.AddParam(DBConst.C3010404, "0");
            dba.AddParam(DBConst.C3010405, name);
            dba.AddParam(DBConst.C3010406, mail);
            dba.AddParam(DBConst.C3010407, name);
            dba.AddParam(DBConst.C3010408, "0");
            dba.AddParam(DBConst.C3010409, "");
            dba.AddParam(DBConst.C301040A, "");
            dba.AddParam(DBConst.C301040B, "");
            dba.AddParam(DBConst.C301040C, DBConst.SQL_NOW, false);
            dba.AddParam(DBConst.C301040D, DBConst.SQL_NOW, false);
            if (dba.ExecuteInsert() != 1)
            {
                return IMsg.MSG_SIGNUP_INNER;
            }
            #endregion

            #region 联系方式
            dba.ReInit();
            dba.AddTable(DBConst.C3010500);
            dba.AddParam(DBConst.C3010501, "0");
            dba.AddParam(DBConst.C3010502, IUser.MAJOR_04);
            dba.AddParam(DBConst.C3010503, hash);
            dba.AddParam(DBConst.C3010504, code);
            dba.AddParam(DBConst.C3010505, "sctteqacvfxgqgtb");// 电子邮件
            dba.AddParam(DBConst.C3010506, mail);
            dba.AddParam(DBConst.C3010507, "");
            dba.AddParam(DBConst.C3010508, DBConst.SQL_NOW, false);
            dba.AddParam(DBConst.C3010509, DBConst.SQL_NOW, false);
            if (dba.ExecuteInsert() != 1)
            {
                return IMsg.MSG_SIGNUP_INNER;
            }
            #endregion

            #region 安全信息
            _Data = new byte[256];
            new Random().NextBytes(_Data);
            string info = Digest(name.ToLower(), pass, _Data);
            dba.ReInit();
            dba.AddTable(DBConst.C3010600);
            dba.AddParam(DBConst.C3010601, hash);
            dba.AddParam(DBConst.C3010602, hash);
            dba.AddParam(DBConst.C3010603, info);
            dba.AddParam(DBConst.C3010604, mail);
            dba.AddParam(DBConst.C3010605, "");
            dba.AddParam(DBConst.C3010606, "");
            dba.AddParam(DBConst.C3010607, "");
            dba.AddParam(DBConst.C3010608, "");
            dba.AddParam(DBConst.C3010609, "");
            dba.AddParam(DBConst.C301060A, "");
            dba.AddParam(DBConst.C301060B, "");
            dba.AddParam(DBConst.C301060C, "");
            dba.AddParam(DBConst.C301060D, "");
            dba.AddParam(DBConst.C301060E, "");
            dba.AddParam(DBConst.C301060F, Convert.ToBase64String(_Data));
            dba.AddParam(DBConst.C3010610, DBConst.SQL_NOW, false);
            dba.AddParam(DBConst.C3010611, DBConst.SQL_NOW, false);
            if (dba.ExecuteInsert() != 1)
            {
                return IMsg.MSG_SIGNUP_INNER;
            }
            #endregion

            #region 权限分配
            dba.ReInit();
            dba.AddTable(DBConst.C3010200);
            dba.AddParam(DBConst.C3010201, hash);
            dba.AddParam(DBConst.C3010202, hash);
            dba.AddParam(DBConst.C3010203, "sctvsxyttfzeqqgq");//一般用户
            dba.AddParam(DBConst.C3010204, "APWD0000");
            dba.AddParam(DBConst.C3010205, "");
            dba.AddParam(DBConst.C3010206, DBConst.SQL_NOW, false);
            dba.AddParam(DBConst.C3010207, DBConst.SQL_NOW, false);
            if (dba.ExecuteInsert() != 1)
            {
                return IMsg.MSG_SIGNUP_INNER;
            }
            #endregion

            _Name = name;
            _Code = code;
            _Rank = IUser.LEVEL_02;//一般用户

            return IMsg.MSG_SIGNUP_SUCCESS;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        public bool WsSignUp(string name, string pass, XmlWriter writer)
        {
            name = name.ToLower();
            Random r = new Random();

            // 口令
            byte[] t = new byte[72];
            int i = 0;
            byte[] a = Encoding.UTF8.GetBytes(_Code);
            Array.Copy(a, 0, t, i, a.Length);
            i += a.Length;

            _Salt = new byte[16];
            r.NextBytes(_Salt);
            Array.Copy(_Salt, 0, t, i, _Salt.Length);
            i += _Salt.Length;

            _Keys = new byte[32];
            r.NextBytes(_Keys);
            Array.Copy(_Keys, 0, t, i, _Keys.Length);
            i += _Keys.Length;

            _Mask = CharUtil.GenerateUserChar();
            a = Encoding.UTF8.GetBytes(_Mask);
            Array.Copy(a, 0, t, i, a.Length);

            #region AES 加密
            byte[] k = GenK(name, _Code, pass);
            byte[] v = GenV(name, _Code, pass);
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

            DBAccess dba = new DBAccess();
            dba.AddTable(DBConst.APWD0000);
            dba.AddWhere(DBConst.APWD0001, _Code);
            dba.AddDeleteBatch();

            a = new byte[256];
            r.NextBytes(a);
            string data = Convert.ToBase64String(a);
            dba.ReInit();
            dba.AddTable(DBConst.APWD0000);
            dba.AddParam(DBConst.APWD0001, _Code);
            dba.AddParam(DBConst.APWD0002, "Data");
            dba.AddParam(DBConst.APWD0003, data);
            dba.AddParam(DBConst.APWD0004, DBConst.SQL_NOW, false);
            dba.AddInsertBatch();

            string info = Digest(name, pass, a);
            dba.ReInit();
            dba.AddTable(DBConst.APWD0000);
            dba.AddParam(DBConst.APWD0001, _Code);
            dba.AddParam(DBConst.APWD0002, "Info");
            dba.AddParam(DBConst.APWD0003, info);
            dba.AddParam(DBConst.APWD0004, DBConst.SQL_NOW, false);
            dba.AddInsertBatch();

            string main = Convert.ToBase64String(t);
            dba.ReInit();
            dba.AddTable(DBConst.APWD0000);
            dba.AddParam(DBConst.APWD0001, _Code);
            dba.AddParam(DBConst.APWD0002, "Main");
            dba.AddParam(DBConst.APWD0003, main);
            dba.AddParam(DBConst.APWD0004, DBConst.SQL_NOW, false);
            dba.AddInsertBatch();

            string safe = "";
            dba.ReInit();
            dba.AddTable(DBConst.APWD0000);
            dba.AddParam(DBConst.APWD0001, _Code);
            dba.AddParam(DBConst.APWD0002, "Safe");
            dba.AddParam(DBConst.APWD0003, safe);
            dba.AddParam(DBConst.APWD0004, DBConst.SQL_NOW, false);
            dba.AddInsertBatch();
            dba.ExecuteBatch();

            a = new byte[256];
            new Random().NextBytes(a);
            writer.WriteElementString("Code", _Code);
            writer.WriteElementString("Data", data);
            writer.WriteElementString("Info", info);
            writer.WriteElementString("Main", main);
            writer.WriteElementString("Safe", safe);
            return true;
        }

        /// <summary>
        /// 修改口令
        /// </summary>
        /// <param name="name"></param>
        /// <param name="oldPass"></param>
        /// <param name="newPass"></param>
        /// <returns></returns>
        public bool WsSignPk(string name, string oldPass, string newPass, XmlWriter writer)
        {
            var dba = new DBAccess();
            dba.AddTable(DBConst.C3010400);
            dba.AddColumn(DBConst.C3010402);
            dba.AddWhere(DBConst.C3010400, CharUtil.Text2DB(name));
            var dt = dba.ExecuteSelect();
            if (dt.Rows.Count != 1)
            {
                writer.WriteElementString("Error", "请确认您的登录口令及登录口令是否正确！");
                return false;
            }

            string code = dt.Rows[0][DBConst.C3010402] as string;
            dba.ReInit();
            dba.AddTable(DBConst.APWD0000);
            dba.AddColumn(DBConst.APWD0002);
            dba.AddColumn(DBConst.APWD0003);
            dba.AddWhere(DBConst.APWD0001, code);
            dba.AddSort(DBConst.APWD0002, true);
            dt = dba.ExecuteSelect();
            if (dt.Rows.Count != 4)
            {
                writer.WriteElementString("Error", "系统异常，请与管理员联系：admin@amon.me！");
                return false;
            }

            string data = dt.Rows[0][DBConst.APWD0003] as string;
            if (string.IsNullOrEmpty(data))
            {
                writer.WriteElementString("Error", "系统异常，请与管理员联系：admin@amon.me！");
                return false;
            }
            byte[] b = Convert.FromBase64String(data);
            string info = dt.Rows[0][DBConst.APWD0003] as string;
            string main = dt.Rows[0][DBConst.APWD0003] as string;
            string safe = dt.Rows[0][DBConst.APWD0003] as string;

            // 已有口令校验
            if (info != Digest(name, oldPass, b))
            {
                writer.WriteElementString("Error", "请确认您的登录口令及登录口令是否正确！");
                return false;
            }

            // 口令
            byte[] k = GenK(name, code, oldPass);
            // 向量
            byte[] v = GenV(name, code, oldPass);
            byte[] t = Convert.FromBase64String(main);
            #region AES 加密
            AesManaged aes1 = new AesManaged();
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes1.CreateDecryptor(k, v), CryptoStreamMode.Write))
                {
                    cStream.Write(t, 0, t.Length);
                    cStream.FlushFinalBlock();
                    t = mStream.ToArray();
                }
            }
            aes1.Clear();
            #endregion

            new Random().NextBytes(b);
            // 口令
            k = GenK(name, code, newPass);
            // 向量
            v = GenV(name, code, newPass);

            #region AES 加密
            AesManaged aes2 = new AesManaged();
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes2.CreateEncryptor(k, v), CryptoStreamMode.Write))
                {
                    cStream.Write(t, 0, t.Length);
                    cStream.FlushFinalBlock();
                    t = mStream.ToArray();
                }
            }
            aes1.Clear();
            #endregion

            // 摘要用户登录信息
            info = Digest(name, newPass, b);
            data = Convert.ToBase64String(b);
            main = Convert.ToBase64String(t);

            dba.ReInit();
            dba.AddTable(DBConst.APWD0000);
            dba.AddWhere(DBConst.APWD0001, code);
            dba.AddDeleteBatch();

            dba.ReInit();
            dba.AddTable(DBConst.APWD0000);
            dba.AddParam(DBConst.APWD0001, code);
            dba.AddParam(DBConst.APWD0002, "Data");
            dba.AddParam(DBConst.APWD0003, data);
            dba.AddInsertBatch();

            dba.ReInit();
            dba.AddTable(DBConst.APWD0000);
            dba.AddParam(DBConst.APWD0001, code);
            dba.AddParam(DBConst.APWD0002, "Info");
            dba.AddParam(DBConst.APWD0003, info);
            dba.AddInsertBatch();

            dba.ReInit();
            dba.AddTable(DBConst.APWD0000);
            dba.AddParam(DBConst.APWD0001, code);
            dba.AddParam(DBConst.APWD0002, "Main");
            dba.AddParam(DBConst.APWD0003, main);
            dba.AddInsertBatch();

            dba.ReInit();
            dba.AddTable(DBConst.APWD0000);
            dba.AddParam(DBConst.APWD0001, code);
            dba.AddParam(DBConst.APWD0002, "Safe");
            dba.AddParam(DBConst.APWD0003, safe);
            dba.AddInsertBatch();

            dba.ExecuteBatch();

            writer.WriteElementString("Code", code);
            writer.WriteElementString("Data", data);
            writer.WriteElementString("Info", info);
            writer.WriteElementString("Main", main);
            writer.WriteElementString("Safe", safe);
            return true;
        }
        #endregion

        #region 数据安全
        public string Digest(string name, string pass, byte[] data)
        {
            byte[] s = Encoding.UTF8.GetBytes(name + '%' + pass + "@Amon");
            byte[] t = new byte[data.Length + s.Length];
            Array.Copy(data, t, data.Length);
            Array.Copy(s, 0, t, data.Length, s.Length);

            return Convert.ToBase64String(Digest(t));
        }

        public byte[] Digest(byte[] data)
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

        public string Decode(string data)
        {
            AesManaged aes = new AesManaged();

            byte[] buf = CharUtil.DecodeString(data, _Mask);
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

        public string Encode(string data)
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
    }
}

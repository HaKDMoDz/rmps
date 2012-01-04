using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Controls;
using Me.Amon.Apwd.Model;
using Me.Amon.Apwd.Model.Atts;
using Me.Amon.Apwd.Utils;

namespace Me.Amon.Apwd.Comn
{
    public sealed class UserMdl
    {
        private string _Name;
        private string _Pass;
        private string _Code;
        private byte[] keys;
        private byte[] salt;
        private char[] mask;
        private ObservableCollection<Att> _AttList;
        private int _AttIndx;
        private bool _Edit;

        #region 构造函数
        public UserMdl()
        {
            _AttList = new ObservableCollection<Att>();
        }
        #endregion

        public string Name { get { return _Name; } }
        public string Code { get { return _Code; } }

        #region 权限认证
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public bool signIn(string name, string pass, string code)
        {
            return Verify(name, pass, code);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool signPb()
        {
            return true;
        }

        /// <summary>
        /// 网络登录
        /// </summary>
        /// <returns></returns>
        public bool signNw()
        {
            return true;
        }

        /// <summary>
        /// 修改登录口令
        /// </summary>
        /// <param name="oldPwds"></param>
        /// <param name="newPwds"></param>
        /// <returns></returns>
        public bool signPk(string oldPwds, string newPwds)
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
        public bool signFp(string usrName, StringBuilder secPwds)
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
        public bool signSk(string oldPwds, string secPwds)
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
        public bool signUp(string name, string pass, string code)
        {
            return Verify(name, pass, code);
        }

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
            byte[] key = new MD5Managed().ComputeHash(temp);
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
            return true;
        }
        #endregion

        #region 与服务器交互
        private void WebRequest(string uri, DownloadStringCompletedEventHandler handler)
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += handler;
            client.DownloadStringAsync(new Uri(uri));
        }
        #endregion

        #region 属性处理
        public int Count { get { return _AttList.Count; } }

        public void Clear()
        {
            _AttList.Clear();
        }

        /// <summary>
        /// 是否更新
        /// </summary>
        public bool IsUpdate { get { return _Edit; } }

        private DataGrid AttGrid;
        /// <summary>
        /// 头部初始化
        /// </summary>
        /// <param name="grid"></param>
        public void InitHead(DataGrid grid)
        {
            AttGrid = grid;

            _AttList.Clear();
            InitGuid();
            AttGrid.ItemsSource = _AttList;
        }

        /// <summary>
        /// 体部初始化
        /// </summary>
        /// <param name="grid"></param>
        public void InitBody(List<LibDetail> list)
        {
            InitMeta();
            InitLogo();
            InitHint();

            int order = 1;
            foreach (LibDetail detail in list)
            {
                Att att = Att.GetInstance(detail.Type, detail.Name, detail.Data);
                att.Order = (order++).ToString();
                _AttList.Add(att);
            }

            AttGrid.ItemsSource = _AttList;
            AttGrid.SelectedIndex += 1;
        }

        public void ReBind(DataGrid grid, int step)
        {
            int idx = grid.SelectedIndex + step;
            if (idx < 0)
            {
                idx = 0;
            }
            else if (idx >= _AttList.Count)
            {
                idx = _AttList.Count - 1;
            }

            grid.ItemsSource = null;
            grid.ItemsSource = _AttList;

            AttGrid.SelectedIndex = idx;

            grid.UpdateLayout();
            grid.ScrollIntoView(AttGrid.SelectedItem, AttGrid.Columns[0]);
        }

        #region 固定属性
        /// <summary>
        /// 向导初始化
        /// </summary>
        /// <returns></returns>
        private Att InitGuid()
        {
            GuidAtt guid = new GuidAtt();
            guid.Name = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _AttList.Add(guid);
            return guid;
        }

        /// <summary>
        /// 关键搜索
        /// </summary>
        /// <returns></returns>
        private Att InitMeta()
        {
            MetaAtt meta = new MetaAtt();
            _AttList.Add(meta);
            return meta;
        }

        /// <summary>
        /// 徽标
        /// </summary>
        /// <returns></returns>
        private Att InitLogo()
        {
            LogoAtt logo = new LogoAtt();
            _AttList.Add(logo);
            return logo;
        }

        /// <summary>
        /// 过时提醒
        /// </summary>
        /// <returns></returns>
        private Att InitHint()
        {
            HintAtt hint = new HintAtt();
            _AttList.Add(hint);
            return hint;
        }
        #endregion

        public Att GetPrevAtt()
        {
            _AttIndx -= 1;
            if (_AttIndx < 0)
            {
                _AttIndx = 0;
            }
            return _AttList[_AttIndx];
        }

        public Att GetNextAtt()
        {
            _AttIndx += 1;
            if (_AttIndx >= _AttList.Count)
            {
                _AttIndx = _AttList.Count - 1;
            }
            return _AttList[_AttIndx];
        }

        public Att GetAtt(int index)
        {
            if (index < 0)
            {
                index = 0;
            }
            else if (index >= _AttList.Count)
            {
                index = _AttList.Count - 1;
            }
            return _AttList[index];
        }
        #endregion

        #region 数据处理
        public void Decode(DataGrid grid, Key header)
        {
            // 查询数据是否为空
            string text = Decode(header.Password);
            if (text.Length < 1)
            {
                return;
            }

            _AttList.Clear();

            // Guid
            GuidAtt guid = new GuidAtt();
            guid.Data = header.CatId;
            guid.Name = header.RegDate;
            guid.SetSpec(GuidAtt.SPEC_GUID_TPLT, header.LibId);
            _AttList.Add(guid);

            // MetaItem
            MetaAtt meta = new MetaAtt();
            meta.Name = header.Title;
            meta.Data = header.MetaKey;
            _AttList.Add(meta);

            // LogoItem
            LogoAtt logo = new LogoAtt();
            logo.Name = header.IcoName;
            logo.Data = header.IcoMemo;
            logo.setPath(header.IcoPath);
            _AttList.Add(logo);

            // HintItem
            HintAtt hint = new HintAtt();
            hint.Data = header.GtdId;
            hint.Name = header.GtdMemo;
            hint.GtdHeader = header.GtdHeader;
            _AttList.Add(hint);

            // 处理每一个数据
            string[] arr = text.Split(Att.SP_SQL_EE);
            int o = 1;
            for (int i = 0, j = arr.Length - 1; i < j; i += 1)
            {
                string s = arr[i] + Att.SP_SQL_KV;
                int dn = s.IndexOf(Att.SP_SQL_KV);
                int dd = s.IndexOf(Att.SP_SQL_KV, dn + 1);
                int ds = s.IndexOf(Att.SP_SQL_KV, dd + 1);

                int type = int.Parse(s.Substring(0, dn));
                string name = s.Substring(dn + 1, dd - dn - 1);
                string data = s.Substring(dd + 1, ds - dd - 1);
                string spec = s.Substring(ds + 1);
                Att item = Att.GetInstance(type, name, data);
                item.Order = (o++).ToString();
                if (spec.Length > 0)
                {
                    item.DecodeSpec(spec, Att.SP_SQL_KV);
                }
                _AttList.Add(item);
            }

            grid.ItemsSource = _AttList;
            grid.SelectedIndex = 0;
        }

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

        public void Encode(DataGrid grid, Key header)
        {
            GuidAtt guid = (GuidAtt)_AttList[Att.PWDS_HEAD_GUID];
            header.CatId = guid.Data;
            header.RegDate = guid.Name;
            header.LibId = guid.GetSpec(GuidAtt.SPEC_GUID_TPLT);

            // MetaItem
            MetaAtt meta = (MetaAtt)_AttList[Att.PWDS_HEAD_META];
            header.Title = _Edit ? Att.SP_TPL_LS + meta.Name + '_' + header.RegDate + Att.SP_TPL_RS : meta.Name;
            header.MetaKey = meta.Data;

            // LogoItem
            LogoAtt logo = (LogoAtt)_AttList[Att.PWDS_HEAD_LOGO];
            header.IcoName = logo.Name;
            header.IcoMemo = logo.Data;
            header.IcoPath = logo.getPath();

            // HintItem
            HintAtt hint = (HintAtt)_AttList[Att.PWDS_HEAD_HINT];
            header.GtdId = hint.Data;
            header.GtdMemo = hint.Name;
            header.GtdHeader = hint.GtdHeader;

            // 字符串拼接
            StringBuilder buf = new StringBuilder();
            for (int i = Att.HEAD_SIZE, j = _AttList.Count; i < j; i += 1)
            {
                Att item = _AttList[i];
                buf.Append(item.Type);
                buf.Append(Att.SP_SQL_KV);
                buf.Append(item.Name);
                buf.Append(Att.SP_SQL_KV);
                buf.Append(item.Data);
                buf.Append(item.EncodeSpec(Att.SP_SQL_KV));
                buf.Append(Att.SP_SQL_EE);
            }

            header.Password = Encode(buf.ToString());

            _AttList.Clear();
            grid.ItemsSource = _AttList;
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
    }
}

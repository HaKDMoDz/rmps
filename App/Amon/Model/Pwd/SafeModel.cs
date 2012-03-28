using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Me.Amon.Bean;
using Me.Amon.Bean.Att;
using Me.Amon.Util;

namespace Me.Amon.Model.Pwd
{
    public sealed class SafeModel
    {
        private UserModel _UserModel;
        private ObservableCollection<AAtt> _AttList;

        #region 构造函数
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userModel"></param>
        public SafeModel(UserModel userModel)
        {
            _UserModel = userModel;
        }

        public void Init()
        {
            _AttList = new ObservableCollection<AAtt>();
        }
        #endregion

        #region 公共属性
        private Key _Key;
        public Key Key
        {
            get
            {
                return _Key;
            }
            set
            {
                _Key = value;
                Modified = false;
                _IsUpdate = _Key != null && CharUtil.IsValidateHash(_Key.Id);
            }
        }
        private bool _IsUpdate;
        public bool IsUpdate { get { return _IsUpdate; } }
        public bool Modified { get; set; }
        #endregion

        #region 属性信息
        /// <summary>
        /// 
        /// </summary>
        public GuidAtt Guid
        {
            get
            {
                return (GuidAtt)GetAtt(0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public MetaAtt Meta
        {
            get
            {
                return (MetaAtt)GetAtt(1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public LogoAtt Logo
        {
            get
            {
                return (LogoAtt)GetAtt(2);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public HintAtt Hint
        {
            get
            {
                return (HintAtt)GetAtt(3);
            }
        }

        private int _AttIndex;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AAtt GetPrevAtt()
        {
            _AttIndex -= 1;
            if (_AttIndex < 0)
            {
                _AttIndex = 0;
            }
            return _AttList[_AttIndex];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AAtt GetNextAtt()
        {
            _AttIndex += 1;
            if (_AttIndex >= _AttList.Count)
            {
                _AttIndex = _AttList.Count - 1;
            }
            return _AttList[_AttIndex];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public AAtt GetAtt(int index)
        {
            if (_AttList.Count > 0 && index > -1 && index < _AttList.Count)
            {
                return _AttList[index];
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count { get { return _AttList.Count; } }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            _AttList.Clear();
        }

        public void Append(AAtt att)
        {
        }

        public void Insert(int index, AAtt att)
        {
            _AttList.Insert(index, att);
        }

        public void Remove(AAtt att)
        {
            if (att.Type < AAtt.TYPE_GUID)
            {
                _AttList.Remove(att);
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= AAtt.HEAD_SIZE && index <= _AttList.Count)
            {
                _AttList.RemoveAt(index);
            }
        }
        #endregion

        #region 固定属性
        /// <summary>
        /// 向导初始化
        /// </summary>
        /// <returns></returns>
        public GuidAtt InitGuid()
        {
            GuidAtt guid = new GuidAtt { Order = "模板" };
            guid.Name = DateTime.Now.ToString(IEnv.DATEIME_FORMAT);
            _AttList.Add(guid);
            return guid;
        }

        /// <summary>
        /// 关键搜索
        /// </summary>
        /// <returns></returns>
        public MetaAtt InitMeta()
        {
            MetaAtt meta = new MetaAtt { Order = "搜索" };
            _AttList.Add(meta);
            return meta;
        }

        /// <summary>
        /// 徽标
        /// </summary>
        /// <returns></returns>
        public LogoAtt InitLogo()
        {
            LogoAtt logo = new LogoAtt { Order = "徽标" };
            _AttList.Add(logo);
            return logo;
        }

        /// <summary>
        /// 过时提醒
        /// </summary>
        /// <returns></returns>
        public HintAtt InitHint()
        {
            HintAtt hint = new HintAtt { Order = "提醒" };
            _AttList.Add(hint);
            return hint;
        }

        /// <summary>
        /// 口令数据
        /// </summary>
        /// <param name="index"></param>
        public bool InitData(Lib header)
        {
            for (int i = _AttList.Count - 1; i >= AAtt.HEAD_SIZE; i -= 1)
            {
                _AttList.RemoveAt(i);
            }

            int order = 1;
            foreach (LibDetail detail in header.Details)
            {
                AAtt att = AAtt.GetInstance(detail.Type, detail.Name, detail.Data);
                att.Order = (order++).ToString();
                _AttList.Add(att);
            }
            return true;
        }
        #endregion

        #region 数据处理
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void Decode()
        {
            _AttList.Clear();
            Decode(Key.Password, Key.CipherVer, _AttList);
        }

        public void Decode(string key, int sec, IList<AAtt> list)
        {
            // 查询数据是否为空
            if (string.IsNullOrEmpty(key))
            {
                return;
            }
            key = _UserModel.Decode(key, sec);

            // Guid
            GuidAtt guid = new GuidAtt();
            guid.Name = Key.RegTime;
            guid.Data = Key.CatId;
            guid.SetSpec(GuidAtt.SPEC_GUID_TPLT, Key.LibId);
            list.Add(guid);

            // MetaItem
            MetaAtt meta = new MetaAtt();
            meta.Name = Key.Title;
            meta.Data = Key.MetaKey;
            list.Add(meta);

            // LogoItem
            LogoAtt logo = new LogoAtt();
            logo.Name = Key.IcoName;
            logo.Data = Key.IcoMemo;
            logo.Path = Key.IcoPath;
            list.Add(logo);

            // HintItem
            HintAtt hint = new HintAtt();
            hint.Data = Key.GtdId;
            hint.Name = Key.GtdMemo;
            list.Add(hint);

            // 处理每一个数据
            string[] arr = key.Split(AAtt.SP_SQL_EE);
            int i = 0;
            int j = arr.Length - 1;
            while (i < j)
            {
                string[] tmp = arr[i].Split(AAtt.SP_SQL_KV);
                if (tmp.Length < 5)
                {
                    return;
                }

                if (!CharUtil.IsValidateLong(tmp[1]))
                {
                    return;
                }
                AAtt item = AAtt.GetInstance(int.Parse(tmp[1]), tmp[2], tmp[3]);
                item.Id = tmp[0];
                item.Order = (++i).ToString();
                item.DecodeSpec(tmp, 4);
                list.Add(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="header"></param>
        public void Encode()
        {
            GuidAtt guid = (GuidAtt)_AttList[AAtt.PWDS_HEAD_GUID];
            Key.RegTime = guid.Name;
            //Rec.CatId = guid.Data;
            Key.LibId = guid.GetSpec(GuidAtt.SPEC_GUID_TPLT);

            // MetaItem
            MetaAtt meta = (MetaAtt)_AttList[AAtt.PWDS_HEAD_META];
            //Rec.Title = Rec.IsUpdate ? AAtt.SP_TPL_LS + meta.Name + '_' + header.RegDate + Att.SP_TPL_RS : meta.Name;
            Key.Title = meta.Name;
            Key.MetaKey = meta.Data;

            // LogoItem
            LogoAtt logo = (LogoAtt)_AttList[AAtt.PWDS_HEAD_LOGO];
            Key.IcoName = logo.Name;
            Key.IcoMemo = logo.Data;
            Key.IcoPath = logo.Path;

            // HintItem
            HintAtt hint = (HintAtt)_AttList[AAtt.PWDS_HEAD_HINT];
            Key.GtdId = hint.Data;
            Key.GtdMemo = hint.Name;

            // 字符串拼接
            StringBuilder buf = new StringBuilder();
            for (int i = AAtt.HEAD_SIZE, j = _AttList.Count; i < j; i += 1)
            {
                AAtt item = _AttList[i];
                buf.Append(item.Id).Append(AAtt.SP_SQL_KV);
                buf.Append(item.Type).Append(AAtt.SP_SQL_KV);
                buf.Append(item.Name).Append(AAtt.SP_SQL_KV);
                buf.Append(item.Data).Append(AAtt.SP_SQL_KV);
                buf.Append(item.EncodeSpec(AAtt.SP_SQL_KV));
                buf.Append(AAtt.SP_SQL_EE);
            }

            // 加密版本
            Key.CipherVer = ISec.SEC_AES;

            Key.Password = _UserModel.EncodeKey(buf.ToString());

            _AttList.Clear();
        }
        #endregion

        #region 数据导入
        public bool ImportByTxt(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return false;
            }

            string[] list = data.Replace("\\;", "\b").Split(';');
            if (list == null || list.Length < AAtt.HEAD_SIZE)
            {
                return false;
            }

            Clear();
            Key = new Key();

            foreach (string tmp in list)
            {
                if (string.IsNullOrEmpty(tmp))
                {
                    continue;
                }

                string tmp1 = tmp.Replace("\b", "\\;").Trim();
                Match matche = Regex.Match(tmp1, "^\\d+:");
                if (!matche.Success)
                {
                    continue;
                }
                string tmp2 = matche.Value;
                AAtt item = AAtt.GetInstance(int.Parse(tmp2.Substring(0, tmp2.Length - 1)));
                if (item != null)
                {
                    if (item.ImportByTxt(tmp1.Substring(tmp2.Length)))
                    {
                        _AttList.Add(item);
                    }
                }
            }
            return true;
        }

        public bool ExportAsTxt(StringBuilder buffer)
        {
            if (buffer == null)
            {
                return false;
            }

            foreach (AAtt att in _AttList)
            {
                att.ExportAsTxt(buffer);
            }
            return true;
        }

        public bool ImportByXml(XmlReader reader)
        {
            if (reader == null)
            {
                return false;
            }

            if (!reader.ReadToDescendant("Att"))
            {
                return false;
            }

            Clear();
            _Key = new Key();

            if (reader.MoveToAttribute("Cat"))
            {
                Key.CatId = reader.ReadContentAsString();
            }

            do
            {
                if (!reader.ReadToDescendant("Type"))
                {
                    continue;
                }

                int type = reader.ReadElementContentAsInt();
                AAtt item = AAtt.GetInstance(type);
                if (item != null)
                {
                    if (item.ImportByXml(reader))
                    {
                        _AttList.Add(item);
                    }
                }
            } while (reader.ReadToFollowing("Att"));

            return true;
        }

        public bool ExportAsXml(XmlWriter writer)
        {
            if (writer == null)
            {
                return false;
            }

            writer.WriteStartElement("Rec");
            writer.WriteElementString("Cat", Key.CatId);
            foreach (AAtt att in _AttList)
            {
                writer.WriteStartElement("Att");
                att.ExportAsXml(writer);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            return true;
        }
        #endregion
    }
}

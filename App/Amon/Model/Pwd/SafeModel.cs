using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Me.Amon.Pwd;
using Me.Amon.Pwd._Att;
using Me.Amon.Util;

namespace Me.Amon.Model.Pwd
{
    public sealed class SafeModel
    {
        private UserModel _UserModel;
        private ObservableCollection<Att> _AttList;

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
            _AttList = new ObservableCollection<Att>();
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
        public Att GetPrevAtt()
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
        public Att GetNextAtt()
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
        public Att GetAtt(int index)
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

        public void Append(Att att)
        {
            att.Id = (_Key.AttIndex++).ToString();
            _AttList.Add(att);
        }

        public void Insert(int index, Att att)
        {
            att.Id = (_Key.AttIndex++).ToString();
            _AttList.Insert(index, att);
        }

        public void Remove(Att att)
        {
            if (att.Type < Att.TYPE_GUID)
            {
                _AttList.Remove(att);
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= Att.HEAD_SIZE && index <= _AttList.Count)
            {
                _AttList.RemoveAt(index);
            }
        }

        public void Change(int x, int y)
        {
            if (x == y || x < 0 || x >= _AttList.Count || y < 0 || y >= _AttList.Count)
            {
                return;
            }
            Att att = _AttList[x];
            _AttList[x] = _AttList[y];
            _AttList[y] = att;
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
            guid.Text = DateTime.Now.ToString(EApp.DATEIME_FORMAT);
            guid.Id = (_Key.AttIndex++).ToString();
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
            meta.Id = (_Key.AttIndex++).ToString();
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
            logo.Id = (_Key.AttIndex++).ToString();
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
            hint.Id = (_Key.AttIndex++).ToString();
            _AttList.Add(hint);
            return hint;
        }

        /// <summary>
        /// 口令数据
        /// </summary>
        /// <param name="index"></param>
        public bool InitData(Lib header)
        {
            for (int i = _AttList.Count - 1; i >= Att.HEAD_SIZE; i -= 1)
            {
                _AttList.RemoveAt(i);
            }

            int order = 1;
            foreach (LibDetail detail in header.Details)
            {
                Att att = Att.GetInstance(detail.Type, detail.Text, detail.Data);
                att.Id = (_Key.AttIndex++).ToString();
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
            Decode(_Key.Password, _Key.CipherVer, _AttList);
        }

        public void Decode(string key, int sec, IList<Att> list)
        {
            // 查询数据是否为空
            if (string.IsNullOrEmpty(key))
            {
                return;
            }
            key = _UserModel.Decode(key, sec);

            // Guid
            GuidAtt guid = new GuidAtt();
            guid.Text = _Key.RegTime;
            guid.Data = _Key.LibId;
            list.Add(guid);

            // MetaItem
            MetaAtt meta = new MetaAtt();
            meta.Text = _Key.Title;
            meta.Data = _Key.MetaKey;
            list.Add(meta);

            // LogoItem
            LogoAtt logo = new LogoAtt();
            logo.Text = _Key.IcoName;
            logo.Data = _Key.IcoMemo;
            logo.Path = _Key.IcoPath;
            list.Add(logo);

            // HintItem
            HintAtt hint = new HintAtt();
            hint.Text = _Key.GtdMemo;
            hint.Data = _Key.GtdId;
            list.Add(hint);

            // 处理每一个数据
            string[] arr = key.Split(Att.SP_SQL_EE);
            int i = 0;
            int j = arr.Length - 1;
            while (i < j)
            {
                string[] tmp = arr[i].Split(Att.SP_SQL_KV);
                if (tmp.Length < 5)
                {
                    return;
                }

                if (!CharUtil.IsValidateLong(tmp[1]))
                {
                    return;
                }
                Att item = Att.GetInstance(int.Parse(tmp[1]), tmp[3], tmp[4]);
                item.Id = tmp[0];
                item.Name = tmp[2];
                item.Order = (++i).ToString();
                item.DecodeSpec(tmp, 5);
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
            GuidAtt guid = (GuidAtt)_AttList[Att.PWDS_HEAD_GUID];
            _Key.RegTime = guid.Text;
            _Key.LibId = guid.Data;

            // MetaItem
            MetaAtt meta = (MetaAtt)_AttList[Att.PWDS_HEAD_META];
            //Rec.Title = Rec.IsUpdate ? AAtt.SP_TPL_LS + meta.Name + '_' + header.RegDate + Att.SP_TPL_RS : meta.Name;
            _Key.Title = meta.Text;
            _Key.MetaKey = meta.Data;

            // LogoItem
            LogoAtt logo = (LogoAtt)_AttList[Att.PWDS_HEAD_LOGO];
            _Key.IcoName = logo.Text;
            _Key.IcoMemo = logo.Data;
            _Key.IcoPath = logo.Path;

            // HintItem
            HintAtt hint = (HintAtt)_AttList[Att.PWDS_HEAD_HINT];
            _Key.GtdId = hint.Data;
            _Key.GtdMemo = hint.Text;

            // 字符串拼接
            StringBuilder buf = new StringBuilder();
            for (int i = Att.HEAD_SIZE, j = _AttList.Count; i < j; i += 1)
            {
                Att item = _AttList[i];
                buf.Append(item.Id).Append(Att.SP_SQL_KV);
                buf.Append(item.Type).Append(Att.SP_SQL_KV);
                buf.Append(item.Name).Append(Att.SP_SQL_KV);
                buf.Append(item.Text).Append(Att.SP_SQL_KV);
                buf.Append(item.Data).Append(Att.SP_SQL_KV);
                buf.Append(item.EncodeSpec(Att.SP_SQL_KV));
                buf.Append(Att.SP_SQL_EE);
            }

            // 加密版本
            _Key.CipherVer = EApp.SEC_AES;

            _Key.Password = _UserModel.EncodeKey(buf.ToString());

            _AttList.Clear();
        }
        #endregion

        #region 数据导入
        public bool ImportByTxt(string data, string ver)
        {
            if (string.IsNullOrEmpty(data))
            {
                return false;
            }

            string[] list = data.Replace("\\;", "\b").Split(';');
            if (list == null || list.Length < Att.HEAD_SIZE)
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
                Att item = Att.GetInstance(int.Parse(tmp2.Substring(0, tmp2.Length - 1)));
                if (item == null)
                {
                    return false;
                }
                if (item.ImportByTxt(tmp1.Substring(tmp2.Length), ver))
                {
                    item.Id = (_Key.AttIndex++).ToString();
                    _AttList.Add(item);
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

            foreach (Att att in _AttList)
            {
                att.ExportAsTxt(buffer);
            }
            return true;
        }

        public bool ImportByXml(XmlReader reader, string ver)
        {
            if (reader == null || !reader.ReadToDescendant("Att"))
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
                Att item = Att.GetInstance(type);
                if (item == null)
                {
                    return false;
                }

                if (item.ImportByXml(reader, ver))
                {
                    item.Id = (_Key.AttIndex++).ToString();
                    _AttList.Add(item);
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

            writer.WriteStartElement("Key");
            writer.WriteAttributeString("Cat", Key.CatId);
            foreach (Att att in _AttList)
            {
                writer.WriteStartElement("Att");
                att.ExportAsXml(writer);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            return true;
        }

        public bool ImportByOld(string data, string ver)
        {
            if (string.IsNullOrEmpty(data))
            {
                return false;
            }

            string[] list = data.Replace("\\;", "\b").Split(';');
            if (list == null || list.Length < Att.HEAD_SIZE)
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
                Match matche = Regex.Match(tmp1, "^\\d+,");
                if (!matche.Success)
                {
                    continue;
                }
                string tmp2 = matche.Value;
                int idx = int.Parse(tmp2.Substring(0, tmp2.Length - 1));
                if (idx == 6)
                {
                    idx = Att.TYPE_MEMO;
                }
                else if (idx > 6)
                {
                    idx += 1;
                }
                if (idx == Att.TYPE_DATE)
                {
                    idx = Att.TYPE_TEXT;
                }
                Att item = Att.GetInstance(idx);
                if (item == null)
                {
                    return false;
                }
                if (idx == Att.TYPE_HINT)
                {
                    _AttList.Add(item);
                    continue;
                }
                if (item.ImportByTxt(tmp1.Substring(tmp2.Length), ver))
                {
                    item.Id = (_Key.AttIndex++).ToString();
                    _AttList.Add(item);
                    continue;
                }
            }
            return true;
        }
        #endregion
    }
}

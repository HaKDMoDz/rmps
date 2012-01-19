using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Model.Att;

namespace Me.Amon.Model
{
    public sealed class SafeModel
    {
        private UserModel _UserModel;

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
        }
        #endregion

        #region 公共属性
        public Key Key { get; set; }
        #endregion

        #region 属性信息
        private ObservableCollection<AAtt> _AttList = new ObservableCollection<AAtt>();

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

        public void BindTo(DataGridView grid)
        {
            grid.DataSource = _AttList;
        }
        #endregion

        #region 固定属性
        /// <summary>
        /// 向导初始化
        /// </summary>
        /// <returns></returns>
        public AAtt InitGuid()
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
        public AAtt InitMeta()
        {
            MetaAtt meta = new MetaAtt { Order = "搜索" };
            _AttList.Add(meta);
            return meta;
        }

        /// <summary>
        /// 徽标
        /// </summary>
        /// <returns></returns>
        public AAtt InitLogo()
        {
            LogoAtt logo = new LogoAtt { Order = "徽标" };
            _AttList.Add(logo);
            return logo;
        }

        /// <summary>
        /// 过时提醒
        /// </summary>
        /// <returns></returns>
        public AAtt InitHint()
        {
            HintAtt hint = new HintAtt { Order = "提醒" };
            _AttList.Add(hint);
            return hint;
        }

        /// <summary>
        /// 口令数据
        /// </summary>
        /// <param name="index"></param>
        public bool InitData(LibHeader header)
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
        public void Decode(string key)
        {
            // 查询数据是否为空
            if (key.Length < 1)
            {
                return;
            }
            key = _UserModel.Decode(key);

            _AttList.Clear();

            // Guid
            GuidAtt guid = new GuidAtt();
            guid.Name = Key.RegDate;
            guid.Data = Key.CatId;
            guid.SetSpec(GuidAtt.SPEC_GUID_TPLT, Key.LibId);
            _AttList.Add(guid);

            // MetaItem
            MetaAtt meta = new MetaAtt();
            meta.Name = Key.Title;
            meta.Data = Key.MetaKey;
            _AttList.Add(meta);

            // LogoItem
            LogoAtt logo = new LogoAtt();
            logo.Name = Key.IcoName;
            logo.Data = Key.IcoMemo;
            logo.Path = Key.IcoPath;
            _AttList.Add(logo);

            // HintItem
            HintAtt hint = new HintAtt();
            hint.Data = Key.GtdId;
            hint.Name = Key.GtdMemo;
            hint.GtdHeader = Key.GtdHeader;
            _AttList.Add(hint);

            // 处理每一个数据
            string[] arr = key.Split(AAtt.SP_SQL_EE);
            int o = 1;
            for (int i = 0, j = arr.Length - 1; i < j; i += 1)
            {
                string s = arr[i] + AAtt.SP_SQL_KV;
                int dn = s.IndexOf(AAtt.SP_SQL_KV);
                int dd = s.IndexOf(AAtt.SP_SQL_KV, dn + 1);
                int ds = s.IndexOf(AAtt.SP_SQL_KV, dd + 1);

                int type = int.Parse(s.Substring(0, dn));
                string name = s.Substring(dn + 1, dd - dn - 1);
                string data = s.Substring(dd + 1, ds - dd - 1);
                string spec = s.Substring(ds + 1);
                AAtt item = AAtt.GetInstance(type, name, data);
                item.Order = (o++).ToString();
                if (spec.Length > 0)
                {
                    item.DecodeSpec(spec, AAtt.SP_SQL_KV);
                }
                _AttList.Add(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catId"></param>
        /// <param name="grid"></param>
        public void Encode(DataGrid grid)
        {
            Encode();
            grid.DataSource = _AttList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="header"></param>
        public void Encode()
        {
            GuidAtt guid = (GuidAtt)_AttList[AAtt.PWDS_HEAD_GUID];
            Key.RegDate = guid.Name;
            //Key.CatId = guid.Data;
            Key.LibId = guid.GetSpec(GuidAtt.SPEC_GUID_TPLT);

            // MetaItem
            MetaAtt meta = (MetaAtt)_AttList[AAtt.PWDS_HEAD_META];
            //Key.Title = Key.IsUpdate ? Att.SP_TPL_LS + meta.Name + '_' + header.RegDate + Att.SP_TPL_RS : meta.Name;
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
            Key.GtdHeader = hint.GtdHeader;

            // 字符串拼接
            StringBuilder buf = new StringBuilder();
            for (int i = AAtt.HEAD_SIZE, j = _AttList.Count; i < j; i += 1)
            {
                AAtt item = _AttList[i];
                buf.Append(item.Type);
                buf.Append(AAtt.SP_SQL_KV);
                buf.Append(item.Name);
                buf.Append(AAtt.SP_SQL_KV);
                buf.Append(item.Data);
                buf.Append(item.EncodeSpec(AAtt.SP_SQL_KV));
                buf.Append(AAtt.SP_SQL_EE);
            }

            // 加密版本
            Key.CipherVer = "1";

            Key.Password = _UserModel.Encode(buf.ToString());

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
            if (Key == null)
            {
                Key = new Key();
            }
            else
            {
                Key.SetDefault();
            }

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
            if (Key == null)
            {
                Key = new Key();
            }
            else
            {
                Key.SetDefault();
            }

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

            writer.WriteStartElement("Key");
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

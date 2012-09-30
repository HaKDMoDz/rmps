using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using Me.Amon.Apwd.Model.Atts;

namespace Me.Amon.Apwd.Model
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
        #endregion

        #region 公共属性
        /// <summary>
        /// 是否更新
        /// </summary>
        public Key Key { get; set; }
        #endregion

        #region 属性重写
        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            get
            {
                return _UserModel.Code;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                return _UserModel.Name;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<LibHeader> LibKey { get { return _UserModel.LibKey; } }
        #endregion

        #region 属性信息
        private ObservableCollection<Att> _AttList = new ObservableCollection<Att>();

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

        public void BindTo(DataGrid grid)
        {
            grid.ItemsSource = _AttList;
        }
        #endregion

        #region 固定属性
        /// <summary>
        /// 向导初始化
        /// </summary>
        /// <returns></returns>
        public Att InitGuid()
        {
            GuidAtt guid = new GuidAtt();
            guid.Name = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _AttList.Add(guid);
            return guid;
        }

        /// <summary>
        /// 头部初始化
        /// </summary>
        /// <param name="grid"></param>
        public void InitGuid(DataGrid grid)
        {
            InitGuid();
            grid.ItemsSource = _AttList;
        }

        /// <summary>
        /// 关键搜索
        /// </summary>
        /// <returns></returns>
        public Att InitMeta()
        {
            MetaAtt meta = new MetaAtt();
            _AttList.Add(meta);
            return meta;
        }

        /// <summary>
        /// 徽标
        /// </summary>
        /// <returns></returns>
        public Att InitLogo()
        {
            LogoAtt logo = new LogoAtt();
            _AttList.Add(logo);
            return logo;
        }

        /// <summary>
        /// 过时提醒
        /// </summary>
        /// <returns></returns>
        public Att InitHint()
        {
            HintAtt hint = new HintAtt();
            _AttList.Add(hint);
            return hint;
        }

        /// <summary>
        /// 口令数据
        /// </summary>
        /// <param name="index"></param>
        public bool InitData(LibHeader header)
        {
            for (int i = _AttList.Count - 1; i >= Att.HEAD_SIZE; i -= 1)
            {
                _AttList.RemoveAt(i);
            }

            int order = 1;
            foreach (LibDetail detail in header.Details)
            {
                Att att = Att.GetInstance(detail.Type, detail.Name, detail.Data);
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
        /// <param name="grid"></param>
        public void Decode(string key, DataGrid grid)
        {
            Decode(key);

            grid.ItemsSource = _AttList;
            grid.SelectedIndex = 0;
        }
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
            logo.setPath(Key.IcoPath);
            _AttList.Add(logo);

            // HintItem
            HintAtt hint = new HintAtt();
            hint.Data = Key.GtdId;
            hint.Name = Key.GtdMemo;
            hint.GtdHeader = Key.GtdHeader;
            _AttList.Add(hint);

            // 处理每一个数据
            string[] arr = key.Split(Att.SP_SQL_EE);
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catId"></param>
        /// <param name="grid"></param>
        public void Encode(DataGrid grid)
        {
            Encode();
            grid.ItemsSource = _AttList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="header"></param>
        public void Encode()
        {
            GuidAtt guid = (GuidAtt)_AttList[Att.PWDS_HEAD_GUID];
            Key.RegDate = guid.Name;
            //Key.CatId = guid.Data;
            Key.LibId = guid.GetSpec(GuidAtt.SPEC_GUID_TPLT);

            // MetaItem
            MetaAtt meta = (MetaAtt)_AttList[Att.PWDS_HEAD_META];
            //Key.Title = Key.IsUpdate ? Att.SP_TPL_LS + meta.Name + '_' + header.RegDate + Att.SP_TPL_RS : meta.Name;
            Key.Title = meta.Name;
            Key.MetaKey = meta.Data;

            // LogoItem
            LogoAtt logo = (LogoAtt)_AttList[Att.PWDS_HEAD_LOGO];
            Key.IcoName = logo.Name;
            Key.IcoMemo = logo.Data;
            Key.IcoPath = logo.getPath();

            // HintItem
            HintAtt hint = (HintAtt)_AttList[Att.PWDS_HEAD_HINT];
            Key.GtdId = hint.Data;
            Key.GtdMemo = hint.Name;
            Key.GtdHeader = hint.GtdHeader;

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

            // 加密版本
            Key.CipherVer = "1";

            Key.Password = _UserModel.Encode(buf.ToString());

            _AttList.Clear();
        }
        #endregion

        #region 列表模式
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="step"></param>
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

            grid.SelectedIndex = idx;

            grid.UpdateLayout();
            grid.ScrollIntoView(grid.SelectedItem, grid.Columns[0]);
        }
        #endregion

        #region 数据导入
        public void ImportByTxt(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return;
            }

            if (Key == null)
            {
                Key = new Key();
            }

            string[] list = data.Replace("\\;", "\b").Split(';');
            if (list == null || list.Length < Att.HEAD_SIZE)
            {
                return;
            }

            Clear();
            Key.SetDefault();

            foreach (string tmp in list)
            {
                if (string.IsNullOrEmpty(tmp))
                {
                    continue;
                }

                string tmp1 = tmp.Replace("\b", "\\;").Trim();
                Match matche = Regex.Match(tmp1, "^\\d+");
                if (!matche.Success)
                {
                    continue;
                }
                string tmp2 = matche.Value;
                Att item = Att.GetInstance(int.Parse(tmp2));
                if (item != null)
                {
                    item.ImportByTxt(tmp1.Substring(tmp2.Length + 1));
                    _AttList.Add(item);
                }
            }
        }
        #endregion
    }
}

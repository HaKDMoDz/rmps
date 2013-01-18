using System.Collections.Generic;
using System.IO;
using Me.Amon.Da;
using Me.Amon.Gtd;
using Me.Amon.Gtd.M;
using Me.Amon.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.M
{
    public sealed class DataModel : ADataModel
    {
        public DataModel(UserModel userModel)
        {
            _UserModel = userModel;
        }

        public new void Init()
        {
            base.Init();

            #region 数据目录
            _CatDir = Path.Combine(_UserModel.DatHome, "CAT");
            if (!Directory.Exists(_CatDir))
            {
                Directory.CreateDirectory(_CatDir);
            }
            _KeyDir = Path.Combine(_UserModel.DatHome, "KEY");
            if (!Directory.Exists(_KeyDir))
            {
                Directory.CreateDirectory(_KeyDir);
            }
            _AttDir = Path.Combine(_UserModel.DatHome, "ATT");
            if (!Directory.Exists(_AttDir))
            {
                Directory.CreateDirectory(_AttDir);
            }
            _AcfDir = Path.Combine(_UserModel.DatHome, "ACF");
            if (!Directory.Exists(_AcfDir))
            {
                Directory.CreateDirectory(_AcfDir);
            }
            #endregion

            _LibList = new List<Lib>();
            foreach (Lib lib in ListLib())
            {
                _LibList.Add(lib);
            }
            LibModified = 0x7FFFFFFF;
        }

        public void SaveMPwd(MPwd pwd)
        {
            _DbEngine.Save(pwd);
        }

        public MPwd ReadMPwd()
        {
            var list = _DbEngine.Query<MPwd>();
            return list.Count > 0 ? list[0] : new MPwd();
        }

        #region 数据目录
        private string _CatDir;
        public string CatDir { get { return _CatDir; } }

        private string _KeyDir;
        public string KeyDir { get { return _KeyDir; } }

        private string _AttDir;
        public string AttDir { get { return _AttDir; } }

        private string _AcfDir;
        public string AcfDir { get { return _AcfDir; } }
        #endregion

        #region 口令模板
        private IList<Lib> _LibList;
        public IList<Lib> LibList
        {
            get
            {
                return _LibList;
            }
        }
        public int LibModified { get; set; }
        #endregion

        #region 模板操作
        public IList<Lib> ListLib()
        {
            return _DbEngine.Query<Lib>(
                delegate(Lib header)
                {
                    return header.UserCode == _UserModel.Code;
                },
                delegate(Lib a, Lib b)
                {
                    return a.Order.CompareTo(b.Order);
                });
        }
        #endregion

        #region 记录操作
        public Key ReadKey(string keyId)
        {
            IList<Key> keys = _DbEngine.Query<Key>(delegate(Key key)
            {
                return key.Id == keyId;
            });

            return keys.Count > 0 ? keys[0] : null;
        }

        public IList<Key> FindKey(string keyMeta)
        {
            string[] arr = keyMeta.ToLower().Split(' ');

            IList<Key> recs = _DbEngine.Query<Key>(
                delegate(Key rec)
                {
                    if (rec.Operate == DBConst.OPT_DELETE)
                    {
                        return false;
                    }

                    bool a = string.IsNullOrEmpty(rec.Title) ? false : Contains(rec.Title.ToLower(), arr);
                    bool b = string.IsNullOrEmpty(rec.MetaKey) ? false : Contains(rec.MetaKey.ToLower(), arr);
                    return a || b;
                },
                delegate(Key a, Key b)
                {
                    return b.Order.CompareTo(a.Order);
                });
            return recs;
        }

        public IList<Key> ListKey(string catId)
        {
            IList<Key> keys = _DbEngine.Query<Key>(
                delegate(Key key)
                {
                    if (key.UserCode != _UserModel.Code)
                    {
                        return false;
                    }
                    if (key.Operate == DBConst.OPT_DELETE)
                    {
                        return false;
                    }

                    return key.CatId == catId;
                },
                delegate(Key a, Key b)
                {
                    return b.Order.CompareTo(a.Order);
                });
            return keys;
        }

        public IList<Key> FindKeyByLabel(int label)
        {
            IList<Key> keys = _DbEngine.Query<Key>(delegate(Key key)
            {
                return key.UserCode == _UserModel.Code && key.Label == label;
            });
            return keys;
        }

        public IList<Key> FindKeyByMajor(int major)
        {
            IList<Key> keys = _DbEngine.Query<Key>(delegate(Key key)
            {
                return key.UserCode == _UserModel.Code && key.Major == major;
            });
            return keys;
        }

        public IList<MGtd> FindGtdExpired()
        {
            IList<MGtd> gtds = _DbEngine.Query<MGtd>(
                delegate(MGtd gtd)
                {
                    if (gtd.UserCode != _UserModel.Code)
                    {
                        return false;
                    }
                    return gtd.Status == CGtd.STATUS_EXPIRED && CharUtil.IsValidateHash(gtd.RefId);
                });
            return gtds;
        }
        #endregion

        #region 日志操作
        public KeyLog ReadKeyLog(string logId)
        {
            IList<KeyLog> logs = _DbEngine.Query<KeyLog>(delegate(KeyLog log)
            {
                return log.Id == logId;
            });

            return logs.Count > 0 ? logs[0] : null;
        }

        public IList<KeyLog> ListKeyLog(string keyId)
        {
            IList<KeyLog> logs = _DbEngine.Query<KeyLog>(
                delegate(KeyLog log)
                {
                    return log.RefId == keyId;
                },
                delegate(KeyLog a, KeyLog b)
                {
                    return b.LogTime.CompareTo(a.LogTime);
                });
            return logs;
        }
        #endregion

        #region 目录操作
        public IList<Dir> ListDir()
        {
            return _DbEngine.Query<Dir>();
        }
        #endregion
    }
}

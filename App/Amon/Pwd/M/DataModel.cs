using System;
using System.Collections.Generic;
using System.IO;
using Me.Amon.Da;
using Me.Amon.Da.Db;
using Me.Amon.Gtd;
using Me.Amon.Gtd.M;
using Me.Amon.M;
using Me.Amon.Util;

namespace Me.Amon.Pwd.M
{
    public sealed class DataModel
    {
        private UserModel _UserModel;
        private ODBEngine _DbEngine;

        public DataModel(UserModel userModel)
        {
            _UserModel = userModel;
        }

        public void Init()
        {
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
            foreach (Lib lib in _UserModel.DBA.ListLib())
            {
                _LibList.Add(lib);
            }
            LibModified = 0x7FFFFFFF;
        }

        public void SaveVcs(Vcs vcs)
        {
            if (vcs.Operate == DBConst.OPT_DEFAULT)
            {
                vcs.Version += 1;
            }

            if (vcs.Operate > DBConst.OPT_INSERT)
            {
                vcs.Operate += 1;
            }

            vcs.UserCode = _UserModel.Code;
            vcs.UpdateTime = DateTime.Now;
            if (!CharUtil.IsValidateHash(vcs.Id))
            {
                vcs.Id = HashUtil.UtcTimeInEnc(false);
                vcs.CreateTime = vcs.UpdateTime;
            }
            _DbEngine.Store(vcs);
        }

        public void SaveLog(Log log)
        {
            log.Id = HashUtil.UtcTimeInEnc(false);
            log.LogTime = DateTime.Now;
            _DbEngine.Store(log);
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

        public Key ReadKey(string keyId)
        {
            IList<Key> keys = _DbEngine.Query<Key>(delegate(Key key)
            {
                return key.Id == keyId;
            });

            return keys.Count > 0 ? keys[0] : null;
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

        public IList<MGtd> ListGtdWithRef()
        {
            IList<MGtd> gtds = _DbEngine.Query<MGtd>(
                delegate(MGtd gtd)
                {
                    if (gtd.UserCode != _UserModel.Code)
                    {
                        return false;
                    }
                    return gtd.Status > CGtd.STATUS_SUSPEND && CharUtil.IsValidateHash(gtd.RefId);
                });
            return gtds;
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

        public IList<Cat> ListCat(string appId, string parentId)
        {
            if (string.IsNullOrWhiteSpace(parentId))
            {
                return _DbEngine.Query<Cat>();
            }

            return _DbEngine.Query<Cat>(
                delegate(Cat cat)
                {
                    return cat.AppId == appId && cat.Parent == parentId;
                },
                delegate(Cat a, Cat b)
                {
                    return a.Order.CompareTo(b.Order);
                });
        }

        public UdcModel UdcModel { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Me.Amon.Model;
using Me.Amon.Pwd;
using Me.Amon.Ren;
using Me.Amon.Util;

namespace Me.Amon.Da
{
    public class DBObject : DBA
    {
        private string _DbPath;
        private IObjectContainer _Container;
        private UserModel _UserModel;

        #region 构造函数
        public DBObject()
        {
        }

        public void Init(UserModel userModel)
        {
            _UserModel = userModel;
            _DbPath = Path.Combine(userModel.Home, IEnv.FILE_DB);
        }
        #endregion

        #region 连接管理
        private IObjectContainer Container
        {
            get
            {
                if (_Container == null)
                {
                    IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();
                    config.Common.ObjectClass(typeof(Cat)).ObjectField("Id").Indexed(true);
                    config.Common.ObjectClass(typeof(Key)).ObjectField("Title").Indexed(true);
                    config.Common.ObjectClass(typeof(Key)).ObjectField("MetaKey").Indexed(true);
                    config.Common.ObjectClass(typeof(Lib)).CascadeOnUpdate(true);
                    _Container = Db4oEmbedded.OpenFile(config, _DbPath);
                }
                return _Container;
            }
        }

        public void CloseConnect()
        {
            if (_Container != null)
            {
                _Container.Close();
                _Container = null;
            }
        }
        #endregion

        #region 私有函数
        private bool Contains(string src, string[] arr)
        {
            foreach (string tmp in arr)
            {
                if (!src.Contains(tmp))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region 数据更新
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
                vcs.Id = HashUtil.UtcTimeInHex(false);
                vcs.CreateTime = vcs.UpdateTime;
            }
            Container.Store(vcs);
        }

        public void SaveLog(Log log)
        {
            log.Id = HashUtil.UtcTimeInHex(false);
            log.LogTime = DateTime.Now;
            Container.Store(log);
        }
        #endregion

        #region 数据删除
        public void RemoveVcs(Vcs vcs)
        {
            vcs.Operate = DBConst.OPT_DELETE;
            vcs.Version += 1;
            Container.Store(vcs);
        }

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="vcs"></param>
        public void DeleteVcs(Vcs vcs)
        {
            Container.Delete(vcs);
        }

        public void DeleteLog(Log log)
        {
            Container.Delete(log);
        }
        #endregion

        #region 类别操作
        public Cat ReadCat(string catId)
        {
            IList<Cat> cats = Container.Query<Cat>(delegate(Cat cat)
            {
                return cat.Id == catId;
            });

            return cats.Count > 0 ? cats[0] : null;
        }

        public IList<Cat> FindCat(string catMeta)
        {
            if (string.IsNullOrEmpty(catMeta))
            {
                return null;
            }
            string[] arr = catMeta.ToLower().Split(' ', ',', ';');
            IList<Cat> cats = Container.Query<Cat>(
                delegate(Cat cat)
                {
                    return Contains(cat.Meta.ToLower(), arr);
                },
                delegate(Cat a, Cat b)
                {
                    return a.Order.CompareTo(b.Order);
                });
            return cats;
        }

        public IList<Cat> ListCat(string parentId)
        {
            IList<Cat> cats = Container.Query<Cat>(
                delegate(Cat cat)
                {
                    return cat.Parent == parentId;
                },
                delegate(Cat a, Cat b)
                {
                    return a.Order.CompareTo(b.Order);
                });
            return cats;
        }
        #endregion

        #region 记录操作
        public Key ReadKey(string keyId)
        {
            IList<Key> keys = Container.Query<Key>(delegate(Key key)
            {
                return key.Id == keyId;
            });

            return keys.Count > 0 ? keys[0] : null;
        }

        public IList<Key> FindKey(string keyMeta)
        {
            string[] arr = keyMeta.ToLower().Split(' ');

            IList<Key> recs = Container.Query<Key>(
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
            IList<Key> keys = Container.Query<Key>(
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
            IList<Key> keys = Container.Query<Key>(delegate(Key key)
            {
                return key.UserCode == _UserModel.Code && key.Label == label;
            });
            return keys;
        }

        public IList<Key> FindKeyByMajor(int major)
        {
            IList<Key> keys = Container.Query<Key>(delegate(Key key)
            {
                return key.UserCode == _UserModel.Code && key.Major == major;
            });
            return keys;
        }
        #endregion

        #region 日志操作
        public KeyLog ReadKeyLog(string logId)
        {
            IList<KeyLog> logs = Container.Query<KeyLog>(delegate(KeyLog log)
            {
                return log.Id == logId;
            });

            return logs.Count > 0 ? logs[0] : null;
        }

        public IList<KeyLog> ListKeyLog(string keyId)
        {
            IList<KeyLog> logs = Container.Query<KeyLog>(
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

        #region 模板操作
        public IList<Lib> ListLib()
        {
            return Container.Query<Lib>(
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

        #region 字符操作
        public IList<Udc> ListUdc()
        {
            return Container.Query<Udc>();
        }
        #endregion

        #region 目录操作
        public IList<Dir> ListDir()
        {
            return Container.Query<Dir>();
        }
        #endregion

        public IList<MRen> ListRen()
        {
            return Container.Query<MRen>(delegate(MRen ren)
                {
                    return ren.UserCode == _UserModel.Code;
                },
                delegate(MRen a, MRen b)
                {
                    return a.Order.CompareTo(b.Order);
                });
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Me.Amon.Gtd;
using Me.Amon.Gtd.M;
using Me.Amon.M;
using Me.Amon.Pwd.M;
using Me.Amon.Util;

namespace Me.Amon.Da.Db
{
    public class ODBEngine : DBA
    {
        private string _DbPath;
        private IObjectContainer _Container;
        private AUserModel _UserModel;
        private Dbv _DbVersion;

        #region 构造函数
        public ODBEngine()
        {
        }
        #endregion

        #region 连接管理
        public void DbInit(AUserModel userModel)
        {
            _UserModel = userModel;
            _DbPath = Path.Combine(userModel.DatHome, CApp.FILE_DB);

            IList<Dbv> dbvs = Container.Query<Dbv>();
            if (dbvs.Count > 0)
            {
                _DbVersion = dbvs[0];
            }
            else
            {
                _DbVersion = new Dbv { Version = 2 };
                _Container.Store(_DbVersion);
            }
        }

        public void Upgrade()
        {
            CloseConnect();

            string oldDb = _DbPath + ".old";
            File.Move(_DbPath, oldDb);
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();
            config.Common.ObjectClass(typeof(Me.Amon.M.Vcs)).CascadeOnActivate(true);
            config.Common.ObjectClass(typeof(Me.Amon.M.Log)).CascadeOnActivate(true);
            config.Common.AddAlias(new ODBUpgradeConfig());
            IObjectContainer oldContainer = Db4oEmbedded.OpenFile(config, oldDb);
            IObjectContainer newContainer = Container;
            IList<Key> logs = oldContainer.Query<Key>();
            foreach (var log in logs)
            {
                newContainer.Store(log);
            }

            oldContainer.Close();
        }

        public bool Suspended { get; private set; }

        public void Suspend()
        {
            CloseConnect();
            Suspended = true;
        }

        public void Resume()
        {
            Suspended = false;
        }

        public void CloseConnect()
        {
            if (_Container != null)
            {
                _Container.Close();
                _Container = null;
            }
        }

        /// <summary>
        /// 读取数据版本
        /// </summary>
        /// <returns></returns>
        public Dbv DbVersion
        {
            get
            {
                return _DbVersion;
            }
        }

        private IObjectContainer Container
        {
            get
            {
                if (_Container == null && !Suspended)
                {
                    IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();
                    config.Common.ObjectClass(typeof(Cat)).ObjectField("Id").Indexed(true);
                    config.Common.ObjectClass(typeof(Key)).ObjectField("Title").Indexed(true);
                    config.Common.ObjectClass(typeof(Key)).ObjectField("MetaKey").Indexed(true);
                    config.Common.ObjectClass(typeof(Lib)).CascadeOnUpdate(true);
                    config.Common.ObjectClass(typeof(MGtd)).CascadeOnUpdate(true);
                    _Container = Db4oEmbedded.OpenFile(config, _DbPath);
                }
                return _Container;
            }
        }
        #endregion

        public IList<T> Query<T>()
        {
            return Container.Query<T>();
        }

        public IList<T> Query<T>(Predicate<T> match, Comparison<T> comparison)
        {
            return Container.Query<T>(match, comparison);
        }

        public IList<T> Query<T>(Predicate<T> match)
        {
            return Container.Query<T>(match);
        }

        public void Store(object obj)
        {
            Container.Store(obj);
        }

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
            throw new Exception("TODO");
        }

        public void SaveLog(Log log)
        {
            throw new Exception("TODO");
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

        public IList<Cat> FindCat(string appId, string catMeta)
        {
            if (string.IsNullOrEmpty(catMeta))
            {
                return null;
            }
            string[] arr = catMeta.ToLower().Split(' ', ',', ';');
            IList<Cat> cats = Container.Query<Cat>(
                delegate(Cat cat)
                {
                    return cat.AppId == appId && Contains(cat.Meta.ToLower(), arr);
                },
                delegate(Cat a, Cat b)
                {
                    return a.Order.CompareTo(b.Order);
                });
            return cats;
        }

        public IList<Cat> ListCat(string appId, string parentId)
        {
            if (string.IsNullOrWhiteSpace(parentId))
            {
                return Container.Query<Cat>();
            }

            return Container.Query<Cat>(
                delegate(Cat cat)
                {
                    return cat.AppId == appId && cat.Parent == parentId;
                },
                delegate(Cat a, Cat b)
                {
                    return a.Order.CompareTo(b.Order);
                });
        }
        #endregion

        #region 记录操作
        public Key ReadKey(string keyId)
        {
            throw new Exception("TODO");
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
            throw new Exception("TODO");
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

        public IList<MGtd> ListGtdWithRef()
        {
            throw new Exception("TODO");
        }

        public IList<MGtd> FindKeyByGtdExpired()
        {
            throw new Exception("TODO");
        }
    }
}

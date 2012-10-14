using System;
using System.Collections.Generic;
using System.IO;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Me.Amon.Gtd.M;
using Me.Amon.M;
using Me.Amon.Pwd.M;

namespace Me.Amon.Da.Db
{
    public class ODBEngine : DBA
    {
        private string _DbPath;
        private AUserModel _UserModel;
        private IObjectContainer _Container;

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
                DbVersion = dbvs[0];
            }
            else
            {
                DbVersion = new Dbv { Version = 2 };
                _Container.Store(DbVersion);
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

        /// <summary>
        /// 读取数据版本
        /// </summary>
        /// <returns></returns>
        public Dbv DbVersion { get; private set; }

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
        #endregion

        #region 数据操作
        public void Store(object obj)
        {
            Container.Store(obj);
        }

        public void Delete(object obj)
        {
            Container.Delete(obj);
        }

        public IList<T> Query<T>()
        {
            return Container.Query<T>();
        }

        public IList<T> Query<T>(Predicate<T> match)
        {
            return Container.Query<T>(match);
        }

        public IList<T> Query<T>(Predicate<T> match, Comparison<T> comparison)
        {
            return Container.Query<T>(match, comparison);
        }
        #endregion
    }
}

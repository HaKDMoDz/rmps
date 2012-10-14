using System;
using System.Collections.Generic;
using Me.Amon.M;

namespace Me.Amon.Da
{
    public interface DBA
    {
        /// <summary>
        /// 读取数据版本
        /// </summary>
        /// <returns></returns>
        Dbv DbVersion { get; }

        void DbInit(AUserModel userModel);

        void Upgrade();

        bool Suspended { get; }

        void Suspend();

        void Resume();

        void CloseConnect();

        void Store(object obj);

        void Delete(object obj);

        IList<T> Query<T>();

        IList<T> Query<T>(Predicate<T> match);

        IList<T> Query<T>(Predicate<T> match, Comparison<T> comparison);
    }
}

using System.Collections.Generic;
using Me.Amon.M;

namespace Me.Amon.Da
{
    public interface DBA
    {
        void CloseConnect();

        /// <summary>
        /// 读取数据版本
        /// </summary>
        /// <returns></returns>
        Dbv DbVersion { get; }

        #region 数据更新
        /// <summary>
        /// 存储数据
        /// </summary>
        /// <param name="vcs"></param>
        void SaveVcs(Vcs vcs);

        /// <summary>
        /// 存储日志
        /// </summary>
        /// <param name="log"></param>
        void SaveLog(Log log);
        #endregion

        #region 数据删除
        /// <summary>
        /// 逻辑移除
        /// </summary>
        /// <param name="vcs"></param>
        void RemoveVcs(Vcs vcs);

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="vcs"></param>
        void DeleteVcs(Vcs vcs);

        void DeleteLog(Log log);
        #endregion
    }
}

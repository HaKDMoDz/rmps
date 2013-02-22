using System.Data;
using Me.Amon.Da.Db;

namespace Me.Amon.Bean
{
    public class GtdDetail : Vcs
    {
        public int P30F0401 { get; set; }
        /// <summary>
        /// 计划索引
        /// </summary>
        public string P30F0402 { get; set; }
        /// <summary>
        /// 指定时间
        /// </summary>
        public long P30F0403 { get; set; }
        /// <summary>
        /// 间隔单位
        /// </summary>
        public int P30F0404 { get; set; }
        /// <summary>
        /// 间隔时间
        /// </summary>
        public int P30F0405 { get; set; }
        /// <summary>
        /// 表达式
        /// </summary>
        public string P30F0406 { get; set; }

        #region 接口实现
        public override bool Load(DataRow row)
        {
            return true;
        }

        public override bool Read(DBAccess dba, string Id)
        {
            return true;
        }

        public override bool Save(DBAccess dba, bool update)
        {
            return true;
        }
        #endregion
    }
}

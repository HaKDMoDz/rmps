using System;
using Me.Amon.Model;

namespace Me.Amon.Gtd
{
    /// <summary>
    /// 数据模型
    /// </summary>
    public class MGtd : Vcs
    {
        #region 基本信息
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 显示排序
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// 任务类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 任务级别
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// 任务状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 完成度
        /// </summary>
        public int Percent { get; set; }
        /// <summary>
        /// 相关说明
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region 提醒方式
        /// <summary>
        /// 提示方式
        /// </summary>
        public int HintType { get; set; }
        /// <summary>
        /// 执行参数
        /// </summary>
        public string Command { get; set; }
        /// <summary>
        /// 附加参数
        /// </summary>
        public string Params { get; set; }
        #endregion

        #region 高级特性
        /// <summary>
        /// 可否共用
        /// </summary>
        public bool Shared { get; set; }
        /// <summary>
        /// 上级任务
        /// </summary>
        public string SupGtd { get; set; }
        /// <summary>
        /// 前置任务
        /// </summary>
        public string PreGtd { get; set; }
        #endregion

        #region 对外接口
        /// <summary>
        /// 相关引用
        /// </summary>
        public string RefId { get; set; }
        #endregion

        public MGtdDates Dates { get; set; }
        public MGtdEvent Event { get; set; }
        public MGtdMaths Maths { get; set; }

        public MGtd()
        {
        }

        public void Init()
        {
            if (Type == CGtd.TYPE_MAJOR_POINT)
            {
                if (Dates != null)
                {
                    Dates.Init();
                }
                return;
            }
            if (Type == CGtd.TYPE_MAJOR_EVENT)
            {
                if (Event != null)
                {
                    Event.Init();
                }
                return;
            }
            if (Type == CGtd.TYPE_MAJOR_MATHS)
            {
                if (Maths != null)
                {
                    Maths.Init();
                }
                return;
            }
        }

        public virtual bool Test(DateTime time, int length)
        {
            if (Status == CGtd.GTD_STAT_EXPIRED)
            {
                return false;
            }

            if (Type == CGtd.TYPE_MAJOR_POINT)
            {
                return Dates == null || Dates.Test(time, length);
            }
            if (Type == CGtd.TYPE_MAJOR_EVENT)
            {
                return Event == null || Event.Test();
            }
            if (Type == CGtd.TYPE_MAJOR_MATHS)
            {
                return Maths == null || Maths.Test();
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using Me.Amon.M;

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
        /// 起始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 相关说明
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region 重复控制
        /// <summary>
        /// 重复方式
        /// </summary>
        public int EndType { get; set; }
        /// <summary>
        /// 执行次数
        /// </summary>
        public int ExeCount { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 上次时间
        /// </summary>
        public DateTime LastTime { get; set; }
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
        /// <summary>
        /// 相关引用
        /// </summary>
        public string RefId { get; set; }
        #endregion

        public MGtd()
        {
            Dates = new List<ADates>();

            Events = new List<int>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <param name="length"></param>
        /// <returns>状态是否发生改变：true是，false否</returns>
        public bool Test(DateTime time, int length)
        {
            if (Status == CGtd.GTD_STAT_EXPIRED)
            {
                return false;
            }

            if (Type == CGtd.TYPE_MAJOR_DATES)
            {
                return TestDates(time, length);
            }
            if (Type == CGtd.TYPE_MAJOR_EVENT)
            {
                return TestEvent();
            }
            if (Type == CGtd.TYPE_MAJOR_MATHS)
            {
                return TestMaths(time);
            }
            return false;
        }

        #region 时间型
        /// <summary>
        /// 下次时间
        /// </summary>
        public DateTime NextTime { get; set; }
        /// <summary>
        /// 是否提前
        /// </summary>
        public int PrePose { get; set; }
        /// <summary>
        /// 提前间隔
        /// </summary>
        public int PreTime { get; set; }
        /// <summary>
        /// 数值列表
        /// </summary>
        public List<ADates> Dates { get; private set; }

        public bool TestDates(DateTime time, int length)
        {
            // 计算下次提醒时间
            //if (NextTime == DateTime.MinValue)
            if (NextTime < StartTime)
            {
                NextTime = StartTime;
            }
            else if (Status == CGtd.GTD_STAT_NORMAL && NextTime < time)
            {
                bool changed = false;
                foreach (ADates date in Dates)
                {
                    NextTime = date.Next(NextTime, out changed);
                    if (!changed)
                    {
                        break;
                    }
                }

                // 完成
                if ((EndType == CGtd.END_TYPE_NONE && time > EndTime)
                    || (EndType == CGtd.END_TYPE_LOOP && ExeCount < 1)
                    || (EndType == CGtd.END_TYPE_TIME && (NextTime > EndTime || time > EndTime)))
                {
                    Status = CGtd.GTD_STAT_FINISHED;
                    return true;
                }
                ExeCount -= 1;
            }

            // 判断是否过期
            if (Status == CGtd.GTD_STAT_ONTIME)
            {
                if (time > NextTime)
                {
                    Status = CGtd.GTD_STAT_EXPIRED;
                    return true;
                }
                return false;
            }

            #region 提前
            switch (PrePose)
            {
                case CGtd.UNIT_MAJOR_SECOND:
                    time.AddSeconds(PreTime);
                    break;
                case CGtd.UNIT_MAJOR_MINUTE:
                    time.AddMinutes(PreTime);
                    break;
                case CGtd.UNIT_MAJOR_HOUR:
                    time.AddHours(PreTime);
                    break;
                case CGtd.UNIT_MAJOR_DAY:
                    time.AddDays(PreTime);
                    break;
                case CGtd.UNIT_MAJOR_WEEK:
                    time.AddDays(PreTime * 7);
                    break;
                case CGtd.UNIT_MAJOR_MONTH:
                    time.AddMonths(PreTime);
                    break;
                case CGtd.UNIT_MAJOR_YEAR:
                    time.AddYears(PreTime);
                    break;
            }
            #endregion

            if (time >= NextTime.AddSeconds(-length))
            {
                Status = CGtd.GTD_STAT_ONTIME;
                return true;
            }
            return false;
        }
        #endregion

        #region 事件型
        /// <summary>
        /// 事件列表
        /// </summary>
        public List<int> Events { get; private set; }

        public bool TestEvent()
        {
            return true;
        }
        #endregion

        #region 公式型
        /// <summary>
        /// 计算公式 
        /// </summary>
        public string Maths { get; set; }

        public bool TestMaths(DateTime time)
        {
            return true;
        }
        #endregion
    }
}

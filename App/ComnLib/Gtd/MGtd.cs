using System;
using System.Collections.Generic;
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

        #region 结束方式
        /// <summary>
        /// 结束方式
        /// </summary>
        public int StopType { get; set; }
        /// <summary>
        /// 循环次数
        /// </summary>
        public int Cycles { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
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

        public MGtd()
        {
            WhenValues = new List<int>();

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
        #region 属性
        #region 时间信息
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        /// 下次时间
        /// </summary>
        public DateTime NextTime { get; set; }
        /// <summary>
        /// 上次时间
        /// </summary>
        public DateTime LastTime { get; set; }
        /// <summary>
        /// 是否提前
        /// </summary>
        public int PrePose { get; set; }
        /// <summary>
        /// 提前间隔
        /// </summary>
        public int PreTime { get; set; }
        #endregion

        #region 重复提醒
        /// <summary>
        /// 重复单位
        /// </summary>
        public int RedoUnit { get; set; }
        /// <summary>
        /// 重复方式
        /// </summary>
        public int RedoType { get; set; }

        #region 每隔重复
        /// <summary>
        /// 最大值
        /// </summary>
        public int MaxValue { get; private set; }
        /// <summary>
        /// 最小值
        /// </summary>
        public int MinValue { get; private set; }
        /// <summary>
        /// 每隔值
        /// </summary>
        public int EachValue { get; set; }
        #endregion

        #region 每到重复
        /// <summary>
        /// 参照单位
        /// </summary>
        public int ReferUnit { get; set; }
        /// <summary>
        /// 是否反向
        /// </summary>
        public bool Reverse { get; set; }
        /// <summary>
        /// 数值列表
        /// </summary>
        public List<int> WhenValues { get; private set; }
        #endregion
        #endregion
        #endregion

        #region 函数
        public bool TestDates(DateTime time, int length)
        {
            // 计算下次提醒时间
            if (NextTime == DateTime.MinValue)
            {
                NextTime = Start;
            }
            else if (Status == CGtd.GTD_STAT_NORMAL && NextTime < time)
            {
                NextDates(NextTime);
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
                    time.AddDays(7 * PreTime);
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

        public void ChangeUnit(int unit)
        {
            switch (unit)
            {
                case CGtd.UNIT_MAJOR_SECOND:
                    MaxValue = 59;
                    MinValue = 0;
                    break;
                case CGtd.UNIT_MAJOR_MINUTE:
                    MaxValue = 59;
                    MinValue = 0;
                    break;
                case CGtd.UNIT_MAJOR_HOUR:
                    MaxValue = 23;
                    MinValue = 0;
                    break;
                case CGtd.UNIT_MAJOR_DAY:
                    MaxValue = 31;
                    MinValue = 1;
                    break;
                case CGtd.UNIT_MAJOR_WEEK:
                    MaxValue = 59;
                    MinValue = 0;
                    break;
                case CGtd.UNIT_MAJOR_MONTH:
                    MaxValue = 12;
                    MinValue = 1;
                    break;
                case CGtd.UNIT_MAJOR_YEAR:
                    MaxValue = 100;
                    MinValue = 0;
                    break;
            }
        }

        private void NextDates(DateTime time)
        {
            if (RedoType == CGtd.TYPE_MINOR_EACH)
            {
                switch (RedoUnit)
                {
                    // 间隔n秒
                    case CGtd.UNIT_MAJOR_SECOND:
                        NextTime = time.AddSeconds(EachValue);
                        break;
                    // 间隔n分
                    case CGtd.UNIT_MAJOR_MINUTE:
                        NextTime = time.AddMinutes(EachValue);
                        break;
                    // 间隔n时
                    case CGtd.UNIT_MAJOR_HOUR:
                        NextTime = time.AddHours(EachValue);
                        break;
                    // 间隔n天
                    case CGtd.UNIT_MAJOR_DAY:
                        NextTime = time.AddDays(EachValue);
                        break;
                    // 间隔n周
                    case CGtd.UNIT_MAJOR_WEEK:
                        NextTime = time.AddDays(EachValue * 7);
                        break;
                    // 间隔n月
                    case CGtd.UNIT_MAJOR_MONTH:
                        NextTime = time.AddMonths(EachValue);
                        break;
                    // 间隔n季
                    case CGtd.UNIT_MAJOR_SEASON:
                        break;
                    // 间隔n年
                    case CGtd.UNIT_MAJOR_YEAR:
                        NextTime = time.AddYears(EachValue);
                        break;
                    default:
                        break;
                }
                return;
            }
            if (RedoType == CGtd.TYPE_MINOR_WHEN)
            {
                int tmp;
                switch (RedoUnit)
                {
                    // 每到n秒
                    case CGtd.UNIT_MAJOR_SECOND:
                        tmp = NextValue(time.Second);
                        if (tmp > 0)
                        {
                            NextTime = NextTime.AddSeconds(tmp);
                        }
                        else
                        {
                            NextTime = NextTime.AddMinutes(1).AddSeconds(WhenValues[0] - time.Second);
                        }
                        break;
                    // 每到n分
                    case CGtd.UNIT_MAJOR_MINUTE:
                        tmp = NextValue(time.Minute);
                        if (tmp > 0)
                        {
                            NextTime = NextTime.AddMinutes(tmp);
                        }
                        else
                        {
                            NextTime = NextTime.AddHours(1).AddMinutes(WhenValues[0] - time.Minute);
                        }
                        break;
                    // 每到n时
                    case CGtd.UNIT_MAJOR_HOUR:
                        tmp = NextValue(time.Hour);
                        if (tmp > 0)
                        {
                            NextTime = NextTime.AddHours(tmp);
                        }
                        else
                        {
                            NextTime = NextTime.AddDays(1).AddHours(WhenValues[0] - time.Hour);
                        }
                        break;
                    // 每到n天
                    case CGtd.UNIT_MAJOR_DAY:
                        tmp = NextValue(time.Day);
                        if (tmp > 0)
                        {
                            NextTime = NextTime.AddDays(tmp);
                        }
                        else
                        {
                            NextTime = NextTime.AddMonths(1).AddDays(WhenValues[0] - time.Day);
                        }
                        break;
                    // 每到n周
                    case CGtd.UNIT_MAJOR_WEEK:
                        tmp = NextValue(0);
                        if (tmp > 0)
                        {
                            NextTime = NextTime.AddDays(tmp);
                        }
                        else
                        {
                            NextTime = NextTime.AddDays(7 + WhenValues[0] - (int)time.DayOfWeek);
                            //if (ReferUnit == CGtd.UNIT_MINOR_BYMONTH)
                            //{
                            //    NextTime = NextTime.AddMonths(1);
                            //    NextTime = GetWeekDayOfMonth(NextTime, 1, WhenValues[0]);
                            //}
                            //else if (ReferUnit == CGtd.UNIT_MINOR_BYSEASON)
                            //{
                            //}
                            //else if (ReferUnit == CGtd.UNIT_MINOR_BYYEAR)
                            //{
                            //    NextTime = NextTime.AddYears(1);
                            //    NextTime = GetWeekDayOfMonth(NextTime, 1, 0);
                            //}
                        }
                        break;
                    // 每到n月
                    case CGtd.UNIT_MAJOR_MONTH:
                        tmp = NextValue(time.Month);
                        if (tmp > 0)
                        {
                            NextTime = NextTime.AddMonths(tmp);
                        }
                        else
                        {
                            NextTime = NextTime.AddYears(1).AddMonths(WhenValues[0] - time.Month);
                        }
                        break;
                    // 间隔n季
                    case CGtd.UNIT_MAJOR_SEASON:
                        break;
                    // 每到n年
                    case CGtd.UNIT_MAJOR_YEAR:
                        tmp = NextValue(time.Year);
                        if (tmp > 0)
                        {
                            NextTime = NextTime.AddYears(tmp);
                        }
                        break;

                    default:
                        break;
                }
                return;
            }
        }

        private int NextValue(int key)
        {
            foreach (int tmp in WhenValues)
            {
                if (key < tmp)
                {
                    return tmp - key;
                }
            }
            return -1;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="time"></param>
        /// <param name="weekIndex">从0开始</param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        private static DateTime GetWeekDayOfMonth(DateTime time, int weekIndex, int dayOfWeek)
        {
            if (weekIndex > 0)
            {
                // 每周第一天星期几
                time = time.AddDays(1 - time.Day);
                int fdw = (int)time.DayOfWeek;

                if (dayOfWeek < fdw)
                {
                    weekIndex++;
                }

                return time.AddDays(dayOfWeek - fdw + (weekIndex - 1) * 7);
            }

            if (weekIndex < 0)
            {
                time = time.AddDays(1 - time.Day).AddMonths(1);
                int fdw = (int)time.DayOfWeek;

                if (dayOfWeek > fdw)
                {
                    weekIndex--;
                }

                return time.AddDays(dayOfWeek - fdw + (weekIndex + 1) * 7);
            }
            return time;
        }

        private static DateTime GetWeekDayOfYear(DateTime time, int weekIndex, int dayOfWeek)
        {
            if (weekIndex > 0)
            {
                // 每周第一天星期几
                time = time.AddDays(1 - time.DayOfYear);
                int fdw = (int)time.DayOfWeek;

                if (dayOfWeek < fdw)
                {
                    weekIndex++;
                }

                return time.AddDays(dayOfWeek - fdw + (weekIndex - 1) * 7);
            }

            if (weekIndex < 0)
            {
                time = time.AddDays(1 - time.DayOfYear).AddYears(1);
                int fdw = (int)time.DayOfWeek;

                if (dayOfWeek > fdw)
                {
                    weekIndex--;
                }

                return time.AddDays(dayOfWeek - fdw + (weekIndex + 1) * 7);
            }
            return time;
        }
        #endregion
        #endregion

        #region 事件型
        public List<int> Events { get; private set; }

        public bool TestEvent()
        {
            return true;
        }
        #endregion

        #region 公式型
        public string Maths { get; set; }

        public bool TestMaths(DateTime time)
        {
            return true;
        }
        #endregion
    }
}

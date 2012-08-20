using System;
using System.Collections.Generic;

namespace Me.Amon.Gtd
{
    public class MGtdDates
    {
        #region 时间信息
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime End { get; set; }
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

        #region 特殊功能
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

        public MGtdDates()
        {
            WhenValues = new List<int>();
        }

        public void Init()
        {
            NextDate(NextTime == DateTime.MinValue ? Start : NextTime);
        }

        public bool Test(DateTime time, int length)
        {
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

            return time >= NextTime.AddSeconds(-length);
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

        private void NextDate(DateTime time)
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
                        tmp = NextStep(time.Second);
                        NextTime = tmp > 0 ? NextTime.AddSeconds(tmp) : NextTime.AddMinutes(1);
                        break;
                    // 每到n分
                    case CGtd.UNIT_MAJOR_MINUTE:
                        tmp = NextStep(time.Minute);
                        NextTime = tmp > 0 ? NextTime.AddMinutes(tmp) : NextTime.AddHours(1);
                        break;
                    // 每到n时
                    case CGtd.UNIT_MAJOR_HOUR:
                        tmp = NextStep(time.Hour);
                        NextTime = tmp > 0 ? NextTime.AddHours(tmp) : NextTime.AddDays(1);
                        break;
                    // 每到n天
                    case CGtd.UNIT_MAJOR_DAY:
                        tmp = NextStep(time.Day);
                        NextTime = tmp > 0 ? NextTime.AddDays(tmp) : NextTime.AddMonths(1);
                        break;
                    // 每到n周
                    case CGtd.UNIT_MAJOR_WEEK:
                        tmp = NextStep(0);
                        NextTime = NextTime.AddDays(EachValue * 7);
                        break;
                    // 每到n月
                    case CGtd.UNIT_MAJOR_MONTH:
                        tmp = NextStep(time.Month);
                        NextTime = tmp > 0 ? NextTime.AddMonths(tmp) : NextTime.AddYears(1);
                        break;
                    // 每到n年
                    case CGtd.UNIT_MAJOR_YEAR:
                        tmp = NextStep(time.Year);
                        if (tmp > 0)
                        {
                            NextTime = NextTime.AddMonths(tmp);
                        }
                        break;

                    default:
                        break;
                }
                return;
            }
        }

        private int NextStep(int key)
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
    }
}

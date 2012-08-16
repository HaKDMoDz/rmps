using System;
using System.Text.RegularExpressions;
using Me.Amon.Gtd;

namespace Me.Amon.Util
{
    public class TimeUtil
    {
        public static DateTime Parse(string str, char a, char b, char c)
        {
            DateTime now = DateTime.Now;
            if (str == null)
            {
                return now;
            }
            str = str.Trim();
            if (!Regex.IsMatch(str, string.Format("[^{0}{1}{2}\\d]", a, b, c)))
            {
                return now;
            }
            int i = str.IndexOf(c);
            if (i < 0)
            {
                return ParseDate(now, str, a);
            }

            now = ParseDate(now, str.Substring(0, i), a);
            return ParseTime(now, str.Substring(i + 1), b);
        }

        public static DateTime ParseDate(DateTime now, string str, char s)
        {
            string[] arr = str.Split(s);
            if (arr.Length == 3)
            {
                //now.Year = int.Parse(arr[0]);
                //now.Month = int.Parse(arr[1]);
                //now.Day = int.Parse(arr[2]);
            }
            Convert.ToDateTime("", null);
            return now;
        }

        public static DateTime ParseTime(DateTime now, string str, char s)
        {
            return now;
        }
        /// <summary>
        /// 计算指定任务是否满足可提示条件
        /// </summary>
        /// <param name="time">计算参照时间</param>
        /// <param name="mgtd">计划任务</param>
        /// <param name="length">可接受的时间段，以秒计</param>
        /// <returns>-2:异常、-1:过期、0满足、1未到</returns>
        public static int isOnTime(DateTime time, MGtd mgtd, long length)
        {
            #region 提前
            switch (mgtd.Prepose)
            {
                case CGtd.GTD_UNIT_SECOND:
                    time.AddSeconds(mgtd.P30F0313);
                    break;
                case CGtd.GTD_UNIT_MINUTE:
                    time.AddMinutes(mgtd.P30F0313);
                    break;
                case CGtd.GTD_UNIT_HOUR:
                    time.AddHours(mgtd.P30F0313);
                    break;
                case CGtd.GTD_UNIT_DAY:
                    time.AddDays(mgtd.P30F0313);
                    break;
                case CGtd.GTD_UNIT_WEEK:
                    time.AddDays(7 * mgtd.P30F0313);
                    break;
                case CGtd.GTD_UNIT_MONTH:
                    time.AddMonths(mgtd.P30F0313);
                    break;
                case CGtd.GTD_UNIT_YEAR:
                    time.AddYears(mgtd.P30F0313);
                    break;
            }
            #endregion

            #region 定时
            if (mgtd.Type == CGtd.GTD_TYPE_FIXTIME)
            {
                long now = time.ToBinary();
                foreach (MGtdDetail detail in mgtd.Details)
                {
                    long dif = (detail.Time - now) / TimeSpan.TicksPerSecond;
                    return dif < 0 ? -1 : (dif <= length ? 0 : 1);
                }
                return -2;
            }
            #endregion

            DateTime fix;
            length = -length;

            #region 间隔
            if (mgtd.Type == CGtd.GTD_TYPE_INTERVAL)
            {
                foreach (MGtdDetail detail in mgtd.Details)
                {
                    fix = DateTime.FromBinary(detail.Time);

                    if (time >= fix)
                    {
                        return -1;
                    }

                    fix.AddSeconds(length);

                    long dif;
                    switch (detail.Unit)
                    {
                        // 间隔n秒
                        case CGtd.GTD_UNIT_SECOND:
                            dif = (time.Second - fix.Second) % detail.Interval;
                            break;
                        // 间隔n分
                        case CGtd.GTD_UNIT_MINUTE:
                            dif = (time.Minute - fix.Minute) % detail.Interval;
                            break;
                        // 间隔n时
                        case CGtd.GTD_UNIT_HOUR:
                            dif = (time.Hour - fix.Hour) % detail.Interval;
                            break;
                        // 间隔n天
                        case CGtd.GTD_UNIT_DAY:
                            dif = (time.Day - fix.Day) % detail.Interval;
                            break;
                        // 间隔n周
                        case CGtd.GTD_UNIT_WEEK:
                            dif = (time.Day - fix.Day) % detail.Interval;
                            break;
                        // 间隔n月
                        case CGtd.GTD_UNIT_MONTH:
                            dif = time.Month - fix.Month % detail.Interval;
                            break;
                        // 间隔n年
                        case CGtd.GTD_UNIT_YEAR:
                            dif = (time.Year - fix.Year) % detail.Interval;
                            break;
                        default:
                            continue;
                    }

                    if (dif != 0)
                    {
                        return 1;
                    }
                    if (time > fix)
                    {
                        return 0;
                    }
                    return -1;
                }
                return -2;
            }
            #endregion

            #region 周期
            if (mgtd.Type == CGtd.GTD_TYPE_CYCLIST)
            {
                foreach (MGtdDetail detail in mgtd.Details)
                {
                    fix = DateTime.FromBinary(detail.Time);

                    if (time >= fix)
                    {
                        return -1;
                    }

                    switch (detail.Unit)
                    {
                        // 每到n分
                        case CGtd.GTD_UNIT_MINUTE:
                            fix.AddMinutes(time.Minute - fix.Minute);
                            break;
                        // 每到n时
                        case CGtd.GTD_UNIT_HOUR:
                            fix.AddHours(time.Hour - fix.Hour);
                            break;
                        // 每到n天
                        case CGtd.GTD_UNIT_DAY:
                            fix.AddDays(time.Day - fix.Day);
                            break;
                        // 每到n周
                        case CGtd.GTD_UNIT_WEEK:
                            fix.AddDays(time.Day - fix.Day);
                            break;
                        // 每到n月
                        case CGtd.GTD_UNIT_MONTH:
                            fix.AddMonths(time.Month - fix.Month);
                            break;
                        // 每到n年
                        case CGtd.GTD_UNIT_YEAR:
                            fix.AddYears(time.Year - fix.Year);
                            break;
                    }

                    fix.AddSeconds(length);
                    if (time > fix)
                    {
                        return 1;
                    }
                    return 0;
                }
                return -2;
            }
            #endregion

            #region 公式
            if (mgtd.Type == CGtd.GTD_TYPE_FORMULA)
            {
                foreach (MGtdDetail detail in mgtd.Details)
                {
                    string exp = detail.Express;
                    if (!CharUtil.IsValidate(exp))
                    {
                        continue;
                    }

                    try
                    {
                        exp = Regex.Replace(exp, "(n|nian|year)", "" + time.Year);
                        exp = Regex.Replace(exp, "(y|yue|month)", "" + (time.Month));
                        exp = Regex.Replace(exp, "(r|ri|day)", "" + time.Day);
                        exp = Regex.Replace(exp, "(s|shi|hour)", "" + time.Hour);
                        exp = Regex.Replace(exp, "(f|fen|minute)", "" + time.Minute);
                        exp = Regex.Replace(exp, "(m|miao|second)", "" + time.Second);
                        exp = Regex.Replace(exp, "(z|zhou|date)", "" + time.DayOfWeek);
                        double dif = 0;//new Symbols().eval(exp);
                        return dif < 0 ? -1 : (dif <= length ? 0 : 1);
                    }
                    catch (Exception e)
                    {
                        //Main.LogInfo(e.Message);
                        return -2;
                    }
                }
                return -2;
            }
            #endregion

            return -2;
        }
    }
}

/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.util;

import java.util.Calendar;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * TODO: 功能说明
 * <li>使用说明：</li>
 * <br />
 * TODO: 使用说明
 * </ul>
 * 
 * @author Amon
 */
public final class DateUtil
{
    private DateUtil()
    {
    }

    /**
     * 转换指定的日期、时间字符串为日期
     * 
     * @param datetime
     *            日期时间字符串
     * @param datesp
     *            日期分隔字符
     * @param timesp
     *            时间分隔字符
     * @param dtsp
     *            日期与时间的分隔字符
     * @return Calendar日期格式
     */
    public static Calendar stringToDate(String datetime, char datesp, char timesp, char dtsp) throws Exception
    {
        // 若指定日期时间字符串为空，则直接返回当前时间
        if (!CheckUtil.isValidate(datetime))
        {
            return Calendar.getInstance();
        }

        // 日期时间字符串分隔
        int dtspIndx = datetime.indexOf(dtsp);
        String date = datetime;
        String time = "";
        if (dtspIndx >= 0 && dtspIndx < datetime.length())
        {
            date = datetime.substring(0, dtspIndx);
            time = datetime.substring(dtspIndx + 1);
        }

        // 日期对象
        Calendar cal = Calendar.getInstance();

        // 日期信息解析
        if (CheckUtil.isValidate(date))
        {
            // 读取日期分隔符在日期字符串中位置信息
            int f = date.indexOf(datesp);
            int e = date.lastIndexOf(datesp);

            String y = null;// 年份
            String m = null;// 月份
            String d = null;// 日期
            // 没有日期分隔符号的情况下，日期字符串均按年份处理
            if (f < 0)
            {
                y = date;
            }
            // 存在日期分隔符号的情况下的处理
            else if (f >= 0)
            {
                // 只存在一个日期分隔符号的情况下，日期字符串按年月格式处理
                if (f == e)
                {
                    y = date.substring(0, f);
                    m = date.substring(e + 1);
                }
                // 存在两个日期分隔符号的情况下，日期字符串按年月日格式处理
                else
                {
                    y = date.substring(0, f);
                    m = date.substring(f + 1, e);
                    d = date.substring(e + 1);
                }
            }

            // 年份信息读取
            if (CheckUtil.isValidate(y))
            {
                cal.set(Calendar.YEAR, Integer.parseInt(y));
            }

            // 月份信息读取
            if (CheckUtil.isValidate(m))
            {
                cal.set(Calendar.MONTH, Integer.parseInt(m) - 1);
            }

            // 日期信息读取
            if (CheckUtil.isValidate(d))
            {
                cal.set(Calendar.DAY_OF_MONTH, Integer.parseInt(d));
            }
        }

        // 时间信息解析
        if (CheckUtil.isValidate(time))
        {
            // 读取日期分隔符在日期字符串中位置信息
            int f = time.indexOf(timesp);
            int e = time.lastIndexOf(timesp);

            String h = null;// 小时
            String m = null;// 分钟
            String s = null;// 秒钟
            // 没有时间分隔符号的情况下，时间字符串均按小时处理
            if (f < 0)
            {
                h = time;
            }
            // 存在日期分隔符号的情况下的处理
            else if (f >= 0)
            {
                // 只存在一个日期分隔符号的情况下，日期字符串按年月格式处理
                if (f == e)
                {
                    h = time.substring(0, f);
                    m = time.substring(e + 1);
                }
                // 存在两个日期分隔符号的情况下，日期字符串按年月日格式处理
                else
                {
                    h = time.substring(0, f);
                    m = time.substring(f + 1, e);
                    s = time.substring(e + 1);
                }
            }

            // 年份信息读取
            if (CheckUtil.isValidate(h))
            {
                cal.set(Calendar.HOUR_OF_DAY, Integer.parseInt(h));
            }

            // 月份信息读取
            if (CheckUtil.isValidate(m))
            {
                cal.set(Calendar.MINUTE, Integer.parseInt(m));
            }

            // 日期信息读取
            if (CheckUtil.isValidate(s))
            {
                cal.set(Calendar.SECOND, Integer.parseInt(s));
            }
        }

        return cal;
    }

    /**
     * 获取指定年月日是一周中的第几天（即星期几），默认一周中第一天为星期日，其后依次为
     * 星期一、星期二、星期三、星期四、星期五、星期六，并分别用0,1,2,3,4,5,6来表示。
     * 指定年月日是一周中的第几天的计算公式通常为蔡勒公式，其定义如下： W = [C/4] - 2C + Y + [Y/4] + [13 * (M+1)
     * / 5] + D - 1 W表示一周中的第几天（即星期几）， C是当前年份所对应的世纪数减一， Y是当前年份的后两位， M是要计算的月份，
     * D是要计算的日数。 公式说明： 1月和2月要按上一年的13月和14月来算，这时C和Y均应按上一年所对应的年份来取值。
     * 
     * @param year
     *            要计算的年份信息
     * @param month
     *            要计算的月份信息
     * @param day
     *            要计算的日期信息
     * @return 指定年月日所对应的一周中的第几天（即星期几），一周中的第一天为星期日，以数值0表示
     */
    public static int dayInWeek(int year, int month, int day)
    {
        int y = year;
        int m = month;
        int d = day;

        // 判断要计算的月分是否为一年中的第一、二月份，若是则按上一年的十三、十四月份计算
        if (m < 3)
        {
            m += 12;
            y -= 1;
        }

        // 当前计算年份所对应的世纪
        int c = y / 100;

        // 取当前年份的后两位所对应的数值
        y %= 100;

        // 利用蔡勒公式计算星期几
        int w = (-7 * c) >> 2;
        w += (5 * y) >> 2;
        w += 13 * (m + 1) / 5;
        w += d - 1;

        w %= 7;
        if (w < 0)
        {
            w += 7;
        }

        return w;
    }

    /**
     * 获得指定年份的月份里包含有多少天数。
     * 
     * @param year
     *            要计算天数的年份
     * @param month
     *            要计算天数的月份
     * @return
     */
    public static int daysOfMonth(int year, int month)
    {
        switch (month)
        {
            // 一、三、五、七、八、十、腊月份分别为31天
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                return 31;
                // 四、六、九、十一月份分别为30天
            case 4:
            case 6:
            case 9:
            case 11:
                return 30;
                // 二月份平年为28天，润年为29年
            case 2:
                int days = 28;
                if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
                {
                    days = 29;
                }
                return days;
            default:
                return 0;
        }
    }

    /**
     * 计算指定的年份有多少个星期
     * 
     * @param year
     * @return
     */
    public static int weeksOfYear(int year)
    {
        int temp = 1;
        temp += year;
        temp += year / 4;
        temp -= year / 100;
        temp += year / 400;
        temp %= 7;
        temp = temp > 4 ? 53 : 52;
        return temp;
    }

    /**
     * 在一年中从1月1日到指定日期总共经过的天数，包含当天。
     * 
     * @param year
     * @param month
     * @param day
     * @return
     */
    public static int daysInyear(int year, int month, int day)
    {
        int total = 0;
        int[] days =
        { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
        {
            days[2] = 29;
        }

        for (int i = 1; i < month; i++)
        {
            total += days[i];
        }
        return total + day;
    }

    /**
     * 计算指定的日期所在周是一年中的第几周
     * 
     * @param year
     *            年份
     * @param month
     *            月份
     * @param day
     *            日期
     * @return 对应周为一年中第几周
     */
    public static int weekInYear(int year, int month, int day)
    {
        int days = dayInWeek(year, 1, 1);
        int week = daysInyear(year, month, day) / 7;
        if (days != 0)
        {
            week += 1;
        }
        return week;
    }

    /**
     * 计算指定的日期所在周是对应月中的第几周
     * 
     * @param year
     * @param month
     * @param day
     * @return
     */
    public static int weekOfMonth(int year, int month, int day)
    {
        int days = dayInWeek(year, month, 1);
        int week = day / 7;
        if (days != 0)
        {
            week += 1;
        }
        return week;
    }

    /**
     * 获取GMT世界标准时间
     * 
     * @return
     */
    public static java.util.Calendar getGMTCalendar()
    {
        // 万年历对象
        java.util.Calendar cal = java.util.Calendar.getInstance();
        // 当前时区偏差
        int offset = cal.get(java.util.Calendar.DST_OFFSET) + cal.get(java.util.Calendar.ZONE_OFFSET);
        // 校正时区偏差到GMT时区
        cal.add(java.util.Calendar.MILLISECOND, -offset);

        return cal;
    }

    /**
     * 获取GMT世界标准时间
     * 
     * @return 长整型GMT时间标准时间
     */
    public static long getGMTTimeInMillies()
    {
        // 长整型GMT时间
        return getGMTCalendar().getTimeInMillis();
    }
}

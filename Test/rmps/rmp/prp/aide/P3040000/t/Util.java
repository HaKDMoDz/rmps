/*
 * Project:        RMPS
 * Compiler:       JDK1.6.0
 * CopyRight:      &copy; 2007 Amon &reg; Winshine ( Amon@amonsoft.cn / http://amonsoft.cn ).
 * Description:
 *
 */
package rmp.prp.aide.P3040000.t;

import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import rmp.bean.K1IV2S;
import rmp.face.WBackCall;
import rmp.io.db.DBAccess;
import rmp.prp.aide.P3040000.P3040000;
import rmp.util.DateUtil;
import rmp.util.LogUtil;


import cons.db.PrpCons;
import cons.prp.aide.P3040000.ConstUI;
import cons.prp.aide.P3040000.LangRes;

/**
 * <ul>
 * <li>功能说明：</li>
 * <br />
 * 最终工具类
 * <li>使用说明：</li>
 * <br />
 * </ul>
 * 
 * @author Amon
 */
public final class Util
{
    // ////////////////////////////////////////////////////////////////////////
    // 逻辑控制区域
    // ////////////////////////////////////////////////////////////////////////
    /** 调用此模型并且需要回馈的对象 */
    private static HashMap<String, WBackCall> hm_PropList;
    private static int year;
    private static int month;
    private static int day;
    private static int weekOfYear;
    private static int weekOfMonth;

    // ////////////////////////////////////////////////////////////////////////
    // 构造函数区域
    // ////////////////////////////////////////////////////////////////////////
    /**
     * 默认构造函数
     */
    private Util()
    {
    }

    /**
     * 注册回馈对象引用
     * 
     * @param key
     * @param backCall
     */
    public static void register(String key, WBackCall backCall)
    {
        if (hm_PropList == null)
        {
            hm_PropList = new HashMap<String, WBackCall>();
        }
        hm_PropList.put(key, backCall);
    }

    /**
     * 指定回馈对象信息回馈
     * 
     * @param key
     */
    public static void firePropertyChanged(String key, String value)
    {
        if (hm_PropList != null)
        {
            WBackCall backCall = hm_PropList.get(key);
            if (backCall != null)
            {
                backCall.wAction(null, value, null);
            }
        }
    }

    public static List<K1IV2S> initViewDataByDate()
    {
        // 年月字符串常量
        final String y = Integer.toString(year);
        final String m = Integer.toString(month);
        final String d = Integer.toString(day);

        // 符合条件的数据集列表
        List<K1IV2S> dataList = new ArrayList<K1IV2S>();

        // 数据库操作对象
        DBAccess dba = new DBAccess();

        try
        {
            dba.wInit();

            // 查询条件拼接
            dba.addTable(PrpCons.P3040100);
            dba.addColumn("*");

            ResultSet rest = dba.executeSelect();
            int i1;
            int i2;
            String s;

            // 循环处理每一条记录
            while (rest.next())
            {
                // 区间限制类型
                i1 = rest.getInt(PrpCons.P3040102);

                // 限制起始时间
                if (i1 == 1 || i1 == 2)
                {
                    // 起始年份判断
                    s = rest.getString(PrpCons.P3040106);
                    s = s.replace(ConstUI.PARAM_Y_E, y);
                    // .replace(ConstUI.PARAM_Y_C, y)，以后扩展
                    i2 = rmp.prp.aide.P3060000.t.Util.calculate(s);
                    if (i2 > year)
                    {
                        // 起始年份大于当前年份，继续下一条记录处理
                        continue;
                    }

                    // 起始月份判断
                    s = rest.getString(PrpCons.P3040107);
                    s = s.replace(ConstUI.PARAM_M_E, m);
                    // .replace(ConstUI.PARAM_M_C, m)，以后扩展
                    i2 = rmp.prp.aide.P3060000.t.Util.calculate(s);
                    if (i2 > month)
                    {
                        // 起始月份大于当前月份，继续下一条记录处理
                        continue;
                    }
                }

                // 限制结束时间
                if (i1 == 1 || i1 == 3)
                {
                    // 结束年份判断
                    s = rest.getString(PrpCons.P3040112);
                    s = s.replace(ConstUI.PARAM_Y_E, y);
                    // .replace(ConstUI.PARAM_Y_C, y)
                    i2 = rmp.prp.aide.P3060000.t.Util.calculate(s);
                    if (i2 < year)
                    {
                        // 结束年份小于当前年份，继续下一条记录处理
                        continue;
                    }

                    // 结束月份判断
                    s = rest.getString(PrpCons.P3040113);
                    s = s.replace(ConstUI.PARAM_M_E, m);
                    // .replace(ConstUI.PARAM_M_C, m)
                    i2 = rmp.prp.aide.P3060000.t.Util.calculate(s);
                    if (i2 < month)
                    {
                        // 结束月份小于当前月份，继续下一条记录处理
                        continue;
                    }
                }

                // 显示年份判断
                s = rest.getString(PrpCons.P304010C);
                s = s.replace(ConstUI.PARAM_Y_E, y);
                // .replace(ConstUI.PARAM_Y_C, y)
                i2 = rmp.prp.aide.P3060000.t.Util.calculate(s);
                if (i2 != year)
                {
                    // 提示年份不等于当前年份，继续下一条记录处理
                    continue;
                }

                // 显示月份判断
                s = rest.getString(PrpCons.P304010D);
                s = s.replace(ConstUI.PARAM_M_E, m);
                // .replace(ConstUI.PARAM_M_C, m)
                i2 = rmp.prp.aide.P3060000.t.Util.calculate(s);
                if (i2 != month)
                {
                    // 提示月份不等于当前月份，继续下一条记录处理
                    continue;
                }

                // 显示日期计算
                s = rest.getString(PrpCons.P304010E);
                s = s.replace(ConstUI.PARAM_D_E, d);
                // .replace(ConstUI.PARAM_D_C, "" + i1)
                i2 = rmp.prp.aide.P3060000.t.Util.calculate(s);

                // 添加记录
                if (i2 == day)
                {
                    // 提示日期等于当前日期，读取当前记录信息
                    s = rest.getString(PrpCons.P3040118);
                    dataList.add(new K1IV2S(i2, s, s));
                }
            }
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.close();
        }
        return dataList;
    }

    /**
     * @return
     */
    public static List<K1IV2S> initViewDataByMonth()
    {
        // 年月字符串常量
        final String y = Integer.toString(year);
        final String m = Integer.toString(month);
        // final String w = Integer.toString(weekOfYear);
        // final String z = Integer.toString(weekOfMonth);
        final int a = DateUtil.daysOfMonth(year, month);

        // 符合条件的数据集列表
        List<K1IV2S> dataList = new ArrayList<K1IV2S>();

        // 数据库操作对象
        DBAccess dba = new DBAccess();

        try
        {
            dba.wInit();

            // 查询条件拼接
            dba.addTable(PrpCons.P3040100);
            dba.addColumn("*");

            ResultSet rest = dba.executeSelect();
            int i1;
            int i2;
            String s;

            // 循环处理每一条记录
            while (rest.next())
            {
                // 区间限制类型
                i1 = rest.getInt(PrpCons.P3040102);

                // 限制起始时间
                if (i1 == 1 || i1 == 2)
                {
                    // 起始年份判断
                    s = rest.getString(PrpCons.P3040106);
                    s = s.replace(ConstUI.PARAM_Y_E, y);
                    // .replace(ConstUI.PARAM_Y_C, y)，以后扩展
                    i2 = rmp.prp.aide.P3060000.t.Util.calculate(s);
                    if (i2 > year)
                    {
                        // 起始年份大于当前年份，继续下一条记录处理
                        continue;
                    }

                    // 起始月份判断
                    s = rest.getString(PrpCons.P3040107);
                    s = s.replace(ConstUI.PARAM_M_E, m);
                    // .replace(ConstUI.PARAM_M_C, m)，以后扩展
                    i2 = rmp.prp.aide.P3060000.t.Util.calculate(s);
                    if (i2 > month)
                    {
                        // 起始月份大于当前月份，继续下一条记录处理
                        continue;
                    }
                }

                // 限制结束时间
                if (i1 == 1 || i1 == 3)
                {
                    // 结束年份判断
                    s = rest.getString(PrpCons.P3040112);
                    s = s.replace(ConstUI.PARAM_Y_E, y);
                    // .replace(ConstUI.PARAM_Y_C, y)
                    i2 = rmp.prp.aide.P3060000.t.Util.calculate(s);
                    if (i2 < year)
                    {
                        // 结束年份小于当前年份，继续下一条记录处理
                        continue;
                    }

                    // 结束月份判断
                    s = rest.getString(PrpCons.P3040113);
                    s = s.replace(ConstUI.PARAM_M_E, m);
                    // .replace(ConstUI.PARAM_M_C, m)
                    i2 = rmp.prp.aide.P3060000.t.Util.calculate(s);
                    if (i2 < month)
                    {
                        // 结束月份小于当前月份，继续下一条记录处理
                        continue;
                    }
                }

                // 显示年份判断
                s = rest.getString(PrpCons.P304010C);
                s = s.replace(ConstUI.PARAM_Y_E, y);
                // .replace(ConstUI.PARAM_Y_C, y)
                i2 = rmp.prp.aide.P3060000.t.Util.calculate(s);
                if (i2 != year)
                {
                    // 提示年份不等于当前年份，继续下一条记录处理
                    continue;
                }

                // 显示月份判断
                s = rest.getString(PrpCons.P304010D);
                s = s.replace(ConstUI.PARAM_M_E, m);
                // .replace(ConstUI.PARAM_M_C, m)
                i2 = rmp.prp.aide.P3060000.t.Util.calculate(s);
                if (i2 != month)
                {
                    // 提示月份不等于当前月份，继续下一条记录处理
                    continue;
                }

                // 显示日期计算
                i1 = 0;
                while (++i1 <= a)
                {
                    s = rest.getString(PrpCons.P304010E);
                    s = s.replace(ConstUI.PARAM_D_E, "" + i1);
                    // .replace(ConstUI.PARAM_D_C, "" + i1)
                    i2 = rmp.prp.aide.P3060000.t.Util.calculate(s);

                    // 添加记录
                    if (i1 == i2)
                    {
                        s = rest.getString(PrpCons.P3040118);
                        dataList.add(new K1IV2S(i2, s, s));
                    }
                }
            }
        }
        catch (Exception exp)
        {
            LogUtil.exception(exp);
        }
        finally
        {
            dba.close();
        }
        return dataList;
    }

    /**
     * 检测指定的文本是否仅包含数字、四则运行符及指定字符c。
     * 
     * @param t
     * @param c
     * @return
     */
    public static boolean validate(String t, String s1, String s2)
    {
        if (t == null)
        {
            return true;
        }
        t = t.trim();
        if (t.length() < 1)
        {
            return true;
        }
        t = t.replace(s1, "").replace(s2, "");
        for (char c : t.toCharArray())
        {
            if (c >= '0' && c <= '9')
            {
                continue;
            }
            if (c == '.' || c == '+' || c == '-' || c == '*' || c == '%' || c == '/')
            {
                continue;
            }
            return false;
        }
        return true;
    }

    /**
     * @return the hm_PropList
     */
    public static HashMap<String, WBackCall> getHm_PropList()
    {
        return hm_PropList;
    }

    /**
     * @param hm_PropList
     *            the hm_PropList to set
     */
    public static void setPropList(HashMap<String, WBackCall> hm_PropList)
    {
        Util.hm_PropList = hm_PropList;
    }

    /**
     * 设置日期为当前日期
     */
    public static void setDate()
    {
        java.util.Calendar cal = java.util.Calendar.getInstance();
        Util.year = cal.get(java.util.Calendar.YEAR);
        Util.month = cal.get(java.util.Calendar.MONTH) + 1;
        Util.day = cal.get(java.util.Calendar.DATE);
    }

    /**
     * @param year
     * @param month
     * @param day
     */
    public static void setDate(int year, int month, int day)
    {
        Util.year = year;
        Util.month = month;
        Util.day = day;
    }

    /**
     * @param v
     * @return
     */
    public static int addYear(int v)
    {
        if (v == 0)
        {
            return year;
        }

        year += v;
        if (year == 0)
        {
            year = v > 0 ? 1 : -1;
        }
        return year;
    }

    /**
     * @return the year
     */
    public static int getYear()
    {
        return year;
    }

    /**
     * @param year
     *            the year to set
     */
    public static void setYear(int year)
    {
        if (year != 0)
        {
            Util.year = year;
        }
    }

    /**
     * @param v
     * @return
     */
    public static int addMonth(int v)
    {
        if (v == 0)
        {
            return month;
        }
        month += v;
        if (month > 12)
        {
            addYear(month / 12);
            month %= 12;
        }
        else if (month < 1)
        {
            addYear(month / 12 - 1);
            month %= 12;
            month += 12;
        }
        return month;
    }

    /**
     * @return the month
     */
    public static int getMonth()
    {
        return month;
    }

    /**
     * @param month
     *            the month to set
     */
    public static void setMonth(int month)
    {
        if (month >= 1 && month <= 12)
        {
            Util.month = month;
        }
    }

    public static int addDay(int v)
    {
        if (v == 0)
        {
            return day;
        }
        day += v;
        int t = DateUtil.daysOfMonth(year, month);
        if (day > t)
        {
            while (day > t)
            {
                addMonth(1);
                day -= t;
                t = DateUtil.daysOfMonth(year, month);
            }
        }
        else if (day < 1)
        {
            while (day < 1)
            {
                addMonth(-1);
                t = DateUtil.daysOfMonth(year, month);
                day += t;
            }
        }
        return day;
    }

    /**
     * @return the day
     */
    public static int getDay()
    {
        return day;
    }

    /**
     * @param day
     *            the day to set
     */
    public static void setDay(int day)
    {
        if (day >= 1 && day <= 31)
        {
            Util.day = day;
        }
    }

    /**
     * 获得公元纪元日期，格式为：yyyy-MM-dd
     * 
     * @return
     */
    public static String getDate()
    {
        return getDate(Integer.toString(day));
    }

    /**
     * 获得公元纪元日期，格式为：yyyy-MM-dd
     * 
     * @param day
     *            在某月份视图下，用户鼠标经过某个日期时，显示提示信息的日期
     * @return
     */
    public static String getDate(int date)
    {
        return getDate(Integer.toString(date));
    }

    public static String getDate(String date)
    {
        String t = P3040000.getMesg(LangRes.P3041102);

        StringBuffer sb = new StringBuffer();
        sb.append(year).append(t);
        if (month < 10)
        {
            sb.append('0');
        }
        sb.append(Util.getMonth());
        sb.append(t);
        if (date.length() < 2)
        {
            sb.append('0');
        }
        sb.append(Util.getDay());

        return sb.toString();
    }

    /**
     * 获得当前日期
     */
    public static String getSolarDate()
    {
        String t = P3040000.getMesg(LangRes.P3041102);
        return new StringBuffer().append(year).append(t).append(month).append(t).append(day).toString();
    }

    public static String getLunarDate()
    {
        return "";
    }

    /**
     * @return the weekOfYear
     */
    public static int getWeekOfYear()
    {
        return weekOfYear;
    }

    /**
     * @param weekOfYear
     *            the weekOfYear to set
     */
    public static void setWeekOfYear(int weekOfYear)
    {
        Util.weekOfYear = weekOfYear;
    }

    /**
     * @return the weekOfMonth
     */
    public static int getWeekOfMonth()
    {
        return weekOfMonth;
    }

    /**
     * @param weekOfMonth
     *            the weekOfMonth to set
     */
    public static void setWeekOfMonth(int weekOfMonth)
    {
        Util.weekOfMonth = weekOfMonth;
    }
}

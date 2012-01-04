using System;
using System.Data;
using System.Collections;

using cons.io.db.comn;

using rmp.bean;
using rmp.io.db;
using System.Text;
using System.Globalization;

namespace rmp.wrp.date
{
    /// <summary>
    /// Summary description for Date
    /// </summary>
    public class Date
    {
        private static ArrayList dateList;
        /// <summary>
        /// 中国农历对象
        /// </summary>
        private static readonly ChineseLunisolarCalendar nl = new ChineseLunisolarCalendar();
        /// <summary>
        /// 中文数字
        /// </summary>
        public static readonly string[] SZ = { "〇", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
        /// <summary>
        /// 年份：天干
        /// </summary>
        public static readonly string[] TG = { "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };
        /// <summary>
        /// 年份：地支
        /// </summary>
        public static readonly string[] DZ = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };
        /// <summary>
        /// 年份：生肖
        /// </summary>
        public static readonly string[] SX = { "鼠", "牛", "虎", "兔", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪" };
        /// <summary>
        /// 月份
        /// </summary>
        public static readonly string[] YF = { "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "冬", "腊" };
        /// <summary>
        /// 日期
        /// </summary>
        public static readonly string[] RQ = { "初一", "初二", "初三", "初四", "初五", "初六", "初七", "初八", "初九", "初十", "十一", "十二", "十三", "十四", "十五", "十六", "十七", "十八", "十九", "二十", "廿一", "廿二", "廿三", "廿四", "廿五", "廿六", "廿七", "廿八", "廿九", "三十" };


        private Date()
        {
        }

        public static ArrayList DateList()
        {
            if (dateList == null)
            {
                ReadDate();
            }
            return dateList;
        }

        public static String DateName(String hash)
        {
            if (dateList == null)
            {
                ReadDate();
            }

            K1V3 item;
            foreach (ArrayList itemList in dateList)
            {
                for (int i = 1; i < itemList.Count; i += 1)
                {
                    item = (K1V3)itemList[i];
                    if (hash == item.K)
                    {
                        return item.V1 + ' ' + ((K1V3)itemList[0]).V1;
                    }
                }
            }
            return "";
        }

        private static void ReadDate()
        {
            dateList = new ArrayList(5);
            DBAccess dba = new DBAccess();

            String sqlTable = ComnCons.C2010000;
            String sqlSelect = String.Format("SELECT {1}, {2}, {3}, {4} FROM {0} WHERE {5}='{6}' ORDER BY {7} DESC",
                sqlTable,
                ComnCons.C2010002,
                ComnCons.C2010004,
                ComnCons.C2010005,
                ComnCons.C2010006,
                ComnCons.C2010003, "13100000",
                ComnCons.C2010001
                );
            DataView dv = dba.CreateView(sqlTable, sqlSelect);
            ArrayList list;
            DataRowView row;
            for (int i = 0; i < dv.Count; i += 1)
            {
                row = dv[i];
                list = new ArrayList();
                list.Add(new K1V3(row[ComnCons.C2010002].ToString(), row[ComnCons.C2010004].ToString(), row[ComnCons.C2010005].ToString(), row[ComnCons.C2010006].ToString()));

                sqlTable = ComnCons.C2010100;
                sqlSelect = String.Format("SELECT {1}, {2}, {3}, {4} FROM {0} WHERE {5}='{6}' ORDER BY {7} DESC",
                    sqlTable,
                    ComnCons.C2010103,
                    ComnCons.C2010105,
                    ComnCons.C2010106,
                    ComnCons.C2010107,
                    ComnCons.C2010104, row[ComnCons.C2010002],
                    ComnCons.C2010101
                    );
                DataView dv2 = dba.CreateView(sqlTable, sqlSelect);
                for (int j = 0; j < dv2.Count; j += 1)
                {
                    row = dv2[j];
                    list.Add(new K1V3(row[ComnCons.C2010103].ToString(), row[ComnCons.C2010105].ToString(), row[ComnCons.C2010106].ToString(), row[ComnCons.C2010107].ToString()));
                }
                dateList.Add(list);
            }
            dv.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static System.Xml.XmlDocument ChineseDateM(int y, int m, int d, String solar, String lunar)
        {
            DateTime now = new DateTime(y, m, d);

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            System.Xml.XmlElement root = doc.CreateElement("amonsoft");
            doc.AppendChild(root);

            System.Xml.XmlElement date = doc.CreateElement("date");
            date.SetAttribute("solar", now.ToString(solar));
            date.SetAttribute("lunar", ChineseDateD(now, lunar));
            root.AppendChild(date);

            System.Xml.XmlElement week = doc.CreateElement("week");
            week.InnerText = ((int)new DateTime(y, m, 1).DayOfWeek).ToString();
            date.AppendChild(week);

            int days = DateTime.DaysInMonth(y, m);
            date.SetAttribute("count", days.ToString());
            for (int i = 1; i <= days; i += 1)
            {
                System.Xml.XmlElement day = doc.CreateElement("day");
                day.SetAttribute("id", i.ToString());
                day.InnerText = RQ[nl.GetDayOfMonth(new DateTime(y, m, i)) - 1];
                date.AppendChild(day);
            }

            return doc;
        }

        /// <summary>
        /// 返回格式化的指定日期
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="format">日期格式字符串</param>
        /// <returns></returns>
        public static string ChineseDateD(DateTime dateTime, string format)
        {
            // 年
            int n = nl.GetYear(dateTime);
            int t = n;
            StringBuilder s = new StringBuilder();
            while (t > 0)
            {
                s.Insert(0, SZ[t % 10]);
                t /= 10;
            }

            // 月
            int y = nl.GetMonth(dateTime);
            // 日
            int r = nl.GetDayOfMonth(dateTime);
            // 干支
            int jz = nl.GetSexagenaryYear(dateTime);
            // 天干
            int tg = jz % 10;
            // 地支
            int dz = jz % 12;
            // 闰月
            int ry = nl.GetLeapMonth(n);
            // 显示闰月
            string l = "";
            if (ry > 0)
            {
                if (ry == y)
                {
                    l = "闰";
                }
                ry = ry <= y ? 1 : 0;
            }
            y -= ry + 1;
            return format == null ? "" : format
                .Replace("gz", "GZ")
                .Replace("GZ", TG[tg - 1] + DZ[dz - 1])
                .Replace("sx", "SX")
                .Replace("SX", SX[dz - 1])
                .Replace("NF", s.ToString())
                .Replace("nf", n.ToString())
                .Replace("YF", l + YF[y])
                .Replace("yf", l + y)
                .Replace("RQ", RQ[r - 1])
                .Replace("rq", r.ToString());
        }
    }
}
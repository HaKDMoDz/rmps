<%@ WebHandler Language="C#" Class="date0001" %>

using System;
using System.Web;

/// <summary>
/// 日期时间类
/// </summary>
public class date0001 : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/xml";
        DateTime now = DateTime.Now;

        // 年份
        int y;
        try
        {
            y = int.Parse(context.Request["y"]);
        }
        catch (Exception)
        {
            y = now.Year;
        }

        // 月份
        int m;
        try
        {
            m = int.Parse(context.Request["m"]);
        }
        catch (Exception)
        {
            m = now.Month;
        }

        // 日期
        int d;
        try
        {
            d = int.Parse(context.Request["d"]);
        }
        catch (Exception)
        {
            d = now.Day;
        }

        // 阳历格式
        String s = context.Request["s"];
        if (!rmp.util.StringUtil.isValidate(s))
        {
            s = "yyyy-MM-dd";
        }

        // 阴历格式
        String l = context.Request["l"];
        if (!rmp.util.StringUtil.isValidate(l))
        {
            l = "GZ年YF月RQ日 肖（SX）";
        }

        DateTime tmp = new DateTime(y, m, d);
        System.Globalization.ChineseLunisolarCalendar clc = new System.Globalization.ChineseLunisolarCalendar();
        if (tmp < clc.MinSupportedDateTime)
        {
            tmp = clc.MinSupportedDateTime;
        }
        else if (tmp > clc.MaxSupportedDateTime)
        {
            tmp = clc.MaxSupportedDateTime;
        }

        context.Response.Write(rmp.wrp.date.Date.ChineseDateM(tmp.Year, tmp.Month, tmp.Day, s, l).InnerXml);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
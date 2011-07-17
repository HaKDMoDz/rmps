<%@ WebHandler Language="C#" Class="card0001" %>

using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;

/// <summary>
/// 图片引用类
/// </summary>
public class card0001 : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        // 卡片名称
        String sid = context.Request[cons.wrp.WrpCons.SID];
        // 用户代码
        String uri = context.Request[cons.wrp.WrpCons.URI];
        if (!rmp.util.StringUtil.isValidateHash(sid) || !rmp.util.StringUtil.isValidateCode(uri))
        {
            return;
        }

        // 读取卡片数据
        rmp.io.db.DBAccess dba = new rmp.io.db.DBAccess();
        dba.addTable(cons.io.db.wrp.WrpCons.W2040100);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2040104, uri);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2040105, sid);
        DataTable dt = dba.executeSelect();

        string path = context.Server.MapPath(string.Format(cons.EnvCons.DIR_DAT + "card/{0}.png", sid));
        Image img = File.Exists(path) ? Image.FromFile(path) : new Bitmap(260, 156);
        Graphics g = Graphics.FromImage(img);

        // 绘制文本
        foreach (DataRow row in dt.Rows)
        {
            g.DrawString(row[cons.io.db.wrp.WrpCons.W2040108] + text(context.Request, row), font(row), brush(row), point(row));
        }
        g.Save();

        // 生成图片
        MemoryStream ms = new MemoryStream();
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        byte[] buf = ms.GetBuffer();
        ms.Close();

        // 写出到客户端
        context.Response.ContentType = "image/png";
        context.Response.OutputStream.Write(buf, 0, buf.Length);
        context.Response.OutputStream.Close();
        context.Response.End();
    }

    /// <summary>
    /// 获取对应的属性
    /// </summary>
    /// <param name="req"></param>
    /// <param name="row">功能键</param>
    /// <returns></returns>
    private static string text(HttpRequest req, DataRow row)
    {
        switch (row[cons.io.db.wrp.WrpCons.W2040106] + "")
        {
            case "aol": return "" + (req.Browser.AOL ? row[cons.io.db.wrp.WrpCons.W2040109] : row[cons.io.db.wrp.WrpCons.W204010A]);
            case "axc": return "" + (req.Browser.ActiveXControls ? row[cons.io.db.wrp.WrpCons.W2040109] : row[cons.io.db.wrp.WrpCons.W204010A]);
            case "beta": return "" + (req.Browser.Beta ? row[cons.io.db.wrp.WrpCons.W2040109] : row[cons.io.db.wrp.WrpCons.W204010A]);
            case "bful": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.Browser.Browser + " " + req.Browser.Version);
            case "bits": return "" + (req.Browser.Win32 ? row[cons.io.db.wrp.WrpCons.W2040109] : (req.Browser.Win16 ? row[cons.io.db.wrp.WrpCons.W204010A] : row[cons.io.db.wrp.WrpCons.W204010B]));
            case "bknd": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.Browser.Type);
            case "bmaj": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.Browser.MajorVersion);
            case "bmin": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.Browser.MinorVersion);
            case "bnam": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.Browser.Browser);
            case "bver": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.Browser.Version);
            case "cae": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.UserAgent);
            case "cfi": return "" + (req.Browser.CanCombineFormsInDeck ? row[cons.io.db.wrp.WrpCons.W2040109] : row[cons.io.db.wrp.WrpCons.W204010A]);
            case "clr": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.Browser.ClrVersion);
            case "cnl": return rmp.wrp.date.Date.ChineseDateD(DateTime.Now, row[cons.io.db.wrp.WrpCons.W2040109] + "");//农历
            case "cpu": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.ServerVariables["HTTP_UA_CPU"] ?? "");
            case "craw": return "" + (req.Browser.Crawler ? row[cons.io.db.wrp.WrpCons.W2040109] : row[cons.io.db.wrp.WrpCons.W204010A]);
            case "css": return "" + (req.Browser.SupportsCss ? row[cons.io.db.wrp.WrpCons.W2040109] : row[cons.io.db.wrp.WrpCons.W204010A]);
            case "cur": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.UrlReferrer);
            case "date": return DateTime.Now.ToString(row[cons.io.db.wrp.WrpCons.W2040109] + "");
            case "esv": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.Browser.EcmaScriptVersion);
            case "ivc": return "" + (req.Browser.CanInitiateVoiceCall ? row[cons.io.db.wrp.WrpCons.W2040109] : row[cons.io.db.wrp.WrpCons.W204010A]);
            case "jsv": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.Browser.JScriptVersion);
            case "mhl": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.Browser.MaximumHrefLength);
            case "mobi": return "" + (req.Browser.IsMobileDevice ? row[cons.io.db.wrp.WrpCons.W2040109] : row[cons.io.db.wrp.WrpCons.W204010A]);
            case "msd": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.Browser.MSDomVersion);
            case "now": return DateTime.Now.ToString(row[cons.io.db.wrp.WrpCons.W2040109] + "");
            case "plat": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.Browser.Platform);
            case "sae": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.ServerVariables["HTTP_ACCEPT_ENCODING"] ?? "");
            case "sbd": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.Browser.ScreenBitDepth);
            case "sbs": return "" + (req.Browser.BackgroundSounds ? row[cons.io.db.wrp.WrpCons.W2040109] : row[cons.io.db.wrp.WrpCons.W204010A]);
            case "scs": return "" + (req.Browser.Cookies ? row[cons.io.db.wrp.WrpCons.W2040109] : row[cons.io.db.wrp.WrpCons.W204010A]);
            case "sfs": return "" + (req.Browser.Frames ? row[cons.io.db.wrp.WrpCons.W2040109] : row[cons.io.db.wrp.WrpCons.W204010A]);
            case "sha": { string ha = req.ServerVariables["HTTP_ACCEPT"]; return "" + (ha == null ? row[cons.io.db.wrp.WrpCons.W204010B] : (ha.IndexOf("wap") > -1 ? row[cons.io.db.wrp.WrpCons.W204010A] : row[cons.io.db.wrp.WrpCons.W2040109])); }
            case "sic": return "" + (req.Browser.IsColor ? row[cons.io.db.wrp.WrpCons.W2040109] : row[cons.io.db.wrp.WrpCons.W204010A]);
            case "sit": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.Browser.InputType);
            case "sja": return "" + (req.Browser.JavaApplets ? row[cons.io.db.wrp.WrpCons.W2040109] : row[cons.io.db.wrp.WrpCons.W204010A]);
            case "sph": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.Browser.ScreenPixelsHeight);
            case "sps": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.Browser.ScreenPixelsWidth, req.Browser.ScreenPixelsHeight);
            case "spw": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.Browser.ScreenPixelsWidth);
            case "sts": return "" + (req.Browser.Tables ? row[cons.io.db.wrp.WrpCons.W2040109] : row[cons.io.db.wrp.WrpCons.W204010A]);
            case "time": return DateTime.Now.ToString(row[cons.io.db.wrp.WrpCons.W2040109] + "");
            case "udt": return row[cons.io.db.wrp.WrpCons.W2040109] + "";
            case "uha": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.UserHostAddress);
            case "uhl": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", rmp.wrp.card.Card.IpLoc(req.UserHostAddress));
            case "uhn": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.UserHostName);
            case "uln": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.UserLanguages[0]);
            case "uos": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", osName(req.UserAgent));
            case "vbs": return "" + (req.Browser.VBScript ? row[cons.io.db.wrp.WrpCons.W2040109] : row[cons.io.db.wrp.WrpCons.W204010A]);
            case "w3c": return string.Format(row[cons.io.db.wrp.WrpCons.W2040109] + "", req.Browser.W3CDomVersion);
            case "week": return (row[cons.io.db.wrp.WrpCons.W2040109] + "").Split(',')[(int)(DateTime.Now.DayOfWeek)];
            case "xml": return "" + (req.Browser.SupportsXmlHttp ? row[cons.io.db.wrp.WrpCons.W2040109] : row[cons.io.db.wrp.WrpCons.W204010A]);
            default: return "";
        }
    }

    private static Font font(DataRow row)
    {
        try
        {
            return new Font(row[cons.io.db.wrp.WrpCons.W204010C] + "", (int)row[cons.io.db.wrp.WrpCons.W204010D] * 3 / 4F, (FontStyle)row[cons.io.db.wrp.WrpCons.W204010F]);
        }
        catch (Exception)
        {
            return new Font(FontFamily.GenericMonospace, 9F, FontStyle.Regular);
        }
    }

    private static Brush brush(DataRow row)
    {
        try
        {
            return new SolidBrush(Color.FromArgb(Convert.ToInt32("FF" + row[cons.io.db.wrp.WrpCons.W204010E], 16)));
        }
        catch (Exception)
        {
            return new SolidBrush(Color.Black);
        }
    }

    private static PointF point(DataRow row)
    {
        try
        {
            return new PointF((int)row[cons.io.db.wrp.WrpCons.W2040110], (int)row[cons.io.db.wrp.WrpCons.W2040111]);
        }
        catch (Exception)
        {
            return new PointF(10, 10);
        }
    }

    /// <summary>
    /// 根据 User Agent 获取操作系统名称
    /// </summary>
    private static string osName(string userAgent)
    {
        if (userAgent.Contains("NT 6.0"))
        {
            return "Windows Vista/Server 2008";
        }
        if (userAgent.Contains("NT 5.2"))
        {
            return "Windows Server 2003";
        }
        if (userAgent.Contains("NT 5.1"))
        {
            return "Windows XP";
        }
        if (userAgent.Contains("NT 5"))
        {
            return "Windows 2000";
        }
        if (userAgent.Contains("NT 4"))
        {
            return "Windows NT4";
        }
        if (userAgent.Contains("Me"))
        {
            return "Windows Me";
        }
        if (userAgent.Contains("98"))
        {
            return "Windows 98";
        }
        if (userAgent.Contains("95"))
        {
            return "Windows 95";
        }
        if (userAgent.Contains("Mac"))
        {
            return "Mac";
        }
        if (userAgent.Contains("Unix"))
        {
            return "UNIX";
        }
        if (userAgent.Contains("Linux"))
        {
            return "Linux";
        }
        if (userAgent.Contains("SunOS"))
        {
            return "SunOS";
        }
        return "未知";
    }

    /// <summary>
    /// 
    /// </summary>
    public bool IsReusable
    {
        get
        {
            return true;
        }
    }

}
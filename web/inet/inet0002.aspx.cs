using System;
using System.Data;
using System.Text;
using System.Threading;
using System.Web.UI;

using cons.wrp;
using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp.inet;

/// <summary>
/// 网页精灵链接打开页面
/// </summary>
public partial class inet_inet0002 : Page
{
    private String sid;
    private String t;
    private String u;
    private String d;
    private String f;
    private String i;
    private String ip;
    private String ua;
    private String bn;
    private String os;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        // 键值参数处理
        sid = WrpUtil.text2Db(Request[WrpCons.SID]);
        if (!StringUtil.isValidate(sid, 16))
        {
            ShowPage("<script type=\"text/javascript\">alert('页面载入出错：页面传入参数不合法！');window.close();</script>");
            return;
        }

        #region 用户参数处理
        //来源页面标题
        t = Request["t"] ?? "";
        ht.Value = t;

        //来源页面路径
        u = Request["u"] ?? "";
        hu.Value = u;

        //来源页面概要
        d = Request["d"] ?? "";
        hd.Value = d;

        // 流量统计用户
        f = Request["f"] ?? "";

        // 用户上次打开TAB
        i = Request["i"] ?? "0";

        // hp 目标页面路径
        // hx 字符转换方式
        // hk 窗口操作方式

        // 用户浏览器信息
        ip = Request.UserHostAddress;
        ua = Request.UserAgent;
        bn = Request.Browser.Browser;
        os = Request.Browser.Platform;
        #endregion

        // 查询缓存数据
        K1V2 item = Inet.GetInetItem(sid);
        if (item == null)
        {
            item = new K1V2("http://amonsoft.net/", "encodeURIComponent", "iNetHelper_90wmi");

            // 查询条件拼接
            DBAccess dba = new DBAccess();
            dba.addTable(cons.io.db.wrp.WrpCons.W2019100);
            dba.addColumn(cons.io.db.wrp.WrpCons.W2019108);
            dba.addColumn(cons.io.db.wrp.WrpCons.W2019109);
            dba.addColumn(cons.io.db.wrp.WrpCons.W2019104);
            dba.addWhere(cons.io.db.wrp.WrpCons.W2019102, sid);

            // 查询链接地址，并进行相应的编码转换
            DataTable dt = dba.executeSelect();
            if (dt.Rows.Count > 0)
            {
                item.K = dt.Rows[0][cons.io.db.wrp.WrpCons.W2019108].ToString();
                item.V1 = dt.Rows[0][cons.io.db.wrp.WrpCons.W2019109].ToString();
                item.V2 = dt.Rows[0][cons.io.db.wrp.WrpCons.W2019104].ToString();
            }
            dt.Dispose();

            // 缓冲数据
            Inet.SetInetItem(sid, item);
        }

        // 显示路径及编码信息
        hp.Value = item.K;
        String x = item.V1;
        if (x.StartsWith("decode"))
        {
            x = x.Substring(6);
            ht.Value = WrpUtil.EncodeText(ht.Value, x);
            hd.Value = WrpUtil.EncodeText(hd.Value, x);
            x = "";
        }
        hx.Value = x;
        if (item.V2 == "iNetHelper_90wmi")
        {
            hk.Value = "1";
        }

        // 启动统计线程
        Thread thread = new Thread(Statistics);
        thread.Start();
    }

    /// <summary>
    /// 显示HTML文本
    /// </summary>
    /// <param name="text"></param>
    private void ShowPage(String text)
    {
        Response.ContentType = "text/html";
        Response.ContentEncoding = Encoding.UTF8;
        Response.Write("<html xmlns=\"http://www.w3.org/1999/xhtml\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><title>网页精灵</title></head><body>");
        Response.Write(text);
        Response.Write("</body></html>");
        Response.Flush();
        Response.End();
    }

    /// <summary>
    /// 统计线程
    /// </summary>
    private void Statistics()
    {
        DBAccess dba = new DBAccess();

        #region 用户访问数据日志
        f = WrpUtil.text2Db(f.Trim());
        bool b = StringUtil.isValidate(f, 8);
        if (!b)
        {
            b = StringUtil.isValidate(f, 4) && f.ToLower()[0] == 't';
        }
        dba.addTable(cons.io.db.wrp.WrpCons.W2012100);
        dba.addParam(cons.io.db.wrp.WrpCons.W2012101, HashUtil.getCurrTimeHex(false));
        dba.addParam(cons.io.db.wrp.WrpCons.W2012102, b ? f : "A0000000");
        dba.addParam(cons.io.db.wrp.WrpCons.W2012103, cons.EnvCons.SQL_NOW, false);
        dba.addParam(cons.io.db.wrp.WrpCons.W2012104, sid);
        dba.addParam(cons.io.db.wrp.WrpCons.W2012105, WrpUtil.text2Db(t));
        dba.addParam(cons.io.db.wrp.WrpCons.W2012106, WrpUtil.text2Db(u));
        dba.addParam(cons.io.db.wrp.WrpCons.W2012107, WrpUtil.text2Db(d));
        dba.addParam(cons.io.db.wrp.WrpCons.W2012108, WrpUtil.text2Db(ip));
        dba.addParam(cons.io.db.wrp.WrpCons.W2012109, WrpUtil.text2Db(ua));
        dba.addParam(cons.io.db.wrp.WrpCons.W201210A, WrpUtil.text2Db(bn));
        dba.addParam(cons.io.db.wrp.WrpCons.W201210B, WrpUtil.text2Db(os));
        dba.executeInsert();
        #endregion

        #region 使用频率
        // 使用频率更新
        dba.UpdateStep(cons.io.db.wrp.WrpCons.W2019100, cons.io.db.wrp.WrpCons.W2019102, sid, cons.io.db.wrp.WrpCons.W2019101, 1);
        if (b)
        {
            dba.UpdateStep(cons.io.db.wrp.WrpCons.W2011100,
                           new string[] { cons.io.db.wrp.WrpCons.W2011105, cons.io.db.wrp.WrpCons.W2011104 },
                           new string[] { f, sid },
                           cons.io.db.wrp.WrpCons.W2011101,
                           1);
        }
        #endregion

        // 记录用户偏好
        try
        {
            Inet.SetUserFav(f, int.Parse(i));
        }
        catch (Exception)
        {
        }
    }
}

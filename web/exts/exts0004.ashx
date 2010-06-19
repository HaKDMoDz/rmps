<%@ WebHandler Language="C#" Class="exts0004" %>

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using cons.wrp;
using rmp.io.db;
using rmp.util;

public class exts0004 : IHttpHandler
{
    #region IHttpHandler Members
    /// <summary>
    /// 垂直填充
    /// </summary>
    private const int PADDING_HEIGHT = 20;

    /// <summary>
    /// 水平填充
    /// </summary>
    private const int PADDING_WIDTH = 20;

    private readonly Color BACK_COLOR = Color.White;
    private readonly Color GRID_COLOR = Color.LightGray;
    private readonly Color TEXT_COLOR = Color.DarkGray;

    /// <summary>
    /// 行高对应单位
    /// </summary>
    private int CellUnit = 1;

    /// <summary>
    /// 列起点偏移量
    /// </summary>
    private int ColInit;

    /// <summary>
    /// 行起点偏移量
    /// </summary>
    private int RowInit;

    /// <summary>
    /// 行高
    /// </summary>
    private int RowUnit;

    public void ProcessRequest(HttpContext context)
    {
        string sid = WrpUtil.text2Db(context.Request[WrpCons.SID]);
        string uri = WrpUtil.text2Db(context.Request[WrpCons.URI]);
        if (!StringUtil.isValidate(sid) || !StringUtil.isValidate(uri))
        {
            return;
        }

        string param = context.Request["w"];
        int w;
        try
        {
            w = StringUtil.isValidate(param) ? int.Parse(param) : 300;
        }
        catch (Exception)
        {
            w = 300;
        }
        param = context.Request["h"];
        int h;
        try
        {
            h = StringUtil.isValidate(param) ? int.Parse(param) : 200;
        }
        catch (Exception)
        {
            h = 200;
        }

        DBAccess dba = new DBAccess();
        dba.addTable(uri);
        dba.addColumn(cons.io.db.prp.PrpCons.P3010701);
        dba.addWhere(cons.io.db.prp.PrpCons.P3010703, sid);

        // 图像内容存储
        Bitmap bmp = new Bitmap(w, h);
        DrawGrid(bmp, 10);
        MemoryStream stream = new MemoryStream((w * h) << 2);
        bmp.Save(stream, ImageFormat.Png);

        // 输出到客户端
        context.Response.ContentType = "image/png";
        context.Response.BinaryWrite(stream.ToArray());
        stream.Close();
        context.Response.End();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bmp"></param>
    /// <param name="n">数量</param>
    private void DrawGrid(Image bmp, int n)
    {
        n += n + 1;

        Graphics g = Graphics.FromImage(bmp);

        // 绘制工具初始化
        Brush b = new SolidBrush(TEXT_COLOR);
        Pen p = new Pen(GRID_COLOR, 0.1F);
        Font f = new Font("Fixedsys", 9);

        // 图像面板初始化
        g.Clear(BACK_COLOR);
        g.SmoothingMode = SmoothingMode.HighQuality; //高质量
        g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量

        // 绘制变量初始化
        RowInit = bmp.Height - PADDING_HEIGHT; //行起点偏移量
        RowUnit = (RowInit - PADDING_HEIGHT) / n; //行高
        ColInit = PADDING_WIDTH; //列起点偏移量

        CellUnit = CellUnit / 10 + 1;

        g.DrawLine(p, ColInit, PADDING_HEIGHT, ColInit, RowInit);
        g.DrawLine(p, ColInit, RowInit, bmp.Width - ColInit, RowInit);
        RowInit -= (RowUnit << 1);

        // 绘制进制横线
        int RowStep = RowInit; // 绘制过程中行高偏移量
        while (RowStep > PADDING_HEIGHT)
        {
            g.FillRectangle(b, ColInit, RowStep, 100, RowUnit);
            g.DrawString("测试", f, b, 120, RowStep);
            RowStep -= (RowUnit << 1);
        }

        g.Save();
        g.Dispose();
    }

    public bool IsReusable
    {
        get { return true; }
    }

    #endregion
}
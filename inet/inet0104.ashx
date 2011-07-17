<%@ WebHandler Language="C#" Class="inet0104" %>

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;

using cons.io.db.wrp;

using rmp.io.db;
using rmp.util;

public class inet0104 : IHttpHandler
{
    /// <summary>
    /// 图像宽度
    /// </summary>
    private const int IMAGE_WIDTH = 460;
    /// <summary>
    /// 图像高度
    /// </summary>
    private const int IMAGE_HEIGHT = 260;
    /// <summary>
    /// 水平填充
    /// </summary>
    private const int PADDING_WIDTH = 20;
    /// <summary>
    /// 垂直填充
    /// </summary>
    private const int PADDING_HEIGHT = 20;

    private readonly Color BACK_COLOR = Color.White;
    private readonly Color GRID_COLOR = Color.LightGray;
    private readonly Color TEXT_COLOR = Color.DarkGray;
    private readonly Color PV_COLOR = Color.Red;
    private readonly Color IP_COLOR = Color.Blue;

    /// <summary>
    /// 行起点偏移量
    /// </summary>
    private int RowInit;
    /// <summary>
    /// 行高
    /// </summary>
    private int RowUnit;
    /// <summary>
    /// 列起点偏移量
    /// </summary>
    private int ColInit;
    /// <summary>
    /// 列宽
    /// </summary>
    private int ColUnit;
    /// <summary>
    /// 行高对应单位
    /// </summary>
    private int CellUnit = 1;

    public void ProcessRequest(HttpContext context)
    {
        String sid = WrpUtil.text2Db(context.Request[cons.wrp.WrpCons.SID]);
        bool isUser = StringUtil.isValidate(sid, 8) || (StringUtil.isValidate(sid, 4) && sid.ToLower()[0] == 't');

        DateTime now = DateTime.Now;
        DateTime old = now.AddDays(-30);

        // 创建内在图像
        Bitmap map = new Bitmap(IMAGE_WIDTH, IMAGE_HEIGHT);
        Graphics g = Graphics.FromImage(map);

        #region 读取流量数据
        Dictionary<String, int> pv = new Dictionary<string, int>();
        Dictionary<String, int> ip = new Dictionary<string, int>();
        if (isUser)
        {
            DBAccess dba = new DBAccess();

            // 查询日期内的数据
            StringBuilder sqlSelect = new StringBuilder();
            sqlSelect.Append("SELECT");
            sqlSelect.Append("       COUNT(").Append(WrpCons.W2012103).Append(")                AS pv,");
            sqlSelect.Append("       COUNT(DISTINCT(").Append(WrpCons.W2012108).Append("))       AS IP,");
            sqlSelect.Append("       DATE_FORMAT(").Append(WrpCons.W2012103).Append(", '%m-%d') AS days");
            sqlSelect.Append("  FROM ").Append(WrpCons.W2012100);
            sqlSelect.Append(" WHERE DATE_FORMAT(").Append(WrpCons.W2012103).Append(", '%Y-%m-%d') >= '").Append(old.ToString("yyyy-MM-dd")).Append("'");
            if (sid != "00000001")
            {
                sqlSelect.Append("   AND ").Append(WrpCons.W2012102).Append("='").Append(sid).Append("'");
            }
            sqlSelect.Append(" GROUP BY days");
            DataTable dataList = dba.executeSelect(sqlSelect.ToString());

            // 取出所有数据，并计算最数据
            int tmp;
            foreach (DataRow row in dataList.Rows)
            {
                // PV统计
                try
                {
                    tmp = int.Parse(row["pv"].ToString());
                }
                catch (Exception)
                {
                    tmp = 0;
                }
                if (CellUnit < tmp)
                {
                    CellUnit = tmp;
                }
                pv[row["days"].ToString()] = tmp;

                // IP统计
                try
                {
                    tmp = int.Parse(row["ip"].ToString());
                }
                catch (Exception)
                {
                    tmp = 0;
                }
                ip[row["days"].ToString()] = tmp;
            }
        }
        #endregion

        // 绘制单位表格
        DrawGrid(g, old, now);

        // 绘制流量曲线
        if (isUser)
        {
            // PV曲线
            Pen p = new Pen(PV_COLOR);
            DrawStat(g, p, pv, old, now);
            // IP曲线
            p.Color = IP_COLOR;
            DrawStat(g, p, ip, old, now);
        }

        // 图像内容存储
        g.Save();
        g.Dispose();
        MemoryStream stream = new MemoryStream(IMAGE_WIDTH * IMAGE_HEIGHT);
        map.Save(stream, ImageFormat.Png);

        // 输出到客户端
        context.Response.ContentType = "image/png";
        context.Response.BinaryWrite(stream.ToArray());
        stream.Close();
        context.Response.End();
    }

    /// <summary>
    /// 绘制单位表格
    /// </summary>
    /// <param name="g">Graphics对象</param>
    /// <param name="old">起始时间</param>
    /// <param name="now">结束时间</param>
    private void DrawGrid(Graphics g, DateTime old, DateTime now)
    {
        // 绘制工具初始化
        Brush b = new SolidBrush(TEXT_COLOR);
        Pen p = new Pen(GRID_COLOR, 0.1F);
        Font f = new Font("Fixedsys", 9);

        // 图像面板初始化
        g.Clear(BACK_COLOR);
        g.SmoothingMode = SmoothingMode.HighQuality; //高质量
        g.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量

        // 绘制变量初始化
        RowInit = IMAGE_HEIGHT - PADDING_HEIGHT;//行起点偏移量
        RowUnit = (RowInit - PADDING_HEIGHT) / 10;//行高
        ColInit = PADDING_WIDTH + (int)g.MeasureString(CellUnit.ToString(), f).Width;//列起点偏移量
        ColUnit = (IMAGE_WIDTH - ColInit - PADDING_WIDTH) / 30;//列宽

        CellUnit = CellUnit / 10 + 1;
        int t = 0;// 计数变量
        String s;// 字符变量
        SizeF d;// 字体变量

        // 绘制进制横线
        int RowStep = RowInit;// 绘制过程中行高偏移量
        while (RowStep >= PADDING_HEIGHT)
        {
            // 绘制单位
            s = t.ToString();
            d = g.MeasureString(s, f);
            g.DrawString(s, f, b, ColInit - d.Width - 2, RowStep - d.Height);

            // 绘制横线
            g.DrawLine(p, ColInit - 2, RowStep, IMAGE_WIDTH - PADDING_WIDTH, RowStep);
            RowStep -= RowUnit;
            t += CellUnit;
        }

        d = g.MeasureString("MM-dd", f);
        d.Width = d.Width / 2;
        t = 0;

        // 绘制单位横线
        int ColStep = ColInit;// 绘制过程中列宽偏移量
        while (old <= now)
        {
            s = old.ToString("MM-dd");

            // 绘制竖线
            g.DrawLine(p, ColStep, PADDING_HEIGHT, ColStep, RowInit);

            // 绘制单位
            if (t % 5 == 0)
            {
                g.DrawString(s, f, b, ColStep - d.Width, RowInit);
                p.Color = TEXT_COLOR;
                g.DrawRectangle(p, ColStep - 1, RowInit - 1, 2, 2);
                p.Color = GRID_COLOR;
            }
            ColStep += ColUnit;
            old = old.AddDays(1);
            t += 1;
        }

        // 绘制标题
        s = "PV曲线";
        d = g.MeasureString(s, f);
        RowStep = PADDING_HEIGHT - (int)d.Height - 2;
        ColStep = PADDING_HEIGHT >> 1;

        t = ColInit + 10;
        g.DrawString(s, f, b, t + 20, RowStep);
        p.Color = PV_COLOR;
        g.DrawLine(p, t, ColStep, t + 20, ColStep);

        s = "IP曲线";
        t += (int)d.Width + 30;
        g.DrawString(s, f, b, t + 20, RowStep);
        p.Color = IP_COLOR;
        g.DrawLine(p, t, ColStep, t + 20, ColStep);
    }

    /// <summary>
    /// 绘制流量曲线
    /// </summary>
    /// <param name="g">Graphics对象</param>
    /// <param name="pen">绘制工具对象</param>
    /// <param name="dat">统计数据列表</param>
    /// <param name="old">起始时间</param>
    /// <param name="now">结束时间</param>
    private void DrawStat(Graphics g, Pen pen, IDictionary<string, int> dat, DateTime old, DateTime now)
    {
        float r = RowUnit / (float)CellUnit;

        //绘制曲线
        String s = old.ToString("MM-dd");// 要绘制的标量文本信息
        int t = dat.ContainsKey(s) ? dat[s] : 0;

        old = old.AddDays(1);
        float x1 = ColInit;
        float y1 = RowInit - t * r;

        // 绘制流量曲线
        float x2;
        float y2;
        while (old <= now)
        {
            s = old.ToString("MM-dd");
            t = dat.ContainsKey(s) ? dat[s] : 0;

            //绘制曲线
            x2 = x1 + ColUnit;
            y2 = RowInit - t * r;
            g.DrawLine(pen, x1, y1, x2, y2);

            old = old.AddDays(1);
            x1 = x2;
            y1 = y2;
        }
    }

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }

}
<%@ WebHandler Language="C#" Class="inet0003" %>

using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Web;
using rmp.util;

/// <summary>
/// 日历背景
/// </summary>
public class inet0003 : IHttpHandler
{
    #region IHttpHandler Members

    public void ProcessRequest(HttpContext context)
    {
        // 图像宽度
        string param = context.Request["w"];
        int w = StringUtil.isValidate(param) ? int.Parse(param) : 160;
        // 图像高度
        param = context.Request["h"];
        int h = StringUtil.isValidate(param) ? int.Parse(param) : 60;

        Image img = new Bitmap(w, h);

        // 绘制文本
        string t = context.Request["t"];
        if (!string.IsNullOrEmpty(t))
        {
            // 字体颜色
            param = context.Request["c"];
            long c = StringUtil.isValidate(param) ? long.Parse(param, NumberStyles.HexNumber) : -1;
            // 字体大小
            param = context.Request["s"];
            float s = StringUtil.isValidate(param) ? float.Parse(param) : 20f;

            if (c >= 0x80000000)
            {
                c -= 0x100000000;
            }
            DrawText(img, w, h, t, (int)c, s);
        }

        MemoryStream ms = new MemoryStream(w * h * 4);
        img.Save(ms, ImageFormat.Png);
        byte[] b = ms.GetBuffer();
        ms.Close();

        context.Response.ContentType = "image/png";
        context.Response.OutputStream.Write(b, 0, b.Length);
        context.Response.End();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="w">图像宽度</param>
    /// <param name="h">图像高度</param>
    /// <param name="t">绘制文本</param>
    /// <param name="c">字体颜色</param>
    /// <param name="s">字体大小</param>
    private static void DrawText(Image m, int w, int h, string t, int c, float s)
    {
        Graphics g = Graphics.FromImage(m);
        Font f = new Font("Arial Black", s, FontStyle.Italic);
        SizeF z = g.MeasureString(t, f);
        g.DrawString(t, f, new SolidBrush(Color.FromArgb(c)), (m.Width - z.Width) / 2, (m.Height - z.Height) / 2);
        g.Save();
    }

    public bool IsReusable
    {
        get { return true; }
    }

    #endregion
}
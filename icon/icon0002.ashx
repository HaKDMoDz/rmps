<%@ WebHandler Language="C#" Class="icon0002" %>

using System;
using System.Web;

/// <summary>
/// 图像处理器，用于加水印显示软件运行截图、操作系统截图等。
/// </summary>
public class icon0002 : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/png";

        // 图像索引
        String sid = (context.Request[cons.wrp.WrpCons.SID] ?? "").Trim();

        String dir = HttpContext.Current.Server.MapPath(cons.EnvCons.DIR_DAT);
        if (!rmp.util.StringUtil.isValidatePath(sid))
        {
            sid = "comn,0";
        }
        sid = dir + sid.Replace(',', System.IO.Path.DirectorySeparatorChar) + ".png";
        if (!System.IO.File.Exists(sid))
        {
            sid = dir + "comn,0.png".Replace(',', System.IO.Path.DirectorySeparatorChar);
        }

        // 读取图像
        System.IO.Stream stream = System.IO.File.OpenRead(sid);
        System.Drawing.Image sImage = System.Drawing.Image.FromStream(stream);
        stream.Close();

        // 绘制版权图像
        System.Drawing.Image cImage = rmp.wrp.Wrps.MarkImage;
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(sImage);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        g.DrawImage(cImage, new System.Drawing.Rectangle(sImage.Width - cImage.Width, sImage.Height - cImage.Height, cImage.Width, cImage.Height), 0, 0, cImage.Width, cImage.Height, System.Drawing.GraphicsUnit.Pixel);
        g.Save();
        g.Dispose();

        // 输出到客户端
        System.IO.MemoryStream ms = new System.IO.MemoryStream(sImage.Width * sImage.Height * 4);
        sImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        byte[] b = ms.GetBuffer();
        stream = context.Response.OutputStream;
        stream.Write(b, 0, b.Length);
        stream.Flush();
        stream.Close();
        ms.Close();

        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
}
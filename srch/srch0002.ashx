<%@ WebHandler Language="C#" Class="srch0002" %>

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using rmp.util;

/// <summary>
/// 搜索引擎图片
/// </summary>
public class srch0002 : IHttpHandler
{
    /// <summary>
    /// 图片路径
    /// </summary>
    private static string PATH;

    public void ProcessRequest(HttpContext context)
    {
        if (PATH == null)
        {
            PATH = context.Server.MapPath(cons.wrp.srch.SrchCons.SRCH_ICON_PATH);
        }

        // 图片ID
        string sid = WrpUtil.text2Db(context.Request[cons.wrp.WrpCons.SID]);
        if (!StringUtil.isValidateHash(sid))
        {
            sid = "0";
        }

        // 读取图片
        Image img = Image.FromFile(string.Format("{0}{1}.png", PATH, sid));
        MemoryStream ms = new MemoryStream(img.Width * img.Height * 4);
        img.Save(ms, ImageFormat.Png);
        byte[] b = ms.GetBuffer();
        ms.Close();

        context.Response.ContentType = "image/png";
        context.Response.OutputStream.Write(b, 0, b.Length);
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
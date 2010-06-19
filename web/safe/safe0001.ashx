<%@ WebHandler Language="C#" Class="safe0001" %>

using System;

public class safe0001 : System.Web.IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

    public void ProcessRequest(System.Web.HttpContext context)
    {
        context.Response.ContentType = "image/jpeg";

        String sid = (context.Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        if (rmp.util.StringUtil.isValidate(sid, 32))
        {
            try
            {
                rmp.comn.safe.AuthIcon auth = new rmp.comn.safe.AuthIcon();
                auth.AuthCode = rmp.comn.safe.Safe.GetAuthCode(sid);
                System.Drawing.Image image = auth.GetAuthIcon();
                image.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                image.Dispose();
            }
            catch (Exception e)
            {
                context.Response.Write(e.Message);
            }
        }
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
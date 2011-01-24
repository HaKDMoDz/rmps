<%@ WebHandler Language="C#" Class="code0001" %>

using System;
using System.Web;

public class code0001 : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        #region 语言判断
        String lang = rmp.util.WrpUtil.text2Db(context.Request["l"]);
        if (!rmp.util.StringUtil.isValidate(lang))
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("msg:请选择代码语言！");
            context.Response.End();
            return;
        }
        #endregion

        #region 源代码判断
        String text = context.Request["c"] ?? "";
        if (text == null || text.Length < 1)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("msg:请输入您的源代码！");
            context.Response.End();
            return;
        }
        #endregion

        rmp.wrp.code.UserOpt userOpt = new rmp.wrp.code.UserOpt();
        userOpt.ShowLineNbr = ("1" == context.Request["n"]);
        userOpt.InLineStyle = ("1" == context.Request["i"]);
        userOpt.ShowLinkUri = ("1" == context.Request["u"]);
        userOpt.TagStyle = (context.Request["t"] ?? "").Trim();
        userOpt.Language = lang;

        #region 制表符判断
        String tab = (context.Request["s"] ?? "").Trim();
        if (rmp.util.StringUtil.isValidateLong(tab))
        {
            userOpt.TabCount = int.Parse(tab);
            if (userOpt.TabCount < 1)
            {
                userOpt.TabCount = 1;
            }
            if (userOpt.TabCount > 8)
            {
                userOpt.TabCount = 8;
            }
        }
        #endregion

        String opt = (context.Request["o"] ?? "").Trim().ToLower();

        try
        {
            context.Response.ContentType = "text/" + (opt == "html" ? "html" : "plain");
            context.Response.Write(new rmp.wrp.code.GenHtml(text, userOpt).ToHtml());
        }
        catch (Exception exp)
        {
            context.Response.Write("msg:" + exp.Message);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
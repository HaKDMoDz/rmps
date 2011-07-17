<%@ WebHandler Language="C#" Class="inet0106" %>

using System.Text;
using System.Web;
using System.Web.SessionState;
using rmp.comn.user;

public class inet0106 : IHttpHandler, IRequiresSessionState
{
    #region IHttpHandler Members

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/xml";
        context.Response.ContentEncoding = Encoding.UTF8;

        #region XML
        StringBuilder xmlBuf = new StringBuilder();
        xmlBuf.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        xmlBuf.Append("<openServiceDescription xmlns=\"http://www.microsoft.com/schemas/openservicedescription/1.0\">");
        xmlBuf.Append("  <homepageUrl>http://amonsoft.net/</homepageUrl>");
        xmlBuf.Append("  <display>");
        xmlBuf.Append("    <name>Amon网页精灵</name>");
        xmlBuf.Append("    <icon>http://amonsoft.net/favicon.ico</icon>");
        xmlBuf.Append("    <description>Amon网页精灵，您的网络冲浪助手！</description>");
        xmlBuf.Append("  </display>");
        xmlBuf.Append("  <activity category=\"Share\">");

        xmlBuf.Append("    <activityAction context=\"selection\">");
        xmlBuf.Append("      <preview method=\"post\" accept-charset=\"UTF-8\" action=\"http://amonsoft.net/inet/inet0001.ashx\">");
        xmlBuf.Append("        <parameter name=\"f\" value=\"").Append(UserInfo.Current(context.Session).UserCode).Append("\" />");
        //xmlBuf.Append("        <parameter name=\"i\" value=\"1\" />");
        xmlBuf.Append("        <parameter name=\"h\" value=\"238\" />");
        xmlBuf.Append("        <parameter name=\"w\" value=\"314\" />");
        xmlBuf.Append("        <parameter name=\"t\" value=\"{documentTitle}\" />");
        xmlBuf.Append("        <parameter name=\"u\" value=\"{documentUrl}\" />");
        xmlBuf.Append("        <parameter name=\"d\" value=\"{selection}\" />");
        xmlBuf.Append("      </preview>");
        xmlBuf.Append("      <execute method=\"post\" accept-charset=\"UTF-8\" action=\"http://amonsoft.net/inet/inet0001.aspx\" >");
        xmlBuf.Append("        <parameter name=\"f\" value=\"").Append(UserInfo.Current(context.Session).UserCode).Append("\" />");
        xmlBuf.Append("        <parameter name=\"t\" value=\"{documentTitle}\" />");
        xmlBuf.Append("        <parameter name=\"u\" value=\"{documentUrl}\" />");
        xmlBuf.Append("        <parameter name=\"d\" value=\"{selection}\" />");
        xmlBuf.Append("      </execute>");
        xmlBuf.Append("    </activityAction>");

        xmlBuf.Append("    <activityAction context=\"link\">");
        xmlBuf.Append("      <preview method=\"post\" accept-charset=\"UTF-8\" action=\"http://amonsoft.net/inet/inet0001.ashx\">");
        xmlBuf.Append("        <parameter name=\"f\" value=\"").Append(UserInfo.Current(context.Session).UserCode).Append("\" />");
        //xmlBuf.Append("        <parameter name=\"i\" value=\"1\" />");
        xmlBuf.Append("        <parameter name=\"h\" value=\"238\" />");
        xmlBuf.Append("        <parameter name=\"w\" value=\"314\" />");
        xmlBuf.Append("        <parameter name=\"t\" value=\"{linkText}\" />");
        xmlBuf.Append("        <parameter name=\"u\" value=\"{link}\" />");
        xmlBuf.Append("        <parameter name=\"d\" value=\"{selection}\" />");
        xmlBuf.Append("      </preview>");
        xmlBuf.Append("      <execute method=\"post\" accept-charset=\"UTF-8\" action=\"http://amonsoft.net/inet/inet0001.aspx\" >");
        xmlBuf.Append("        <parameter name=\"f\" value=\"").Append(UserInfo.Current(context.Session).UserCode).Append("\" />");
        xmlBuf.Append("        <parameter name=\"t\" value=\"{linkText}\" />");
        xmlBuf.Append("        <parameter name=\"u\" value=\"{link}\" />");
        xmlBuf.Append("        <parameter name=\"d\" value=\"{selection}\" />");
        xmlBuf.Append("      </execute>");
        xmlBuf.Append("    </activityAction>");

        xmlBuf.Append("    <activityAction context=\"document\">");
        xmlBuf.Append("      <preview method=\"post\" accept-charset=\"UTF-8\" action=\"http://amonsoft.net/inet/inet0001.ashx\">");
        xmlBuf.Append("        <parameter name=\"f\" value=\"").Append(UserInfo.Current(context.Session).UserCode).Append("\" />");
        //xmlBuf.Append("        <parameter name=\"i\" value=\"1\" />");
        xmlBuf.Append("        <parameter name=\"h\" value=\"238\" />");
        xmlBuf.Append("        <parameter name=\"w\" value=\"314\" />");
        xmlBuf.Append("        <parameter name=\"t\" value=\"{documentTitle}\" />");
        xmlBuf.Append("        <parameter name=\"u\" value=\"{documentUrl}\" />");
        xmlBuf.Append("        <parameter name=\"d\" value=\"{selection}\" />");
        xmlBuf.Append("      </preview>");
        xmlBuf.Append("      <execute method=\"post\" accept-charset=\"UTF-8\" action=\"http://amonsoft.net/inet/inet0001.aspx\" >");
        xmlBuf.Append("        <parameter name=\"f\" value=\"").Append(UserInfo.Current(context.Session).UserCode).Append("\" />");
        xmlBuf.Append("        <parameter name=\"t\" value=\"{documentTitle}\" />");
        xmlBuf.Append("        <parameter name=\"u\" value=\"{documentUrl}\" />");
        xmlBuf.Append("        <parameter name=\"d\" value=\"{selection}\" />");
        xmlBuf.Append("      </execute>");
        xmlBuf.Append("    </activityAction>");

        xmlBuf.Append("  </activity>");
        xmlBuf.Append("</openServiceDescription>");
        #endregion

        context.Response.Write(xmlBuf.ToString());
        context.Response.End();
    }

    public bool IsReusable
    {
        get { return true; }
    }

    #endregion
}
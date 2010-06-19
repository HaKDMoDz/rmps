using System;
using System.Web.UI;

using rmp.comn.user;
using rmp.util;

public partial class App_Ascx_AmonHead : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserInfo ui = UserInfo.Current(Session);
        bool b = StringUtil.isValidate(ui.UserHash, 16);
        lb_SignOs.Visible = b;
        lb_SignOs.ToolTip = "您已登录为：" + ui.UserName;
        hl_SignIn.Visible = !b;

        if (IsPostBack)
        {
            return;
        }

        im_AmonLogo.ImageUrl = string.Format("~/_styles/{0}/images/logo.png", (Session[cons.wrp.WrpCons.USERSKIN] + "" ?? "0000").Trim().PadLeft(4, '0'));
        lb_AmonUser.Text = string.Format("您好，{0}！", ui.UserName);
    }

    protected void lb_SignOs_Click(object sender, EventArgs e)
    {
        UserInfo.Current(Session).signOs();
        lb_SignOs.Visible = false;
        hl_SignIn.Visible = true;
        Response.Redirect("~/");
    }
}

using System;
using System.Web.UI;

public partial class exts_exts : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        rmp.comn.user.UserInfo ui = rmp.comn.user.UserInfo.Current(Session);
        bool b = rmp.util.StringUtil.isValidate(ui.UserHash, 16);
        lb_SignOs.Visible = b;
        lb_SignOs.ToolTip = "您已登录为：" + ui.UserName;
        hl_SignIn.Visible = !b;

        // 页面事件交互状态不进行后面的处理
        if (IsPostBack)
        {
            return;
        }

        im_AmonLogo.ImageUrl = string.Format("~/_styles/{0}/images/exts.png", (Session[cons.wrp.WrpCons.USERSKIN] + "" ?? "0000").Trim().PadLeft(4, '0'));
        lb_AmonUser.Text = string.Format("您好，{0}！", ui.UserName);
        pl_Edit.Visible = ui.UserRank > cons.comn.user.UserInfo.LEVEL_01;
    }

    protected void lb_SignOs_Click(object sender, EventArgs e)
    {
        rmp.comn.user.UserInfo.Current(Session).signOs();
        lb_SignOs.Visible = false;
        hl_SignIn.Visible = true;
        Response.Redirect("~/");
    }
}

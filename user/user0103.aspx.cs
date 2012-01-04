using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.comn.user;
using rmp.wrp;

public partial class user_user0103 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_01)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        #region Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "口令修改";
        Session[cons.wrp.WrpCons.SCRIPTID] = "user0103";

        List<K1V2> guidList = Wrps.GuidUser(Session);
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/user/user0103.aspx";
        guidItem.V1 = "口令修改";
        guidItem.V2 = "口令修改";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;
        #endregion

        tr_ErrMsg.Attributes.Add("style", "display: none;");

        if (IsPostBack)
        {
            return;
        }

        bt_Change.Enabled = UserInfo.Current(Session).UserCode != cons.comn.user.UserInfo.DEMO_CODE;
    }

    protected void bt_Change_Click(object sender, EventArgs e)
    {
        String oldPwds = pf_OldPwds.Text;
        if (string.IsNullOrEmpty(oldPwds))
        {
            lb_ErrMsg.Text = "请输入【现有口令】！";
            tr_ErrMsg.Attributes.Add("style", "display:;");
            pf_OldPwds.Focus();
            return;
        }
        if (oldPwds.Length < 4)
        {
            lb_ErrMsg.Text = "【现有口令】字符串长度不能小于 4 位！";
            tr_ErrMsg.Attributes.Add("style", "display:;");
            pf_OldPwds.Focus();
            return;
        }

        String newPwds = pf_NewPwds.Text;
        if (string.IsNullOrEmpty(newPwds))
        {
            lb_ErrMsg.Text = "请输入【新登录口令】！";
            tr_ErrMsg.Attributes.Add("style", "display:;");
            pf_NewPwds.Focus();
            return;
        }
        if (newPwds.Length < 4)
        {
            lb_ErrMsg.Text = "【新登录口令】字符串长度不能小于 4 位！";
            tr_ErrMsg.Attributes.Add("style", "display:;");
            pf_NewPwds.Focus();
            return;
        }

        if (newPwds != pf_FrmPwds.Text)
        {
            lb_ErrMsg.Text = "您两次输入的口令不一致，请重新输入！";
            tr_ErrMsg.Attributes.Add("style", "display:;");
            pf_NewPwds.Focus();
            return;
        }

        if (UserInfo.Current(Session).signPk(oldPwds, newPwds))
        {
            tr_RegData1.Visible = false;
            tr_RegData2.Visible = false;
            tr_RegInfo.Visible = true;
        }
        else
        {
            lb_ErrMsg.Text = "口令修改失败，请确认您的口令输入是否正确！";
            tr_ErrMsg.Attributes.Add("style", "display:;");
            pf_OldPwds.Focus();
            return;
        }
    }
}
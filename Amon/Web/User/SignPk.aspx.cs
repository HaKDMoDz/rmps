using System;
using System.Web.UI;
using Me.Amon.Model;

public partial class User_SignPk : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserModel.Current(Session).Rank < IUser.LEVEL_01)
        {
            Response.Redirect("~/Index.aspx");
            return;
        }

        if (IsPostBack)
        {
            return;
        }
    }

    protected void BtSignPk_Click(object sender, EventArgs e)
    {
        String oldPwds = TbOldPass.Text;
        if (string.IsNullOrEmpty(oldPwds))
        {
            LbErrMsg.Text = "请输入【现有口令】！";
            TrErrMsg.Attributes.Add("style", "display:;");
            TbOldPass.Focus();
            return;
        }
        if (oldPwds.Length < 4)
        {
            LbErrMsg.Text = "【现有口令】字符串长度不能小于 4 位！";
            TrErrMsg.Attributes.Add("style", "display:;");
            TbOldPass.Focus();
            return;
        }

        String newPwds = TbNewPass.Text;
        if (string.IsNullOrEmpty(newPwds))
        {
            LbErrMsg.Text = "请输入【新登录口令】！";
            TrErrMsg.Attributes.Add("style", "display:;");
            TbNewPass.Focus();
            return;
        }
        if (newPwds.Length < 4)
        {
            LbErrMsg.Text = "【新登录口令】字符串长度不能小于 4 位！";
            TrErrMsg.Attributes.Add("style", "display:;");
            TbNewPass.Focus();
            return;
        }

        if (newPwds != TbRepPass.Text)
        {
            LbErrMsg.Text = "您两次输入的口令不一致，请重新输入！";
            TrErrMsg.Attributes.Add("style", "display:;");
            TbNewPass.Focus();
            return;
        }

        if (true)//UserInfo.Current(Session).signPk(oldPwds, newPwds))
        {
            tr_RegData1.Visible = false;
            tr_RegData2.Visible = false;
            tr_RegInfo.Visible = true;
        }
        else
        {
            LbErrMsg.Text = "口令修改失败，请确认您的口令输入是否正确！";
            TrErrMsg.Attributes.Add("style", "display:;");
            TbOldPass.Focus();
            return;
        }
    }
}
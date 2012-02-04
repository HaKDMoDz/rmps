using System;
using Me.Amon.Model;

public partial class User_SignWs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtSignWs_Click(object sender, EventArgs e)
    {
        String userPwds = TbPass1.Text;
        if (string.IsNullOrEmpty(userPwds))
        {
            LbErrMsg.Text = "请输入【登录口令】！";
            TrErrMsg.Attributes.Add("style", "display:;");
            TbPass1.Focus();
            return;
        }
        if (userPwds.Length < 4)
        {
            LbErrMsg.Text = "【登录口令】字符串长度不能小于 4 位！";
            TrErrMsg.Attributes.Add("style", "display:;");
            TbPass1.Focus();
            return;
        }
        if (userPwds != TbPass2.Text)
        {
            LbErrMsg.Text = "您两次输入的口令不一致，请重新输入！";
            TrErrMsg.Attributes.Add("style", "display:;");
            TbPass1.Text = "";
            TbPass2.Text = "";
            TbPass1.Focus();
            return;
        }

        string data;
        UserModel userModel = UserModel.Current(Session);
        if (userModel.SignWs(userModel.Code, userModel.Name, userPwds, out data))
        {
            tr_RegData1.Visible = false;
            tr_RegData2.Visible = false;
            tr_RegInfo.Visible = true;
        }
        else
        {
            LbErrMsg.Text = "用户注册失败，请稍后重试！";
            TrErrMsg.Attributes.Add("style", "display:;");
        }
    }
}
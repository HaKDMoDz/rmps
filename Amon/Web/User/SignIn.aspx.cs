using System;
using System.Web.UI;
using Me.Amon.Model;
using Me.Amon.Util;

public partial class User_SignIn : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        TbName.Focus();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtSignIn_Click(object sender, EventArgs e)
    {
        // 登录用户检测
        string userName = TbName.Text;
        if (string.IsNullOrEmpty(userName))
        {
            LbErrMsg.Text = "请输入【登录用户】！";
            TbName.Focus();
            return;
        }
        if (!CharUtil.IsValidateName(userName))
        {
            LbErrMsg.Text = "【登录用户】应在 4 到 32 个字符之间，且仅能为大小写字母、下划线及英文点号！";
            TbName.Focus();
            return;
        }

        // 登录口令检测
        string userPwds = TbPass.Text;
        if (string.IsNullOrEmpty(userPwds))
        {
            LbErrMsg.Text = "请输入【登录口令】！";
            TbPass.Focus();
            return;
        }
        if (userPwds.Length < 4)
        {
            LbErrMsg.Text = "【登录口令】字符串长度不能小于 4 位！";
            TbPass.Focus();
            return;
        }

        UserModel userModel = UserModel.Current(Session);
        if (!userModel.WpSignIn(userName, userPwds))
        {
            LbErrMsg.Text = "登录错误：请检查您输入的【登录用户】或【登录口令】是否正确！";
            return;
        }

        Response.Redirect("~/User/Index.aspx");
    }
}
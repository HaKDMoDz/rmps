using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using Me.Amon.Model;
using Me.Amon.Util;

public partial class user_user0101 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        tf_UserName.Focus();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SignIn_Click(object sender, EventArgs e)
    {
        // 登录用户检测
        String userName = tf_UserName.Text;
        if (string.IsNullOrEmpty(userName))
        {
            lb_ErrMsg.Text = "请输入【登录用户】！";
            tf_UserName.Focus();
            return;
        }
        Regex reg = new Regex("^\\w+[\\w\\d\\.]*$");
        if (!reg.IsMatch(userName))
        {
            lb_ErrMsg.Text = "您输入的【登录用户】不合法：登录用户仅能为大小写字母、下划线及英文点号！";
            tf_UserName.Focus();
            return;
        }
        if (!CharUtil.IsValidate(userName, 4, 32))
        {
            lb_ErrMsg.Text = "【登录用户】字符串长度应在 4 到 32 个字符之间！";
            tf_UserName.Focus();
            return;
        }

        // 登录口令检测
        String userPwds = pf_UserPwds.Text;
        if (string.IsNullOrEmpty(userPwds))
        {
            lb_ErrMsg.Text = "请输入【登录口令】！";
            pf_UserPwds.Focus();
            return;
        }
        if (userPwds.Length < 4)
        {
            lb_ErrMsg.Text = "【登录口令】字符串长度不能小于 4 位！";
            pf_UserPwds.Focus();
            return;
        }

        if (!new UserModel().SignWp(userName, userPwds))
        {
            lb_ErrMsg.Text = "登录错误：请检查您输入的【登录用户】或【登录口令】是否正确！";
            return;
        }

        Response.Redirect("~/user/user0001.aspx");
    }
}
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using Me.Amon.Da;
using Me.Amon.Util;

public partial class user_user0102 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        tr_ErrMsg.Attributes.Add("style", "display: none;");

        if (IsPostBack)
        {
            return;
        }
    }

    protected void bt_Register_Click(object sender, EventArgs e)
    {
        String userName = tf_UserName.Text;
        if (string.IsNullOrEmpty(userName))
        {
            lb_ErrMsg.Text = "请输入【登录用户】！";
            tr_ErrMsg.Attributes.Add("style", "display:;");
            tf_UserName.Focus();
            return;
        }
        Regex reg = new Regex("^\\w+[\\w\\d\\.]*$");
        if (!reg.IsMatch(userName))
        {
            lb_ErrMsg.Text = "您输入的【登录用户】不合法：登录用户仅能为大小写字母、下划线及英文点号！";
            tr_ErrMsg.Attributes.Add("style", "display:;");
            tf_UserName.Focus();
            return;
        }
        if (!CharUtil.IsValidate(userName, 4, 32))
        {
            lb_ErrMsg.Text = "【登录用户】字符串长度应在 4 到 32 个字符之间！";
            tr_ErrMsg.Attributes.Add("style", "display:;");
            tf_UserName.Focus();
            return;
        }

        String userPwds = pf_UserPwds.Text;
        if (string.IsNullOrEmpty(userPwds))
        {
            lb_ErrMsg.Text = "请输入【登录口令】！";
            tr_ErrMsg.Attributes.Add("style", "display:;");
            pf_UserPwds.Focus();
            return;
        }
        if (userPwds.Length < 4)
        {
            lb_ErrMsg.Text = "【登录口令】字符串长度不能小于 4 位！";
            tr_ErrMsg.Attributes.Add("style", "display:;");
            pf_UserPwds.Focus();
            return;
        }
        if (userPwds != pf_FirmPwds.Text)
        {
            lb_ErrMsg.Text = "您两次输入的口令不一致，请重新输入！";
            tr_ErrMsg.Attributes.Add("style", "display:;");
            pf_UserPwds.Text = "";
            pf_FirmPwds.Text = "";
            pf_UserPwds.Focus();
            return;
        }

        String userMail = tf_UserMail.Text;
        if (!CharUtil.IsValidate(userMail))
        {
            lb_ErrMsg.Text = "请输入【电子邮件】！";
            tr_ErrMsg.Attributes.Add("style", "display:;");
            tf_UserMail.Focus();
            return;
        }
        reg = new Regex("^\\w+[\\w\\.]*@\\w+(\\.[\\w\\.]+)+$");
        if (!reg.IsMatch(userMail))
        {
            lb_ErrMsg.Text = "您输入的【电子邮件】格式不正确，正确格式为：someone@hostname.com！";
            tr_ErrMsg.Attributes.Add("style", "display:;");
            tf_UserMail.Focus();
            return;
        }

        // 用户名重复检测
        DBAccess dba = new DBAccess();
        dba.AddTable(DBConst.C3010400);
        dba.AddColumn(DBConst.C3010405);
        dba.AddWhere(DBConst.C3010405, userName);
        DataTable dv = dba.ExecuteSelect();
        if (dv != null && dv.Rows.Count > 0)
        {
            lb_ErrMsg.Text = String.Format("用户名 {0} 已存在，请选择其它用户名！", userName);
            tr_ErrMsg.Attributes.Add("style", "display:;");
            tf_UserName.Focus();
            return;
        }

        if (true)//UserInfo.Current(Session).signUp(userName, userPwds, userMail))
        {
            tr_RegData1.Visible = false;
            tr_RegData2.Visible = false;
            tr_RegInfo.Visible = true;
        }
        else
        {
            lb_ErrMsg.Text = "用户注册失败，请稍后重试！";
            tr_ErrMsg.Attributes.Add("style", "display:;");
        }
    }
}

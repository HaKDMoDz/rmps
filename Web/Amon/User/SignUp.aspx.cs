using System;
using System.Data;
using System.Text.RegularExpressions;
using Me.Amon.Da;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.User
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
        }

        protected void BtSignUp_Click(object sender, EventArgs e)
        {
            string userName = TbName.Text;
            if (string.IsNullOrEmpty(userName))
            {
                LbErrMsg.Text = "请输入【登录用户】！";
                TrErrMsg.Attributes.Add("style", "display:;");
                TbName.Focus();
                return;
            }
            Regex reg = new Regex("^\\w+[\\w\\d\\.]*$");
            if (!reg.IsMatch(userName))
            {
                LbErrMsg.Text = "您输入的【登录用户】不合法：登录用户仅能为大小写字母、下划线及英文点号！";
                TrErrMsg.Attributes.Add("style", "display:;");
                TbName.Focus();
                return;
            }
            if (!CharUtil.IsValidate(userName, 4, 32))
            {
                LbErrMsg.Text = "【登录用户】字符串长度应在 4 到 32 个字符之间！";
                TrErrMsg.Attributes.Add("style", "display:;");
                TbName.Focus();
                return;
            }

            string userPwds = TbPass1.Text;
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

            string userMail = TbMail.Text;
            if (!CharUtil.IsValidate(userMail))
            {
                LbErrMsg.Text = "请输入【电子邮件】！";
                TrErrMsg.Attributes.Add("style", "display:;");
                TbMail.Focus();
                return;
            }
            reg = new Regex("^\\w+[\\w\\.]*@\\w+(\\.[\\w\\.]+)+$");
            if (!reg.IsMatch(userMail))
            {
                LbErrMsg.Text = "您输入的【电子邮件】格式不正确，正确格式为：someone@hostname.com！";
                TrErrMsg.Attributes.Add("style", "display:;");
                TbMail.Focus();
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
                LbErrMsg.Text = string.Format("用户名 {0} 已存在，请选择其它用户名！", userName);
                TrErrMsg.Attributes.Add("style", "display:;");
                TbName.Focus();
                return;
            }

            UserModel userModel = UserModel.Current(Session);
            if (0 == userModel.WpSignUp(userName, userPwds, userMail))
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
}
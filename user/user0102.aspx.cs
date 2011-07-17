using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;

using cons.io.db.comn;

using rmp.bean;
using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;

public partial class user_user0102 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "用户注册";
        Session[cons.wrp.WrpCons.SCRIPTID] = "user0102";

        List<K1V2> guidList = Wrps.GuidUser(Session);
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/user/user0102.aspx";
        guidItem.V1 = "用户注册";
        guidItem.V2 = "用户注册";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;
        #endregion

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
        if (!StringUtil.isValidate(userName, 4, 32))
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
        if (!StringUtil.isValidate(userMail))
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
        const string sqlTable = cons.io.db.comn.user.UserCons.C3010400;
        String sqlSelect = String.Format("SELECT {0} FROM {1} WHERE {2}='{3}'",
            cons.io.db.comn.user.UserCons.C3010405,
            sqlTable,
            cons.io.db.comn.user.UserCons.C3010405, userName
            );
        DataView dv = new DBAccess().CreateView(sqlTable, sqlSelect);
        if (dv != null && dv.Count > 0)
        {
            lb_ErrMsg.Text = String.Format("用户名 {0} 已存在，请选择其它用户名！", userName);
            tr_ErrMsg.Attributes.Add("style", "display:;");
            tf_UserName.Focus();
            return;
        }

        if (UserInfo.Current(Session).signUp(userName, userPwds, userMail))
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

using System;
using System.Web.UI;
using rmp.util;
using rmp.comn.safe;

public partial class App_Ascx_AmonAuth : System.Web.UI.UserControl
{
    private String errMsg;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        tf_AmonAuth.MaxLength = Safe.CharSize;

        InitData();
    }

    public void InitData()
    {
        String authHash = Safe.GenAuthCode(rmp.comn.user.UserInfo.Current(Session).UserHash);
        im_AmonAuth.Attributes[cons.wrp.WrpCons.SID] = authHash;
        im_AmonAuth.ImageUrl = "~/safe/safe0001.ashx?sid=" + authHash;
    }

    public override void Focus()
    {
        tf_AmonAuth.Focus();
    }

    protected void im_AmonAuth_Click(object sender, ImageClickEventArgs e)
    {
        InitData();
    }

    public bool IsValidate
    {
        get
        {
            String code = (tf_AmonAuth.Text ?? "").Trim();
            String hash = im_AmonAuth.Attributes[cons.wrp.WrpCons.SID];
            InitData();

            tf_AmonAuth.Text = "";
            if (!StringUtil.isValidate(code))
            {
                errMsg = "请输入验证图片中的文字！";
                return false;
            }
            if (!StringUtil.isValidate(code, Safe.CharSize))
            {
                errMsg = String.Format("请输入一个长度为 {0} 的文字！", Safe.CharSize);
                return false;
            }

            if (hash != HashUtil.digest(code.ToUpper() + rmp.comn.user.UserInfo.Current(Session).UserHash, true))
            {
                errMsg = "验证字符输入错误！";
                return false;
            }
            return true;
        }
    }

    public String ErrMsg
    {
        get
        {
            return errMsg;
        }
    }
}

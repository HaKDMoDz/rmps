using System;

public partial class card_card : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 消息提示不可见
        tr_ErrMsg.Visible = false;
    }
}

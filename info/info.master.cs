using System;
using System.Web.UI;

public partial class info_info : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 消息提示不可见
        tr_ErrMsg.Visible = false;

        // 页面事件交互状态不进行后面的处理
        if (IsPostBack)
        {
            return;
        }
    }
}
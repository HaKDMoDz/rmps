using System;
using System.Web.UI;

/// <summary>
/// 附注信息
/// </summary>
public partial class exts_exts0095 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// 下一步按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_NextStep_Click(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// 完成按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/exts/exts0001.aspx");
    }
}
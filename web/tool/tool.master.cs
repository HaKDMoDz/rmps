using System;
using System.Web.UI;

public partial class tool_tool : MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }
        lb_CopyYear.Text = DateTime.Now.Year.ToString();
    }
}
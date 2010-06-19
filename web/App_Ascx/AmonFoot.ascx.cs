using System;
using System.Web.UI;

public partial class App_Ascx_AmonFoot : UserControl
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DvList.Style.Add("width", "220px");
        DvIdea.Style.Add("width", "300px");
        DvPage.Style.Add("margin", "0px 310px 0px 230px");
    }
}
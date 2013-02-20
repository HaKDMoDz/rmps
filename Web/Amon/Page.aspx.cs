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
        DvBody.Style.Add("width", "960px");
        DvList.Style.Add("width", "240px");
    }
}
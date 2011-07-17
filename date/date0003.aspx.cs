using System;
using System.Web.UI;

public partial class date_date0003 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }
        hd_FlashObj.Value = Request[cons.wrp.WrpCons.SID];
    }
}
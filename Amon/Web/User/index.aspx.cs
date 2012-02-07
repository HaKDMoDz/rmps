using System;
using Me.Amon.Da;

public partial class User_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        //DBAccess dba = new DBAccess();
    }
}
using System;

namespace Me.Amon
{
    public partial class Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            DvList.Style.Add("width", "220px");
            DvIdea.Style.Add("width", "300px");
            DvPage.Style.Add("margin", "0px 310px 0px 230px");
        }
    }
}
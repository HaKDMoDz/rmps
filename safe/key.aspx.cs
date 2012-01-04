using System;
using System.Security.Cryptography;

public partial class safe_key : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }
    }

    protected void BtGk_Click(object sender, EventArgs e)
    {
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        TaGk.Text = rsa.ToXmlString(false);
        TaSk.Text = rsa.ToXmlString(true);
    }
}

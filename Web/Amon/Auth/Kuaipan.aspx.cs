using System;
using Me.Amon.Open;
using Me.Amon.Open.V1.Web;
using Me.Amon.Open.V1.Web.Pcs;

public partial class Auth_Kuaipan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var token = Request["oauth_token"];
        var verifier = Request["oauth_verifier"];
        TextBox1.Text = "oauth_token:" + token + ";oauth_verifier" + verifier;
        if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(verifier))
        {
            RequestToken();
            return;
        }

        var client = Session["oAuth"] as OAuthV1Client;
        if (client == null)
        {
            return;
        }

        client.Token.oauth_token = token;
        if (!client.AccessToken())
        {
            return;
        }
    }

    private void RequestToken()
    {
        OAuthConsumer consumer = OAuthConsumer.KuaipanConsumer();
        OAuthV1Client client = new KuaipanClient(consumer, true);
        if (!client.RequestToken())
        {
            return;
        }
        Session["oAuth"] = client;
        Response.Redirect(client.GetAuthorizeUrl());
    }
}
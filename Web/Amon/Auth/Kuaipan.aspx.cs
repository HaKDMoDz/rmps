using System;
using Me.Amon.Da.Db;
using Me.Amon.Model;
using Me.Amon.Open;
using Me.Amon.Open.V1.Web;
using Me.Amon.Open.V1.Web.Pcs;
using Me.Amon.Util;

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

        TextBox1.Text += "\nAuth OK!\n";
        var client = Session["oAuth"] as OAuthV1Client;
        if (client == null)
        {
            return;
        }

        TextBox1.Text += "Access OK!\n";
        client.Token.Token = token;
        if (!client.AccessToken())
        {
            TextBox1.Text += "Access Error!\n";
            return;
        }

        TextBox1.Text += "Save Token!\n" + client.DebugResult;
        SaveToken(client.Token);
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

    private void SaveToken(OAuthToken token)
    {
        TextBox1.Text += "token:" + token.Token + '\n';
        TextBox1.Text += "token:" + token.Secret + '\n';
        DBAccess dba = new DBAccess();
        dba.AddTable(DBConst.C3010A00);
        dba.AddParam(DBConst.C3010A01, 0);
        dba.AddParam(DBConst.C3010A02, HashUtil.UtcTimeInHex(false));
        dba.AddParam(DBConst.C3010A03, UserModel.Current(Session).Code);
        dba.AddParam(DBConst.C3010A04, KuaipanServer.TYPE);
        dba.AddParam(DBConst.C3010A05, KuaipanServer.CONSUMER_KEY);
        dba.AddParam(DBConst.C3010A06, KuaipanServer.CONSUMER_SECRET);
        dba.AddParam(DBConst.C3010A07, CharUtil.Text2DB(token.Token));
        dba.AddParam(DBConst.C3010A08, CharUtil.Text2DB(token.Secret));
        dba.AddParam(DBConst.C3010A09, 1);
        dba.AddParam(DBConst.C3010A0A, DBConst.SQL_NOW, false);
        dba.AddParam(DBConst.C3010A0B, DBConst.SQL_NOW, false);
        dba.ExecuteInsert();
    }
}
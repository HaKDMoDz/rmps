using System;
using Me.Amon.Da.Db;
using Me.Amon.Model;
using Me.Amon.Open;
using Me.Amon.Open.V1.Web;
using Me.Amon.Open.V1.Web.Pcs;
using Me.Amon.Util;

namespace Me.Amon.Auth
{
    public partial class Kuaipan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userModel = UserModel.Current(Session);
            if (userModel.Rank < IUser.LEVEL_01)
            {
                Response.Redirect("~/Index.aspx");
                return;
            }

            var token = Request["oauth_token"];
            var verifier = Request["oauth_verifier"];
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

            client.Token.Token = token;
            if (!client.AccessToken())
            {
                return;
            }

            client.Token.Type = OAuthClient.KUAIPAN;
            SaveToken(client.Token, userModel.Code);

            Response.Redirect("~/Page.aspx");
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

        private void SaveToken(OAuthToken token, string code)
        {
            DBAccess dba = new DBAccess();
            dba.AddTable(DBConst.C3010A00);
            dba.AddWhere(DBConst.C3010A03, code);
            dba.AddWhere(DBConst.C3010A04, OAuthClient.KUAIPAN);
            dba.AddWhere(DBConst.C3010A05, CharUtil.Text2DB(token.UserId));
            dba.AddDeleteBatch();

            dba.ReInit();
            dba.AddTable(DBConst.C3010A00);
            dba.AddParam(DBConst.C3010A01, 0);
            dba.AddParam(DBConst.C3010A02, HashUtil.UtcTimeInHex(false));
            dba.AddParam(DBConst.C3010A03, code);
            dba.AddParam(DBConst.C3010A04, OAuthClient.KUAIPAN);
            dba.AddParam(DBConst.C3010A05, CharUtil.Text2DB(token.UserId));
            dba.AddParam(DBConst.C3010A06, KuaipanServer.CONSUMER_KEY);
            dba.AddParam(DBConst.C3010A07, KuaipanServer.CONSUMER_SECRET);
            dba.AddParam(DBConst.C3010A08, CharUtil.Text2DB(token.Token));
            dba.AddParam(DBConst.C3010A09, CharUtil.Text2DB(token.Secret));
            dba.AddParam(DBConst.C3010A0A, 1);
            dba.AddParam(DBConst.C3010A0B, DBConst.SQL_NOW, false);
            dba.AddParam(DBConst.C3010A0C, DBConst.SQL_NOW, false);
            dba.AddInsertBatch();

            dba.ExecuteBatch();
        }
    }
}
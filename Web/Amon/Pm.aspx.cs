using System;
using System.Text;
using Me.Amon.Http;
using Me.Amon.Model;
using Me.Amon.Open;
using Me.Amon.Open.V1.Web.Pcs;

namespace Me.Amon
{
    public partial class Pm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = UserModel.Current(Session);
            if (user.Rank < IUser.LEVEL_01 || user.Token == null)
            {
                Response.Redirect("~/Index.aspx");
                return;
            }
        }

        protected void BtUpdate_Click(object sender, EventArgs e)
        {
            var user = UserModel.Current(Session);

            OAuthConsumer consumer = OAuthConsumer.KuaipanConsumer();
            KuaipanClient client = new KuaipanClient(consumer, user.Token, true);
            var uri = client.Upload("/" + Web.PAGE_NAME + "/");

            MsMultiPartFormData form = new MsMultiPartFormData();
            form.AddStreamFile("file", "MetaName", Encoding.UTF8.GetBytes(HfData.Value));
            form.PrepareFormData();

            HttpUtil http = new HttpUtil();
            http.Encoding = Encoding.UTF8;
            http.Method = HttpMethod.POST;
            http.ContentType = "multipart/form-data; boundary=" + form.Boundary;
            http.Post(uri, form.GetFormData().ToArray());
        }
    }
}
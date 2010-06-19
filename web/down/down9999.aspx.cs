using System;
using System.IO;
using System.Text;
using System.Web.UI;

using cons.wrp;

using rmp.comn.user;
using rmp.wrp;

public partial class down_down9999 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        String sid = Request[WrpCons.SID];
        if (sid == null || sid.Trim() == "")
        {
            return;
        }

        LoadData(sid);
    }

    private void LoadData(String sid)
    {
        String path = Server.MapPath("data/" + sid + ".txt");
        if (!File.Exists(path))
        {
            return;
        }

        StreamReader reader = File.OpenText(path);
        StringBuilder builder = new StringBuilder();
        String text = reader.ReadLine();
        while (text != null)
        {
            builder.Append(text);
            text = reader.ReadLine();
            builder.Append(Environment.NewLine);
        }
        reader.Close();
        ta_DownInfo.Text = builder.ToString();
        hd_SoftHash.Value = sid;
    }

    protected void bt_DownInfo_Click(object sender, EventArgs e)
    {
        String sid = hd_SoftHash.Value;
        if (sid.Length != 8)
        {
            Wrps.ShowMesg(Master, "您没有指定软件索引，无法保存数据！");
            return;
        }

        String path = Server.MapPath("data/" + sid + ".txt");
        FileStream writer = File.OpenWrite(path);
        byte[] buff = Encoding.UTF8.GetBytes(ta_DownInfo.Text);
        writer.Write(buff, 0, buff.Length);
        writer.Flush();
        writer.Close();
    }

    protected void ck_DownInfo_CheckedChanged(object sender, EventArgs e)
    {
        ta_DownInfo.Wrap = ck_DownInfo.Checked;
    }
}
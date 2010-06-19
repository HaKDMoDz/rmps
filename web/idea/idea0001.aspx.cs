using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

using cons.wrp;

using rmp.bean;
using rmp.io.db;
using rmp.wrp.soft;

/// <summary>
/// 我有意见<br>
/// 用户发表意见页面
/// </summary>
public partial class idea_idea0001 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "我有话说";
        Session[cons.wrp.WrpCons.SCRIPTID] = "idea0001";

        Session[cons.wrp.WrpCons.GUIDSIZE] = 2;

        if (IsPostBack)
        {
            return;
        }

        String sid = Request[WrpCons.SID];
        if (sid != null)
        {
            tr_SoftHash.Visible = false;
            hd_SoftHash.Value = sid;
        }
        else
        {
            cb_SoftIndx.Items.Add(new ListItem("默认", "0"));

            ArrayList al = Soft.GetSoftList();
            K1V3 kvItem;
            for (int i = 0, j = al.Count; i < j; i += 1)
            {
                kvItem = (K1V3)al[i];
                cb_SoftIndx.Items.Add(new ListItem(kvItem.V1, kvItem.K));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveIdea_Click(object sender, EventArgs e)
    {
        String ideaText = ta_IdeaText.Text.Trim();
        if (ideaText == "")
        {
            tr_ErrMsg.Visible = true;
            return;
        }

        String softIndx = tr_SoftHash.Visible ? cb_SoftIndx.SelectedValue : hd_SoftHash.Value;
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.wrp.WrpCons.WRP_IDEA_IDEADATA);
        dba.addParam(cons.io.db.wrp.WrpCons.IDEADATA_IDEAINDX, Convert.ToString(DateTime.Now.ToFileTimeUtc(), 16));
        dba.addParam(cons.io.db.wrp.WrpCons.IDEADATA_SOFTINDX, softIndx);
        dba.addParam(cons.io.db.wrp.WrpCons.IDEADATA_IDEATYPE, cb_IdeaType.SelectedValue);
        dba.addParam(cons.io.db.wrp.WrpCons.IDEADATA_NICKNAME, rmp.util.WrpUtil.text2Db(tf_NickName.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.IDEADATA_USERMAIL, rmp.util.WrpUtil.text2Db(tf_UserMail.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.IDEADATA_HOMEPAGE, rmp.util.WrpUtil.text2Db(tf_HomePage.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.IDEADATA_DATETIME, cons.EnvCons.SQL_NOW, false);
        dba.addParam(cons.io.db.wrp.WrpCons.IDEADATA_IDEATEXT, rmp.util.WrpUtil.text2Db(ta_IdeaText.Text));
        dba.executeInsert();

        String linkAddr = "";
        if (softIndx != "0")
        {
            linkAddr = "?sid=" + softIndx;
        }
        Response.Redirect("idea0001.aspx" + linkAddr);
    }
}
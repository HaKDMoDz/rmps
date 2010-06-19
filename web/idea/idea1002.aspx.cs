using System;
using System.Web.UI;

using cons.wrp;

using rmp.io.db;
using rmp.util;
using cons;

public partial class idea_idea1002 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.SCRIPTID]= "idea1002";

        if (IsPostBack)
        {
            return;
        }

        String sid = WrpUtil.text2Db(Request[WrpCons.SID]);
        if (!StringUtil.isValidate(sid, 16))
        {
            sid = "13010000";
        }
        hd_SoftHash.Value = sid;
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

        String softIndx = hd_SoftHash.Value;
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.wrp.WrpCons.WRP_IDEA_IDEADATA);
        dba.addParam(cons.io.db.wrp.WrpCons.IDEADATA_IDEAINDX, Convert.ToString(DateTime.Now.ToFileTimeUtc(), 16));
        dba.addParam(cons.io.db.wrp.WrpCons.IDEADATA_SOFTINDX, softIndx);
        dba.addParam(cons.io.db.wrp.WrpCons.IDEADATA_IDEATYPE, cb_IdeaType.SelectedValue);
        dba.addParam(cons.io.db.wrp.WrpCons.IDEADATA_NICKNAME, WrpUtil.text2Db(tf_NickName.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.IDEADATA_USERMAIL, WrpUtil.text2Db(tf_UserMail.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.IDEADATA_HOMEPAGE, WrpUtil.text2Db(tf_HomePage.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.IDEADATA_DATETIME, EnvCons.SQL_NOW, false);
        dba.addParam(cons.io.db.wrp.WrpCons.IDEADATA_IDEATEXT, WrpUtil.text2Db(ta_IdeaText.Text));
        dba.executeInsert();

        String linkAddr = "";
        if (softIndx != "0")
        {
            linkAddr = "?sid=" + softIndx;
        }
        Response.Redirect("idea1001.aspx" + linkAddr);
    }
}
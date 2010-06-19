using System;
using System.Web.UI.WebControls;
using cons;
using cons.wrp;
using rmp.io.db;
using rmp.comn.user;

/// <summary>
/// 获取代码
/// </summary>
public partial class card_card0001 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;
        Session[cons.wrp.WrpCons.GUIDNAME] = "获取代码";
        Session[cons.wrp.WrpCons.SCRIPTID] = "card0001";

        // 页面事件类型判断
        if (IsPostBack)
        {
            return;
        }

        UserInfo ui = UserInfo.Current(Session);
        lb_EditCard.Visible = ui.UserRank >= cons.comn.user.UserInfo.LEVEL_02;
        lb_EditCard.Attributes.Add("onclick", "return doEdit();");
        LoadData(ui.UserCode);
    }

    private void LoadData(string code)
    {
        // 用户代码
        hd_UserCode.Value = code;

        // 用户数据
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.ComnCons.C2010100);
        dba.addWhere(cons.io.db.comn.ComnCons.C2010104, code + SysCons.CARD_HASH);
        dba.addSort(cons.io.db.comn.ComnCons.C2010101, false);

        cb_CardList.DataTextField = cons.io.db.comn.ComnCons.C2010105;
        cb_CardList.DataValueField = cons.io.db.comn.ComnCons.C2010103;
        cb_CardList.DataSource = dba.executeSelect();
        cb_CardList.DataBind();

        cb_CardList.Items.Insert(0, new ListItem("请选择", ""));
        cb_CardList.Attributes.Add("onchange", "chgIcon(this.value);");
        cb_CardList.SelectedValue = Request[WrpCons.SID];
    }
}

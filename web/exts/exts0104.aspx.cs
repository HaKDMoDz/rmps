using System;
using System.Collections.Generic;
using System.Web.UI;

using cons.io.db.prp;

using rmp.bean;
using rmp.io.db;
using rmp.comn.user;
using rmp.wrp;
using rmp.util;
using cons.wrp.exts;

public partial class exts_exts0104 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_02)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        #region Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "公司信息";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0104";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        guidList[2].K = cons.EnvCons.PRE_URL + "/exts/exts0101.aspx";

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0100.aspx";
        guidItem.V1 = "公司信息";
        guidItem.V2 = "公司信息";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0104.aspx";
        guidItem.V1 = "数据删除";
        guidItem.V2 = "数据删除";
        #endregion

        if (IsPostBack)
        {
            return;
        }

        // 页面传入参数处理
        String sid = (Request[cons.wrp.WrpCons.SID] ?? "").Trim();
        if (!StringUtil.isValidateHash(sid))
        {
            Response.Redirect("~/exts/exts0101.aspx");
            return;
        }

        ta_P3010109.MaxLength = PrpCons.P3010109_SIZE;
        hd_CorpHash.Value = sid;
    }

    protected void bt_Delete_Click(object sender, EventArgs e)
    {
        // 用户权限判断
        UserInfo ui = UserInfo.Current(Session);
        if (ui.UserRank < cons.comn.user.UserInfo.LEVEL_02)
        {
            Response.Redirect("~/user/user0001.aspx");
            return;
        }

        #region 用户输入检测
        String P3010109 = WrpUtil.text2Db(ta_P3010109.Text);
        if (!StringUtil.isValidate(P3010109))
        {
            Wrps.ShowMesg(this.Master, "请输入有效的说明信息！");
            ta_P3010109.Focus();
            return;
        }
        if (!StringUtil.isValidate(P3010109, 0, PrpCons.P3010109_SIZE))
        {
            Wrps.ShowMesg(this.Master, String.Format("说明信息不能超过 {0} 个字符！", PrpCons.P3010109_SIZE));
            ta_P3010109.Focus();
            return;
        }
        #endregion

        // 修改后缀数据的公司信息为默认
        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3010000);
        dba.addParam(PrpCons.P3010005, "0");
        dba.addWhere(PrpCons.P3010005, hd_CorpHash.Value);
        dba.executeUpdate();

        // 修改软件数据的公司信息为默认
        dba.reset();
        dba.addTable(PrpCons.P3010200);
        dba.addParam(PrpCons.P3010203, "0");
        dba.addWhere(PrpCons.P3010203, hd_CorpHash.Value);
        dba.executeUpdate();

        if (ui.UserRank > cons.comn.user.UserInfo.LEVEL_06)
        {
            // 物理删除公司数据
            dba.reset();
            dba.addTable(PrpCons.P3010100);
            dba.addWhere(PrpCons.P3010102, hd_CorpHash.Value);
            dba.executeDelete();
        }
        else
        {
            // 逻辑删除公司数据
            dba.reset();
            dba.addTable(PrpCons.P3010100);
            dba.addParam(PrpCons.P3010109, WrpUtil.text2Db(ta_P3010109.Text));
            dba.addParam(PrpCons.P301010D, cons.wrp.WrpCons.OPT_DELETE);
            dba.addWhere(PrpCons.P3010102, hd_CorpHash.Value);
            dba.executeUpdate();
        }

        Response.Redirect("exts0101.aspx");
    }
}
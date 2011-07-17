using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

using cons;
using cons.wrp;

using rmp.bean;
using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;
using rmp.wrp.inet;

public partial class inet_inet0198 : Page
{
    protected bool isRoot;
    protected bool isUser;

    protected void Page_Load(object sender, EventArgs e)
    {
        // 用户权限判断
        int randId = UserInfo.Current(Session).UserRank;
        isRoot = (randId == cons.comn.user.UserInfo.LEVEL_09);
        isUser = (randId >= cons.comn.user.UserInfo.LEVEL_02);
        if (randId == 0)
        {
            Response.Redirect("~/user/user0001.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "编辑配置";
        Session[cons.wrp.WrpCons.SCRIPTID] = "inet0198";

        List<K1V2> guidList = Wrps.GuidInet(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/inet/inet0198.aspx";
        guidItem.V1 = "编辑配置";
        guidItem.V2 = "编辑配置";

        if (IsPostBack)
        {
            return;
        }

        cb_W2019105.Attributes.Add("onclick", "changeIcon(this);");

        // 读取指定的数据信息
        String sid = WrpUtil.text2Db(Request[WrpCons.SID]);
        if (StringUtil.isValidate(sid, 16))
        {
            LoadData(sid);
        }
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        String W2019106 = WrpUtil.text2Db(tf_W2019106.Text);
        if (!StringUtil.isValidate(W2019106, 1, cons.io.db.wrp.WrpCons.W2019106_SIZE))
        {
            lb_ErrMsg.Text = "【显示信息】输入信息不符合要求！";
            tf_W2019106.Focus();
            return;
        }

        String W2019107 = WrpUtil.text2Db(tf_W2019107.Text);
        if (!StringUtil.isValidate(W2019107, 0, cons.io.db.wrp.WrpCons.W2019107_SIZE))
        {
            lb_ErrMsg.Text = "【快捷提示】输入信息不符合要求！";
            tf_W2019107.Focus();
            return;
        }

        String W2019108 = WrpUtil.text2Db(tf_W2019108.Text);
        if (!StringUtil.isValidate(W2019108, 0, cons.io.db.wrp.WrpCons.W2019108_SIZE))
        {
            lb_ErrMsg.Text = "【联系地址】输入信息不符合要求！";
            tf_W2019108.Focus();
            return;
        }
        if (cb_W2019105.SelectedValue == "mail")
        {
            if (!W2019108.ToLower().StartsWith("mailto:"))
            {
                W2019108 = "mailto:" + W2019108;
            }
        }

        String W201910C = WrpUtil.text2Db(ta_W201910C.Text);
        if (!StringUtil.isValidate(W201910C, 0, cons.io.db.wrp.WrpCons.W201910C_SIZE))
        {
            lb_ErrMsg.Text = "【备选地址】输入信息不符合要求！";
            ta_W201910C.Focus();
            return;
        }

        DBAccess dba = new DBAccess();

        dba.addTable(cons.io.db.wrp.WrpCons.W2019100);
        dba.addParam(cons.io.db.wrp.WrpCons.W2019103, SysCons.UI_LANGHASH);
        dba.addParam(cons.io.db.wrp.WrpCons.W2019104, "iNetHelper_90wmi");
        dba.addParam(cons.io.db.wrp.WrpCons.W2019105, cb_W2019105.SelectedValue);
        dba.addParam(cons.io.db.wrp.WrpCons.W2019106, W2019106);
        dba.addParam(cons.io.db.wrp.WrpCons.W2019107, W2019107);
        dba.addParam(cons.io.db.wrp.WrpCons.W2019108, W2019108);
        dba.addParam(cons.io.db.wrp.WrpCons.W2019109, "");
        dba.addParam(cons.io.db.wrp.WrpCons.W201910A, "0");
        dba.addParam(cons.io.db.wrp.WrpCons.W201910B, "0");
        dba.addParam(cons.io.db.wrp.WrpCons.W201910C, W201910C);
        dba.addParam(cons.io.db.wrp.WrpCons.W201910D, EnvCons.SQL_NOW, false);

        if (hd_IsUpdate.Value == "1")
        {
            dba.addWhere(cons.io.db.wrp.WrpCons.W2019102, hd_W2019102.Value);
            dba.executeUpdate();

            im_W2019105.ImageUrl = "~/inet/i/" + cb_W2019105.SelectedValue + ".gif";
            lb_ErrMsg.Text = "数据更新成功！";

            K1V2 item = Inet.GetInetItem(hd_W2019102.Value);
            if (item != null)
            {
                item.K = tf_W2019108.Text;
            }
        }
        else
        {
            hd_W2019102.Value = HashUtil.getCurrTimeHex(false);
            dba.addParam(cons.io.db.wrp.WrpCons.W2019102, hd_W2019102.Value);
            dba.addParam(cons.io.db.wrp.WrpCons.W2019101, 0);
            dba.addParam(cons.io.db.wrp.WrpCons.W201910E, EnvCons.SQL_NOW, false);
            dba.executeInsert();

            hd_W2019102.Value = "0";
            im_W2019105.ImageUrl = "~/inet/i/" + cb_W2019105.SelectedValue + ".gif";
            tf_W2019106.Text = "";
            tf_W2019107.Text = "";
            tf_W2019108.Text = "";
            ta_W201910C.Text = "";

            lb_ErrMsg.Text = "数据新增成功！";
        }
    }

    /// <summary>
    /// 数据更新，读取已有数据
    /// </summary>
    /// <param name="sid"></param>
    private void LoadData(String sid)
    {
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.wrp.WrpCons.W2019100);
        dba.addColumn("*");
        dba.addWhere(cons.io.db.wrp.WrpCons.W2019102, sid);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2019104, "iNetHelper_90wmi");

        DataTable dt = dba.executeSelect();
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            hd_W2019102.Value = row[cons.io.db.wrp.WrpCons.W2019102].ToString();
            im_W2019105.ImageUrl = "~/inet/i/" + row[cons.io.db.wrp.WrpCons.W2019105] + ".gif";
            cb_W2019105.SelectedValue = row[cons.io.db.wrp.WrpCons.W2019105].ToString();
            tf_W2019106.Text = row[cons.io.db.wrp.WrpCons.W2019106].ToString();
            tf_W2019107.Text = row[cons.io.db.wrp.WrpCons.W2019107].ToString();
            tf_W2019108.Text = row[cons.io.db.wrp.WrpCons.W2019108].ToString();
            ta_W201910C.Text = row[cons.io.db.wrp.WrpCons.W201910C].ToString();

            hd_IsUpdate.Value = "1";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

using rmp.bean;
using rmp.comn.user;
using rmp.io.db;
using rmp.util;
using rmp.wrp;

/// <summary>
/// 软件编辑
/// </summary>
public partial class soft_soft0103 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = "Amon软件";
        Session[cons.wrp.WrpCons.SCRIPTID] = "soft0103";

        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        // Guid List设置
        List<K1V2> guidList = Wrps.GuidSoft(Session);
        K1V2 guidItem = guidList[1];
        guidItem.K = String.Format("/{0}soft/soft0101.aspx", cons.EnvCons.PRE_URL);
        guidItem.V1 = "软件查询";
        guidItem.V2 = "软件查询";

        guidItem = guidList[2];
        guidItem.K = String.Format("/{0}soft/soft0103.aspx", cons.EnvCons.PRE_URL);
        guidItem.V1 = "新增数据";
        guidItem.V2 = "新增数据";

        // 用户权限检测
        if (UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_02)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        if (IsPostBack)
        {
            return;
        }

        #region 输入控制
        tf_C0010104.MaxLength = cons.io.db.comn.ComnCons.C0010104_SIZE;
        tf_C0010105.MaxLength = cons.io.db.comn.ComnCons.C0010105_SIZE;
        tf_C0010106.MaxLength = cons.io.db.comn.ComnCons.C0010106_SIZE;
        tf_C0010107.MaxLength = cons.io.db.comn.ComnCons.C0010107_SIZE;
        tf_C0010108.MaxLength = cons.io.db.comn.ComnCons.C0010108_SIZE;
        tf_C0010109.MaxLength = cons.io.db.comn.ComnCons.C0010109_SIZE;
        tf_C001010A.MaxLength = cons.io.db.comn.ComnCons.C001010A_SIZE;
        tf_C001010B.MaxLength = cons.io.db.comn.ComnCons.C001010B_SIZE;
        tf_C001010C.MaxLength = cons.io.db.comn.ComnCons.C001010C_SIZE;
        tf_C001010D.MaxLength = cons.io.db.comn.ComnCons.C001010D_SIZE;
        tf_C001010E.MaxLength = cons.io.db.comn.ComnCons.C001010E_SIZE;
        tf_C001010F.MaxLength = cons.io.db.comn.ComnCons.C001010F_SIZE;
        tf_C0010110.MaxLength = cons.io.db.comn.ComnCons.C0010110_SIZE;
        tf_C0010111.MaxLength = cons.io.db.comn.ComnCons.C0010111_SIZE;
        ta_C0010112.MaxLength = cons.io.db.comn.ComnCons.C0010112_SIZE;
        ta_C0010113.MaxLength = cons.io.db.comn.ComnCons.C0010113_SIZE;
        ta_C0010114.MaxLength = cons.io.db.comn.ComnCons.C0010114_SIZE;
        #endregion

        ck_C0010105.Attributes.Add("onchange", "chgC0010105()");
        ck_C0010107.Attributes.Add("onchange", "chgC0010107()");

        LoadData(Request[cons.wrp.WrpCons.SID]);
    }

    private void LoadData(String sid)
    {
        if (!StringUtil.isValidateHash(sid))
        {
            cb_System.Items.Add(new ListItem("--请选择--", ""));
            if (UserInfo.Current(Session).UserRank >= cons.comn.user.UserInfo.LEVEL_06)
            {
                cb_System.Items.Add(new ListItem("系统管控", "0"));
            }
            cb_System.Items.Add(new ListItem("个人应用（PRP）", "1"));
            cb_System.Items.Add(new ListItem("企业应用（ERP）", "2"));
            cb_System.Items.Add(new ListItem("网络平台应用（WRP）", "3"));
            cb_System.Items.Add(new ListItem("移动平台应用（MRP）", "4"));
            cb_System.Items.Add(new ListItem("即时通讯应用（IRP）", "5"));

            ck_C0010107.Checked = true;
            return;
        }

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.ComnCons.C0010100);
        dba.addWhere(cons.io.db.comn.ComnCons.C0010103, sid);

        DataTable dt = dba.executeSelect();
        if (dt.Rows.Count != 1)
        {
            return;
        }

        DataRow row = dt.Rows[0];
        int C0010102 = (int)row[cons.io.db.comn.ComnCons.C0010102];
        rb_C0010102.SelectedValue = (C0010102 / 10).ToString();
        cb_C0010102.SelectedValue = (C0010102 % 10).ToString();
        hd_C0010103.Value = sid;
        tf_C0010104.Text = "" + row[cons.io.db.comn.ComnCons.C0010104];
        tf_C0010105.Text = "" + row[cons.io.db.comn.ComnCons.C0010105];
        hd_C0010105.Value = tf_C0010105.Text;
        tf_C0010106.Text = "" + row[cons.io.db.comn.ComnCons.C0010106];
        tf_C0010107.Text = "" + row[cons.io.db.comn.ComnCons.C0010107];
        tf_C0010108.Text = "" + row[cons.io.db.comn.ComnCons.C0010108];
        tf_C0010109.Text = "" + row[cons.io.db.comn.ComnCons.C0010109];
        tf_C001010A.Text = "" + row[cons.io.db.comn.ComnCons.C001010A];
        tf_C001010B.Text = "" + row[cons.io.db.comn.ComnCons.C001010B];
        tf_C001010C.Text = "" + row[cons.io.db.comn.ComnCons.C001010C];
        tf_C001010D.Text = "" + row[cons.io.db.comn.ComnCons.C001010D];
        tf_C001010E.Text = "" + row[cons.io.db.comn.ComnCons.C001010E];
        tf_C001010F.Text = "" + row[cons.io.db.comn.ComnCons.C001010F];
        tf_C0010110.Text = "" + row[cons.io.db.comn.ComnCons.C0010110];
        tf_C0010111.Text = "" + row[cons.io.db.comn.ComnCons.C0010111];
        ta_C0010112.Text = "" + row[cons.io.db.comn.ComnCons.C0010112];
        ta_C0010113.Text = "" + row[cons.io.db.comn.ComnCons.C0010113];
        ta_C0010114.Text = "" + row[cons.io.db.comn.ComnCons.C0010114];
        lb_C0010115.Text = "" + row[cons.io.db.comn.ComnCons.C0010115];
        lb_C0010116.Text = "" + row[cons.io.db.comn.ComnCons.C0010116];

        cb_System.Visible = false;
        cb_Module.Visible = false;
    }

    /// <summary>
    /// 软件信息保存事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        #region 输入控制
        if (!StringUtil.isValidate(tf_C0010106.Text))
        {
            lb_ErrMsg.Text = "请输入软件名称！";
            tf_C0010106.Focus();
            return;
        }
        if (!StringUtil.isValidate(tf_C0010104.Text))
        {
            lb_ErrMsg.Text = "请输入软件代码！";
            tf_C0010104.Focus();
            return;
        }
        if (!StringUtil.isValidateCode(tf_C0010104.Text))
        {
            lb_ErrMsg.Text = "软件代码输入错误！";
            tf_C0010104.Focus();
            return;
        }
        if (!StringUtil.isValidate(tf_C0010105.Text))
        {
            lb_ErrMsg.Text = "请输入软件版本！";
            tf_C0010105.Focus();
            return;
        }
        if (!aa_AmonAuth.IsValidate)
        {
            lb_ErrMsg.Text = aa_AmonAuth.ErrMsg;
            aa_AmonAuth.Focus();
            return;
        }
        #endregion

        bool isUpdate = StringUtil.isValidateHash(hd_C0010103.Value);

        DBAccess dba = new DBAccess();

        // 判断版本是否相同，不相同则执行已有数据备份操作
        String C0010105 = tf_C0010105.Text.Replace(" ", "");
        if (isUpdate && C0010105 != hd_C0010105.Value)
        {
            dba.addParam(cons.io.db.comn.ComnCons.C0010A01, cons.io.db.comn.ComnCons.C0010101, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A02, cons.io.db.comn.ComnCons.C0010102, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A03, cons.io.db.comn.ComnCons.C0010103, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A04, cons.io.db.comn.ComnCons.C0010104, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A05, cons.io.db.comn.ComnCons.C0010105, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A06, cons.io.db.comn.ComnCons.C0010106, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A07, cons.io.db.comn.ComnCons.C0010107, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A08, cons.io.db.comn.ComnCons.C0010108, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A09, cons.io.db.comn.ComnCons.C0010109, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A0A, cons.io.db.comn.ComnCons.C001010A, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A0B, cons.io.db.comn.ComnCons.C001010B, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A0C, cons.io.db.comn.ComnCons.C001010C, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A0D, cons.io.db.comn.ComnCons.C001010D, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A0E, cons.io.db.comn.ComnCons.C001010E, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A0F, cons.io.db.comn.ComnCons.C001010F, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A10, cons.io.db.comn.ComnCons.C0010110, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A11, cons.io.db.comn.ComnCons.C0010111, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A12, cons.io.db.comn.ComnCons.C0010112, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A13, cons.io.db.comn.ComnCons.C0010113, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A14, cons.io.db.comn.ComnCons.C0010114, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A15, cons.io.db.comn.ComnCons.C0010115, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010A16, cons.io.db.comn.ComnCons.C0010116, false);

            dba.addWhere(cons.io.db.comn.ComnCons.C0010103, WrpUtil.text2Db(hd_C0010103.Value));
            dba.executeBackup(cons.io.db.comn.ComnCons.C0010A00, cons.io.db.comn.ComnCons.C0010100);

            dba.reset();
        }

        dba.addTable(cons.io.db.comn.ComnCons.C0010100);
        dba.addParam(cons.io.db.comn.ComnCons.C0010102, WrpUtil.text2Db(rb_C0010102.SelectedValue + cb_C0010102.SelectedValue), false);
        dba.addParam(cons.io.db.comn.ComnCons.C0010104, WrpUtil.text2Db(tf_C0010104.Text));
        dba.addParam(cons.io.db.comn.ComnCons.C0010105, WrpUtil.text2Db(C0010105));
        dba.addParam(cons.io.db.comn.ComnCons.C0010106, WrpUtil.text2Db(tf_C0010106.Text));
        dba.addParam(cons.io.db.comn.ComnCons.C0010107, WrpUtil.text2Db(tf_C0010107.Text));
        dba.addParam(cons.io.db.comn.ComnCons.C0010108, WrpUtil.text2Db(tf_C0010108.Text));
        dba.addParam(cons.io.db.comn.ComnCons.C0010109, WrpUtil.text2Db(tf_C0010109.Text));
        dba.addParam(cons.io.db.comn.ComnCons.C001010A, WrpUtil.text2Db(tf_C001010A.Text));
        dba.addParam(cons.io.db.comn.ComnCons.C001010B, WrpUtil.text2Db(tf_C001010B.Text));
        dba.addParam(cons.io.db.comn.ComnCons.C001010C, WrpUtil.text2Db(tf_C001010C.Text));
        dba.addParam(cons.io.db.comn.ComnCons.C001010D, WrpUtil.text2Db(tf_C001010D.Text));
        dba.addParam(cons.io.db.comn.ComnCons.C001010E, WrpUtil.text2Db(tf_C001010E.Text));
        dba.addParam(cons.io.db.comn.ComnCons.C001010F, WrpUtil.text2Db(tf_C001010F.Text));
        dba.addParam(cons.io.db.comn.ComnCons.C0010110, WrpUtil.text2Db(tf_C0010110.Text));
        dba.addParam(cons.io.db.comn.ComnCons.C0010111, WrpUtil.text2Db(tf_C0010111.Text));
        dba.addParam(cons.io.db.comn.ComnCons.C0010112, WrpUtil.text2Db(ta_C0010112.Text));
        dba.addParam(cons.io.db.comn.ComnCons.C0010113, WrpUtil.text2Db(ta_C0010113.Text));
        dba.addParam(cons.io.db.comn.ComnCons.C0010114, WrpUtil.text2Db(ta_C0010114.Text));
        dba.addParam(cons.io.db.comn.ComnCons.C0010115, cons.EnvCons.SQL_NOW, false);

        if (isUpdate)
        {
            // 执行数据更新
            dba.addWhere(cons.io.db.comn.ComnCons.C0010103, hd_C0010103.Value);

            dba.executeUpdate();

            lb_ErrMsg.Text = "数据更新成功！";
        }
        else
        {
            String hash = HashUtil.getCurrTimeHex(false);
            // 执行数据插入
            dba.addParam(cons.io.db.comn.ComnCons.C0010101, 0);
            dba.addParam(cons.io.db.comn.ComnCons.C0010103, hash);
            dba.addParam(cons.io.db.comn.ComnCons.C0010116, cons.EnvCons.SQL_NOW, false);
            dba.executeInsert();

            // 插入项目申请人员
            dba.reset();
            dba.addTable(cons.io.db.comn.ComnCons.C0010200);
            dba.addParam(cons.io.db.comn.ComnCons.C0010201, 0);
            dba.addParam(cons.io.db.comn.ComnCons.C0010202, 0);
            dba.addParam(cons.io.db.comn.ComnCons.C0010203, hash);
            dba.addParam(cons.io.db.comn.ComnCons.C0010204, UserInfo.Current(Session).UserCode);
            dba.addParam(cons.io.db.comn.ComnCons.C0010205, cons.EnvCons.SQL_NOW, false);
            dba.addParam(cons.io.db.comn.ComnCons.C0010206, cons.EnvCons.SQL_NOW, false);
            dba.executeInsert();

            cb_Module.SelectedValue = "";
            tf_C0010104.Text = "";

            lb_ErrMsg.Text = "数据新增成功！";
        }

        tf_C0010105.ReadOnly = !ck_C0010105.Checked;
        tf_C0010107.ReadOnly = ck_C0010107.Checked;
    }

    protected void cb_System_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_06)
        {
            return;
        }

        tf_C0010104.Text = "";
        cb_Module.Items.Clear();
        cb_Module.Items.Add(new ListItem("--请选择--", ""));
        switch (cb_System.SelectedValue)
        {
            case "0":// 管控系统
                cb_Module.Items.Add(new ListItem("管控资源", "0"));
                cb_Module.Items.Add(new ListItem("自然资源", "1"));
                cb_Module.Items.Add(new ListItem("信息资源", "2"));
                cb_Module.Items.Add(new ListItem("用户资源", "3"));
                cb_Module.Items.Add(new ListItem("安全控制", "4"));
                cb_Module.Items.Add(new ListItem("Amon专用", "5"));
                cb_Module.Items.Add(new ListItem("其它资源", "A"));
                break;
            case "1":// PRP 系统
                cb_Module.Items.Add(new ListItem("首页", "0"));
                cb_Module.Items.Add(new ListItem("我的地盘", "1"));
                cb_Module.Items.Add(new ListItem("新闻资讯", "2"));
                cb_Module.Items.Add(new ListItem("个人助理", "3"));
                cb_Module.Items.Add(new ListItem("财经证券", "4"));
                cb_Module.Items.Add(new ListItem("家庭办公", "5"));
                cb_Module.Items.Add(new ListItem("休闲娱乐", "6"));
                cb_Module.Items.Add(new ListItem("功能扩展", "7"));
                cb_Module.Items.Add(new ListItem("使用帮助", "9"));
                break;
            case "2":// ERP 系统
                break;
            case "3":// WRP 系统
                cb_Module.Items.Add(new ListItem("控制", "0"));
                cb_Module.Items.Add(new ListItem("在线", "1"));
                cb_Module.Items.Add(new ListItem("软件", "2"));
                cb_Module.Items.Add(new ListItem("博客", "3"));
                cb_Module.Items.Add(new ListItem("论坛", "4"));
                cb_Module.Items.Add(new ListItem("通讯", "5"));
                cb_Module.Items.Add(new ListItem("服务", "A"));
                cb_Module.Items.Add(new ListItem("意见", "D"));
                cb_Module.Items.Add(new ListItem("帮助", "E"));
                cb_Module.Items.Add(new ListItem("关于", "F"));
                break;
            case "4":// MRP 系统
                break;
            case "5":// IRP 系统
                cb_Module.Items.Add(new ListItem("用户偏好", "0"));
                cb_Module.Items.Add(new ListItem("新闻资讯", "1"));
                cb_Module.Items.Add(new ListItem("生活服务", "2"));
                cb_Module.Items.Add(new ListItem("财经证券", "3"));
                cb_Module.Items.Add(new ListItem("在线办公", "4"));
                cb_Module.Items.Add(new ListItem("信息检索", "5"));
                cb_Module.Items.Add(new ListItem("休闲娱乐", "6"));
                cb_Module.Items.Add(new ListItem("科学教育", "7"));
                cb_Module.Items.Add(new ListItem("功能扩展", "8"));
                cb_Module.Items.Add(new ListItem("配置管理", "9"));
                break;
            default:
                break;
        }
    }

    protected void cb_Module_SelectedIndexChanged(object sender, EventArgs e)
    {
        String s = cb_System.SelectedValue;
        String m = cb_Module.SelectedValue;

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.ComnCons.C0010100);
        dba.addColumn("COUNT(*) cnt");
        dba.addWhere(String.Format("{0} LIKE '{1}{2}%'", cons.io.db.comn.ComnCons.C0010104, s, m));

        DataTable dt = dba.executeSelect();
        if (dt == null || dt.Rows.Count != 1)
        {
            return;
        }

        int cnt;
        try
        {
            cnt = int.Parse(dt.Rows[0][0].ToString());
        }
        catch (Exception)
        {
            cnt = 0;
        }

        cnt += 1;
        tf_C0010104.Text = String.Format("{0}{1}{2}0000", s, m, Convert.ToString(cnt, 16).PadLeft(2, '0')).ToUpper();
    }
}

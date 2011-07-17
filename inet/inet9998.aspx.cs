using System;
using System.Data;
using System.IO;
using System.Web.UI;

using cons;
using cons.wrp;

using rmp.bean;
using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;
using rmp.wrp.inet;

using Util = rmp.comn.Util;

public partial class inet_inet9998 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 0;
        Session[cons.wrp.WrpCons.GUIDNAME] = "网页精灵";
        Session[cons.wrp.WrpCons.SCRIPTID] = "inet9998";
        Session[cons.wrp.WrpCons.GUIDSIZE] = Wrps.GuidInfo(Session).Count;

        // 页面事件类型判断
        if (IsPostBack)
        {
            return;
        }

        Util.InitLangData(cb_W2019103, true);
        Util.InitCat1Data(cb_W2019104, SysCons.UI_LANGHASH, SysCons.INET_HASH, true);
        cb_W2019104.Items.Remove("iNetHelper_90wmi");

        String sid = WrpUtil.text2Db(Request[WrpCons.SID]);
        if (StringUtil.isValidate(sid, 16))
        {
            LoadData(sid);
        }
    }

    /// <summary>
    /// 图片文件上传
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_W2019105_Click(object sender, EventArgs e)
    {
        String fileName = fu_W2019105.FileName;
        if (!StringUtil.isValidate(fileName))
        {
            lb_ErrMsg.Text = "请选择您要上传的文件！";
            return;
        }

        Stream stream = fu_W2019105.FileContent;
        if (stream == null || stream.Length < 1)
        {
            lb_ErrMsg.Text = "无法读取您选择文件，请确认路径是否正确！";
            return;
        }

        fileName = hd_W2019105.Value;
        if (fileName == null)
        {
            fileName = HashUtil.getCurrTimeHex(false);
        }
        else
        {
            fileName = fileName.Trim();
            if (fileName == "" || fileName == "0")
            {
                fileName = HashUtil.getCurrTimeHex(false);
            }
        }

        String filePath = Server.MapPath(cons.wrp.inet.InetCons.INET_ICON_PATH);
        fu_W2019105.SaveAs(filePath + fileName + ".gif");
        im_W2019105.ImageUrl = cons.wrp.inet.InetCons.INET_ICON_PATH + fileName + ".gif";
        hd_W2019105.Value = fileName;
    }

    /// <summary>
    /// 保存数据
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        DBAccess dba = new DBAccess();

        dba.addTable(cons.io.db.wrp.WrpCons.W2019100);
        dba.addParam(cons.io.db.wrp.WrpCons.W2019103, cb_W2019103.SelectedValue);
        dba.addParam(cons.io.db.wrp.WrpCons.W2019104, cb_W2019104.SelectedValue);
        dba.addParam(cons.io.db.wrp.WrpCons.W2019105, hd_W2019105.Value);
        dba.addParam(cons.io.db.wrp.WrpCons.W2019106, WrpUtil.text2Db(tf_W2019106.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W2019107, WrpUtil.text2Db(tf_W2019107.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W2019108, WrpUtil.text2Db(tf_W2019108.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W2019109, WrpUtil.text2Db(cb_W2019109.SelectedValue));
        dba.addParam(cons.io.db.wrp.WrpCons.W201910A, tf_W201910A.Text);
        dba.addParam(cons.io.db.wrp.WrpCons.W201910B, tf_W201910B.Text);
        dba.addParam(cons.io.db.wrp.WrpCons.W201910C, WrpUtil.text2Db(ta_W201910C.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W201910D, EnvCons.SQL_NOW, false);

        if (hd_IsUpdate.Value == "1")
        {
            dba.addWhere(cons.io.db.wrp.WrpCons.W2019102, hd_W2019102.Value);
            dba.executeUpdate();

            im_W2019105.ImageUrl = cons.wrp.inet.InetCons.INET_ICON_PATH + hd_W2019105.Value + ".gif";
            lb_ErrMsg.Text = "数据更新成功！";

            K1V2 item = Inet.GetInetItem(hd_W2019102.Value);
            if (item != null)
            {
                item.K = tf_W2019108.Text;
                item.V1 = cb_W2019109.SelectedValue;
                item.V2 = cb_W2019104.SelectedValue;
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
            im_W2019105.ImageUrl = cons.wrp.inet.InetCons.INET_ICON_PATH + "0.gif";
            hd_W2019105.Value = "0";
            tf_W2019106.Text = "";
            tf_W2019107.Text = "";
            tf_W2019108.Text = "";
            tf_W201910A.Text = "480";
            tf_W201910B.Text = "560";
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

        DataTable dt = dba.executeSelect();
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            hd_W2019102.Value = row[cons.io.db.wrp.WrpCons.W2019102].ToString();
            cb_W2019103.SelectedValue = row[cons.io.db.wrp.WrpCons.W2019103].ToString();
            cb_W2019104.SelectedValue = row[cons.io.db.wrp.WrpCons.W2019104].ToString();
            im_W2019105.ImageUrl = cons.wrp.inet.InetCons.INET_ICON_PATH + row[cons.io.db.wrp.WrpCons.W2019105] + ".gif";
            hd_W2019105.Value = row[cons.io.db.wrp.WrpCons.W2019105].ToString();
            tf_W2019106.Text = row[cons.io.db.wrp.WrpCons.W2019106].ToString();
            tf_W2019107.Text = row[cons.io.db.wrp.WrpCons.W2019107].ToString();
            tf_W2019108.Text = row[cons.io.db.wrp.WrpCons.W2019108].ToString();
            cb_W2019109.SelectedValue = row[cons.io.db.wrp.WrpCons.W2019109].ToString();
            tf_W201910A.Text = row[cons.io.db.wrp.WrpCons.W201910A].ToString();
            tf_W201910B.Text = row[cons.io.db.wrp.WrpCons.W201910B].ToString();
            ta_W201910C.Text = row[cons.io.db.wrp.WrpCons.W201910C].ToString();

            hd_IsUpdate.Value = "1";
        }
    }
}
using System;
using System.Data;
using System.Drawing;
using System.Web.UI;

using cons;
using cons.wrp;

using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;

public partial class soft_soft9999 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 用户权限检测
        if (UserInfo.Current(Session).UserRank != cons.comn.user.UserInfo.LEVEL_09)
        {
            Response.Redirect("~/index.aspx");
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 5;
        Session[cons.wrp.WrpCons.GUIDNAME] = "软件管理";
        Session[cons.wrp.WrpCons.SCRIPTID] = "soft9999";
        Session[cons.wrp.WrpCons.GUIDSIZE] = Wrps.GuidSoft(Session).Count;

        // 是否页面回传
        if (IsPostBack)
        {
            return;
        }

        String sid = WrpUtil.text2Db(Request[WrpCons.SID]);
        String ver = WrpUtil.text2Db(Request["ver"]);
        if (!StringUtil.isValidate(sid, 8) || String.IsNullOrEmpty(ver))
        {
            return;
        }

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.ComnCons.C0010100);
        dba.addWhere(cons.io.db.comn.ComnCons.C0010104, sid);
        dba.addWhere(cons.io.db.comn.ComnCons.C0010105, ver);

        DataTable dataList = dba.executeSelect();
        if (dataList != null && dataList.Rows.Count > 0)
        {
            DataRow row = dataList.Rows[0];
            tf_SoftIndx.Text = row[cons.io.db.comn.ComnCons.C0010104].ToString();
            tf_SoftVers.Text = row[cons.io.db.comn.ComnCons.C0010105].ToString();
            tf_SoftName.Text = row[cons.io.db.comn.ComnCons.C0010106].ToString();
            tf_PubsTime.Text = row[cons.io.db.comn.ComnCons.C0010107].ToString();
            tf_VersTips.Text = row[cons.io.db.comn.ComnCons.C0010108].ToString();
            tf_VersLogo.Text = row[cons.io.db.comn.ComnCons.C0010109].ToString();
            tf_VersPict.Text = row[cons.io.db.comn.ComnCons.C001010A].ToString();
            tf_VersDown.Text = row[cons.io.db.comn.ComnCons.C001010F].ToString();
            tf_VersJnlp.Text = row[cons.io.db.comn.ComnCons.C0010110].ToString();
            tf_VersCode.Text = row[cons.io.db.comn.ComnCons.C0010111].ToString();
            ta_VersInfo.Text = row[cons.io.db.comn.ComnCons.C0010112].ToString();
            ta_VersBugs.Text = row[cons.io.db.comn.ComnCons.C0010113].ToString();
            ta_VersDesp.Text = row[cons.io.db.comn.ComnCons.C0010114].ToString();
            dl_SoftProp.SelectedValue = row[cons.io.db.comn.ComnCons.C0010102].ToString();

            tf_SoftIndx.Enabled = false;
            tf_SoftVers.Enabled = false;
            bt_IsUpdate.Value = "1";
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveVers_Click(object sender, EventArgs e)
    {
        String softIndx = tf_SoftIndx.Text;
        if (softIndx.Length > cons.io.db.comn.ComnCons.C0010104_SIZE)
        {
            lb_ErrMsg.Text = String.Format("长度不能超过 {0} 个字符！", cons.io.db.comn.ComnCons.C0010104_SIZE);
            tf_SoftIndx.BackColor = Color.Red;
            return;
        }
        String softVers = tf_SoftVers.Text;
        if (softIndx.Length > cons.io.db.comn.ComnCons.C0010104_SIZE)
        {
            lb_ErrMsg.Text = String.Format("长度不能超过 {0} 个字符！", cons.io.db.comn.ComnCons.C0010104_SIZE);
            tf_SoftIndx.BackColor = Color.Red;
            return;
        }
        String softName = tf_SoftName.Text;
        if (softName.Length > cons.io.db.comn.ComnCons.C0010106_SIZE)
        {
            lb_ErrMsg.Text = String.Format("长度不能超过 {0} 个字符！", cons.io.db.comn.ComnCons.C0010106_SIZE);
            tf_SoftName.BackColor = Color.Red;
            return;
        }
        String pubsTime = tf_PubsTime.Text;
        if (pubsTime.Length > cons.io.db.comn.ComnCons.C0010107_SIZE)
        {
            lb_ErrMsg.Text = String.Format("长度不能超过 {0} 个字符！", cons.io.db.comn.ComnCons.C0010107_SIZE);
            tf_PubsTime.BackColor = Color.Red;
            return;
        }
        String versTips = tf_VersTips.Text;
        if (versTips.Length > cons.io.db.comn.ComnCons.C0010108_SIZE)
        {
            lb_ErrMsg.Text = String.Format("长度不能超过 {0} 个字符！", cons.io.db.comn.ComnCons.C0010108_SIZE);
            tf_VersTips.BackColor = Color.Red;
            return;
        }
        String versLogo = tf_VersLogo.Text;
        if (versLogo.Length > cons.io.db.comn.ComnCons.C0010109_SIZE)
        {
            lb_ErrMsg.Text = String.Format("长度不能超过 {0} 个字符！", cons.io.db.comn.ComnCons.C0010109_SIZE);
            tf_VersLogo.BackColor = Color.Red;
            return;
        }
        String versPict = tf_VersPict.Text;
        if (versPict.Length > cons.io.db.comn.ComnCons.C001010A_SIZE)
        {
            lb_ErrMsg.Text = String.Format("长度不能超过 {0} 个字符！", cons.io.db.comn.ComnCons.C001010A_SIZE);
            tf_VersPict.BackColor = Color.Red;
            return;
        }
        String versDown = tf_VersDown.Text;
        if (versDown.Length > cons.io.db.comn.ComnCons.C001010F_SIZE)
        {
            lb_ErrMsg.Text = String.Format("长度不能超过 {0} 个字符！", cons.io.db.comn.ComnCons.C001010F_SIZE);
            tf_VersDown.BackColor = Color.Red;
            return;
        }
        String versJnlp = tf_VersJnlp.Text;
        if (versJnlp.Length > cons.io.db.comn.ComnCons.C0010110_SIZE)
        {
            lb_ErrMsg.Text = String.Format("长度不能超过 {0} 个字符！", cons.io.db.comn.ComnCons.C0010110_SIZE);
            tf_VersJnlp.BackColor = Color.Red;
            return;
        }
        String versCode = tf_VersCode.Text;
        if (versCode.Length > cons.io.db.comn.ComnCons.C0010111_SIZE)
        {
            lb_ErrMsg.Text = String.Format("长度不能超过 {0} 个字符！", cons.io.db.comn.ComnCons.C0010111_SIZE);
            tf_VersCode.BackColor = Color.Red;
            return;
        }
        String versInfo = ta_VersInfo.Text;
        if (versInfo.Length > cons.io.db.comn.ComnCons.C0010112_SIZE)
        {
            lb_ErrMsg.Text = String.Format("长度不能超过 {0} 个字符！", cons.io.db.comn.ComnCons.C0010112_SIZE);
            ta_VersInfo.BackColor = Color.Red;
            return;
        }
        String versBugs = ta_VersBugs.Text;
        if (versBugs.Length > cons.io.db.comn.ComnCons.C0010113_SIZE)
        {
            lb_ErrMsg.Text = String.Format("长度不能超过 {0} 个字符！", cons.io.db.comn.ComnCons.C0010113_SIZE);
            ta_VersBugs.BackColor = Color.Red;
            return;
        }
        String versDesp = ta_VersDesp.Text;
        if (versDesp.Length > cons.io.db.comn.ComnCons.C0010114_SIZE)
        {
            lb_ErrMsg.Text = String.Format("长度不能超过 {0} 个字符！", cons.io.db.comn.ComnCons.C0010114_SIZE);
            ta_VersDesp.BackColor = Color.Red;
            return;
        }
        String versCurr = dl_SoftProp.SelectedValue;

        DBAccess dba = new DBAccess();
        if (versCurr != "0")
        {
            dba.addTable(cons.io.db.comn.ComnCons.C0010100);
            dba.addParam(cons.io.db.comn.ComnCons.C0010102, "0");
            dba.addWhere(cons.io.db.comn.ComnCons.C0010104, softIndx);
            dba.executeUpdate();
        }

        dba.reset();
        dba.addTable(cons.io.db.comn.ComnCons.C0010100);
        dba.addParam(cons.io.db.comn.ComnCons.C0010106, softName);
        dba.addParam(cons.io.db.comn.ComnCons.C0010107, pubsTime);
        dba.addParam(cons.io.db.comn.ComnCons.C0010108, versTips);
        dba.addParam(cons.io.db.comn.ComnCons.C0010109, versLogo);
        dba.addParam(cons.io.db.comn.ComnCons.C001010A, versPict);
        dba.addParam(cons.io.db.comn.ComnCons.C001010F, versDown);
        dba.addParam(cons.io.db.comn.ComnCons.C0010110, versJnlp);
        dba.addParam(cons.io.db.comn.ComnCons.C0010111, versCode);
        dba.addParam(cons.io.db.comn.ComnCons.C0010112, versInfo);
        dba.addParam(cons.io.db.comn.ComnCons.C0010113, versBugs);
        dba.addParam(cons.io.db.comn.ComnCons.C0010114, versDesp);
        dba.addParam(cons.io.db.comn.ComnCons.C0010102, versCurr);
        dba.addParam(cons.io.db.comn.ComnCons.C0010115, EnvCons.SQL_NOW, false);
        if (bt_IsUpdate.Value == "1")
        {
            dba.addWhere(cons.io.db.comn.ComnCons.C0010104, softIndx);
            dba.addWhere(cons.io.db.comn.ComnCons.C0010105, softVers);
            dba.executeUpdate();

            lb_ErrMsg.Text = "软件信息更新成功！";
        }
        else
        {
            dba.addParam(cons.io.db.comn.ComnCons.C0010104, softIndx);
            dba.addParam(cons.io.db.comn.ComnCons.C0010105, softVers);
            dba.addParam(cons.io.db.comn.ComnCons.C0010116, EnvCons.SQL_NOW, false);
            dba.executeInsert();

            lb_ErrMsg.Text = "软件信息添加成功！";
        }
        tr_ErrMsg.Visible = true;
    }
}
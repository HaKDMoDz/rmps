using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using cons;
using cons.io.db.prp;
using cons.wrp.link;

using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;

/// <summary>
/// 类别管理
/// </summary>
public partial class link_link0203 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_02)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "类别编辑";
        Session[cons.wrp.WrpCons.SCRIPTID] = "link0203";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 5;

        if (IsPostBack)
        {
            return;
        }

        tf_P3070A06.MaxLength = cons.io.db.comn.info.C2010000.C2010107_SIZE;
        ta_P3070A07.MaxLength = cons.io.db.comn.info.C2010000.C201010A_SIZE;

        LoadData();
    }

    /// <summary>
    /// 数据初始化
    /// </summary>
    private void LoadData()
    {
        String sid = WrpUtil.text2Db(Request[cons.wrp.WrpCons.SID]);//当前链接
        String uri = WrpUtil.text2Db(Request[cons.wrp.WrpCons.URI]);//上级类别
        if (StringUtil.isValidate(uri, 16))
        {
            hd_HistBack.Value = "/link/link0001.aspx";
        }

        // 读取当前类别信息
        DBAccess dba = new DBAccess();
        if (StringUtil.isValidate(sid, 16))
        {
            dba.addTable(cons.io.db.comn.info.C2010000.C2010100);
            dba.addColumn(cons.io.db.comn.info.C2010000.C2010106);
            dba.addColumn(cons.io.db.comn.info.C2010000.C2010107);
            dba.addColumn(cons.io.db.comn.info.C2010000.C201010A);
            dba.addWhere(cons.io.db.comn.info.C2010000.C2010104, UserInfo.Current(Session).UserCode);
            dba.addWhere(cons.io.db.comn.info.C2010000.C2010105, sid);

            DataTable dt = dba.executeSelect();
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                uri = row[cons.io.db.comn.info.C2010000.C2010106] + "";
                tf_P3070A06.Text = row[cons.io.db.comn.info.C2010000.C2010107] + "";
                ta_P3070A07.Text = row[cons.io.db.comn.info.C2010000.C201010A] + "";

                hd_P3070A05.Value = sid;
                hd_IsUpdate.Value = "1";
            }

            dba.reset();
        }

        // 显示其它类别目录
        dba.addTable(cons.io.db.comn.info.C2010000.C2010100);
        dba.addColumn(cons.io.db.comn.info.C2010000.C2010106);
        dba.addColumn(cons.io.db.comn.info.C2010000.C2010105);
        dba.addColumn(cons.io.db.comn.info.C2010000.C2010107);
        dba.addColumn(cons.io.db.comn.info.C2010000.C201010A);
        dba.addWhere(cons.io.db.comn.info.C2010000.C2010102, LinkCons.LINK_STAT_NORMAL.ToString());
        dba.addWhere(cons.io.db.comn.info.C2010000.C2010104, UserInfo.Current(Session).UserCode);
        dba.addSort(cons.io.db.comn.info.C2010000.C2010101, false);
        DataView dv = dba.executeSelect().DefaultView;

        // 用户链接
        TreeNode node = new TreeNode("我的类别", LinkCons.LINK_USER_HASH);
        node.Checked = (LinkCons.LINK_USER_HASH == uri);
        node.SelectAction = TreeNodeSelectAction.None;
        tv_P3070A04.Nodes.Add(node);
        BindKind(dv, node, LinkCons.LINK_USER_HASH, uri, sid);
        tv_P3070A04.CollapseAll();
        node.Expand();

        if (tf_P3070A04.Value == "")
        {
            tf_P3070A04.Value = "--请选择--";
        }
    }

    /// <summary>
    /// 类别加载
    /// </summary>
    /// <param name="dv">类别数据</param>
    /// <param name="cur">上级节点</param>
    /// <param name="sid">上级节点ID</param>
    /// <param name="uri">选中节点ID</param>
    /// <param name="def">去除节点ID</param>
    private void BindKind(DataView dv, TreeNode cur, String sid, String uri, String def)
    {
        String old = dv.RowFilter;
        dv.RowFilter = cons.io.db.comn.info.C2010000.C2010106 + "='" + sid + "'";
        foreach (DataRowView view in dv)
        {
            String tmp = view[cons.io.db.comn.info.C2010000.C2010105] + "";
            if (tmp == def)
            {
                continue;
            }

            TreeNode node = new TreeNode();
            node.Value = tmp;
            node.Text = view[cons.io.db.comn.info.C2010000.C2010107] + "";
            node.ToolTip = view[cons.io.db.comn.info.C2010000.C201010A] + "";
            if (tmp == uri)
            {
                node.Checked = true;
                tf_P3070A04.Value = node.Text;
            }
            node.SelectAction = TreeNodeSelectAction.None;
            cur.ChildNodes.Add(node);

            BindKind(dv, node, tmp, uri, def);
        }
        dv.RowFilter = old;
    }

    /// <summary>
    /// 保存按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        List<TreeNode> list = new List<TreeNode>();
        foreach (TreeNode temp in tv_P3070A04.Nodes)
        {
            ReadNode(temp, list);
        }
        if (list.Count < 1)
        {
            Wrps.ShowMesg(Master, "请选择上级类别！");
            return;
        }
        if (list.Count > 1)
        {
            Wrps.ShowMesg(Master, "只能选择一个上级类别！");
            return;
        }
        TreeNode node = list[0];

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.comn.info.C2010000.C2010100);
        dba.addParam(cons.io.db.comn.info.C2010000.C2010106, node.Value);
        dba.addParam(cons.io.db.comn.info.C2010000.C2010107, WrpUtil.text2Db(tf_P3070A06.Text));
        dba.addParam(cons.io.db.comn.info.C2010000.C201010A, WrpUtil.text2Db(ta_P3070A07.Text));
        dba.addParam(cons.io.db.comn.info.C2010000.C201010B, EnvCons.SQL_NOW, false);

        if (hd_IsUpdate.Value == "1")
        {
            dba.addWhere(cons.io.db.comn.info.C2010000.C2010104, UserInfo.Current(Session).UserCode);
            dba.addWhere(cons.io.db.comn.info.C2010000.C2010105, hd_P3070A05.Value);
            dba.executeUpdate();

            Wrps.ShowMesg(Master, "类别更新成功！");
        }
        else
        {
            String P3070A05 = HashUtil.getCurrTimeHex(false);
            dba.addParam(cons.io.db.comn.info.C2010000.C2010101, 0);
            dba.addParam(cons.io.db.comn.info.C2010000.C2010102, LinkCons.LINK_STAT_NORMAL);
            dba.addParam(cons.io.db.comn.info.C2010000.C2010104, UserInfo.Current(Session).UserCode);
            dba.addParam(cons.io.db.comn.info.C2010000.C2010105, P3070A05);
            dba.addParam(cons.io.db.comn.info.C2010000.C201010C, EnvCons.SQL_NOW, false);
            dba.executeInsert();

            TreeNode subs = new TreeNode();
            subs.Value = P3070A05;
            subs.Text = tf_P3070A06.Text;
            subs.ToolTip = ta_P3070A07.Text;
            subs.SelectAction = TreeNodeSelectAction.None;
            node.ChildNodes.Add(subs);

            Wrps.ShowMesg(Master, "类别新增成功！");

            tf_P3070A06.Text = "";
            ta_P3070A07.Text = "";

            tf_P3070A06.Focus();
        }
    }

    /// <summary>
    /// 读取选择状态的节点
    /// </summary>
    /// <param name="node"></param>
    /// <param name="list"></param>
    private void ReadNode(TreeNode node, ICollection<TreeNode> list)
    {
        if (node.Checked)
        {
            list.Add(node);
        }
        foreach (TreeNode temp in node.ChildNodes)
        {
            ReadNode(temp, list);
        }
    }
}
using System;
using System.Data;
using System.Web.UI.WebControls;
using cons.wrp.link;
using rmp.io.db;
using rmp.comn.user;
using rmp.util;

public partial class link_link0211 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        LoadData();
    }

    private void LoadData()
    {
        String sid = WrpUtil.text2Db(Request[cons.wrp.WrpCons.SID]);//当前链接
        String uri = WrpUtil.text2Db(Request[cons.wrp.WrpCons.URI]);//上级类别

        DBAccess dba = new DBAccess();

        // 显示其它类别目录
        dba.addTable(cons.io.db.comn.info.C2010000.C2010100);
        dba.addColumn(cons.io.db.comn.info.C2010000.C2010106);
        dba.addColumn(cons.io.db.comn.info.C2010000.C2010105);
        dba.addColumn(cons.io.db.comn.info.C2010000.C2010107);
        dba.addColumn(cons.io.db.comn.info.C2010000.C201010A);
        dba.addWhere(cons.io.db.comn.info.C2010000.C2010102, LinkCons.LINK_STAT_NORMAL.ToString());
        //dba.addWhere(cons.io.db.comn.info.C2010000.C2010104, UserInfo.Current(Session).UserCode);
        dba.addSort(cons.io.db.comn.info.C2010000.C2010101, false);
        DataView dv = dba.executeSelect().DefaultView;

        // 用户链接
        TreeNode node = new TreeNode();
        node.Value = LinkCons.LINK_USER_HASH;
        node.Text = "我的类别";
        node.ToolTip = "我的类别";
        node.Checked = (LinkCons.LINK_USER_HASH == uri);
        node.SelectAction = TreeNodeSelectAction.None;
        KindList.Nodes.Add(node);

        BindKind(dv, node, LinkCons.LINK_USER_HASH, uri, sid);

        KindList.CollapseAll();
        node.Expand();
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
            node.Checked = (tmp == uri);
            node.SelectAction = TreeNodeSelectAction.None;
            cur.ChildNodes.Add(node);

            BindKind(dv, node, tmp, uri, def);
        }
        dv.RowFilter = old;
    }
}

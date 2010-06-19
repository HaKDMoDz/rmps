using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using cons;
using cons.io.db.comn;
using cons.io.db.wrp;
using cons.wrp.srch;

using rmp.bean;
using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;

public partial class srch_srch0101 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 用户权限判断
        int randId = UserInfo.Current(Session).UserRank;
        if (randId == 0)
        {
            Response.Redirect("~/user/user0001.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = "数据配置";
        Session[cons.wrp.WrpCons.SCRIPTID] = "srch0101";

        List<K1V2> guidList = Wrps.GuidSrch(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/srch/srch0100.aspx";
        guidItem.V1 = "用户首页";
        guidItem.V2 = "用户首页";

        guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/srch/srch0101.aspx";
        guidItem.V1 = "数据配置";
        guidItem.V2 = "数据配置";

        if (IsPostBack)
        {
            return;
        }

        bool b = randId >= cons.comn.user.UserInfo.LEVEL_06;
        bt_Append.Visible = b;
        bt_Update.Visible = b;

        LoadSrch();
    }

    /// <summary>
    /// 读取偏好数据列表
    /// </summary>
    /// <param name="type"></param>
    private DataView LoadData()
    {
        DBAccess dba = new DBAccess();
        dba.addTable(String.Format("{0} LEFT JOIN {1} ON {2}={3} AND {4}='{5}'",
            WrpCons.W2039100, WrpCons.W2031100,
            WrpCons.W2039102, WrpCons.W2031104,// 用户偏好配置
            WrpCons.W2031105, UserInfo.Current(Session).UserCode));// 用户代码关联
        dba.addColumn(WrpCons.W2039102);//元素索引
        dba.addColumn(WrpCons.W2039104);//从属门户
        dba.addColumn(WrpCons.W2039105);//所属类别
        dba.addColumn(WrpCons.W2039106);//显示图标
        dba.addColumn(WrpCons.W2039107);//显示文本
        dba.addColumn(WrpCons.W2039108);//功能名称
        dba.addColumn(WrpCons.W2039109);//快捷提示
        dba.addColumn(WrpCons.W203910A);//链接地址
        dba.addColumn(WrpCons.W203910B);//转换方案
        dba.addColumn(WrpCons.W203910C);//窗口模式
        dba.addColumn(WrpCons.W2031103);//用户偏好
        dba.addSort(WrpCons.W2039101, false);//访问频率

        return dba.executeSelect().DefaultView;
    }

    /// <summary>
    /// 按搜索引擎显示
    /// </summary>
    private void LoadSrch()
    {
        DataView dv = LoadData();
        dv.Sort = WrpCons.W2039102 + " DESC";
        TreeNode root = new TreeNode("搜索引擎", "");
        root.SelectAction = TreeNodeSelectAction.None;
        tv_DataList.Nodes.Add(root);
        BindSrch(root, dv, "0");
        tv_DataList.CollapseAll();
        root.Expand();
    }

    /// <summary>
    /// 搜索引擎绑定
    /// </summary>
    /// <param name="tn"></param>
    /// <param name="dv"></param>
    /// <param name="kn"></param>
    private void BindSrch(TreeNode tn, DataView dv, String kn)
    {
        String old = dv.RowFilter;
        dv.RowFilter = WrpCons.W2039104 + "='" + kn + "'";
        foreach (DataRowView view in dv)
        {
            String tmp = view[WrpCons.W2039102] + "";

            TreeNode node = new TreeNode();
            node.Value = tmp + "," + view[WrpCons.W2039105];
            node.Text = view[WrpCons.W2039107] + "";
            node.ToolTip = view[WrpCons.W2039109] + "";
            node.ShowCheckBox = true;
            node.Checked = StringUtil.isValidate(view[WrpCons.W2031103] + "", 16);
            node.SelectAction = TreeNodeSelectAction.None;
            tn.ChildNodes.Add(node);

            BindSrch(node, dv, tmp);
        }
        dv.RowFilter = old;
    }

    /// <summary>
    /// 按功能类别显示
    /// </summary>
    private void LoadKind()
    {
        DBAccess dba = new DBAccess();
        dba.addTable(ComnCons.C2010000);
        dba.addColumn(ComnCons.C2010001);//显示排序
        dba.addColumn(ComnCons.C2010002);//类别索引
        dba.addColumn(ComnCons.C2010003);//系统索引
        dba.addColumn(ComnCons.C2010004);//类别名称
        dba.addColumn(ComnCons.C2010005);//类别提示
        dba.addColumn(ComnCons.C2010006);//类别键值
        dba.addWhere(ComnCons.C2010003, SysCons.SRCH_HASH);//类别关联
        dba.addSort(ComnCons.C2010001, false);

        DataView dv1 = dba.executeSelect().DefaultView;
        DataView dv2 = LoadData();

        TreeNode root = new TreeNode("功能类别", "");
        root.SelectAction = TreeNodeSelectAction.None;
        tv_DataList.Nodes.Add(root);
        foreach (DataRowView view in dv1)
        {
            TreeNode node = new TreeNode();
            node.Value = "0,0";
            node.Text = view[ComnCons.C2010004] + "";
            node.ToolTip = view[ComnCons.C2010005] + "";
            node.ShowCheckBox = true;
            node.SelectAction = TreeNodeSelectAction.None;
            root.ChildNodes.Add(node);

            BindKind(node, dv2, view[ComnCons.C2010002] + "");
        }
        tv_DataList.CollapseAll();
        root.Expand();
    }

    /// <summary>
    /// 功能类别数据绑定
    /// </summary>
    /// <param name="tn"></param>
    /// <param name="dv"></param>
    /// <param name="kn"></param>
    private void BindKind(TreeNode tn, DataView dv, String kn)
    {
        String old = dv.RowFilter;
        dv.RowFilter = WrpCons.W2039105 + "='" + kn + "'";
        foreach (DataRowView view in dv)
        {
            TreeNode node = new TreeNode();
            node.Value = view[WrpCons.W2039102] + "," + kn;
            node.Text = view[WrpCons.W2039107] + "";
            node.ToolTip = view[WrpCons.W2039109] + "";
            node.ShowCheckBox = true;
            node.Checked = StringUtil.isValidate(view[WrpCons.W2031103] + "", 16);
            node.SelectAction = TreeNodeSelectAction.None;
            tn.ChildNodes.Add(node);
        }
        dv.RowFilter = old;
    }

    /// <summary>
    /// 保存偏好设定
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Save_Click(object sender, EventArgs e)
    {
        Dictionary<String, int> link = new Dictionary<String, int>();
        Dictionary<String, int> kind = new Dictionary<String, int>();
        String code = UserInfo.Current(Session).UserCode;

        DBAccess dba = new DBAccess();

        // 读取所有当前用户的配置数据
        dba.addTable(WrpCons.W2031100);
        dba.addColumn(WrpCons.W2031101);
        dba.addColumn(WrpCons.W2031102);
        dba.addColumn(WrpCons.W2031104);
        dba.addWhere(WrpCons.W2031105, code);
        // 默认标记所有配置数据为删除状态
        foreach (DataRow row in dba.executeSelect().Rows)
        {
            if (row[WrpCons.W2031102] + "" == SrchCons.TYPE_USER_KIND)
            {
                kind[row[WrpCons.W2031104] + ""] = -1;
            }
            else
            {
                link[row[WrpCons.W2031104] + ""] = -1;
            }
        }

        // 读取用户选择的数据
        ReadNode(tv_DataList.Nodes[0], link, kind);

        long t = DateTime.UtcNow.ToBinary();

        // 循环处理类别数据
        foreach (string key in kind.Keys)
        {
            dba.reset();
            dba.addTable(WrpCons.W2031100);
            // 需要删除的类别
            if (kind[key] < 0)
            {
                dba.addWhere(WrpCons.W2031105, code);
                dba.addWhere(WrpCons.W2031104, key);
                dba.executeDelete();
            }
            // 需要新增的类别
            else if (kind[key] > 0)
            {
                dba.addParam(WrpCons.W2031101, "0");
                dba.addParam(WrpCons.W2031102, SrchCons.TYPE_USER_KIND);
                dba.addParam(WrpCons.W2031103, StringUtil.encodeLong(t++, false));
                dba.addParam(WrpCons.W2031104, key);
                dba.addParam(WrpCons.W2031105, code);
                dba.addParam(WrpCons.W2031106, "");
                dba.addParam(WrpCons.W2031107, EnvCons.SQL_NOW, false);
                dba.addParam(WrpCons.W2031108, EnvCons.SQL_NOW, false);
                dba.executeInsert();
            }
        }

        // 循环处理类别数据
        foreach (string key in link.Keys)
        {
            dba.reset();
            dba.addTable(WrpCons.W2031100);
            // 需要删除的类别
            if (link[key] < 0)
            {
                dba.addWhere(WrpCons.W2031105, code);
                dba.addWhere(WrpCons.W2031104, key);
                dba.executeDelete();
            }
            // 需要新增的类别
            else if (link[key] > 0)
            {
                dba.addParam(WrpCons.W2031101, "0");
                dba.addParam(WrpCons.W2031102, SrchCons.TYPE_USER_DATA);
                dba.addParam(WrpCons.W2031103, StringUtil.encodeLong(t++, false));
                dba.addParam(WrpCons.W2031104, key);
                dba.addParam(WrpCons.W2031105, code);
                dba.addParam(WrpCons.W2031106, "");
                dba.addParam(WrpCons.W2031107, EnvCons.SQL_NOW, false);
                dba.addParam(WrpCons.W2031108, EnvCons.SQL_NOW, false);
                dba.executeInsert();
            }
        }
    }

    /// <summary>
    /// 读取用户选择的数据
    /// </summary>
    /// <param name="node"></param>
    /// <param name="link"></param>
    /// <param name="kind"></param>
    private static void ReadNode(TreeNode node, IDictionary<String, int> link, IDictionary<String, int> kind)
    {
        if (node.Checked)
        {
            String[] arr = node.Value.Split(',');
            String tmp = arr[0];
            if (tmp != "0")
            {
                // 判断是否已经存在对应的链接
                if (link.ContainsKey(tmp))
                {
                    // 若为删除状态，则标记为无变更
                    if (link[tmp] == -1)
                    {
                        link[tmp] = 0;
                    }
                }
                // 若不包含指定链接，则标记为增加
                else
                {
                    link[tmp] = 1;
                }

                tmp = arr[1];
                // 判断是否已经存在对应的类别
                if (kind.ContainsKey(tmp))
                {
                    // 若为删除状态，则标记为无变更
                    if (kind[tmp] < 0)
                    {
                        kind[tmp] = 0;
                    }
                }
                // 若不包含指定类别，则标记为增加
                else
                {
                    kind[tmp] = 1;
                }
            }
        }
        foreach (TreeNode temp in node.ChildNodes)
        {
            ReadNode(temp, link, kind);
        }
    }

    /// <summary>
    /// 查看方式变更
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rb_ListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        tv_DataList.Nodes.Clear();
        if (rb_ListView.SelectedValue == "1")
        {
            LoadKind();
        }
        else
        {
            LoadSrch();
        }
    }

    /// <summary>
    /// 数据更新
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Update_Click(object sender, EventArgs e)
    {
        List<string> list = new List<string>();
        FindNode(tv_DataList.Nodes[0], list);
        if (list.Count > 0)
        {
            Response.Redirect("~/srch/srch9998.aspx?sid=" + list[0].Replace(",", "&uri="));
        }
    }

    private void FindNode(TreeNode node, List<string> list)
    {
        if (node.Checked)
        {
            list.Add(node.Value);
            return;
        }
        foreach (TreeNode temp in node.ChildNodes)
        {
            FindNode(temp, list);
        }
    }
}

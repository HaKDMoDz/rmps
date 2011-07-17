using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.IconLib;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
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
/// 链接编辑
/// </summary>
public partial class link_link0103 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_02)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 3;
        Session[cons.wrp.WrpCons.GUIDNAME] = "链接编辑";
        Session[cons.wrp.WrpCons.SCRIPTID] = "link0103";
        Session[cons.wrp.WrpCons.GUIDSIZE] = 5;

        if (IsPostBack)
        {
            return;
        }

        tf_P3070107.MaxLength = PrpCons.P3070107_SIZE;
        tf_P3070108.MaxLength = PrpCons.P3070108_SIZE;
        tf_P3070109.MaxLength = PrpCons.P3070109_SIZE;
        tf_P307010A.MaxLength = PrpCons.P307010A_SIZE;
        ta_P307010B.MaxLength = PrpCons.P307010B_SIZE;
        ta_P307010C.MaxLength = PrpCons.P307010C_SIZE;

        cb_P3070104.Attributes.Add("onchange", "return changeIcon();");
        ck_P3070104.Attributes.Add("onclick", "return changeView();");

        LoadData();
    }

    /// <summary>
    /// 界面数据绑定
    /// </summary>
    private void LoadData()
    {
        String sid = WrpUtil.text2Db(Request[cons.wrp.WrpCons.SID]);// 链接ID
        String uri = WrpUtil.text2Db(Request[cons.wrp.WrpCons.URI]);// 类别ID
        bool isEdit = StringUtil.isValidate(sid, 16);

        DBAccess dba = new DBAccess();

        // 查询门户网站
        dba.addTable(PrpCons.P3070100);
        dba.addColumn(PrpCons.P3070105);
        dba.addColumn(PrpCons.P3070106);
        dba.addColumn(PrpCons.P3070107);
        dba.addWhere(PrpCons.P3070103, UserInfo.Current(Session).UserCode);
        dba.addWhere(PrpCons.P3070104, "0");
        dba.addSort(PrpCons.P3070101, false);
        cb_P3070104.Items.Add(new ListItem("--请选择--", ""));
        cb_P3070104.Items.Add(new ListItem("《网站首页》", "0,0"));
        foreach (DataRow row in dba.executeSelect().Rows)
        {
            cb_P3070104.Items.Add(new ListItem(row[PrpCons.P3070107] + "", row[PrpCons.P3070105] + "," + row[PrpCons.P3070106]));
        }

        // 查询已有类别
        dba.addTable(PrpCons.P3070200);
        dba.addColumn(PrpCons.P3070203);
        dba.addWhere(PrpCons.P3070202, sid);
        IDictionary<String, bool> kind = new Dictionary<String, bool>();
        foreach (DataRow row in dba.executeSelect().Rows)
        {
            kind[row[PrpCons.P3070203] + ""] = true;
        }
        if (StringUtil.isValidate(uri, 16))
        {
            kind[uri] = true;
            hd_HistBack.Value = "/link/link0001.aspx";
        }
        dba.reset();

        // 链接编辑事件
        if (isEdit)
        {
            dba.addTable(PrpCons.P3070100);
            dba.addWhere(PrpCons.P3070103, UserInfo.Current(Session).UserCode);
            dba.addWhere(PrpCons.P3070105, sid);
            DataTable dt = dba.executeSelect();
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                cb_P3070104.SelectedValue = row[PrpCons.P3070104] + "";
                hd_P3070104.Value = row[PrpCons.P3070104] + "";
                hd_P3070105.Value = row[PrpCons.P3070105] + "";
                im_P3070106.ImageUrl = LinkCons.LINK_ICON_PATH + row[PrpCons.P3070106] + ".png";
                hd_P3070106.Value = row[PrpCons.P3070106] + "";
                tf_P3070107.Text = row[PrpCons.P3070107] + "";
                tf_P3070108.Text = row[PrpCons.P3070108] + "";
                tf_P3070109.Text = row[PrpCons.P3070109] + "";
                tf_P307010A.Text = row[PrpCons.P307010A] + "";
                ta_P307010B.Text = row[PrpCons.P307010B] + "";
                ta_P307010C.Text = row[PrpCons.P307010C] + "";
                hd_IsUpdate.Value = "1";
                ck_P3070104.Checked = false;
            }

            dba.reset();
        }

        // 链接类别显示
        dba.addTable(cons.io.db.comn.info.C2010000.C2010100);
        dba.addColumn(cons.io.db.comn.info.C2010000.C2010106);
        dba.addColumn(cons.io.db.comn.info.C2010000.C2010105);
        dba.addColumn(cons.io.db.comn.info.C2010000.C2010107);
        dba.addColumn(cons.io.db.comn.info.C2010000.C201010A);
        dba.addWhere(cons.io.db.comn.info.C2010000.C2010104, UserInfo.Current(Session).UserCode);
        dba.addWhere(cons.io.db.comn.info.C2010000.C2010102, LinkCons.LINK_STAT_NORMAL.ToString());
        dba.addSort(cons.io.db.comn.info.C2010000.C2010101, false);
        DataView dv = dba.executeSelect().DefaultView;

        // 用户链接
        TreeNode node = new TreeNode("我的类别", LinkCons.LINK_USER_HASH);
        node.Checked = (LinkCons.LINK_USER_HASH == uri);
        node.SelectAction = TreeNodeSelectAction.None;
        tv_P3070A05.Nodes.Add(node);
        BindKind(dv, node, LinkCons.LINK_USER_HASH, kind);
        tv_P3070A05.CollapseAll();
        node.Expand();

        if (tf_P3070A05.Value == "")
        {
            tf_P3070A05.Value = "--请选择--";
        }

        // 外部收藏事件
        if (!isEdit)
        {
            tf_P3070107.Text = Request["t"];
            tf_P3070108.Text = Request["t"];
            tf_P3070109.Text = Request["u"];
            ta_P307010C.Text = Request["d"];
        }
    }

    /// <summary>
    /// 类别绑定
    /// </summary>
    /// <param name="dv"></param>
    /// <param name="key"></param>
    /// <param name="def"></param>
    private void BindKind(DataView dv, TreeNode cur, String key, IDictionary<String, bool> def)
    {
        String old = dv.RowFilter;
        dv.RowFilter = cons.io.db.comn.info.C2010000.C2010106 + "='" + key + "'";
        foreach (DataRowView view in dv)
        {
            String tmp = view[cons.io.db.comn.info.C2010000.C2010105] + "";

            TreeNode node = new TreeNode();
            node.Value = tmp;
            node.Text = view[cons.io.db.comn.info.C2010000.C2010107] + "";
            node.ToolTip = view[cons.io.db.comn.info.C2010000.C201010A] + "";
            if (def.ContainsKey(tmp))
            {
                node.Checked = true;
                tf_P3070A05.Value += node.Text + ';';
            }
            node.SelectAction = TreeNodeSelectAction.None;
            cur.ChildNodes.Add(node);

            BindKind(dv, node, tmp, def);
        }
        dv.RowFilter = old;
    }

    /// <summary>
    /// 提取网站LOGO
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void im_P3070109_Click(object sender, ImageClickEventArgs e)
    {
        String url = tf_P3070109.Text + '/';
        int s = url.IndexOf("://");
        if (s < 0)
        {
            url = "http://" + url;
            s = 4;
        }
        s = url.IndexOf("/", s + 3);
        if (s < 0)
        {
            return;
        }
        url = url.Substring(0, s + 1) + "favicon.ico";

        try
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            ReadImg(stream);
        }
        catch (Exception)
        {
        }
    }

    /// <summary>
    /// 图标文件上传
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_P3070106_Click(object sender, EventArgs e)
    {
        String fileName = fu_P3070106.FileName;
        if (!StringUtil.isValidate(fileName))
        {
            Wrps.ShowMesg(Master, "请选择您要上传的文件！");
            return;
        }

        Stream stream = fu_P3070106.FileContent;
        if (stream == null || stream.Length < 1)
        {
            Wrps.ShowMesg(Master, "无法读取您选择文件，请确认路径是否正确！");
            return;
        }

        if (stream.Length > 10240)
        {
            Wrps.ShowMesg(Master, "上传文件大小不能超过 10K ！");
            return;
        }

        try
        {
            ReadImg(stream);
        }
        catch (Exception)
        {
        }
    }

    /// <summary>
    /// 保存图标文件。
    /// </summary>
    /// <param name="stream"></param>
    private void ReadImg(Stream stream)
    {
        if (stream == null)
        {
            return;
        }
        MemoryStream ms = new MemoryStream();
        int b = stream.ReadByte();
        while (b >= 0)
        {
            ms.WriteByte((byte)b);
            b = stream.ReadByte();
        }
        stream.Close();

        // 提取资源文件图标
        MultiIcon mIcon = new MultiIcon();
        mIcon.Load(ms);
        ms.Close();
        if (mIcon.Count < 1)
        {
            return;
        }

        Bitmap bmp = null;
        foreach (SingleIcon sIcon in mIcon)
        {
            PixelFormat lpf = PixelFormat.Format1bppIndexed;
            for (int k = sIcon.Count - 1; k >= 0; k -= 1)
            {
                IconImage img = sIcon[k];

                bmp = img.Icon.ToBitmap();
                if (bmp.Width != 16)
                {
                    continue;
                }

                // 低像素图像忽略
                if (img.PixelFormat < lpf)
                {
                    continue;
                }

                // 记录当前图像像素
                if (img.PixelFormat > lpf)
                {
                    lpf = img.PixelFormat;
                }
            }
        }

        if (bmp != null)
        {
            if (!StringUtil.isValidate(hd_P3070106.Value, 16))
            {
                hd_P3070106.Value = HashUtil.getCurrTimeHex(false);
            }
            String filePath = LinkCons.LINK_ICON_PATH + hd_P3070106.Value + ".png";
            bmp.Save(Server.MapPath(filePath), ImageFormat.Png);
            im_P3070106.ImageUrl = filePath;
        }
    }

    /// <summary>
    /// 链接数据保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        List<TreeNode> list = new List<TreeNode>();
        foreach (TreeNode node in tv_P3070A05.Nodes)
        {
            ReadNode(node, list);
        }
        if (list.Count < 1)
        {
            Wrps.ShowMesg(Master, "请选择上级类别！");
            return;
        }

        String temp = cb_P3070104.SelectedValue.Trim();
        if (temp == "")
        {
            Wrps.ShowMesg(Master, "请选择从属网站！");
            return;
        }

        String P3070106 = ck_P3070104.Checked ? temp.Split(',')[1] : hd_P3070106.Value;
        if (!StringUtil.isValidate(P3070106))
        {
            P3070106 = "0";
        }
        temp = temp.Split(',')[0];

        DBAccess dba = new DBAccess();
        dba.addTable(PrpCons.P3070100);
        dba.addParam(PrpCons.P3070104, temp);// 从属门户
        dba.addParam(PrpCons.P3070106, P3070106);//网站LOGO
        dba.addParam(PrpCons.P3070107, WrpUtil.text2Db(tf_P3070107.Text));//链接名称
        dba.addParam(PrpCons.P3070108, WrpUtil.text2Db(tf_P3070108.Text));//网站标题
        dba.addParam(PrpCons.P3070109, WrpUtil.text2Db(tf_P3070109.Text));//链接路径
        dba.addParam(PrpCons.P307010A, WrpUtil.text2Db(tf_P307010A.Text));//关键搜索
        dba.addParam(PrpCons.P307010B, WrpUtil.text2Db(ta_P307010B.Text));//网站描述
        dba.addParam(PrpCons.P307010C, WrpUtil.text2Db(ta_P307010C.Text));//相关说明
        dba.addParam(PrpCons.P307010D, EnvCons.SQL_NOW, false);

        if (hd_IsUpdate.Value == "1")
        {
            dba.addWhere(PrpCons.P3070103, UserInfo.Current(Session).UserCode);
            dba.addWhere(PrpCons.P3070105, hd_P3070105.Value);
            if (dba.executeUpdate() == 1)
            {
                // 删除已有类别信息
                DeleteRef(dba, hd_P3070105.Value);
            }

            // 添加类别
            foreach (TreeNode node in list)
            {
                InsertRef(dba, hd_P3070105.Value, node.Value);
            }

            hd_P3070106.Value = P3070106;
            im_P3070106.ImageUrl = LinkCons.LINK_ICON_PATH + P3070106 + ".png";

            Wrps.ShowMesg(Master, "数据更新成功！");
        }
        else
        {
            String hash = HashUtil.getCurrTimeHex(false);
            dba.addParam(PrpCons.P3070101, "0");
            dba.addParam(PrpCons.P3070102, LinkCons.LINK_STAT_NORMAL);
            dba.addParam(PrpCons.P3070103, UserInfo.Current(Session).UserCode);
            dba.addParam(PrpCons.P3070105, hash);
            dba.addParam(PrpCons.P307010E, EnvCons.SQL_NOW, false);
            dba.executeInsert();

            // 添加类别
            foreach (TreeNode node in list)
            {
                InsertRef(dba, hash, node.Value);
            }

            Wrps.ShowMesg(Master, "数据添加成功！");

            hd_P3070106.Value = "0";
            im_P3070106.ImageUrl = LinkCons.LINK_ICON_PATH + "0.png";
            tf_P3070107.Text = "";
            tf_P3070108.Text = "";
            tf_P3070109.Text = "";
            tf_P307010A.Text = "";
            ta_P307010B.Text = "";
            ta_P307010C.Text = "";

            tf_P3070107.Focus();
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

    /// <summary>
    /// 清除分类链接
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="linkHash"></param>
    private void DeleteRef(DBAccess dba, String linkHash)
    {
        dba.reset();
        dba.addTable(PrpCons.P3070200);
        dba.addWhere(PrpCons.P3070202, linkHash);
        dba.executeDelete();
    }

    /// <summary>
    /// 添加分类链接
    /// </summary>
    /// <param name="dba"></param>
    /// <param name="linkHash"></param>
    /// <param name="kindHash"></param>
    private void InsertRef(DBAccess dba, String linkHash, String kindHash)
    {
        dba.reset();
        dba.addTable(PrpCons.P3070200);
        dba.addParam(PrpCons.P3070201, 0);
        dba.addParam(PrpCons.P3070202, linkHash);
        dba.addParam(PrpCons.P3070203, kindHash);
        dba.executeInsert();
    }
}
using System;
using System.Data;
using System.Drawing;
using System.Drawing.IconLib;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using cons;
using cons.wrp;
using cons.wrp.srch;
using rmp.io.db;
using rmp.comn.user;
using rmp.util;
using rmp.wrp;

using Util = rmp.comn.Util;

public partial class srch_srch9998 : Page
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
        Session[cons.wrp.WrpCons.GUIDNAME] = "全能搜索";
        Session[cons.wrp.WrpCons.SCRIPTID] = "srch9998";
        Session[cons.wrp.WrpCons.GUIDSIZE] = Wrps.GuidSrch(Session).Count;

        // 页面事件类型判断
        if (IsPostBack)
        {
            return;
        }

        cb_W2039104.Attributes.Add("onchange", "changeIcon();");
        ck_W2039104.Attributes.Add("onchange", "changeView();");
        Util.InitLangData(cb_W2039103, true);
        Util.InitCat1Data(cb_W2039105, SysCons.UI_LANGHASH, SysCons.SRCH_HASH, true);

        LoadData();
    }

    private void LoadData()
    {
        DBAccess dba = new DBAccess();

        // 门户网站绑定
        dba.addTable(cons.io.db.wrp.WrpCons.W2039100);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2039102);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2039106);
        dba.addColumn(cons.io.db.wrp.WrpCons.W2039107);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2039104, "0");
        dba.addSort(cons.io.db.wrp.WrpCons.W2039101, false);

        cb_W2039104.Items.Add(new ListItem("请选择", ""));
        cb_W2039104.Items.Add(new ListItem("《网站首页》", "0,0"));
        foreach (DataRow row in dba.executeSelect().Rows)
        {
            cb_W2039104.Items.Add(new ListItem(row[cons.io.db.wrp.WrpCons.W2039107] + "", row[cons.io.db.wrp.WrpCons.W2039102] + "," + row[cons.io.db.wrp.WrpCons.W2039106]));
        }

        String sid = WrpUtil.text2Db(Request[WrpCons.SID]);
        if (!StringUtil.isValidate(sid, 16))
        {
            return;
        }

        dba.reset();
        dba.addTable(cons.io.db.wrp.WrpCons.W2039100);
        dba.addWhere(cons.io.db.wrp.WrpCons.W2039102, sid);
        DataTable dt = dba.executeSelect();
        if (dt == null || dt.Rows.Count != 1)
        {
            return;
        }

        DataRow dr = dt.Rows[0];
        hd_W2039102.Value = dr[cons.io.db.wrp.WrpCons.W2039102] + "";
        cb_W2039103.SelectedValue = dr[cons.io.db.wrp.WrpCons.W2039103] + "";
        hd_W2039104.Value = dr[cons.io.db.wrp.WrpCons.W2039104] + "";
        cb_W2039105.SelectedValue = dr[cons.io.db.wrp.WrpCons.W2039105] + "";
        im_W2039106.ImageUrl = SrchCons.SRCH_ICON_PATH + dr[cons.io.db.wrp.WrpCons.W2039106] + ".png";
        hd_W2039106.Value = dr[cons.io.db.wrp.WrpCons.W2039106] + "";
        tf_W2039107.Text = dr[cons.io.db.wrp.WrpCons.W2039107] + "";
        tf_W2039108.Text = dr[cons.io.db.wrp.WrpCons.W2039108] + "";
        tf_W2039109.Text = dr[cons.io.db.wrp.WrpCons.W2039109] + "";
        tf_W203910A.Text = dr[cons.io.db.wrp.WrpCons.W203910A] + "";
        tf_W203910C.Text = dr[cons.io.db.wrp.WrpCons.W203910C] + "";

        hd_IsUpdate.Value = "1";
    }

    /// <summary>
    /// 自动查找网站LOGO
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void im_W203910A_Click(object sender, ImageClickEventArgs e)
    {
        String url = tf_W203910A.Text + '/';
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
    protected void bt_W2039106_Click(object sender, EventArgs e)
    {
        String fileName = fu_W2039106.FileName;
        if (!StringUtil.isValidate(fileName))
        {
            Wrps.ShowMesg(Master, "请选择您要上传的文件！");
            return;
        }

        Stream stream = fu_W2039106.FileContent;
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
            if (!StringUtil.isValidate(hd_W2039106.Value, 16))
            {
                hd_W2039106.Value = HashUtil.getCurrTimeHex(false);
            }
            String filePath = SrchCons.SRCH_ICON_PATH + hd_W2039106.Value + ".png";
            bmp.Save(Server.MapPath(filePath), ImageFormat.Png);
            im_W2039106.ImageUrl = filePath;
        }
    }

    /// <summary>
    /// 搜索引擎数据保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        String[] arr = cb_W2039104.SelectedValue.Split(',');
        String W2039106 = ck_W2039104.Checked ? arr[1] : hd_W2039106.Value;

        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.wrp.WrpCons.W2039100);
        dba.addParam(cons.io.db.wrp.WrpCons.W2039103, cb_W2039103.SelectedValue);
        dba.addParam(cons.io.db.wrp.WrpCons.W2039104, arr[0]);
        dba.addParam(cons.io.db.wrp.WrpCons.W2039105, cb_W2039105.SelectedValue);
        dba.addParam(cons.io.db.wrp.WrpCons.W2039106, W2039106);
        dba.addParam(cons.io.db.wrp.WrpCons.W2039107, WrpUtil.text2Db(tf_W2039107.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W2039108, WrpUtil.text2Db(tf_W2039108.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W2039109, WrpUtil.text2Db(tf_W2039109.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W203910A, WrpUtil.text2Db(tf_W203910A.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W203910B, cb_W203910B.SelectedValue);
        dba.addParam(cons.io.db.wrp.WrpCons.W203910C, WrpUtil.text2Db(tf_W203910C.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W203910D, WrpUtil.text2Db(ta_W203910D.Text));
        dba.addParam(cons.io.db.wrp.WrpCons.W203910E, EnvCons.SQL_NOW, false);
        if (hd_IsUpdate.Value == "1")
        {
            dba.addWhere(cons.io.db.wrp.WrpCons.W2039102, hd_W2039102.Value);
            dba.executeUpdate();

            Wrps.ShowMesg(Master, "数据更新成功！");

            im_W2039106.ImageUrl = SrchCons.SRCH_ICON_PATH + W2039106 + ".png";
            hd_W2039106.Value = W2039106;
        }
        else
        {
            string W2039102 = HashUtil.getCurrTimeHex(false);
            dba.addParam(cons.io.db.wrp.WrpCons.W2039101, 0);
            dba.addParam(cons.io.db.wrp.WrpCons.W2039102, W2039102);
            dba.addParam(cons.io.db.wrp.WrpCons.W203910F, EnvCons.SQL_NOW, false);
            dba.executeInsert();

            Wrps.ShowMesg(Master, "数据新增成功！");

            // 添加门户网站列表
            if (arr[0] == "0")
            {
                cb_W2039104.Items.Add(new ListItem(tf_W2039107.Text, W2039102));
            }

            im_W2039106.ImageUrl = SrchCons.SRCH_ICON_PATH + "0.png";
            hd_W2039106.Value = "0";
            tf_W2039107.Text = "";
            tf_W2039108.Text = "";
            tf_W2039109.Text = "";
            tf_W203910A.Text = "";
            tf_W203910C.Text = "";
            ta_W203910D.Text = "";
        }
    }
}

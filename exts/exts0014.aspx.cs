using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.UI;

using rmp.bean;
using rmp.io.db;
using rmp.util;
using rmp.wrp;
using rmp.wrp.exts;

/// <summary>
/// 软件信息
/// </summary>
public partial class exts_exts0014 : Page
{
    private rmp.comn.user.UserInfo userInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        // ====================================================================
        // 用户身份认证
        // ====================================================================
        userInfo = rmp.comn.user.UserInfo.Current(Session);
        if (userInfo.UserRank <= cons.comn.user.UserInfo.LEVEL_05)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 4;
        Session[cons.wrp.WrpCons.GUIDNAME] = "数据管理";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts0014";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count - 2;

        K1V2 guidItem = guidList[3];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0010.aspx";
        guidItem.V1 = "数据管理";
        guidItem.V2 = "数据管理";

        guidItem = guidList[4];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts0014.aspx";
        guidItem.V1 = "软件信息";
        guidItem.V2 = "软件信息";

        if (IsPostBack)
        {
            return;
        }

        // 设置默认显示
        Bean extsBase = (Bean)Session[cons.wrp.WrpCons.P3010000_BEAN];
        if (extsBase == null)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        Exts.InitSoftData(cb_P3010006, extsBase.P3010005, true);
        cb_P3010006.SelectedValue = extsBase.P3010006;
        bt_SaveData.Enabled = extsBase.IsUpdate;
    }

    protected void bt_NextStep_Click(object sender, EventArgs e)
    {
        Bean extsBase = (Bean)Session[cons.wrp.WrpCons.P3010000_BEAN];
        if (extsBase == null)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        extsBase.P3010006 = cb_P3010006.SelectedValue;
        Response.Redirect("~/exts/exts0015.aspx");
    }

    /// <summary>
    /// 保存数据按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_SaveData_Click(object sender, EventArgs e)
    {
        Bean extsBase = (Bean)Session[cons.wrp.WrpCons.P3010000_BEAN];
        if (extsBase == null)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        Exts.SaveBase(extsBase);
        Exts.needQuery(Session, true);
        Response.Redirect("~/exts/exts0001.aspx");
    }

    /// <summary>
    /// 运行截图上传按钮事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_P301020A_Click(object sender, EventArgs e)
    {
        String name = fu_P301020A.FileName;
        if (!StringUtil.isValidate(name))
        {
            return;
        }

        if (fu_P301020A.FileContent.Length < 1)
        {
            return;
        }

        try
        {
            Image img = Image.FromStream(fu_P301020A.FileContent);

            img = Scale(img, 800, 600);

            if (hd_P301020A.Value.Length != 16)
            {
                hd_P301020A.Value = HashUtil.getCurrTimeHex(false);
            }
            img.Save(Server.MapPath("view/") + hd_P301020A.Value + ".png", ImageFormat.Png);

            fu_P301020A.FileContent.Close();
        }
        catch (Exception)
        {
            return;
        }
    }

    /// <summary>
    /// 图像缩放处理
    /// </summary>
    /// <param name="original"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    private static Image Scale(Image original, int width, int height)
    {
        if (original.Width < width && original.Height < height)
        {
            return original;
        }

        Bitmap tn = new Bitmap(width, height);
        Graphics g = Graphics.FromImage(tn);
        g.InterpolationMode = InterpolationMode.HighQualityBilinear;
        int w = original.Width;
        int h = original.Height;
        double sw = (double)width / w;
        double sh = (double)height / h;
        double ss = sw <= sh ? sw : sh;
        w = (int)(ss * w);
        h = (int)(ss * h);
        int x = (width - w) >> 1;
        int y = (height - h) >> 1;
        g.DrawImage(original, new Rectangle(x, y, w, h), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel);
        g.Dispose();
        return tn;
    }

    /// <summary>
    /// 新增数据按钮保存事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_Insert_Click(object sender, EventArgs e)
    {
        Bean extsBase = (Bean)Session[cons.wrp.WrpCons.P3010000_BEAN];
        if (extsBase == null)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        hd_P3010204.Value = Exts.NextIcon(hd_UpdtIcon.Value, "soft", hd_P3010204.Value);

        String hash = HashUtil.getCurrTimeHex(false);
        DBAccess dba = new DBAccess();
        dba.addTable(cons.io.db.prp.PrpCons.P3010200);
        dba.addParam(cons.io.db.prp.PrpCons.P3010201, 0); //显示排序
        dba.addParam(cons.io.db.prp.PrpCons.P3010202, hash); //软件索引
        dba.addParam(cons.io.db.prp.PrpCons.P3010203, extsBase.P3010005); //公司信息
        dba.addParam(cons.io.db.prp.PrpCons.P3010204, hd_P3010204.Value); //软件图标
        dba.addParam(cons.io.db.prp.PrpCons.P3010205, WrpUtil.text2Db(tf_P3010205.Text)); //软件名称
        dba.addParam(cons.io.db.prp.PrpCons.P3010206, WrpUtil.text2Db(tf_P3010206.Text)); //英文名称
        dba.addParam(cons.io.db.prp.PrpCons.P3010207, WrpUtil.text2Db(tf_P3010207.Text)); //联系邮件
        dba.addParam(cons.io.db.prp.PrpCons.P3010208, WrpUtil.text2Db(tf_P3010208.Text)); //链接地址
        dba.addParam(cons.io.db.prp.PrpCons.P3010209, ""); //兼容后缀
        dba.addParam(cons.io.db.prp.PrpCons.P301020A, hd_P301020A.Value); //运行截图
        dba.addParam(cons.io.db.prp.PrpCons.P301020B, WrpUtil.text2Db(ta_P301020B.Text)); //软件描述
        dba.addParam(cons.io.db.prp.PrpCons.P301020C, WrpUtil.text2Db(ta_P301020C.Text)); //附注信息
        dba.addParam(cons.io.db.prp.PrpCons.P301020D, cons.EnvCons.SQL_NOW, false); //更新日期
        dba.addParam(cons.io.db.prp.PrpCons.P301020E, cons.EnvCons.SQL_NOW, false); //创建日期
        dba.addParam(cons.io.db.prp.PrpCons.P301020F, 0);
        dba.addParam(cons.io.db.prp.PrpCons.P3010210, cons.wrp.WrpCons.OPT_NORMAL);
        dba.addParam(cons.io.db.prp.PrpCons.P3010211, userInfo.UserCode);

        //执行数据插入操作
        dba.executeInsert();

        Exts.SaveIcon(hd_UpdtIcon.Value, hd_IconPath.Value, hd_IconHash.Value, hd_P3010204.Value, true, 0);

        // 恢复界面初始状态
        ib_P3010204.ImageUrl = "soft" + "00030.png";
        tf_P3010205.Text = "";
        tf_P3010206.Text = "";
        tf_P3010207.Text = "";
        tf_P3010208.Text = "";
        hd_P301020A.Value = "";
        ta_P301020B.Text = "";
        ta_P301020C.Text = "";

        // 更新软件列表
        cb_P3010006.Items.Clear();
        Exts.InitSoftData(cb_P3010006, extsBase.P3010005, true);
        cb_P3010006.SelectedValue = hash;
    }
}
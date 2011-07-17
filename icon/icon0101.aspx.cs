using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI;
using rmp.comn.user;
using rmp.wrp.exts;

/// <summary>
/// 常见图像文件上传（如PNG、JPG、GIF等）
/// </summary>
public partial class icon_icon0101 : Page
{
    protected const int COL_SIZE = 5;
    protected const String DIR_PATH = "img/";
    protected ArrayList iconList = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_02)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        if (IsPostBack)
        {
            return;
        }

        cb_ImgScale.Attributes.Add("onchange", "changeSize();");
        String sName = Request["sid"];
        hd_IconHash.Value = sName;
        ListIcon(Server.MapPath(DIR_PATH), sName);
    }

    protected void lb_DeltFile_Click(object sender, EventArgs e)
    {
        String sPath = Server.MapPath(DIR_PATH);
        File.Delete(sPath + hd_DeltFile.Value);

        ListIcon(sPath, hd_IconHash.Value);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_FileUpld_Click(object sender, EventArgs e)
    {
        String cName = fu_FileUpld.FileName;
        if (cName == null || cName.Trim() == "")
        {
            lb_ErrMsg.Text = "请选择你要上传的文件！";
            return;
        }

        // 判断上传文件流合法性
        Stream stream = fu_FileUpld.FileContent;
        if (stream == null || stream.Length < 1)
        {
            lb_ErrMsg.Text = "请选择你要上传的文件！";
            return;
        }

        // 限制最大上传文件大小
        if (stream.Length > 2000000)
        {
            lb_ErrMsg.Text = "由于网速影响，请不要上传超过 2M 的文件，谢谢您的配合！";
            return;
        }

        // 文件格式信息检测
        cName = cName.ToLower();
        String[] exts = { ".png", ".jpg", ".jpeg", ".jiff", ".gif", ".bmp" };
        bool fext = false;
        foreach (string s in exts)
        {
            if (cName.EndsWith(s))
            {
                fext = LoadIcon(stream);
                break;
            }
        }
        if (!fext)
        {
            lb_ErrMsg.Text = "请上传 png、jpg、gif、bmp 格式的文件！";
        }
        stream.Close();
    }

    /// <summary>
    /// 保存PNG图像
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    private bool LoadIcon(Stream stream)
    {
        int w;
        try
        {
            w = int.Parse(tf_ImgWidth.Value.Trim());
        }
        catch (Exception)
        {
            w = -1;
        }

        int h;
        try
        {
            h = int.Parse(tf_ImgHight.Value.Trim());
        }
        catch (Exception)
        {
            h = -1;
        }

        String sName = hd_IconHash.Value;
        String sPath = Server.MapPath(DIR_PATH);

        try
        {
            Image img = Image.FromStream(stream);
            if (w == -1)
            {
                w = img.Width;
            }
            if (h == -1)
            {
                h = img.Height;
            }
            img = Exts.GenerateThumbnail(img, w, h, ck_ImgScale.Checked, ck_ImgRatio.Checked);
            img.Save(sPath + sName + Convert.ToString(w, 16).PadLeft(4, '0') + ".png", ImageFormat.Png);
            ListIcon(sPath, sName);
            return true;
        }
        catch (Exception exp)
        {
            lb_ErrMsg.Text = "上传图片处理错误：" + exp.Message;
        }
        return false;
    }

    /// <summary>
    /// 图像从大到小显示
    /// </summary>
    /// <param name="sPath"></param>
    /// <param name="sName"></param>
    private void ListIcon(String sPath, String sName)
    {
        String[] fileList = Directory.GetFiles(sPath, sName + "*.png");
        iconList.Clear();
        String file;
        for (int j = 0; j < fileList.Length; j += 1)
        {
            file = Path.GetFileName(fileList[j]).ToLower();
            int i = 0;
            while (i < iconList.Count)
            {
                if (file.CompareTo(iconList[i]) > 0)
                {
                    break;
                }
                i += 1;
            }
            iconList.Insert(i, file);
        }
    }
}
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.IconLib;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI;

using cons.wrp;

using rmp.comn.user;
using rmp.util;

/// <summary>
/// 资源图标提取
/// </summary>
public partial class icon_icon0103 : Page
{
    protected const int COL_SIZE = 5;
    protected const String DIR_PATH = "res/";
    protected const int ROW_SIZE = 6;
    protected ArrayList iconList = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserInfo.Current(Session).UserRank < cons.comn.user.UserInfo.LEVEL_02)
        {
            Response.Redirect("~/index.aspx");
            return;
        }

        tr_ErrMsg.Visible = false;

        if (IsPostBack)
        {
            return;
        }

        hd_IconHash.Value = Request[WrpCons.SID];

        String[] file = Directory.GetFiles(Server.MapPath(DIR_PATH), "*0030.png");
        int indx = 0;
        while (indx < file.Length)
        {
            iconList.Add(Path.GetFileName(file[indx++]));
        }
    }

    /// <summary>
    /// 文件上传事件处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_FileUpld_Click(object sender, EventArgs e)
    {
        // 判断上传文件名合法性
        String cName = fu_FileUpld.FileName;
        if (cName == null || cName.Trim() == "")
        {
            lb_ErrMsg.Text = "请选择你要上传的文件！";
            tr_ErrMsg.Visible = true;
            return;
        }

        // 判断上传文件流合法性
        Stream stream = fu_FileUpld.FileContent;
        if (stream == null || stream.Length < 1)
        {
            lb_ErrMsg.Text = "请选择你要上传的文件！";
            tr_ErrMsg.Visible = true;
            return;
        }

        // 限制最大上传文件大小
        if (stream.Length > 2000000)
        {
            lb_ErrMsg.Text = "由于网速影响，请不要上传超过 2M 的文件，谢谢您的配合！";
            tr_ErrMsg.Visible = true;
            return;
        }

        // 清除图像文件列表
        iconList.Clear();

        // 从文件提取图标
        cName = cName.ToLower();
        String[] exts = { ".ico", ".icl", ".dll", ".exe", ".ocx", ".cpl", ".src" };
        bool fext = false;
        foreach (String s in exts)
        {
            if (cName.EndsWith(s))
            {
                cName = cName.Substring(0, Path.GetExtension(cName).Length);
                fext = LoadIcon(stream, cName);
                break;
            }
        }

        if (!fext)
        {
            lb_ErrMsg.Text = "请上传 ico、icl、dll、exe、ocx、cpl、src 格式的文件！";
            tr_ErrMsg.Visible = true;
        }
        stream.Close();
    }

    /// <summary>
    /// 从资源文件提取.ico文件
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="fileName"></param>
    private bool LoadIcon(Stream stream, String fileName)
    {
        try
        {
            // 提取资源文件图标
            MultiIcon mIcon = new MultiIcon();
            mIcon.Load(stream);
            if (mIcon.Count < 1)
            {
                return false;
            }

            long t = DateTime.Now.ToBinary();
            foreach (SingleIcon sIcon in mIcon)
            {
                String iconName = StringUtil.encodeLong(t++, true);
                PixelFormat lpf = PixelFormat.Format1bppIndexed;
                for (int k = sIcon.Count - 1; k >= 0; k -= 1)
                {
                    IconImage img = sIcon[k];

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

                    Bitmap bmp = img.Icon.ToBitmap();
                    bmp.Save(Server.MapPath(DIR_PATH + iconName + Convert.ToString(bmp.Width, 16).PadLeft(4, '0') + ".png"), ImageFormat.Png);
                }

                iconList.Add(iconName + "0030.png");
            }
            return true;
        }
        catch (Exception e)
        {
            lb_ErrMsg.Text = "图标提取错误：" + e.Message;
            tr_ErrMsg.Visible = true;
            return false;
        }
    }
}
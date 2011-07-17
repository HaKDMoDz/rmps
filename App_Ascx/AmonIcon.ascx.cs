using System;
using System.Web.UI.WebControls;

public partial class App_Ascx_AmonIcon : System.Web.UI.UserControl
{
    private bool enabled;
    private bool editable;
    private bool viewable;
    private bool createEditDiv;
    private bool createViewDiv;
    private int iconSize = 48;
    private String toolTips = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        InitData();
    }

    public void InitData()
    {
        // 图像大小
        Unit unit = new Unit(iconSize);
        ib_AmonIcon.Width = unit;
        ib_AmonIcon.Height = unit;

        ib_AmonIcon.AlternateText = toolTips;

        // 图像是否可编辑
        if (editable)
        {
            ib_AmonIcon.OnClientClick = "return editIcon('" + ClientID + "');";
            ib_AmonIcon.ToolTip = toolTips + "，点击修改";

            // 图像是否可响应
            ib_AmonIcon.Enabled = enabled & true;
        }
        // 图像是否可预览
        else if (viewable)
        {
            ib_AmonIcon.OnClientClick = "return viewIcon('" + DstIconHash + "','" + ClientID + "');";
            ib_AmonIcon.ToolTip = toolTips + "，点击查看";

            // 图像是否可响应
            ib_AmonIcon.Enabled = enabled & true;
        }
        else
        {
            ib_AmonIcon.ToolTip = toolTips;

            // 图像是否可响应
            ib_AmonIcon.Enabled = false;
        }

        ViewIcon();
    }

    /// <summary>
    /// 显示默认图片
    /// </summary>
    private void ViewIcon()
    {
        if (hd_UserOpt.Value != "0")
        {
            ib_AmonIcon.ImageUrl = cons.EnvCons.PRE_URL + hd_SrcPath.Value + hd_SrcHash.Value + Convert.ToString(iconSize, 16).PadLeft(4, '0') + ".png";
        }
        else
        {
            ib_AmonIcon.ImageUrl = cons.EnvCons.PRE_URL + "/icon/icon0001.ashx?uri=" + iconSize + "&sid=" + hd_DstHash.Value;
        }
    }

    /// <summary>
    /// 返回下一个图片
    /// </summary>
    /// <returns></returns>
    public String NextIcon()
    {
        String hash = rmp.wrp.exts.Exts.NextIcon(hd_UserOpt.Value, hd_DstPath.Value, hd_DstHash.Value);
        hd_DstHash.Value = hash;
        return hash;
    }

    /// <summary>
    /// 保存图片
    /// </summary>
    /// <param name="isManage"></param>
    /// <param name="operate"></param>
    public bool SaveIcon(bool isManage, long operate)
    {
        rmp.wrp.exts.Exts.SaveIcon(hd_UserOpt.Value, hd_SrcPath.Value, hd_SrcHash.Value, hd_DstHash.Value, isManage, operate);
        hd_UserOpt.Value = "0";
        return true;
    }

    /// <summary>
    /// 读取或设置图片默认显示大小
    /// </summary>
    public int IconSize
    {
        get
        {
            return iconSize;
        }
        set
        {
            iconSize = value;
        }
    }

    /// <summary>
    /// 读取或设置目标保存目录
    /// </summary>
    public String DstIconPath
    {
        get
        {
            return hd_DstPath.Value;
        }
        set
        {
            String path = value;
            if (!path.EndsWith("/"))
            {
                path += '/';
            }
            hd_DstPath.Value = path;
        }
    }

    /// <summary>
    /// 读取或设置目标文件名称
    /// </summary>
    public String DstIconHash
    {
        get
        {
            return hd_DstHash.Value;
        }
        set
        {
            hd_DstHash.Value = value;
        }
    }

    /// <summary>
    /// 获取临时保存目录
    /// </summary>
    public String SrcIconPath
    {
        get
        {
            return hd_SrcPath.Value;
        }
        set
        {
            String path = value;
            if (!path.EndsWith("/"))
            {
                path += '/';
            }
            hd_SrcPath.Value = path;
        }
    }

    /// <summary>
    /// 获取临时文件名称
    /// </summary>
    public String SrcIconHash
    {
        get
        {
            return hd_SrcHash.Value;
        }
    }

    /// <summary>
    /// 读取或设置图像是否可响应
    /// </summary>
    public bool Enabled
    {
        get
        {
            return enabled;
        }
        set
        {
            enabled = value;
        }
    }

    public bool Editable
    {
        get
        {
            return editable;
        }
        set
        {
            editable = value;
        }
    }

    public bool Viewable
    {
        get
        {
            return viewable;
        }
        set
        {
            viewable = value;
        }
    }

    /// <summary>
    /// 读取或设置图像提示文本
    /// </summary>
    public String ToolTip
    {
        get
        {
            return toolTips;
        }
        set
        {
            toolTips = value;
        }
    }

    /// <summary>
    /// 读取或设置是否生成图标编辑DIV
    /// </summary>
    public bool CreateEditDiv
    {
        get
        {
            return createEditDiv;
        }
        set
        {
            createEditDiv = value;
        }
    }

    /// <summary>
    /// 读取或设置是否生成图标查看DIV
    /// </summary>
    public bool CreateViewDiv
    {
        get
        {
            return createViewDiv;
        }
        set
        {
            createViewDiv = value;
        }
    }
}

using System;
using System.Web.UI.WebControls;

public partial class App_Ascx_AmonIcon : System.Web.UI.UserControl
{
    private bool enabled;
    private bool createDiv;
    private int iconSize = 48;
    private String toolTips = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (hd_UserOpt.Value != "0")
        {
            ib_AmonIcon.ImageUrl = cons.EnvCons.PRE_URL + hd_SrcPath.Value + hd_SrcHash.Value + Convert.ToString((int)ib_AmonIcon.Width.Value, 16).PadLeft(4, '0') + ".png";
        }
        else
        {
            ib_AmonIcon.ImageUrl = cons.EnvCons.PRE_URL + "/icon/icon0001.ashx?uri=" + iconSize + "&sid=" + hd_DstHash.Value;
        }

        if (IsPostBack)
        {
            return;
        }
    }

    public void InitData()
    {
        Unit unit = new Unit(iconSize);
        ib_AmonIcon.Width = unit;
        ib_AmonIcon.Height = unit;

        ib_AmonIcon.Enabled = enabled;
        ib_AmonIcon.OnClientClick = "return editIcon();";

        if (enabled)
        {
            ib_AmonIcon.ToolTip = toolTips + "，点击修改";
            ib_AmonIcon.AlternateText = toolTips;
        }
        else
        {
            ib_AmonIcon.ToolTip = toolTips;
            ib_AmonIcon.AlternateText = toolTips;
            ib_AmonIcon.Enabled = false;
        }

        if (hd_UserOpt.Value != "0")
        {
            ib_AmonIcon.ImageUrl = cons.EnvCons.PRE_URL + hd_SrcPath.Value + hd_SrcHash.Value + Convert.ToString(iconSize, 16).PadLeft(4, '0') + ".png";
        }
        else
        {
            ib_AmonIcon.ImageUrl = cons.EnvCons.PRE_URL + "/icon/icon0001.ashx?uri=" + iconSize + "&sid=" + hd_DstHash.Value;
        }
    }

    public String NextIcon()
    {
        String hash = rmp.wrp.exts.Exts.NextIcon(hd_UserOpt.Value, hd_DstPath.Value, hd_DstHash.Value);
        hd_DstHash.Value = hash;
        return hash;
    }

    public void SaveIcon(bool isManage, int operate)
    {
        try
        {
            rmp.wrp.exts.Exts.SaveIcon(hd_UserOpt.Value, hd_SrcPath.Value, hd_SrcHash.Value, hd_DstHash.Value, isManage, operate);
        }
        catch (Exception)
        {
        }
        hd_UserOpt.Value = "0";
    }

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

    public String DstIconPath
    {
        get
        {
            return hd_DstPath.Value;
        }
        set
        {
            hd_DstPath.Value = value;
        }
    }

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

    public String SrcIconPath
    {
        get
        {
            return hd_SrcPath.Value;
        }
    }

    public String SrcIconHash
    {
        get
        {
            return hd_SrcHash.Value;
        }
    }

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

    public bool CreateDiv
    {
        get
        {
            return createDiv;
        }
        set
        {
            createDiv = value;
        }
    }
}

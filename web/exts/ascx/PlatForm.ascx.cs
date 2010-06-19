using System;
using System.Web.UI;

using cons;

public partial class exts_ascx_PlatForm : UserControl
{
    /// <summary>
    /// 读取或设置运行平台信息
    /// </summary>
    public int PlatForm
    {
        get
        {
            if (ck_PfAll.Checked)
            {
                return SysCons.OS_IDX_ALL;
            }

            int platForm = 0;
            if (ck_PfWin.Checked)
            {
                platForm |= SysCons.OS_IDX_WINDOWS;
            }
            if (ck_PfMac.Checked)
            {
                platForm |= SysCons.OS_IDX_MACINTOSH;
            }
            if (ck_PfLnx.Checked)
            {
                platForm |= SysCons.OS_IDX_LINUX;
            }
            if (ck_PfUnx.Checked)
            {
                platForm |= SysCons.OS_IDX_UNIX;
            }
            if (ck_PfMbl.Checked)
            {
                platForm |= SysCons.OS_IDX_MOBILE;
            }
            if (ck_PfSpc.Checked)
            {
                platForm |= SysCons.OS_IDX_UNKNOWN;
            }
            return platForm;
        }
        set
        {
            int platForm = value;

            // 平台通用
            if (SysCons.OS_IDX_ALL == platForm)
            {
                ck_PfAll.Checked = true;
                return;
            }

            ck_PfAll.Checked = false;
            // Windows平台
            ck_PfWin.Checked = (platForm & SysCons.OS_IDX_WINDOWS) != 0;
            // Mac OS平台
            ck_PfMac.Checked = (platForm & SysCons.OS_IDX_MACINTOSH) != 0;
            // Linux平台
            ck_PfLnx.Checked = (platForm & SysCons.OS_IDX_LINUX) != 0;
            // Unix平台
            ck_PfUnx.Checked = (platForm & SysCons.OS_IDX_UNIX) != 0;
            // 移动平台
            ck_PfMbl.Checked = (platForm & SysCons.OS_IDX_MOBILE) != 0;
            // 其它平台
            ck_PfSpc.Checked = (platForm & SysCons.OS_IDX_UNKNOWN) != 0;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }

        ck_PfAll.Attributes.Add("onclick", "chgStat();");
    }
}
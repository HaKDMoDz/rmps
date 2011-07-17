using System;
using System.Web.UI;

using cons;

public partial class exts_ascx_ArchBits : UserControl
{
    public int ArchBits
    {
        get
        {
            int archBits = 0;
            if (ck_Ab64.Checked)
            {
                archBits |= SysCons.BITS_IDX_64;
            }
            if (ck_Ab32.Checked)
            {
                archBits |= SysCons.BITS_IDX_32;
            }
            if (ck_Ab16.Checked)
            {
                archBits |= SysCons.BITS_IDX_16;
            }
            if (ck_Ab00.Checked)
            {
                archBits |= SysCons.BITS_IDX_00;
            }
            return archBits;
        }
        set
        {
            int archBits = value;

            // 64位
            ck_Ab64.Checked = (archBits & SysCons.BITS_IDX_64) != 0;
            // 32位
            ck_Ab32.Checked = (archBits & SysCons.BITS_IDX_32) != 0;
            // 16位
            ck_Ab16.Checked = (archBits & SysCons.BITS_IDX_16) != 0;
            // 其它
            ck_Ab00.Checked = (archBits & SysCons.BITS_IDX_00) != 0;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
}
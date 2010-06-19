using System;
using System.Collections;
using System.Web.UI;

using cons.wrp;

using rmp.prp.aide.P3060000.t;
using rmp.wrp;

public partial class tool_tool1306 : Page
{
    protected ArrayList mathList = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDNAME] = "计算助理";
        Session[cons.wrp.WrpCons.SCRIPTID] = "1306";

        if (IsPostBack)
        {
            return;
        }
    }

    protected void bt_S6_Click(object sender, EventArgs e)
    {
        String decimals = tf_Decimals.Text;
        if (decimals == null || decimals.Trim() == "")
        {
            Wrps.ShowMesg(Master, "请输入一个有效的计算精度！");
            return;
        }

        int size;
        try
        {
            size = Int32.Parse(decimals);
        }
        catch (Exception)
        {
            Wrps.ShowMesg(Master, "请输入一个有效的计算精度！");
            return;
        }

        if (size > 64)
        {
            Wrps.ShowMesg(Master, "计算精度太大，无法正常运算！");
            return;
        }

        try
        {
            mathList.Clear();
            Mc mc = new Mc(hd_MathExps.Value, size, mathList);
            ta_MathExps.Text += "\n=" + mc.calculate();
        }
        catch (Exception exp)
        {
            Wrps.ShowMesg(Master, exp.Message);
            return;
        }

        ta_MathExps.Focus();
    }
}
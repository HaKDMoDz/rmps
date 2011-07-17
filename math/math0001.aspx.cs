using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;

using cons.wrp;

using rmp.bean;
using rmp.prp.aide.P3060000.t;
using rmp.wrp;

public partial class math_math0001 : Page
{
    protected ArrayList mathList = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 1;
        Session[cons.wrp.WrpCons.GUIDNAME] = "高级模式";
        Session[cons.wrp.WrpCons.SCRIPTID] = "math0001";

        List<K1V2> guidList = Wrps.GuidMath(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = guidList.Count;
        K1V2 guidItem = guidList[1];
        guidItem.K = cons.EnvCons.PRE_URL + "/math/math0001.aspx";
        guidItem.V1 = "高级模式";
        guidItem.V2 = "高级模式";

        if (IsPostBack)
        {
            return;
        }

        String uri = Request[WrpCons.URI];
        if (!String.IsNullOrEmpty(uri))
        {
            Mc mc = new Mc(uri, 10, mathList);
            ta_MathExps.Text = uri + "\n=" + mc.calculate();
        }
    }

    /// <summary>
    /// 取运算结果
    /// </summary>
    /// <param name="txt"></param>
    /// <param name="dec"></param>
    /// <returns></returns>
    public String calc(String txt, int dec)
    {
        return new Mc(txt, dec, null).calculate();
    }

    /// <summary>
    /// 取运算过程
    /// </summary>
    /// <param name="txt"></param>
    /// <param name="dec"></param>
    /// <returns></returns>
    public String step(String txt, int dec)
    {
        StringBuilder step = new StringBuilder();
        ArrayList list = new ArrayList();
        new Mc(txt, dec, list).calculate();
        step.Append("<table id=\"tb_MathExps\" width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"1\">");
        foreach (K1V2 item in list)
        {
            step.Append("<tr id=\"tr_MathStep<%= i %>\" style=\"display: none\">");
            step.Append("<th style=\"width: 20px;\">=</th>");
            step.Append("<td align=\"left\">");
            step.Append(item.K.Replace(item.V1, String.Format("<span class=\"TEXT_NOTE1\">{0}</span>", item.V1)));
            step.Append("</td></tr>");
        }
        step.Append("</table>");
        return step.ToString();
    }

    protected void bt_S6_Click(object sender, EventArgs e)
    {
        String decimals = tf_Decimals.Text;
        if (!new Regex("^\\d+$").IsMatch(decimals))
        {
            Wrps.ShowMesg(Master, "请输入一个有效的计算精度！");
            return;
        }

        int size = Int32.Parse(decimals);
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
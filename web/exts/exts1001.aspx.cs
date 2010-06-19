﻿using System;
using System.Collections.Generic;
using System.Web.UI;

using rmp.bean;
using rmp.wrp;

public partial class exts_exts1001 : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Master Page初始化
        Session[cons.wrp.WrpCons.GUIDINDX] = 2;
        Session[cons.wrp.WrpCons.GUIDNAME] = "什么是文件扩展名称？";
        Session[cons.wrp.WrpCons.SCRIPTID] = "exts1001";

        List<K1V2> guidList = Wrps.GuidExts(Session);
        Session[cons.wrp.WrpCons.GUIDSIZE] = 3;

        K1V2 guidItem = guidList[2];
        guidItem.K = cons.EnvCons.PRE_URL + "/exts/exts1001.aspx";
        guidItem.V1 = "什么是文件扩展名称？";
        guidItem.V2 = "什么是文件扩展名称？";

        if (IsPostBack)
        {
            return;
        }
    }
}
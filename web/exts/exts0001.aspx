<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0001.aspx.cs" Inherits="exts_exts0001" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <asp:ScriptManager ID="sm_Script" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Update" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
                <tr>
                    <td align="center">
                        <table id="tb_Exts" width="460" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:RadioButtonList ID="rb_ExtsCase" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        <asp:ListItem Text="大小敏感(H)" Value="0" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="大写(U)" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="小写(L)" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="模糊查询(R)" Value="3"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%;">
                                    <asp:Label ID="lb_ExtsName" runat="server" Text="后缀名称(X)"></asp:Label>
                                </td>
                                <td align="center" style="width: 60%;">
                                    <asp:TextBox ID="tf_ExtsName" runat="server" Width="90%" AccessKey="X">.PDF</asp:TextBox>
                                    <asp:FileUpload ID="tf_ExtsFile" runat="server" Style="display: none; width: 90%;" />
                                </td>
                                <td align="left" style="width: 20%;">
                                    <asp:Button ID="bt_ExtsName" runat="server" Text="查询(Q)" AccessKey="Q" OnClick="bt_ExtsName_Click" OnClientClick="return chkExts();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3" style="height: 20px;">
                                    <asp:CheckBox ID="ck_ExtsFile" runat="server" Text="文件查看(I)" AccessKey="I" ToolTip="查看指定文件的后缀信息" />
                                    <asp:CheckBox ID="ck_ExtsAjax" runat="server" Text="启用Ajax(J)" AccessKey="J" ToolTip="启用Ajax可以获得更好的网络效果" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="TD_LINE_B">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;<asp:HiddenField ID="hd_SoftHash" runat="server" />
                        <asp:HiddenField ID="hd_ErrMsg" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <%
                                if (dv_DataView != null && dv_DataView.Rows.Count > 0)
                                {
                                    String extsName = rmp.wrp.exts.Exts.readQuery(Session).V1;
                                    DataRow row;
                                    DataTable despView;
                                    DataTable mimeView;
                                    DataTable platView;
                                    DataTable docsView;
                                    DataTable corpView;
                                    DataTable softView;
                                    DataTable fileView;
                                    DataTable idioView;
                                    DataTable asocView;
                                    for (int i = 0, j = dv_DataView.Rows.Count; i < j; i += 1)
                                    {
                                        row = dv_DataView.Rows[i];
                                        /*描述信息*/
                                        despView = rmp.wrp.exts.Exts.ReadDesp(dba, row[cons.io.db.prp.PrpCons.P3010009].ToString());
                                        /*MIME信息*/
                                        mimeView = rmp.wrp.exts.Exts.ReadMime(dba, row[cons.io.db.prp.PrpCons.P301000A].ToString());
                                        /*应用平台*/
                                        platView = rmp.wrp.exts.Exts.ReadPlat(dba, row[cons.io.db.prp.PrpCons.P301000E].ToString());
                                        /*格式信息*/
                                        docsView = rmp.wrp.exts.Exts.ReadDocs(dba, row[cons.io.db.prp.PrpCons.P3010008].ToString());
                                        /*公司索引*/
                                        corpView = rmp.wrp.exts.Exts.ReadCorp(dba, row[cons.io.db.prp.PrpCons.P3010005].ToString());
                                        /*软件信息*/
                                        softView = rmp.wrp.exts.Exts.ReadSoft(dba, row[cons.io.db.prp.PrpCons.P3010006].ToString());
                                        /*文件信息*/
                                        fileView = rmp.wrp.exts.Exts.ReadFile(dba, row[cons.io.db.prp.PrpCons.P3010007].ToString());
                                        /*人员信息*/
                                        idioView = rmp.wrp.exts.Exts.ReadIdio(dba, row[cons.io.db.prp.PrpCons.P301000F].ToString());
                                        /*备选软件*/
                                        asocView = rmp.wrp.exts.Exts.ReadAsoc(dba, row[cons.io.db.prp.PrpCons.P301000B].ToString());
                            %>
                            <tr>
                                <td style="height: 20px;" align="right">
                                    <a href="#" title="显示所有信息" onclick="return wEnableAll(<%=i%>)">显示所有</a>&nbsp;<a href="#" title="返回到页面起始">返回顶部</a>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <table width="460" border="0" cellpadding="2" cellspacing="0" class="TB_EXTSINFO" id="TB_EXTSINFO<%=i%>">
                                        <tr>
                                            <td align="center" style="width: 10%;" class="TD_TAB_S" id="TAB<%=i%>0" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                                                <a href="#" class="A_TAB_O" onclick="return wEnable('DV_BASE<%=i%>','TAB<%=i%>0',<%=i%>)">&nbsp;摘要&nbsp;</a>
                                            </td>
                                            <td align="center" style="width: 10%;" class="TD_TAB_D" id="TAB<%=i%>1" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                                                <a href="#" class="A_TAB_O" onclick="return wEnable('DV_DESP<%=i%>','TAB<%=i%>1',<%=i%>)">&nbsp;描述&nbsp;</a>
                                            </td>
                                            <td align="center" style="width: 10%;" class="TD_TAB_D" id="TAB<%=i%>2" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                                                <a href="#" class="A_TAB_O" onclick="return wEnable('DV_MIME<%=i%>','TAB<%=i%>2',<%=i%>)">&nbsp;MIME&nbsp;</a>
                                            </td>
                                            <td align="center" style="width: 10%;" class="TD_TAB_D" id="TAB<%=i%>3" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                                                <a href="#" class="A_TAB_O" onclick="return wEnable('DV_PLAT<%=i%>','TAB<%=i%>3',<%=i%>)">&nbsp;平台&nbsp;</a>
                                            </td>
                                            <td align="center" style="width: 10%;" class="TD_TAB_D" id="TAB<%=i%>4" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                                                <a href="#" class="A_TAB_O" onclick="return wEnable('DV_DOCS<%=i%>','TAB<%=i%>4',<%=i%>)">&nbsp;格式&nbsp;</a>
                                            </td>
                                            <td align="center" style="width: 10%;" class="TD_TAB_D" id="TAB<%=i%>5" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                                                <a href="#" class="A_TAB_O" onclick="return wEnable('DV_CORP<%=i%>','TAB<%=i%>5',<%=i%>)">&nbsp;公司&nbsp;</a>
                                            </td>
                                            <td align="center" style="width: 10%;" class="TD_TAB_D" id="TAB<%=i%>6" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                                                <a href="#" class="A_TAB_O" onclick="return wEnable('DV_SOFT<%=i%>','TAB<%=i%>6',<%=i%>)">&nbsp;软件&nbsp;</a>
                                            </td>
                                            <td align="center" style="width: 10%;" class="TD_TAB_D" id="TAB<%=i%>7" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                                                <a href="#" class="A_TAB_O" onclick="return wEnable('DV_FILE<%=i%>','TAB<%=i%>7',<%=i%>)">&nbsp;文件&nbsp;</a>
                                            </td>
                                            <td align="center" style="width: 10%;" class="TD_TAB_D" id="TAB<%=i%>8" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                                                <a href="#" class="A_TAB_O" onclick="return wEnable('DV_IDIO<%=i%>','TAB<%=i%>8',<%=i%>)">&nbsp;致谢&nbsp;</a>
                                            </td>
                                            <td align="center" style="width: 10%;" class="TD_TAB_D" id="TAB<%=i%>9" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                                                <a href="#" class="A_TAB_O" onclick="return wEnable('DV_ASOC<%=i%>','TAB<%=i%>9',<%=i%>)">&nbsp;备选&nbsp;</a>
                                            </td>
                                        </tr>
                                        <tr id="DV_BASE<%=i%>">
                                            <td colspan="10">
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL">
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            软件名称
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <%=row[cons.io.db.prp.PrpCons.P3010205]%>
                                                        </td>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            所属类别
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <%=rmp.comn.Comn.ReadCat1Item(row[cons.io.db.prp.PrpCons.P301000C].ToString(), "13010000").K%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            应用平台
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <%=rmp.wrp.exts.Exts.decodePlatForm(int.Parse(row[cons.io.db.prp.PrpCons.P301000D].ToString()))%>
                                                        </td>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            CPU 架构
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <%=rmp.wrp.exts.Exts.decodeArchBits(int.Parse(row[cons.io.db.prp.PrpCons.P3010002].ToString()))%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            查询统计
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <%=row[cons.io.db.prp.PrpCons.P3010001]%>
                                                        </td>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            数据状态
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <%if(cons.wrp.WrpCons.OPT_INSERT==row[cons.io.db.prp.PrpCons.P3010015].ToString()){%>
                                                                用户新增，待审核！
                                                            <%}else if (cons.wrp.WrpCons.OPT_UPDATE == row[cons.io.db.prp.PrpCons.P3010015].ToString()){%>
                                                                用户更新，待审核！
                                                            <%}else{%>
                                                                -
                                                            <%}%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            最后更新
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <%=row[cons.io.db.prp.PrpCons.P3010011]%>
                                                        </td>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            创建日期
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <%=rmp.util.WrpUtil.db2Html(row[cons.io.db.prp.PrpCons.P3010012])%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            快捷地址
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L" colspan="3">
                                                            <a href="http://amonsoft.cn/?.<%=extsName%>" title="后缀 .<%=extsName%> 的快捷访问地址！">http://amonsoft.cn/?.<%=extsName%></a><br />
                                                            <a href="http://amonsoft.cn/exts/exts0001.aspx?exts=.<%=extsName%>" title="后缀 .<%=extsName%> 的常规访问地址！">http://amonsoft.cn/exts/exts0001.aspx?exts=.<%=extsName%></a><br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            网络搜索
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L" colspan="3">
                                                            <a href="http://www.google.cn/search?q=打开<%=extsName%>" title="在Google搜索 打开<%=extsName%>" target="_blank">打开<%=extsName%></a>&nbsp;<a href="http://www.google.cn/search?q=<%=extsName%>介绍" title="在Google搜索 <%=extsName%>介绍" target="_blank"><%=extsName%>介绍</a>&nbsp;<a href="http://www.google.cn/search?q=<%=extsName%>文件"
                                                                title="在Google搜索 <%=extsName%>文件" target="_blank"><%=extsName%>文件</a>&nbsp;<a href="http://www.google.cn/search?q=<%=extsName%>格式" title="在Google搜索 <%=extsName%>格式" target="_blank"><%=extsName%>格式</a>&nbsp;<a href="http://www.google.cn/search?q=<%=extsName%>下载" title="在Google搜索 <%=extsName%>下载" target="_blank"><%=extsName%>下载</a>&nbsp;<a
                                                                    href="http://www.google.cn/search?q=<%=extsName%>相关软件" title="在Google搜索 <%=extsName%>相关软件" target="_blank"><%=extsName%>相关软件</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            附注信息
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L" colspan="3">
                                                            <%=rmp.util.WrpUtil.db2Html(row[cons.io.db.prp.PrpCons.P3010010])%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            用户留言
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L" colspan="3">
                                                            <a href="<%=cons.EnvCons.PRE_URL%>/idea/idea0002.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010003,"")%>">查看留言</a>&nbsp;<a href="/idea/idea0001.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010003,"")%>">发表意见</a>
                                                            <%if(bl_User){%>
                                                            &nbsp;<a href="<%=cons.EnvCons.PRE_URL%>/exts/exts0021.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010003,"")%>&uri=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010006,"")%>&opt=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010014,"")%>" title="">更新</a>
                                                            <%if (bl_Root){lb_UpdtStep.OnClientClick = "return doUpdate('" + dv_DataView.Rows[i][cons.io.db.prp.PrpCons.P3010006] + "');"; lb_DeltExts.OnClientClick = "return doDelete('" + dv_DataView.Rows[i][cons.io.db.prp.PrpCons.P3010006] + "');";%>
                                                            &nbsp;<asp:LinkButton ID="lb_UpdtStep" runat="server" OnClick="lb_UpdtStep_Click">上移</asp:LinkButton>&nbsp;<asp:LinkButton ID="lb_DeltExts" runat="server" OnClick="lb_DeltExts_Click">删除</asp:LinkButton>
                                                            <%}}%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="DV_DESP<%=i%>" style="display: none">
                                            <td colspan="10">
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL">
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            后缀描述
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <%row = despView.Rows.Count < 1 ? null : despView.Rows[0]; String d = Text(row, cons.io.db.prp.PrpCons.P3010503); if (d.StartsWith("参见："))
                                                              {
                                                                  d = d.Substring(3);%>
                                                            参见：<a href="<%=cons.EnvCons.PRE_URL%>/exts/exts0001.aspx?exts=<%=d%>" title="点击查看 <%=d%> 的详细信息"><%=d%></a>
                                                            <%}
                                                              else if (d.ToLower().StartsWith("see:"))
                                                              {
                                                                  d = d.Substring(4);%>
                                                            See:<a href="<%=cons.EnvCons.PRE_URL%>/exts/exts0001.aspx?exts=<%=d%>" title="点击查看 <%=d%> 的详细信息"><%=d%></a>
                                                            <%}
                                                              else
                                                              {%><%=d%><%}%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            附注信息
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P3010504)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            最后更新
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P3010505)%>
                                                            <div style="text-align:right">
                                                                <%=Info(row, cons.io.db.prp.PrpCons.P3010508, cons.io.db.prp.PrpCons.P3010507)%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            创建日期
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P3010506)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            用户留言
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <a href="<%=cons.EnvCons.PRE_URL%>/idea/idea0002.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010009,"")%>">查看留言</a>&nbsp;<a href="/idea/idea0001.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010009,"")%>">发表意见</a>
                                                            <%if (bl_User)
                                                              {%>&nbsp;<a href="<%=cons.EnvCons.PRE_URL%>/exts/exts0091.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010009,"")%>&opt=<%=Text(row,cons.io.db.prp.PrpCons.P3010507)%>" title="">更新</a><%}%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="DV_MIME<%=i%>" style="display: none">
                                            <td colspan="10">
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL">
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" rowspan="<%=mimeView.Rows.Count+1%>" align="center" class="TD_DataHead_TL_L">
                                                            MIME类型
                                                        </th>
                                                        <td style="height: 0px;">
                                                        </td>
                                                    </tr>
                                                    <%foreach (DataRow m in mimeView.Rows)
                                                      {%>
                                                    <tr>
                                                        <td style="height: 30px;" align="left" class="TD_DataItem_TL_L">
                                                            <a href="<%=cons.EnvCons.PRE_URL%>/exts/exts0502.aspx?sid=<%=Text(m,cons.io.db.prp.PrpCons.P3010603,"")%>" title="点击查看有关此MIME的详细信息！">
                                                                <%=Text(m,cons.io.db.prp.PrpCons.P301F104)%>
                                                            </a>
                                                            <div style="text-align:right">
                                                                <%=Info(m, cons.io.db.prp.PrpCons.P3010608, cons.io.db.prp.PrpCons.P3010607)%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <%}%>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            用户留言
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <a href="<%=cons.EnvCons.PRE_URL%>/idea/idea0002.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P301000A,"")%>">查看留言</a>&nbsp;<a href="/idea/idea0001.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P301000A,"")%>">发表意见</a>
                                                            <%if (bl_User)
                                                              {%>&nbsp;<a href="<%=cons.EnvCons.PRE_URL%>/exts/exts0092.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P301000A,"")%>" title="">更新</a><%}%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="DV_PLAT<%=i%>" style="display: none">
                                            <td colspan="10">
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL">
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" rowspan="<%=platView.Rows.Count+1%>" align="center" class="TD_DataHead_TL_L">
                                                            平台名称
                                                        </th>
                                                        <td style="height: 0px;">
                                                        </td>
                                                    </tr>
                                                    <%foreach (DataRow m in platView.Rows)
                                                      {%>
                                                    <tr>
                                                        <td style="height: 30px;" align="left" class="TD_DataItem_TL_L">
                                                            <a href="<%=cons.EnvCons.PRE_URL%>/exts/exts0602.aspx?sid=<%=Text(m,cons.io.db.prp.PrpCons.P3010803)%>" title="点击查看有关此平台的详细信息！">
                                                                <%=Text(m, cons.io.db.prp.PrpCons.P301F206)%>
                                                            </a>
                                                            <div style="text-align:right">
                                                                <%=Info(m, cons.io.db.prp.PrpCons.P3010808, cons.io.db.prp.PrpCons.P3010807)%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <%}%>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            用户留言
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <a href="<%=cons.EnvCons.PRE_URL%>/idea/idea0002.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P301000E,"")%>">查看留言</a>&nbsp;<a href="/idea/idea0001.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P301000E,"")%>">发表意见</a>
                                                            <%if (bl_User)
                                                              {%>&nbsp;<a href="<%=cons.EnvCons.PRE_URL%>/exts/exts0094.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P301000E,"")%>" title="">更新</a><%}%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="DV_DOCS<%=i%>" style="display: none">
                                            <td colspan="10">
                                                <%row = docsView.Rows.Count < 1 ? null : docsView.Rows[0];%>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL">
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            文档名称
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <a href="<%=cons.EnvCons.PRE_URL%>/file/file0001.ashx?sid=<%=Text(row,cons.io.db.prp.PrpCons.P3010404,"0")%>" target="_blank" title="点击查看文档">
                                                                <%=Text(row,cons.io.db.prp.PrpCons.P3010405)%></a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            发行版本
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P3010406)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            发行日期
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P3010407)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            文档摘要
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P3010408)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            附注信息
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P3010409)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            最后更新
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row, cons.io.db.prp.PrpCons.P301040A)%>
                                                            <div style="text-align:right">
                                                                <%=Info(row, cons.io.db.prp.PrpCons.P301040D, cons.io.db.prp.PrpCons.P301040C)%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            创建日期
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row, cons.io.db.prp.PrpCons.P301040B)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            用户留言
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <a href="<%=cons.EnvCons.PRE_URL%>/idea/idea0002.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010008,"")%>">查看留言</a>&nbsp;<a href="/idea/idea0001.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010008,"")%>">发表意见</a>
                                                            <%if (bl_User)
                                                              {%>&nbsp;<a href="<%=cons.EnvCons.PRE_URL%>/exts/exts0403.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010008,"")%>&opt=<%=Text(row, cons.io.db.prp.PrpCons.P301040C)%>" title="">更新</a><%}%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="DV_CORP<%=i%>" style="display: none">
                                            <td colspan="10">
                                                <%row = corpView.Rows.Count < 1 ? null : corpView.Rows[0];%>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL">
                                                    <tr>
                                                        <td style="width: 80px;" rowspan="2" align="center" class="TD_DataHead_TL_L">
                                                            <img id="ICON_CORP" src="<%=cons.EnvCons.PRE_URL%>/icon/icon0001.ashx?uri=corp&sid=<%=row!=null?row[cons.io.db.prp.PrpCons.P3010104]:"0"%>" alt="公司徽标" width="48" height="48" class="IMG_EXTSICON" onclick="viewIcon(event,'<%=Text(row,cons.io.db.prp.PrpCons.P3010104,"0")%>');" />
                                                        </td>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            中文名称
                                                        </th>
                                                        <td style="width: 300px;" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P3010105)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            英文名称
                                                        </th>
                                                        <td style="width: 300px;" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P3010106)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            公司网址
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <a href="<%=Text(row,cons.io.db.prp.PrpCons.P3010107,"#")%>" title="<%=Text(row,cons.io.db.prp.PrpCons.P3010107,"")%>" target="_blank">
                                                                <%=Text(row,cons.io.db.prp.PrpCons.P3010107)%>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            公司简介
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P3010108)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            附注信息
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P3010109)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            最后更新
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row, cons.io.db.prp.PrpCons.P301010A)%>
                                                            <div style="text-align:right">
                                                                <%=Info(row, cons.io.db.prp.PrpCons.P301010D, cons.io.db.prp.PrpCons.P301010C)%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            创建日期
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row, cons.io.db.prp.PrpCons.P301010B)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            用户留言
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <a href="<%=cons.EnvCons.PRE_URL%>/idea/idea0002.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010005,"")%>">查看留言</a>&nbsp;<a href="/idea/idea0001.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010005,"")%>">发表意见</a>
                                                            <%if (bl_User)
                                                              {%>&nbsp;<a href="<%=cons.EnvCons.PRE_URL%>/exts/exts0103.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010005,"")%>&opt=<%=Text(row,cons.io.db.prp.PrpCons.P301010C,"0")%>" title="">更新</a><%}%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="DV_SOFT<%=i%>" style="display: none">
                                            <td colspan="10">
                                                <%row = softView.Rows.Count < 1 ? null : softView.Rows[0];%>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL">
                                                    <tr>
                                                        <td style="width: 80px;" rowspan="2" align="center" class="TD_DataHead_TL_L">
                                                            <img id="ICON_SOFT" src="<%=cons.EnvCons.PRE_URL%>/icon/icon0001.ashx?uri=soft&sid=<%=row!=null?row[cons.io.db.prp.PrpCons.P3010204]:"0"%>" alt="软件图标" width="48" height="48" class="IMG_EXTSICON" onclick="viewIcon(event,'<%=Text(row,cons.io.db.prp.PrpCons.P3010204,"0")%>');" />
                                                        </td>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            中文名称
                                                        </th>
                                                        <td style="width: 300px;" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P3010205)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            英文名称
                                                        </th>
                                                        <td style="width: 300px;" align="left" align="center" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P3010206)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            电子邮件
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <a href="mailto:<%=Text(row,cons.io.db.prp.PrpCons.P3010207,"#")%>" title="<%=Text(row,cons.io.db.prp.PrpCons.P3010207,"")%>" target="_blank">
                                                                <%=Text(row,cons.io.db.prp.PrpCons.P3010207)%>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            链接地址
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <a href="<%=Text(row,cons.io.db.prp.PrpCons.P3010208,"#")%>" title="<%=Text(row,cons.io.db.prp.PrpCons.P3010208,"")%>" target="_blank">
                                                                <%=Text(row,cons.io.db.prp.PrpCons.P3010208)%>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            兼容后缀
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <%String[] extsList = Text(row, cons.io.db.prp.PrpCons.P3010209, "").Trim().Split(',', ';'); String x; for (int a = 0, b = extsList.Length - 1; a < b; a += 1)
                                                              {
                                                                  x = extsList[a];%>
                                                            <a href="<%=cons.EnvCons.PRE_URL%>/exts/exts0001.aspx?exts=<%=extsList%>" title="点击查看 <%=x%> 的详细信息">
                                                                <%=x%></a><br />
                                                            <%} x = extsList[extsList.Length - 1];%>
                                                            <a href="<%=cons.EnvCons.PRE_URL%>/exts/exts0001.aspx?exts=<%=extsList%>" title="点击查看 <%=x%> 的详细信息">
                                                                <%=x%></a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            运行截图
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <a href="<%=cons.EnvCons.PRE_URL%>/icon/icon0002.ashx?sid=<%=Text(row,cons.io.db.prp.PrpCons.P301020A,"0")%>" title="点击查看大图" target="_blank">点击查看</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            软件简介
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P301020B)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            附注信息
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P301020C)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            最后更新
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row, cons.io.db.prp.PrpCons.P301020D)%>
                                                            <div style="text-align:right">
                                                                <%=Info(row, cons.io.db.prp.PrpCons.P3010210, cons.io.db.prp.PrpCons.P301020F)%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            创建日期
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row, cons.io.db.prp.PrpCons.P301020E)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            用户留言
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <a href="<%=cons.EnvCons.PRE_URL%>/idea/idea0002.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010006,"")%>">查看留言</a>&nbsp;<a href="/idea/idea0001.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010006,"")%>">发表意见</a>
                                                            <%if (bl_User)
                                                              {%>&nbsp;<a href="<%=cons.EnvCons.PRE_URL%>/exts/exts0203.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010006,"")%>&opt=<%=Text(row,cons.io.db.prp.PrpCons.P301020F,"0")%>" title="">更新</a><%}%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="DV_FILE<%=i%>" style="display: none">
                                            <td colspan="10">
                                                <%row = fileView.Rows.Count > 0 ? fileView.Rows[0] : null;%>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL">
                                                    <tr>
                                                        <td style="width: 80px;" rowspan="2" align="center" class="TD_DataHead_TL_L">
                                                            <img id="ICON_FILE" src="<%=cons.EnvCons.PRE_URL%>/icon/icon0001.ashx?uri=file&sid=<%=row!=null?row[cons.io.db.prp.PrpCons.P3010304]:"0"%>" alt="文件图标" width="48" height="48" class="IMG_EXTSICON" onclick="viewIcon(event,'<%=Text(row,cons.io.db.prp.PrpCons.P3010304,"0")%>');" />
                                                        </td>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            数值签名
                                                        </th>
                                                        <td style="width: 300px;" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P3010306)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            字符签名
                                                        </th>
                                                        <td style="width: 300px;" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P3010305)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            偏移位置
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P3010307)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            加密算法
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P3010308)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            起始数据
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P3010309)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            结束数据
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P301030A)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            附注信息
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.prp.PrpCons.P301030C)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            最后更新
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row, cons.io.db.prp.PrpCons.P301030D)%>
                                                            <div style="text-align:right">
                                                                <%=Info(row, cons.io.db.prp.PrpCons.P3010310, cons.io.db.prp.PrpCons.P301030F)%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            创建日期
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row, cons.io.db.prp.PrpCons.P301030E)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            用户留言
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <a href="<%=cons.EnvCons.PRE_URL%>/idea/idea0002.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010007,"")%>">查看留言</a>&nbsp;<a href="/idea/idea0001.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010007,"")%>">发表意见</a>
                                                            <%if (bl_User)
                                                              {%>&nbsp;<a href="<%=cons.EnvCons.PRE_URL%>/exts/exts0303.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P3010007,"")%>&opt=<%=Text(row,cons.io.db.prp.PrpCons.P301030F,"0")%>" title="">更新</a><%}%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="DV_IDIO<%=i%>" style="display: none">
                                            <td colspan="10">
                                                <%row = idioView.Rows.Count < 1 ? null : idioView.Rows[0];%>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL">
                                                    <tr>
                                                        <td style="width: 80px;" rowspan="2" align="center" class="TD_DataHead_TL_L">
                                                            <img id="ICON_IDIO" src="<%=cons.EnvCons.PRE_URL%>/icon/icon0001.ashx?uri=idio&sid=<%=row!=null?row[cons.io.db.comn.user.UserCons.C3010408]:"0"%>" alt="个性图标" width="48" height="48" class="IMG_EXTSICON" onclick="viewIcon(event,'<%=Text(row,cons.io.db.comn.user.UserCons.C3010408,"0")%>');" />
                                                        </td>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            邮&nbsp;&nbsp;&nbsp;&nbsp;件
                                                        </th>
                                                        <td style="width: 300px;" align="left" class="TD_DataItem_TL_L">
                                                            <a href="mailto:<%=Text(row,cons.io.db.comn.user.UserCons.C3010406,"#")%>" title="<%=Text(row,cons.io.db.comn.user.UserCons.C3010406,"")%>" target="_blank">
                                                                <%=Text(row,cons.io.db.comn.user.UserCons.C3010406)%>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            昵&nbsp;&nbsp;&nbsp;&nbsp;称
                                                        </th>
                                                        <td style="width: 300px;" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.comn.user.UserCons.C3010407)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            签&nbsp;&nbsp;&nbsp;&nbsp;名
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.comn.user.UserCons.C3010409)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            个人主页
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <a href="<%=Text(row,cons.io.db.comn.user.UserCons.C301040A,"#")%>" title="<%=Text(row,cons.io.db.comn.user.UserCons.C301040A,"")%>" target="_blank">
                                                                <%=Text(row,cons.io.db.comn.user.UserCons.C301040A)%>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            个人简介
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <%=Text(row,cons.io.db.comn.user.UserCons.C301040B)%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            用户留言
                                                        </th>
                                                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                            <a href="<%=cons.EnvCons.PRE_URL%>/idea/idea0002.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P301000F,"")%>">查看留言</a>&nbsp;<a href="/idea/idea0001.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P301000F,"")%>">发表意见</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="DV_ASOC<%=i%>" style="display: none">
                                            <td colspan="10">
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL">
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" rowspan="<%=asocView.Rows.Count+1%>" align="center" class="TD_DataHead_TL_L">
                                                            备选软件
                                                        </th>
                                                        <td style="height: 0px;">
                                                        </td>
                                                    </tr>
                                                    <%foreach (DataRow m in asocView.Rows)
                                                      {
                                                          int ay = Int32.Parse(m[cons.io.db.prp.PrpCons.P3010702].ToString());%>
                                                    <tr>
                                                        <td class="TD_DataItem_TL_L">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td style="height: 30px; width:24px;" align="center">
                                                                        <img src="<%=cons.EnvCons.PRE_URL%>/icon/icon0001.ashx?uri=soft&sid=<%=m[cons.io.db.prp.PrpCons.P3010204]%>&opt=16" alt="软件图标" width="16" height="16" />
                                                                    </td>
                                                                    <td style="height: 30px;" align="left">
                                                                        <div style="overflow: hidden">
                                                                            <a href="<%=cons.EnvCons.PRE_URL%>/exts/exts0202.aspx?sid=<%=m[cons.io.db.prp.PrpCons.P3010704]%>" title="点击查看软件详细信息">
                                                                                <%=m[cons.io.db.prp.PrpCons.P3010205]%>
                                                                            </a></div>
                                                                    </td>
                                                                    <td style="height: 30px; width:36px;" align="center">
                                                                        <%=m[cons.io.db.prp.PrpCons.P3010705]%>
                                                                    </td>
                                                                    <td style="height: 30px; width:160px;" align="center">
                                                                        <img src="<%=cons.EnvCons.PRE_URL%>/icon/icon0001.ashx?sid=comn,_<%=(ay == cons.SysCons.OS_IDX_ALL) ? "ALL" : "DEF"%>&opt=16" title="平台通用" alt="平台通用" width="16" height="16" />
                                                                        <img src="<%=cons.EnvCons.PRE_URL%>/icon/icon0001.ashx?sid=comn,_<%=((ay & cons.SysCons.OS_IDX_WINDOWS) != 0) ? "WIN" : "DEF"%>&opt=16" title="Windows平台" alt="Windows平台" width="16" height="16" />
                                                                        <img src="<%=cons.EnvCons.PRE_URL%>/icon/icon0001.ashx?sid=comn,_<%=((ay & cons.SysCons.OS_IDX_MACINTOSH) != 0) ? "MAC" : "DEF"%>&opt=16" title="Macintosh平台" alt="Macintosh平台" width="16" height="16" />
                                                                        <img src="<%=cons.EnvCons.PRE_URL%>/icon/icon0001.ashx?sid=comn,_<%=((ay & cons.SysCons.OS_IDX_LINUX) != 0) ? "LNX" : "DEF"%>&opt=16" title="Linux平台" alt="Linux平台" width="16" height="16" />
                                                                        <img src="<%=cons.EnvCons.PRE_URL%>/icon/icon0001.ashx?sid=comn,_<%=((ay & cons.SysCons.OS_IDX_UNIX) != 0) ? "UNX" : "DEF"%>&opt=16" title="Unix平台" alt="Unix平台" width="16" height="16" />
                                                                        <img src="<%=cons.EnvCons.PRE_URL%>/icon/icon0001.ashx?sid=comn,_<%=((ay & cons.SysCons.OS_IDX_MOBILE) != 0) ? "MBL" : "DEF"%>&opt=16" title="移动平台" alt="移动平台" width="16" height="16" />
                                                                        <img src="<%=cons.EnvCons.PRE_URL%>/icon/icon0001.ashx?sid=comn,_<%=((ay & cons.SysCons.OS_IDX_UNKNOWN) != 0) ? "SPC" : "DEF"%>&opt=16" title="其它平台" alt="其它平台" width="16" height="16" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <div style="text-align:right">
                                                                <%=Info(m, cons.io.db.prp.PrpCons.P301070A, cons.io.db.prp.PrpCons.P3010709)%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <%}%>
                                                    <tr>
                                                        <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                                            用户留言
                                                        </th>
                                                        <td align="left" class="TD_DataItem_TL_L">
                                                            <a href="<%=cons.EnvCons.PRE_URL%>/idea/idea0002.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P301000B,"")%>">查看留言</a>&nbsp;<a href="/idea/idea0001.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P301000B,"")%>">发表意见</a>
                                                            <%if (bl_User)
                                                              {%>&nbsp;<a href="<%=cons.EnvCons.PRE_URL%>/exts/exts0093.aspx?sid=<%=Text(dv_DataView.Rows[i],cons.io.db.prp.PrpCons.P301000B,"")%>" title="">更新</a><%}%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <%
                                }
                                }
                            %>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <a href="#" onclick="return addFav()" id="hl_Favorite" runat="server" visible="false">收藏本页</a>&nbsp;<a href="/idea/idea0001.aspx?sid=0">发表意见</a><asp:HiddenField ID="hd_DataSize" runat="server" Value="0" />
                        <asp:HiddenField ID="hd_StepSize" runat="server" Value="10" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/tool/tool.master" AutoEventWireup="true" CodeFile="tool1301.aspx.cs" Inherits="tool_tool1301" %>
<%@ Import Namespace="cons.io.db.comn" %>
<%@ Import Namespace="cons.io.db.prp" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <script language="javascript" type="text/javascript">var errMsg;</script>
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr id="tr_ExtsSrch" runat="server">
            <td align="center">
                <table border="0" cellspacing="0" cellpadding="0" width="460">
                    <tr>
                        <td align="right" style="width: 20%;">
                            <asp:Label ID="lb_ExtsName" runat="server" Text="后缀名称(X)"></asp:Label>
                        </td>
                        <td align="center" style="width: 60%;">
                            <asp:TextBox ID="tf_ExtsName" runat="server" Width="90%" AccessKey="X">.PDF</asp:TextBox>
                        </td>
                        <td align="left" style="width: 20%;">
                            <asp:Button ID="bt_ExtsName" runat="server" Text="查询(Q)" AccessKey="Q" OnClick="bt_ExtsName_Click" OnClientClick="return checkNull();" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="TD_LINE" style="height: 1px;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%
            String extsName = rmp.wrp.exts.Exts.readQuery(Session).V1;
            if (dv_DataView == null)
            {
                /*用户首次打开此页面*/
            }
            else if (dv_DataView.Rows.Count == 0)
            {
        %>

        <script language="javascript" type="text/javascript">
            errMsg = '您要查询的后缀数据 “<%= extsName %>” 不存在！';
        </script>

        <%
            }
            else
            {
                System.Data.DataRow row;
                System.Data.DataTable despView;
                System.Data.DataTable mimeView;
                System.Data.DataTable platView;
                System.Data.DataTable docsView;
                System.Data.DataTable corpView;
                System.Data.DataTable softView;
                System.Data.DataTable fileView;
                System.Data.DataTable idioView;
                System.Data.DataTable asocView;

                int dataSize = dv_DataView.Rows.Count;
        %>
        <tr>
            <td align="right">
                <table border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <% for (int i = 0; i < dataSize; i += 1) { %>
                        <td id="TD_PAGE<%= i %>" align="center">
                            <a id="hl_Exts<%= i %>" href="#" onclick="return showTabs(<%= i %>);" title="显示第 <%= i+1 %> 页"><strong><%= i+1 %></strong></a>
                        </td>
                        <% } %>
                        <td align="center">
                            /
                        </td>
                        <td>
                            共&nbsp;<span class="TEXT_NOTE1"><%= dataSize %></span>&nbsp;页
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%
            for (int i = 0; i < dataSize; i += 1)
            {
                row = dv_DataView.Rows[i];
                /*描述信息*/
                despView = rmp.wrp.exts.Exts.ReadDesp(dba, row[PrpCons.P3010009].ToString());
                /*MIME信息*/
                mimeView = rmp.wrp.exts.Exts.ReadMime(dba, row[PrpCons.P301000A].ToString());
                /*应用平台*/
                platView = rmp.wrp.exts.Exts.ReadPlat(dba, row[PrpCons.P301000E].ToString());
                /*格式信息*/
                docsView = rmp.wrp.exts.Exts.ReadDocs(dba, row[PrpCons.P3010008].ToString());
                /*公司索引*/
                corpView = rmp.wrp.exts.Exts.ReadCorp(dba, row[PrpCons.P3010005].ToString());
                /*软件信息*/
                softView = rmp.wrp.exts.Exts.ReadSoft(dba, row[PrpCons.P3010006].ToString());
                /*文件信息*/
                fileView = rmp.wrp.exts.Exts.ReadFile(dba, row[PrpCons.P3010007].ToString());
                /*人员信息*/
                idioView = rmp.wrp.exts.Exts.ReadIdio(dba, row[PrpCons.P301000F].ToString());
                /*备选软件*/
                asocView = rmp.wrp.exts.Exts.ReadAsoc(dba, row[PrpCons.P301000B].ToString());
        %>
        <tr id="tr_Exts<%= i %>" style="<%= i != 0 ? "display:none" : "" %>">
            <td align="center">
                <table width="460" border="0" cellpadding="2" cellspacing="0" class="TB_EXTSINFO" id="TB_EXTSINFO<%= i %>">
                    <tr>
                        <td align="center" style="width: 10%;" class="TD_TAB_S" id="TAB<%= i %>0" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                            <a href="#" class="A_TAB_O" onclick="return wEnable('DV_EXTS<%= i %>', 'TAB<%= i %>0', <%= i %>)">&nbsp;摘要&nbsp;</a>
                        </td>
                        <td align="center" style="width: 10%;" class="TD_TAB_D" id="TAB<%= i %>1" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                            <a href="#" class="A_TAB_O" onclick="return wEnable('DV_DESP<%= i %>', 'TAB<%= i %>1', <%= i %>)">&nbsp;描述&nbsp;</a>
                        </td>
                        <td align="center" style="width: 10%;" class="TD_TAB_D" id="TAB<%= i %>2" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                            <a href="#" class="A_TAB_O" onclick="return wEnable('DV_MIME<%= i %>', 'TAB<%= i %>2', <%= i %>)">&nbsp;MIME&nbsp;</a>
                        </td>
                        <td align="center" style="width: 10%;" class="TD_TAB_D" id="TAB<%= i %>3" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                            <a href="#" class="A_TAB_O" onclick="return wEnable('DV_PLAT<%= i %>', 'TAB<%= i %>3', <%= i %>)">&nbsp;平台&nbsp;</a>
                        </td>
                        <td align="center" style="width: 10%;" class="TD_TAB_D" id="TAB<%= i %>4" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                            <a href="#" class="A_TAB_O" onclick="return wEnable('DV_DOCS<%= i %>', 'TAB<%= i %>4', <%= i %>)">&nbsp;格式&nbsp;</a>
                        </td>
                        <td align="center" style="width: 10%;" class="TD_TAB_D" id="TAB<%= i %>5" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                            <a href="#" class="A_TAB_O" onclick="return wEnable('DV_CORP<%= i %>', 'TAB<%= i %>5', <%= i %>)">&nbsp;公司&nbsp;</a>
                        </td>
                        <td align="center" style="width: 10%;" class="TD_TAB_D" id="TAB<%= i %>6" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                            <a href="#" class="A_TAB_O" onclick="return wEnable('DV_SOFT<%= i %>', 'TAB<%= i %>6', <%= i %>)">&nbsp;软件&nbsp;</a>
                        </td>
                        <td align="center" style="width: 10%;" class="TD_TAB_D" id="TAB<%= i %>7" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                            <a href="#" class="A_TAB_O" onclick="return wEnable('DV_FILE<%= i %>', 'TAB<%= i %>7', <%= i %>)">&nbsp;文件&nbsp;</a>
                        </td>
                        <td align="center" style="width: 10%;" class="TD_TAB_D" id="TAB<%= i %>8" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                            <a href="#" class="A_TAB_O" onclick="return wEnable('DV_IDIO<%= i %>', 'TAB<%= i %>8', <%= i %>)">&nbsp;致谢&nbsp;</a>
                        </td>
                        <td align="center" style="width: 10%;" class="TD_TAB_D" id="TAB<%= i %>9" onmouseover="wActive(this)" onmouseout="wRemove(this)">
                            <a href="#" class="A_TAB_O" onclick="return wEnable('DV_ASOC<%= i %>', 'TAB<%= i %>9', <%= i %>)">&nbsp;备选&nbsp;</a>
                        </td>
                    </tr>
                    <tr id="DV_EXTS<%= i %>">
                        <td colspan="10">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL" id="EXTSPROP<%= i %>">
                                <tr>
                                    <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                        软件名称
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <%= row[PrpCons.P3010205] %>
                                    </td>
                                    <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                        所属类别
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <%= rmp.comn.Comn.ReadCat1Item(row[PrpCons.P301000C].ToString(), "13010000").K%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                        应用平台
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <%= rmp.wrp.exts.Exts.decodePlatForm(int.Parse(row[PrpCons.P301000D].ToString())) %>
                                    </td>
                                    <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                        CPU 架构
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <%= rmp.wrp.exts.Exts.decodeArchBits(int.Parse(row[PrpCons.P3010002].ToString())) %>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                        最近更新
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <%= row[PrpCons.P3010011] %>
                                    </td>
                                    <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                        查询统计
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <%= row[PrpCons.P3010001] %>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                        快捷地址
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L" colspan="3">
                                        <a href="http://amonsoft.cn/?<%= extsName %>" title="后缀 <%= extsName %> 的快捷访问地址！">http://amonsoft.cn/?<%= extsName %></a><br />
                                        <a href="http://amonsoft.cn/exts/exts0001.aspx?exts=<%= extsName %>" title="后缀 <%= extsName %> 的常规访问地址！">http://amonsoft.cn/exts/exts0001.aspx?exts=<%= extsName %></a><br />
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                        网络搜索
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L" colspan="3">
                                    	<a href="http://www.google.cn/search?q=打开<%=extsName %>" title="在Google搜索 打开<%=extsName %>" target="_blank">打开<%=extsName%></a>&nbsp;<a href="http://www.google.cn/search?q=<%= extsName%>介绍" title="在Google搜索 <%= extsName%>介绍" target="_blank"><%= extsName%>介绍</a>&nbsp;<a href="http://www.google.cn/search?q=<%= extsName%>文件" title="在Google搜索 <%= extsName%>文件" target="_blank"><%= extsName%>文件</a>&nbsp;<a href="http://www.google.cn/search?q=<%= extsName%>格式" title="在Google搜索 <%= extsName%>格式" target="_blank"><%= extsName%>格式</a>&nbsp;<a href="http://www.google.cn/search?q=<%= extsName%>下载" title="在Google搜索 <%= extsName%>下载" target="_blank"><%= extsName%>下载</a>&nbsp;<a href="http://www.google.cn/search?q=<%= extsName%>相关软件" title="在Google搜索 <%= extsName%>相关软件" target="_blank"><%= extsName%>相关软件</a>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                        附注信息
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L" colspan="3">
                                        <%= rmp.util.WrpUtil.db2Html(row[PrpCons.P3010010].ToString()) %>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                        用户留言
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L" colspan="3">
                                        <a href="/idea/idea1001.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P3010003,"")%>">查看留言</a> &nbsp;<a href="/idea/idea1002.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P3010003,"")%>">发表意见</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="DV_DESP<%= i %>" style="display: none">
                        <td colspan="10">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL">
                                <tr>
                                    <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                        后缀描述
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <%row = despView.Rows.Count < 1 ? null : despView.Rows[0];String d = Text(row, PrpCons.P3010503);if (d.StartsWith("参见：")){d = d.Substring(3);%>
                                        参见：<a href="exts0001.aspx?exts=<%= d %>" title="点击查看 <%= d %> 的详细信息"><%= d %></a>
                                        <%}else if (d.ToLower().StartsWith("see:")){d = d.Substring(4);%>
                                        See:<a href="exts0001.aspx?exts=<%= d %>" title="点击查看 <%= d %> 的详细信息"><%= d %></a>
                                        <%}else{%><%=d%><%}%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                        用户留言
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <a href="/idea/idea1001.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P3010009,"")%>">查看留言</a>&nbsp;<a href="/idea/idea1002.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P3010009,"")%>">发表意见</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="DV_MIME<%= i %>" style="display: none">
                        <td colspan="10">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL">
                                <tr>
                                    <th style="width: 80px; height: 30px;" rowspan="<%= mimeView.Rows.Count + 1 %>" align="center" class="TD_DataHead_TL_L">
                                        MIME类型
                                    </th>
                                    <td style="height: 0px;">
                                    </td>
                                </tr>
                                <% foreach(System.Data.DataRow m in mimeView.Rows){ %>
                                <tr>
                                    <td style="height: 30px;" align="left" class="TD_DataItem_TL_L">
                                        <a href="/exts/exts0502.aspx?sid=<%=Text(m,PrpCons.P301F102,"")%>" title="点击查看有关此MIME的详细信息！">
                                            <%=Text(m,PrpCons.P301F104,"")%>
                                        </a>
                                    </td>
                                </tr>
                                <% } %>
                                <tr>
                                    <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                        用户留言
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <a href="/idea/idea1001.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P301000A,"")%>">查看留言</a>&nbsp;<a href="/idea/idea1002.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P301000A,"")%>">发表意见</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="DV_PLAT<%= i %>" style="display: none">
                        <td colspan="10">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL" id="PLATPROP">
                                <tr>
                                    <th style="width: 80px; height: 30px;" rowspan="<%= platView.Rows.Count + 1 %>" align="center" class="TD_DataHead_TL_L">
                                        平台名称
                                    </th>
                                    <td style="height: 0px;">
                                    </td>
                                </tr>
                                <% foreach(System.Data.DataRow p in platView.Rows) { %>
                                <tr>
                                    <td style="height: 30px;" align="left" class="TD_DataItem_TL_L">
                                        <a href="/exts/exts0602.aspx?sid=<%=Text(p,PrpCons.P301F203,"")%>" title="点击查看有关此平台的详细信息！">
                                            <%=Text(p,PrpCons.P301F206)%>
                                        </a>
                                    </td>
                                </tr>
                                <% } %>
                                <tr>
                                    <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                        用户留言
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <a href="/idea/idea1001.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P301000E,"")%>">查看留言</a>&nbsp;<a href="/idea/idea1002.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P301000E,"")%>">发表意见</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="DV_DOCS<%= i %>" style="display: none">
                        <td colspan="10">
                            <% row = docsView.Rows.Count <1 ?null: docsView.Rows[0]; %>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL" id="DOCSPROP">
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        文档名称
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <a href="/exts/docs/<%=Text(row,PrpCons.P3010404,"0.html")%>" target="_blank" title="点击查看文档"><%=Text(row,PrpCons.P3010405,"0.html")%></a>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        发行版本
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P3010406)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        发行日期
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P3010407)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        文档摘要
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P3010408)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        附注信息
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P3010409)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        用户留言
                                    </th>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <a href="/idea/idea1001.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P3010008,"")%>">查看留言</a>&nbsp;<a href="/idea/idea1002.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P3010008,"")%>">发表意见</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="DV_CORP<%= i %>" style="display: none">
                        <td colspan="10">
                            <% row = corpView.Rows.Count <1 ?null: corpView.Rows[0]; %>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL" id="CORPPROP">
                                <tr>
                                    <td style="width: 80px;" rowspan="2" align="center" class="TD_DataHead_TL_L">
                                        <img id="ICON_CORP" src="/exts/exts0002.ashx?sid=<%=row!=null?row[PrpCons.P3010104]:"0"%>&u=corp" alt="公司徽标" width="48" height="48" class="IMG_EXTSICON" onclick="viewIcon(event, '<%=Text(row,PrpCons.P3010104,"0")%>');" />
                                    </td>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        中文名称
                                    </th>
                                    <td style="width: 300px;" align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P3010105)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        英文名称
                                    </th>
                                    <td style="width: 300px;" align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P3010106)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        公司网址
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <a href="<%=Text(row,PrpCons.P3010107,"#")%>" title="<%=Text(row,PrpCons.P3010107,"")%>" target="_blank"><%=Text(row,PrpCons.P3010107)%></a>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        公司简介
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P3010108)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        相关说明
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P3010109)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                        用户留言
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <a href="/idea/idea1001.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P3010005,"")%>">查看留言</a>&nbsp;<a href="/idea/idea1002.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P3010005,"")%>">发表意见</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="DV_SOFT<%= i %>" style="display: none">
                        <td colspan="10">
                            <% row = softView.Rows.Count < 1 ? null:softView.Rows[0]; %>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL" id="SOFTPROP">
                                <tr>
                                    <td style="width: 80px;" rowspan="2" align="center" class="TD_DataHead_TL_L">
                                        <img id="ICON_SOFT" src="/exts/exts0002.ashx?sid=<%=Text(row,PrpCons.P3010204,"0")%>&u=soft" alt="软件图标" width="48" height="48" class="IMG_EXTSICON" onclick="viewIcon(event, '<%=Text(row,PrpCons.P3010204,"0")%>');" />
                                    </td>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        中文名称
                                    </th>
                                    <td style="width: 300px;" align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P3010205)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        英文名称
                                    </th>
                                    <td style="width: 300px;" align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P3010206)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        电子邮件
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <a href="mailto:<%=Text(row,PrpCons.P3010207,"#")%>" title="<%=Text(row,PrpCons.P3010207,"")%>" target="_blank"><%=Text(row,PrpCons.P3010207)%></a>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        链接地址
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <a href="<%=Text(row,PrpCons.P3010208,"#")%>" title="<%=Text(row,PrpCons.P3010208,"")%>" target="_blank"><%=Text(row,PrpCons.P3010208)%></a>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        兼容后缀
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <%String[] extsList = Text(row, PrpCons.P3010209).Trim().Split(',', ';'); String x; for (int a = 0, b = extsList.Length - 1; a < b; a += 1){x = extsList[a];%>
                                        <a href="exts0001.aspx?exts=<%= x %>" title="点击查看 <%= x %> 的详细信息"><%= x %></a><br />
                                        <%} x = extsList[extsList.Length - 1];%>
                                        <a href="exts0001.aspx?exts=<%= x %>" title="点击查看 <%= x %> 的详细信息"><%= x %></a>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        运行截图
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <a href="/exts/exts0003.ashx?uri=view&sid=<%=Text(row,PrpCons.P301020A,"0")%>" title="<%=Text(row,PrpCons.P301020A,"")%>" target="_blank">点击查看</a>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        软件简介
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P301020B)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        相关说明
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P301020C)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                        用户留言
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <a href="/idea/idea1001.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P3010006,"")%>">查看留言</a>&nbsp;<a href="/idea/idea1002.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P3010006,"")%>">发表意见</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="DV_FILE<%= i %>" style="display: none">
                        <td colspan="10">
                            <% row = fileView.Rows.Count < 1 ? null : fileView.Rows[0]; %>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL" id="FILEPROP">
                                <tr>
                                    <td style="width: 80px;" rowspan="2" align="center" class="TD_DataHead_TL_L">
                                        <img id="ICON_FILE" src="/exts/exts0002.ashx?sid=<%=Text(row,PrpCons.P3010304,"0")%>&u=file" alt="文件图标" width="48" height="48" class="IMG_EXTSICON" onclick="viewIcon(event, '<%=Text(row,PrpCons.P3010304,"0")%>');" />
                                    </td>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        数值签名
                                    </th>
                                    <td style="width: 300px;" align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P3010306)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        字符签名
                                    </th>
                                    <td style="width: 300px;" align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P3010305)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        偏移位置
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P3010307)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        加密算法
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P3010308)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        起始数据
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P3010309)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        结束数据
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P301030A)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        相关说明
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,PrpCons.P301030C)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                        用户留言
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <a href="/idea/idea1001.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P3010007,"")%>">查看留言</a>&nbsp;<a href="/idea/idea1002.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P3010007,"")%>">发表意见</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="DV_IDIO<%= i %>" style="display: none">
                        <td colspan="10">
                            <% row = idioView.Rows.Count < 1 ? null : idioView.Rows[0]; %>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL" id="IDIOPROP">
                                <tr>
                                    <td style="width: 80px;" rowspan="2" align="center" class="TD_DataHead_TL_L">
                                        <img id="ICON_IDIO" src="/user/user0002.ashx?sid=<%=Text(row,cons.io.db.comn.user.UserCons.C3010408,"0")%>&u=idio" alt="个性图标" width="48" height="48" class="IMG_EXTSICON" onclick="viewIcon(event, '<%=Text(row,cons.io.db.comn.user.UserCons.C3010408,"0")%>');" />
                                    </td>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        邮&nbsp;&nbsp;&nbsp;&nbsp;件
                                    </th>
                                    <td style="width: 300px;" align="left" class="TD_DataItem_TL_L">
                                        <a href="mailto:<%=Text(row,cons.io.db.comn.user.UserCons.C3010406,"#")%>" title="<%=Text(row,cons.io.db.comn.user.UserCons.C3010406,"")%>" target="_blank"><%=Text(row,cons.io.db.comn.user.UserCons.C3010406,"")%></a>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        昵&nbsp;&nbsp;&nbsp;&nbsp;称
                                    </th>
                                    <td style="width: 300px;" align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,cons.io.db.comn.user.UserCons.C3010407)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        签&nbsp;&nbsp;&nbsp;&nbsp;名
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <%=Text(row,cons.io.db.comn.user.UserCons.C3010409)%>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                        个人主页
                                    </th>
                                    <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                        <a href="<%=Text(row,cons.io.db.comn.user.UserCons.C301040A,"#")%>" title="<%=Text(row,cons.io.db.comn.user.UserCons.C301040A,"")%>" target="_blank"><%=Text(row,cons.io.db.comn.user.UserCons.C301040A)%></a>
                                    </td>
                                </tr>
                                <tr>
                                    <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
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
                                        <a href="/idea/idea1001.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P301000F,"")%>">查看留言</a>&nbsp;<a href="/idea/idea1002.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P301000F,"")%>">发表意见</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="DV_ASOC<%= i %>" style="display: none">
                        <td colspan="10">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="TB_DataList_TL" id="ASOCPROP">
                                <tr>
                                    <th style="width: 80px; height: 30px;" rowspan="<%= asocView.Rows.Count + 1 %>" align="center" class="TD_DataHead_TL_L">
                                        备选软件
                                    </th>
                                    <td style="width: 30px; height: 0px;">
                                    </td>
                                    <td style="height: 0px;">
                                    </td>
                                    <td style="width: 36px; height: 0px;">
                                    </td>
                                    <td style="width: 160px; height: 0px;">
                                    </td>
                                </tr>
                                <%
                                    foreach (System.Data.DataRow l in asocView.Rows)
                                    {
                                        int ay = Int32.Parse(l[PrpCons.P3010702].ToString());
                                %>
                                <tr>
                                    <td class="TD_DataItem_TL_L" style="height: 30px;" align="center">
                                        <img src="/exts/exts0002.ashx?sid=<%= l[PrpCons.P3010204]%>&d=0010&u=soft" alt="软件图标" width="16" height="16" />
                                    </td>
                                    <td class="TD_DataItem_TL_L" style="height: 30px;" align="left">
                                        <a href="/exts/exts0202.aspx?sid=<%= l[PrpCons.P3010704] %>" title="点击查看软件详细信息">
                                            <%= l[PrpCons.P3010205] %>
                                        </a>&nbsp;
                                    </td>
                                    <td class="TD_DataItem_TL_L" style="height: 30px;" align="center">
                                        <%= l[PrpCons.P3010705] %>
                                    </td>
                                    <td class="TD_DataItem_TL_L" style="height: 30px;" align="center">
                                        <img src="/exts/exts0002.ashx?sid=<%= (ay == cons.SysCons.OS_IDX_ALL) ? "_all" : "_def" %>" alt="平台通用" width="16" height="16" />
                                        <img src="/exts/exts0002.ashx?sid=<%= ((ay & cons.SysCons.OS_IDX_WINDOWS) != 0) ? "_win" : "_def" %>" alt="Windows平台" width="16" height="16" />
                                        <img src="/exts/exts0002.ashx?sid=<%= ((ay & cons.SysCons.OS_IDX_MACINTOSH) != 0) ? "_mac" : "_def" %>" alt="Macintosh平台" width="16" height="16" />
                                        <img src="/exts/exts0002.ashx?sid=<%= ((ay & cons.SysCons.OS_IDX_LINUX) != 0) ? "_lnx" : "_def" %>" alt="Linux平台" width="16" height="16" />
                                        <img src="/exts/exts0002.ashx?sid=<%= ((ay & cons.SysCons.OS_IDX_UNIX) != 0) ? "_unx" : "_def" %>" alt="Unix平台" width="16" height="16" />
                                        <img src="/exts/exts0002.ashx?sid=<%= ((ay & cons.SysCons.OS_IDX_MOBILE) != 0) ? "_mbl" : "_def" %>" alt="移动平台" width="16" height="16" />
                                        <img src="/exts/exts0002.ashx?sid=<%= ((ay & cons.SysCons.OS_IDX_UNKNOWN) != 0) ? "_spc" : "_def" %>" alt="其它平台" width="16" height="16" />
                                    </td>
                                </tr>
                                <%
                                    }
                                %>
                                <tr>
                                    <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                        用户留言
                                    </th>
                                    <td colspan="4" align="left" class="TD_DataItem_TL_L">
                                        <a href="/idea/idea1001.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P301000B,"")%>">查看留言</a>&nbsp;<a href="/idea/idea1002.aspx?sid=<%=Text(dv_DataView.Rows[i],PrpCons.P301000B,"")%>">发表意见</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%
            }
        }
        %>
    </table>
    <asp:HiddenField ID="hd_DataSize" runat="server" Value="0" />
    <asp:HiddenField ID="hd_StepSize" runat="server" Value="10" />
    <asp:HiddenField ID="hd_SoftHash" runat="server" />
    <asp:HiddenField ID="hd_ExtsCase" runat="server" />
    <asp:HiddenField ID="hd_ExtsName" runat="server" />
</asp:Content>

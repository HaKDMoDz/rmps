<%@ Page Language="C#" AutoEventWireup="true" CodeFile="inet0001.aspx.cs" Inherits="inet_inet0001" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Amon网页精灵</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        HTML, BODY, FORM
        {
            background-color: #ffffff;
            color: #330000;
            font-family: "宋体" , simsun, Arial, "Times New Roman";
            font-size: 9pt;
            margin: 0px;
            height: 100%;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="/inet/c/NetHelper.css" />
</head>
<body>
    <form id="AmonForm" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
            <tr>
                <td align="center">
                    <div id="Net_Amonsoft_NetHelper_Help" class="Net_Amonsoft_NetHelper_Form" style="width: <%= PAGE_WIDH %>px; text-align: center;">
                        <table id="Net_Amonsoft_NetHelper_BODY" class="Net_Amonsoft_NetHelper_BODY" width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <th id="Net_Amonsoft_NetHelper_HEAD" align="left" style="height: 21px; padding-left: 4px;">
                                    Amon 收藏
                                </th>
                                <th id="Net_Amonsoft_NetHelper_GUID" runat="server" align="right" style="height: 21px; padding-left: 4px;">
                                    &nbsp;
                                </th>
                            </tr>
                            <tr>
                                <td style="height: 16px;" colspan="2">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr align="center">
                                            <asp:Repeater ID="Net_Amonsoft_NetHelper_TABS_TD" runat="server">
                                                <ItemTemplate>
                                                    <td id="Net_Amonsoft_NetHelper_TAB<%#Container.ItemIndex%>" style="width: 40px; height: 16px;" class="Net_Amonsoft_NetHelper_TABD" onmouseover="tabO(this, <%#Container.ItemIndex%>)" onmouseout="tabX(this, <%#Container.ItemIndex%>)" onmouseup="tabS(this, <%#Container.ItemIndex%>)">
                                                        <a href="" title="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.comn.ComnCons.C2010004]%>" onclick="javascript: return false;">
                                                            <%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.comn.ComnCons.C2010004]%>
                                                        </a>
                                                    </td>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" style="height: <%= PAGE_ROWS * 20 %>px;">
                                    <%-- 网摘 --%>
                                    <div style="height: <%= PAGE_ROWS * 20 %>px; display: none;" id="Net_Amonsoft_NetHelper_10bms_DV" class="Net_Amonsoft_NetHelper_Help">
                                        <input id="Net_Amonsoft_NetHelper_10bms_HD" type="hidden" value="0" />
                                        <asp:DataList ID="Net_Amonsoft_NetHelper_10bms_TB" runat="server" BorderWidth="0" CellPadding="0" CellSpacing="0" Width="100%">
                                            <ItemStyle Height="20" HorizontalAlign="left" />
                                            <ItemTemplate>
                                                <a href="/inet/inet0002.aspx?sid=<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>" target="_blank" s="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>" w="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W201910A]%>" h="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W201910B]%>"
                                                    k="bms" title="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019107]%>" onclick="return openLink(this);">
                                                    <img src="/data/inet/<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019105]%>.gif" alt="" /><%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019106]%>
                                                </a>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                    <%-- 阅读 --%>
                                    <div style="height: <%= PAGE_ROWS * 20 %>px; display: none;" id="Net_Amonsoft_NetHelper_20rss_DV" class="Net_Amonsoft_NetHelper_Help">
                                        <input id="Net_Amonsoft_NetHelper_20rss_HD" type="hidden" value="0" />
                                        <asp:DataList ID="Net_Amonsoft_NetHelper_20rss_TB" runat="server" BorderWidth="0" CellPadding="0" CellSpacing="0" Width="100%">
                                            <ItemStyle Height="20" HorizontalAlign="left" />
                                            <ItemTemplate>
                                                <a href="/inet/inet0002.aspx?sid=<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>" target="_blank" s="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>" w="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W201910A]%>" h="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W201910B]%>"
                                                    k="rss" title="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019107]%>" onclick="return openLink(this);">
                                                    <img src="/data/inet/<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019105]%>.gif" alt="" /><%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019106]%>
                                                </a>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                    <%-- 搜索 --%>
                                    <div style="height: <%= PAGE_ROWS * 20 %>px; display: none;" id="Net_Amonsoft_NetHelper_30wse_DV" class="Net_Amonsoft_NetHelper_Help">
                                        <input id="Net_Amonsoft_NetHelper_30wse_HD" type="hidden" value="0" /><%-- 搜索 --%>
                                        <asp:DataList ID="Net_Amonsoft_NetHelper_30wse_TB" runat="server" BorderWidth="0" CellPadding="0" CellSpacing="0" Width="100%">
                                            <ItemStyle Height="20" HorizontalAlign="left" />
                                            <ItemTemplate>
                                                <a href="/inet/inet0002.aspx?sid=<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>" target="_blank" s="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>" w="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W201910A]%>" h="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W201910B]%>"
                                                    k="wse" title="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019107]%>" onclick="return openLink(this);">
                                                    <img src="/data/inet/<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019105]%>.gif" alt="" /><%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019106]%>
                                                </a>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                    <%-- 站点 --%>
                                    <div style="height: <%= PAGE_ROWS * 20 %>px; display: none;" id="Net_Amonsoft_NetHelper_31ssl_DV" class="Net_Amonsoft_NetHelper_Help">
                                        <input id="Net_Amonsoft_NetHelper_31ssl_HD" type="hidden" value="0" />
                                        <table id="Net_Amonsoft_NetHelper_31ssl_TB" cellspacing="0" cellpadding="0" border="0" style="border-width: 0px; width: 100%; border-collapse: collapse;">
                                            <asp:Repeater ID="Net_Amonsoft_NetHelper_31ssl_RP" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td style="width: 20%;" align="left">
                                                            <label for="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>_Cbox"><input type="checkbox" id="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>_Cbox" onclick="siteView(this, '<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>')" /><%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019106]%></label>
                                                        </td>
                                                        <td style="width: 20%;" align="right">
                                                            收录信息
                                                        </td>
                                                        <td style="width: 20%;" align="left" id="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>_Site">
                                                            ……
                                                        </td>
                                                        <td style="width: 20%;" align="right">
                                                            反向链接
                                                        </td>
                                                        <td style="width: 20%;" align="left" id="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>_Link">
                                                            ……
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </table>
                                    </div>
                                    <%-- 地图 --%>
                                    <div style="height: <%= PAGE_ROWS * 20 %>px; display: none;" id="Net_Amonsoft_NetHelper_32map_DV" class="Net_Amonsoft_NetHelper_Help">
                                        <input id="Net_Amonsoft_NetHelper_32map_HD" type="hidden" value="0" />
                                        <asp:DataList ID="Net_Amonsoft_NetHelper_32map_TB" runat="server" BorderWidth="0" CellPadding="0" CellSpacing="0" Width="100%">
                                            <ItemStyle Height="20" HorizontalAlign="left" />
                                            <ItemTemplate>
                                                <a href="/inet/inet0002.aspx?sid=<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>" target="_blank" s="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>" w="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W201910A]%>" h="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W201910B]%>"
                                                    k="ssl" title="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019107]%>" onclick="return openLink(this);">
                                                    <img src="/data/inet/<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019105]%>.gif" alt="" /><%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019106]%>
                                                </a>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                    <%-- 日历 --%>
                                    <div style="height: <%= PAGE_ROWS * 20 %>px; display: none;" id="Net_Amonsoft_NetHelper_40cal_DV" class="Net_Amonsoft_NetHelper_Help">
                                        <asp:DataList ID="Net_Amonsoft_NetHelper_40cal_TB" runat="server" BorderWidth="0" CellPadding="0" CellSpacing="0" Width="100%">
                                            <ItemStyle Height="20" HorizontalAlign="left" />
                                            <ItemTemplate>
                                                <a href="/inet/inet0002.aspx?sid=<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>" target="_blank" s="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>" w="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W201910A]%>" h="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W201910B]%>"
                                                    k="wmi" title="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019107]%>" onclick="return openLink(this);">
                                                    <img src="/data/inet/<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019105]%>" alt="" /><%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019106]%>
                                                </a>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                    <%-- 时间 --%>
                                    <div style="height: <%= PAGE_ROWS * 20 %>px; display: none;" id="Net_Amonsoft_NetHelper_41dts_DV" class="Net_Amonsoft_NetHelper_Help">
                                        <asp:DataList ID="Net_Amonsoft_NetHelper_41dts_TB" runat="server" BorderWidth="0" CellPadding="0" CellSpacing="0" Width="100%">
                                            <ItemStyle Height="20" HorizontalAlign="left" />
                                            <ItemTemplate>
                                                <a href="/inet/inet0002.aspx?sid=<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>" target="_blank" s="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>" w="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W201910A]%>" h="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W201910B]%>"
                                                    k="wmi" title="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019107]%>" onclick="return openLink(this);">
                                                    <img src="/data/inet/<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019105]%>" alt="" /><%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019106]%>
                                                </a>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                    <%-- 翻译 --%>
                                    <div style="height: <%= PAGE_ROWS * 20 %>px; display: none;" id="Net_Amonsoft_NetHelper_50wlt_DV" class="Net_Amonsoft_NetHelper_Help">
                                        <input id="Net_Amonsoft_NetHelper_50wlt_HD" type="hidden" value="0" />
                                        <asp:DataList ID="Net_Amonsoft_NetHelper_50wlt_TB" runat="server" BorderWidth="0" CellPadding="0" CellSpacing="0" Width="100%">
                                            <ItemStyle Height="20" HorizontalAlign="left" />
                                            <ItemTemplate>
                                                <a href="/inet/inet0002.aspx?sid=<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>" target="_blank" s="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>" w="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W201910A]%>" h="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W201910B]%>"
                                                    k="ssl" title="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019107]%>" onclick="return openLink(this);">
                                                    <img src="/data/inet/<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019105]%>.gif" alt="" /><%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019106]%>
                                                </a>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                    <%-- 邮件 --%>
                                    <div style="height: <%= PAGE_ROWS * 20 %>px; display: none;" id="Net_Amonsoft_NetHelper_60wmc_DV" class="Net_Amonsoft_NetHelper_Help">
                                        <input id="Net_Amonsoft_NetHelper_60wmc_HD" type="hidden" value="0" />
                                        <asp:DataList ID="Net_Amonsoft_NetHelper_60wmc_TB" runat="server" BorderWidth="0" CellPadding="0" CellSpacing="0" Width="100%">
                                            <ItemStyle Height="20" HorizontalAlign="left" />
                                            <ItemTemplate>
                                                <a href="/inet/inet0002.aspx?sid=<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>" target="_blank" s="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>" w="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W201910A]%>" h="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W201910B]%>"
                                                    k="ssl" title="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019107]%>" onclick="return openLink(this);">
                                                    <img src="/data/inet/<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019105]%>.gif" alt="" /><%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019106]%>
                                                </a>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                    <%-- 关于 --%>
                                    <div style="height: <%= PAGE_ROWS * 20 %>px; display: none;" id="Net_Amonsoft_NetHelper_90wmi_DV" class="Net_Amonsoft_NetHelper_Help">
                                        <asp:DataList ID="Net_Amonsoft_NetHelper_90wmi_TB" runat="server" BorderWidth="0" CellPadding="0" CellSpacing="0" Width="100%">
                                            <ItemStyle Height="20" HorizontalAlign="left" />
                                            <ItemTemplate>
                                                <a href="/inet/inet0002.aspx?sid=<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>" target="_blank" s="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019102]%>" w="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W201910A]%>" h="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W201910B]%>"
                                                    k="wmi" title="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019107]%>" onclick="return openLink(this);">
                                                    <img src="/data/inet/<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019105]%>.gif" alt="" /><%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.wrp.WrpCons.W2019106]%>
                                                </a>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                    <div style="height: <%= PAGE_ROWS * 20 %>px; display: none;" id="Net_Amonsoft_NetHelper_99def_DV" class="Net_Amonsoft_NetHelper_Help">
                                        <table id="Net_Amonsoft_NetHelper_99def_TB" cellspacing="0" cellpadding="0" border="0" style="border-width: 0px; width: 100%; border-collapse: collapse;">
                                            <tr>
                                                <td align="center">
                                                    服务器忙，请稍后重试！
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr id="tr_PageGuid" runat="server">
                                <td style="height: 16px;" colspan="2">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr id="Net_Amonsoft_NetHelper_10bms_TR" runat="server" style="display: none;">
                                            <td align="right">
                                                <%-- 网摘 --%>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_10bms_LP" runat="server" OnClick="Net_Amonsoft_NetHelper_10bms_LP_Click">上一页</asp:LinkButton>
                                                <%-- 页面提示 --%>
                                                <asp:Label ID="Net_Amonsoft_NetHelper_10bms_LT" runat="server" Text="1/3"></asp:Label>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_10bms_LN" runat="server" OnClick="Net_Amonsoft_NetHelper_10bms_LN_Click">下一页</asp:LinkButton>
                                                <%-- 当前页索引（下标0开始），下同 --%>
                                                <asp:HiddenField ID="Net_Amonsoft_NetHelper_10bms_HC" runat="server" />
                                            </td>
                                        </tr>
                                        <tr id="Net_Amonsoft_NetHelper_20rss_TR" runat="server" style="display: none;">
                                            <td align="right">
                                                <%-- 阅读 --%>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_20rss_LP" runat="server" OnClick="Net_Amonsoft_NetHelper_20rss_LP_Click">上一页</asp:LinkButton>
                                                <asp:Label ID="Net_Amonsoft_NetHelper_20rss_LT" runat="server" Text="1/3"></asp:Label>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_20rss_LN" runat="server" OnClick="Net_Amonsoft_NetHelper_20rss_LN_Click">下一页</asp:LinkButton>
                                                <asp:HiddenField ID="Net_Amonsoft_NetHelper_20rss_HC" runat="server" />
                                            </td>
                                        </tr>
                                        <tr id="Net_Amonsoft_NetHelper_30wse_TR" runat="server" style="display: none;">
                                            <td align="right">
                                                <%-- 搜索 --%>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_30wse_LP" runat="server" OnClick="Net_Amonsoft_NetHelper_30wse_LP_Click">上一页</asp:LinkButton>
                                                <asp:Label ID="Net_Amonsoft_NetHelper_30wse_LT" runat="server" Text="1/3"></asp:Label>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_30wse_LN" runat="server" OnClick="Net_Amonsoft_NetHelper_30wse_LN_Click">下一页</asp:LinkButton>
                                                <asp:HiddenField ID="Net_Amonsoft_NetHelper_30wse_HC" runat="server" />
                                            </td>
                                        </tr>
                                        <tr id="Net_Amonsoft_NetHelper_31ssl_TR" runat="server" style="display: none;">
                                            <td align="right">
                                                <%-- 收录 --%>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_31ssl_LP" runat="server" OnClick="Net_Amonsoft_NetHelper_31ssl_LP_Click">上一页</asp:LinkButton>
                                                <asp:Label ID="Net_Amonsoft_NetHelper_31ssl_LT" runat="server" Text="1/3"></asp:Label>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_31ssl_LN" runat="server" OnClick="Net_Amonsoft_NetHelper_31ssl_LN_Click">下一页</asp:LinkButton>
                                                <asp:HiddenField ID="Net_Amonsoft_NetHelper_31ssl_HC" runat="server" />
                                            </td>
                                        </tr>
                                        <tr id="Net_Amonsoft_NetHelper_32map_TR" runat="server" style="display: none;">
                                            <td align="right">
                                                <%-- 地图 --%>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_32map_LP" runat="server" OnClick="Net_Amonsoft_NetHelper_32map_LP_Click">上一页</asp:LinkButton>
                                                <asp:Label ID="Net_Amonsoft_NetHelper_32map_LT" runat="server" Text="1/3"></asp:Label>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_32map_LN" runat="server" OnClick="Net_Amonsoft_NetHelper_32map_LN_Click">下一页</asp:LinkButton>
                                                <asp:HiddenField ID="Net_Amonsoft_NetHelper_32map_HC" runat="server" />
                                            </td>
                                        </tr>
                                        <tr id="Net_Amonsoft_NetHelper_40cal_TR" runat="server" style="display: none;">
                                            <td align="right">
                                                <%-- 日历 --%>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_40cal_LP" runat="server" OnClick="Net_Amonsoft_NetHelper_40cal_LP_Click">上一页</asp:LinkButton>
                                                <asp:Label ID="Net_Amonsoft_NetHelper_40cal_LT" runat="server" Text="1/3"></asp:Label>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_40cal_LN" runat="server" OnClick="Net_Amonsoft_NetHelper_40cal_LN_Click">下一页</asp:LinkButton>
                                                <asp:HiddenField ID="Net_Amonsoft_NetHelper_40cal_HC" runat="server" />
                                            </td>
                                        </tr>
                                        <tr id="Net_Amonsoft_NetHelper_41dts_TR" runat="server" style="display: none;">
                                            <td align="right">
                                                <%-- 时间 --%>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_41dts_LP" runat="server" OnClick="Net_Amonsoft_NetHelper_41dts_LP_Click">上一页</asp:LinkButton>
                                                <asp:Label ID="Net_Amonsoft_NetHelper_41dts_LT" runat="server" Text="1/3"></asp:Label>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_41dts_LN" runat="server" OnClick="Net_Amonsoft_NetHelper_41dts_LN_Click">下一页</asp:LinkButton>
                                                <asp:HiddenField ID="Net_Amonsoft_NetHelper_41dts_HC" runat="server" />
                                            </td>
                                        </tr>
                                        <tr id="Net_Amonsoft_NetHelper_50wlt_TR" runat="server" style="display: none;">
                                            <td align="right">
                                                <%-- 翻译 --%>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_50wlt_LP" runat="server" OnClick="Net_Amonsoft_NetHelper_50wlt_LP_Click">上一页</asp:LinkButton>
                                                <asp:Label ID="Net_Amonsoft_NetHelper_50wlt_LT" runat="server" Text="1/3"></asp:Label>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_50wlt_LN" runat="server" OnClick="Net_Amonsoft_NetHelper_50wlt_LN_Click">下一页</asp:LinkButton>
                                                <asp:HiddenField ID="Net_Amonsoft_NetHelper_50wlt_HC" runat="server" />
                                            </td>
                                        </tr>
                                        <tr id="Net_Amonsoft_NetHelper_60wmc_TR" runat="server" style="display: none;">
                                            <td align="right">
                                                <%-- 邮件 --%>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_60wmc_LP" runat="server" OnClick="Net_Amonsoft_NetHelper_60wmc_LP_Click">上一页</asp:LinkButton>
                                                <asp:Label ID="Net_Amonsoft_NetHelper_60wmc_LT" runat="server" Text="1/3"></asp:Label>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_60wmc_LN" runat="server" OnClick="Net_Amonsoft_NetHelper_60wmc_LN_Click">下一页</asp:LinkButton>
                                                <asp:HiddenField ID="Net_Amonsoft_NetHelper_60wmc_HC" runat="server" />
                                            </td>
                                        </tr>
                                        <tr id="Net_Amonsoft_NetHelper_90wmi_TR" runat="server" style="display: none;">
                                            <td align="right">
                                                <%-- 关于 --%>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_90wmi_LP" runat="server" OnClick="Net_Amonsoft_NetHelper_90wmi_LP_Click">上一页</asp:LinkButton>
                                                <asp:Label ID="Net_Amonsoft_NetHelper_90wmi_LT" runat="server" Text="1/3"></asp:Label>
                                                <asp:LinkButton ID="Net_Amonsoft_NetHelper_90wmi_LN" runat="server" OnClick="Net_Amonsoft_NetHelper_90wmi_LN_Click">下一页</asp:LinkButton>
                                                <asp:HiddenField ID="Net_Amonsoft_NetHelper_90wmi_HC" runat="server" />
                                            </td>
                                        </tr>
                                        <tr id="Net_Amonsoft_NetHelper_99def_TR" runat="server" style="display: none;">
                                            <td align="right">
                                                Amonsoft
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr_SoftGuid" runat="server">
                                <td align="left" style="height: 16px;">
                                    &nbsp;
                                </td>
                                <td align="right" style="height: 16px;">
                                    <a href="http://amonsoft.net/" target="_blank" title="Amon软件">Amonsoft</a>&nbsp;<a href="http://amonsoft.net/inet/inet0001.aspx" target="_blank" onclick="return openFull();" title="更多网摘">更多…</a>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <%-- 当前选择分页索引 --%>
                    <asp:HiddenField ID="hd_I" runat="server" Value="0" />
                    <%-- 来源页面标题 --%>
                    <asp:HiddenField ID="hd_T" runat="server" />
                    <%-- 来源页面链接地址 --%>
                    <asp:HiddenField ID="hd_U" runat="server" />
                    <%-- 来源页面用户选择文本 --%>
                    <asp:HiddenField ID="hd_D" runat="server" />
                    <%-- 来源页面统计账户 --%>
                    <asp:HiddenField ID="hd_F" runat="server" />
                    <%-- 页面脚本引用 --%>
                    <asp:Literal ID="lt_Script" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
<script type="text/javascript" src="/inet/inet0001.js"></script>
<script type="text/javascript" src="http://js.tongji.linezing.com/437983/tongji.js"></script>
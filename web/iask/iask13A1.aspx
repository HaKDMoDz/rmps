<%@ Page Language="C#" MasterPageFile="~/iask/iask.master" AutoEventWireup="true" CodeFile="iask13A1.aspx.cs" Inherits="iask_iask13A1" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="80%" border="0" cellpadding="2" cellspacing="0">
                    <tr>
                        <td align="right" style="width: 80px;">
                            时间：
                        </td>
                        <td align="left">
                            <div>
                                <asp:TextBox ID="tf_CurrDate" runat="server" ReadOnly="true" Columns="16"></asp:TextBox><img id="im_CurrDate" alt="" src="/_images/date.gif" style="vertical-align: middle;" onclick="initView();" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 80px;">
                            地区：
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cb_AreaList" runat="server" OnSelectedIndexChanged="cb_AreaList_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 80px;">
                            电台：
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cb_StatList" runat="server" OnSelectedIndexChanged="cb_StatList_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 80px;">
                            频道：
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cb_ChnlList" runat="server" OnSelectedIndexChanged="cb_ChnlList_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
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
        <tr>
            <td class="TD_LINE">
            </td>
        </tr>
        <tr>
            <td align="center" id="td_ProgList">
                <table width="90%" class="TB_DataList_TL" border="0" cellpadding="2" cellspacing="0">
                    <asp:Repeater ID="rp_ProgList" runat="server">
                        <HeaderTemplate>
                            <tr>
                                <td class="TD_DataHead_TL_L" align="center" style="width: 15%;">
                                    播出时间
                                </td>
                                <td class="TD_DataHead_TL_L" align="center" style="width: 35%;">
                                    节目信息
                                </td>
                                <td class="TD_DataHead_TL_L" align="center" style="width: 50%;">
                                    电台信息
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="TD_DataItem_TL_L" align="center">
                                    <%#Eval("playTime")%>
                                </td>
                                <td class="TD_DataItem_TL_L" align="left">
                                    <%#Eval("tvProgram")%>
                                </td>
                                <td class="TD_DataItem_TL_L" align="left">
                                    <%#Eval("tvStationInfo")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            &nbsp;
                        </FooterTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

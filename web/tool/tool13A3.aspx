<%@ Page Language="C#" MasterPageFile="~/tool/tool.master" AutoEventWireup="true" CodeFile="tool13A3.aspx.cs" Inherits="tool_tool13A3" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                省份：<asp:DropDownList ID="cb_ProvList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_ProvList_SelectedIndexChanged">
                </asp:DropDownList>
                城市：<asp:DropDownList ID="cb_CityList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_CityList_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td height="1" class="TD_LINE">
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr id="tr_Mini" runat="server">
            <td align="center">
                <table border="0" cellpadding="3" cellspacing="0" width="460" class="TB_DataList_TL">
                    <tr>
                        <td align="center" rowspan="3" width="100" class="TD_DataItem_TL_L">
                            <asp:Image ID="im_T00" Width="100" Height="70" runat="server" />
                        </td>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_T00" runat="server"></asp:Label>
                        </td>
                        <td align="center" rowspan="2" width="70" class="TD_DataItem_TL_L">
                            <asp:Image ID="im_T01" runat="server" />&nbsp;&nbsp;<asp:Image ID="im_T02" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_T05" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_T07" runat="server"></asp:Label>
                        </td>
                        <td align="center" width="70" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_T06" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" rowspan="3" width="100" class="TD_DataItem_TL_L">
                            <asp:LinkButton ID="lb_24" runat="server" OnClick="lb_24_Click">24小时</asp:LinkButton><br />
                            <asp:LinkButton ID="lb_48" runat="server" OnClick="lb_48_Click">48小时</asp:LinkButton><br />
                            <asp:LinkButton ID="lb_72" runat="server" OnClick="lb_72_Click">72小时</asp:LinkButton></td>
                        <td align="left" colspan="2" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_T11" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_T12" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_T13" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

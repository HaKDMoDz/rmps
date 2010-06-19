<%@ Page Language="C#" MasterPageFile="~/tool/tool.master" AutoEventWireup="true" CodeFile="tool13A1.aspx.cs" Inherits="tool_tool13A1" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="2" cellspacing="0">
                    <tr>
                        <td align="center" style="width: 10%;">
                            时间：
                        </td>
                        <td align="left" style="width: 40%;">
                            <asp:TextBox ID="tf_CurrDate" runat="server" ReadOnly="true" Style="width: 80%;"></asp:TextBox><input id="bt_CurrDate" type="image" src="/_images/date.gif" style="vertical-align: middle;" value="D" onclick="initView();" />
                        </td>
                        <td align="center" style="width: 10%;">
                            地区：
                        </td>
                        <td align="left" style="width: 40%;">
                            <asp:DropDownList ID="cb_AreaList" runat="server" Style="width: 96%;" OnSelectedIndexChanged="cb_AreaList_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="width: 10%;">
                            电台：
                        </td>
                        <td align="left" style="width: 40%;">
                            <asp:DropDownList ID="cb_StatList" runat="server" Style="width: 96%;" OnSelectedIndexChanged="cb_StatList_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td align="center" style="width: 10%;">
                            频道：
                        </td>
                        <td align="left" style="width: 40%;">
                            <asp:DropDownList ID="cb_ChnlList" runat="server" Style="width: 96%;" OnSelectedIndexChanged="cb_ChnlList_SelectedIndexChanged" AutoPostBack="True">
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
            <td align="center">
                <div style="position: relative; width: 460px; height: 180px; overflow: scroll; border: solid 1px #CCCCCC;">
                    <table class="TB_DataList_TL" border="0" cellpadding="2" cellspacing="0" style="min-width: 100%; width: 100%;">
                        <asp:Repeater ID="rp_ProgList" runat="server">
                            <HeaderTemplate>
                                <thead>
                                    <tr>
                                        <td class="TD_DataHead_TL_L" align="center" width="15%">
                                            播出时间
                                        </td>
                                        <td class="TD_DataHead_TL_L" align="center" width="35%">
                                            节目信息
                                        </td>
                                        <td class="TD_DataHead_TL_L" align="center" width="50%">
                                            电台信息
                                        </td>
                                    </tr>
                                </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr onmouseover="igo.mouseOver(this)" onmouseout="igo.mouseExit(this)">
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
                                </tbody>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

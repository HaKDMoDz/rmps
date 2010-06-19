<%@ Page Language="C#" MasterPageFile="~/tool/tool.master" AutoEventWireup="true" CodeFile="tool13A2.aspx.cs" Inherits="tool_tool13A2" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <asp:RadioButton ID="rb_Zip2City" runat="server" AutoPostBack="True" GroupName="zc" Text="邮编到地址" Checked="True" OnCheckedChanged="rb_Zip2City_CheckedChanged" />
                <asp:RadioButton ID="rb_City2Zip" runat="server" AutoPostBack="True" GroupName="zc" Text="地址到邮编" OnCheckedChanged="rb_City2Zip_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="3" cellspacing="0">
                    <tr id="z2c" runat="server">
                        <td align="center" width="20%">
                            邮编：
                        </td>
                        <td align="center" colspan="2">
                            <asp:TextBox ID="tf_Zip2City" runat="server" Style="width: 96%;" AutoPostBack="True" OnTextChanged="tf_Zip2City_TextChanged">200080</asp:TextBox>
                        </td>
                        <td align="center" width="20%">
                            <asp:Button ID="bt_Zip2City" runat="server" OnClick="bt_Zip2City_Click" Text="查询(Q)" AccessKey="Q" />
                        </td>
                    </tr>
                    <tr id="c2z" visible="false" runat="server">
                        <td align="center" width="20%">
                            <asp:DropDownList ID="cb_Province" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_Province_SelectedIndexChanged" Style="max-width: 138; width: 96%;" ToolTip="省份/直辖市">
                            </asp:DropDownList>
                        </td>
                        <td align="center" width="20%">
                            <asp:DropDownList ID="cb_City" runat="server" Style="max-width: 138; width: 96%;" ToolTip="城市/地区">
                            </asp:DropDownList>
                        </td>
                        <td align="center" width="40%">
                            <asp:TextBox ID="tf_City2Zip" runat="server" Style="width: 96%;" AutoPostBack="True" OnTextChanged="tf_City2Zip_TextChanged" ToolTip="乡镇/街道"></asp:TextBox>
                        </td>
                        <td align="center" width="20%">
                            <asp:Button ID="bt_City2Zip" runat="server" AccessKey="Q" Text="查询(Q)" OnClick="bt_City2Zip_Click" />
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
            <td align="left">
                <div style="position: relative; width: 460px; height: 180px; overflow: scroll; border: solid 1px #CCCCCC;">
                    <table border="0" cellpadding="3" cellspacing="0" style="min-width: 100%; width: 100%;">
                        <asp:Repeater ID="rp_Zip5City" runat="server">
                            <HeaderTemplate>
                                <tr>
                                    <td class="TD_DataHead_TL_L" align="center">
                                        邮政编码
                                    </td>
                                    <td class="TD_DataHead_TL_L" align="center">
                                        街道、乡镇
                                    </td>
                                    <td class="TD_DataHead_TL_L" align="center">
                                        城市、地区
                                    </td>
                                    <td class="TD_DataHead_TL_L" align="center">
                                        省份/直辖市
                                    </td>
                                </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr onmouseover="igo.mouseOver(this)" onmouseout="igo.mouseExit(this)">
                                    <td class="TD_DataItem_TL_L" align="center">
                                        <%#Eval("ZIP")%>
                                    </td>
                                    <td class="TD_DataItem_TL_L" align="left">
                                        <%#Eval("ADDRESS")%>
                                    </td>
                                    <td class="TD_DataItem_TL_L" align="center">
                                        <%#Eval("CITY")%>
                                    </td>
                                    <td class="TD_DataItem_TL_L" align="center">
                                        <%#Eval("PROVINCE")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/iask/iask.master" AutoEventWireup="true" CodeFile="iask13A2.aspx.cs" Inherits="iask_iask13A2" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <asp:RadioButton ID="rb_Zip2City" runat="server" AutoPostBack="True" GroupName="zc" Text="邮编到地址" Checked="True" OnCheckedChanged="rb_Zip2City_CheckedChanged" />
                <asp:RadioButton ID="rb_City2Zip" runat="server" AutoPostBack="True" GroupName="zc" Text="地址到邮编" OnCheckedChanged="rb_City2Zip_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="90%" id="z2c" runat="server" border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <td width="25%" align="right">
                            邮编：
                        </td>
                        <td align="left" width="75%">
                            <asp:TextBox ID="tf_Zip2City" runat="server" AutoPostBack="True" OnTextChanged="tf_Zip2City_TextChanged">200080</asp:TextBox>
                            <asp:Button ID="bt_Zip2City" runat="server" OnClick="bt_Zip2City_Click" Text="查询(Q)" AccessKey="Q" />
                        </td>
                    </tr>
                </table>
                <table width="90%" id="c2z" visible="false" runat="server" border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <td width="25%" align="right">
                            省份/直辖市：
                        </td>
                        <td align="left" width="75%">
                            <asp:DropDownList ID="cb_Province" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_Province_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" align="right">
                            城市/地区：
                        </td>
                        <td align="left" width="75%">
                            <asp:DropDownList ID="cb_City" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" align="right">
                            乡镇/街道：
                        </td>
                        <td align="left" width="75%">
                            <asp:TextBox ID="tf_City2Zip" runat="server" AutoPostBack="True" OnTextChanged="tf_City2Zip_TextChanged"></asp:TextBox>
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
            <td class="TD_LINE" height="1">
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table class="TB_DataList_TL" border="0" cellpadding="3" cellspacing="0">
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
                            <tr>
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
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/tool/tool.master" AutoEventWireup="true" CodeFile="tool130C.aspx.cs" Inherits="tool_tool130C" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table>
                    <tr>
                        <td>
                            &nbsp;您的ＩＰ地址：
                        </td>
                        <td>
                            <asp:TextBox ID="tf_IpText" runat="server" AutoPostBack="True"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;<asp:Button ID="bt_IpText" runat="server" AccessKey="Q" OnClick="bt_IpText_Click" Text="查询(Q)" />
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
                &nbsp;<asp:Label ID="lb_IpInfo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

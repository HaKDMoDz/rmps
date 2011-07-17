<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AmonAuth.ascx.cs" Inherits="App_Ascx_AmonAuth" %>
<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <asp:TextBox ID="tf_AmonAuth" runat="server" Columns="6"></asp:TextBox>
        </td>
        <td>
            <asp:ImageButton ID="im_AmonAuth" runat="server" ToolTip="看不清楚，请点击刷新" OnClick="im_AmonAuth_Click" />
        </td>
    </tr>
</table>

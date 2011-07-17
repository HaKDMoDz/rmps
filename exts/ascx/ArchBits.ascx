<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArchBits.ascx.cs" Inherits="exts_ascx_ArchBits" %>
<table>
    <tr>
        <td align="left">
            <asp:CheckBox ID="ck_Ab64" runat="server" AccessKey="0" Text="64位(0)" />
        </td>
        <td align="left">
            <asp:CheckBox ID="ck_Ab32" runat="server" AccessKey="2" Text="32位(2)" Checked="True" />
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:CheckBox ID="ck_Ab16" runat="server" AccessKey="2" Text="16位(2)" />
        </td>
        <td align="left">
            <asp:CheckBox ID="ck_Ab00" runat="server" AccessKey="3" Text="其它(3)" />
        </td>
    </tr>
</table>

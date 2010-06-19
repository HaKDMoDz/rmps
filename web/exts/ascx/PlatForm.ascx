<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PlatForm.ascx.cs" Inherits="exts_ascx_PlatForm" %>
<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="left" colspan="2">
            <asp:CheckBox ID="ck_PfAll" runat="server" AccessKey="G" Text="平台通用(G)" Checked="True" />
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:CheckBox ID="ck_PfWin" runat="server" AccessKey="W" Text="Windows(W)" />
        </td>
        <td align="left">
            <asp:CheckBox ID="ck_PfMac" runat="server" AccessKey="M" Text="Macintosh(M)" />
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:CheckBox ID="ck_PfUnx" runat="server" AccessKey="U" Text="Unix(U)" />
        </td>
        <td align="left">
            <asp:CheckBox ID="ck_PfLnx" runat="server" AccessKey="L" Text="Linux(L)" />
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:CheckBox ID="ck_PfMbl" runat="server" AccessKey="B" Text="移动平台(B)" />
        </td>
        <td align="left">
            <asp:CheckBox ID="ck_PfSpc" runat="server" AccessKey="O" Text="其它平台(O)" />
        </td>
    </tr>
</table>

<script type="text/javascript">
function chgStat()
{
    var PLATFORM = 'pf_PlatForm_';
    var b = $X(_PRE + PLATFORM + 'ck_PfAll').checked;

    $X(_PRE + PLATFORM + 'ck_PfWin').disabled = b;
    $X(_PRE + PLATFORM + 'ck_PfMac').disabled = b;
    $X(_PRE + PLATFORM + 'ck_PfUnx').disabled = b;
    $X(_PRE + PLATFORM + 'ck_PfLnx').disabled = b;
    $X(_PRE + PLATFORM + 'ck_PfMbl').disabled = b;
    $X(_PRE + PLATFORM + 'ck_PfSpc').disabled = b;
}

chgStat();
</script>


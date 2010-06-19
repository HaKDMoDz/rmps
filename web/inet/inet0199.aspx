<%@ Page Language="C#" MasterPageFile="~/inet/inet.master" AutoEventWireup="true" CodeFile="inet0199.aspx.cs" Inherits="inet_inet0199" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td>
                <asp:Label ID="lb_ErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                确认要删除此数据吗？<br />
                执行此操作后有可能会影响到您现有的显示数据信息！！！<br />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:HiddenField ID="hd_W2019102" runat="server" Value="0" />
                <asp:Button ID="bt_SaveData" runat="server" Text="删除(S)" AccessKey="S" OnClick="bt_SaveData_Click" OnClientClick="return confirm('确认要执行删除操作吗？此操作将不可恢复！');" />
                <input type="button" value="返回(R)" accesskey="R" onclick="window.location.href = 'inet0102.aspx?sid=iNetHelper_90wmi'" />
            </td>
        </tr>
    </table>
</asp:Content>

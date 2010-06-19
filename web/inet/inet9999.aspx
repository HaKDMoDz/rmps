<%@ Page Language="C#" MasterPageFile="~/inet/inet.master" AutoEventWireup="true" CodeFile="inet9999.aspx.cs" Inherits="inet_inet9999" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td>
                <asp:Label ID="lb_ErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                说明：<br />
                您的删除操作将会影响到用户的配置数据，<br />
                要执行此操作请重新为用户指定一个替换数据！<br />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ListBox ID="lb_Replace" runat="server" Rows="10" Width="160"></asp:ListBox>
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
                <asp:HiddenField ID="hd_W2019104" runat="server" Value="0" />
                <asp:Button ID="bt_SaveData" runat="server" Text="保存(S)" AccessKey="S" OnClick="bt_SaveData_Click" OnClientClick="return checkNull();" />
                <input type="button" value="返回(R)" accesskey="R" onclick="window.location.href = 'inet0102.aspx?sid='+$E('hd_W2019104').value" />
            </td>
        </tr>
    </table>
</asp:Content>

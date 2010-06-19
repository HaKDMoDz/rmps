<%@ Page Language="C#" MasterPageFile="~/link/link.master" AutoEventWireup="true" CodeFile="link0204.aspx.cs" Inherits="link_link0204" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <div class="DV_TEXT1">
                    【说明】<br />
                    &nbsp;&nbsp;确认要删除此类别及其下面所有的链接数据吗，此操作将不恢复？
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="bt_Delete" runat="server" Text="删除(D)" AccessKey="D" OnClick="bt_Delete_Click" OnClientClick="return confirm('确认要执行删除操作吗，此操作将不可恢复？');" />
                <asp:HiddenField ID="hd_P3070A05" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

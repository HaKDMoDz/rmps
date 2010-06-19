<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0204.aspx.cs" Inherits="exts_exts0204" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 40px;">
                <asp:Label ID="lb_NoteInfo" runat="server" Text="确认要删除此软件信息么？此操作将不可恢复！"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:HiddenField ID="hd_SoftHash" runat="server" />
                <asp:Button ID="bt_Delete" runat="server" Text="删除(D)" AccessKey="D" OnClick="bt_Delete_Click" />
                <input id="bt_Cancel" type="button" value="取消(C)" accesskey="C" onclick="javascript:history.back();" />
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

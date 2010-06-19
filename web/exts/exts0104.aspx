<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0104.aspx.cs" Inherits="exts_exts0104" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                请输入您要删除此数据的原因：
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 40px;">
                <asp:TextBox ID="ta_P3010109" runat="server" Rows="4" TextMode="MultiLine" Width="96%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:HiddenField ID="hd_CorpHash" runat="server" />
                <asp:Button ID="bt_Delete" runat="server" Text="删除(D)" AccessKey="D" OnClick="bt_Delete_Click" OnClientClick="return checkNull();" />
                <input id="bt_Cancel" type="button" value="取消(C)" accesskey="C" onclick="javascript:history.back();" />&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Templates/Tplt.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Templates_index" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;<asp:Button ID="Button1" runat="server" Text="更新" onclick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

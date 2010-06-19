<%@ Page Language="C#" MasterPageFile="~/wime/wime.master" AutoEventWireup="true" CodeFile="wime0001.aspx.cs" Inherits="wime_wime0001" Title="网页五笔" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <asp:TextBox ID="ta_TextArea" runat="server" TextMode="multiLine" Width="420" Rows="20"></asp:TextBox>

                <script type="text/javascript" src="/wime/wime0001.ashx"></script>

            </td>
        </tr>
    </table>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/date/date.master" AutoEventWireup="true" CodeFile="date0001.aspx.cs" Inherits="date_date0001" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:DataList ID="dl_DateList" runat="server" Width="460" RepeatColumns="5" BorderWidth="1" CellSpacing="6" CellPadding="1" CssClass="TB_DATELIST" RepeatDirection="horizontal">
                    <ItemStyle CssClass="TD_DATEITEM" HorizontalAlign="center" Width="20%" />
                    <ItemTemplate>
                        <a href="date0002.aspx?sid=<%#Eval(cons.io.db.prp.PrpCons.P3100103)%>" title="<%#Eval(cons.io.db.prp.PrpCons.P3100108)%>">
                            <%#Eval(cons.io.db.prp.PrpCons.P3100107)%>
                        </a>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

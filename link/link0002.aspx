<%@ Page Language="C#" MasterPageFile="~/link/link.master" AutoEventWireup="true" CodeFile="link0002.aspx.cs" Inherits="link_link0002" Title="友情链接" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <asp:DataList ID="dl_DataList" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" Width="460px">
                    <ItemStyle HorizontalAlign="left" Width="25%" />
                    <ItemTemplate>
                        ·<a href="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.prp.PrpCons.P3070109]%>" title="<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.prp.PrpCons.P3070108]%>" onclick="return viewLink('<%#((System.Data.DataRowView)Container.DataItem)[cons.io.db.prp.PrpCons.P3070105]%>')" target="_blank"><%#rmp.util.StringUtil.FixWidth(((System.Data.DataRowView)Container.DataItem)[cons.io.db.prp.PrpCons.P3070107]+"",6)%></a>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>

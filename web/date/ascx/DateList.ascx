<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DateList.ascx.cs" Inherits="date_ascx_DateList" %>
<table border="0" cellpadding="0" cellspacing="0" id="TB_LIST">
    <tr>
        <td style="height: 10px">
        </td>
    </tr>
    <%
        rmp.bean.K1V3 item;
        foreach (ArrayList itemList in rmp.wrp.date.Date.DateList())
        {
            item = (rmp.bean.K1V3)itemList[0];
    %>
    <tr>
        <td align="center">
            <table border="0" cellpadding="2" cellspacing="0" class="TB_LIST_ITEM">
                <tr>
                    <td align="center" class="TD_LIST_HEAD">
                        <%= item.V1 %>
                    </td>
                </tr>
                <%
                    for (int j = 1; j < itemList.Count; j += 1)
                    {
                        item = (rmp.bean.K1V3)itemList[j];
                %>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/date/date0001.aspx?sid=<%= item.K %>" title="<%= item.V2 %>"><%= item.V1 %></a>
                    </td>
                </tr>
                <%
                    }
                %>
            </table>
        </td>
    </tr>
    <tr>
        <td style="height: 10px;">
        </td>
    </tr>
    <%
        }
    %>
</table>

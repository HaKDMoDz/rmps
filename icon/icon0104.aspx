<%@ Page Language="C#" AutoEventWireup="true" CodeFile="icon0104.aspx.cs" Inherits="icon_icon0104" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=cons.wrp.WrpCons.TITLE_ICON%>
    </title>
    <%=cons.wrp.WrpCons.KEYWORDS_ICON%>
    <%=cons.wrp.WrpCons.DESCRIPTION_ICON%>
    <%=rmp.wrp.Wrps.ComnHead(cons.wrp.WrpCons.MODULE_ICON)%>
    <%= rmp.wrp.Wrps.GetScript(cons.wrp.WrpCons.MODULE_SYNC) %>
</head>
<body>
    <form id="AmonForm" runat="server">
        <table border="0" cellpadding="3" cellspacing="0" width="100%">
            <tr>
                <th class="TD_DataHead_TL_L" align="center" style="height: 30px;">
                    <asp:Label ID="lb_NoteInfo" runat="server"></asp:Label>
                    <asp:HiddenField ID="hd_IconPath" runat="server" />
                </th>
            </tr>
            <tr id="tr1">
                <td align="center">
                    <table width="96%" border="0" cellpadding="2" cellspacing="0" class="TB_DataList_TL">
                        <tr>
                            <%
                                int size = iconList.Count;
                                int i = 0;
                                int row = 1;
                                int num = 1;
                                String t;
                                while (i < size)
                                {
                                    t = (String)iconList[i];
                            %>
                            <td class="TD_DataItem_TL_L">
                                <img src="<%= iconPath + t %>" alt="" width="48" height="48" class="IMG_EXTSICON" />
                                <%
                                    t = t.Substring(0, t.Length - 8);
                                    if (t == iconHash)
                                    {
                                %>
                                <input type="radio" name="rb_IconHash" value="<%= t %>" checked="checked" />
                                <%
                                    }
                                    else
                                    {
                                %>
                                <input type="radio" name="rb_IconHash" value="<%= t %>" />
                                <% } %>
                            </td>
                            <%
                                i += 1;
                                if (i % ROW_SIZE == 0)
                                {
                            %>
                        </tr>
                        <%
                            row += 1;
                            if (row == COL_SIZE)
                            {
                                row = 1;
                                num += 1;
                        %>
                    </table>
                </td>
            </tr>
            <tr id="tr<%= num %>" style="display: none">
                <td align="center">
                    <table width="96%" border="0" cellpadding="2" cellspacing="0" class="TB_DataList_TL">
                        <%
                            }
                        %>
                        <tr>
                            <%
                                }
                            }
                            %>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <th align="left" class="TD_DataHead_TL_L" style="height: 30px;">
                    <%
                        for (int k = 1; k <= num; k += 1)
                        {
                    %>
                    &nbsp;<a href="#" onclick="showTR('<%= k %>');"><%= k %></a>
                    <%
                        }
                    %>
                </th>
            </tr>
            <tr>
                <td align="right" style="height: 30px;">
                    <asp:HiddenField ID="hd_IconHash" runat="server" />
                    <input id="ck_Append" type="checkbox" checked="checked" accesskey="A" title="追加所选择的图片" />追加(A)
                    <input id="bt_Select" type="button" value="选择(S)" accesskey="S" onclick="chooseImage();" />
                    <input id="bt_Return" type="button" value="返回(R)" accesskey="S" onclick="returnHome();" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

<script type="text/javascript" src="icon0104.js"></script>
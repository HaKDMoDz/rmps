<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SoftList.ascx.cs" Inherits="soft_ascx_SoftList" %>
<table border="0" cellpadding="0" cellspacing="0" id="TB_LIST">
    <tr>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td align="center">
            <table border="0" cellpadding="2" cellspacing="0" class="TB_LIST_ITEM">
                <tr>
                    <td align="center" class="TD_LIST_HEAD">
                        系列软件
                    </td>
                </tr>
                <%
                    ArrayList al = rmp.wrp.soft.Soft.GetSoftList();
                    rmp.bean.K1V3 kvItem;
                    for (int i = 0, j = al.Count; i < j; i += 1)
                    {
                        kvItem = (rmp.bean.K1V3)al[i];
                %>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="soft0001.aspx?sid=<%= kvItem.K %>"><%= kvItem.V1 %></a>
                    </td>
                </tr>
                <%
                    }
                %>
                <tr>
                    <td class="TD_LIST_FOOT">
                        更多
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="height: 10px;">
        </td>
    </tr>
    <tr>
        <td align="center">
            <table border="0" cellpadding="2" cellspacing="0" class="TB_LIST_ITEM">
                <tr>
                    <td align="center" class="TD_LIST_HEAD">
                        友情链接
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<asp:HyperLink ID="HyperLink7" NavigateUrl="http://www.freewb.org/" ToolTip="优秀的五笔输入法软件" Target="_blank" runat="server">极点五笔</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<asp:HyperLink ID="HyperLink8" NavigateUrl="http://www.dreammail.org/" ToolTip="DreamMail是一款专业的电子邮件软件" Target="_blank" runat="server">梦幻快车</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<asp:HyperLink ID="HyperLink9" NavigateUrl="http://notepad-plus.sourceforge.net/" Target="_blank" runat="server">Notepad++</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="http://www.dtdown.net" target="_blank" title="欢迎访问大唐软件站">大唐软件站</a>
                    </td>
                </tr>
                <tr>
                    <td class="TD_LIST_FOOT">
                        更多
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="height: 10px;">
        </td>
    </tr>
</table>

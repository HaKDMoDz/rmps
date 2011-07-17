<%@ Control Language="C#" AutoEventWireup="true" CodeFile="IdeaList.ascx.cs" Inherits="idea_ascx_IdeaList" %>
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
                        意见反馈
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·<a href="/idea/index.aspx">反馈首页</a>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·<a href="/idea/idea0002.aspx">所有反馈</a>
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
        <td height="10px">
        </td>
    </tr>
    <tr>
        <td align="center">
            <table border="0" cellpadding="2" cellspacing="0" class="TB_LIST_ITEM">
                <tr>
                    <td align="center" class="TD_LIST_HEAD">
                        快捷列表
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
                    <td align="left">
                        ·<a href="/idea/idea0002.aspx?sid=<%= kvItem.K %>"><%= kvItem.V1 %></a>
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
        <td height="10px">
        </td>
    </tr>
</table>

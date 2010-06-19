<%@ Page Language="C#" MasterPageFile="~/idea/idea.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="idea_index" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;如果您在使用Amon系列软件的过程中存在问题、意见或建议，欢迎在此<a href="idea0001.aspx" title="发表留言">留言反馈</a>，作者会在最快的时间内给予您回复！
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;<a href="idea0002.aspx">所有留言</a>
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
                &nbsp;&nbsp;&nbsp;&nbsp;<a href="idea0002.aspx?sid=<%= kvItem.K %>"><%= kvItem.V1 %></a>
            </td>
        </tr>
        <%
            }
        %>
    </table>
</asp:Content>

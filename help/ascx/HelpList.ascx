<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HelpList.ascx.cs" Inherits="help_ascx_HelpList" %>
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
                        使用帮助
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·<a href="/help/help0001.aspx" title="系统简介">系统简介</a>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·<a href="/help/help0002.aspx" title="软件目标">软件目标</a>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·<a href="/help/help0003.aspx" title="开源方案">开源方案</a>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·<a href="/help/help0004.aspx" title="标准插件">标准插件</a>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·<a href="/help/help0005.aspx" title="独立插件">独立插件</a>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·<a href="/help/help0006.aspx" title="环境需求">环境需求</a>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·<a href="/help/help0007.aspx" title="安装说明">安装说明</a>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="TD_LIST_FOOT">
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
                    <td align="left">
                        ·<a href="help1000.aspx?sid=<%= kvItem.K %>"><%= kvItem.V1 %></a>
                    </td>
                </tr>
                <%
                    }
                %>
                <tr>
                    <td align="right" class="TD_LIST_FOOT">
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

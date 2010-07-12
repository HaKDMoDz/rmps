<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExtsList.ascx.cs" Inherits="exts_ascx_ExtsList" %>
<table border="0" cellpadding="0" cellspacing="0" id="TB_LIST">
    <tr>
        <td style="height: 10px">
        </td>
    </tr>
    <% 
        if (rmp.comn.user.UserInfo.Current(Session).UserRank >= cons.comn.user.UserInfo.LEVEL_06)
        {
    %>
    <tr>
        <td align="center">
            <table border="0" cellpadding="2" cellspacing="0" class="TB_LIST_ITEM">
                <tr>
                    <td align="center" class="TD_LIST_HEAD">
                        后缀管理
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<asp:HyperLink ID="hl_ExtsInfo" NavigateUrl="~/exts/exts0010.aspx" runat="server">后缀数据</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<asp:HyperLink ID="hl_CorpInfo" NavigateUrl="~/exts/exts0100.aspx" runat="server">公司信息</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<asp:HyperLink ID="hl_SoftInfo" NavigateUrl="~/exts/exts0200.aspx" runat="server">软件信息</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<asp:HyperLink ID="hl_FileInfo" NavigateUrl="~/exts/exts0300.aspx" runat="server">文件信息</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<asp:HyperLink ID="hl_DocsInfo" NavigateUrl="~/exts/exts0400.aspx" runat="server">文档信息</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<asp:HyperLink ID="hl_MimeInfo" NavigateUrl="~/exts/exts0500.aspx" runat="server">MIME类型</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<asp:HyperLink ID="hl_PlatForm" NavigateUrl="~/exts/exts0600.aspx" runat="server">应用平台</asp:HyperLink>
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
        <td style="height: 10px">
        </td>
    </tr>
    <% } %>
    <tr>
        <td align="center">
            <table border="0" cellpadding="2" cellspacing="0" class="TB_LIST_ITEM">
                <tr>
                    <td align="center" class="TD_LIST_HEAD">
                        Amon在线
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/exts/index.aspx">后缀解析</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool1301.aspx?view=1',500, 440)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/math/index.aspx">计算助理</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool1306.aspx',500, 340)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/edit/index.aspx" title="在线网页源代码编辑器">源码查看</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool1310.aspx',500, 480)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/date/index.aspx">中国农历</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool1304.aspx',500, 440)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask1303.aspx" title="查询字符在不同编码方案中的编码信息">编码查询</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool1303.aspx',500, 420)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask1305.aspx" title="计算文本的MD5、SHA等摘要信息">消息摘要</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool1305.aspx',500, 320)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask130C.aspx">ＩＰ查询</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool130C.aspx',500, 200)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask13A1.aspx">节目预告</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool13A1.aspx',500, 360)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask13A2.aspx">邮编查询</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool13A2.aspx',500, 340)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask13A3.aspx">天气预报</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool13A3.aspx',500, 320)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask1311.aspx" title="Javascript 正则表达式测试及运算工具！">Javascript正则表达式</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool1311.aspx',500, 420)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask1313.aspx" title="Javascript 代码加密器！">Javascript代码加密器</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool1313.aspx',500, 440)" />
                    </td>
                </tr>
                <tr>
                    <td class="TD_LIST_FOOT">
                        <a href="/iask/index.aspx">更多</a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td align="center">
            <table border="0" cellpadding="0" cellspacing="0" class="TB_LIST_ITEM">
                <tr>
                    <td align="center" class="TD_LIST_HEAD">
                        查询统计
                    </td>
                </tr>
                <tr>
                    <td style="width: 50%;" valign="top">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <%
                                ArrayList list = rmp.wrp.exts.Exts.searchHistory(Session);
                                rmp.bean.K1V1 kvItem;
                                for (int i = list.Count - 1; i >= 0; i -= 1)
                                {
                                    kvItem = (rmp.bean.K1V1)list[i];
                            %>
                            <tr>
                                <td align="left" class="TD_LIST_BODY">
                                    ·&nbsp;<a href="/exts/exts0001.aspx?exts=.<%= kvItem.V %>" title="最近查询时间：<%= kvItem.K %>">.<%= kvItem.V %></a>
                                </td>
                            </tr>
                            <%
                                }
                            %>
                        </table>
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
        <td style="height: 10px">
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
                <%
                    foreach (rmp.bean.K1V2 item in rmp.wrp.link.Link.ExtsLink)
                    {
                %>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="<%= item.K %>" title="<%= item.V2 %>" target="_blank"><%= item.V1 %></a>
                    </td>
                </tr>
                <%}%>
                <tr>
                    <td class="TD_LIST_FOOT">
                        <a href="/link/link1001.aspx?sid=sctvratvcgxtfyzb">更多</a>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="height: 10px">
        </td>
    </tr>
</table>

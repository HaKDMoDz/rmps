<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkList.ascx.cs" Inherits="link_ascx_LinkList" %>
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
                        Amon在线
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/exts/index.aspx">后缀解析</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/n_tool/n_tool1301.aspx?view=1',500, 440)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/math/index.aspx">计算助理</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/n_tool/n_tool1306.aspx',500, 340)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/edit/index.aspx" title="在线网页源代码编辑器">源码查看</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/n_tool/n_tool1310.aspx',500, 480)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/date/index.aspx">中国农历</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/n_tool/n_tool1304.aspx',500, 440)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask1303.aspx" title="查询字符在不同编码方案中的编码信息">编码查询</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/n_tool/n_tool1303.aspx',500, 420)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask1305.aspx" title="计算文本的MD5、SHA等摘要信息">消息摘要</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/n_tool/n_tool1305.aspx',500, 320)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask130C.aspx">ＩＰ查询</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/n_tool/n_tool130C.aspx',500, 200)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask13A1.aspx">节目预告</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/n_tool/n_tool13A1.aspx',500, 360)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask13A2.aspx">邮编查询</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/n_tool/n_tool13A2.aspx',500, 340)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask13A3.aspx">天气预报</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/n_tool/n_tool13A3.aspx',500, 320)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask1311.aspx" title="Javascript 正则表达式测试及运算工具！">Javascript正则表达式</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/n_tool/n_tool1311.aspx',500, 420)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask1313.aspx" title="Javascript 代码加密器！">Javascript代码加密器</a>&nbsp;&nbsp;<input type="image" src="/_images/n_tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/n_tool/n_tool1313.aspx',500, 440)" />
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
        <td style="height: 10px;">
        </td>
    </tr>
    <tr>
        <td align="center">
            <table border="0" cellpadding="2" cellspacing="0" class="TB_LIST_ITEM">
                <tr>
                    <td align="center" class="TD_LIST_HEAD">
                        链接分类
                    </td>
                </tr>
                <asp:Repeater ID="rp_TypeList" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="left" class="TD_LIST_BODY">
                                ·&nbsp;<a href="link0001.aspx?uri=<%=cons.wrp.link.LinkCons.LINK_USER_HASH%>&sid=<%#Eval(cons.io.db.comn.info.C2010000.C2010105)%>" title="<%#Eval(cons.io.db.comn.info.C2010000.C201010A)%>"><%#Eval(cons.io.db.comn.info.C2010000.C2010107)%></a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td align="right" class="TD_LIST_FOOT">
                        <a href="/link/link0001.aspx">更多</a>
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

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SrchList.ascx.cs" Inherits="srch_ascx_SrchList" %>
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
                        全能搜索
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/srch/srch0001.aspx">在线使用</a>
                    </td>
                </tr>
                <% 
                    if (rmp.comn.user.UserInfo.Current(Session).UserRank >= cons.comn.user.UserInfo.LEVEL_02)
                    { 
                %>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/srch/srch0101.aspx">定制搜索</a>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/srch/srch0102.aspx">风格配置</a>
                    </td>
                </tr>
                <%
                    }
                %>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/srch/srch0103.aspx">获取代码</a>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/srch/srch1001.aspx">使用说明</a>
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
                        Amon在线
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/exts/index.aspx">后缀解析</a>&nbsp;&nbsp;<input type="image" src="/_images/tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool1301.aspx?view=1',500, 440)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/math/index.aspx">计算助理</a>&nbsp;&nbsp;<input type="image" src="/_images/tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool1306.aspx',500, 340)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/edit/index.aspx" title="在线网页源代码编辑器">源码查看</a>&nbsp;&nbsp;<input type="image" src="/_images/tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool1310.aspx',500, 480)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/date/index.aspx">中国农历</a>&nbsp;&nbsp;<input type="image" src="/_images/tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool1304.aspx',500, 440)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask1303.aspx" title="查询字符在不同编码方案中的编码信息">编码查询</a>&nbsp;&nbsp;<input type="image" src="/_images/tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool1303.aspx',500, 420)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask1305.aspx" title="计算文本的MD5、SHA等摘要信息">消息摘要</a>&nbsp;&nbsp;<input type="image" src="/_images/tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool1305.aspx',500, 320)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask130C.aspx">ＩＰ查询</a>&nbsp;&nbsp;<input type="image" src="/_images/tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool130C.aspx',500, 200)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask13A1.aspx">节目预告</a>&nbsp;&nbsp;<input type="image" src="/_images/tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool13A1.aspx',500, 360)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask13A2.aspx">邮编查询</a>&nbsp;&nbsp;<input type="image" src="/_images/tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool13A2.aspx',500, 340)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask13A3.aspx">天气预报</a>&nbsp;&nbsp;<input type="image" src="/_images/tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool13A3.aspx',500, 320)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask1311.aspx" title="Javascript 正则表达式测试及运算工具！">Javascript正则表达式</a>&nbsp;&nbsp;<input type="image" src="/_images/tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool1311.aspx',500, 420)" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/iask/iask1313.aspx" title="Javascript 代码加密器！">Javascript代码加密器</a>&nbsp;&nbsp;<input type="image" src="/_images/tool.gif" title="点击以独立窗口启动" onclick="return openWnd('/tool/tool1313.aspx',500, 440)" />
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

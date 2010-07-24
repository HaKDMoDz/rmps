<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="exts_index" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellspacing="0" cellpadding="0" id="TB_DATA">
        <tr>
            <td align="left" style="height: 40px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table id="tb_Exts" width="460" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="3" align="center">
                            <asp:RadioButtonList ID="rb_ExtsCase" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                <asp:ListItem Text="大小敏感(H)" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="大写(U)" Value="1"></asp:ListItem>
                                <asp:ListItem Text="小写(L)" Value="2"></asp:ListItem>
                                <asp:ListItem Text="模糊查询(R)" Value="3"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%;">
                            <asp:Label ID="lb_ExtsName" runat="server" Text="后缀名称(X)"></asp:Label>
                        </td>
                        <td align="center" style="width: 60%;">
                            <asp:TextBox ID="tf_ExtsName" runat="server" Width="90%" AccessKey="X">.PDF</asp:TextBox>
                            <asp:FileUpload ID="tf_ExtsFile" runat="server" Style="display: none; width: 90%;" />
                        </td>
                        <td align="left" style="width: 20%;">
                            <asp:Button ID="bt_ExtsName" runat="server" Text="查询(Q)" AccessKey="Q" OnClientClick="return chkExts();" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3" style="height: 20px;">
                            <asp:CheckBox ID="ck_ExtsFile" runat="server" Text="文件查看(I)" AccessKey="I" ToolTip="查看指定文件的后缀信息" />
                            <asp:CheckBox ID="ck_ExtsAjax" runat="server" Text="启用Ajax(J)" AccessKey="J" ToolTip="启用Ajax可以获得更好的网络效果" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 60px;">
                当前后缀记录总量：<asp:Label ID="lb_AmonInfo" runat="server" CssClass="TEXT_NOTE1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 60px;" align="center">
                <a href="/exts/exts0001.html">使用Flex版</a>&nbsp;&nbsp;<a href="/down/Extparse_V3.3.1.0_2009-07-18.zip">使用.Net版</a>&nbsp;&nbsp;<a href="#" onclick="return myGears();">使用 Gears</a>
            </td>
        </tr>
        <tr>
            <td style="border-top: solid 1px #d5d5d5;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellpadding="0" cellspacing="0" width="460">
                    <tr>
                        <th align="center" style="width: 50%;">
                            使用帮助
                        </th>
                        <th align="center" style="width: 50%;">
                            最近更新
                        </th>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left">
                                        1、<a href="/inet/index.aspx" title="Amon网络收藏！">Amon网页精灵！</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        2、<a href="/exts/exts0001.asmx" title="后缀解析 WEB 服务！">后缀解析 WEB 服务！</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        3、<a href="/exts/exts1007.aspx" title="后缀解析定制搜索代码！">后缀解析定制搜索代码！</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        4、<a href="/exts/exts1005.aspx" title="浏览器内置搜索！">浏览器内置搜索！</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        5、<a href="/exts/exts1009.aspx" title="Microsoft Windows Internet Explorer 8 加速器！">Internet Explorer 8 加速器！</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        6、<a href="/exts/exts1001.aspx" title="什么是文件扩展名称？">什么是文件扩展名称？</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        7、<a href="/exts/exts1003.aspx" title="什么是MIME类型？">什么是MIME类型？</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        8、<a href="/exts/exts0605.aspx" title="Linux操作系统知多少？">Linux操作系统知多少？</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                <%
                                    ArrayList list = rmp.wrp.exts.Exts.getRecentUpdate();
                                    int size = list.Count / 3;
                                    int indx1 = 0;
                                    int indx2 = indx1 + size;
                                    int indx3 = indx2 + size;
                                    rmp.bean.K1V1 item1;
                                    rmp.bean.K1V1 item2;
                                    rmp.bean.K1V1 item3;
                                    while (indx1 < size)
                                    {
                                        item1 = (rmp.bean.K1V1)list[indx1++];
                                        item2 = (rmp.bean.K1V1)list[indx2++];
                                        item3 = (rmp.bean.K1V1)list[indx3++];
                                %>
                                <tr>
                                    <td align="left">
                                        <a href="/exts/exts0001.aspx?exts=<%= item1.V %>" title="最后更新时间：<%= item1.K %>">
                                            <%= item1.V.Length > 10 ? item1.V.Substring(0, 10) : item1.V%>
                                        </a>
                                    </td>
                                    <td align="left">
                                        <a href="/exts/exts0001.aspx?exts=<%= item2.V %>" title="最后更新时间：<%= item2.K %>">
                                            <%= item2.V.Length > 10 ? item2.V.Substring(0, 10) : item2.V%>
                                        </a>
                                    </td>
                                    <td align="left">
                                        <a href="/exts/exts0001.aspx?exts=<%= item3.V %>" title="最后更新时间：<%= item3.K %>">
                                            <%= item3.V.Length > 10 ? item3.V.Substring(0, 10) : item3.V%>
                                        </a>
                                    </td>
                                </tr>
                                <%
                                    }
                                %>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <script type="text/javascript" src="/_script/gears_init.js"></script>

</asp:Content>

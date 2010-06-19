<%@ Page Language="C#" MasterPageFile="~/comn/comn.master" AutoEventWireup="true" CodeFile="comn0503.aspx.cs" Inherits="comn_comn0503" Title="无标题页" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <asp:ScriptManager ID="sm_Script" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Update" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
                <tr id="tr_ErrMsg" runat="server">
                    <td align="center">
                        <asp:Label ID="lb_ErrMsg" CssClass="TEXT_NOTE1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table border="0" cellpadding="2" cellspacing="0" width="460" class="TB_DataList_TL">
                            <tr>
                                <th class="TD_DataHead_TL_L" style="height: 26px;">
                                    功能
                                </th>
                                <th class="TD_DataHead_TL_L" style="height: 26px;">
                                    说明
                                </th>
                                <th class="TD_DataHead_TL_L" style="height: 26px;">
                                    执行
                                </th>
                            </tr>
                            <tr>
                                <td align="center" class="TD_DataItem_TL_L" rowspan="3">
                                    网络导航
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    友情链接：重新读取名模块的友情链接数据
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <asp:LinkButton ID="bt_LinkGuid" runat="server" Text="更新" OnClick="bt_LinkGuid_Click" OnClientClick="return askUpdate();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="TD_DataItem_TL_L">
                                    门户网站：重新读取读取门户网站导航数据
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <asp:LinkButton ID="bt_LinkPort" runat="server" Text="更新" OnClick="bt_LinkPort_Click" OnClientClick="return askUpdate();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="TD_DataItem_TL_L">
                                    图标清理：<%=cons.EnvCons.DIR_DAT%>link/*
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <asp:LinkButton ID="bt_LinkIcon" runat="server" Text="清理" OnClick="bt_LinkIcon_Click" OnClientClick="return askClean();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TD_DataItem_TL_L" rowspan="2">
                                    网页精灵
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    代码维护：重新读取网页精灵Javascript代码
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <asp:LinkButton ID="bt_InetCode" runat="server" Text="读取" OnClick="bt_InetCode_Click" OnClientClick="return askMethod();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="TD_DataItem_TL_L">
                                    图标清理：<%=cons.EnvCons.DIR_DAT%>inet/*
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <asp:LinkButton ID="bt_InetIcon" runat="server" Text="清理" OnClick="bt_InetIcon_Click" OnClientClick="return askClean();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TD_DataItem_TL_L">
                                    网页五笔
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    代码维护：重新读取网页五笔Javascript代码
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <asp:LinkButton ID="bt_WimeCode" runat="server" Text="读取" OnClick="bt_WimeCode_Click" OnClientClick="return askMethod();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TD_DataItem_TL_L" rowspan="6">
                                    后缀解析
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    数据维护：最近更新后缀数据在首页的显示数量调整
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <asp:LinkButton ID="bt_ExtsSize" runat="server" Text="变更" OnClick="bt_ExtsSize_Click" OnClientClick="return askChange();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="TD_DataItem_TL_L">
                                    公司徽标清理：<%=cons.EnvCons.DIR_DAT%>corp/*
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <asp:LinkButton ID="bt_ExtsCorp" runat="server" Text="清理" OnClick="bt_ExtsCorp_Click" OnClientClick="return askClean();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="TD_DataItem_TL_L">
                                    软件图标清理：<%=cons.EnvCons.DIR_DAT%>soft/*<br />
                                    运行截图清理：<%=cons.EnvCons.DIR_DAT%>view/*
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <asp:LinkButton ID="bt_ExtsSoft" runat="server" Text="清理" OnClick="bt_ExtsSoft_Click" OnClientClick="return askClean();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="TD_DataItem_TL_L">
                                    文件图标清理：<%=cons.EnvCons.DIR_DAT%>file/*
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <asp:LinkButton ID="bt_ExtsFile" runat="server" Text="清理" OnClick="bt_ExtsFile_Click" OnClientClick="return askClean();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="TD_DataItem_TL_L">
                                    个性图标清理：<%=cons.EnvCons.DIR_DAT%>idio/*
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <asp:LinkButton ID="bt_UserIdio" runat="server" Text="清理" OnClick="bt_UserIdio_Click" OnClientClick="return askClean();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="TD_DataItem_TL_L">
                                    平台徽标清理：<%=cons.EnvCons.DIR_DAT%>plat/l_*<br />
                                    平台截图清理：<%=cons.EnvCons.DIR_DAT%>plat/r_*
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <asp:LinkButton ID="bt_ExtsPlat" runat="server" Text="清理" OnClick="bt_ExtsPlat_Click" OnClientClick="return askClean();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TD_DataItem_TL_L">
                                    图标管理
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    图片文件清除：~/icon/img/*<br />
                                    资源文件清除：~/icon/res/*<br />
                                    图标文件清除：~/icon/svg/*
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <asp:LinkButton ID="bt_Icon" runat="server" Text="清除" OnClick="bt_Icon_Click" OnClientClick="return askRemove();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TD_DataItem_TL_L">
                                    Amon软件
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    列表更新：Amon系列软件列表及版本信息更新
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <asp:LinkButton ID="bt_Soft" runat="server" Text="更新" OnClick="bt_Soft_Click" OnClientClick="return askUpdate();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TD_DataItem_TL_L" rowspan="2">
                                    Amon搜索
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    代码维护：重新读取Amon搜索Javascript代码
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <asp:LinkButton ID="bt_SrchCode" runat="server" Text="读取" OnClick="bt_SrchCode_Click" OnClientClick="return askMethod();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="TD_DataItem_TL_L">
                                    图片数据清理：<%=cons.EnvCons.DIR_DAT%>srch/
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <asp:LinkButton ID="bt_Srch" runat="server" Text="清理" OnClick="bt_SrchIcon_Click" OnClientClick="return askClean();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TD_DataItem_TL_L">
                                    Amon卡片
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    图片数据清理：<%=cons.EnvCons.DIR_DAT%>card/
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <asp:LinkButton ID="bt_Card" runat="server" Text="清理" OnClick="bt_Card_Click" OnClientClick="return askClean();" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="TD_DataItem_TL_L">
                                    数据备份
                                </td>
                                <td align="left" class="TD_DataItem_TL_L">
                                    图片数据增量备份
                                </td>
                                <td align="center" class="TD_DataItem_TL_L">
                                    <asp:LinkButton ID="bt_DataBack" runat="server" Text="备份" OnClick="bt_DataBack_Click" OnClientClick="return askBackup();" />
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hd_TempData" runat="server" Value="0" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

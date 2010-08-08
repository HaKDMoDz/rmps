<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0002.aspx.cs" Inherits="exts_exts0002" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <asp:ScriptManager ID="sm_Script" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Update" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
                <tr>
                    <td align="center">
                        <table id="tb_Exts" width="460" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:RadioButtonList ID="rb_IconMode" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        <asp:ListItem Text="公司(C)" Value="corp"></asp:ListItem>
                                        <asp:ListItem Text="软件(S)" Value="soft"></asp:ListItem>
                                        <asp:ListItem Text="文件(S)" Value="file"></asp:ListItem>
                                        <asp:ListItem Text="个性(I)" Value="idio"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%;">
                                    <asp:Label ID="lb_IconName" runat="server" Text="图标名称(N)"></asp:Label>
                                </td>
                                <td align="center" style="width: 60%;">
                                    <asp:TextBox ID="tf_IconName" runat="server" Width="90%" AccessKey="N"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 20%;">
                                    <asp:Button ID="bt_IconName" runat="server" Text="查询(Q)" AccessKey="Q" OnClick="bt_IconName_Click" OnClientClick="return chkIcon();" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="TD_LINE_B">
                                    &nbsp;
                                    <asp:HiddenField ID="hd_IconSize" runat="server" />
                                    <asp:HiddenField ID="hd_ViewMode" runat="server" />
                                    <asp:HiddenField ID="hd_ColCount" runat="server" />
                                    <asp:HiddenField ID="hd_RowCount" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        查看：
                        <asp:ImageButton ID="ib_ViewIcon" runat="server" OnClick="ib_ViewIcon_Click" ToolTip="以图标方式查看" />
                        <asp:ImageButton ID="ib_ViewList" runat="server" OnClick="ib_ViewList_Click" ToolTip="以列表方式查看" />
                    </td>
                </tr>
                <tr id="tr_IconList" runat="server">
                    <td align="center" id="td_IconList" runat="server">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:LinkButton ID="lb_PrevPage" runat="server" Text="上一页" OnClick="lb_PrevPage_Click"></asp:LinkButton>
                        <asp:HiddenField ID="hd_IconMode" runat="server" />
                        <asp:HiddenField ID="hd_IconName" runat="server" />
                        <asp:HiddenField ID="hd_PageIndx" runat="server" />
                        <asp:Label ID="lb_PageInfo" runat="server"></asp:Label>
                        <asp:LinkButton ID="lb_NextPage" runat="server" Text="下一页" OnClick="lb_NextPage_Click"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="dv_ViewIcon" title="Amon图标" style="display: none;">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width: 13px;" align="center" rowspan="2">
                    <div id="sv_SlidIcon" style="height: 260px;">
                    </div>
                </td>
                <td style="height: 260px;" align="center">
                    <img id="im_SlidIcon" src="" alt="" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <label id="lb_SlidIcon" style="border: 0; font-weight: bold;">
                    </label>
                    <input type="hidden" id="hd_SlidIcon" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

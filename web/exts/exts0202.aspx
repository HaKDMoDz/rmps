<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0202.aspx.cs" Inherits="exts_exts0202" %>

<%@ Register Src="~/App_Ascx/AmonIcon.ascx" TagName="AmonIcon" TagPrefix="as" %>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="3" cellspacing="0" class="TB_EXTSINFO">
                    <tr>
                        <td width="80" rowspan="2" align="center" class="TD_DataHead_TL_L">
                            <as:AmonIcon ID="ai_P3010204" runat="server" DstIconPath="soft" ToolTip="软件图标" Enabled="true" Viewable="true" CreateViewDiv="true" />
                        </td>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            中文名称
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P3010205" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            英文名称
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P3010206" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            公司信息
                        </th>
                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                            <asp:HyperLink ID="hl_P3010203" runat="server">点击查看</asp:HyperLink>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            电子邮件
                        </th>
                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                            <asp:HyperLink ID="hl_P3010207" runat="server"></asp:HyperLink>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            链接地址
                        </th>
                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                            <asp:HyperLink ID="hl_P3010208" runat="server" Target="_blank"></asp:HyperLink>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            兼容后缀
                        </th>
                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P3010209" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            运行截图
                        </th>
                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                            <asp:HyperLink ID="hl_P301020A" runat="server" Target="_blank">点击查看</asp:HyperLink>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            软件简介
                        </th>
                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P301020B" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            相关说明
                        </th>
                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P301020C" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

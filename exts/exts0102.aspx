<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0102.aspx.cs" Inherits="exts_exts0102" %>

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
                <table width="100%" border="0" cellpadding="3" cellspacing="0" class="TB_DataList_TL" id="CORPPROP">
                    <tr>
                        <td width="80" rowspan="2" align="center" class="TD_DataHead_TL_L">
                            <as:AmonIcon ID="ai_P3010104" runat="server" DstIconPath="corp" ToolTip="公司徽标" Enabled="true" Viewable="true" CreateViewDiv="true" />
                        </td>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            本语名称
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P3010105" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            英语名称
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P3010106" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            国别信息
                        </th>
                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                            <asp:HyperLink ID="hl_P3010103" runat="server">点击查看</asp:HyperLink>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            公司网址
                        </th>
                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                            <asp:HyperLink ID="hl_P3010107" runat="server" Target="_blank"></asp:HyperLink>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            公司简介
                        </th>
                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P3010108" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            相关说明
                        </th>
                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P3010109" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

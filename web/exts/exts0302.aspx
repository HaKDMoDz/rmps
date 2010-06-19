<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0302.aspx.cs" Inherits="exts_exts0302" %>

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
                <table width="100%" border="0" cellpadding="3" cellspacing="0" class="TB_DataList_TL" id="FILEPROP">
                    <tr>
                        <td width="80" rowspan="2" align="center" class="TD_DataHead_TL_L">
                            <as:AmonIcon ID="ai_P3010304" runat="server" DstIconPath="corp" ToolTip="文件图标" />
                        </td>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            数值签名
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P3010306" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            字符签名
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P3010305" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            软件信息
                        </th>
                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                            <asp:HyperLink ID="hl_P3010303" runat="server">点击查看</asp:HyperLink>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            偏移位置
                        </th>
                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P3010307" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            加密算法
                        </th>
                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P3010308" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            起始数据
                        </th>
                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P3010309" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            结束数据
                        </th>
                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P301030A" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            相关说明
                        </th>
                        <td colspan="2" align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P301030C" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

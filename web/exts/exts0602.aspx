<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0602.aspx.cs" Inherits="exts_exts0602" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="460" border="0" cellpadding="3" cellspacing="0" class="TB_EXTSINFO">
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            所属家族
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P301F202" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            平台名称
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P301F206" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            平台徽标
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Image ID="im_P301F207" runat="server" />&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            运行截图
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:HyperLink ID="hl_P301F208" runat="server" Target="_blank">点击查看</asp:HyperLink>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            平台首页
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:HyperLink ID="hl_P301F209" runat="server" Target="_blank"></asp:HyperLink>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            平台简介
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P301F20A" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <th width="80" height="30" class="TD_DataHead_TL_L">
                            相关说明
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:Label ID="lb_P301F20B" runat="server"></asp:Label>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

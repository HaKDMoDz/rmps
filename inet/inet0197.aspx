<%@ Page Language="C#" MasterPageFile="~/inet/inet.master" AutoEventWireup="true" CodeFile="inet0197.aspx.cs" Inherits="inet_inet0197" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table border="0" cellpadding="0" cellspacing="0" width="460" class="TB_DataList_TL">
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            联系方式：
                        </th>
                        <td>
                            <asp:HiddenField ID="hd_W2019102" runat="server" />
                            <asp:Image ID="im_W2019105" runat="server" Width="16" Height="16" />
                            <asp:Label ID="lb_W2019105" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            显示信息：
                        </th>
                        <td>
                            <asp:Label ID="lb_W2019106" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            快捷提示：
                        </th>
                        <td>
                            <asp:Label ID="lb_W2019107" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            通讯地址：
                        </th>
                        <td>
                            <asp:Label ID="lb_W2019108" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            备选地址：
                        </th>
                        <td>
                            <asp:Label ID="lb_W201910C" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right">
                <input type="button" value="修改(E)" accesskey="E" onclick="window.location.href = 'inet0198.aspx?sid='+$E('hd_W2019102').value" />
                <input type="button" value="返回(R)" accesskey="R" onclick="window.location.href = 'inet0102.aspx?sid=iNetHelper_90wmi'" />
            </td>
        </tr>
    </table>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/inet/inet.master" AutoEventWireup="true" CodeFile="inet0198.aspx.cs" Inherits="inet_inet0198" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <asp:Label ID="lb_ErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellpadding="3" cellspacing="0" width="460" class="TB_DataList_TL">
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            联系方式：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:Image ID="im_W2019105" runat="server" Width="16" Height="16" ImageUrl="~/inet/i/0.gif" />
                            <asp:DropDownList ID="cb_W2019105" runat="server">
                                <asp:ListItem Text="《请选择》" Value="0"></asp:ListItem>
                                <asp:ListItem Text="电子邮件" Value="mail"></asp:ListItem>
                                <asp:ListItem Text="个人首页" Value="home"></asp:ListItem>
                                <asp:ListItem Text="链接地址" Value="link"></asp:ListItem>
                                <asp:ListItem Text="移动飞信" Value="fetion"></asp:ListItem>
                                <asp:ListItem Text="网易泡泡" Value="popo"></asp:ListItem>
                                <asp:ListItem Text="阿里旺旺" Value="alww"></asp:ListItem>
                                <asp:ListItem Text="MSN" Value="msn"></asp:ListItem>
                                <asp:ListItem Text="QQ" Value="qq"></asp:ListItem>
                                <asp:ListItem Text="ICQ" Value="icq"></asp:ListItem>
                                <asp:ListItem Text="Yahoo" Value="yahoo"></asp:ListItem>
                                <asp:ListItem Text="Skype" Value="skype"></asp:ListItem>
                                <asp:ListItem Text="AIM" Value="aim"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            显示信息：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W2019106" runat="server" Width="80%" MaxLength="128"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            快捷提示：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W2019107" runat="server" Width="80%" MaxLength="256"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            联系地址：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W2019108" runat="server" Width="80%" MaxLength="1024"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            备选地址：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="ta_W201910C" runat="server" Width="80%" MaxLength="2048" Rows="5" TextMode="MultiLine"></asp:TextBox>
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
            <td align="right">
                <asp:HiddenField ID="hd_W2019102" runat="server" Value="0" />
                <asp:HiddenField ID="hd_IsUpdate" runat="server" Value="0" />
                <asp:Button ID="bt_SaveData" runat="server" Text="保存(S)" AccessKey="S" OnClick="bt_SaveData_Click" OnClientClick="return checkNull();" />
                <input type="button" value="返回(R)" accesskey="R" onclick="window.location.href = 'inet0102.aspx?sid=iNetHelper_90wmi'" />
            </td>
        </tr>
    </table>
</asp:Content>

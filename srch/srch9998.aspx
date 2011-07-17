<%@ Page Language="C#" MasterPageFile="~/srch/srch.master" AutoEventWireup="true" CodeFile="srch9998.aspx.cs" Inherits="srch_srch9998" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table border="0" cellpadding="0" cellspacing="0" width="460" class="TB_DataList_TL">
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            语言类型：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:DropDownList ID="cb_W2039103" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            从属网站：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:DropDownList ID="cb_W2039104" runat="server">
                            </asp:DropDownList><asp:CheckBox ID="ck_W2039104" runat="server" Text="使用相同徽标" Checked="true" />
                            <asp:HiddenField ID="hd_W2039104" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            所属类别：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:DropDownList ID="cb_W2039105" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            链接地址：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W203910A" runat="server" Width="80%"></asp:TextBox>
                            <asp:ImageButton ID="im_W203910A" runat="server" ImageUrl="~/_images/srch.png" ImageAlign="middle" ToolTip="自动查找网站LOGO" Width="16" Height="16" OnClick="im_W203910A_Click" OnClientClick="return checkLink();" />
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            显示图标：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:Image ID="im_W2039106" runat="server" ImageUrl="srch/0.gif" ImageAlign="middle" Width="16" Height="16" />
                            <asp:HiddenField ID="hd_W2039106" runat="server" Value="0" />
                            <asp:FileUpload ID="fu_W2039106" runat="server" />
                            <asp:Button ID="bt_W2039106" runat="server" Text="上传(L)" AccessKey="L" OnClick="bt_W2039106_Click" />
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            显示名称：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W2039107" runat="server" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            功能名称：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W2039108" runat="server" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            快捷提示：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W2039109" runat="server" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            转换方案：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:DropDownList ID="cb_W203910B" runat="server">
                                <asp:ListItem Value="">（无）</asp:ListItem>
                                <asp:ListItem Value="escape">escape</asp:ListItem>
                                <asp:ListItem Value="encodeURI">encodeURI</asp:ListItem>
                                <asp:ListItem Value="encodeURIComponent">encodeURIComponent</asp:ListItem>
                                <asp:ListItem Value="decodeGB2312">decodeGB2312</asp:ListItem>
                                <asp:ListItem Value="decodeUTF-8">decodeUTF-8</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            窗口模式：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W203910C" runat="server" Width="80%" Text="window.open({0},{1});"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            附注信息：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="ta_W203910D" runat="server" Rows="5" TextMode="MultiLine" Width="80%"></asp:TextBox>
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
                <asp:HiddenField ID="hd_W2039102" runat="server" Value="0" />
                <asp:HiddenField ID="hd_IsUpdate" runat="server" Value="0" />
                <asp:Button ID="bt_SaveData" runat="server" Text="保存(S)" AccessKey="S" OnClick="bt_SaveData_Click" OnClientClick="return checkNull();" />
                <input type="button" value="返回(R)" accesskey="R" onclick="window.location.href='srch0101.aspx'" />
            </td>
        </tr>
    </table>
</asp:Content>

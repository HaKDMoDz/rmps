<%@ Page Language="C#" MasterPageFile="~/inet/inet.master" AutoEventWireup="true" CodeFile="inet9998.aspx.cs" Inherits="inet_inet9998" ValidateRequest="false" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <asp:Label ID="lb_ErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellpadding="0" cellspacing="0" width="460" class="TB_DataList_TL">
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            语言类型：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:DropDownList ID="cb_W2019103" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            所属类别：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:DropDownList ID="cb_W2019104" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            显示图标：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:Image ID="im_W2019105" runat="server" ImageUrl="inet/0.gif" ImageAlign="middle" Width="16" Height="16" />
                            <asp:HiddenField ID="hd_W2019105" runat="server" Value="0" />
                            <asp:FileUpload ID="fu_W2019105" runat="server" />
                            <asp:Button ID="bt_W2019105" runat="server" Text="上传(L)" AccessKey="L" OnClick="bt_W2019105_Click" />
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            显示文本：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W2019106" runat="server" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            快捷提示：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W2019107" runat="server" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            链接地址：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W2019108" runat="server" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            转换方案：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:DropDownList ID="cb_W2019109" runat="server">
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
                            窗口大小：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            宽<asp:TextBox ID="tf_W201910A" runat="server" Columns="4" ToolTip="宽度" MaxLength="4" Style="text-align: center">480</asp:TextBox>
                            *
                            <asp:TextBox ID="tf_W201910B" runat="server" Columns="4" ToolTip="高度" MaxLength="4" Style="text-align: center">560</asp:TextBox>高
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            附注信息：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="ta_W201910C" runat="server" Rows="5" TextMode="MultiLine" Width="80%"></asp:TextBox>
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
                <asp:Button ID="bt_SaveData" runat="server" Text="保存(S)" AccessKey="S" OnClick="bt_SaveData_Click" />
                <input type="button" value="返回(R)" accesskey="R" onclick="window.location.href = 'inet0102.aspx?sid='+$E('cb_W2019104').value" />
            </td>
        </tr>
    </table>
</asp:Content>

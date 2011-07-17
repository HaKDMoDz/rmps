<%@ Page Language="C#" MasterPageFile="~/tool/tool.master" AutoEventWireup="true" CodeFile="tool1305.aspx.cs" Inherits="tool_tool1305" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="2" cellspacing="0" id="TB_DATA" class="TD_TOOL">
        <tr>
            <th align="center" style="width: 100px;" class="TD_DataHead_TL_L">
                明文数据
            </th>
            <td align="left" style="width: 370px;" class="TD_DataItem_TL_L">
                <asp:TextBox ID="ta_SrcDigest" runat="server" Rows="6" TextMode="MultiLine" Width="350" Wrap="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th align="center" style="width: 100px;" class="TD_DataHead_TL_L">
                加密算法
            </th>
            <td align="left" style="width: 370px;" class="TD_DataItem_TL_L">
                <asp:DropDownList ID="cb_TpDigest" runat="server">
                    <asp:ListItem Value="md5">MD5</asp:ListItem>
                    <asp:ListItem Value="sha1">SHA-1</asp:ListItem>
                    <asp:ListItem Value="sha256">SHA-256</asp:ListItem>
                    <asp:ListItem Value="sha384">SHA-384</asp:ListItem>
                    <asp:ListItem Value="sha512">SHA-512</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="bt_MsgDigest" runat="server" AccessKey="M" OnClick="bt_MsgDigest_Click" Text="计算(M)" />
            </td>
        </tr>
        <tr>
            <th align="center" style="width: 100px;" class="TD_DataHead_TL_L">
                加密结果
            </th>
            <td align="left" style="width: 370px;" class="TD_DataItem_TL_L">
                <asp:TextBox ID="tf_DstDigest" runat="server" Columns="50" Rows="3" TextMode="MultiLine" Width="350" Wrap="true"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>

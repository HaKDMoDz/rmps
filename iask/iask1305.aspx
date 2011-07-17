<%@ Page Language="C#" MasterPageFile="~/iask/iask.master" AutoEventWireup="true" CodeFile="iask1305.aspx.cs" Inherits="iask_iask1305" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="90%">
                    <tr>
                        <td align="left">
                            明文数据
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:TextBox ID="ta_SrcDigest" runat="server" Rows="10" TextMode="MultiLine" Width="420px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            加密算法
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
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
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            加密结果
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:TextBox ID="tf_DstDigest" runat="server" Columns="50" Rows="3" TextMode="MultiLine" Width="420px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

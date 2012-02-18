<%@ Page Title="" Language="C#" MasterPageFile="~/Amon.Master" AutoEventWireup="true" CodeBehind="SignWs.aspx.cs" Inherits="Me.Amon.User.SignWs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AmonHead" runat="server">
</asp:Content>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr id="TrErrMsg" runat="server" style="display: none;">
            <td align="center" style="height: 30px;">
                <asp:Label ID="LbErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>
            </td>
        </tr>
        <tr id="TrRegData1" runat="server">
            <td align="center">
                <table border="0" cellpadding="4" cellspacing="0" width="300" class="TB_DataList_TL">
                    <tr>
                        <th class="TD_DataHead_TL_L">
                            登录口令：
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:TextBox ID="TbPass1" runat="server" TextMode="Password" Style="width: 160px;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L">
                            口令确认：
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:TextBox ID="TbPass2" runat="server" TextMode="Password" Style="width: 160px;"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="TrRegData2" runat="server">
            <td align="center">
                <table border="0" cellpadding="4" cellspacing="0" width="300">
                    <tr>
                        <td align="right">
                            <asp:Button ID="BtSignWs" runat="server" Text="注册(R)" AccessKey="R" OnClick="BtSignWs_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="TrRegInfo" runat="server">
            <td align="center">
                <table border="0" cellpadding="5" cellspacing="0" width="480" class="TB_DataList_TL">
                    <tr>
                        <th align="left" class="TD_DataHead_TL_L">
                            恭喜：用户注册成功！
                        </th>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataItem_TL_L">
                            请牢记下面的信息数据，并在客户端输入。
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TD_DataHead_TL_L">
                            <asp:TextBox ID="TBData" runat="server" ReadOnly="True" TextMode="MultiLine" Width="98%" Rows="13"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

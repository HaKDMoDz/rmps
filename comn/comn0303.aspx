<%@ Page Language="C#" MasterPageFile="~/comn/comn.master" AutoEventWireup="true" CodeFile="comn0303.aspx.cs" Inherits="comn_comn0303" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="300" border="0" cellpadding="3" cellspacing="0" class="TB_DataList_TL">
                    <tr>
                        <th align="center" class="TD_DataHead_TL_L">
                            登录用户：
                        </th>
                        <td align="left" class="TD_DataItem_TL_L" style="height: 18px;">
                            <asp:Label ID="lb_UserName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="center" class="TD_DataHead_TL_L">
                            用户权限：
                        </th>
                        <td align="left" class="TD_DataItem_TL_L" style="height: 18px;">
                            <asp:DropDownList ID="cb_UserRank" runat="server">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hd_UserRank" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <th align="center" class="TD_DataHead_TL_L">
                            用户口令：
                        </th>
                        <td align="left" class="TD_DataItem_TL_L" style="height: 18px;">
                            <asp:TextBox ID="tf_UserPwds" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="ib_UserPwds" runat="server" ImageUrl="~/_images/keys.png" ToolTip="自动生成密码" OnClick="ib_UserPwds_Click" Width="16" Height="16" ImageAlign="middle" />
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
                <asp:Button ID="bt_SaveData" runat="server" Text="修改(U)" AccessKey="U" OnClick="bt_SaveData_Click" OnClientClick="return checkNull();" />
                <asp:HiddenField ID="hd_UserHash" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

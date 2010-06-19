<%@ Page Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="user0103.aspx.cs" Inherits="user_user0103" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr id="tr_ErrMsg" runat="server">
            <td align="center">
                <asp:Label ID="lb_ErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>
            </td>
        </tr>
        <tr id="tr_RegData1" runat="server">
            <td align="center">
                <table border="0" cellpadding="4" cellspacing="0" width="300" class="TB_DataList_TL">
                    <tr>
                        <th class="TD_DataHead_TL_L">
                            现有口令：
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:TextBox ID="pf_OldPwds" runat="server" Style="width: 160px;" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L">
                            新登录口令：
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:TextBox ID="pf_NewPwds" runat="server" Style="width: 160px;" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L">
                            新口令确认：
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:TextBox ID="pf_FrmPwds" runat="server" Style="width: 160px;" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="tr_RegData2" runat="server">
            <td align="center">
                <table border="0" cellpadding="4" cellspacing="0" width="300">
                    <tr>
                        <td align="right">
                            <asp:Button ID="bt_Change" runat="server" Text="修改(R)" AccessKey="R" OnClick="bt_Change_Click" OnClientClick="return checkNull();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="tr_RegInfo" runat="server" visible="false">
            <td align="center">
                <table border="0" cellpadding="5" cellspacing="0" width="300" class="TB_DataList_TL">
                    <tr>
                        <th align="left" class="TD_DataHead_TL_L">
                            恭喜：口令修改成功！
                        </th>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

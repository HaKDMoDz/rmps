<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignPk.aspx.cs" Inherits="Me.Amon.User.SignPk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AmonHead" runat="server">
</asp:Content>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <div style="background: url(../_img/wrap.png) no-repeat; width: 436px; height: 782px; top: 0px; left: 50%; margin-left: -218px; padding-top: 50px; position: absolute;">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr id="TrErrMsg" runat="server">
                <td align="center">
                    <asp:Label ID="LbErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>
                </td>
            </tr>
            <tr id="tr_RegData1" runat="server">
                <td align="center">
                    <table border="0" cellpadding="4" cellspacing="0" width="300" class="TB_DataList_TL">
                        <tr>
                            <th>
                                现有口令：
                            </th>
                            <td align="left">
                                <asp:TextBox ID="TbOldPass" runat="server" CssClass="input corner" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                新登录口令：
                            </th>
                            <td align="left">
                                <asp:TextBox ID="TbNewPass" runat="server" CssClass="input corner" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                新口令确认：
                            </th>
                            <td align="left">
                                <asp:TextBox ID="TbRepPass" runat="server" CssClass="input corner" TextMode="Password"></asp:TextBox>
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
                                <asp:Button ID="BtSignPk" runat="server" Text="修改(R)" AccessKey="R" OnClick="BtSignPk_Click" OnClientClick="return checkNull();" CssClass="button submit" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="tr_RegInfo" runat="server" visible="false">
                <td align="center">
                    <table border="0" cellpadding="5" cellspacing="0" width="300" class="TB_DataList_TL">
                        <tr>
                            <th align="left">
                                恭喜：口令修改成功！
                            </th>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

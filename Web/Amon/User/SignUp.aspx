<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Me.Amon.User.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AmonHead" runat="server">
</asp:Content>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr id="TrErrMsg" runat="server" style="display: none;">
            <td align="center" style="height: 30px;">
                <asp:Label ID="LbErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>
            </td>
        </tr>
        <tr id="tr_RegData1" runat="server">
            <td align="center">
                <table border="0" cellpadding="4" cellspacing="0" width="300" class="TB_DataList_TL">
                    <tr>
                        <th class="TD_DataHead_TL_L">
                            登录用户：
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:TextBox ID="TbName" runat="server" Style="width: 160px;"></asp:TextBox>
                        </td>
                    </tr>
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
                    <tr>
                        <th class="TD_DataHead_TL_L">
                            电子邮件：
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:TextBox ID="TbMail" runat="server" Style="width: 160px;"></asp:TextBox>
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
                            <asp:Button ID="BtSignUp" runat="server" Text="注册(R)" AccessKey="R" OnClick="BtSignUp_Click" />
                            <a href="SignIn.aspx">取消</a>
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
                            恭喜：用户注册成功！
                        </th>
                    </tr>
                    <tr>
                        <td align="left" class="TD_DataHead_TL_L">
                            &nbsp;&nbsp;&nbsp;&nbsp;如果您的浏览器在
                            <label id="dv_Redirect" style="color: #FF0000;">
                                5</label>
                            秒钟后没有自动跳转到登录页面，请手动点击下面链接：<br />
                            <script type="text/javascript">
                                var time = 5;
                                setInterval("reDirect()", 1000);
                                function reDirect() {
                                    time -= 1;
                                    if (time > 0) {
                                        document.getElementById('dv_Redirect').innerHTML = time.toString();
                                    }
                                    else {
                                        window.location.href = "/User/Index.aspx";
                                    }
                                }
                            </script>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="TD_DataHead_TL_L">
                            <a href="Index.aspx">用户登录&gt;&gt;&gt;</a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

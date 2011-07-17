<%@ Page Language="C#" MasterPageFile="~/user/user.master" AutoEventWireup="true" CodeFile="user0001.aspx.cs" Inherits="user_user0001" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table border="0" cellpadding="3" cellspacing="0" width="460">
                    <tr>
                        <td align="left">
                            您好，<asp:Label ID="lb_UserName" runat="server"></asp:Label>：
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            账户信息
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table border="0" cellpadding="3" cellspacing="1" width="300" class="TB_DataList_TL">
                                <tr>
                                    <td align="right" style="width: 120px;" class="TD_DataHead_TL_L">
                                        用户代码：
                                    </td>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <asp:Label ID="lb_UserCode" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 120px;" class="TD_DataHead_TL_L">
                                        我的角色：
                                    </td>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <asp:Label ID="lb_UserRank" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 120px;" class="TD_DataHead_TL_L">
                                        登录口令：
                                    </td>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <a href="user0103.aspx">修改</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 120px;" class="TD_DataHead_TL_L">
                                        电子邮件：
                                    </td>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <asp:Label ID="lb_UserMail" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 120px;" class="TD_DataHead_TL_L">
                                        个人资料：
                                    </td>
                                    <td align="left" class="TD_DataItem_TL_L">
                                        <a href="user0002.aspx">修改</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            关联账户
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table border="0" cellpadding="3" cellspacing="1" width="300" class="TB_DataList_TL">
                                <asp:Repeater ID="rp_Accounts" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td align="right" style="width: 120px;" class="TD_DataHead_TL_L">
                                                <%# Eval(cons.io.db.comn.info.C2010000.C2010107)%>
                                            </td>
                                            <td align="left" class="TD_DataItem_TL_L">
                                                <%# Eval(cons.io.db.comn.user.UserCons.C3010506)%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <a href="user0104.aspx">管理账户</a>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            我的服务
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

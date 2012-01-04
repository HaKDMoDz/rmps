<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserList.ascx.cs" Inherits="user_ascx_UserList" %>
<table border="0" cellpadding="0" cellspacing="0" id="TB_LIST">
    <tr>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td align="center">
            <table border="0" cellpadding="2" cellspacing="0" class="TB_LIST_ITEM">
                <tr>
                    <td align="center" class="TD_LIST_HEAD">
                        用户管理
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/user/user0101.aspx">用户登录</a>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/user/user0102.aspx">用户注册</a>
                    </td>
                </tr>
                <% if (rmp.comn.user.UserInfo.Current(Session).UserRank > 0){ %>
                <tr>
                    <td align="left" class="TD_LIST_BODY">
                        ·&nbsp;<a href="/user/user0103.aspx">修改口令</a>
                    </td>
                </tr>
                <%}%>
                <tr>
                    <td align="right" class="TD_LIST_FOOT">
                        更多
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="height: 10px;">
        </td>
    </tr>
</table>

<%@ Page Language="C#" MasterPageFile="~/inet/inet.master" AutoEventWireup="true" CodeFile="inet0101.aspx.cs" Inherits="inet_inet0101" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <div class="DV_TEXT1">
                    【使用说明】<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;1、此页面仅供注册用户进行个性化配置，请先确认您是否已经登录；<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;2、选择左部《所有数据》中您需要显示的数据，并添加到右部《显示数据》中去；<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;3、操作完成后点击《保存(S)》按钮，此时您可以通过此页面右上角《Amonsoft.net》按钮查看您的设定结果。<br />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 1px;" class="TD_LINE">
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellpadding="0" cellspacing="0" width="460">
                    <tr>
                        <th style="height: 30px; width: 200px;">
                            所有数据
                        </th>
                        <th style="height: 30px; width: 60px;">
                            &nbsp;
                        </th>
                        <th style="height: 30px; width: 200px;">
                            显示数据
                        </th>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:ListBox ID="lb_All" runat="server" Height="200px" Width="180px"></asp:ListBox>
                        </td>
                        <td align="center">
                            <asp:Button ID="bt_AddOne" runat="server" Text=">" Width="40px" OnClick="bt_AddOne_Click" ToolTip="添加选择项" OnClientClick="return addOne();" />
                            <br />
                            <asp:Button ID="bt_DelOne" runat="server" Text="<" Width="40px" OnClick="bt_DelOne_Click" ToolTip="移除选择项" OnClientClick="return delOne();" />
                        </td>
                        <td align="left">
                            <asp:ListBox ID="lb_Fav" runat="server" Height="200px" Width="180px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <%
                                if (isRoot)
                                {
                            %>
                            <a id="hl_RootInfo" href="#" onclick="return rootInfo();">详细</a>&nbsp;<a id="hl_RootEdit" href="#" onclick="return rootEdit();">编辑</a>&nbsp;<a id="hl_RootDrop" href="#" onclick="rootDrop();">删除</a>
                            <%
                                }
                            %>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="center">
                            <%
                                if (isUser)
                                {
                            %>
                            <asp:LinkButton ID="lb_MoveUp" runat="server" OnClick="lb_MoveUp_Click" OnClientClick="return userSort();">上移</asp:LinkButton>
                            <asp:LinkButton ID="lb_MoveDn" runat="server" OnClick="lb_MoveDn_Click" OnClientClick="return userSort();">下移</asp:LinkButton>
                            <%
                                }
                            %>
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
            <td style="height: 1px;" class="TD_LINE">
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:HiddenField ID="hd_Size" runat="server" Value="4" />
                <% if (isRoot) { %>
                    <input type="button" id="hl_RootApnd" value="新增(A)" accesskey="A" onclick="window.location.href='inet9997.aspx'" />
                <% } %>
                <asp:Button ID="bt_Save" runat="server" Text="保存(S)" AccessKey="S" OnClick="bt_Save_Click" />
                <input type="button" value="下一步(N)" accesskey="N" onclick="window.location.href='inet0102.aspx'" />
            </td>
        </tr>
    </table>
</asp:Content>

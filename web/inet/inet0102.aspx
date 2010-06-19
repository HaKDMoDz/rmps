<%@ Page Language="C#" MasterPageFile="~/inet/inet.master" AutoEventWireup="true" CodeFile="inet0102.aspx.cs" Inherits="inet_inet0102" %>

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
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="460">
                    <tr>
                        <td align="right" style="width:20%;">
                            类别列表
                        </td>
                        <td align="center">
                            <asp:DropDownList ID="cb_W2010203" runat="server" Width="80%">
                            </asp:DropDownList>
                        </td>
                        <td align="left" style="width:30%;">
                            <asp:Button ID="bt_ListData" runat="server" Text="查询(Q)" OnClick="bt_ListData_Click" AccessKey="Q" OnClientClick="return listData();" />
                            <% if (isRoot) { %>&nbsp;<a id="hl_RootApnd" href="#" onclick="window.location.href='inet9998.aspx'">新增</a><% } %>
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
                            <asp:ListBox ID="lb_All" runat="server" Height="300px" Width="180px"></asp:ListBox>
                        </td>
                        <td align="center">
                            <asp:Button ID="bt_AddAll" runat="server" Text=">>" Width="40px" OnClick="bt_AddAll_Click" ToolTip="添加所有项" />
                            <br />
                            <asp:Button ID="bt_AddOne" runat="server" Text=">" Width="40px" OnClick="bt_AddOne_Click" ToolTip="添加选择项" OnClientClick="return addOne();" />
                            <br />
                            <asp:Button ID="bt_DelOne" runat="server" Text="<" Width="40px" OnClick="bt_DelOne_Click" ToolTip="移除选择项" OnClientClick="return delOne();" />
                            <br />
                            <asp:Button ID="bt_DelAll" runat="server" Text="<<" Width="40px" OnClick="bt_DelAll_Click" ToolTip="移除所有项" />
                        </td>
                        <td align="left">
                            <div class="DV_TEXT2">
                                <asp:ListBox ID="lb_Fav" runat="server" Height="300px" Width="180px"></asp:ListBox>
                            </div>
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
                            <%if(isRoot){%>
                            <script type="text/javascript">
                                function rootInfo()
                                {
                                    var sid = $E('lb_All').value;
                                    if(sid==null || sid=='')
                                    {
                                        alert('请选择您要查看的数据信息！');
                                        $E('lb_All').focus();
                                        return false;
                                    }
                                    $W().location.href=($E('cb_W2010203').value=='iNetHelper_90wmi')?('inet0197.aspx?sid='+sid):('inet9997.aspx?sid='+sid);
                                }
                                function rootEdit()
                                {
                                    var sid = $E('lb_All').value;
                                    if(sid==null || sid=='')
                                    {
                                        alert('请选择您要编辑的数据信息！');
                                        $E('lb_All').focus();
                                        return false;
                                    }
                                    $W().location.href=($E('cb_W2010203').value=='iNetHelper_90wmi')?('inet0198.aspx?sid='+sid):('inet9998.aspx?sid='+sid);
                                }
                                function rootDrop()
                                {
                                    var sid = $E('lb_All').value;
                                    if(sid==null || sid=='')
                                    {
                                        alert('请选择您要编辑的数据信息！');
                                        $E('lb_All').focus();
                                        return false;
                                    }
                                    $W().location.href=($E('cb_W2010203').value=='iNetHelper_90wmi')?('inet0199.aspx?sid='+sid):('inet9999.aspx?sid='+sid+'&sth='+$E('cb_W2010203').value);
                                }
                            </script>
                            <a id="hl_RootInfo" href="#" onclick="return rootInfo();">详细</a>&nbsp;<a id="hl_RootEdit" href="#" onclick="return rootEdit();">编辑</a>&nbsp;<a id="hl_RootDrop" href="#" onclick="return rootDrop();">删除</a>
                            <%}else if(isUser){%>
                            <div id="dv_Info" style="display:none;">
                                <a id="hl_UserInfo" href="#" onclick="return userInfo();">详细</a>&nbsp;<a id="hl_UserEdit" href="#" onclick="return userEdit();">编辑</a>&nbsp;<a id="hl_UserDrop" href="#" onclick="return userDrop();">删除</a>
                            </div>
                            <%}%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="center">
                            <%
                                if (isUser)
                                {
                            %>
                            <asp:LinkButton ID="hl_MoveUp" runat="server" OnClick="hl_MoveUp_Click" OnClientClick="return userSort();">上移</asp:LinkButton>
                            <asp:LinkButton ID="hl_MoveDn" runat="server" OnClick="hl_MoveDn_Click" OnClientClick="return userSort();">下移</asp:LinkButton>
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
                <input type="button" id="bt_Apnd" value="添加(A)" accesskey="A" onclick="window.location.href='inet0198.aspx'" style="display:none" />
                <asp:Button ID="bt_Save" runat="server" Text="保存(S)" AccessKey="S" OnClick="bt_Save_Click" Visible="false" />
                <input type="button" value="下一步(N)" accesskey="N" onclick="window.location.href='inet0105.aspx'" />
            </td>
        </tr>
    </table>
</asp:Content>

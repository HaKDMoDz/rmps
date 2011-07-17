<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0093.aspx.cs" Inherits="exts_exts0093" %>

<%@ Register Src="~/App_Ascx/AmonAuth.ascx" TagName="AmonAuth" TagPrefix="as" %>
<%@ Register Src="ascx/PlatForm.ascx" TagName="PlatForm" TagPrefix="as" %>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <asp:ScriptManager ID="sm_Script" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Update" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
                <tr id="tr_StepGuid" runat="server" style="height: 20px;">
                    <td align="left">
                        【可选第三步】输入备选软件：
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lb_ErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <div class="DV_TEXT1">
                            &nbsp;&nbsp;&nbsp;&nbsp;您可以添加或删除对应的备选软件信息，并通过鼠标拖动的方式对备选软件信息进行排序，请务必在修改后点击<span class="TEXT_NOTE1">完成</span>按钮以保存您的操作！
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table width="460" border="0" cellpadding="2" cellspacing="0" class="TB_DataList_TL" id="ASOCPROP">
                            <tr>
                                <th style="width: 80px;" align="center" class="TD_DataHead_TL_L">
                                    备选软件
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:HiddenField ID="hd_P3010701" runat="server" />
                                    <asp:HiddenField ID="hd_P3010703" runat="server" />
                                    <asp:HiddenField ID="hd_P3010704" runat="server" />
                                    <div style="width: 320px; height: 300px; overflow: scroll;">
                                        <ul id="ul_P3010704" style="list-style-type: none; margin: 0; padding: 0; width: 100%;">
                                            <asp:Repeater ID="rp_P3010704" runat="server">
                                                <ItemTemplate>
                                                    <li id="<%#Eval(cons.io.db.prp.PrpCons.P3010704)%>" class="ui-state-default">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td align="left">
                                                                    <%# Eval(cons.io.db.prp.PrpCons.P3010205)%>
                                                                </td>
                                                                <td style="width: 20px;" align="center">
                                                                    <asp:ImageButton ID="ib_Delete" runat="server" ImageUrl="~/_images/m_drop.png" OnClick="ib_Delete_Click" OnClientClick="return remove();" Width="15" Height="15" CommandArgument='<%#Eval(cons.io.db.prp.PrpCons.P3010704)%>' ToolTip="删除" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" align="right">
                                                                    <%#Eval(cons.io.db.prp.PrpCons.P3010705)%>&nbsp;<%#GetPlatform(Eval(cons.io.db.prp.PrpCons.P3010702))%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" align="right">
                                                                    <%#rmp.wrp.exts.Exts.ShowDataStatus(Eval(cons.io.db.comn.user.UserCons.C3010407), Eval(cons.io.db.prp.PrpCons.P301070A), Eval(cons.io.db.prp.PrpCons.P3010709))%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px;" align="center" class="TD_DataHead_TL_L">
                                    查找选项
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:RadioButton ID="rb_Search" runat="server" AccessKey="S" Text="快捷搜索(S)" GroupName="rg_Option" Checked="true" AutoPostBack="True" OnCheckedChanged="rb_Search_CheckedChanged" />
                                    <asp:RadioButton ID="rb_Manual" runat="server" Text="手工查找(M)" AccessKey="M" GroupName="rg_Option" AutoPostBack="True" OnCheckedChanged="rb_Manual_CheckedChanged" />
                                </td>
                            </tr>
                            <tr id="tr_FindWays0" runat="server">
                                <th style="width: 80px;" align="center" class="TD_DataHead_TL_L">
                                    软件名称
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="tf_P3010704" runat="server" Columns="30"></asp:TextBox><asp:Button ID="bt_P3010704" runat="server" Text="查找(Q)" AccessKey="Q" OnClick="bt_P3010704_Click" />
                                </td>
                            </tr>
                            <tr id="tr_FindWays1" runat="server">
                                <th style="width: 80px;" align="center" class="TD_DataHead_TL_L">
                                    国家信息
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:DropDownList ID="cb_C1110100" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_C1110100_SelectedIndexChanged" Style="max-width: 370px;">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr id="tr_FindWays2" runat="server">
                                <th style="width: 80px;" align="center" class="TD_DataHead_TL_L">
                                    公司信息
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:DropDownList ID="cb_P3010100" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_P3010100_SelectedIndexChanged" Style="max-width: 370px;">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px;" align="center" class="TD_DataHead_TL_L">
                                    软件信息
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:DropDownList ID="cb_P3010704" runat="server" Style="max-width: 370px;">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px;" align="center" class="TD_DataHead_TL_L">
                                    读写权限
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:CheckBox ID="ck_R" runat="server" AccessKey="R" Checked="True" Text="读取(R)" />
                                    <asp:CheckBox ID="ck_W" runat="server" AccessKey="W" Text="写入(W)" />
                                    <asp:CheckBox ID="ck_X" runat="server" AccessKey="X" Text="执行(X)" />
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px;" align="center" class="TD_DataHead_TL_L">
                                    运行平台
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <as:PlatForm ID="pf_PlatForm" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px;" align="center" class="TD_DataHead_TL_L">
                                    附注信息
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    &nbsp;<asp:TextBox ID="ta_P3010706" runat="server" Rows="4" TextMode="MultiLine" Width="260"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px;" align="center" class="TD_DataHead_TL_L">
                                    身份校验
                                </th>
                                <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                    <as:AmonAuth ID="aa_AmonAuth" runat="server" />
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
                        <asp:Button ID="bt_Insert" runat="server" Text="添加(S)" AccessKey="S" OnClick="bt_Insert_Click" OnClientClick="return checkNull();" />
                        <asp:Button ID="bt_LastStep" runat="server" Text="上一步(P)" AccessKey="P" />
                        <asp:Button ID="bt_NextStep" runat="server" Text="下一步(N)" AccessKey="N" OnClick="bt_NextStep_Click" />
                        <asp:Button ID="bt_SaveData" runat="server" Text="完成(O)" AccessKey="O" OnClick="bt_SaveData_Click" OnClientClick="return saveData();" />
                        <asp:HiddenField ID="hd_NextStep" runat="server" />
                        <asp:HiddenField ID="hd_IsUpdate" runat="server" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

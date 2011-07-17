<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0094.aspx.cs" Inherits="exts_exts0094" %>

<%@ Register Src="~/App_Ascx/AmonAuth.ascx" TagName="AmonAuth" TagPrefix="as" %>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr id="tr_StepGuid" runat="server" style="height: 20px;">
            <td align="left">
                【可选第四步】输入运行平台：
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
                    &nbsp;&nbsp;&nbsp;&nbsp;您可以添加或删除对应的操作平台信息，并通过鼠标拖动的方式对操作平台信息进行排序，请务必在修改后点击<span class="TEXT_NOTE1">完成</span>按钮以保存您的操作！
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
                            操作平台
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:HiddenField ID="hd_P3010801" runat="server" />
                            <asp:HiddenField ID="hd_P3010802" runat="server" />
                            <asp:HiddenField ID="hd_P3010803" runat="server" />
                            <div style="width: 320px; height: 300px; overflow: scroll;">
                                <ul id="ul_P3010803" style="list-style-type: none; margin: 0; padding: 0; width: 100%;">
                                    <asp:Repeater ID="rp_P3010803" runat="server">
                                        <ItemTemplate>
                                            <li id="<%#Eval(cons.io.db.prp.PrpCons.P3010803)%>" class="ui-state-default">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <%# Eval(cons.io.db.prp.PrpCons.P301F206)%>
                                                        </td>
                                                        <td style="width: 20px;" align="center">
                                                            <asp:ImageButton ID="ib_Delete" runat="server" ImageUrl="~/_images/m_drop.png" OnClick="ib_Delete_Click" OnClientClick="return remove();" Width="15" Height="15" CommandArgument='<%#Eval(cons.io.db.prp.PrpCons.P3010803)%>' ToolTip="删除" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="right">
                                                            <%#rmp.wrp.exts.Exts.ShowDataStatus(Eval(cons.io.db.comn.user.UserCons.C3010407), Eval(cons.io.db.prp.PrpCons.P3010808), Eval(cons.io.db.prp.PrpCons.P3010807))%>
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
                            参照列表
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:DropDownList ID="cb_P3010803" runat="server" Style="max-width: 320px;">
                            </asp:DropDownList>
                            &nbsp;<asp:HyperLink ID="hl_P3010803" NavigateUrl="~/exts/exts0603.aspx" runat="server">新增</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <th style="width: 80px;" align="center" class="TD_DataHead_TL_L">
                            附注信息
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:TextBox ID="ta_P3010804" runat="server" Rows="5" TextMode="MultiLine" Width="260"></asp:TextBox>
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
                <asp:Button ID="bt_NextStep" runat="server" Text="下一步(N)" AccessKey="N" OnClick="bt_NextStep_Click" Visible="false" />
                <asp:Button ID="bt_SaveData" runat="server" Text="完成(O)" AccessKey="O" OnClick="bt_SaveData_Click" OnClientClick="return saveData();" />
                <asp:HiddenField ID="hd_NextStep" runat="server" />
                <asp:HiddenField ID="hd_IsUpdate" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

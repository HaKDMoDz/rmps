<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0013.aspx.cs" Inherits="exts_exts0013" %>

<%@ Register Src="~/App_Ascx/AmonIcon.ascx" TagName="AmonIcon" TagPrefix="as" %>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                【第三步】选择公司信息：
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <div class="DV_TEXT1">
                    &nbsp;
                </div>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellpadding="0" cellspacing="0" width="400">
                    <tr>
                        <td align="center" style="width: 70px;">
                            公司名称
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cb_P3010005" runat="server" Style="max-width: 300px;">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;
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
                        <td align="left">
                            <label>
                                <input id="ck_ApndData" type="checkbox" accesskey="A" onclick="$X('tr_ApndData').style.display=this.checked?'':'none';" />添加数据(A)
                            </label>
                        </td>
                        <td align="right">
                            <input type="button" id="bt_LastStep" value="上一步(P)" accesskey="P" onclick="window.location='exts0012.aspx';" />
                            <asp:Button ID="bt_NextStep" runat="server" Text="下一步(N)" AccessKey="N" OnClick="bt_NextStep_Click" OnClientClick="return checkInput();" />
                            <asp:Button ID="bt_SaveData" runat="server" Text="完成(O)" AccessKey="O" OnClick="bt_SaveData_Click" OnClientClick="return checkInput();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="tr_ApndData" style="display: none;">
            <td>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table width="460" border="0" cellpadding="2" cellspacing="0" class="TB_EXTSINFO" id="TB_EXTSINFO">
                                <tr>
                                    <td align="center">
                                        <table width="100%" border="0" cellpadding="2" cellspacing="0" class="TB_DataList_TL">
                                            <tr>
                                                <td style="width: 80px;" rowspan="2" align="center" class="TD_DataHead_TL_L">
                                                    <as:AmonIcon ID="ai_P3010104" runat="server" DstIconPath="corp" ToolTip="公司徽标" Enabled="true" CreateDiv="true" />
                                                </td>
                                                <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                    本语名称
                                                </th>
                                                <td align="left" class="TD_DataItem_TL_L">
                                                    <asp:TextBox ID="tf_P3010105" runat="server" Columns="30"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                    英语名称
                                                </th>
                                                <td align="left" class="TD_DataItem_TL_L">
                                                    <asp:TextBox ID="tf_P3010106" runat="server" Columns="30"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                    公司网址
                                                </th>
                                                <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                    <asp:TextBox ID="tf_P3010107" runat="server" Columns="30"></asp:TextBox>
                                                    <input id="bt_P3010107" type="button" value="查看(V)" accesskey="V" onclick="viewLink()" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                    公司简介
                                                </th>
                                                <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                    <asp:TextBox ID="ta_P3010108" runat="server" Rows="4" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                    附注信息
                                                </th>
                                                <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                    <asp:TextBox ID="ta_P3010109" runat="server" Rows="4" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
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
                            <asp:Button ID="bt_Insert" runat="server" OnClick="bt_Insert_Click" Text="保存(S)" OnClientClick="return checkNull();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

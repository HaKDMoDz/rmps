<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0303.aspx.cs" Inherits="exts_exts0303" ValidateRequest="false" %>

<%@ Register Src="~/App_Ascx/AmonAuth.ascx" TagName="AmonAuth" TagPrefix="as" %>
<%@ Register Src="~/App_Ascx/AmonIcon.ascx" TagName="AmonIcon" TagPrefix="as" %>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <asp:ScriptManager ID="sm_Script" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Update" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
                <tr>
                    <td align="center">
                        <asp:Label ID="lb_ErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table width="460" border="0" cellpadding="2" cellspacing="0" class="TB_EXTSINFO" id="TB_EXTSINFO">
                            <tr>
                                <td align="center">
                                    <table width="100%" border="0" cellpadding="2" cellspacing="0" class="TB_DataList_TL" id="FILEPROP">
                                        <tr>
                                            <td style="width: 80px;" rowspan="2" align="center" class="TD_DataHead_TL_L">
                                                <asp:HiddenField ID="hd_P3010302" runat="server" />
                                                <as:AmonIcon ID="ai_P3010304" runat="server" DstIconPath="corp" ToolTip="文件图标" Enabled="true" CreateDiv="true" />
                                            </td>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                数值签名
                                            </th>
                                            <td align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_P3010306" runat="server" Columns="30">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                字符签名
                                            </th>
                                            <td align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_P3010305" runat="server" Columns="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                国别信息
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:DropDownList ID="cb_C1110100" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_C1110100_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:CheckBox ID="ck_C1110100" runat="server" Text="更新软件信息" Checked="true" Enabled="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                公司信息
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:DropDownList ID="cb_P3010100" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_P3010100_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                软件信息
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:DropDownList ID="cb_P3010303" runat="server">
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hd_P3010303" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                偏移位置
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_P3010307" runat="server" Columns="30">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                加密算法
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_P3010308" runat="server" Columns="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                起始数据
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_P3010309" runat="server" Columns="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                结束数据
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_P301030A" runat="server" Columns="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                文件描述
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="ta_P301030B" runat="server" Rows="4" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                附注信息
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="ta_P301030C" runat="server" Rows="4" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                身份校验
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <as:AmonAuth ID="aa_AmonAuth" runat="server" />
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
                        <asp:Button ID="bt_Update" runat="server" OnClick="bt_Update_Click" Text="保存(S)" AccessKey="S" OnClientClick="return checkNull();" />
                        <input type="button" value="返回(R)" accesskey="R" />
                        <asp:HiddenField ID="hd_NextStep" runat="server" />
                        <asp:HiddenField ID="hd_P301030E" runat="server" />
                        &nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

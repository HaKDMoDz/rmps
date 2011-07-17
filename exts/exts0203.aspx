<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0203.aspx.cs" Inherits="exts_exts0203" ValidateRequest="false" %>

<%@ Register Src="~/App_Ascx/AmonAuth.ascx" TagName="AmonAuth" TagPrefix="as" %>
<%@ Register Src="~/App_Ascx/AmonIcon.ascx" TagName="AmonIcon" TagPrefix="as" %>
<%@ Register Src="~/App_Ascx/AmonFile.ascx" TagName="AmonFile" TagPrefix="as" %>
<%@ Register Src="ascx/PlatForm.ascx" TagName="PlatForm" TagPrefix="as" %>
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
                                    <table width="100%" border="0" cellpadding="2" cellspacing="0" class="TB_DataList_TL" id="SOFTPROP">
                                        <tr>
                                            <td style="width: 80px;" rowspan="2" align="center" class="TD_DataHead_TL_L">
                                                <asp:HiddenField ID="hd_P3010202" runat="server" />
                                                <as:AmonIcon ID="ai_P3010204" runat="server" DstIconPath="soft" ToolTip="软件图标" Enabled="true" Editable="true" CreateEditDiv="true" />
                                            </td>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                中文名称
                                            </th>
                                            <td align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_P3010205" runat="server" Columns="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                英文名称
                                            </th>
                                            <td align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_P3010206" runat="server" Columns="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr id="tr_C1110100" runat="server">
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                国别信息
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:DropDownList ID="cb_C1110100" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_C1110100_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:CheckBox ID="ck_C1110100" runat="server" Text="更新公司信息" Checked="true" Enabled="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                所属公司
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:DropDownList ID="cb_P3010203" runat="server">
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hd_P3010203" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                电子邮件
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_P3010207" runat="server" Columns="30"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                链接地址
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="tf_P3010208" runat="server" Columns="30"></asp:TextBox>
                                                <input id="bt_P3010208" type="button" value="查看(V)" accesskey="V" onclick="viewLink()" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                兼容后缀
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:ListBox ID="ls_P3010209" runat="server" Rows="6" Width="90%"></asp:ListBox>
                                                <table id="tb_P3010209" runat="server" visible="false" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr id="tr_Asoc00">
                                                        <td align="left">
                                                            <asp:TextBox ID="tf_P3010209" runat="server" Columns="20"></asp:TextBox>
                                                            <asp:Button ID="bt_Append" runat="server" Text="添加(A)" AccessKey="A" OnClick="bt_Append_Click" OnClientClick="return checkAppend();" />
                                                            <asp:Button ID="bt_Delete" runat="server" Text="删除(D)" AccessKey="D" OnClick="bt_Delete_Click" OnClientClick="return checkDelete();" />
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_Asoc01">
                                                        <td align="left">
                                                            <asp:CheckBox ID="ck_P3010209" runat="server" Text="关联后缀(X)" AccessKey="X" Checked="true" /><br />
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_Asoc02">
                                                        <td align="left">
                                                            <asp:CheckBox ID="ck_R" runat="server" AccessKey="R" Checked="True" Text="读取(R)" />
                                                            <asp:CheckBox ID="ck_W" runat="server" AccessKey="W" Text="写入(W)" />
                                                            <asp:CheckBox ID="ck_X" runat="server" AccessKey="X" Text="执行(X)" /><br />
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_Asoc03">
                                                        <td align="left">
                                                            <as:PlatForm ID="pf_PlatForm" runat="server" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                运行截图
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <as:AmonFile ID="af_P301020A" runat="server" SrcFilePath="view" DstFilePath="view" CreateEditDiv="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                软件简介
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="ta_P301020B" runat="server" Rows="4" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                附注信息
                                            </th>
                                            <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                <asp:TextBox ID="ta_P301020C" runat="server" Rows="4" TextMode="MultiLine" Width="90%"></asp:TextBox>
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
                        <asp:HiddenField ID="hd_Operate" runat="server" />
                        &nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

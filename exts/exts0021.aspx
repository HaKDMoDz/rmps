<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0021.aspx.cs" Inherits="exts_exts0021" %>

<%@ Register Src="ascx/PlatForm.ascx" TagName="PlatForm" TagPrefix="uc1" %>
<%@ Register Src="ascx/ArchBits.ascx" TagName="ArchBits" TagPrefix="uc2" %>
<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <asp:ScriptManager ID="sm_Script" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Update" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
                <tr id="tr_StepGuid" runat="server" style="height: 20px;">
                    <td align="left">
                        【第一步】后缀基本信息
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table width="460" border="0" cellpadding="2" cellspacing="0" class="TB_DataList_TL" id="EXTSPROP">
                            <tr>
                                <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                    后缀名称
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="tf_P3010013" runat="server" Columns="30"></asp:TextBox>
                                    <asp:HiddenField ID="hd_P3010003" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                    访问频率
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:Label ID="lb_P3010001" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                    国别信息
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:DropDownList ID="cb_P3010004" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_P3010004_SelectedIndexChanged" Style="max-width: 370px;">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                    公司信息
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:DropDownList ID="cb_P3010005" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_P3010005_SelectedIndexChanged" Style="max-width: 370px;">
                                    </asp:DropDownList>
                                    <a href="#" onclick="return showCorp();">添加</a>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                    软件信息
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:DropDownList ID="cb_P3010006" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cb_P3010006_SelectedIndexChanged" Style="max-width: 370px;">
                                    </asp:DropDownList>
                                    <a href="#" onclick="return showSoft();">添加</a>
                                    <asp:HiddenField ID="hd_P3010006" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                    文件信息
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:DropDownList ID="cb_P3010007" runat="server" Style="max-width: 370px;">
                                    </asp:DropDownList>
                                    <a href="#" onclick="return showFile();">添加</a>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                    文档信息
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:DropDownList ID="cb_P3010008" runat="server" Style="max-width: 370px;">
                                    </asp:DropDownList>
                                    <a href="#" onclick="return showDocs();">添加</a>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                    所属类别
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:DropDownList ID="cb_P301000C" runat="server" Style="max-width: 370px;">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                    应用平台
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <uc1:PlatForm ID="pf_PlatForm" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                    CPU 架构
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <uc2:ArchBits ID="ab_ArchBits" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                    特别致谢
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:DropDownList ID="cb_P301000F" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                    相关说明
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:TextBox ID="ta_P3010010" runat="server" Rows="4" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                    更新日期
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:Label ID="lb_P3010011" runat="server" Text="-"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th style="width: 80px; height: 30px;" align="center" class="TD_DataHead_TL_L">
                                    创建日期
                                </th>
                                <td align="left" class="TD_DataItem_TL_L">
                                    <asp:Label ID="lb_P3010012" runat="server" Text="-"></asp:Label>
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
                        <asp:Label ID="lb_ErrMsg" runat="server" CssClass="TEXT_NOTE1"></asp:Label>
                        <asp:Button ID="bt_SaveData" runat="server" Text="保存(S)" AccessKey="S" OnClick="bt_SaveData_Click" OnClientClick="return checkNull();" />
                        <asp:Button ID="bt_NextStep" runat="server" Text="下一步(N)" AccessKey="N" OnClick="bt_SaveData_Click" OnClientClick="return checkNull();" />
                        <input type="button" value="返回(R)" accesskey="R" />
                        <asp:HiddenField ID="hd_NextStep" runat="server" />
                        <asp:HiddenField ID="hd_PrevStep" runat="server" />
                    </td>
                </tr>
            </table>
            <div id="Corp" title="公司信息">
            </div>
            <div id="Soft" title="软件信息">
            </div>
            <div id="File" title="文件信息">
            </div>
            <div id="Docs" title="文档格式">
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

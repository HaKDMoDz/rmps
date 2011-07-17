<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0014.aspx.cs" Inherits="exts_exts0014" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                【第四步】选择软件信息：
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
                            所属软件
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cb_P3010006" runat="server" Style="max-width: 300px;">
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
                            <input type="button" id="bt_LastStep" value="上一步(P)" accesskey="P" onclick="window.location='exts0013.aspx';" />
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
                                                    <a href="#" onclick="return chooseImg();">
                                                        <asp:Image ID="ib_P3010204" Width="48" Height="48" CssClass="IMG_EXTSICON" ToolTip="软件图标，点击修改" AlternateText="点击修改" runat="server" /></a>
                                                    <asp:HiddenField ID="hd_P3010204" runat="server" Value="0" />
                                                    <asp:HiddenField ID="hd_UpdtIcon" runat="server" />
                                                    <asp:HiddenField ID="hd_IconPath" runat="server" />
                                                    <asp:HiddenField ID="hd_IconHash" runat="server" />
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
                                                    运行截图
                                                </th>
                                                <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                    <asp:FileUpload ID="fu_P301020A" runat="server" /><asp:Button ID="bt_P301020A" runat="server" Text="上传(L)" AccessKey="L" OnClick="bt_P301020A_Click" /><asp:HiddenField ID="hd_P301020A" runat="server" />
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
                                                    相关说明
                                                </th>
                                                <td colspan="2" align="left" class="TD_DataItem_TL_L">
                                                    <asp:TextBox ID="ta_P301020C" runat="server" Rows="4" TextMode="MultiLine" Width="90%"></asp:TextBox>
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

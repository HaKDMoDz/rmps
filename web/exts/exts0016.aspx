<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0016.aspx.cs" Inherits="exts_exts0016" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                【第六步】选择文档信息：
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
                            格式文档
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="cb_P3010008" runat="server" Style="max-width: 300px;">
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
                            <input type="button" id="bt_LastStep" value="上一步(P)" accesskey="P" onclick="window.location='exts0015.aspx';" />
                            <asp:Button ID="bt_NextStep" runat="server" Text="下一步(N)" AccessKey="N" OnClick="bt_NextStep_Click" />
                            <asp:Button ID="bt_SaveData" runat="server" Text="完成(O)" AccessKey="O" OnClick="bt_SaveData_Click" />
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
                                        <table width="100%" border="0" cellpadding="2" cellspacing="0" class="TB_DataList_TL" id="DOCSPROP">
                                            <tr>
                                                <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                    文档名称
                                                </th>
                                                <td align="left" class="TD_DataItem_TL_L">
                                                    <asp:FileUpload ID="fu_P3010404" runat="server" />
                                                    <asp:Button ID="bt_P3010404" runat="server" OnClick="bt_P3010404_Click" Text="上传" />
                                                    <asp:HiddenField ID="hd_P3010402" runat="server" />
                                                    <asp:HiddenField ID="hd_P3010404" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                    文档名称
                                                </th>
                                                <td align="left" class="TD_DataItem_TL_L">
                                                    <asp:TextBox ID="tf_P3010405" runat="server" Columns="30"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                    发行版本
                                                </th>
                                                <td align="left" class="TD_DataItem_TL_L">
                                                    <asp:TextBox ID="tf_P3010406" runat="server" Columns="30"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                    发行日期
                                                </th>
                                                <td align="left" class="TD_DataItem_TL_L">
                                                    <asp:TextBox ID="tf_P3010407" runat="server" Columns="30"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                    文档摘要
                                                </th>
                                                <td align="left" class="TD_DataItem_TL_L">
                                                    <asp:TextBox ID="ta_P3010408" runat="server" Rows="4" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th style="width: 80px; height: 30px;" class="TD_DataHead_TL_L">
                                                    附注信息
                                                </th>
                                                <td align="left" class="TD_DataItem_TL_L">
                                                    <asp:TextBox ID="ta_P3010409" runat="server" Rows="4" TextMode="MultiLine" Width="90%"></asp:TextBox>
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
                            <asp:Button ID="bt_Insert" runat="server" OnClick="bt_Insert_Click" Text="保存(S)" AccessKey="S" OnClientClick="return checkNull();" /><asp:HiddenField ID="hd_IsUpdate" runat="server" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

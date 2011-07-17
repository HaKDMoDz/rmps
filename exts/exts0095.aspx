<%@ Page Language="C#" MasterPageFile="~/exts/exts.master" AutoEventWireup="true" CodeFile="exts0095.aspx.cs" Inherits="exts_exts0095" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr id="tr_StepGuid" runat="server" style="height: 20px;">
            <td align="left">
                【可选第五步】输入附注信息：
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
            <td align="center">
                <table width="460" border="0" cellpadding="2" cellspacing="0" class="TB_DataList_TL">
                    <tr>
                        <th style="width: 80px;" align="center" class="TD_DataHead_TL_L">
                            附注信息
                        </th>
                        <td align="left" class="TD_DataItem_TL_L">
                            <asp:TextBox ID="ta_P3010504" runat="server" Rows="4" TextMode="MultiLine" Width="260"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 110px;">
                <asp:Button ID="bt_NextStep" runat="server" Text="下一步(N)" AccessKey="N" OnClick="bt_NextStep_Click" />
                <asp:Button ID="bt_SaveData" runat="server" Text="完成(O)" AccessKey="O" OnClick="bt_SaveData_Click" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" colspan="3">
                <input id="ck_ApndData" type="checkbox" accesskey="A" />添加数据(A)
            </td>
        </tr>
        <tr>
            <td style="height: 1px;" class="TD_LINE">
            </td>
        </tr>
    </table>
</asp:Content>

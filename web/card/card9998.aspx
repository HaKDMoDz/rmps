<%@ Page Language="C#" MasterPageFile="~/card/card.master" AutoEventWireup="true" CodeFile="card9998.aspx.cs" Inherits="card_card9998" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <table border="0" cellpadding="0" cellspacing="0" width="460" class="TB_DataList_TL">
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            功能键值：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W2040106" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            功能名称：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W2040107" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            文本数量：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:DropDownList ID="cb_W2040102" runat="server">
                                <asp:ListItem Text="1">1</asp:ListItem>
                                <asp:ListItem Text="2">2</asp:ListItem>
                                <asp:ListItem Text="3">3</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            默认标题：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W2040108" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            默认文本1：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W2040109" runat="server" Text="{0}"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            默认文本2：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W204010A" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            默认文本3：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W204010B" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            字体名称：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:DropDownList ID="cb_W204010C" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            字体大小：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W204010D" runat="server" Text="12"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            字体颜色：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_W204010E" runat="server" Text="#000000"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            字体风格：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:CheckBox ID="ck_Bold" runat="server" Text="粗体" /><asp:CheckBox ID="ck_Itac" runat="server" Text="斜体" /><asp:CheckBox ID="ck_Strk" runat="server" Text="删除线" /><asp:CheckBox ID="ck_Line" runat="server" Text="下划线" />
                        </td>
                    </tr>
                    <tr>
                        <th class="TD_DataHead_TL_L" style="width: 80px; height: 30px;">
                            显示位置：
                        </th>
                        <td class="TD_DataItem_TL_L" align="left">
                            水平(px)<asp:TextBox ID="tf_W2040110" runat="server" Text="10"></asp:TextBox>
                            竖直(px)<asp:TextBox ID="tf_W2040111" runat="server" Text="10"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="bt_SaveData" runat="server" Text="保存(S)" AccessKey="S" OnClick="bt_SaveData_Click" />
                <asp:HiddenField ID="hd_W2040103" runat="server" />
                <asp:HiddenField ID="hd_IsUpdate" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

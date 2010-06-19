<%@ Page Language="C#" MasterPageFile="~/tool/tool.master" AutoEventWireup="true" CodeFile="tool1303.aspx.cs" Inherits="tool_tool1303" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td colspan="2" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:TextBox ID="tf_Char" runat="server" TextMode="MultiLine" Rows="5" Width="360" Height="80"></asp:TextBox>
            </td>
            <td valign="top" style="background-color: #FAFAFA;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <asp:RadioButton ID="rb_Char" runat="server" Text="字符查询(C)" AccessKey="C" GroupName="rbcn" ToolTip="您可以输入任何可显示字符信息" Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:RadioButton ID="rb_Numb" runat="server" Text="数值查询(N)" AccessKey="N" GroupName="rbcn" ToolTip="您可以输入以~为标记的数值区间" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 10px;">
            </td>
            <td style="height: 10px; background-color: #FAFAFA;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellpadding="0" cellspacing="0" width="360">
                    <tr>
                        <td align="left">
                            <asp:DropDownList ID="cb_Char" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Button ID="bt_Char" runat="server" OnClick="bt_Char_Click" Text="查询(Q)" AccessKey="Q" OnClientClick="return checkNull();" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="background-color: #FAFAFA;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 10px;">
            </td>
            <td style="height: 10px; background-color: #FAFAFA;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <div style="width: 364px; height: 180px; overflow: scroll; border: solid 1px #CCCCCC;">
                    <table border="0" cellpadding="1" cellspacing="0" style="min-width: 100%; width: 100%;">
                        <tr>
                            <%
                                if (ck_Char.Checked)
                                {
                            %>
                            <th class="TD_DataHead_TL_L" nowrap="nowrap">
                                字符
                            </th>
                            <%
                                }
                                if (ck_No16.Checked)
                                {
                            %>
                            <th class="TD_DataHead_TL_L" nowrap="nowrap">
                                十六进制
                            </th>
                            <%
                                }
                                if (ck_No10.Checked)
                                {
                            %>
                            <th class="TD_DataHead_TL_L" nowrap="nowrap">
                                十进制
                            </th>
                            <%
                                }
                                if (ck_No08.Checked)
                                {
                            %>
                            <th class="TD_DataHead_TL_L" nowrap="nowrap">
                                八进制
                            </th>
                            <%
                                }
                                if (ck_No02.Checked)
                                {
                            %>
                            <th class="TD_DataHead_TL_L" nowrap="nowrap">
                                二进制
                            </th>
                            <%
                                }
                            %>
                        </tr>
                        <%
                            if (code != null)
                            {
                                /*字符查询*/
                                if (rb_Char.Checked)
                                {
                                    /*循环处理编码*/
                                    char[] t = new char[1];
                                    foreach (char c in tf_Char.Text)
                                    {
                                        t[0] = c;
                                        byte[] b = code.GetBytes(t);
                        %>
                        <tr>
                            <%
                                if (ck_Char.Checked)
                                {
                            %>
                            <td class="TD_DataItem_TL_L" align="center">
                                <%= Convert.ToChar(c)%>
                            </td>
                            <%
                                }
                                if (ck_No16.Checked)
                                {
                            %>
                            <td class="TD_DataItem_TL_L" align="center">
                                <%=ToString(b, 16, ' ', ck_Fixd.Checked, 2)%>
                            </td>
                            <%
                                }
                                if (ck_No10.Checked)
                                {
                            %>
                            <td class="TD_DataItem_TL_L" align="center">
                                <%=ToString(b, 10, ' ', ck_Fixd.Checked, 3)%>
                            </td>
                            <%
                                }
                                if (ck_No08.Checked)
                                {
                            %>
                            <td class="TD_DataItem_TL_L" align="center">
                                <%=ToString(b, 8, ' ', ck_Fixd.Checked, 3)%>
                            </td>
                            <%
                                }
                                if (ck_No02.Checked)
                                {
                            %>
                            <td class="TD_DataItem_TL_L" align="center">
                                <%=ToString(b, 2, ' ', ck_Fixd.Checked, 8)%>
                            </td>
                            <%
                                }
                            %>
                        </tr>
                        <%
                            }
                        }
                        else if (numS > -1)
                        {
                            while (numS <= numE)
                            {
                        %>
                        <tr>
                            <%
                                if (ck_Char.Checked)
                                {
                            %>
                            <td class="TD_DataItem_TL_L" align="center">
                                <%=Convert.ToChar(numS)%>
                            </td>
                            <%
                                }
                                if (ck_No16.Checked)
                                {
                            %>
                            <td class="TD_DataItem_TL_L" align="center">
                                <%=ToString(numS, 16, ck_Fixd.Checked, 8)%>
                            </td>
                            <%
                                }
                                if (ck_No10.Checked)
                                {
                            %>
                            <td class="TD_DataItem_TL_L" align="center">
                                <%=ToString(numS, 10, ck_Fixd.Checked, 10)%>
                            </td>
                            <%
                                }
                                if (ck_No08.Checked)
                                {
                            %>
                            <td class="TD_DataItem_TL_L" align="center">
                                <%=ToString(numS, 8, ck_Fixd.Checked, 11)%>
                            </td>
                            <%
                                }
                                if (ck_No02.Checked)
                                {
                            %>
                            <td class="TD_DataItem_TL_L" align="center">
                                <%=ToString(numS, 2, ck_Fixd.Checked, 32)%>
                            </td>
                            <%
                                }
                            %>
                        </tr>
                        <%
                                        numS += 1;
                                    }
                                }
                            }
                        %>
                    </table>
                </div>
            </td>
            <td valign="top" style="background-color: #FAFAFA;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left">
                            <asp:CheckBox ID="ck_Char" runat="server" AccessKey="H" Text="字符(H)" AutoPostBack="True" OnCheckedChanged="ck_Char_CheckedChanged" Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:CheckBox ID="ck_No16" runat="server" AccessKey="X" Text="16进制(X)" AutoPostBack="True" OnCheckedChanged="ck_No16_CheckedChanged" Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:CheckBox ID="ck_No10" runat="server" AccessKey="D" Text="10进制(D)" AutoPostBack="True" OnCheckedChanged="ck_No10_CheckedChanged" Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:CheckBox ID="ck_No08" runat="server" AccessKey="O" Text="8进制(O)" AutoPostBack="True" OnCheckedChanged="ck_No08_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:CheckBox ID="ck_No02" runat="server" AccessKey="B" Text="2进制(B)" AutoPostBack="True" OnCheckedChanged="ck_No02_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td class="TD_LINE">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:CheckBox ID="ck_Fixd" runat="server" AccessKey="F" Text="填充(F)" AutoPostBack="True" OnCheckedChanged="ck_Fixd_CheckedChanged" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

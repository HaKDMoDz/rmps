<%@ Page Language="C#" MasterPageFile="~/comn/comn.master" AutoEventWireup="true" CodeFile="comn0201.aspx.cs" Inherits="comn_comn0201" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <asp:ScriptManager ID="sm_Script" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="up_Update" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
                <tr>
                    <td align="center">
                        <asp:TextBox ID="tf_InfoData" runat="server"></asp:TextBox><asp:Button ID="bt_InfoData" runat="server" Text="查询(Q)" AccessKey="Q" OnClick="bt_InfoData_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:LinkButton ID="lb_IsCreate" runat="server" Text="新增数据" Visible="false" OnClick="lb_IsCreate_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lb_SoftList" runat="server" Text="返回列表首页" OnClick="lb_SoftList_Click"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gv_SoftList" runat="server" Width="460px" AutoGenerateColumns="False" OnSelectedIndexChanged="gv_SoftList_SelectedIndexChanged" DataKeyNames="C0010104" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField HeaderText="软件代码">
                                    <ItemTemplate>
                                        <%# Eval(cons.io.db.comn.ComnCons.C0010104)%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="软件名称">
                                    <ItemTemplate>
                                        <a title="<%# Eval(cons.io.db.comn.ComnCons.C0010108)%>">
                                            <%# Eval(cons.io.db.comn.ComnCons.C0010106)%>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="当前版本">
                                    <ItemTemplate>
                                        <%# Eval(cons.io.db.comn.ComnCons.C0010105)%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" SelectText="查看" />
                            </Columns>
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                        <asp:GridView ID="gv_InfoData" runat="server" Width="460px" AutoGenerateColumns="False" OnSelectedIndexChanged="gv_InfoData_SelectedIndexChanged" DataKeyNames="C2010105" Visible="False" OnRowEditing="gv_InfoData_RowEditing" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="gv_InfoData_RowDeleting">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField HeaderText="类别级别">
                                    <ItemTemplate>
                                        <%# Eval(cons.io.db.comn.info.C2010000.C2010103)%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="类别名称">
                                    <ItemTemplate>
                                        <a title="<%# Eval(cons.io.db.comn.info.C2010000.C2010108)%>">
                                            <%# Eval(cons.io.db.comn.info.C2010000.C2010107)%>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="类别键值">
                                    <ItemTemplate>
                                        <asp:Label ID="lb_C0010105" runat="server"><%# Eval(cons.io.db.comn.info.C2010000.C2010109)%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowSelectButton="True" SelectText="查看" />
                                <asp:CommandField ShowEditButton="True" SelectText="编辑" />
                                <asp:CommandField ShowDeleteButton="True" SelectText="删除" />
                            </Columns>
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <div id="dv_Update" runat="server" visible="false" style="text-align: center;">
                <table width="460" border="0" cellpadding="3" cellspacing="0" class="TB_DataList_TL">
                    <tr>
                        <td class="TD_DataHead_TL_L" style="width: 100px;" align="center">
                            显示排序
                        </td>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_C2010101" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TD_DataHead_TL_L" style="width: 100px;" align="center">
                            类别名称
                        </td>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_C2010107" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TD_DataHead_TL_L" style="width: 100px;" align="center">
                            类别提示
                        </td>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_C2010108" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TD_DataHead_TL_L" style="width: 100px;" align="center">
                            类别键值
                        </td>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="tf_C2010109" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TD_DataHead_TL_L" style="width: 100px;" align="center">
                            类别描述
                        </td>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:TextBox ID="ta_C201010A" runat="server" Rows="4" Columns="40" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="TD_DataHead_TL_L" style="width: 100px;" align="center">
                            上次更新
                        </td>
                        <td class="TD_DataItem_TL_L" align="left">
                            <asp:Label ID="lb_C201010B" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="bt_SaveData" runat="server" Text="保存(S)" AccessKey="S" OnClick="bt_SaveData_Click" />
                <asp:HiddenField ID="hd_IsUpdate" runat="server" />
                <asp:HiddenField ID="hd_C2010106" runat="server" Value="0" />
                <asp:HiddenField ID="hd_SoftCode" runat="server" Value="0" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

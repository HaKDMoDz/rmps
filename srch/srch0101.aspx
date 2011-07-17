<%@ Page Language="C#" MasterPageFile="~/srch/srch.master" AutoEventWireup="true" CodeFile="srch0101.aspx.cs" Inherits="srch_srch0101" Title="Untitled Page" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <div class="DV_TEXT1">
                    【使用说明】<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;1、此页面仅供注册用户进行个性化配置，请先确认您是否已经登录；<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;2、您可以选择增加或移除（取消选择）某个搜索引擎，以调整您的使用偏好，完成后点击《保存(S)》按钮；<br />
                    &nbsp;&nbsp;&nbsp;&nbsp;3、点击《下一步(N)》按钮，选择您喜欢的界面风格。<br />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 30px;">
                <asp:RadioButtonList ID="rb_ListView" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="rb_ListView_SelectedIndexChanged">
                    <asp:ListItem Text="按引擎查看" Value="0" Selected="true"></asp:ListItem>
                    <asp:ListItem Text="按类别查看" Value="1"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div style="width: 400px; height: 600px; text-align: left; border: solid 1px #EAEAEA; overflow: auto;">
                    <asp:TreeView ID="tv_DataList" runat="server">
                    </asp:TreeView>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="bt_Append" runat="server" Text="新增(A)" AccessKey="A" OnClientClick="return doAppend()" />
                <asp:Button ID="bt_Update" runat="server" Text="更新(U)" AccessKey="U" OnClientClick="return doUpdate()" OnClick="bt_Update_Click" />
                <asp:Button ID="bt_Save" runat="server" Text="保存(S)" AccessKey="S" OnClick="bt_Save_Click" OnClientClick="return checkNull();" />
                <input type="button" value="下一步(N)" accesskey="N" onclick="window.location.href='srch0103.aspx'" />
            </td>
        </tr>
    </table>
</asp:Content>

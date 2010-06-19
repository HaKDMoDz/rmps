<%@ Page Language="C#" MasterPageFile="~/card/card.master" AutoEventWireup="true" CodeFile="card0001.aspx.cs" Inherits="card_card0001" EnableEventValidation="false" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;HTML代码：您可以放置于任何HTML页面文件中。<br />
            </td>
        </tr>
        <tr>
            <td align="center">
                <textarea id="ta_HtmCode" cols="20" rows="6" style="width: 90%" readonly="readOnly"></textarea>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;UBB代码：适合放置于支持UBB的论坛或博客页面中。<br />
            </td>
        </tr>
        <tr>
            <td align="center">
                <textarea id="ta_UbbCode" cols="20" rows="6" style="width: 90%" readonly="readOnly"></textarea>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;我的卡片：<asp:DropDownList ID="cb_CardList" runat="server">
                </asp:DropDownList>&nbsp;<asp:LinkButton ID="lb_EditCard" runat="server" Text="修改" ToolTip="修改卡片数据"></asp:LinkButton>
                <asp:HiddenField ID="hd_UserCode" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr id="tr_UserCard" style="display: none;">
            <td align="center">
                <img id="im_UserCard" alt="卡片预览" src="" title="卡片预览" />
            </td>
        </tr>
    </table>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/iask/iask.master" AutoEventWireup="true" CodeFile="iask1313.aspx.cs" Inherits="iask_iask1313" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <textarea id="j" rows="20" cols="60"></textarea>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <input type="button" id="e" value="加密(E)" accesskey="E" onclick="_e()" />
                <input type="button" id="d" value="解密(D)" accesskey="D" onclick="_d()" />
                <input type="button" id="c" value="清除(C)" accesskey="C" onclick="_c()" />
                <input type="button" id="r" value="运行(R)" accesskey="R" onclick="_r()" />
            </td>
        </tr>
    </table>
</asp:Content>

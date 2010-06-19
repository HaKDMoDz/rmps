<%@ Page Language="C#" MasterPageFile="~/srch/srch.master" AutoEventWireup="true" CodeFile="srch0103.aspx.cs" Inherits="srch_srch0103" %>

<asp:Content ID="AmonData" ContentPlaceHolderID="AmonView" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" id="TB_DATA">
        <tr>
            <td align="center">
                <div class="DV_TEXT1">
                    【说明】：<br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;某些版本的浏览器可能出现无法预览的情况，请刷新一次预览窗口即可！
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
                <textarea id="ta_Code" cols="20" rows="8" style="width: 90%" readonly="readOnly"></textarea>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <div style="width: 90%; text-align: right;">
                    <input id="bt_View" type="button" value="预览(P)" accesskey="P" onclick="preview();" /><asp:HiddenField ID="hd_UserCode" runat="server" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="TD_LINE" style="height: 1px;">
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table border="0" cellpadding="2" cellspacing="0" width="90%">
                    <tr>
                        <th align="left">
                            配置参数
                        </th>
                    </tr>
                    <tr>
                        <td align="left">
                            容器 DIV：<input type="text" id="tf_Sdiv" value="" size="8" onblur="checkInput();" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            显示宽度：<input type="text" id="tf_Size" value="400" size="8" onblur="checkInput();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

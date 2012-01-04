<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="cipher_Index" EnableEventValidation="true" %>

<!doctype html>
<html>
<head runat="server">
    <title>无标题页</title>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <link href="index.css" rel="stylesheet" type="text/css" />
    <link href="../_res/jQueryUI/ui-lightness/jquery-ui-1.8.14.custom.css" rel="stylesheet" type="text/css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js" type="text/javascript"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.14/jquery-ui.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="AmonForm" runat="server">
    <table style="width: 100%;" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="BgTl">
            </td>
            <td class="BgTm">
            </td>
            <td class="BgTr">
            </td>
        </tr>
        <tr>
            <td class="BgMl">
            </td>
            <td id="TdTa" class="BgMm">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 50%;" align="center">
                            <asp:TextBox ID="TaSt" runat="server" TextMode="MultiLine" ToolTip="输入内容(S)" AccessKey="S"></asp:TextBox>
                        </td>
                        <td style="width: 20px;" align="center">
                            <%-- Method Direction：操作方向（加密还是解密） --%>
                            <input type="image" id="IbMd" src="../_img/safe/switch16.png" alt="" title="互换(X)" accesskey="X" checked="false" />
                            <%-- HdMd:是否为解密操作：1是，0否 --%>
                            <asp:HiddenField ID="HdMd" runat="server" />
                        </td>
                        <td style="width: 50%;" align="center">
                            <asp:TextBox ID="TaDt" runat="server" TextMode="MultiLine" ToolTip="输出内容(D)" AccessKey="D" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="BgMr">
            </td>
        </tr>
        <tr>
            <td class="BgMl">
            </td>
            <td class="BgMm" style="height: 20px;">
                <%-- 算法选项 --%>
                <div id="DvMo" runat="server">
                    <%-- Method Category:加密方案 --%>
                    <asp:DropDownList ID="CbMc" runat="server" ToolTip="加密方案(C)" AccessKey="C">
                    </asp:DropDownList>
                    <%-- Method Function:加密算法 --%>
                    <asp:DropDownList ID="CbMf" runat="server" ToolTip="加密算法(A)" AccessKey="A">
                    </asp:DropDownList>
                    <%-- 密钥长度 --%>
                    <asp:DropDownList ID="CbMl" runat="server" ToolTip="密钥长度(L)" AccessKey="L">
                    </asp:DropDownList>
                    <input type="image" id="IbKd" src="../_img/safe/wizard16.png" alt="G" title="生成密钥(G)" accesskey="G" />
                    <span id="LbMc">字符集 </span>
                </div>
                <asp:Label ID="LbErr1" runat="server"></asp:Label>
            </td>
            <td class="BgMr">
            </td>
        </tr>
        <tr>
            <td class="BgMl">
            </td>
            <td class="BgMm" style="height: 20px;">
                <%-- User Password用户口令 --%>
                <asp:TextBox ID="TbUk" runat="server" ToolTip="用户口令(P)" AccessKey="P"></asp:TextBox>
            </td>
            <td class="BgMr">
            </td>
        </tr>
        <tr>
            <td class="BgBl">
            </td>
            <td class="BgBm" align="center">
                <input type=button id="BtDo" class="Btn" value="执行(R)" accesskey="R" />
                <asp:Button ID="BtOp" runat="server" CssClass="Btn" />
            </td>
            <td class="BgBr">
            </td>
        </tr>
    </table>
    <div id="dvCd" title="字符集" style="display: none;">
        <iframe id="ifCd"></iframe>
    </div>
    <div id="dvKd" title="密钥对" style="display: none;">
        <iframe id="ifKd"></iframe>
    </div>
    </form>
</body>
</html>

<script src="index.js" type="text/javascript"></script>


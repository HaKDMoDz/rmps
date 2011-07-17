<%@ Page Language="C#" AutoEventWireup="true" CodeFile="inet0002.aspx.cs" Inherits="inet_inet0002" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>网页精灵</title>
    <style type="text/css">
    BODY
    {
        font-family: "宋体", simsun, Arial, "Times New Roman";
        font-size: 9pt;
    }
    </style>
</head>
<body>
    <form id="AmonForm" runat="server" action="inet0003.aspx">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="center" style="height: 200px;">
                    <img src="/inet/_i/Loading.gif" alt="页面载入中..." /><br />
                    <br />
                    页面载入中，请稍候...
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hp" runat="server" />
        <asp:HiddenField ID="ht" runat="server" />
        <asp:HiddenField ID="hu" runat="server" />
        <asp:HiddenField ID="hd" runat="server" />
        <asp:HiddenField ID="hx" runat="server" />
        <asp:HiddenField ID="hk" runat="server" />
    </form>
</body>
</html>

<script type="text/javascript">
function v(o)
{
    return document.getElementById('h'+o).value;
}
var w=window;
var p=v('p');
if (p&&p!='')
{
    var x=v('x');
    if (x&&x!='')
    {
        p=w.open(p.replace('{0}',eval(x)(v('t'))).replace('{1}',eval(x)(v('u'))).replace('{2}',eval(x)(v('d'))),'_self');
    }
    else
    {
        p=w.open(p.replace('{0}',v('t')).replace('{1}',v('u')).replace('{2}',v('d')),'_self');
    }
}
if(p&&v('k')=='1')
{
    w.close();
}
</script>


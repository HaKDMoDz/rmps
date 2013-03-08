<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cv.aspx.cs" Inherits="Me.Amon.Cv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>爱梦·卡片</title>
    <link type="text/css" rel="stylesheet" href="/_css/Amon.css" />
    <link type="text/css" rel="stylesheet" href="/_css/smoothness/jquery-ui-1.10.1.custom.min.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.10.1/jquery-ui.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="DbBase" class="base">
        <div id="DvBody" runat="server" class="body">
            <div id="DvList" runat="server" class="list shadow">
                <ul id="UlList" class="ztree">
                </ul>
            </div>
            <div id="DvPage" class="page shadow">
                <asp:Label ID="LbNote" runat="server"></asp:Label>
            </div>
            <div class="clear">
            </div>
        </div>
        <!--div id="DvIdea" class="idea shadow">
        </div-->
        <div id="DvLoad" class="load corner" style="width: 300px; height: 100px; margin-left: -150px; margin-top: -40px; text-align: center">
            <br />
            <img alt="Loading" src="/_img/Loading.gif" /><br />
            <br />
            正在努力建设中……<br />
            <br />
            <a href="/User/Index.aspx">回首页</a>
        </div>
    </div>
    </form>
</body>
</html>

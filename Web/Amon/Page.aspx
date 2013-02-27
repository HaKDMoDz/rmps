<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page.aspx.cs" Inherits="Me.Amon.Page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>爱梦·网志</title>
    <link type="text/css" rel="stylesheet" href="/_css/Amon.css" />
    <link type="text/css" rel="stylesheet" href="/_css/smoothness/jquery-ui-1.10.1.custom.min.css" />
    <link type="text/css" rel="stylesheet" href="/_js/zt/themes/zTreeStyle.css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.10.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="/_js/zt/jquery.ztree.core-3.5.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="DbBase" class="base">
        <div id="DvBody" runat="server" class="body">
            <div id="DvList" runat="server" class="list shadow">
                <ul id="UlList" class="ztree">
                </ul>
            </div>
            <div id="DvPage" runat="server" class="page shadow">
                <iframe id="IfPage" runat="server" style="width: 100%; height: 420px; min-width: 300px; min-height: 420px; border: 0px;"></iframe>
            </div>
            <div class="clear">
            </div>
        </div>
        <div id="DvIdea" runat="server" class="idea shadow">
            abc
        </div>
        <div id="DvLoad" class="load corner" style="width: 300px; height: 80px; margin-left: -150px; margin-top: -40px; text-align: center">
            <br />
            <img alt="Loading" src="/_img/Loading.gif" /><br />
            <br />
            正在努力为您加载中……
        </div>
    </div>
    <asp:HiddenField ID="HdCode" runat="server" />
    </form>
</body>
<script type="text/javascript">
    function reload(url) {
        $('#IfPage').attr("src", "/Page.ashx?c=" + code + "&f=" + escape(url));
        $("#IfPage").load(function () {
            var h = $(this).contents().find("body").height() + 30;
            if (h < 420) { h = 420; }
            $(this).height(h);
        });
    }
    reload("/index.html");
    function onClick(event, treeId, treeNode, clickFlag) {
        $('#IfPage').attr("src", "/Page.ashx?c=" + code + "&f=" + escape(treeNode.v));
    }

    var zTree;
    var setting = {
        data: {
            key: {
                title: "t"
            },
            simpleData: {
                enable: true,
                idKey: "id",
                pIdKey: "pId",
                rootPId: "0"
            }
        },
        callback: {
            onClick: onClick
        }
    };
    var zNodes = [];
    var t = $("#UlList");
    var code = $('#HdCode').val();
    $.fn.zTree.init(t, setting, zNodes);

    $.ajax({
        type: "POST",
        url: "/Page.ashx?t=cat&c=" + code,
        success: function (data) {
            zNodes = eval(data);
            $.fn.zTree.init(t, setting, zNodes);
            $("#DvLoad").hide();
        }
    });
</script>
</html>

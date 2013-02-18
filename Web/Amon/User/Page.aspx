<%@ Page Title="" Language="C#" MasterPageFile="~/Amon.master" AutoEventWireup="true" CodeFile="Page.aspx.cs" Inherits="User_Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AmonHead" runat="Server">
    <script type="text/javascript" charset="utf-8" src="../_js/ue/editor_config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../_js/ue/editor_all_min.js"></script>
    <style type="text/css">
        .clear
        {
            clear: both;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AmonView" runat="Server">
    <div>
        <script id="editor" type="text/plain">这里可以书写，编辑器的初始内容</script>
    </div>
    <script type="text/javascript">
        //实例化编辑器
        var ue = UE.getEditor('editor');

        ue.addListener('ready', function () {
            this.focus()
        });
    </script>
</asp:Content>

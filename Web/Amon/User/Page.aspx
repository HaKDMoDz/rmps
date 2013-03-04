<%@ Page Title="编辑网志" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Page.aspx.cs" Inherits="Me.Amon.User.Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AmonHead" runat="Server">
    <script type="text/javascript">
        window.UEDITOR_HOME_URL = "/_js/ue/";
    </script>
    <script type="text/javascript" charset="utf-8" src="/_js/ue/editor_config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/_js/ue/editor_all.js"></script>
    <style type="text/css">
        .clear
        {
            clear: both;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AmonView" runat="Server">
    <div class="body" style="width: 960px; margin: 50px auto 0px auto;">
        <div style="margin: 8px">
            <script id="editor" type="text/plain">这里可以书写，编辑器的初始内容</script>
        </div>
        <div style="margin: 8px; text-align: center;">
            <asp:HiddenField ID="HfData" runat="server" />
            <asp:LinkButton ID="BtUpdate" runat="server" Text="保存" CssClass="button submit" ForeColor="White" OnClientClick="return getContentHtm();" OnClick="BtUpdate_Click" />
            <a href="/User/Index.aspx" class="button cancel" onclick="return doCancel()" style="color: #000;">取消</a>
        </div>
    </div>
    <script type="text/javascript">
        //实例化编辑器
        var ue = UE.getEditor('editor');

        ue.addListener('ready', function () {
            this.focus()
        });

        function doCancel() {
            return confirm("您有网志正在编辑中，取消后您的数据将会丢失，确认要取消吗？");
        }

        function getContentHtm() {
            $('#HfData').val(UE.getEditor('editor').getContent());
            return true;
        }
        function getContentTxt() {
            $('#HfData').val(UE.getEditor('editor').getContentTxt());
            return true;
        }
        function setContent() {
            UE.getEditor('editor').setContent($('HfData').val());
            return true;
        }
    </script>
</asp:Content>

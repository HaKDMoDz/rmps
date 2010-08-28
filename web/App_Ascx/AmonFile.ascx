<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AmonFile.ascx.cs" Inherits="App_Ascx_AmonFile" %>
<%-- 用户修改图标时，临时图标存储路径 --%>
<asp:HiddenField ID="hd_SrcPath" runat="server" Value="" />
<%-- 用户修改图标时，临时图标Hash键值 --%>
<asp:HiddenField ID="hd_SrcHash" runat="server" Value="" />
<%-- 用户操作记录：-1删除，0无操作，1新增，2覆盖，3追加 --%>
<asp:HiddenField ID="hd_UserOpt" runat="server" Value="0" />
<%-- 图标文件目标存储路径，如corp,soft等 --%>
<asp:HiddenField ID="hd_DstPath" runat="server" Value="0" />
<%-- 图标文件最终Hash键值 --%>
<asp:HiddenField ID="hd_DstHash" runat="server" Value="0" />
<asp:Label ID="lb_FileName" runat="server"></asp:Label>
<input type="button" value="编辑(E)" accesskey="E" onclick="editFile();" />
<%
    // 编辑功能
    if (CreateEditDiv)
    {
%>
<div id="dv_EditFile" title="Amon文件" style="display: none;">
    <iframe id="if_EditFile" frameborder="0" style="width: 100%; height: 100%;"></iframe>
</div>

<script type="text/javascript">
    function editFile()
    {
        var d=$X(cid+'_hd_DstHash').value;
        if(!d)
        {
            d='0';
        }

        $("#dv_EditFile").dialog({width:600,height:400,modal:true});
	    $X('if_EditFile').src=_URI+'/file/file0100.aspx?sid='+d;
	    $("#dv_EditFile").attr('editHash',cid);

        return false;
    }
    function saveFile()
    {
    }
</script>

<%
    }
%>
<input type="button" value="查看(E)" accesskey="V" onclick="viewFile();" />
<%
    // 编辑功能
    if (CreateViewDiv)
    {
%>
<div id="dv_ViewFile" title="Amon文件" style="display: none;">
    <iframe id="if_ViewFile" frameborder="0" style="width: 100%; height: 100%;"></iframe>
</div>

<script type="text/javascript">
    function viewFile()
    {
    }
</script>

<%
    }
%>
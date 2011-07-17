<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AmonFile.ascx.cs" Inherits="App_Ascx_AmonFile" %>
<%-- 用户修改图标时，临时图标存储路径 --%>
<asp:HiddenField ID="hd_SrcPath" runat="server" Value="" />
<%-- 用户修改图标时，临时图标Hash键值 --%>
<asp:HiddenField ID="hd_SrcHash" runat="server" Value="" />
<%-- 图标文件目标存储路径，如corp,soft等 --%>
<asp:HiddenField ID="hd_DstPath" runat="server" Value="0" />
<%-- 图标文件最终Hash键值 --%>
<asp:HiddenField ID="hd_DstHash" runat="server" Value="0" />
<asp:HyperLink ID="hl_FileName" runat="server" ToolTip="点击查看" Target="_blank"></asp:HyperLink>
<input type="button" value="编辑(E)" accesskey="E" onclick="editFile('<%=ClientID%>');" />
<%
    // 编辑功能
    if (CreateEditDiv)
    {
%>
<div id="dv_EditFile" title="Amon文件" style="display: none;">
    <iframe id="if_EditFile" frameborder="0" style="width: 100%; height: 100%;"></iframe>
</div>
<script type="text/javascript">
    function editFile(cid)
    {
        var d=$X(cid+'_hd_DstHash').value;
        if(!d)
        {
            d='0';
        }

        $("#dv_EditFile").dialog({width:600,height:460,modal:true});
	    $X('if_EditFile').src=_URI+'/file/file0100.aspx?sid='+d+'&opt='+escape('<%= SrcFilePath %>');
	    $("#dv_EditFile").attr('editHash',cid);

        return false;
    }
    function saveFile(sid,ext,cid)
    {
        if(!cid)
        {
            cid=$("#dv_EditFile").attr('editHash');
        }
        $X(cid+'_hl_FileName').href=_URI+'<%=cons.EnvCons.DIR_TMP.Substring(1)+SrcFilePath%>'+sid+ext;
        $X(cid+'_hl_FileName').innerHTML=sid+ext;
        //$X(cid+'_hd_SrcPath').value=uri;
        $X(cid+'_hd_SrcHash').value=sid;
        $("#dv_EditFile").dialog('close');
    }
</script>

<%
    }
%>
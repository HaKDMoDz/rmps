<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AmonIcon.ascx.cs" Inherits="App_Ascx_AmonIcon" %>
<asp:ImageButton ID="ib_AmonIcon" runat="server" Width="48" Height="48" CssClass="IMG_EXTSICON" />
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
<%
    if (CreateDiv)
    {
%>
<div id="dv_EditIcon" title="Amon图标" style="display: none;">
    <iframe id="if_EditIcon" frameborder="0" style="width: 100%; height: 100%;"></iframe>
</div>
<%
    }
%>

<script type="text/javascript" charset="utf-8">
$W().saveIcon=function(uri,sid,opt)
{
    if (!sid)
    {
        sid='0';
    }
    if (!uri)
    {
        uri=_URI+'/icon/icon0001.ashx?sid=comn,_NVL';
        sid='0';
    }

    $X('<%=ClientID%>_ib_AmonIcon').src=_URI+uri+sid+'0030.png';
    $X('<%=ClientID%>_hd_SrcPath').value=uri;
    $X('<%=ClientID%>_hd_SrcHash').value=sid;
    $X('<%=ClientID%>_hd_UserOpt').value=isHash($X('<%=ClientID%>_hd_DstHash').value)?opt:'1';
    $("#dv_EditIcon").dialog('close');

    return true;
};
function editIcon()
{
    var d=$X('<%=ClientID%>_hd_DstHash').value;
    if (!d)
    {
        d='0';
    }

    $("#dv_EditIcon").dialog({width:600,height:400,modal:true});
	$X('if_EditIcon').src=_URI+'/icon/icon0100.aspx?uri=corp&sid='+d;

    return false;
}
function viewIcon()
{
}
</script>


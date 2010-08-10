<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AmonIcon.ascx.cs" Inherits="App_Ascx_AmonIcon" %>
<asp:ImageButton ID="ib_AmonIcon" runat="server" CssClass="IMG_EXTSICON" />
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
    // 编辑功能
    if (CreateEditDiv)
    {
%>
<div id="dv_EditIcon" title="Amon图标" style="display: none;">
    <iframe id="if_EditIcon" frameborder="0" style="width: 100%; height: 100%;"></iframe>
</div>

<script type="text/javascript" charset="utf-8">
$W().saveIcon=function(uri,sid,opt,cid)
{
    if(!uri)
    {
        uri='/icon/icon0001.ashx?sid=comn,_NVL';
        sid='0';
    }
    if(!sid)
    {
        sid='0';
    }
	if(!cid)
	{
		cid=$("#dv_EditIcon").attr('editHash');
	}

    $X(cid+'_ib_AmonIcon').src=_URI+uri+sid+'0030.png';
    $X(cid+'_hd_SrcPath').value=uri;
    $X(cid+'_hd_SrcHash').value=sid;
    $X(cid+'_hd_UserOpt').value=isHash($X(cid+'_hd_DstHash').value)?opt:'1';
    $("#dv_EditIcon").dialog('close');

    return true;
};
function editIcon(cid)
{
    var d=$X(cid+'_hd_DstHash').value;
    if(!d)
    {
        d='0';
    }

    $("#dv_EditIcon").dialog({width:600,height:400,modal:true});
	$X('if_EditIcon').src=_URI+'/icon/icon0100.aspx?uri=corp&sid='+d;
	$("#dv_EditIcon").attr('editHash',cid);

    return false;
}
</script>

<%
    }
%>
<%
    // 查看功能
    if (CreateViewDiv)
    {
%>
<div id="dv_ViewIcon" title="Amon图标" style="display: none;">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 13px;" align="center" rowspan="2">
                <div id="sv_ViewIcon" style="height: 260px;">
                </div>
            </td>
            <td style="height: 260px;" align="center">
                <img id="im_ViewIcon" src="" alt="" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <label id="lb_ViewIcon" style="border: 0; font-weight: bold;">
                </label>
                <input type="hidden" id="hd_ViewIcon" />
            </td>
        </tr>
    </table>
</div>

<script type="text/javascript" charset="utf-8">
$(function()
{
    $("#sv_ViewIcon").slider({
        orientation: "vertical",
        range: "min",
        min: 16,
        max: 256,
        value: 48,
        step: 16,
        slide: function(event, ui)
        {
            showIcon(ui.value);
        }
    });
});
function viewIcon(sid,cid)
{
    if(!sid)
    {
        sid='comn,_NVL';
    }
    
    $("#dv_ViewIcon").attr("viewHash",'/web/icon/icon0001.ashx?sid='+sid+'&uri=');
    
    $("#sv_ViewIcon").slider("value",48)
    showIcon(48);
    
    $("#dv_ViewIcon").dialog({width:310,height:330,modal:true});
    return false;
}
function showIcon(size)
{
    $("#lb_ViewIcon").html("图片大小："+size+"×"+size);
    $('#hd_ViewIcon').val(size);
    $X('im_ViewIcon').src=$("#dv_ViewIcon").attr("viewHash")+size;
}
</script>

<%
    }
%>

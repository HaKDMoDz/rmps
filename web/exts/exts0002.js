// JScript 文件
function chkIcon()
{
    var obj=$E('tf_IconName');
    var val=obj.value;
    if(!val||!val.trim())
    {
        alert('请输入您要查询的图标名称！');
        obj.focus();
        return false;
    }
    return true;
}
function addFav()
{
    var conf = window.confirm('您当前的操作是将本页面添加到收藏夹，确认要继续么？');
    if (!conf)
    {
        return;
    }
    var ext = $E('hd_ExtsName').value;
    var cas = $E('hd_ExtsCase').value;

    return addFavorite('http://amonsoft.net/exts/exts0001.aspx?exts=' + ext + '&case=' + cas, '后缀解析 - ' + ext, '')
}

$(function()
{
    $("#sv_SlidIcon").slider({
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
    
    $("#dv_ViewIcon").attr("slidHash",'/icon/icon0001.ashx?sid='+sid+'&uri=');
    
    $("#sv_SlidIcon").slider("value",48)
    showIcon(48);
    
    $("#dv_ViewIcon").dialog({width:310,height:330,modal:true});
    return false;
}
function showIcon(size)
{
    $("#lb_SlidIcon").html("图片大小："+size+"×"+size);
    $('#hd_SlidIcon').val(size);
    $X('im_SlidIcon').src=$("#dv_ViewIcon").attr("slidHash")+size;
}
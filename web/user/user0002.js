$W().handleImg=function(uri,sid,opt)
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

    $E('hd_C3010008').value = sid;
    $E('ib_C3010008').src=_URI+uri+sid+'0030.png';
    $E('hd_IconPath').value=uri;
    $E('hd_IconHash').value=sid;
    $E('hd_UpdtIcon').value=isHash($E('hd_C3010008').value)?opt:'1';
    $("#dv_EditIcon").dialog('close');
}
function chooseImg()
{
    var d=$E('hd_C3010008').value;
    if (!d)
    {
        d='0';
    }
    
    $("#dv_EditIcon").dialog({width:600,height:400,modal:true});
	$X('if_EditIcon').src=_URI+'/icon/icon0100.aspx?uri=corp&sid='+d;

    return false;
}
function checkNull()
{
    var c = $E('tf_C3010005');
    var t = c.value;
    if (t == null || t == '')
    {
        alert('“邮件”不能为空！');
        c.focus();
        return false;
    }
    t = t.replace(/(^\s*)|(\s*$)/g, "");
    if (t == '')
    {
        alert('“邮件”不能为空！');
        c.value = t;
        c.focus();
        return false;
    }
    
    c = $E('tf_C3010007');
    t = c.value;
    if (t == null || t == '')
    {
        alert('“昵称”不能为空！');
        c.focus();
        return false;
    }
    t = t.replace(/(^\s*)|(\s*$)/g, "");
    if (t == '')
    {
        alert('“昵称”不能为空！');
        c.value = t;
        c.focus();
        return false;
    }
    return true;
}
function viewLink()
{
    $A($E('tf_C301000A').value);
}
function checkNull()
{
    var c = $E('tf_P3010105');
    var t = c.value;
    if (t == null || t == '')
    {
        showMesg('“中文名称”不能为空！');
        c.focus();
        return false;
    }
    t = t.replace(/(^\s*)|(\s*$)/g, "");
    if (t == '')
    {
        showMesg('“中文名称”不能为空！');
        c.value = t;
        c.focus();
        return false;
    }
    
    c = $E('cb_P3010103');
    t = c.value;
    if (t == null || t == '')
    {
        showMesg('请选择国别信息！');
        c.focus();
        return false;
    }
    return true;
}

function viewLink()
{
    $A($E('tf_P3010107').value);
}
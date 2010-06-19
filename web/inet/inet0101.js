// JScript File
function rootInfo()
{
    var sid = $E('lb_All').value;
    if(sid==null || sid=='')
    {
        alert('请选择您要查看的数据信息！');
        $E('lb_All').focus();
        return false;
    }
    $W().location.href = 'inet9997.aspx?sid=' + sid;
}
function rootEdit()
{
    var sid = $E('lb_All').value;
    if(sid==null || sid=='')
    {
        alert('请选择您要编辑的数据信息！');
        $E('lb_All').focus();
        return false;
    }
    $W().location.href = 'inet9998.aspx?sid=' + sid;
}
function rootDrop()
{
    var sid = $E('lb_All').value;
    if(sid==null || sid=='')
    {
        alert('请选择您要编辑的数据信息！');
        $E('lb_All').focus();
        return false;
    }
    $W().location.href = 'inet9999.aspx?sid=' + sid + '&sth=' + $E('cb_W2010203').value;
}
function userSort()
{
    var sid = $E('lb_Fav').value;
    if(sid==null || sid=='')
    {
        alert('请选择您要移动的数据信息！');
        $E('lb_Fav').focus();
        return false;
    }
    return true;
}
function addOne()
{
    var v = $E('lb_All').value;
    if(v==null || v.trim()=='')
    {
        alert('请选择您要添加的数据！');
        return false;
    }
    v = eval($E('hd_Size').value);
    if($E('lb_Fav').options.length >= v)
    {
        alert('类别选项不能超过 ' + v + ' 个！');
        return false;
    }
    return true;
}
function delOne()
{
    var v = $E('lb_Fav').value;
    if(v==null || v.trim()=='')
    {
        alert('请选择您要删除的数据！');
        return false;
    }
    return true;
}
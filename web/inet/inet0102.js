// JScript File
function userInfo()
{
    var sid = $E('lb_All').value;
    if(sid==null || sid=='')
    {
        alert('请选择您要查看的数据信息！');
        $E('lb_Fav').focus();
        return false;
    }
    $W().location.href = 'inet0197.aspx?sid=' + sid;
}
function userEdit()
{
    var sid = $E('lb_All').value;
    if(sid==null || sid=='')
    {
        alert('请选择您要编辑的数据信息！');
        $E('lb_Fav').focus();
        return false;
    }
    $W().location.href = 'inet0198.aspx?sid=' + $E('lb_All').value;
}
function userDrop()
{
    var sid = $E('lb_All').value;
    if(sid==null || sid=='')
    {
        alert('请选择您要删除的数据信息！');
        $E('lb_Fav').focus();
        return false;
    }
    $W().location.href = 'inet0199.aspx?sid=' + $E('lb_All').value;
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
function listData()
{
    if($E('cb_W2010203').value == '')
    {
        alert('请选择您要查看的类别！');
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

var b = $E('cb_W2010203').value == 'iNetHelper_90wmi' ? '' : 'none';
var c = $X('dv_Info');
if(c)c.style.display = b;
c = $X('bt_Apnd');
if(c)c.style.display = b;